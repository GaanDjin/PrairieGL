using PrairieGL.Glfw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPrairieGL.VulkanTutorials
{
    public class _00_base_code
    {
        const int WIDTH = 800;
        const int HEIGHT = 600;



        public void run()
        {
            initWindow();
            initVulkan();
            mainLoop();
            cleanup();
        }


        private GLFWwindow window;

        private void initWindow()
        {
            Glfw.Init();

            Glfw.WindowHint(WindowHints.GLFW_CLIENT_API, Glfw.GLFW_NO_API);
            Glfw.WindowHint(WindowHints.GLFW_RESIZABLE, Glfw.GLFW_FALSE);

            window = Glfw.CreateWindow(WIDTH, HEIGHT, "Vulkan", IntPtr.Zero, IntPtr.Zero);
        }

        private void initVulkan()
        {

        }

        private void mainLoop()
        {
            while (!Glfw.WindowShouldClose(window))
            {
                Glfw.PollEvents();
            }
        }

        private void cleanup()
        {
            Glfw.DestroyWindow(window);

            Glfw.Terminate();
        }


        public static int Main()
        {
            _00_base_code app = new _00_base_code();

            try
            {
                app.run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return -1;
            }

            return 0;
        }
    }
}
