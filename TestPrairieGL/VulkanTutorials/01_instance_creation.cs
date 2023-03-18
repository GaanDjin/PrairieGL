using PrairieGL.Glfw;
using PrairieGL.Vulkan;

namespace TestPrairieGL.VulkanTutorials
{
    public class _01_instance_creation
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

        private VkInstance instance = new VkInstance();

        private void initWindow()
        {
            Glfw.Init();

            Glfw.WindowHint(WindowHints.GLFW_CLIENT_API, Glfw.GLFW_NO_API);
            Glfw.WindowHint(WindowHints.GLFW_RESIZABLE, Glfw.GLFW_FALSE);

            window = Glfw.CreateWindow(WIDTH, HEIGHT, "Vulkan", IntPtr.Zero, IntPtr.Zero);

            if (Glfw.VulkanSupported() == 0)
            {
                throw new Exception("Glfw tells us Vulkan is not supported!");
            }
        }

        private void initVulkan()
        {
            createInstance();
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
            VK.DestroyInstance(instance);

            Glfw.DestroyWindow(window);

            Glfw.Terminate();
        }

        private void createInstance()
        {
            VkApplicationInfo appInfo = new VkApplicationInfo();
            appInfo.sType = VkStructureType.VK_STRUCTURE_TYPE_APPLICATION_INFO;
            appInfo.pApplicationName = "Hello Triangle";
            appInfo.applicationVersion = VK.MakeVersion(0, 0, 0);
            appInfo.pEngineName = "No Engine";
            appInfo.engineVersion = VK.MakeVersion(0, 0, 0);
            appInfo.apiVersion = VK.VK_API_VERSION_1_0;

            VkInstanceCreateInfo createInfo = new VkInstanceCreateInfo();
            createInfo.sType = VkStructureType.VK_STRUCTURE_TYPE_INSTANCE_CREATE_INFO;
            createInfo.pApplicationInfo = appInfo;

            string[] glfwExtensions = Glfw.GetRequiredInstanceExtensions();

            createInfo.enabledExtensionCount = (uint)glfwExtensions.Length;
            createInfo.ppEnabledExtensionNames = glfwExtensions;

            createInfo.enabledLayerCount = 0;

            VkResult result = VK.CreateInstance(createInfo, IntPtr.Zero, ref instance);
            if (result != VkResult.VK_SUCCESS)
            {
                throw new Exception("failed to create instance! Error: " + result);
            }
        }


        public static int Main()
        {
            _01_instance_creation app = new _01_instance_creation();

            try
            {
                app.run();
            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());
                return -1;
            }

            return 0;
        }
    }
}

