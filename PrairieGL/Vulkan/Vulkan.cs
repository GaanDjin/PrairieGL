using System.Runtime.InteropServices;

namespace PrairieGL.Vulkan
{
    /// <summary>
    ///TODO: I tried to get Vulkan to work but it just failed a few calls in with null pointers.
    ///
    /// I can't get past vkCreateDevice. It just gives me a nonsensical error:
    /// "Typelib export: Type library is not registered. (0x80131165)'"
    /// Windows 10 Home, 21H1 OS Build 19043.2364
    /// </summary>
    public class VK
    {
        #region Constants
        public const int VK_ATTACHMENT_UNUSED = (~0);
        public const float VK_LOD_CLAMP_NONE = 1000.0f;
        public const uint VK_QUEUE_FAMILY_IGNORED = unchecked((uint)~0);
        public const int VK_REMAINING_ARRAY_LAYERS = (~0);
        public const int VK_REMAINING_MIP_LEVELS = (~0);
        public const uint VK_SUBPASS_EXTERNAL = unchecked((uint)(~0));
        public const int VK_WHOLE_SIZE = (~0);
        public const int VK_MAX_MEMORY_TYPES = 32;
        public const int VK_MAX_PHYSICAL_DEVICE_NAME_SIZE = 256;
        public const int VK_UUID_SIZE = 16;
        public const int VK_MAX_EXTENSION_NAME_SIZE = 256;
        public const int VK_MAX_DESCRIPTION_SIZE = 256;
        public const int VK_MAX_MEMORY_HEAPS = 16;
        public const int VK_MAX_DEVICE_GROUP_SIZE = 32;
        public const int VK_LUID_SIZE = 8;
        public const int VK_MAX_DRIVER_NAME_SIZE = 256;
        public const int VK_MAX_DRIVER_INFO_SIZE = 256;
        public const int VK_MAX_GLOBAL_PRIORITY_SIZE_KHR = 16;
        public const int VK_MAX_SHADER_MODULE_IDENTIFIER_SIZE_EXT = 32;

        #endregion

        #region Delegates


        public delegate Bool32 PFN_vkDebugUtilsMessengerCallbackEXT(
        VkDebugUtilsMessageSeverityFlagBitsEXT messageSeverity,
        VkDebugUtilsMessageTypeFlagsEXT messageTypes,
         VkDebugUtilsMessengerCallbackDataEXT pCallbackData,
        IntPtr pUserData);

        #endregion

        [DllImport("vulkan-1.dll", EntryPoint = "vkGetInstanceProcAddr", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr GetInstanceProcAddr(VkInstance instance, string pName);


        [DllImport("vulkan-1.dll", EntryPoint = "vkGetDeviceProcAddr", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr GetDeviceProcAddr(VkDevice device, string pName);



        public static readonly uint VK_API_VERSION_1_0 = MakeApiVersion(0, 1, 0, 0); // Patch version should always be set to 0
        public const string EXT_DEBUG_UTILS_EXTENSION_NAME = "VK_EXT_debug_utils";

        public static uint MakeVersion(int major, int minor, int patch)
        {
            return ((((uint)(major)) << 22) | (((uint)(minor)) << 12) | ((uint)(patch)));
        }
        public static uint MakeVersion(uint major, uint minor, uint patch)
        {
            return ((((major)) << 22) | (((minor)) << 12) | ((patch)));
        }
        public static uint MakeApiVersion(int variant, int major, int minor, int patch)
        {
            return ((((uint)(variant)) << 29) | (((uint)(major)) << 22) | (((uint)(minor)) << 12) | ((uint)(patch)));
        }
        public static uint MakeApiVersion(uint variant, uint major, uint minor, uint patch)
        {
            return ((((variant)) << 29) | (((major)) << 22) | (((minor)) << 12) | ((patch)));
        }

        [DllImport("vulkan-1.dll", EntryPoint = "vkCreateInstance", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern VkResult CreateInstance(
            VkInstanceCreateInfo pCreateInfo,
            IntPtr pAllocator,
            ref VkInstance pInstance);

        [DllImport("vulkan-1.dll", EntryPoint = "vkCreateInstance", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern VkResult CreateInstance(
            VkInstanceCreateInfo pCreateInfo,
            VkAllocationCallbacks pAllocator,
            ref VkInstance pInstance);

        [DllImport("vulkan-1.dll", EntryPoint = "vkDestroyInstance", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void DestroyInstance(
            VkInstance instance,
            VkAllocationCallbacks pAllocator);


        [DllImport("vulkan-1.dll", EntryPoint = "vkDestroyInstance", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void DestroyInstance(
            VkInstance instance,
            IntPtr pAllocator);

        public static void DestroyInstance(
            VkInstance instance)
        {
            DestroyInstance(instance, IntPtr.Zero);
        }

        [DllImport("vulkan-1.dll", EntryPoint = "vkAllocateCommandBuffers", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern VkResult AllocateCommandBuffers(
                    VkDevice device,
                    VkCommandBufferAllocateInfo pAllocateInfo,
                    out VkCommandBuffer pCommandBuffers);

        [DllImport("vulkan-1.dll", EntryPoint = "vkAllocateDescriptorSets", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern VkResult AllocateDescriptorSets(
           VkDevice device,
           VkDescriptorSetAllocateInfo pAllocateInfo,
           out VkDescriptorSet pDescriptorSets);

        [DllImport("vulkan-1.dll", EntryPoint = "vkAllocateMemory", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern VkResult AllocateMemory(
            VkDevice device,
            VkMemoryAllocateInfo pAllocateInfo,
            VkAllocationCallbacks pAllocator,
            out VkDeviceMemory pMemory);

        /// <summary>
        /// Begins recording a command buffer
        /// </summary>
        /// <param name="commandBuffer">the command buffer which is to be put in the recording state.</param>
        /// <param name="pBeginInfo">a VkCommandBufferBeginInfo structure defining additional information about how the command buffer begins recording.</param>
        /// <returns></returns>
        [DllImport("vulkan-1.dll", EntryPoint = "vkBeginCommandBuffer", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern VkResult BeginCommandBuffer(
            VkCommandBuffer commandBuffer,
            VkCommandBufferBeginInfo pBeginInfo);

        [DllImport("vulkan-1.dll", EntryPoint = "vkBindBufferMemory", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern VkResult BindBufferMemory(
            VkDevice device,
            VkBuffer buffer,
            VkDeviceMemory memory,
            ulong memoryOffset);


        [DllImport("vulkan-1.dll", EntryPoint = "vkBindImageMemory", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern VkResult BindImageMemory(
            VkDevice device,
            VkImage image,
            VkDeviceMemory memory,
            ulong memoryOffset);


        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdBeginRenderPass", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void CmdBeginRenderPass(
            VkCommandBuffer commandBuffer,
            VkRenderPassBeginInfo pRenderPassBegin,
            VkSubpassContents contents);

        // Bind descriptor sets describing shader binding points
        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdBindDescriptorSets", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void CmdBindDescriptorSets(
            VkCommandBuffer commandBuffer,
            VkPipelineBindPoint pipelineBindPoint,
            VkPipelineLayout layout,
            uint firstSet,
            uint descriptorSetCount,
            VkDescriptorSet[] pDescriptorSets,
            uint dynamicOffsetCount,
            uint[] pDynamicOffsets);


        // Bind triangle index buffer
        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdBindIndexBuffer", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void CmdBindIndexBuffer(
            VkCommandBuffer commandBuffer,
            VkBuffer buffer,
            ulong offset,
            VkIndexType indexType);


        // Bind the rendering pipeline
        // The pipeline (state obj) contains all states of the rendering pipeline, binding it will set all the states specified at pipeline creation time
        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdBindPipeline", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void CmdBindPipeline(
            VkCommandBuffer commandBuffer,
            VkPipelineBindPoint pipelineBindPoint,
            VkPipeline pipeline);


        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdBindVertexBuffers", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void CmdBindVertexBuffers(
            VkCommandBuffer commandBuffer,
            uint firstBinding,
            uint bindingCount,
            VkBuffer[] pBuffers,
            ulong[] pOffsets);


        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdCopyBuffer", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void CmdCopyBuffer(
            VkCommandBuffer commandBuffer,
            VkBuffer srcBuffer,
            VkBuffer dstBuffer,
            uint regionCount,
            VkBufferCopy[] pRegions);


        // Draw indexed triangle
        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdDrawIndexed", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void CmdDrawIndexed(
            VkCommandBuffer commandBuffer,
            uint indexCount,
            uint instanceCount,
            uint firstIndex,
            int vertexOffset,
            uint firstInstance);

        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdEndRenderPass", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void CmdEndRenderPass(VkCommandBuffer commandBuffer);


        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdSetScissor", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void CmdSetScissor(
            VkCommandBuffer commandBuffer,
            uint firstScissor,
            uint scissorCount,
            VkRect2D[] pScissors);

        [DllImport("vulkan-1.dll", EntryPoint = "vkCmdSetViewport", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void CmdSetViewport(
            VkCommandBuffer commandBuffer,
            uint firstViewport,
            uint viewportCount,
            VkViewport[] pViewports);

        [DllImport("vulkan-1.dll", EntryPoint = "vkCreateBuffer", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern VkResult CreateBuffer(
            VkDevice device,
            VkBufferCreateInfo pCreateInfo,
            VkAllocationCallbacks pAllocator,
            out VkBuffer pBuffer);


        [DllImport("vulkan-1.dll", EntryPoint = "vkCreateDebugUtilsMessengerEXT", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern VkResult CreateDebugUtilsMessengerEXT(
            VkInstance instance,
            VkDebugUtilsMessengerCreateInfoEXT pCreateInfo,
            VkAllocationCallbacks pAllocator,
            out VkDebugUtilsMessengerEXT pMessenger);

        [DllImport("vulkan-1.dll", EntryPoint = "vkCreateDebugUtilsMessengerEXT", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern VkResult CreateDebugUtilsMessengerEXT(
    VkInstance instance,
    VkDebugUtilsMessengerCreateInfoEXT pCreateInfo,
    IntPtr pAllocator,
    out VkDebugUtilsMessengerEXT pMessenger);

        public static VkResult CreateDebugUtilsMessengerEXT(
VkInstance instance,
VkDebugUtilsMessengerCreateInfoEXT pCreateInfo,
out VkDebugUtilsMessengerEXT pMessenger)
        {
            return CreateDebugUtilsMessengerEXT(instance, pCreateInfo, IntPtr.Zero, out pMessenger);
        }


        [DllImport("vulkan-1.dll", EntryPoint = "vkCreateDevice", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern VkResult CreateDevice(
            VkPhysicalDevice physicalDevice,
            VkDeviceCreateInfo pCreateInfo,
            VkAllocationCallbacks pAllocator,
            ref VkDevice pDevice);

        [DllImport("vulkan-1.dll", EntryPoint = "vkCreateDevice", CallingConvention = CallingConvention.Cdecl/*, CharSet = CharSet.Ansi*/)]

        public static extern VkResult CreateDevice(
            VkPhysicalDevice physicalDevice,
            VkDeviceCreateInfo pCreateInfo,
            IntPtr pAllocator,
            [In, Out] VkDevice pDevice);

        static IntPtr GetAddress(string procName)
        {
            IntPtr vulkandll = WindowsApi.GetModuleHandle("vulkan-1.dll");
            return WindowsApi.GetProcAddress(vulkandll, procName);
        }

        public static VkResult CreateDevice(
            VkInstance instance,
            VkPhysicalDevice physicalDevice,
            VkDeviceCreateInfo pCreateInfo,
            out VkDevice pDevice)
        {
            pDevice = new VkDevice();
            //return CreateDevice(physicalDevice, pCreateInfo, IntPtr.Zero, pDevice);

            IntPtr ptr = VK.GetInstanceProcAddr(instance, "vkCreateDevice");

            //IntPtr ptr2 = GetAddress("vkCreateDevice");

            VulkanDelegates.vkCreateDevice devDel = (VulkanDelegates.vkCreateDevice)Marshal.GetDelegateForFunctionPointer(ptr, typeof(VulkanDelegates.vkCreateDevice));


            return devDel(physicalDevice, pCreateInfo, IntPtr.Zero, pDevice);
        }

        [DllImport("vulkan-1.dll", EntryPoint = "vkDestroyDebugUtilsMessengerEXT", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void DestroyDebugUtilsMessengerEXT(
            VkInstance instance,
            VkDebugUtilsMessengerEXT messenger,
            VkAllocationCallbacks pAllocator);

        [DllImport("vulkan-1.dll", EntryPoint = "vkDestroyDebugUtilsMessengerEXT", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void DestroyDebugUtilsMessengerEXT(
            VkInstance instance,
            VkDebugUtilsMessengerEXT messenger,
            IntPtr pAllocator);

        public static void DestroyDebugUtilsMessengerEXT(
    VkInstance instance,
    VkDebugUtilsMessengerEXT messenger)
        {
            DestroyDebugUtilsMessengerEXT(instance, messenger, IntPtr.Zero);
        }


        [DllImport("vulkan-1.dll", EntryPoint = "vkCreateDescriptorPool", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern VkResult CreateDescriptorPool(
            VkDevice device,
            VkDescriptorPoolCreateInfo pCreateInfo,
            VkAllocationCallbacks pAllocator,
            out VkDescriptorPool pDescriptorPool);

        [DllImport("vulkan-1.dll", EntryPoint = "vkCreateDescriptorSetLayout", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern VkResult CreateDescriptorSetLayout(
            VkDevice device,
            VkDescriptorSetLayoutCreateInfo pCreateInfo,
            VkAllocationCallbacks pAllocator,
            out VkDescriptorSetLayout pSetLayout);


        /// <summary>
        /// Fences are a synchronization primitive that can be used to insert a dependency 
        /// from a queue to the host. 
        /// Fences have two states - signaled and unsignaled. 
        /// A fence can be signaled as part of the execution of a queue submission command.
        /// Fences can be unsignaled on the host with vkResetFences. 
        /// Fences can be waited on by the host with the vkWaitForFences command, 
        /// and the current state can be queried with vkGetFenceStatus.
        /// </summary>
        /// <param name="device">The logical device that creates the fence.</param>
        /// <param name="pCreateInfo">a VkFenceCreateInfo structure containing information about how the fence is to be created.</param>
        /// <param name="pAllocator">controls host memory allocation as described in the Memory Allocation chapter.</param>
        /// <param name="pFence">a handle in which the resulting fence object is returned.</param>
        /// <returns></returns>
        [DllImport("vulkan-1.dll", EntryPoint = "vkCreateFence", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern VkResult CreateFence(
            VkDevice device,
            VkFenceCreateInfo pCreateInfo,
            VkAllocationCallbacks pAllocator,
            out VkFence pFence);

        [DllImport("vulkan-1.dll", EntryPoint = "vkCreateFramebuffer", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern VkResult CreateFramebuffer(
            VkDevice device,
            VkFramebufferCreateInfo pCreateInfo,
            VkAllocationCallbacks pAllocator,
            out VkFramebuffer pFramebuffer);

        [DllImport("vulkan-1.dll", EntryPoint = "vkCreateGraphicsPipelines", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern VkResult CreateGraphicsPipelines(
            VkDevice device,
            VkPipelineCache pipelineCache,
            uint createInfoCount,
            VkGraphicsPipelineCreateInfo[] pCreateInfos,
            VkAllocationCallbacks pAllocator,
            out VkPipeline[] pPipelines);

        [DllImport("vulkan-1.dll", EntryPoint = "vkCreateImage", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern VkResult CreateImage(
            VkDevice device,
            VkImageCreateInfo pCreateInfo,
            VkAllocationCallbacks pAllocator,
            out VkImage pImage);

        [DllImport("vulkan-1.dll", EntryPoint = "vkCreateImageView", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern VkResult CreateImageView(
            VkDevice device,
            VkImageViewCreateInfo pCreateInfo,
            VkAllocationCallbacks pAllocator,
            out VkImageView pView);

        [DllImport("vulkan-1.dll", EntryPoint = "vkCreatePipelineLayout", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern VkResult CreatePipelineLayout(
            VkDevice device,
            VkPipelineLayoutCreateInfo pCreateInfo,
            VkAllocationCallbacks pAllocator,
            out VkPipelineLayout pPipelineLayout);

        [DllImport("vulkan-1.dll", EntryPoint = "vkCreateRenderPass", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern VkResult CreateRenderPass(
            VkDevice device,
            VkRenderPassCreateInfo pCreateInfo,
            VkAllocationCallbacks pAllocator,
            out VkRenderPass pRenderPass);

        /// <summary>
        /// Semaphores are a synchronization primitive that can be used to insert a dependency between queue operations or between a queue operation and the host.
        /// </summary>
        /// <param name="device">the logical device that creates the semaphore.</param>
        /// <param name="pCreateInfo">a VkSemaphoreCreateInfo structure containing information about how the semaphore is to be created.</param>
        /// <param name="pAllocator">Controls host memory allocation as described in the Memory Allocation chapter.</param>
        /// <param name="pSemaphore">A handle in which the resulting semaphore object is returned.</param>
        /// <returns>
        /// Success
        /// VK_SUCCESS
        /// 
        /// Failure
        /// VK_ERROR_OUT_OF_HOST_MEMORY
        /// 
        /// VK_ERROR_OUT_OF_DEVICE_MEMORY
        /// </returns>
        [DllImport("vulkan-1.dll", EntryPoint = "vkCreateSemaphore", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern VkResult CreateSemaphore(
            VkDevice device,
            VkSemaphoreCreateInfo pCreateInfo,
            VkAllocationCallbacks pAllocator,
            out VkSemaphore pSemaphore);

        [DllImport("vulkan-1.dll", EntryPoint = "vkCreateShaderModule", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern VkResult CreateShaderModule(
            VkDevice device,
            VkShaderModuleCreateInfo pCreateInfo,
            VkAllocationCallbacks pAllocator,
            out VkShaderModule pShaderModule);

        [DllImport("vulkan-1.dll", EntryPoint = "vkDestroyBuffer", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void DestroyBuffer(
            VkDevice device,
            VkBuffer buffer,
            VkAllocationCallbacks pAllocator);

        [DllImport("vulkan-1.dll", EntryPoint = "vkDestroyDescriptorSetLayout", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void DestroyDescriptorSetLayout(
            VkDevice device,
            VkDescriptorSetLayout descriptorSetLayout,
            VkAllocationCallbacks pAllocator);


        [DllImport("vulkan-1.dll", EntryPoint = "vkDestroyDevice", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void DestroyDevice(
            VkDevice device,
            VkAllocationCallbacks pAllocator);

        [DllImport("vulkan-1.dll", EntryPoint = "vkDestroyDevice", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void DestroyDevice(
            VkDevice device,
            IntPtr pAllocator);

        public static void DestroyDevice(
            VkDevice device)
        {
            DestroyDevice(device, IntPtr.Zero);
        }

        [DllImport("vulkan-1.dll", EntryPoint = "vkDestroyFence", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void DestroyFence(
            VkDevice device,
            VkFence fence,
            VkAllocationCallbacks pAllocator);

        [DllImport("vulkan-1.dll", EntryPoint = "vkDestroyPipeline", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void DestroyPipeline(
            VkDevice device,
            VkPipeline pipeline,
            VkAllocationCallbacks pAllocator);

        [DllImport("vulkan-1.dll", EntryPoint = "vkDestroyPipelineLayout", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void DestroyPipelineLayout(
            VkDevice device,
            VkPipelineLayout pipelineLayout,
            VkAllocationCallbacks pAllocator);

        [DllImport("vulkan-1.dll", EntryPoint = "vkDestroySemaphore", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void DestroySemaphore(
            VkDevice device,
            VkSemaphore semaphore,
            VkAllocationCallbacks pAllocator);

        [DllImport("vulkan-1.dll", EntryPoint = "vkDestroyShaderModule", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void DestroyShaderModule(
            VkDevice device,
            VkShaderModule shaderModule,
            VkAllocationCallbacks pAllocator);


        /// <summary>
        /// Once recording starts, an application records a sequence of commands (vkCmd*) to set state in the command buffer, draw, dispatch, and other commands.
        /// 
        /// Several commands can also be recorded indirectly from VkBuffer content, see Device-Generated Commands.
        /// 
        /// To complete recording of a command buffer, call:
        /// </summary>
        /// <param name="commandBuffer">the command buffer to complete recording.</param>
        [DllImport("vulkan-1.dll", EntryPoint = "vkEndCommandBuffer", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern VkResult EndCommandBuffer(VkCommandBuffer commandBuffer);


        [DllImport("vulkan-1.dll", EntryPoint = "vkEnumerateInstanceLayerProperties", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern VkResult EnumerateInstanceLayerProperties(
            ref uint pPropertyCount,
            [MarshalAs(UnmanagedType.LPArray)][In, Out] VkLayerProperties[] pProperties);

        [DllImport("vulkan-1.dll", EntryPoint = "vkEnumerateInstanceLayerProperties", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern VkResult EnumerateInstanceLayerProperties(
            ref uint pPropertyCount,
            IntPtr pProperties);

        public static VkResult EnumerateInstanceLayerProperties(out VkLayerProperties[] pProperties)
        {
            uint pPropertyCount = 0;
            pProperties = new VkLayerProperties[0];
            VkResult result = EnumerateInstanceLayerProperties(ref pPropertyCount, IntPtr.Zero);

            if (pPropertyCount == 0)
            {
                return result;
            }

            pProperties = new VkLayerProperties[pPropertyCount];
            //result = EnumerateInstanceLayerProperties(ref pPropertyCount, pProperties);

            GCHandle GlobalDataPointer = GCHandle.Alloc(pProperties, GCHandleType.Pinned); // Marshal.AllocHGlobal(sz);

            result = EnumerateInstanceLayerProperties(ref pPropertyCount, GlobalDataPointer.AddrOfPinnedObject());

            GlobalDataPointer.Free();

            return result;
        }


        [DllImport("vulkan-1.dll", EntryPoint = "vkEnumerateDeviceExtensionProperties", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern VkResult EnumerateDeviceExtensionProperties(
            VkPhysicalDevice physicalDevice,
            string pLayerName,
            ref uint pPropertyCount,
            IntPtr pProperties);

        public static VkResult EnumerateDeviceExtensionProperties(VkPhysicalDevice physicalDevice,
            string pLayerName, out VkExtensionProperties[] pProperties)
        {
            uint pPropertyCount = 0;
            pProperties = new VkExtensionProperties[0];
            VkResult result = EnumerateDeviceExtensionProperties(physicalDevice, pLayerName, ref pPropertyCount, IntPtr.Zero);

            if (pPropertyCount == 0)
            {
                return result;
            }

            pProperties = new VkExtensionProperties[pPropertyCount];
            //result = EnumerateInstanceLayerProperties(ref pPropertyCount, pProperties);

            GCHandle GlobalDataPointer = GCHandle.Alloc(pProperties, GCHandleType.Pinned); // Marshal.AllocHGlobal(sz);

            result = EnumerateDeviceExtensionProperties(physicalDevice, pLayerName, ref pPropertyCount, GlobalDataPointer.AddrOfPinnedObject());

            GlobalDataPointer.Free();

            return result;
        }


        [DllImport("vulkan-1.dll", EntryPoint = "vkEnumerateDeviceLayerProperties", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern VkResult EnumerateDeviceLayerProperties(
            VkPhysicalDevice physicalDevice,
            ref uint pPropertyCount,
            VkLayerProperties[] pProperties);

        //[DllImport("vulkan-1.dll", EntryPoint = "vkEnumeratePhysicalDevices", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        //public static extern VkResult EnumeratePhysicalDevices(
        //    VkInstance instance,
        //    [In, Out] ref uint pPhysicalDeviceCount,
        //    [MarshalAs(UnmanagedType.LPArray)] [In, Out] ref VkPhysicalDevice[] pPhysicalDevices);

        [DllImport("vulkan-1.dll", EntryPoint = "vkEnumeratePhysicalDevices", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern VkResult EnumeratePhysicalDevices(
            VkInstance instance,
            [In, Out] ref uint pPhysicalDeviceCount,
            IntPtr pPhysicalDevices);

        public static VkResult EnumeratePhysicalDevices(
            VkInstance instance,
            out VkPhysicalDevice[] pPhysicalDevices)
        {
            uint deviceCount = 0;
            VkResult resultCode = EnumeratePhysicalDevices(instance, ref deviceCount, IntPtr.Zero);

            if (resultCode != VkResult.VK_SUCCESS)
            {
                pPhysicalDevices = new VkPhysicalDevice[0];
                return resultCode;
            }

            pPhysicalDevices = new VkPhysicalDevice[deviceCount];
            //uint sz = (uint)(Marshal.SizeOf(typeof(VkPhysicalDevice)) * pPhysicalDevices.Length); // Marshal.SizeOf(typeof(int[])) * data.Length;
            GCHandle GlobalDataPointer = GCHandle.Alloc(pPhysicalDevices, GCHandleType.Pinned); // Marshal.AllocHGlobal(sz);

            resultCode = EnumeratePhysicalDevices(instance, ref deviceCount, GlobalDataPointer.AddrOfPinnedObject());

            GlobalDataPointer.Free();

            return resultCode;

        }

        [DllImport("vulkan-1.dll", EntryPoint = "vkFreeCommandBuffers", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void FreeCommandBuffers(
            VkDevice device,
            VkCommandPool commandPool,
            uint commandBufferCount,
            VkCommandBuffer[] pCommandBuffers);

        [DllImport("vulkan-1.dll", EntryPoint = "vkFreeMemory", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void FreeMemory(
            VkDevice device,
            VkDeviceMemory memory,
            VkAllocationCallbacks pAllocator);

        [DllImport("vulkan-1.dll", EntryPoint = "vkGetBufferMemoryRequirements", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void GetBufferMemoryRequirements(
            VkDevice device,
            VkBuffer buffer,
            out VkMemoryRequirements pMemoryRequirements);


        [DllImport("vulkan-1.dll", EntryPoint = "vkGetDeviceQueue", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void GetDeviceQueue(
            VkDevice device,
            uint queueFamilyIndex,
            uint queueIndex,
            [In, Out] ref VkQueue pQueue);


        [DllImport("vulkan-1.dll", EntryPoint = "vkGetPhysicalDeviceFeatures", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void GetPhysicalDeviceFeatures(
            VkPhysicalDevice physicalDevice,
            ref VkPhysicalDeviceFeatures pFeatures);

        public static VkPhysicalDeviceFeatures GetPhysicalDeviceFeatures(
            VkPhysicalDevice physicalDevice)
{
            VkPhysicalDeviceFeatures pFeatures = new VkPhysicalDeviceFeatures();
            GetPhysicalDeviceFeatures(physicalDevice, ref pFeatures);
            return pFeatures;
        }
        //[DllImport("vulkan-1.dll", EntryPoint = "vkGetPhysicalDeviceQueueFamilyProperties", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        //public static extern void GetPhysicalDeviceQueueFamilyProperties(
        //    VkPhysicalDevice physicalDevice,
        //    ref uint pQueueFamilyPropertyCount,
        //    [MarshalAs(UnmanagedType.LPArray)] ref VkQueueFamilyProperties[] pQueueFamilyProperties);

        [DllImport("vulkan-1.dll", EntryPoint = "vkGetPhysicalDeviceQueueFamilyProperties", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void GetPhysicalDeviceQueueFamilyProperties(
            VkPhysicalDevice physicalDevice,
            ref uint pQueueFamilyPropertyCount,
            IntPtr pQueueFamilyProperties);


        public static VkQueueFamilyProperties[] GetPhysicalDeviceQueueFamilyProperties(
            VkPhysicalDevice physicalDevice)
        {
            uint deviceCount = 0;
            GetPhysicalDeviceQueueFamilyProperties(physicalDevice, ref deviceCount, IntPtr.Zero);
            VkQueueFamilyProperties[] pPhysicalDevices;
            if (deviceCount == 0)
            {
                pPhysicalDevices = new VkQueueFamilyProperties[0];
                return pPhysicalDevices;
            }
            pPhysicalDevices = new VkQueueFamilyProperties[deviceCount];
            GCHandle GlobalDataPointer = GCHandle.Alloc(pPhysicalDevices, GCHandleType.Pinned); // Marshal.AllocHGlobal(sz);

            GetPhysicalDeviceQueueFamilyProperties(physicalDevice, ref deviceCount, GlobalDataPointer.AddrOfPinnedObject());

            GlobalDataPointer.Free();

            return pPhysicalDevices;
        }

        [DllImport("vulkan-1.dll", EntryPoint = "vkGetImageMemoryRequirements", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void GetImageMemoryRequirements(
            VkDevice device,
            VkImage image,
            out VkMemoryRequirements pMemoryRequirements);

        /// <summary>
        /// Memory objects created with vkAllocateMemory are not directly host accessible.
///
       /// Memory objects created with the memory property VK_MEMORY_PROPERTY_HOST_VISIBLE_BIT are considered mappable. 
       /// Memory objects must be mappable in order to be successfully mapped on the host.
///
        /// Used to retrieve a host virtual address pointer to a region of a mappable memory object.
                /// </summary>
                /// <param name="device">The logical device that owns the memory.</param>
                /// <param name="memory">The VkDeviceMemory object to be mapped.</param>
                /// <param name="offset">zero-based byte offset from the beginning of the memory object.</param>
                /// <param name="size">size of the memory range to map, or VK_WHOLE_SIZE to map from offset to the end of the allocation.</param>
                /// <param name="flags">Reserved for future use.</param>
                /// <param name="ppData">
                /// A host-accessible pointer to the beginning of the mapped range is returned. 
                /// This pointer minus offset must be aligned to at least 
                /// VkPhysicalDeviceLimits.minMemoryMapAlignment.</param>
                /// <returns></returns>
                [DllImport("vulkan-1.dll", EntryPoint = "vkMapMemory", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern VkResult MapMemory(
            VkDevice device,
            VkDeviceMemory memory,
            ulong offset,
            ulong size,
            VkMemoryMapFlags flags,
            out IntPtr ppData);

        /// <summary>
        /// Shortcut function to MapMemory from the GPU. 
        /// Then copy data to the mapped location and finally UnmapMemory.
        /// 
        /// if size is larger than the size of the data parameter only the data will be copied.
        /// If the size of the data is larger than the size parameter only up to the size parameter will be copied. 
        /// This may result in undefined values at the last value element copied if it doesn't align to the data size.
        /// 
        /// </summary>
        /// <typeparam name="T">struct data to copy</typeparam>
        /// <param name="device">The logical device that owns the memory.</param>
        /// <param name="memory">The VkDeviceMemory object to be mapped.</param>
        /// <param name="offset">zero-based byte offset from the beginning of the memory object.</param>
        /// <param name="size">size of the memory range to map, or VK_WHOLE_SIZE to map from offset to the end of the allocation.</param>
        /// <param name="flags">Reserved for future use.</param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static VkResult WriteMemory<T>(VkDevice device,
            VkDeviceMemory memory,
            ulong offset,
            ulong size,
            VkMemoryMapFlags flags,
            T[] data ) where T : struct
        {
            VkResult errcode_ret;

            IntPtr gpuData;
            errcode_ret = MapMemory(device, memory, offset, size, flags, out gpuData);

            if (errcode_ret != VkResult.VK_SUCCESS)
                return errcode_ret;

            uint sz = (uint)(Marshal.SizeOf(typeof(T)) * data.Length); // Marshal.SizeOf(typeof(int[])) * data.Length;
            GCHandle GlobalDataPointer = GCHandle.Alloc(data, GCHandleType.Pinned); // Marshal.AllocHGlobal(sz);

            WindowsApi.CopyMemory(GlobalDataPointer.AddrOfPinnedObject(), gpuData, new UIntPtr(size > sz ? size : sz));
            
            UnmapMemory(device, memory);

            //CLResult err = CL.EnqueueReadBuffer(Commands, buf, true, 0, buf.Size, buf.GlobalDataPointer.AddrOfPinnedObject(), Waitlist.Count, Waitlist.ToArray(), out _); //(int)Waitlist[session].Length, Waitlist[session]

            //return Marshal.PtrToStructure<T>(buf.GlobalDataPointer.AddrOfPinnedObject());

            return VkResult.VK_SUCCESS;
        }

        /// <summary>
        /// vkQueueSubmit is a queue submission command, with each batch defined by an element of pSubmits. Batches begin execution in the order they appear in pSubmits, but may complete out of order.
        /// 
        /// Fence and semaphore operations submitted with vkQueueSubmit have additional ordering constraints compared to other submission commands, with dependencies involving previous and subsequent queue operations.Information about these additional constraints can be found in the semaphore and fence sections of the synchronization chapter.
        /// Details on the interaction of pWaitDstStageMask with synchronization are described in the semaphore wait operation section of the synchronization chapter.
        /// 
        /// The order that batches appear in pSubmits is used to determine submission order, and thus all the implicit ordering guarantees that respect it.Other than these implicit ordering guarantees and any explicit synchronization primitives, these batches may overlap or otherwise execute out of order.
        /// 
        /// If any command buffer submitted to this queue is in the executable state, it is moved to the pending state.Once execution of all submissions of a command buffer complete, it moves from the pending state, back to the executable state.If a command buffer was recorded with the VK_COMMAND_BUFFER_USAGE_ONE_TIME_SUBMIT_BIT flag, it instead moves to the invalid state.
        /// 
        /// If vkQueueSubmit fails, it may return VK_ERROR_OUT_OF_HOST_MEMORY or VK_ERROR_OUT_OF_DEVICE_MEMORY.If it does, the implementation must ensure that the state and contents of any resources or synchronization primitives referenced by the submitted command buffers and any semaphores referenced by pSubmits is unaffected by the call or its failure.If vkQueueSubmit fails in such a way that the implementation is unable to make that guarantee, the implementation must return VK_ERROR_DEVICE_LOST.See Lost Device.
        /// </summary>
        /// <param name="queue">The queue that the command buffers will be submitted to.</param>
        /// <param name="submitCount">the number of elements in the pSubmits array.</param>
        /// <param name="pSubmits">an array of VkSubmitInfo structures, each specifying a command buffer submission batch.</param>
        /// <param name="fence">an optional handle to a fence to be signaled once all submitted command buffers have completed execution. 
        /// If fence is not VK_NULL_HANDLE, it defines a fence signal operation.</param>
        /// <returns></returns>
        [DllImport("vulkan-1.dll", EntryPoint = "vkQueueSubmit", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern VkResult QueueSubmit(
            VkQueue queue,
            uint submitCount,
            VkSubmitInfo[] pSubmits,
            VkFence fence);


        /// <summary>
        /// If any member of pFences currently has its payload imported with temporary permanence, that fence’s prior permanent payload is first restored. The remaining operations described therefore operate on the restored payload.
        /// 
        /// When vkResetFences is executed on the host, it defines a fence unsignal operation for each fence, which resets the fence to the unsignaled state.
        /// 
        /// If any member of pFences is already in the unsignaled state when vkResetFences is executed, then vkResetFences has no effect on that fence.
        /// </summary>
        /// <param name="device">the logical device that owns the fences.</param>
        /// <param name="fenceCount">the number of fences to reset.</param>
        /// <param name="pFences">An array of fence handles to reset.</param>
        /// <returns></returns>
        [DllImport("vulkan-1.dll", EntryPoint = "vkResetFences", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern VkResult ResetFences(
            VkDevice device,
            uint fenceCount,
            VkFence[] pFences);

        [DllImport("vulkan-1.dll", EntryPoint = "vkUnmapMemory", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void UnmapMemory(
            VkDevice device,
            VkDeviceMemory memory);


        [DllImport("vulkan-1.dll", EntryPoint = "vkUpdateDescriptorSets", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void UpdateDescriptorSets(
            VkDevice device,
            uint descriptorWriteCount,
            VkWriteDescriptorSet[] pDescriptorWrites,
            uint descriptorCopyCount,
            VkCopyDescriptorSet[] pDescriptorCopies);


        /// <summary>
        /// Wait for the fence to signal that command buffer has finished executing.
        /// 
        /// If the condition is satisfied when vkWaitForFences is called, then vkWaitForFences returns immediately. If the condition is not satisfied at the time vkWaitForFences is called, then vkWaitForFences will block and wait until the condition is satisfied or the timeout has expired, whichever is sooner.
        /// 
        /// If timeout is zero, then vkWaitForFences does not wait, but simply returns the current state of the fences.VK_TIMEOUT will be returned in this case if the condition is not satisfied, even though no actual wait was performed.
        /// 
        /// If the condition is satisfied before the timeout has expired, vkWaitForFences returns VK_SUCCESS.Otherwise, vkWaitForFences returns VK_TIMEOUT after the timeout has expired.
        /// 
        /// 
        /// If device loss occurs (see Lost Device) before the timeout has expired, vkWaitForFences must return in finite time with either VK_SUCCESS or VK_ERROR_DEVICE_LOST.
        /// </summary>
        /// <param name="device">the logical device that owns the fences.</param>
        /// <param name="fenceCount">the number of fences to wait on.</param>
        /// <param name="pFences">an array of fenceCount fence handles.</param>
        /// <param name="waitAll">is the condition that must be satisfied to successfully unblock the wait. If waitAll is VK_TRUE, then the condition is that all fences in pFences are signaled. 
        /// Otherwise, the condition is that at least one fence in pFences is signaled.</param>
        /// <param name="timeout">The timeout period in units of nanoseconds. 
        /// timeout is adjusted to the closest value allowed by the implementation-dependent 
        /// timeout accuracy, which may be substantially longer than one nanosecond, 
        /// and may be longer than the requested period.</param>
        /// <returns></returns>
        [DllImport("vulkan-1.dll", EntryPoint = "vkWaitForFences", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern VkResult WaitForFences(
            VkDevice device,
            uint fenceCount,
            VkFence[] pFences,
            bool waitAll,
            ulong timeout);
    }
}