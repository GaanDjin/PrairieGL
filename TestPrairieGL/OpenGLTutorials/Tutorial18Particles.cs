using PrairieGL;
using PrairieGL.Glfw;
using PrairieGL.OpenGL;
using System.Numerics;
using System.Runtime.InteropServices;

namespace TestPrairieGL.OpenGLTutorials
{
    internal class Tutorial18Particles
    {
        const string ParticleFragmentShader = @"#version 330 core

// Interpolated values from the vertex shaders
in vec2 UV;
in vec4 particlecolor;

// Ouput data
out vec4 color;

uniform sampler2D mytextureSampler;

void main(){
	// Output color = color of the texture at the specified UV
	color = texture( mytextureSampler, UV ) * particlecolor;

}";

        const string ParticleVertexShader = @"#version 330 core

// Input vertex data, different for all executions of this shader.
layout(location = 0) in vec3 squareVertices;
layout(location = 1) in vec4 xyzs; // Position of the center of the particule and size of the square
layout(location = 2) in vec4 color; // Position of the center of the particule and size of the square

// Output data ; will be interpolated for each fragment.
out vec2 UV;
out vec4 particlecolor;

// Values that stay constant for the whole mesh.
uniform vec3 CameraRight_worldspace;
uniform vec3 CameraUp_worldspace;
uniform mat4 VP; // Model-View-Projection matrix, but without the Model (the position is in BillboardPos; the orientation depends on the camera)

void main()
{
	float particleSize = xyzs.w; // because we encoded it this way.
	vec3 particleCenter_wordspace = xyzs.xyz;
	
	vec3 vertexPosition_worldspace = 
		particleCenter_wordspace
		+ CameraRight_worldspace * squareVertices.x * particleSize
		+ CameraUp_worldspace * squareVertices.y * particleSize;

	// Output position of the vertex
	gl_Position = VP * vec4(vertexPosition_worldspace, 1.0f);

	// UV of the vertex. No special space for this one.
	UV = squareVertices.xy + vec2(0.5, 0.5);
	particlecolor = color;
}";


		static GLFWwindow window;

		// CPU representation of a particle
		public struct Particle : IComparable<Particle>
		{
			public Vector3 pos, speed;
			public byte r, g, b, a; // Color
			public float size, angle, weight;
			public float life; // Remaining life of the particle. if <0 : dead and unused.
			public float cameradistance; // *Squared* distance to the camera. if dead : -1.0f

            public int CompareTo(Particle that)
            {
				return (that.cameradistance > this.cameradistance) ? 1 : -1;
			}

            //		bool operator <(const Particle& that) const {
            //	// Sort in reverse order : far particles drawn first.
            //	return this->cameradistance > that.cameradistance;
            //}
        }
		const int MaxParticles = 100000;
		static Particle[] ParticlesContainer = new Particle[MaxParticles];
		static int LastUsedParticle = 0;

	// Finds a Particle in ParticlesContainer which isn't used yet.
	// (i.e. life < 0);
	static int FindUnusedParticle()
	{

		for (int i = LastUsedParticle; i < MaxParticles; i++)
		{
			if (ParticlesContainer[i].life < 0)
			{
				LastUsedParticle = i;
				return i;
			}
		}

		for (int i = 0; i < LastUsedParticle; i++)
		{
			if (ParticlesContainer[i].life < 0)
			{
				LastUsedParticle = i;
				return i;
			}
		}

		return -1; // All particles are taken, override the first one
	}

		static void SortParticles()
	{
			Array.Sort(ParticlesContainer);
	}

		public static int main( )
	{
		// Initialise GLFW
		if (Glfw.Init() == 0)
		{
			Console.WriteLine("Failed to initialize GLFW\n");

			return -1;
		}

		Glfw.WindowHint(WindowHints.GLFW_SAMPLES, 4);
		Glfw.WindowHint(WindowHints.GLFW_CONTEXT_VERSION_MAJOR, 3);
		Glfw.WindowHint(WindowHints.GLFW_CONTEXT_VERSION_MINOR, 3);
		Glfw.WindowHint(WindowHints.GLFW_OPENGL_FORWARD_COMPAT, 1); // To make MacOS happy; should not be needed
		Glfw.WindowHint(WindowHints.GLFW_OPENGL_PROFILE, Glfw.GLFW_OPENGL_CORE_PROFILE);
		Glfw.WindowHint(WindowHints.GLFW_MAXIMIZED, 1);

		// Open a window and create its OpenGL context
		window = Glfw.CreateWindow(1024, 768, "Tutorial 18 - Particules", IntPtr.Zero, IntPtr.Zero);
		if (window == null)
		{
			Console.WriteLine("Failed to open GLFW window. If you have an Intel GPU, they are not 3.3 compatible. Try the 2.1 version of the tutorials.\n");
			
			Glfw.Terminate();
			return -1;
		}
		Glfw.MakeContextCurrent(window);

		//// Initialize GLEW
		//glewExperimental = true; // Needed for core profile
		//if (glewInit() != GLEW_OK)
		//{
		//	Console.WriteLine("Failed to initialize GLEW\n");
			
		//	Glfw.Terminate();
		//	return -1;
		//}

		// Ensure we can capture the escape key being pressed below
		Glfw.SetInputMode(window, GlfwInputModes.GLFW_STICKY_KEYS, 1);
		// Hide the mouse and enable unlimited mouvement
		Glfw.SetInputMode(window, GlfwCursorModes.GLFW_CURSOR_DISABLED);


		GL.Enable(GLCapabilities.GL_DEBUG_OUTPUT);
		GL.DebugMessageCallbackDelegate debugDelegate = new GL.DebugMessageCallbackDelegate(Tutorial12.DebugOutputCallback);

		GCHandle gch = GCHandle.Alloc(debugDelegate);//GCHandle callBackHandle = GCHandle.Alloc(callback, GCHandleType.Pinned);

		GL.DebugMessageCallback(debugDelegate, IntPtr.Zero);

		// Set the mouse at the center of the screen
		Glfw.PollEvents();
		Glfw.SetCursorPos(window, 1024 / 2, 768 / 2);

			// Dark blue background
			GL.ClearColor(0.0f, 0.0f, 0.4f, 0.0f);

		// Enable depth test
		GL.Enable( GLCapabilities.GL_DEPTH_TEST);
		// Accept fragment if it closer to the camera than the former one
		//glDepthFunc(GL_LESS);

		uint VertexArrayID = GL.GenVertexArray();
			GL.BindVertexArray(VertexArrayID);


		// Create and compile our GLSL program from the shaders
		Shader programID = Shader.LoadShader(ParticleVertexShader, ParticleFragmentShader, false);

		// Vertex shader
		int CameraRight_worldspace_ID = GL.GetUniformLocation(programID.GLHandle, "CameraRight_worldspace");
		int CameraUp_worldspace_ID = GL.GetUniformLocation(programID.GLHandle, "CameraUp_worldspace");
		int ViewProjMatrixID = GL.GetUniformLocation(programID.GLHandle, "VP");

		// fragment shader
		int textureID = GL.GetUniformLocation(programID.GLHandle, "mytextureSampler");


		float[] g_particule_position_size_data = new float[MaxParticles * 4];
		byte[] g_particule_color_data = new byte[MaxParticles * 4];

		for (int i = 0; i < MaxParticles; i++)
		{
				ParticlesContainer[i] = new Particle();
			ParticlesContainer[i].life = -1.0f;
			ParticlesContainer[i].cameradistance = -1.0f;
		}



            Texture texture = new Texture("OpenGLTutorials\\particle.DDS");

		// The VBO containing the 4 vertices of the particles.
		// Thanks to instancing, they will be shared by all particles.
		float[] g_vertex_buffer_data = {
		 -0.5f, -0.5f, 0.0f,
		  0.5f, -0.5f, 0.0f,
		 -0.5f,  0.5f, 0.0f,
		  0.5f,  0.5f, 0.0f,
	};
		uint billboard_vertex_buffer = GL.GenBuffer();
			GL.BindBuffer( BufferTargets.GL_ARRAY_BUFFER, billboard_vertex_buffer);
			GL.BufferData( BufferTargets.GL_ARRAY_BUFFER, g_vertex_buffer_data,  BufferUsages.GL_STATIC_DRAW);

		// The VBO containing the positions and sizes of the particles
		uint particles_position_buffer = GL.GenBuffer();
			GL.BindBuffer( BufferTargets.GL_ARRAY_BUFFER, particles_position_buffer);
			// Initialize with empty (NULL) buffer : it will be updated later, each frame.
			GL.BufferData( BufferTargets. GL_ARRAY_BUFFER, MaxParticles * 4 * sizeof(float), IntPtr.Zero,  BufferUsages.GL_STREAM_DRAW);

		// The VBO containing the colors of the particles
		uint particles_color_buffer = GL.GenBuffer();
			GL.BindBuffer( BufferTargets.GL_ARRAY_BUFFER, particles_color_buffer);
			// Initialize with empty (NULL) buffer : it will be updated later, each frame.
			GL.BufferData( BufferTargets.GL_ARRAY_BUFFER, MaxParticles * 4 * sizeof(byte), IntPtr.Zero,  BufferUsages.GL_STREAM_DRAW);



		double lastTime = Glfw.GetTime();
		do
		{
				// Clear the screen
				GL.Clear( GLColourMasks.GL_COLOR_BUFFER_BIT |  GLColourMasks.GL_DEPTH_BUFFER_BIT);

			double currentTime = Glfw.GetTime();
			float delta = (float)(currentTime - lastTime);
			lastTime = currentTime;


			Controls.computeMatricesFromInputs(window);
			Matrix4x4 ProjectionMatrix = Controls.getProjectionMatrix();
			Matrix4x4 ViewMatrix = Controls.getViewMatrix();

			// We will need the camera's position in order to sort the particles
			// w.r.t the camera's distance.
			// There should be a getCameraPosition() function in common/controls.cpp, 
			// but this works too.
			Vector3 CameraPosition = Controls.getCameraPosition();

			Matrix4x4 ViewProjectionMatrix = ViewMatrix * ProjectionMatrix;


			// Generate 10 new particule each millisecond,
			// but limit this to 16 ms (60 fps), or if you have 1 long frame (1sec),
			// newparticles will be huge and the next frame even longer.
			int newparticles = (int)(delta * 10000.0);
			if (newparticles > (int)(0.016f * 10000.0))
				newparticles = (int)(0.016f * 10000.0);

			for (int i = 0; i < newparticles; i++)
			{
				int particleIndex = FindUnusedParticle();

					if (particleIndex == -1)
						break;

				ParticlesContainer[particleIndex].life = 5.0f; // This particle will live 5 seconds.
				ParticlesContainer[particleIndex].pos = new Vector3(0, 0, -2.0f);

				float spread = 1.5f;
				Vector3 maindir = new Vector3(0.0f, 10.0f, 0.0f);
				// Very bad way to generate a random direction; 
				// See for instance http://stackoverflow.com/questions/5408276/python-uniform-spherical-distribution instead,
				// combined with some user-controlled parameters (main direction, spread, etc)
				Vector3 randomdir =new  Vector3(
					((Random.Shared.Next() % 2000) - 1000.0f) / 1000.0f,
					((Random.Shared.Next() % 2000) - 1000.0f) / 1000.0f,
					((Random.Shared.Next() % 2000) - 1000.0f) / 1000.0f
				);

				ParticlesContainer[particleIndex].speed = maindir + randomdir * spread;


				// Very bad way to generate a random color
				ParticlesContainer[particleIndex].r = (byte)(Random.Shared.Next() % 256);
				ParticlesContainer[particleIndex].g = (byte)(Random.Shared.Next() % 256);
				ParticlesContainer[particleIndex].b = (byte)(Random.Shared.Next() % 256);
				ParticlesContainer[particleIndex].a = (byte)((Random.Shared.Next() % 256) / 3);

				ParticlesContainer[particleIndex].size = (Random.Shared.Next() % 1000) / 2000.0f + 0.1f;

			}



			// Simulate all particles
			int ParticlesCount = 0;
			for (int i = 0; i < MaxParticles; i++)
			{

				Particle p = ParticlesContainer[i]; // shortcut

				if (p.life > 0.0f)
				{

					// Decrease life
					p.life -= delta;
					if (p.life > 0.0f)
					{

							// Simulate simple physics : gravity only, no collisions
							p.speed += new Vector3(0.0f, -9.81f, 0.0f) * (float)delta * 0.5f;
						p.pos += p.speed * (float)delta;
						p.cameradistance = Vector3.Distance(p.pos, CameraPosition);
						//p.pos += new Vector3(0.0f,10.0f, 0.0f) * (float)delta;

						// Fill the GPU buffer
						g_particule_position_size_data[4 * ParticlesCount + 0] = p.pos.X;
						g_particule_position_size_data[4 * ParticlesCount + 1] = p.pos.Y;
						g_particule_position_size_data[4 * ParticlesCount + 2] = p.pos.Z;

						g_particule_position_size_data[4 * ParticlesCount + 3] = p.size;

						g_particule_color_data[4 * ParticlesCount + 0] = p.r;
						g_particule_color_data[4 * ParticlesCount + 1] = p.g;
						g_particule_color_data[4 * ParticlesCount + 2] = p.b;
						g_particule_color_data[4 * ParticlesCount + 3] = p.a;

					}
					else
					{
						// Particles that just died will be put at the end of the buffer in SortParticles();
						p.cameradistance = -1.0f;
					}
						ParticlesContainer[i] = p;
					ParticlesCount++;

				}
			}

			SortParticles();


			//printf("%d ",ParticlesCount);


			// Update the buffers that OpenGL uses for rendering.
			// There are much more sophisticated means to stream data from the CPU to the GPU, 
			// but this is outside the scope of this tutorial.
			// http://www.opengl.org/wiki/Buffer_Object_Streaming


			GL.BindBuffer( BufferTargets.GL_ARRAY_BUFFER, particles_position_buffer);
				GL.BufferData( BufferTargets.GL_ARRAY_BUFFER, g_particule_position_size_data,  BufferUsages.GL_STREAM_DRAW); // Buffer orphaning, a common way to improve streaming perf. See above link for details.
				//GL.BufferSubData( BufferTargets.GL_ARRAY_BUFFER, 0, g_particule_position_size_data);

				GL.BindBuffer( BufferTargets.GL_ARRAY_BUFFER, particles_color_buffer);
				GL.BufferData( BufferTargets.GL_ARRAY_BUFFER, MaxParticles * 4 * sizeof(byte), IntPtr.Zero,  BufferUsages.GL_STREAM_DRAW); // Buffer orphaning, a common way to improve streaming perf. See above link for details.
				GL.BufferSubData( BufferTargets.GL_ARRAY_BUFFER, 0, g_particule_color_data);


				GL.Enable( GLCapabilities.GL_BLEND);
				GL.BlendFunc( BlendingFactor.GL_SRC_ALPHA,  BlendingFactor.GL_ONE_MINUS_SRC_ALPHA);

				// Use our shader
				GL.UseProgram(programID.GLHandle);

				// Bind our texture in texture Unit 0
				GL.ActiveTexture(TextureUnits.GL_TEXTURE0);
				GL.BindTexture( TextureTargets.GL_TEXTURE_2D, texture.ID);
				// Set our "mytextureSampler" sampler to use texture Unit 0
				GL.Uniform1i(textureID, 0);

				// Same as the billboards tutorial
				GL.Uniform3f(CameraRight_worldspace_ID, ViewMatrix.M11, ViewMatrix.M21, ViewMatrix.M31);
				GL.Uniform3f(CameraUp_worldspace_ID, ViewMatrix.M12, ViewMatrix.M22, ViewMatrix.M32);

				GL.UniformMatrix4fv(ViewProjMatrixID, 1, false, ViewProjectionMatrix);

				// 1rst attribute buffer : vertices
				GL.EnableVertexAttribArray(0);
				GL.BindBuffer( BufferTargets.GL_ARRAY_BUFFER, billboard_vertex_buffer);
				GL.VertexAttribPointer(
				0,                  // attribute. No particular reason for 0, but must match the layout in the shader.
				3,                  // size
				 GLDataTypes.GL_FLOAT,           // type
				false,           // normalized?
				0,                  // stride
				0            // array buffer offset
			);

				// 2nd attribute buffer : positions of particles' centers
				GL.EnableVertexAttribArray(1);
				GL.BindBuffer( BufferTargets.GL_ARRAY_BUFFER, particles_position_buffer);
				GL.VertexAttribPointer(
				1,                                // attribute. No particular reason for 1, but must match the layout in the shader.
				4,                                // size : x + y + z + size => 4
				 GLDataTypes.GL_FLOAT,                         // type
				false,                         // normalized?
				0,                                // stride
				0                          // array buffer offset
			);

				// 3rd attribute buffer : particles' colors
				GL.EnableVertexAttribArray(2);
				GL.BindBuffer( BufferTargets.GL_ARRAY_BUFFER, particles_color_buffer);
				GL.VertexAttribPointer(
				2,                                // attribute. No particular reason for 1, but must match the layout in the shader.
				4,                                // size : r + g + b + a => 4
				 GLDataTypes.GL_UNSIGNED_BYTE,                 // type
				true,                          // normalized?    *** YES, this means that the byte[4] will be accessible with a vec4 (floats) in the shader ***
				0,                                // stride
				0                          // array buffer offset
			);

				// These functions are specific to glDrawArrays*Instanced*.
				// The first parameter is the attribute buffer we're talking about.
				// The second parameter is the "rate at which generic vertex attributes advance when rendering multiple instances"
				// http://www.opengl.org/sdk/docs/man/xhtml/glVertexAttribDivisor.xml
				GL.VertexAttribDivisor(0, 0); // particles vertices : always reuse the same 4 vertices -> 0
				GL.VertexAttribDivisor(1, 1); // positions : one per quad (its center)                 -> 1
				GL.VertexAttribDivisor(2, 1); // color : one per quad                                  -> 1

				// Draw the particules !
				// This draws many times a small triangle_strip (which looks like a quad).
				// This is equivalent to :
				// for(i in ParticlesCount) : glDrawArrays(GL_TRIANGLE_STRIP, 0, 4), 
				// but faster.
				GL.DrawArraysInstanced( RenderModes.GL_TRIANGLE_STRIP, 0, 4, ParticlesCount);

				GL.DisableVertexAttribArray(0);
				GL.DisableVertexAttribArray(1);
				GL.DisableVertexAttribArray(2);

			// Swap buffers
			Glfw.SwapBuffers(window);
			Glfw.PollEvents();

		} // Check if the ESC key was pressed or the window was closed
		while (!Glfw.GetKey(window,  KeyboardKeys.GLFW_KEY_ESCAPE) &&
			   !Glfw.WindowShouldClose(window) );


			//delete[] g_particule_position_size_data;

			// Cleanup VBO and shader
			GL.DeleteBuffer(particles_color_buffer);
			GL.DeleteBuffer(particles_position_buffer);
			GL.DeleteBuffer(billboard_vertex_buffer);
			GL.DeleteProgram(programID.GLHandle);
			GL.DeleteTexture(texture.ID);
			GL.DeleteVertexArray(VertexArrayID);

		// Close OpenGL window and terminate GLFW
		Glfw.Terminate();

		return 0;
	}

}
}
