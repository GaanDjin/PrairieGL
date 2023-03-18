using PrairieGL;
using PrairieGL.Glfw;
using PrairieGL.OpenGL;
using System.Numerics;
using System.Runtime.InteropServices;

namespace TestPrairieGL.OpenGLTutorials
{
    internal class Tutorial18Billboards
    {
        const string BillboardFragmentShader = @"#version 330 core

// Interpolated values from the vertex shaders
in vec2 UV;

// Ouput data
out vec4 color;

uniform sampler2D myTextureSampler;

uniform float LifeLevel;

void main(){
	// Output color = color of the texture at the specified UV
	color = texture( myTextureSampler, UV );
	
	// Hardcoded life level, should be in a separate texture.
	if (UV.x < LifeLevel && UV.y > 0.3 && UV.y < 0.7 && UV.x > 0.04 )
		color = vec4(0.2, 0.8, 0.2, 1.0); // Opaque green
}";

		const string BillboardVertexShader = @"#version 330 core

// Input vertex data, different for all executions of this shader.
layout(location = 0) in vec3 squareVertices;

// Output data ; will be interpolated for each fragment.
out vec2 UV;

// Values that stay constant for the whole mesh.
uniform vec3 CameraRight_worldspace;
uniform vec3 CameraUp_worldspace;
uniform mat4 VP; // Model-View-Projection matrix, but without the Model (the position is in BillboardPos; the orientation depends on the camera)
uniform vec3 BillboardPos; // Position of the center of the billboard
uniform vec2 BillboardSize; // Size of the billboard, in world units (probably meters)

void main()
{
	vec3 particleCenter_wordspace = BillboardPos;
	
	vec3 vertexPosition_worldspace = 
		particleCenter_wordspace
		+ CameraRight_worldspace * squareVertices.x * BillboardSize.x
		+ CameraUp_worldspace * squareVertices.y * BillboardSize.y;


	// Output position of the vertex
	gl_Position = VP * vec4(vertexPosition_worldspace, 1.0f);



	// Or, if BillboardSize is in percentage of the screen size (1,1 for fullscreen) :
	//vertexPosition_worldspace = particleCenter_wordspace;
	//gl_Position = VP * vec4(vertexPosition_worldspace, 1.0f); // Get the screen-space position of the particle's center
	//gl_Position /= gl_Position.w; // Here we have to do the perspective division ourselves.
	//gl_Position.xy += squareVertices.xy * vec2(0.2, 0.05); // Move the vertex in directly screen space. No need for CameraUp/Right_worlspace here.
	
	// Or, if BillboardSize is in pixels : 
	// Same thing, just use (ScreenSizeInPixels / BillboardSizeInPixels) instead of BillboardSizeInScreenPercentage.


	// UV of the vertex. No special space for this one.
	UV = squareVertices.xy + vec2(0.5, 0.5);
}";

		public static bool DRAW_CUBE = true;

		static GLFWwindow window;

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
			GLFWmonitorPtr monitor = Glfw.GetPrimaryMonitor();
			GLFWvidmode mode = Glfw.GetVideoMode(monitor);
			
			if (mode.width == 0 || mode.height == 0)
            {
				int count;
				GLFWvidmode[] modes = Glfw.GetVideoModes(monitor, out count);

				for(int i = 0; i < count; i++)
                {
					if (mode.width <= modes[i].width && mode.height <= modes[i].height)
						mode = modes[i];
                }
			}
			
			window = Glfw.CreateWindow(mode.width, mode.height, "Tutorial 18 - Billboards", monitor, IntPtr.Zero);
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
			//GL.DepthFunc( GLComparisonFunctions.GL_LESS);

			uint VertexArrayID = GL.GenVertexArray();
			GL.BindVertexArray(VertexArrayID);


			// Create and compile our GLSL program from the shaders
			Shader programID = Shader.LoadShader(BillboardVertexShader, BillboardFragmentShader, false);

			// Vertex shader
			int CameraRight_worldspace_ID = GL.GetUniformLocation(programID.GLHandle, "CameraRight_worldspace");
			int CameraUp_worldspace_ID = GL.GetUniformLocation(programID.GLHandle, "CameraUp_worldspace");
			int ViewProjMatrixID = GL.GetUniformLocation(programID.GLHandle, "VP");
			int BillboardPosID = GL.GetUniformLocation(programID.GLHandle, "BillboardPos");
			int BillboardSizeID = GL.GetUniformLocation(programID.GLHandle, "BillboardSize");
			int LifeLevelID = GL.GetUniformLocation(programID.GLHandle, "LifeLevel");

			int TextureID = GL.GetUniformLocation(programID.GLHandle, "myTextureSampler");


            Texture texture = new Texture("OpenGLTutorials\\ExampleBillboard.DDS");

			// The VBO containing the 4 vertices of the particles.
			float[] g_vertex_buffer_data = {
		 -0.5f, -0.5f, 0.0f,
		  0.5f, -0.5f, 0.0f,
		 -0.5f,  0.5f, 0.0f,
		  0.5f,  0.5f, 0.0f,
	};
			uint billboard_vertex_buffer = GL.GenBuffer();
			GL.BindBuffer( BufferTargets.GL_ARRAY_BUFFER, billboard_vertex_buffer);
			GL.BufferData( BufferTargets.GL_ARRAY_BUFFER, g_vertex_buffer_data, BufferUsages. GL_DYNAMIC_DRAW);

			Shader cubeProgramID = null;
			int cubeMatrixID = 0;
			uint cubevertexbuffer = 0;
			uint cubecolorbuffer = 0;

			if (DRAW_CUBE)
			{
				// Everything here comes from Tutorial 4
				cubeProgramID = Shader.LoadShader(Tutorial04.TransformVertexShaderVertexShader, Tutorial04.ColorFragmentShaderFragmentShader, false);
				cubeMatrixID = GL.GetUniformLocation(cubeProgramID.GLHandle, "MVP");
				float[] g_cube_vertex_buffer_data = { -1.0f, -1.0f, -1.0f, -1.0f, -1.0f, 1.0f, -1.0f, 1.0f, 1.0f, 1.0f, 1.0f, -1.0f, -1.0f, -1.0f, -1.0f, -1.0f, 1.0f, -1.0f, 1.0f, -1.0f, 1.0f, -1.0f, -1.0f, -1.0f, 1.0f, -1.0f, -1.0f, 1.0f, 1.0f, -1.0f, 1.0f, -1.0f, -1.0f, -1.0f, -1.0f, -1.0f, -1.0f, -1.0f, -1.0f, -1.0f, 1.0f, 1.0f, -1.0f, 1.0f, -1.0f, 1.0f, -1.0f, 1.0f, -1.0f, -1.0f, 1.0f, -1.0f, -1.0f, -1.0f, -1.0f, 1.0f, 1.0f, -1.0f, -1.0f, 1.0f, 1.0f, -1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, -1.0f, -1.0f, 1.0f, 1.0f, -1.0f, 1.0f, -1.0f, -1.0f, 1.0f, 1.0f, 1.0f, 1.0f, -1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, -1.0f, -1.0f, 1.0f, -1.0f, 1.0f, 1.0f, 1.0f, -1.0f, 1.0f, -1.0f, -1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f, -1.0f, 1.0f, 1.0f, 1.0f, -1.0f, 1.0f };
				float[] g_cube_color_buffer_data = { 0.583f, 0.771f, 0.014f, 0.609f, 0.115f, 0.436f, 0.327f, 0.483f, 0.844f, 0.822f, 0.569f, 0.201f, 0.435f, 0.602f, 0.223f, 0.310f, 0.747f, 0.185f, 0.597f, 0.770f, 0.761f, 0.559f, 0.436f, 0.730f, 0.359f, 0.583f, 0.152f, 0.483f, 0.596f, 0.789f, 0.559f, 0.861f, 0.639f, 0.195f, 0.548f, 0.859f, 0.014f, 0.184f, 0.576f, 0.771f, 0.328f, 0.970f, 0.406f, 0.615f, 0.116f, 0.676f, 0.977f, 0.133f, 0.971f, 0.572f, 0.833f, 0.140f, 0.616f, 0.489f, 0.997f, 0.513f, 0.064f, 0.945f, 0.719f, 0.592f, 0.543f, 0.021f, 0.978f, 0.279f, 0.317f, 0.505f, 0.167f, 0.620f, 0.077f, 0.347f, 0.857f, 0.137f, 0.055f, 0.953f, 0.042f, 0.714f, 0.505f, 0.345f, 0.783f, 0.290f, 0.734f, 0.722f, 0.645f, 0.174f, 0.302f, 0.455f, 0.848f, 0.225f, 0.587f, 0.040f, 0.517f, 0.713f, 0.338f, 0.053f, 0.959f, 0.120f, 0.393f, 0.621f, 0.362f, 0.673f, 0.211f, 0.457f, 0.820f, 0.883f, 0.371f, 0.982f, 0.099f, 0.879f };
				cubevertexbuffer = GL.GenBuffer();
				GL.BindBuffer(BufferTargets.GL_ARRAY_BUFFER, cubevertexbuffer);
				GL.BufferData(BufferTargets.GL_ARRAY_BUFFER, g_cube_vertex_buffer_data, BufferUsages.GL_DYNAMIC_DRAW);
				cubecolorbuffer = GL.GenBuffer();
				GL.BindBuffer(BufferTargets.GL_ARRAY_BUFFER, cubecolorbuffer);
				GL.BufferData(BufferTargets.GL_ARRAY_BUFFER, g_cube_color_buffer_data, BufferUsages.GL_DYNAMIC_DRAW);
			}

			double lastTime = Glfw.GetTime();
			do
			{
				// Clear the screen
				GL.Clear( GLColourMasks.GL_COLOR_BUFFER_BIT |  GLColourMasks.GL_DEPTH_BUFFER_BIT);

				double currentTime = Glfw.GetTime();
				double delta = currentTime - lastTime;
				lastTime = currentTime;


				Controls.computeMatricesFromInputs(window);
				Matrix4x4 ProjectionMatrix = Controls.getProjectionMatrix();
				Matrix4x4 ViewMatrix = Controls.getViewMatrix();



				if (DRAW_CUBE)
				{
					// Again : this is just Tutorial 4 !
					GL.Disable(GLCapabilities.GL_BLEND);
					GL.UseProgram(cubeProgramID.GLHandle);
					Matrix4x4 cubeModelMatrix = Matrix4x4.CreateScale(new Vector3(0.2f, 0.2f, 0.2f));
					Matrix4x4 cubeMVP = cubeModelMatrix * ViewMatrix * ProjectionMatrix;
					GL.UniformMatrix4fv(cubeMatrixID, 1, false, cubeMVP);
					GL.EnableVertexAttribArray(0);
					GL.BindBuffer(BufferTargets.GL_ARRAY_BUFFER, cubevertexbuffer);
					GL.VertexAttribPointer(0, 3, GLDataTypes.GL_FLOAT, false, 0, 0);
					GL.EnableVertexAttribArray(1);
					GL.BindBuffer(BufferTargets.GL_ARRAY_BUFFER, cubecolorbuffer);
					GL.VertexAttribPointer(1, 3, GLDataTypes.GL_FLOAT, false, 0, 0);
					GL.DrawArrays(RenderModes.GL_TRIANGLES, 0, 12 * 3);
					GL.DisableVertexAttribArray(0);
					GL.DisableVertexAttribArray(1);
				}



				// We will need the camera's position in order to sort the particles
				// w.r.t the camera's distance.
				// There should be a getCameraPosition() function in common/controls.cpp, 
				// but this works too.
				Vector3 CameraPosition = Controls.getCameraPosition();

				Matrix4x4 ViewProjectionMatrix = ViewMatrix * ProjectionMatrix;





				GL.Enable( GLCapabilities.GL_BLEND);
				GL.BlendFunc( BlendingFactor.GL_SRC_ALPHA,  BlendingFactor.GL_ONE_MINUS_SRC_ALPHA);

				// Use our shader
				GL.UseProgram(programID.GLHandle);

				// Bind our texture in Texture Unit 0
				GL.ActiveTexture( TextureUnits.GL_TEXTURE0);
				GL.BindTexture( TextureTargets.GL_TEXTURE_2D, texture.ID);
				// Set our "myTextureSampler" sampler to use Texture Unit 0
				GL.Uniform1i(TextureID, 0);

				// This is the only interesting part of the tutorial.
				// This is equivalent to mlutiplying (1,0,0) and (0,1,0) by inverse(ViewMatrix).
				// ViewMatrix is orthogonal (it was made this way), 
				// so its inverse is also its transpose, 
				// and transposing a matrix is "free" (inversing is slooow)
				GL.Uniform3f(CameraRight_worldspace_ID, ViewMatrix.M11, ViewMatrix.M21, ViewMatrix.M31);
				GL.Uniform3f(CameraUp_worldspace_ID, ViewMatrix.M12, ViewMatrix.M22, ViewMatrix.M32);

				GL.Uniform3f(BillboardPosID, 0.0f, 0.5f, 0.0f); // The billboard will be just above the cube
				GL.Uniform2f(BillboardSizeID, 1.0f, 0.125f);     // and 1m*12cm, because it matches its 256*32 resolution =)

				// Generate some fake life level and send it to glsl
				float LifeLevel = MathF.Sin((float)currentTime) * 0.1f + 0.7f;
				GL.Uniform1f(LifeLevelID, LifeLevel);

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


				// Draw the billboard !
				// This draws a triangle_strip which looks like a quad.
				GL.DrawArrays( RenderModes.GL_TRIANGLE_STRIP, 0, 4);

				GL.DisableVertexAttribArray(0);


				// Swap buffers
				Glfw.SwapBuffers(window);
				Glfw.PollEvents();

			} // Check if the ESC key was pressed or the window was closed
			while (!Glfw.GetKey(window,  KeyboardKeys.GLFW_KEY_ESCAPE) &&
				   !Glfw.WindowShouldClose(window));


			// Cleanup VBO and shader
			GL.DeleteBuffer(billboard_vertex_buffer);
			GL.DeleteProgram(programID.GLHandle);
			GL.DeleteTexture(texture.ID);
			GL.DeleteVertexArray(VertexArrayID);

			if (DRAW_CUBE)
			{
				GL.DeleteProgram(cubeProgramID.GLHandle);
				GL.DeleteVertexArray(cubevertexbuffer);
				GL.DeleteVertexArray(cubecolorbuffer);
			}
			// Close OpenGL window and terminate GLFW
			Glfw.Terminate();

			return 0;
		}
	}
}
