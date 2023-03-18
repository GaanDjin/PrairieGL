using PrairieGL.Glfw;
using PrairieGL.Vulkan;

namespace TestPrairieGL.VulkanTutorials
{
    internal class _04_logical_device
    {
        const int WIDTH = 800;
        const int HEIGHT = 600;


        //        VkResult CreateDebugUtilsMessengerEXT(VkInstance instance, const VkDebugUtilsMessengerCreateInfoEXT* pCreateInfo, const VkAllocationCallbacks* pAllocator, VkDebugUtilsMessengerEXT* pDebugMessenger) {
        //    auto func = (PFN_vkCreateDebugUtilsMessengerEXT)vkGetInstanceProcAddr(instance, "vkCreateDebugUtilsMessengerEXT");
        //    if (func != IntPtr.Zero) {
        //        return func(instance, pCreateInfo, pAllocator, pDebugMessenger);
        //    } else {
        //        return VK_ERROR_EXTENSION_NOT_PRESENT;
        //    }
        //}

        //void DestroyDebugUtilsMessengerEXT(VkInstance instance, VkDebugUtilsMessengerEXT debugMessenger, const VkAllocationCallbacks* pAllocator)
        //{
        //    auto func = (PFN_vkDestroyDebugUtilsMessengerEXT)vkGetInstanceProcAddr(instance, "vkDestroyDebugUtilsMessengerEXT");
        //    if (func != IntPtr.Zero)
        //    {
        //        func(instance, debugMessenger, pAllocator);
        //    }
        //}

        

    public void run()
    {
        initWindow();
        initVulkan();
        mainLoop();
        cleanup();
    }

    private GLFWwindow window;

    VkInstance instance;
    VkDebugUtilsMessengerEXT debugMessenger;

    VkPhysicalDevice physicalDevice;
    VkDevice device;

    VkQueue graphicsQueue;

    void initWindow()
    {
        Glfw.Init();

        Glfw.WindowHint( WindowHints.GLFW_CLIENT_API, Glfw.GLFW_NO_API);
        Glfw.WindowHint( WindowHints.GLFW_RESIZABLE, Glfw.GLFW_FALSE);

        window = Glfw.CreateWindow(WIDTH, HEIGHT, "Vulkan", IntPtr.Zero, IntPtr.Zero);
    }

    void initVulkan()
    {
        createInstance();
        //setupDebugMessenger();
        pickPhysicalDevice();
        createLogicalDevice();
    }

    void mainLoop()
    {
        while (!Glfw.WindowShouldClose(window))
        {
            Glfw.PollEvents();
        }
    }

    void cleanup()
    {
        VK.DestroyDevice(device);

            //if (enableValidationLayers)
            //{
            //    DestroyDebugUtilsMessengerEXT(instance, debugMessenger, IntPtr.Zero);
            //}

            VK.DestroyInstance(instance, IntPtr.Zero);

        Glfw.DestroyWindow(window);

        Glfw.Terminate();
    }

    void createInstance()
    {
        //if (enableValidationLayers && !checkValidationLayerSupport())
        //{
        //    throw std::runtime_error("validation layers requested, but not available!");
        //}

        VkApplicationInfo appInfo = new VkApplicationInfo();
        appInfo.sType =  VkStructureType.VK_STRUCTURE_TYPE_APPLICATION_INFO;
        appInfo.pApplicationName = "Hello Triangle";
            appInfo.applicationVersion = 0; // VK_MAKE_VERSION(1, 0, 0);
        appInfo.pEngineName = "No Engine";
            appInfo.engineVersion = 0; // VK_MAKE_VERSION(1, 0, 0);
        appInfo.apiVersion = VK.VK_API_VERSION_1_0;

        VkInstanceCreateInfo createInfo = new VkInstanceCreateInfo();
        createInfo.sType = VkStructureType. VK_STRUCTURE_TYPE_INSTANCE_CREATE_INFO;
        createInfo.pApplicationInfo = appInfo;

        string[] extensions = Glfw.GetRequiredInstanceExtensions();
        createInfo.enabledExtensionCount = (uint)extensions.Length;
        createInfo.ppEnabledExtensionNames = extensions;

        VkDebugUtilsMessengerCreateInfoEXT debugCreateInfo = new VkDebugUtilsMessengerCreateInfoEXT();
        //if (enableValidationLayers)
        //{
        //    createInfo.enabledLayerCount = static_cast<uint32_t>(validationLayers.size());
        //    createInfo.ppEnabledLayerNames = validationLayers.data();

        //    populateDebugMessengerCreateInfo(debugCreateInfo);
        //    createInfo.pNext = (VkDebugUtilsMessengerCreateInfoEXT*)&debugCreateInfo;
        //}
        //else
        {
            createInfo.enabledLayerCount = 0;

            createInfo.pNext = IntPtr.Zero;
        }

            VkResult result = VK.CreateInstance(createInfo, IntPtr.Zero, ref instance);
            if (result != VkResult.VK_SUCCESS)
            {
                throw new Exception("failed to create instance! " + result);
            }
        }

        //void populateDebugMessengerCreateInfo(out VkDebugUtilsMessengerCreateInfoEXT createInfo)
        //{
        //    createInfo = new VkDebugUtilsMessengerCreateInfoEXT();
        //    createInfo.sType = VK_STRUCTURE_TYPE_DEBUG_UTILS_MESSENGER_CREATE_INFO_EXT;
        //    createInfo.messageSeverity = VK_DEBUG_UTILS_MESSAGE_SEVERITY_VERBOSE_BIT_EXT | VK_DEBUG_UTILS_MESSAGE_SEVERITY_WARNING_BIT_EXT | VK_DEBUG_UTILS_MESSAGE_SEVERITY_ERROR_BIT_EXT;
        //    createInfo.messageType = VK_DEBUG_UTILS_MESSAGE_TYPE_GENERAL_BIT_EXT | VK_DEBUG_UTILS_MESSAGE_TYPE_VALIDATION_BIT_EXT | VK_DEBUG_UTILS_MESSAGE_TYPE_PERFORMANCE_BIT_EXT;
        //    createInfo.pfnUserCallback = debugCallback;
        //}

        //void setupDebugMessenger()
        //{
        //    if (!enableValidationLayers) return;

        //    VkDebugUtilsMessengerCreateInfoEXT createInfo;
        //    populateDebugMessengerCreateInfo(createInfo);

        //    if (CreateDebugUtilsMessengerEXT(instance, &createInfo, IntPtr.Zero, &debugMessenger) != VK_SUCCESS)
        //    {
        //        throw std::runtime_error("failed to set up debug messenger!");
        //    }
        //}
        void pickPhysicalDevice()
        {
            //uint deviceCount = 0;
            //VK.EnumeratePhysicalDevices(instance, &deviceCount, nullptr);

            //if (deviceCount == 0)
            //{
            //    throw new Exception("failed to find GPUs with Vulkan support!");
            //}

            VkPhysicalDevice[] devices; // = new VkPhysicalDevice[(deviceCount)];
            VK.EnumeratePhysicalDevices(instance, out devices);

            foreach (VkPhysicalDevice device in devices)
            {
                if (isDeviceSuitable(device))
                {
                    physicalDevice = device;
                    break;
                }
            }

            if (physicalDevice == IntPtr.Zero)
            {
                throw new Exception("failed to find a suitable GPU!");
            }
        }

        bool isDeviceSuitable(VkPhysicalDevice device)
        {
            QueueFamilyIndices indices = findQueueFamilies(device);

            return indices.isComplete();
        }

        QueueFamilyIndices findQueueFamilies(VkPhysicalDevice device)
        {
            QueueFamilyIndices indices = new QueueFamilyIndices();

            //uint queueFamilyCount = 0;
            //        VK.GetPhysicalDeviceQueueFamilyProperties(device, &queueFamilyCount, nullptr);

            //VkQueueFamilyProperties[] queueFamilies = new VkQueueFamilyProperties[queueFamilyCount];
            //        VK.GetPhysicalDeviceQueueFamilyProperties(device, &queueFamilyCount, queueFamilies.data());
            VkQueueFamilyProperties[] queueFamilies = VK.GetPhysicalDeviceQueueFamilyProperties(device);

            uint i = 0;
            foreach (VkQueueFamilyProperties queueFamily in queueFamilies)
            {
                if ((queueFamily.queueFlags & VkQueueFlags.VK_QUEUE_GRAPHICS_BIT) == VkQueueFlags.VK_QUEUE_GRAPHICS_BIT)
                {
                    indices.graphicsFamily = i;
                }

                if (indices.isComplete())
                {
                    break;
                }

                i++;
            }

            return indices;
        }


        void createLogicalDevice()
    {
        QueueFamilyIndices indices = findQueueFamilies(physicalDevice);

        VkDeviceQueueCreateInfo queueCreateInfo = new VkDeviceQueueCreateInfo();
            queueCreateInfo.sType = VkStructureType.VK_STRUCTURE_TYPE_DEVICE_QUEUE_CREATE_INFO;
            queueCreateInfo.queueFamilyIndex = 1; // (uint)indices.graphicsFamily;
            queueCreateInfo.queueCount = 1;

            float queuePriority = 1.0f;
            queueCreateInfo.pQueuePriorities = new float[] { queuePriority };

            //VkPhysicalDeviceFeatures deviceFeatures = new VkPhysicalDeviceFeatures();

        VkDeviceCreateInfo createInfo = new VkDeviceCreateInfo();
        createInfo.sType =  VkStructureType.VK_STRUCTURE_TYPE_DEVICE_CREATE_INFO;

            createInfo.pQueueCreateInfos = new VkDeviceQueueCreateInfo[] { queueCreateInfo };
            createInfo.queueCreateInfoCount = 1;

            createInfo.pEnabledFeatures = VK.GetPhysicalDeviceFeatures(physicalDevice); // deviceFeatures;

            createInfo.enabledExtensionCount = 0;

            //VK.EnumerateDeviceExtensionProperties(physicalDevice,
            //null, out VkExtensionProperties[] pProperties);

            //if (enableValidationLayers)
            //{
            //    createInfo.enabledLayerCount = static_cast<uint32_t>(validationLayers.size());
            //    createInfo.ppEnabledLayerNames = validationLayers.data();
            //}
            //else
            {
            createInfo.enabledLayerCount = 0;
        }

            VkResult resultCreateDevice = VK.CreateDevice(instance, physicalDevice, createInfo, out  device);
        if (resultCreateDevice != VkResult.VK_SUCCESS)
        {
            throw new Exception("failed to create logical device!");
        }

            graphicsQueue = new VkQueue();
        VK.GetDeviceQueue(device, (uint)indices.graphicsFamily, 0, ref graphicsQueue);
    }

    //std::vector<const char*> getRequiredExtensions()
    //{
    //    uint32_t Glfw.ExtensionCount = 0;
    //    const char** Glfw.Extensions;
    //    Glfw.Extensions = Glfw.GetRequiredInstanceExtensions(&Glfw.ExtensionCount);

    //    std::vector <const char*> extensions(Glfw.Extensions, Glfw.Extensions + Glfw.ExtensionCount);

    //    if (enableValidationLayers)
    //    {
    //        extensions.push_back(VK_EXT_DEBUG_UTILS_EXTENSION_NAME);
    //    }

    //    return extensions;
    //}

    //bool checkValidationLayerSupport()
    //{
    //    uint32_t layerCount;
    //    vkEnumerateInstanceLayerProperties(&layerCount, IntPtr.Zero);

    //    std::vector<VkLayerProperties> availableLayers(layerCount);
    //    vkEnumerateInstanceLayerProperties(&layerCount, availableLayers.data());

    //    for (const char* layerName : validationLayers) {
    //        bool layerFound = false;

    //        for (const auto&layerProperties : availableLayers) {
    //            if (strcmp(layerName, layerProperties.layerName) == 0)
    //            {
    //                layerFound = true;
    //                break;
    //            }
    //        }

    //        if (!layerFound)
    //        {
    //            return false;
    //        }
    //    }

    //    return true;
    //}

    //static VKAPI_ATTR VkBool32 VKAPI_CALL debugCallback(VkDebugUtilsMessageSeverityFlagBitsEXT messageSeverity, VkDebugUtilsMessageTypeFlagsEXT messageType, const VkDebugUtilsMessengerCallbackDataEXT* pCallbackData, void* pUserData) {
    //    std::cerr << "validation layer: " << pCallbackData->pMessage << std::endl;

    //    return VK_FALSE;
    //}


public static int Main()
        {
            _04_logical_device app = new _04_logical_device();

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
