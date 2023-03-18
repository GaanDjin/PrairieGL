using PrairieGL;
using PrairieGL.Glfw;
using PrairieGL.OpenGL;
using System.Numerics;

namespace TestPrairieGL.OpenGLTutorials
{
    internal class Tutorial07
    {
        const string TextureFragmentShaderFragmentShader = @"#version 330 core

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
        const string TransformVertexShaderVertexShader = @"#version 330 core

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
}";

		static GLFWwindow window;

		public static int main()
		{
			// Initialise GLFW
			if (Glfw.Init() == 0)
			{
				Console.WriteLine( "Failed to initialize GLFW\n");
				
				return -1;
			}

			Glfw.WindowHint( WindowHints.GLFW_SAMPLES, 4);
			Glfw.WindowHint(WindowHints.GLFW_CONTEXT_VERSION_MAJOR, 3);
			Glfw.WindowHint(WindowHints.GLFW_CONTEXT_VERSION_MINOR, 3);
			Glfw.WindowHint(WindowHints.GLFW_OPENGL_FORWARD_COMPAT, 1); // To make MacOS happy; should not be needed
			Glfw.WindowHint(WindowHints.GLFW_OPENGL_PROFILE, 0x00032001);
			Glfw.WindowHint(WindowHints.GLFW_MAXIMIZED, 1);

			// Open a window and create its OpenGL context
			window = Glfw.CreateWindow(1024, 768, "Tutorial 07 - Model Loading", IntPtr.Zero, IntPtr.Zero);
			if (window == null)
			{
				Console.WriteLine( "Failed to open GLFW window. If you have an Intel GPU, they are not 3.3 compatible. Try the 2.1 version of the tutorials.\n");
				
				Glfw.Terminate();
				return -1;
			}
			Glfw.MakeContextCurrent(window);

			// Initialize GLEW
			//Glew.Experimental = true; // Needed for core profile
			//if (Glew.Init() != GLEW_OK)
			//{
			//	Console.WriteLine( "Failed to initialize GLEW\n");
			//	
			//	Glfw.Terminate();
			//	return -1;
			//}

			// Ensure we can capture the escape key being pressed below
			Glfw.SetInputMode(window, GlfwInputModes.GLFW_STICKY_KEYS, 1);
			// Hide the mouse and enable unlimited mouvement
			Glfw.SetInputMode(window, GlfwCursorModes.GLFW_CURSOR_DISABLED);

			// Set the mouse at the center of the screen
			Glfw.PollEvents();
			Glfw.SetCursorPos(window, 1024 / 2, 768 / 2);

			// Dark blue background
			GL.ClearColor(0.0f, 0.0f, 0.4f, 0.0f);

			// Enable depth test
			GL.Enable( GLCapabilities.GL_DEPTH_TEST);
			// Accept fragment if it closer to the camera than the former one
			GL.DepthFunc( GLComparisonFunctions.GL_LESS);

			// Cull triangles which normal is not towards the camera
			GL.Enable( GLCapabilities.GL_CULL_FACE);

			uint VertexArrayID = GL.GenVertexArray();
			GL.BindVertexArray(VertexArrayID);

			// Create and compile our GLSL program from the shaders
			Shader programID = Shader.LoadShader(TransformVertexShaderVertexShader, TextureFragmentShaderFragmentShader, false);

			// Get a handle for our "MVP" uniform
			int MatrixID = GL.GetUniformLocation(programID.GLHandle, "MVP");

            // Load the texture
            Texture texture = new Texture("OpenGLTutorials\\uvmap.DDS");

			// Get a handle for our "myTextureSampler" uniform
			int TextureID = GL.GetUniformLocation(programID.GLHandle, "myTextureSampler");

			// Read our .obj file
			List<Vector3> vertices;
			List<Vector2> uvs;
			List<Vector3> normals; // Won't be used at the moment.
			bool res = OBJ.loadOBJ("OpenGLTutorials\\cube.obj", out vertices, out uvs, out normals);

			// Load it into a VBO

			uint vertexbuffer = GL.GenBuffer();
			GL.BindBuffer(BufferTargets.GL_ARRAY_BUFFER, vertexbuffer);
			GL.BufferData(BufferTargets.GL_ARRAY_BUFFER, vertices.ToArray(), BufferUsages.GL_STATIC_DRAW);

			uint uvbuffer = GL.GenBuffer();
			GL.BindBuffer(BufferTargets.GL_ARRAY_BUFFER, uvbuffer);
			GL.BufferData(BufferTargets.GL_ARRAY_BUFFER, uvs.ToArray(), BufferUsages.GL_STATIC_DRAW);

			do
			{

				// Clear the screen
				GL.Clear( GLColourMasks.GL_COLOR_BUFFER_BIT |  GLColourMasks.GL_DEPTH_BUFFER_BIT);

				// Use our shader
				GL.UseProgram(programID.GLHandle);

				// Compute the MVP matrix from keyboard and mouse input
				Controls.computeMatricesFromInputs(window);
				Matrix4x4 ProjectionMatrix = Controls.getProjectionMatrix();
				Matrix4x4 ViewMatrix = Controls.getViewMatrix();
				Matrix4x4 ModelMatrix = Matrix4x4.Identity;
				Matrix4x4 MVP = ModelMatrix * ViewMatrix * ProjectionMatrix; // ProjectionMatrix * ViewMatrix * ModelMatrix;

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
					0,                  // attribute
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
					1,                                // attribute
					2,                                // size
					 GLDataTypes.GL_FLOAT,                         // type
					false,                         // normalized?
					0,                                // stride
					0                          // array buffer offset
				);

				// Draw the triangle !
				GL.DrawArrays( RenderModes.GL_TRIANGLES, 0, vertices.Count);

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
