using PrairieGL.Glfw;
using PrairieGL.Vulkan;
using System.Runtime.InteropServices;

namespace TestPrairieGL.VulkanTutorials
{
    public class _02_validation_layers
    {

        const int WIDTH = 800;
        const int HEIGHT = 600;

        static List<string> validationLayers = new List<string>() 
        { "VK_LAYER_VALVE_steam_overlay" /*, "VK_LAYER_KHRONOS_validation"*/ };

        const bool enableValidationLayers = false;


        VkResult CreateDebugUtilsMessengerEXT(VkInstance instance, VkDebugUtilsMessengerCreateInfoEXT pCreateInfo, out VkDebugUtilsMessengerEXT pDebugMessenger)
        {
            return VK.CreateDebugUtilsMessengerEXT(instance, pCreateInfo, IntPtr.Zero, out pDebugMessenger);
        }

        void DestroyDebugUtilsMessengerEXT(VkInstance instance, VkDebugUtilsMessengerEXT debugMessenger)
        {
            VK.DestroyDebugUtilsMessengerEXT(instance, debugMessenger);
        }


        public void run()
        {
            initWindow();
            initVulkan();
            mainLoop();
            cleanup();
        }

        private GLFWwindow window;

        private VkInstance instance;
        private VkDebugUtilsMessengerEXT debugMessenger;
        private GCHandle debugCreateInfoGCHandle;
        //IntPtr debugCreateInfoGCHandle;
        private GCHandle debugCallbackHandle;

        private void initWindow()
        {
            Glfw.Init();

            Glfw.WindowHint(WindowHints.GLFW_CLIENT_API, Glfw.GLFW_NO_API);
            Glfw.WindowHint(WindowHints.GLFW_RESIZABLE, Glfw.GLFW_FALSE);

            window = Glfw.CreateWindow(WIDTH, HEIGHT, "Vulkan", IntPtr.Zero, IntPtr.Zero);
        }

        private void initVulkan()
        {
            createInstance();
            setupDebugMessenger();
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
            if (enableValidationLayers)
            {
                DestroyDebugUtilsMessengerEXT(instance, debugMessenger);
            }

            VK.DestroyInstance(instance);

            debugCallbackHandle.Free();

            Glfw.DestroyWindow(window);

            Glfw.Terminate();
        }

        private void createInstance()
        {
            if (enableValidationLayers && !checkValidationLayerSupport())
            {
                throw new Exception("validation layers requested, but not available!");
            }

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

            List<string> extensions = getRequiredExtensions();
            createInfo.enabledExtensionCount = (uint)extensions.Count;
            createInfo.ppEnabledExtensionNames = extensions.ToArray();

            if (enableValidationLayers)
            {
                createInfo.enabledLayerCount = (uint)validationLayers.Count;
                createInfo.ppEnabledLayerNames = validationLayers.ToArray();

                VkDebugUtilsMessengerCreateInfoEXT debugCreateInfo;
                populateDebugMessengerCreateInfo(out debugCreateInfo);

                
                //debugCreateInfoGCHandle = GCHandle.Alloc(debugCreateInfo, GCHandleType.Pinned);//GCHandle callBackHandle = GCHandle.Alloc(callback, GCHandleType.Pinned);
                //debugCreateInfoGCHandle = Marshal.AllocCoTaskMem(Marshal.SizeOf(debugCreateInfo));
                //Marshal.StructureToPtr(debugCreateInfo, debugCreateInfoGCHandle, false);
               // createInfo.pNext = debugCreateInfo; // debugCreateInfoGCHandle.AddrOfPinnedObject();
            }
            else
            {
                createInfo.enabledLayerCount = 0;
                createInfo.ppEnabledLayerNames = new string[0];

                //createInfo.pNext = IntPtr.Zero;
            }

            VkResult createResult = VK.CreateInstance(createInfo, IntPtr.Zero, ref instance);

            if (createResult != VkResult.VK_SUCCESS)
            {
                //Marshal.FreeCoTaskMem(debugCreateInfoGCHandle);
                //debugCreateInfoGCHandle.Free();
                throw new Exception("failed to create instance!");
            }

            //Marshal.FreeCoTaskMem(debugCreateInfoGCHandle);
            //debugCreateInfoGCHandle.Free();
        }

        private void populateDebugMessengerCreateInfo(out VkDebugUtilsMessengerCreateInfoEXT createInfo)
        {
            createInfo = new VkDebugUtilsMessengerCreateInfoEXT();
            createInfo.sType = VkStructureType.VK_STRUCTURE_TYPE_DEBUG_UTILS_MESSENGER_CREATE_INFO_EXT;
            createInfo.messageSeverity = VkDebugUtilsMessageSeverityFlagsEXT.VK_DEBUG_UTILS_MESSAGE_SEVERITY_VERBOSE_BIT_EXT | VkDebugUtilsMessageSeverityFlagsEXT.VK_DEBUG_UTILS_MESSAGE_SEVERITY_WARNING_BIT_EXT | VkDebugUtilsMessageSeverityFlagsEXT.VK_DEBUG_UTILS_MESSAGE_SEVERITY_ERROR_BIT_EXT;
            createInfo.messageType = VkDebugUtilsMessageTypeFlagsEXT.VK_DEBUG_UTILS_MESSAGE_TYPE_GENERAL_BIT_EXT | VkDebugUtilsMessageTypeFlagsEXT.VK_DEBUG_UTILS_MESSAGE_TYPE_VALIDATION_BIT_EXT | VkDebugUtilsMessageTypeFlagsEXT.VK_DEBUG_UTILS_MESSAGE_TYPE_PERFORMANCE_BIT_EXT;

            //VkDebugUtilsMessengerCreateInfoEXT.PFN_vkDebugUtilsMessengerCallbackEXT
            //GLdebugDelegate = new VkDebugUtilsMessengerCreateInfoEXT.PFN_vkDebugUtilsMessengerCallbackEXT(debugCallback);

            //debugCallbackHandle = GCHandle.Alloc(GLdebugDelegate, GCHandleType.Pinned);
            //createInfo.pfnUserCallback = debugCallback; // = debugCallbackHandle.AddrOfPinnedObject();
        }

        private void setupDebugMessenger()
        {
            if (!enableValidationLayers) return;

            VkDebugUtilsMessengerCreateInfoEXT createInfo;
            populateDebugMessengerCreateInfo(out createInfo);

            if (CreateDebugUtilsMessengerEXT(instance, createInfo, out debugMessenger) != VkResult.VK_SUCCESS)
            {
                throw new Exception("failed to set up debug messenger!");
            }
        }

        private List<string> getRequiredExtensions()
        {
            string[] glfwExtensions = Glfw.GetRequiredInstanceExtensions();

            List<string> extensions = new List<string>(glfwExtensions);

            if (enableValidationLayers)
            {
                extensions.Add(VK.EXT_DEBUG_UTILS_EXTENSION_NAME);
            }

            return extensions;
        }

        private bool checkValidationLayerSupport()
        {
            //uint layerCount = 0;
            //VkResult result = VK.EnumerateInstanceLayerProperties(ref layerCount);

            //VkLayerProperties[] availableLayers = new VkLayerProperties[layerCount];
            //for(int i = 0; i < availableLayers.Length; i++)
            //{
            //    availableLayers[i] = new VkLayerProperties();
            //}

            VkLayerProperties[] availableLayers;
            VkResult result = VK.EnumerateInstanceLayerProperties(out availableLayers);
                bool layerFound = false;

            foreach (string layerName in validationLayers)
            {

                foreach (VkLayerProperties layerProperties in availableLayers)
                {
                    if (layerName.Equals(layerProperties.layerName))
                    {
                        layerFound = true;
                        break;
                    }
                }

                if (!layerFound)
                {
                    return false;
                }
            }

            return true;
        }

        static uint debugCallback(VkDebugUtilsMessageSeverityFlagBitsEXT messageSeverity, VkDebugUtilsMessageTypeFlagsEXT messageType, VkDebugUtilsMessengerCallbackDataEXT pCallbackData, IntPtr pUserData)
        {
            Console.WriteLine("validation layer: " + pCallbackData.pMessage);

            return 0;

        }

        public static int Main()
        {
            _02_validation_layers app = new _02_validation_layers();

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
