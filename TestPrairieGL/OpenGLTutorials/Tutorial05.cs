using PrairieGL;
using PrairieGL.Glfw;
using PrairieGL.OpenGL;
using System.Numerics;

namespace TestPrairieGL.OpenGLTutorials
{
    internal class Tutorial05
    {
        public static string TextureFragmentShaderFragmentShader = @"#version 330 core

// Interpolated values from the vertex shaders
in vec2 UV;

// Ouput data
out vec3 color;

// Values that stay constant for the whole mesh.
uniform sampler2D myTextureSampler;

void main(){

	// Output color = color of the texture at the specified UV
	color = texture( myTextureSampler, UV ).rgb;
}";
        public static string TransformVertexShaderVertexShader = @"#version 330 core

// Input vertex data, different for all executions of this shader.
layout(location = 0) in vec3 vertexPosition_modelspace;
layout(location = 1) in vec2 vertexUV;

// Output data ; will be interpolated for each fragment.
out vec2 UV;

// Values that stay constant for the whole mesh.
uniform mat4 MVP;

void main(){

	// Output position of the vertex, in clip space : MVP * position
	gl_Position =  MVP * vec4(vertexPosition_modelspace,1);
	
	// UV of the vertex. No special space for this one.
	UV = vertexUV;
}
";
		static GLFWwindow window;

		public static int main()
		{
			// Initialise GLFW
			if (Glfw.Init() == 0)
			{
				Console.WriteLine("Failed to initialize GLFW\n");
				return -1;
			}

			Glfw.WindowHint( WindowHints.GLFW_SAMPLES, 4);
			Glfw.WindowHint(WindowHints.GLFW_CONTEXT_VERSION_MAJOR, 3);
			Glfw.WindowHint(WindowHints.GLFW_CONTEXT_VERSION_MINOR, 3);
			Glfw.WindowHint(WindowHints.GLFW_OPENGL_FORWARD_COMPAT, 1); // To make MacOS happy; should not be needed
			Glfw.WindowHint(WindowHints.GLFW_OPENGL_PROFILE, 0x00032001);
			Glfw.WindowHint(WindowHints.GLFW_MAXIMIZED, 1);

			// Open a window and create its OpenGL context
			window = Glfw.CreateWindow(1024, 768, "Tutorial 05 - Textured Cube", IntPtr.Zero, IntPtr.Zero);
			if (window == null)
			{
				Console.WriteLine("Failed to open GLFW window. If you have an Intel GPU, they are not 3.3 compatible. Try the 2.1 version of the tutorials.\n");
				Glfw.Terminate();
				return -1;
			}
			Glfw.MakeContextCurrent(window);

			// Initialize GLEW
			//Glew.Experimental = true; // Needed for core profile
			//if (Glew.Init() != GLEW_OK)
			//{
			//	Console.WriteLine("Failed to initialize GLEW\n");
			//	return -1;
			//}

			// Ensure we can capture the escape key being pressed below
			Glfw.SetInputMode(window, GlfwInputModes. GLFW_STICKY_KEYS, 1);

			// Dark blue background
			GL.ClearColor(0.0f, 0.0f, 0.4f, 0.0f);

			// Enable depth test
			GL.Enable( GLCapabilities.GL_DEPTH_TEST);
			// Accept fragment if it closer to the camera than the former one
			GL.DepthFunc( GLComparisonFunctions.GL_LESS);

			uint VertexArrayID = GL.GenVertexArray();
			GL.BindVertexArray(VertexArrayID);

			// Create and compile our GLSL program from the shaders
			Shader programID = Shader.LoadShader(TransformVertexShaderVertexShader, TextureFragmentShaderFragmentShader, false);

			// Get a handle for our "MVP" uniform
			int MatrixID = GL.GetUniformLocation(programID.GLHandle, "MVP");

			// Projection matrix : 45° Field of View, 4:3 ratio, display range : 0.1 unit <-> 100 units
			Matrix4x4 Projection = Matrix4x4.CreatePerspectiveFieldOfView((45.0f * MathF.PI * 2f / 360f), 4.0f / 3.0f, 0.1f, 100.0f);
			// Camera matrix
			Matrix4x4 View = Matrix4x4.CreateLookAt(
										new Vector3(4, 3, 3), // Camera is at (4,3,3), in World Space
										new Vector3(0, 0, 0), // and looks at the origin
										new Vector3(0, 1, 0)  // Head is up (set to 0,-1,0 to look upside-down)
								   );
			// Model matrix : an identity matrix (model will be at the origin)
			Matrix4x4 Model = Matrix4x4.Identity; // glm::mat4(1.0f);
												  // Our ModelViewProjection : multiplication of our 3 matrices
			Matrix4x4 MVP = Model * View * Projection; // Projection * View * Model; // Remember, matrix multiplication is the other way around

            // Load the texture using any two methods
            //uint texture = Texture.loadBMP_custom("OpenGLTutorials\\uvtemplate.bmp");
            Texture texture = new Texture("OpenGLTutorials\\uvtemplate.DDS");

			// Get a handle for our "myTextureSampler" uniform
			int TextureID = GL.GetUniformLocation(programID.GLHandle, "myTextureSampler");

			// Our vertices. Tree consecutive floats give a 3D vertex; Three consecutive vertices give a triangle.
			// A cube has 6 faces with 2 triangles each, so this makes 6*2=12 triangles, and 12*3 vertices
			float[] g_vertex_buffer_data = {
		-1.0f,-1.0f,-1.0f,
		-1.0f,-1.0f, 1.0f,
		-1.0f, 1.0f, 1.0f,
		 1.0f, 1.0f,-1.0f,
		-1.0f,-1.0f,-1.0f,
		-1.0f, 1.0f,-1.0f,
		 1.0f,-1.0f, 1.0f,
		-1.0f,-1.0f,-1.0f,
		 1.0f,-1.0f,-1.0f,
		 1.0f, 1.0f,-1.0f,
		 1.0f,-1.0f,-1.0f,
		-1.0f,-1.0f,-1.0f,
		-1.0f,-1.0f,-1.0f,
		-1.0f, 1.0f, 1.0f,
		-1.0f, 1.0f,-1.0f,
		 1.0f,-1.0f, 1.0f,
		-1.0f,-1.0f, 1.0f,
		-1.0f,-1.0f,-1.0f,
		-1.0f, 1.0f, 1.0f,
		-1.0f,-1.0f, 1.0f,
		 1.0f,-1.0f, 1.0f,
		 1.0f, 1.0f, 1.0f,
		 1.0f,-1.0f,-1.0f,
		 1.0f, 1.0f,-1.0f,
		 1.0f,-1.0f,-1.0f,
		 1.0f, 1.0f, 1.0f,
		 1.0f,-1.0f, 1.0f,
		 1.0f, 1.0f, 1.0f,
		 1.0f, 1.0f,-1.0f,
		-1.0f, 1.0f,-1.0f,
		 1.0f, 1.0f, 1.0f,
		-1.0f, 1.0f,-1.0f,
		-1.0f, 1.0f, 1.0f,
		 1.0f, 1.0f, 1.0f,
		-1.0f, 1.0f, 1.0f,
		 1.0f,-1.0f, 1.0f
	};

			// Two UV coordinatesfor each vertex. They were created with Blender.
			float[] g_uv_buffer_data = {
		0.000059f, 1.0f-0.000004f,
		0.000103f, 1.0f-0.336048f,
		0.335973f, 1.0f-0.335903f,
		1.000023f, 1.0f-0.000013f,
		0.667979f, 1.0f-0.335851f,
		0.999958f, 1.0f-0.336064f,
		0.667979f, 1.0f-0.335851f,
		0.336024f, 1.0f-0.671877f,
		0.667969f, 1.0f-0.671889f,
		1.000023f, 1.0f-0.000013f,
		0.668104f, 1.0f-0.000013f,
		0.667979f, 1.0f-0.335851f,
		0.000059f, 1.0f-0.000004f,
		0.335973f, 1.0f-0.335903f,
		0.336098f, 1.0f-0.000071f,
		0.667979f, 1.0f-0.335851f,
		0.335973f, 1.0f-0.335903f,
		0.336024f, 1.0f-0.671877f,
		1.000004f, 1.0f-0.671847f,
		0.999958f, 1.0f-0.336064f,
		0.667979f, 1.0f-0.335851f,
		0.668104f, 1.0f-0.000013f,
		0.335973f, 1.0f-0.335903f,
		0.667979f, 1.0f-0.335851f,
		0.335973f, 1.0f-0.335903f,
		0.668104f, 1.0f-0.000013f,
		0.336098f, 1.0f-0.000071f,
		0.000103f, 1.0f-0.336048f,
		0.000004f, 1.0f-0.671870f,
		0.336024f, 1.0f-0.671877f,
		0.000103f, 1.0f-0.336048f,
		0.336024f, 1.0f-0.671877f,
		0.335973f, 1.0f-0.335903f,
		0.667969f, 1.0f-0.671889f,
		1.000004f, 1.0f-0.671847f,
		0.667979f, 1.0f-0.335851f
	};

			uint vertexbuffer = GL.GenBuffer();
			GL.BindBuffer( BufferTargets.GL_ARRAY_BUFFER, vertexbuffer);
			GL.BufferData( BufferTargets.GL_ARRAY_BUFFER, g_vertex_buffer_data,  BufferUsages.GL_STATIC_DRAW);

			uint uvbuffer = GL.GenBuffer();
			GL.BindBuffer(BufferTargets.GL_ARRAY_BUFFER, uvbuffer);
			GL.BufferData(BufferTargets.GL_ARRAY_BUFFER, g_uv_buffer_data, BufferUsages.GL_STATIC_DRAW);

			do
			{

				// Clear the screen
				GL.Clear(GLColourMasks.GL_COLOR_BUFFER_BIT | GLColourMasks.GL_DEPTH_BUFFER_BIT);

				// Use our shader
				GL.UseProgram(programID.GLHandle);

				// Send our transformation to the currently bound shader, 
				// in the "MVP" uniform
				GL.UniformMatrix4fv(MatrixID, 1, false, MVP);

				// Bind our texture in Texture Unit 0
				GL.ActiveTexture( TextureUnits.GL_TEXTURE0);
				GL.BindTexture( TextureTargets.GL_TEXTURE_2D, texture.ID);
				// Set our "myTextureSampler" sampler to use Texture Unit 0
				GL.Uniform1i(TextureID, 0);

				// 1rst attribute buffer : vertices
				GL.EnableVertexAttribArray(0);
				GL.BindBuffer( BufferTargets.GL_ARRAY_BUFFER, vertexbuffer);
				GL.VertexAttribPointer(
					0,                  // attribute. No particular reason for 0, but must match the layout in the shader.
					3,                  // size
					 GLDataTypes.GL_FLOAT,           // type
					false,           // normalized?
					0,                  // stride
					0            // array buffer offset
				);

				// 2nd attribute buffer : UVs
				GL.EnableVertexAttribArray(1);
				GL.BindBuffer( BufferTargets.GL_ARRAY_BUFFER, uvbuffer);
				GL.VertexAttribPointer(
					1,                                // attribute. No particular reason for 1, but must match the layout in the shader.
					2,                                // size : U+V => 2
					 GLDataTypes.GL_FLOAT,                         // type
					false,                         // normalized?
					0,                                // stride
					0                          // array buffer offset
				);

				// Draw the triangle !
				GL.DrawArrays( RenderModes.GL_TRIANGLES, 0, 12 * 3); // 12*3 indices starting at 0 -> 12 triangles

				GL.DisableVertexAttribArray(0);
				GL.DisableVertexAttribArray(1);

				// Swap buffers
				Glfw.SwapBuffers(window);
				Glfw.PollEvents();

			} // Check if the ESC key was pressed or the window was closed
			while (!Glfw.GetKey(window,  KeyboardKeys.GLFW_KEY_ESCAPE) &&
				   !Glfw.WindowShouldClose(window));

			// Cleanup VBO and shader
			GL.DeleteBuffer(vertexbuffer);
			GL.DeleteBuffer(uvbuffer);
			GL.DeleteProgram(programID.GLHandle);
			GL.DeleteTexture(texture.ID);
			GL.DeleteVertexArray(VertexArrayID);

			// Close OpenGL window and terminate GLFW
			Glfw.Terminate();

			return 0;
		}

	}
}
