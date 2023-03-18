using PrairieGL.Glfw;
using PrairieGL.OpenGL;

namespace TestPrairieGL.OpenGLTutorials
{
    internal class Tutorial01
    {
        static GLFWwindow window;

		public static int main( )
		{
			// Initialise GLFW
			if (Glfw.Init() != 1)
			{
				Console.WriteLine("Failed to initialize GLFW\n");
				
				return -1;
			}

            //GL.Init();

            Glfw.WindowHint(WindowHints.GLFW_SAMPLES, 4);
			Glfw.WindowHint(WindowHints.GLFW_CONTEXT_VERSION_MAJOR, 3);
			Glfw.WindowHint(WindowHints.GLFW_CONTEXT_VERSION_MINOR, 3);
			Glfw.WindowHint(WindowHints.GLFW_OPENGL_FORWARD_COMPAT, 1); // To make MacOS happy; should not be needed
			Glfw.WindowHint(WindowHints.GLFW_OPENGL_PROFILE, 0x00032001);

			// Open a window and create its OpenGL context
			window = Glfw.CreateWindow(1024, 768, "Tutorial 01", IntPtr.Zero, IntPtr.Zero);
			if (window == null)
			{
				Console.WriteLine("Failed to open GLFW window. If you have an Intel GPU, they are not 3.3 compatible. Try the 2.1 version of the tutorials.\n");
				Glfw.Terminate();
				return -1;
			}
			Glfw.MakeContextCurrent(window);

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

			do
			{
				// Clear the screen. It's not mentioned before Tutorial 02, but it can cause flickering, so it's there nonetheless.
				GL.Clear( GLColourMasks.GL_COLOR_BUFFER_BIT);

				// Draw nothing, see you in tutorial 2 !


				// Swap buffers
				Glfw.SwapBuffers(window);
				Glfw.PollEvents();

			} // Check if the ESC key was pressed or the window was closed
			while (!Glfw.GetKey(window, KeyboardKeys.GLFW_KEY_ESCAPE) &&
				   !Glfw.WindowShouldClose(window));

			// Close OpenGL window and terminate GLFW
			Glfw.Terminate();

			return 0;
		}
	}
}
