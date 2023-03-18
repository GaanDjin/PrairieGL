using PrairieGL;
using PrairieGL.Glfw;
using PrairieGL.OpenGL;
using System.Numerics;

namespace TestPrairieGL.OpenGLTutorials
{
    internal class Tutorial03
    {
        public const string SimpleTransformVertexShader = @"#version 330 core

// Input vertex data, different for all executions of this shader.
layout(location = 0) in vec3 vertexPosition_modelspace;

// Values that stay constant for the whole mesh.
uniform mat4 MVP;

void main(){

	// Output position of the vertex, in clip space : MVP * position
	gl_Position =  MVP * vec4(vertexPosition_modelspace,1);

}";

        public const string SingleColorFragmentShader = @"#version 330 core

// Output data
out vec3 color;

void main()
{

	// Output color = red 
	color = vec3(1,0,0);

}";

		public static GLFWwindow window;

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
			Glfw.WindowHint(WindowHints.GLFW_OPENGL_PROFILE, 0x00032001); //We don't want the old OpenGL 

			// Open a window and create its OpenGL context
			window = Glfw.CreateWindow(1024, 768, "Tutorial 03 - Matrices", IntPtr.Zero, IntPtr.Zero);
			if (window == null)
			{
				Console.WriteLine("Failed to open GLFW window. If you have an Intel GPU, they are not 3.3 compatible. Try the 2.1 version of the tutorials.\n");
				Glfw.Terminate();
				return -1;
			}
			Glfw.MakeContextCurrent(window);

			//// Initialize GLEW
			//Glew.Experimental = true; // Needed for core profile
			//if (Glew.Init() != GLEW_OK)
			//{
			//	Console.WriteLine("Failed to initialize GLEW\n");
			//	Glfw.Terminate();
			//	return -1;
			//}

			// Ensure we can capture the escape key being pressed below
			Glfw.SetInputMode(window, GlfwInputModes.GLFW_STICKY_KEYS, 1);

			// Dark blue background
			GL.ClearColor(0.0f, 0.0f, 0.4f, 0.0f);

			uint VertexArrayID = GL.GenVertexArray();
			GL.BindVertexArray(VertexArrayID);

			// Create and compile our GLSL program from the shaders
			Shader programID = Shader.LoadShader(SimpleTransformVertexShader, SingleColorFragmentShader, false);

			// Get a handle for our "MVP" uniform
			int MatrixID = GL.GetUniformLocation(programID.GLHandle, "MVP");

			// Projection matrix : 45° Field of View, 4:3 ratio, display range : 0.1 unit <-> 100 units
			Matrix4x4 Projection = Matrix4x4.CreatePerspectiveFieldOfView((45.0f * MathF.PI * 2f / 360f), 4.0f / 3.0f, 0.1f, 100.0f);
			// Or, for an ortho camera :
			//glm::mat4 Projection = glm::ortho(-10.0f,10.0f,-10.0f,10.0f,0.0f,100.0f); // In world coordinates

			// Camera matrix
			Matrix4x4 View = Matrix4x4.CreateLookAt(
										new Vector3(4, 3, 3), // Camera is at (4,3,3), in World Space
										new Vector3(0, 0, 0), // and looks at the origin
										new Vector3(0, 1, 0)  // Head is up (set to 0,-1,0 to look upside-down)
								   );
			// Model matrix : an identity matrix (model will be at the origin)
			Matrix4x4 Model = Matrix4x4.Identity; // new Matrix4x4(1.0f);
												  // Our ModelViewProjection : multiplication of our 3 matrices
			Matrix4x4 MVP = Model * View * Projection; //Projection * View * Model; // Remember, matrix multiplication is the other way around

			float[] g_vertex_buffer_data = {
				-1.0f, -1.0f, 0.0f,
				 1.0f, -1.0f, 0.0f,
				 0.0f,  1.0f, 0.0f,
			};

			uint vertexbuffer = GL.GenBuffer();
			GL.BindBuffer( BufferTargets.GL_ARRAY_BUFFER, vertexbuffer);
			GL.BufferData( BufferTargets.GL_ARRAY_BUFFER, g_vertex_buffer_data, BufferUsages.GL_STATIC_DRAW);

			do
			{

				// Clear the screen
				GL.Clear( GLColourMasks.GL_COLOR_BUFFER_BIT);

				// Use our shader
				GL.UseProgram(programID.GLHandle);

				// Send our transformation to the currently bound shader, 
				// in the "MVP" uniform
				GL.UniformMatrix4fv(MatrixID, 1, false, MVP);

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

				// Draw the triangle !
				GL.DrawArrays( RenderModes.GL_TRIANGLES, 0, 3); // 3 indices starting at 0 -> 1 triangle

				GL.DisableVertexAttribArray(0);

				// Swap buffers
				Glfw.SwapBuffers(window);
				Glfw.PollEvents();

			} // Check if the ESC key was pressed or the window was closed
			while (!Glfw.GetKey(window,  KeyboardKeys.GLFW_KEY_ESCAPE) &&
				   !Glfw.WindowShouldClose(window));

			// Cleanup VBO and shader
			GL.DeleteBuffer(vertexbuffer);
			GL.DeleteProgram(programID.GLHandle);
			GL.DeleteVertexArray(VertexArrayID);

			// Close OpenGL window and terminate GLFW
			Glfw.Terminate();

			return 0;
		}
	}
}
