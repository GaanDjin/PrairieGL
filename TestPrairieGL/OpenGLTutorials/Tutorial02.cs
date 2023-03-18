using PrairieGL;
using PrairieGL.Glfw;
using PrairieGL.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPrairieGL.OpenGLTutorials
{
	public class Tutorial02
	{
		static GLFWwindow window;

		const string SimpleVertexShader = @"#version 330 core

// Input vertex data, different for all executions of this shader.
layout(location = 0) in vec3 vertexPosition_modelspace;

void main(){

    gl_Position.xyz = vertexPosition_modelspace;
    gl_Position.w = 1.0;

}";

		const string SimpleFragmentShader = @"#version 330 core

// Ouput data
out vec3 color;

void main()
{

	// Output color = red 
	color = vec3(1,0,0);

}";

		public static int main()
		{
			// Initialise GLFW
			if (Glfw.Init() != 1)
			{
				Console.WriteLine("Failed to initialize GLFW\n");

				return -1;
            }

            Glfw.WindowHint(WindowHints.GLFW_SAMPLES, 4);
			Glfw.WindowHint(WindowHints.GLFW_CONTEXT_VERSION_MAJOR, 3);
			Glfw.WindowHint(WindowHints.GLFW_CONTEXT_VERSION_MINOR, 3);
			Glfw.WindowHint(WindowHints.GLFW_OPENGL_FORWARD_COMPAT, 1); // To make MacOS happy; should not be needed
			Glfw.WindowHint(WindowHints.GLFW_OPENGL_PROFILE, 0x00032001);

			// Open a window and create its OpenGL context
			window = Glfw.CreateWindow(1024, 768, "Tutorial 02 - Red triangle", IntPtr.Zero, IntPtr.Zero);
			if (window == null)
			{
				Console.WriteLine("Failed to open GLFW window. If you have an Intel GPU, they are not 3.3 compatible. Try the 2.1 version of the tutorials.\n");
				Glfw.Terminate();
				return -1;
			}
			Glfw.MakeContextCurrent(window);

			//We don't use Glew here.
			//// Initialize GLEW
			//if (Glew.Init() != GLEW_OK)
			//{
			//	Console.WriteLine("Failed to initialize GLEW\n");
			//	Glfw.Terminate();
			//	return -1;
			//}

			// Ensure we can capture the escape key being pressed below
			Glfw.SetInputMode(window, GlfwInputModes.GLFW_STICKY_KEYS, true);

            // Dark blue background
            GL.ClearColor(0.0f, 0.0f, 0.4f, 0.0f);

			uint VertexArrayID = GL.GenVertexArray();
			GL.BindVertexArray(VertexArrayID);

			// Create and compile our GLSL program from the shaders
			Shader programID = Shader.LoadShader(SimpleVertexShader, SimpleFragmentShader, false);


			float[] g_vertex_buffer_data = {
		-1.0f, -1.0f, 0.0f,
		 1.0f, -1.0f, 0.0f,
		 0.0f,  1.0f, 0.0f,
	};

			uint vertexbuffer = GL.GenBuffer();
			GL.BindBuffer(BufferTargets.GL_ARRAY_BUFFER, vertexbuffer);
			GL.BufferData(BufferTargets.GL_ARRAY_BUFFER, g_vertex_buffer_data, BufferUsages.GL_STATIC_DRAW);


			do
			{
				// Clear the screen. It's not mentioned before Tutorial 02, but it can cause flickering, so it's there nonetheless.
				GL.Clear(GLColourMasks.GL_COLOR_BUFFER_BIT);


				// Use our shader
				GL.UseProgram(programID.GLHandle);

				// 1rst attribute buffer : vertices
				GL.EnableVertexAttribArray(0);
				GL.BindBuffer(BufferTargets.GL_ARRAY_BUFFER, vertexbuffer);
				GL.VertexAttribPointer(
					0,                  // attribute 0. No particular reason for 0, but must match the layout in the shader.
					3,                  // size
					GLDataTypes.GL_FLOAT,           // type
					false,           // normalized?
					0,                  // stride
					0            // array buffer offset
				);

				// Draw the triangle !
				GL.DrawArrays(RenderModes.GL_TRIANGLES, 0, 3); // 3 indices starting at 0 -> 1 triangle

				GL.DisableVertexAttribArray(0);




				// Swap buffers
				Glfw.SwapBuffers(window);
				Glfw.PollEvents();

			} // Check if the ESC key was pressed or the window was closed
			while (!Glfw.GetKey(window, KeyboardKeys.GLFW_KEY_ESCAPE) &&
				   !Glfw.WindowShouldClose(window));


			// Cleanup VBO
			GL.DeleteBuffer(vertexbuffer);
			GL.DeleteVertexArray(VertexArrayID);
			GL.DeleteProgram(programID.GLHandle);


			// Close OpenGL window and terminate GLFW
			Glfw.Terminate();

			return 0;
		}
	}
}
