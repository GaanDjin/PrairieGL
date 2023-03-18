using Microsoft.VisualBasic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

///typedef uint32_t public Bool32;
///
namespace PrairieGL.Vulkan
{


    #region Vulkan Handles

    public struct VkInstance
    {

        public IntPtr Handle;

        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator VkInstance(IntPtr from)
        {
            VkInstance to = new VkInstance();
            to.Handle = from;
            return to;
        }
        public static bool operator ==(VkInstance obj1, IntPtr obj2)
        {
            return obj1.Handle == obj2;
        }

        public static bool operator !=(VkInstance obj1, IntPtr obj2)
        {
            return obj1.Handle != obj2;
        }
    }

    public struct VkPhysicalDevice
    {

        public IntPtr Handle;

        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator VkPhysicalDevice(IntPtr from)
        {
            VkPhysicalDevice to = new VkPhysicalDevice();
            to.Handle = from;
            return to;
        }

        public static bool operator ==(VkPhysicalDevice obj1, IntPtr obj2)
        {
            return obj1.Handle == obj2;
        }

        public static bool operator !=(VkPhysicalDevice obj1, IntPtr obj2)
        {
            return obj1.Handle != obj2;
        }
    }
    public struct VkDevice
    {
        public IntPtr Handle;

        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator VkDevice(IntPtr from)
        {
            VkDevice to = new VkDevice();
            to.Handle = from;
            return to;
        }
        public static bool operator ==(VkDevice obj1, IntPtr obj2)
        {
            return obj1.Handle == obj2;
        }

        public static bool operator !=(VkDevice obj1, IntPtr obj2)
        {
            return obj1.Handle != obj2;
        }
    }
    public struct VkQueue
    {
        public IntPtr Handle;

        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator VkQueue(IntPtr from)
        {
            VkQueue to = new VkQueue();
            to.Handle = from;
            return to;
        }
        public static bool operator ==(VkQueue obj1, IntPtr obj2)
        {
            return obj1.Handle == obj2;
        }

        public static bool operator !=(VkQueue obj1, IntPtr obj2)
        {
            return obj1.Handle != obj2;
        }
    }
    public struct VkCommandPool
    {
        public IntPtr Handle;

        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator VkCommandPool(IntPtr from)
        {
            VkCommandPool to = new VkCommandPool();
            to.Handle = from;
            return to;
        }
        public static bool operator ==(VkCommandPool obj1, IntPtr obj2)
        {
            return obj1.Handle == obj2;
        }

        public static bool operator !=(VkCommandPool obj1, IntPtr obj2)
        {
            return obj1.Handle != obj2;
        }
    }
    public struct VkCommandBuffer
    {
        public IntPtr Handle;

        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator VkCommandBuffer(IntPtr from)
        {
            VkCommandBuffer to = new VkCommandBuffer();
            to.Handle = from;
            return to;
        }
        public static bool operator ==(VkCommandBuffer obj1, IntPtr obj2)
        {
            return obj1.Handle == obj2;
        }

        public static bool operator !=(VkCommandBuffer obj1, IntPtr obj2)
        {
            return obj1.Handle != obj2;
        }
    }
    public struct VkRenderPass
    {
        public IntPtr Handle;

        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator VkRenderPass(IntPtr from)
        {
            VkRenderPass to = new VkRenderPass();
            to.Handle = from;
            return to;
        }
        public static bool operator ==(VkRenderPass obj1, IntPtr obj2)
        {
            return obj1.Handle == obj2;
        }

        public static bool operator !=(VkRenderPass obj1, IntPtr obj2)
        {
            return obj1.Handle != obj2;
        }
    }
    public struct VkFramebuffer
    {
        public IntPtr Handle;

        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator VkFramebuffer(IntPtr from)
        {
            VkFramebuffer to = new VkFramebuffer();
            to.Handle = from;
            return to;
        }
        public static bool operator ==(VkFramebuffer obj1, IntPtr obj2)
        {
            return obj1.Handle == obj2;
        }

        public static bool operator !=(VkFramebuffer obj1, IntPtr obj2)
        {
            return obj1.Handle != obj2;
        }
    }
    public struct VkDescriptorPool
    {
        public IntPtr Handle;

        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator VkDescriptorPool(IntPtr from)
        {
            VkDescriptorPool to = new VkDescriptorPool();
            to.Handle = from;
            return to;
        }
        public static bool operator ==(VkDescriptorPool obj1, IntPtr obj2)
        {
            return obj1.Handle == obj2;
        }

        public static bool operator !=(VkDescriptorPool obj1, IntPtr obj2)
        {
            return obj1.Handle != obj2;
        }
    }
    public struct VkShaderModule
    {
        public IntPtr Handle;

        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator VkShaderModule(IntPtr from)
        {
            VkShaderModule to = new VkShaderModule();
            to.Handle = from;
            return to;
        }
        public static bool operator ==(VkShaderModule obj1, IntPtr obj2)
        {
            return obj1.Handle == obj2;
        }

        public static bool operator !=(VkShaderModule obj1, IntPtr obj2)
        {
            return obj1.Handle != obj2;
        }
    }
    public struct VkPipelineCache
    {
        public IntPtr Handle;

        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator VkPipelineCache(IntPtr from)
        {
            VkPipelineCache to = new VkPipelineCache();
            to.Handle = from;
            return to;
        }
        public static bool operator ==(VkPipelineCache obj1, IntPtr obj2)
        {
            return obj1.Handle == obj2;
        }

        public static bool operator !=(VkPipelineCache obj1, IntPtr obj2)
        {
            return obj1.Handle != obj2;
        }
    }
    public struct VulkanSwapChain
    {
        public IntPtr Handle;

        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator VulkanSwapChain(IntPtr from)
        {
            VulkanSwapChain to = new VulkanSwapChain();
            to.Handle = from;
            return to;
        }
        public static bool operator ==(VulkanSwapChain obj1, IntPtr obj2)
        {
            return obj1.Handle == obj2;
        }

        public static bool operator !=(VulkanSwapChain obj1, IntPtr obj2)
        {
            return obj1.Handle != obj2;
        }
    }
    public struct VkSemaphore
    {
        public IntPtr Handle;

        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator VkSemaphore(IntPtr from)
        {
            VkSemaphore to = new VkSemaphore();
            to.Handle = from;
            return to;
        }
        public static bool operator ==(VkSemaphore obj1, IntPtr obj2)
        {
            return obj1.Handle == obj2;
        }

        public static bool operator !=(VkSemaphore obj1, IntPtr obj2)
        {
            return obj1.Handle != obj2;
        }
    }

    public struct VkDeviceMemory
    {
        public IntPtr Handle;

        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator VkDeviceMemory(IntPtr from)
        {
            VkDeviceMemory to = new VkDeviceMemory();
            to.Handle = from;
            return to;
        }
        public static bool operator ==(VkDeviceMemory obj1, IntPtr obj2)
        {
            return obj1.Handle == obj2;
        }

        public static bool operator !=(VkDeviceMemory obj1, IntPtr obj2)
        {
            return obj1.Handle != obj2;
        }
    }
    public struct VkBuffer
    {
        public IntPtr Handle;

        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator VkBuffer(IntPtr from)
        {
            VkBuffer to = new VkBuffer();
            to.Handle = from;
            return to;
        }
        public static bool operator ==(VkBuffer obj1, IntPtr obj2)
        {
            return obj1.Handle == obj2;
        }

        public static bool operator !=(VkBuffer obj1, IntPtr obj2)
        {
            return obj1.Handle != obj2;
        }
    }
    public struct VkPipelineLayout
    {
        public IntPtr Handle;

        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator VkPipelineLayout(IntPtr from)
        {
            VkPipelineLayout to = new VkPipelineLayout();
            to.Handle = from;
            return to;
        }
        public static bool operator ==(VkPipelineLayout obj1, IntPtr obj2)
        {
            return obj1.Handle == obj2;
        }

        public static bool operator !=(VkPipelineLayout obj1, IntPtr obj2)
        {
            return obj1.Handle != obj2;
        }
    }
    public struct VkPipeline
    {
        public IntPtr Handle;

        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator VkPipeline(IntPtr from)
        {
            VkPipeline to = new VkPipeline();
            to.Handle = from;
            return to;
        }
        public static bool operator ==(VkPipeline obj1, IntPtr obj2)
        {
            return obj1.Handle == obj2;
        }

        public static bool operator !=(VkPipeline obj1, IntPtr obj2)
        {
            return obj1.Handle != obj2;
        }
    }
    public struct VkDescriptorSetLayout
    {
        public IntPtr Handle;

        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator VkDescriptorSetLayout(IntPtr from)
        {
            VkDescriptorSetLayout to = new VkDescriptorSetLayout();
            to.Handle = from;
            return to;
        }
        public static bool operator ==(VkDescriptorSetLayout obj1, IntPtr obj2)
        {
            return obj1.Handle == obj2;
        }

        public static bool operator !=(VkDescriptorSetLayout obj1, IntPtr obj2)
        {
            return obj1.Handle != obj2;
        }
    }
    public struct VkDescriptorSet
    {
        public IntPtr Handle;

        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator VkDescriptorSet(IntPtr from)
        {
            VkDescriptorSet to = new VkDescriptorSet();
            to.Handle = from;
            return to;
        }
        public static bool operator ==(VkDescriptorSet obj1, IntPtr obj2)
        {
            return obj1.Handle == obj2;
        }

        public static bool operator !=(VkDescriptorSet obj1, IntPtr obj2)
        {
            return obj1.Handle != obj2;
        }
    }
    public struct VkFence
    {
        public IntPtr Handle;

        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator VkFence(IntPtr from)
        {
            VkFence to = new VkFence();
            to.Handle = from;
            return to;
        }
        public static bool operator ==(VkFence obj1, IntPtr obj2)
        {
            return obj1.Handle == obj2;
        }

        public static bool operator !=(VkFence obj1, IntPtr obj2)
        {
            return obj1.Handle != obj2;
        }
    }
    public struct VkImage
    {
        public IntPtr Handle;

        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator VkImage(IntPtr from)
        {
            VkImage to = new VkImage();
            to.Handle = from;
            return to;
        }
        public static bool operator ==(VkImage obj1, IntPtr obj2)
        {
            return obj1.Handle == obj2;
        }

        public static bool operator !=(VkImage obj1, IntPtr obj2)
        {
            return obj1.Handle != obj2;
        }
    }
    public struct VkImageView
    {
        public IntPtr Handle;

        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator VkImageView(IntPtr from)
        {
            VkImageView to = new VkImageView();
            to.Handle = from;
            return to;
        }
        public static bool operator ==(VkImageView obj1, IntPtr obj2)
        {
            return obj1.Handle == obj2;
        }

        public static bool operator !=(VkImageView obj1, IntPtr obj2)
        {
            return obj1.Handle != obj2;
        }
    }
    public struct VkEvent
    {
        public IntPtr Handle;

        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator VkEvent(IntPtr from)
        {
            VkEvent to = new VkEvent();
            to.Handle = from;
            return to;
        }
        public static bool operator ==(VkEvent obj1, IntPtr obj2)
        {
            return obj1.Handle == obj2;
        }

        public static bool operator !=(VkEvent obj1, IntPtr obj2)
        {
            return obj1.Handle != obj2;
        }
    }
    public struct VkQueryPool
    {
        public IntPtr Handle;

        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator VkQueryPool(IntPtr from)
        {
            VkQueryPool to = new VkQueryPool();
            to.Handle = from;
            return to;
        }
        public static bool operator ==(VkQueryPool obj1, IntPtr obj2)
        {
            return obj1.Handle == obj2;
        }

        public static bool operator !=(VkQueryPool obj1, IntPtr obj2)
        {
            return obj1.Handle != obj2;
        }
    }
    public struct VkBufferView
    {
        public IntPtr Handle;

        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator VkBufferView(IntPtr from)
        {
            VkBufferView to = new VkBufferView();
            to.Handle = from;
            return to;
        }
        public static bool operator ==(VkBufferView obj1, IntPtr obj2)
        {
            return obj1.Handle == obj2;
        }

        public static bool operator !=(VkBufferView obj1, IntPtr obj2)
        {
            return obj1.Handle != obj2;
        }
    }
    public struct VkSampler
    {
        public IntPtr Handle;

        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator VkSampler(IntPtr from)
        {
            VkSampler to = new VkSampler();
            to.Handle = from;
            return to;
        }
        public static bool operator ==(VkSampler obj1, IntPtr obj2)
        {
            return obj1.Handle == obj2;
        }

        public static bool operator !=(VkSampler obj1, IntPtr obj2)
        {
            return obj1.Handle != obj2;
        }
    }
    public struct VkSamplerYcbcrConversion
    {
        public IntPtr Handle;

        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator VkSamplerYcbcrConversion(IntPtr from)
        {
            VkSamplerYcbcrConversion to = new VkSamplerYcbcrConversion();
            to.Handle = from;
            return to;
        }
        public static bool operator ==(VkSamplerYcbcrConversion obj1, IntPtr obj2)
        {
            return obj1.Handle == obj2;
        }

        public static bool operator !=(VkSamplerYcbcrConversion obj1, IntPtr obj2)
        {
            return obj1.Handle != obj2;
        }
    }
    public struct VkDescriptorUpdateTemplate
    {
        public IntPtr Handle;

        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator VkDescriptorUpdateTemplate(IntPtr from)
        {
            VkDescriptorUpdateTemplate to = new VkDescriptorUpdateTemplate();
            to.Handle = from;
            return to;
        }
        public static bool operator ==(VkDescriptorUpdateTemplate obj1, IntPtr obj2)
        {
            return obj1.Handle == obj2;
        }

        public static bool operator !=(VkDescriptorUpdateTemplate obj1, IntPtr obj2)
        {
            return obj1.Handle != obj2;
        }
    }
    public struct VkPrivateDataSlot
    {
        public IntPtr Handle;

        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator VkPrivateDataSlot(IntPtr from)
        {
            VkPrivateDataSlot to = new VkPrivateDataSlot();
            to.Handle = from;
            return to;
        }
        public static bool operator ==(VkPrivateDataSlot obj1, IntPtr obj2)
        {
            return obj1.Handle == obj2;
        }

        public static bool operator !=(VkPrivateDataSlot obj1, IntPtr obj2)
        {
            return obj1.Handle != obj2;
        }
    }
    public struct VkSurfaceKHR
    {
        public IntPtr Handle;

        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator VkSurfaceKHR(IntPtr from)
        {
            VkSurfaceKHR to = new VkSurfaceKHR();
            to.Handle = from;
            return to;
        }
        public static bool operator ==(VkSurfaceKHR obj1, IntPtr obj2)
        {
            return obj1.Handle == obj2;
        }

        public static bool operator !=(VkSurfaceKHR obj1, IntPtr obj2)
        {
            return obj1.Handle != obj2;
        }
    }
    public struct VkSwapchainKHR
    {
        public IntPtr Handle;

        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator VkSwapchainKHR(IntPtr from)
        {
            VkSwapchainKHR to = new VkSwapchainKHR();
            to.Handle = from;
            return to;
        }
        public static bool operator ==(VkSwapchainKHR obj1, IntPtr obj2)
        {
            return obj1.Handle == obj2;
        }

        public static bool operator !=(VkSwapchainKHR obj1, IntPtr obj2)
        {
            return obj1.Handle != obj2;
        }
    }
    public struct VkDisplayKHR
    {
        public IntPtr Handle;

        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator VkDisplayKHR(IntPtr from)
        {
            VkDisplayKHR to = new VkDisplayKHR();
            to.Handle = from;
            return to;
        }
        public static bool operator ==(VkDisplayKHR obj1, IntPtr obj2)
        {
            return obj1.Handle == obj2;
        }

        public static bool operator !=(VkDisplayKHR obj1, IntPtr obj2)
        {
            return obj1.Handle != obj2;
        }
    }
    public struct VkDisplayModeKHR
    {
        public IntPtr Handle;

        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator VkDisplayModeKHR(IntPtr from)
        {
            VkDisplayModeKHR to = new VkDisplayModeKHR();
            to.Handle = from;
            return to;
        }
        public static bool operator ==(VkDisplayModeKHR obj1, IntPtr obj2)
        {
            return obj1.Handle == obj2;
        }

        public static bool operator !=(VkDisplayModeKHR obj1, IntPtr obj2)
        {
            return obj1.Handle != obj2;
        }
    }
    public struct VkDeferredOperationKHR
    {
        public IntPtr Handle;

        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator VkDeferredOperationKHR(IntPtr from)
        {
            VkDeferredOperationKHR to = new VkDeferredOperationKHR();
            to.Handle = from;
            return to;
        }
        public static bool operator ==(VkDeferredOperationKHR obj1, IntPtr obj2)
        {
            return obj1.Handle == obj2;
        }

        public static bool operator !=(VkDeferredOperationKHR obj1, IntPtr obj2)
        {
            return obj1.Handle != obj2;
        }
    }
    public struct VkDebugReportCallbackEXT
    {
        public IntPtr Handle;

        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator VkDebugReportCallbackEXT(IntPtr from)
        {
            VkDebugReportCallbackEXT to = new VkDebugReportCallbackEXT();
            to.Handle = from;
            return to;
        }
        public static bool operator ==(VkDebugReportCallbackEXT obj1, IntPtr obj2)
        {
            return obj1.Handle == obj2;
        }

        public static bool operator !=(VkDebugReportCallbackEXT obj1, IntPtr obj2)
        {
            return obj1.Handle != obj2;
        }
    }
    public struct VkCuModuleNVX
    {
        public IntPtr Handle;

        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator VkCuModuleNVX(IntPtr from)
        {
            VkCuModuleNVX to = new VkCuModuleNVX();
            to.Handle = from;
            return to;
        }
        public static bool operator ==(VkCuModuleNVX obj1, IntPtr obj2)
        {
            return obj1.Handle == obj2;
        }

        public static bool operator !=(VkCuModuleNVX obj1, IntPtr obj2)
        {
            return obj1.Handle != obj2;
        }
    }
    public struct VkCuFunctionNVX
    {
        public IntPtr Handle;

        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator VkCuFunctionNVX(IntPtr from)
        {
            VkCuFunctionNVX to = new VkCuFunctionNVX();
            to.Handle = from;
            return to;
        }
        public static bool operator ==(VkCuFunctionNVX obj1, IntPtr obj2)
        {
            return obj1.Handle == obj2;
        }

        public static bool operator !=(VkCuFunctionNVX obj1, IntPtr obj2)
        {
            return obj1.Handle != obj2;
        }
    }
    public struct VkDebugUtilsMessengerEXT
    {
        public IntPtr Handle;

        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator VkDebugUtilsMessengerEXT(IntPtr from)
        {
            VkDebugUtilsMessengerEXT to = new VkDebugUtilsMessengerEXT();
            to.Handle = from;
            return to;
        }
        public static bool operator ==(VkDebugUtilsMessengerEXT obj1, IntPtr obj2)
        {
            return obj1.Handle == obj2;
        }

        public static bool operator !=(VkDebugUtilsMessengerEXT obj1, IntPtr obj2)
        {
            return obj1.Handle != obj2;
        }
    }
    public struct VkValidationCacheEXT
    {
        public IntPtr Handle;

        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator VkValidationCacheEXT(IntPtr from)
        {
            VkValidationCacheEXT to = new VkValidationCacheEXT();
            to.Handle = from;
            return to;
        }
        public static bool operator ==(VkValidationCacheEXT obj1, IntPtr obj2)
        {
            return obj1.Handle == obj2;
        }

        public static bool operator !=(VkValidationCacheEXT obj1, IntPtr obj2)
        {
            return obj1.Handle != obj2;
        }
    }
    public struct VkAccelerationStructureNV
    {
        public IntPtr Handle;

        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator VkAccelerationStructureNV(IntPtr from)
        {
            VkAccelerationStructureNV to = new VkAccelerationStructureNV();
            to.Handle = from;
            return to;
        }
        public static bool operator ==(VkAccelerationStructureNV obj1, IntPtr obj2)
        {
            return obj1.Handle == obj2;
        }

        public static bool operator !=(VkAccelerationStructureNV obj1, IntPtr obj2)
        {
            return obj1.Handle != obj2;
        }
    }
    public struct VkPerformanceConfigurationINTEL
    {
        public IntPtr Handle;

        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator VkPerformanceConfigurationINTEL(IntPtr from)
        {
            VkPerformanceConfigurationINTEL to = new VkPerformanceConfigurationINTEL();
            to.Handle = from;
            return to;
        }
        public static bool operator ==(VkPerformanceConfigurationINTEL obj1, IntPtr obj2)
        {
            return obj1.Handle == obj2;
        }

        public static bool operator !=(VkPerformanceConfigurationINTEL obj1, IntPtr obj2)
        {
            return obj1.Handle != obj2;
        }
    }
    public struct VkIndirectCommandsLayoutNV
    {
        public IntPtr Handle;

        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator VkIndirectCommandsLayoutNV(IntPtr from)
        {
            VkIndirectCommandsLayoutNV to = new VkIndirectCommandsLayoutNV();
            to.Handle = from;
            return to;
        }
        public static bool operator ==(VkIndirectCommandsLayoutNV obj1, IntPtr obj2)
        {
            return obj1.Handle == obj2;
        }

        public static bool operator !=(VkIndirectCommandsLayoutNV obj1, IntPtr obj2)
        {
            return obj1.Handle != obj2;
        }
    }
    public struct VkAccelerationStructureKHR
    {
        public IntPtr Handle;

        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator VkAccelerationStructureKHR(IntPtr from)
        {
            VkAccelerationStructureKHR to = new VkAccelerationStructureKHR();
            to.Handle = from;
            return to;
        }
        public static bool operator ==(VkAccelerationStructureKHR obj1, IntPtr obj2)
        {
            return obj1.Handle == obj2;
        }

        public static bool operator !=(VkAccelerationStructureKHR obj1, IntPtr obj2)
        {
            return obj1.Handle != obj2;
        }
    }
    public struct VkMicromapEXT
    {
        public IntPtr Handle;

        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator VkMicromapEXT(IntPtr from)
        {
            VkMicromapEXT to = new VkMicromapEXT();
            to.Handle = from;
            return to;
        }
        public static bool operator ==(VkMicromapEXT obj1, IntPtr obj2)
        {
            return obj1.Handle == obj2;
        }

        public static bool operator !=(VkMicromapEXT obj1, IntPtr obj2)
        {
            return obj1.Handle != obj2;
        }
    }
    public struct VkOpticalFlowSessionNV
    {
        public IntPtr Handle;

        public override string ToString()
        {
            return Handle.ToString("X");
        }

        public static implicit operator VkOpticalFlowSessionNV(IntPtr from)
        {
            VkOpticalFlowSessionNV to = new VkOpticalFlowSessionNV();
            to.Handle = from;
            return to;
        }
        public static bool operator ==(VkOpticalFlowSessionNV obj1, IntPtr obj2)
        {
            return obj1.Handle == obj2;
        }

        public static bool operator !=(VkOpticalFlowSessionNV obj1, IntPtr obj2)
        {
            return obj1.Handle != obj2;
        }
    }

    public struct Bool32
    {
        public uint Value;

        public Bool32(bool value)
        {
            Value = (uint)(value ? 1 : 0);
        }

        public static implicit operator Bool32(bool value)
        {
            return new Bool32(value);
        }
        public static implicit operator bool(Bool32 value)
        {
            return value.Value > 0;
        }

        public override string ToString()
        {
            return (Value > 0).ToString();
        }

        public void Set(bool value)
        {
            Value = (uint)(value ? 1 : 0);
        }
    }

#endregion

    public interface IVkStruct { }

    public struct VkSemaphoreCreateInfo
    {
        /// <summary>
        /// the type of this structure.
        /// </summary>
        public VkStructureType sType; // = VkStructureType.VK_STRUCTURE_TYPE_EXPORT_SEMAPHORE_CREATE_INFO;
        /// <summary>
        /// NULL or a pointer to a structure extending this structure.
        /// </summary>
        public IntPtr pNext;
        /// <summary>
        /// reserved for future use.
        /// </summary>
        public VkSemaphoreCreateFlags flags;
    }

    public struct VkFenceCreateInfo
    {
        /// <summary>
        /// type of this structure.
        /// </summary>
        public VkStructureType sType;
        /// <summary>
        /// NULL or a pointer to a structure extending this structure.
        /// </summary>
        public IntPtr pNext;
        /// <summary>
        /// a bitmask of VkFenceCreateFlagBits specifying the initial state and behavior of the fence.
        /// </summary>
        public VkFenceCreateFlags flags;
    }


    public struct VkExportFenceCreateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkExternalFenceHandleTypeFlags handleTypes;
    }

    public struct VkCommandBufferAllocateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkCommandPool commandPool;
        public VkCommandBufferLevel level;
        public uint commandBufferCount;
    }
    public struct VkCommandBufferBeginInfo
    {
        /// <summary>
        ///  the type of this structure.
        /// </summary>
        public VkStructureType sType;
        /// <summary>
        /// NULL or a pointer to a structure extending this structure.
        /// </summary>
        public IntPtr pNext;
        /// <summary>
        /// a bitmask of VkCommandBufferUsageFlagBits specifying usage behavior for the command buffer.
        /// </summary>
        public VkCommandBufferUsageFlags flags;
        /// <summary>
        /// a VkCommandBufferInheritanceInfo structure, used if commandBuffer is a secondary command buffer. If this is a primary command buffer, then this value is ignored.
        /// </summary>
        public VkCommandBufferInheritanceInfo pInheritanceInfo;
    }

    public struct VkRect2D
    {
        public VkOffset2D offset;
        public VkExtent2D extent;
    }
    public struct VkOffset2D
    {
        public int x;
        public int y;
    }
    public struct VkExtent2D
    {
        public uint width;
        public uint height;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct VkClearValue {
        [FieldOffset(0)]
        public VkClearColorValue color;
        [FieldOffset(0)]
        public VkClearDepthStencilValue depthStencil;
    }

    public struct VkRenderPassBeginInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkRenderPass renderPass;
        public VkFramebuffer framebuffer;
        public VkRect2D renderArea;
        public uint clearValueCount;
        public VkClearValue[] pClearValues;
    }

    /// <summary>
    /// Describs the parameters of the render pass.
    /// </summary>
    public struct VkRenderPassCreateInfo
    {
        /// <summary>
        /// The type of this structure.
        /// </summary>
        public VkStructureType sType;
        /// <summary>
        /// NULL or a pointer to a structure extending this structure.
        /// </summary>
        public IntPtr pNext;
        /// <summary>
        /// a bitmask of VkRenderPassCreateFlagBits
        /// </summary>
        public VkRenderPassCreateFlags flags;
        /// <summary>
        /// the number of attachments used by this render pass.
        /// </summary>
        public uint attachmentCount;
        /// <summary>
        ///  pointer to an array of attachmentCount VkAttachmentDescription structures describing the attachments used by the render pass.
        /// </summary>
        public VkAttachmentDescription[] pAttachments;
        /// <summary>
        /// the number of subpasses to create.
        /// </summary>
        public uint subpassCount;
        /// <summary>
        /// an array of subpassCount VkSubpassDescription structures describing each subpass.
        /// </summary>
        public VkSubpassDescription[] pSubpasses;
        /// <summary>
        /// the number of memory dependencies between pairs of subpasses.
        /// </summary>
        public uint dependencyCount;
        /// <summary>
        /// n array of dependencyCount VkSubpassDependency structures describing dependencies between pairs of subpasses.
        /// </summary>
        public VkSubpassDependency[] pDependencies;
    }

    public struct VkBufferCreateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkBufferCreateFlags flags;
        public ulong size;
        public VkBufferUsageFlags usage;
        public VkSharingMode sharingMode;
        public uint queueFamilyIndexCount;
        public uint[] pQueueFamilyIndices;
    }

    public struct VkMemoryRequirements
    {
        public ulong size;
        public ulong alignment;
        public uint memoryTypeBits;
    }
    public struct VkMemoryAllocateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public ulong allocationSize;
        public uint memoryTypeIndex;
    }
    public struct VkDescriptorPoolCreateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkDescriptorPoolCreateFlags flags;
        public uint maxSets;
        public uint poolSizeCount;
        public VkDescriptorPoolSize[] pPoolSizes;
    }

    public struct VkDescriptorSetLayoutCreateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkDescriptorSetLayoutCreateFlags flags;
        public uint bindingCount;
        public VkDescriptorSetLayoutBinding[] pBindings;
    }
    public struct VkPipelineLayoutCreateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPipelineLayoutCreateFlags flags;
        public uint setLayoutCount;
        public VkDescriptorSetLayout[] pSetLayouts;
        public uint pushConstantRangeCount;
        public VkPushConstantRange[] pPushConstantRanges;
    }

    public struct VkDescriptorSetAllocateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkDescriptorPool descriptorPool;
        public uint descriptorSetCount;
        public VkDescriptorSetLayout[] pSetLayouts;
    }

    /// <summary>
    /// 
    /// 
    /// Only one of pImageInfo, pBufferInfo, or pTexelBufferView members is used according to the descriptor type specified in the descriptorType member of the containing VkWriteDescriptorSet structure, or none of them in case descriptorType is VK_DESCRIPTOR_TYPE_INLINE_UNIFORM_BLOCK, in which case the source data for the descriptor writes is taken from the VkWriteDescriptorSetInlineUniformBlock structure included in the pNext chain of VkWriteDescriptorSet, or if descriptorType is VK_DESCRIPTOR_TYPE_ACCELERATION_STRUCTURE_KHR, in which case the source data for the descriptor writes is taken from the VkWriteDescriptorSetAccelerationStructureKHR structure in the pNext chain of VkWriteDescriptorSet, or if descriptorType is VK_DESCRIPTOR_TYPE_ACCELERATION_STRUCTURE_NV, in which case the source data for the descriptor writes is taken from the VkWriteDescriptorSetAccelerationStructureNV structure in the pNext chain of VkWriteDescriptorSet, as specified below.
    /// 
    /// If the nullDescriptor feature is enabled, the buffer, acceleration structure, imageView, or bufferView can be VK_NULL_HANDLE.Loads from a null descriptor return zero values and stores and atomics to a null descriptor are discarded.A null acceleration structure descriptor results in the miss shader being invoked.
    /// 
    /// If the destination descriptor is a mutable descriptor, the active descriptor type for the destination descriptor becomes descriptorType.
    /// 
    /// If the dstBinding has fewer than descriptorCount array elements remaining starting from dstArrayElement, then the remainder will be used to update the subsequent binding - dstBinding+1 starting at array element zero.If a binding has a descriptorCount of zero, it is skipped.This behavior applies recursively, with the update affecting consecutive bindings as needed to update all descriptorCount descriptors.Consecutive bindings must have identical VkDescriptorType, VkShaderStageFlags, VkDescriptorBindingFlagBits, and immutable samplers references. In addition, if the VkDescriptorType is VK_DESCRIPTOR_TYPE_MUTABLE_EXT, the supported descriptor types in VkMutableDescriptorTypeCreateInfoEXT must be equally defined.
    /// </summary>
    public struct VkWriteDescriptorSet
    {
        /// <summary>
        /// the type of this structure.
        /// </summary>
        public VkStructureType sType;
        /// <summary>
        /// NULL or a pointer to a structure extending this structure.
        /// </summary>
        public IntPtr pNext;
        /// <summary>
        /// the destination descriptor set to update.
        /// </summary>
        public VkDescriptorSet dstSet;
        /// <summary>
        /// the descriptor binding within that set.
        /// </summary>
        public uint dstBinding;
        /// <summary>
        /// The starting element in that array. If the descriptor binding identified 
        /// by dstSet and dstBinding has a descriptor type of 
        /// VK_DESCRIPTOR_TYPE_INLINE_UNIFORM_BLOCK then dstArrayElement specifies the 
        /// starting byte offset within the binding.
        /// </summary>
        public uint dstArrayElement;
        /// <summary>
        /// The number of descriptors to update. If the descriptor binding identified by 
        /// dstSet and dstBinding has a descriptor type of 
        /// VK_DESCRIPTOR_TYPE_INLINE_UNIFORM_BLOCK, then descriptorCount specifies the 
        /// number of bytes to update. Otherwise, descriptorCount is one of
        /// 
        /// The number of elements in pImageInfo
        /// 
        /// the number of elements in pBufferInfo
        /// the number of elements in pTexelBufferView
        /// A value matching the dataSize member of a VkWriteDescriptorSetInlineUniformBlock 
        /// structure in the pNext chain
        /// 
        /// A value matching the accelerationStructureCount of a 
        /// VkWriteDescriptorSetAccelerationStructureKHR structure in the pNext chain
        /// </summary>
        public uint descriptorCount;
        /// <summary>
        /// A VkDescriptorType specifying the type of each descriptor in pImageInfo, pBufferInfo, 
        /// or pTexelBufferView, as described below. If VkDescriptorSetLayoutBinding for 
        /// dstSet at dstBinding is not equal to VK_DESCRIPTOR_TYPE_MUTABLE_EXT, 
        /// descriptorType must be the same type as the descriptorType specified in 
        /// VkDescriptorSetLayoutBinding for dstSet at dstBinding. 
        /// The type of the descriptor also controls which array the descriptors are taken from.
        /// </summary>
        public VkDescriptorType descriptorType;
        /// <summary>
        /// An array of VkDescriptorImageInfo structures or is ignored.
        /// </summary>
        public VkDescriptorImageInfo[] pImageInfo;
        /// <summary>
        /// An array of VkDescriptorBufferInfo structures or is ignored.
        /// </summary>
        public VkDescriptorBufferInfo[] pBufferInfo;
        /// <summary>
        /// An array of VkBufferView handles as described in the Buffer Views section or is ignored, as described below.
        /// </summary>
        public VkBufferView[] pTexelBufferView;
    }

    public struct VkCopyDescriptorSet
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkDescriptorSet srcSet;
        public uint srcBinding;
        public uint srcArrayElement;
        public VkDescriptorSet dstSet;
        public uint dstBinding;
        public uint dstArrayElement;
        public uint descriptorCount;
    }
    public struct VkImageCreateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkImageCreateFlags flags;
        public VkImageType imageType;
        public VkFormat format;
        public VkExtent3D extent;
        public uint mipLevels;
        public uint arrayLayers;
        public VkSampleCountFlags samples;
        public VkImageTiling tiling;
        public VkImageUsageFlags usage;
        public VkSharingMode sharingMode;
        public uint queueFamilyIndexCount;
        public uint[] pQueueFamilyIndices;
        public VkImageLayout initialLayout;
    }

    public struct VkImageViewCreateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkImageViewCreateFlags flags;
        public VkImage image;
        public VkImageViewType viewType;
        public VkFormat format;
        public VkComponentMapping components;
        public VkImageSubresourceRange subresourceRange;
    }
    public struct VkFramebufferCreateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkFramebufferCreateFlags flags;
        public VkRenderPass renderPass;
        public uint attachmentCount;
        public VkImageView[] pAttachments;
        public uint width;
        public uint height;
        public uint layers;
    }
    public struct VkShaderModuleCreateInfo
    {
        /// <summary>
        /// The type of this structure.
        /// </summary>
        public VkStructureType sType;
        /// <summary>
        /// NULL or a pointer to a structure extending this structure.
        /// </summary>
        public IntPtr pNext;
        /// <summary>
        /// Reserved for future use.
        /// </summary>
        public VkShaderModuleCreateFlags flags;
        /// <summary>
        /// The size, in bytes, of the code pointed to by pCode.
        /// </summary>
        public int codeSize;
        /// <summary>
        /// Pointer to code that is used to create the shader module. 
        /// The type and format of the code is determined from the content of the 
        /// memory addressed by pCode.
        /// </summary>
        [MarshalAs(UnmanagedType.LPArray)]
        public uint[] pCode;
    }

    public struct VkGraphicsPipelineCreateInfo
    {
        /// <summary>
        /// The type of this structure.
        /// </summary>
        public VkStructureType sType;
        /// <summary>
        /// NULL or a pointer to a structure extending this structure.
        /// </summary>
        public IntPtr pNext;
        /// <summary>
        /// a bitmask of VkPipelineCreateFlagBits specifying how the pipeline will be generated.
        /// </summary>
        public VkPipelineCreateFlags flags;
        /// <summary>
        ///  the number of entries in the pStages array.
        /// </summary>
        public uint stageCount;
        /// <summary>
        /// an array of stageCount VkPipelineShaderStageCreateInfo structures describing the set of the shader stages to be included in the graphics pipeline.
        /// </summary>
        public VkPipelineShaderStageCreateInfo[] pStages;
        /// <summary>
        /// It is ignored if the pipeline includes a mesh shader stage. 
        /// It is ignored if the pipeline is created with the VK_DYNAMIC_STATE_VERTEX_INPUT_EXT 
        /// dynamic state set.
        /// </summary>
        public VkPipelineVertexInputStateCreateInfo pVertexInputState;
        /// <summary>
        /// Determines input assembly behavior for vertex shading, as described in Drawing Commands. 
        /// It is ignored if the pipeline includes a mesh shader stage.
        /// </summary>
        public VkPipelineInputAssemblyStateCreateInfo pInputAssemblyState;
        /// <summary>
        /// Tessellation state used by tessellation shaders.
        /// </summary>
        public VkPipelineTessellationStateCreateInfo pTessellationState;
        /// <summary>
        /// Viewport state used when rasterization is enabled.
        /// </summary>
        public VkPipelineViewportStateCreateInfo pViewportState;
        /// <summary>
        /// Rasterization state.
        /// </summary>
        public VkPipelineRasterizationStateCreateInfo pRasterizationState;
        /// <summary>
        /// Multisample state used when rasterization is enabled.
        /// </summary>
        public VkPipelineMultisampleStateCreateInfo pMultisampleState;
        /// <summary>
        /// Depth/stencil state used when rasterization is 
        /// enabled for depth or stencil attachments accessed during rendering.
        /// </summary>
        public VkPipelineDepthStencilStateCreateInfo pDepthStencilState;
        /// <summary>
        /// Color blend state used when rasterization is enabled for any 
        /// color attachments accessed during rendering.
        /// </summary>
        public VkPipelineColorBlendStateCreateInfo pColorBlendState;
        /// <summary>
        /// Which properties of the pipeline state object are dynamic and can be changed 
        /// independently of the pipeline state. This can be NULL, which means no 
        /// state in the pipeline is considered dynamic.
        /// </summary>
        public VkPipelineDynamicStateCreateInfo pDynamicState;
        /// <summary>
        /// binding locations used by both the pipeline and descriptor sets used with the pipeline.
        /// </summary>
        public VkPipelineLayout layout;
        /// <summary>
        /// Render pass object describing the environment in which the pipeline will be used. 
        /// The pipeline must only be used with a render pass instance compatible with the one provided. 
        /// See Render Pass Compatibility for more information.
        /// </summary>
        public VkRenderPass renderPass;
        /// <summary>
        /// Index of the subpass in the render pass where this pipeline will be used.
        /// </summary>
        public uint subpass;
        /// <summary>
        /// A pipeline to derive from.
        /// </summary>
        public VkPipeline basePipelineHandle;
        /// <summary>
        /// An index into the pCreateInfos parameter to use as a pipeline to derive from.
        /// </summary>
        public int basePipelineIndex;
    }

    public struct VkAllocationCallbacks
    {

        public delegate IntPtr PFN_vkAllocationFunction(
    IntPtr pUserData,
    int size,
    int alignment,
    VkSystemAllocationScope allocationScope);


        public delegate IntPtr PFN_vkReallocationFunction(
    IntPtr pUserData,
    IntPtr pOriginal,
    int size,
    int alignment,
    VkSystemAllocationScope allocationScope);

        public delegate void PFN_vkFreeFunction(
    IntPtr pUserData,
    IntPtr pMemory);

        public delegate void PFN_vkInternalAllocationNotification(
    IntPtr pUserData,
    int size,
    VkInternalAllocationType allocationType,
    VkSystemAllocationScope allocationScope);

        public delegate void PFN_vkInternalFreeNotification(
    IntPtr pUserData,
    int size,
    VkInternalAllocationType allocationType,
    VkSystemAllocationScope allocationScope);


        public IntPtr pUserData;
        public IntPtr pfnAllocation;
        public IntPtr pfnReallocation;
        public IntPtr pfnFree;
        public IntPtr pfnInternalAllocation;
        public IntPtr pfnInternalFree;
    }

    public struct VkExtent3D
    {
        public uint width;
        public uint height;
        public uint depth;
    }


    public struct VkOffset3D
    {
        public int x;
        public int y;
        public int z;
    }


    public struct VkBaseInStructure
    {
        public VkStructureType sType;

        /// <summary>
        /// VkBaseInStructure
        /// </summary>
        public IntPtr pNext;
    }

    public struct VkBaseOutStructure
    {
        public VkStructureType sType;

        /// <summary>
        /// VkBaseOutStructure
        /// </summary>
        public IntPtr pNext;
    }

    public struct VkBufferMemoryBarrier
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkAccessFlags srcAccessMask;
        public VkAccessFlags dstAccessMask;
        public uint srcQueueFamilyIndex;
        public uint dstQueueFamilyIndex;
        public VkBuffer buffer;
        public ulong offset;
        public ulong size;
    }

    public struct VkDispatchIndirectCommand
    {
        public uint x;
        public uint y;
        public uint z;
    }

    public struct VkDrawIndexedIndirectCommand
    {
        public uint indexCount;
        public uint instanceCount;
        public uint firstIndex;
        public int vertexOffset;
        public uint firstInstance;
    }

    public struct VkDrawIndirectCommand
    {
        public uint vertexCount;
        public uint instanceCount;
        public uint firstVertex;
        public uint firstInstance;
    }

    public struct VkImageSubresourceRange
    {
        public VkImageAspectFlags aspectMask;
        public uint baseMipLevel;
        public uint levelCount;
        public uint baseArrayLayer;
        public uint layerCount;
    }

    public struct VkImageMemoryBarrier
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkAccessFlags srcAccessMask;
        public VkAccessFlags dstAccessMask;
        public VkImageLayout oldLayout;
        public VkImageLayout newLayout;
        public uint srcQueueFamilyIndex;
        public uint dstQueueFamilyIndex;
        public VkImage image;
        public VkImageSubresourceRange subresourceRange;
    }

    public struct VkMemoryBarrier
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkAccessFlags srcAccessMask;
        public VkAccessFlags dstAccessMask;
    }

    public struct VkPipelineCacheHeaderVersionOne
    {
        public const int VK_UUID_SIZE = 16;

        public uint headerSize;
        VkPipelineCacheHeaderVersion headerVersion;
        public uint vendorID;
        public uint deviceID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = VK_UUID_SIZE)]
        public byte[] pipelineCacheUUID;
    }


    public struct VkApplicationInfo
    {
        public VkStructureType sType = VkStructureType.VK_STRUCTURE_TYPE_APPLICATION_INFO;
        public IntPtr pNext = IntPtr.Zero;

        [MarshalAs(UnmanagedType.LPStr)]
        public string pApplicationName = "";
        public uint applicationVersion = 0;
        [MarshalAs(UnmanagedType.LPStr)]
        public string pEngineName = "";
        public uint engineVersion = 0;
        public uint apiVersion = 0;

        public VkApplicationInfo() { }
    }

    public struct VkFormatProperties
    {
        public VkFormatFeatureFlags linearTilingFeatures;
        public VkFormatFeatureFlags optimalTilingFeatures;
        public VkFormatFeatureFlags bufferFeatures;
    }

    public struct VkImageFormatProperties
    {
        public VkExtent3D maxExtent;
        public uint maxMipLevels;
        public uint maxArrayLayers;
        public VkSampleCountFlags sampleCounts;
        public ulong maxResourceSize;
    }

    //[StructLayoutAttribute(LayoutKind.Sequential, Pack = 1)]
    public struct VkInstanceCreateInfo
    {
        public VkStructureType sType = VkStructureType.VK_STRUCTURE_TYPE_INSTANCE_CREATE_INFO;
        //[MarshalAs(UnmanagedType.IUnknown /*, SafeArraySubType = VarEnum.VT_USERDEFINED*/)]
        public /*IVkStruct*/ IntPtr pNext = IntPtr.Zero;
        public VkInstanceCreateFlags flags = VkInstanceCreateFlags.None;
        //[MarshalAs(UnmanagedType.)]
        public VkApplicationInfo pApplicationInfo = new VkApplicationInfo();
        public uint enabledLayerCount = 0;
        public string[] ppEnabledLayerNames = new string[0];
        public uint enabledExtensionCount = 0;
        //[MarshalAs(UnmanagedType.BStr)]
        public string[] ppEnabledExtensionNames = new string[0];

        public VkInstanceCreateInfo() { }
    }

    public struct VkMemoryHeap
    {
        public ulong size;
        public VkMemoryHeapFlags flags;
    }

    public struct VkMemoryType
    {
        public VkMemoryPropertyFlags propertyFlags;
        public uint heapIndex;
    }

    public struct VkPhysicalDeviceFeatures
    {
        public Bool32 robustBufferAccess;
        public Bool32 fullDrawIndexUint32;
        public Bool32 imageCubeArray;
        public Bool32 independentBlend;
        public Bool32 geometryShader;
        public Bool32 tessellationShader;
        public Bool32 sampleRateShading;
        public Bool32 dualSrcBlend;
        public Bool32 logicOp;
        public Bool32 multiDrawIndirect;
        public Bool32 drawIndirectFirstInstance;
        public Bool32 depthClamp;
        public Bool32 depthBiasClamp;
        public Bool32 fillModeNonSolid;
        public Bool32 depthBounds;
        public Bool32 wideLines;
        public Bool32 largePoints;
        public Bool32 alphaToOne;
        public Bool32 multiViewport;
        public Bool32 samplerAnisotropy;
        public Bool32 textureCompressionETC2;
        public Bool32 textureCompressionASTC_LDR;
        public Bool32 textureCompressionBC;
        public Bool32 occlusionQueryPrecise;
        public Bool32 pipelineStatisticsQuery;
        public Bool32 vertexPipelineStoresAndAtomics;
        public Bool32 fragmentStoresAndAtomics;
        public Bool32 shaderTessellationAndGeometryPointSize;
        public Bool32 shaderImageGatherExtended;
        public Bool32 shaderStorageImageExtendedFormats;
        public Bool32 shaderStorageImageMultisample;
        public Bool32 shaderStorageImageReadWithoutFormat;
        public Bool32 shaderStorageImageWriteWithoutFormat;
        public Bool32 shaderUniformBufferArrayDynamicIndexing;
        public Bool32 shaderSampledImageArrayDynamicIndexing;
        public Bool32 shaderStorageBufferArrayDynamicIndexing;
        public Bool32 shaderStorageImageArrayDynamicIndexing;
        public Bool32 shaderClipDistance;
        public Bool32 shaderCullDistance;
        public Bool32 shaderFloat64;
        public Bool32 shaderInt64;
        public Bool32 shaderInt16;
        public Bool32 shaderResourceResidency;
        public Bool32 shaderResourceMinLod;
        public Bool32 sparseBinding;
        public Bool32 sparseResidencyBuffer;
        public Bool32 sparseResidencyImage2D;
        public Bool32 sparseResidencyImage3D;
        public Bool32 sparseResidency2Samples;
        public Bool32 sparseResidency4Samples;
        public Bool32 sparseResidency8Samples;
        public Bool32 sparseResidency16Samples;
        public Bool32 sparseResidencyAliased;
        public Bool32 variableMultisampleRate;
        public Bool32 inheritedQueries;
    }

    public struct VkPhysicalDeviceLimits
    {
        public uint maxImageDimension1D;
        public uint maxImageDimension2D;
        public uint maxImageDimension3D;
        public uint maxImageDimensionCube;
        public uint maxImageArrayLayers;
        public uint maxTexelBufferElements;
        public uint maxUniformBufferRange;
        public uint maxStorageBufferRange;
        public uint maxPushConstantsSize;
        public uint maxMemoryAllocationCount;
        public uint maxSamplerAllocationCount;
        public ulong bufferImageGranularity;
        public ulong sparseAddressSpaceSize;
        public uint maxBoundDescriptorSets;
        public uint maxPerStageDescriptorSamplers;
        public uint maxPerStageDescriptorUniformBuffers;
        public uint maxPerStageDescriptorStorageBuffers;
        public uint maxPerStageDescriptorSampledImages;
        public uint maxPerStageDescriptorStorageImages;
        public uint maxPerStageDescriptorInputAttachments;
        public uint maxPerStageResources;
        public uint maxDescriptorSetSamplers;
        public uint maxDescriptorSetUniformBuffers;
        public uint maxDescriptorSetUniformBuffersDynamic;
        public uint maxDescriptorSetStorageBuffers;
        public uint maxDescriptorSetStorageBuffersDynamic;
        public uint maxDescriptorSetSampledImages;
        public uint maxDescriptorSetStorageImages;
        public uint maxDescriptorSetInputAttachments;
        public uint maxVertexInputAttributes;
        public uint maxVertexInputBindings;
        public uint maxVertexInputAttributeOffset;
        public uint maxVertexInputBindingStride;
        public uint maxVertexOutputComponents;
        public uint maxTessellationGenerationLevel;
        public uint maxTessellationPatchSize;
        public uint maxTessellationControlPerVertexInputComponents;
        public uint maxTessellationControlPerVertexOutputComponents;
        public uint maxTessellationControlPerPatchOutputComponents;
        public uint maxTessellationControlTotalOutputComponents;
        public uint maxTessellationEvaluationInputComponents;
        public uint maxTessellationEvaluationOutputComponents;
        public uint maxGeometryShaderInvocations;
        public uint maxGeometryInputComponents;
        public uint maxGeometryOutputComponents;
        public uint maxGeometryOutputVertices;
        public uint maxGeometryTotalOutputComponents;
        public uint maxFragmentInputComponents;
        public uint maxFragmentOutputAttachments;
        public uint maxFragmentDualSrcAttachments;
        public uint maxFragmentCombinedOutputResources;
        public uint maxComputeSharedMemorySize;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] maxComputeWorkGroupCount;
        public uint maxComputeWorkGroupInvocations;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] maxComputeWorkGroupSize;
        public uint subPixelPrecisionBits;
        public uint subTexelPrecisionBits;
        public uint mipmapPrecisionBits;
        public uint maxDrawIndexedIndexValue;
        public uint maxDrawIndirectCount;
        public float maxSamplerLodBias;
        public float maxSamplerAnisotropy;
        public uint maxViewports;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[] maxViewportDimensions;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public float[] viewportBoundsRange;
        public uint viewportSubPixelBits;
        public int minMemoryMapAlignment;
        public ulong minTexelBufferOffsetAlignment;
        public ulong minUniformBufferOffsetAlignment;
        public ulong minStorageBufferOffsetAlignment;
        public int minTexelOffset;
        public uint maxTexelOffset;
        public int minTexelGatherOffset;
        public uint maxTexelGatherOffset;
        public float minInterpolationOffset;
        public float maxInterpolationOffset;
        public uint subPixelInterpolationOffsetBits;
        public uint maxFramebufferWidth;
        public uint maxFramebufferHeight;
        public uint maxFramebufferLayers;
        public VkSampleCountFlags framebufferColorSampleCounts;
        public VkSampleCountFlags framebufferDepthSampleCounts;
        public VkSampleCountFlags framebufferStencilSampleCounts;
        public VkSampleCountFlags framebufferNoAttachmentsSampleCounts;
        public uint maxColorAttachments;
        public VkSampleCountFlags sampledImageColorSampleCounts;
        public VkSampleCountFlags sampledImageIntegerSampleCounts;
        public VkSampleCountFlags sampledImageDepthSampleCounts;
        public VkSampleCountFlags sampledImageStencilSampleCounts;
        public VkSampleCountFlags storageImageSampleCounts;
        public uint maxSampleMaskWords;
        public Bool32 timestampComputeAndGraphics;
        public float timestampPeriod;
        public uint maxClipDistances;
        public uint maxCullDistances;
        public uint maxCombinedClipAndCullDistances;
        public uint discreteQueuePriorities;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public float[] pointSizeRange;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public float[] lineWidthRange;
        public float pointSizeGranularity;
        public float lineWidthGranularity;
        public Bool32 strictLines;
        public Bool32 standardSampleLocations;
        public ulong optimalBufferCopyOffsetAlignment;
        public ulong optimalBufferCopyRowPitchAlignment;
        public ulong nonCoherentAtomSize;
    }

    public struct VkPhysicalDeviceMemoryProperties
    {
        public const int VK_MAX_MEMORY_TYPES = 32;

        public uint memoryTypeCount;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = VK_MAX_MEMORY_TYPES)]
        public VkMemoryType[] memoryTypes;
        public uint memoryHeapCount;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = VK_MAX_MEMORY_TYPES)]
        public VkMemoryHeap[] memoryHeaps;
    }

    public struct VkPhysicalDeviceSparseProperties
    {
        public Bool32 residencyStandard2DBlockShape;
        public Bool32 residencyStandard2DMultisampleBlockShape;
        public Bool32 residencyStandard3DBlockShape;
        public Bool32 residencyAlignedMipSize;
        public Bool32 residencyNonResidentStrict;
    }

    public struct VkPhysicalDeviceProperties
    {
        public uint apiVersion;
        public uint driverVersion;
        public uint vendorID;
        public uint deviceID;
        public VkPhysicalDeviceType deviceType;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = VK.VK_MAX_PHYSICAL_DEVICE_NAME_SIZE)]
        public string deviceName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = VK.VK_UUID_SIZE)]
        public byte[] pipelineCacheUUID;
        public VkPhysicalDeviceLimits limits;
        public VkPhysicalDeviceSparseProperties sparseProperties;
    }

    public struct VkQueueFamilyProperties
    {
        public VkQueueFlags queueFlags;
        public uint queueCount;
        public uint timestampValidBits;
        public VkExtent3D minImageTransferGranularity;
    }

    public struct VkDeviceQueueCreateInfo
    {
        public VkStructureType sType = VkStructureType.VK_STRUCTURE_TYPE_DEVICE_QUEUE_CREATE_INFO;
        public IntPtr pNext = IntPtr.Zero;
        public VkDeviceQueueCreateFlags flags = VkDeviceQueueCreateFlags.None;
        public uint queueFamilyIndex = 0;
        public uint queueCount = 0;
        public float[] pQueuePriorities = new float[0];

        public VkDeviceQueueCreateInfo() { }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 48)]
    public struct VkDeviceCreateInfo
    {
        public VkStructureType sType = VkStructureType.VK_STRUCTURE_TYPE_DEVICE_CREATE_INFO;
        public IntPtr pNext = IntPtr.Zero;
        public VkDeviceCreateFlags flags = VkDeviceCreateFlags.None;
        
        public uint queueCreateInfoCount = 0;
        //[MarshalAs(UnmanagedType.LPArray)]
        public VkDeviceQueueCreateInfo[] pQueueCreateInfos = new VkDeviceQueueCreateInfo[0];
        
        public uint enabledLayerCount = 0;
        public string[] ppEnabledLayerNames = new string[0];

        public uint enabledExtensionCount = 0;
        public string[] ppEnabledExtensionNames = new string[0];

        //[MarshalAs(UnmanagedType.LPArray)]
        public VkPhysicalDeviceFeatures pEnabledFeatures = new VkPhysicalDeviceFeatures();
        
        public VkDeviceCreateInfo() { }
    }

    [StructLayout(LayoutKind.Sequential, Pack =1, Size = VK.VK_MAX_EXTENSION_NAME_SIZE+4)]
    public struct VkExtensionProperties
    {

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = VK.VK_MAX_EXTENSION_NAME_SIZE)]
        public string extensionName = "";
        public uint specVersion = 0;

        public VkExtensionProperties() { }
    }

    public struct VkLayerProperties
    {

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = VK.VK_MAX_EXTENSION_NAME_SIZE)]
        public string layerName = "";
        public uint specVersion = 0;
        public uint implementationVersion = 0; 

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = VK.VK_MAX_DESCRIPTION_SIZE)]
        public string description = "";

        public VkLayerProperties() { }
    }

    public struct VkSubmitInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint waitSemaphoreCount;
        public VkSemaphore[] pWaitSemaphores;
        public VkPipelineStageFlags[] pWaitDstStageMask;
        public uint commandBufferCount;
        public VkCommandBuffer[] pCommandBuffers;
        public uint signalSemaphoreCount;
        public VkSemaphore[] pSignalSemaphores;
    }

    public struct VkMappedMemoryRange
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkDeviceMemory memory;
        public ulong offset;
        public ulong size;
    }

    public struct VkSparseMemoryBind
    {
        public ulong resourceOffset;
        public ulong size;
        public VkDeviceMemory memory;
        public ulong memoryOffset;
        public VkSparseMemoryBindFlags flags;
    }

    public struct VkSparseBufferMemoryBindInfo
    {
        public VkBuffer buffer;
        public uint bindCount;
        public VkSparseMemoryBind[] pBinds;
    }

    public struct VkSparseImageOpaqueMemoryBindInfo
    {
        public VkImage image;
        public uint bindCount;
        public VkSparseMemoryBind[] pBinds;
    }

    public struct VkImageSubresource
    {
        public VkImageAspectFlags aspectMask;
        public uint mipLevel;
        public uint arrayLayer;
    }

    public struct VkSparseImageMemoryBind
    {
        public VkImageSubresource subresource;
        public VkOffset3D offset;
        public VkExtent3D extent;
        public VkDeviceMemory memory;
        public ulong memoryOffset;
        public VkSparseMemoryBindFlags flags;
    }

    public struct VkSparseImageMemoryBindInfo
    {
        public VkImage image;
        public uint bindCount;
        public VkSparseImageMemoryBind[] pBinds;
    }

    public struct VkBindSparseInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint waitSemaphoreCount;
        public VkSemaphore[] pWaitSemaphores;
        public uint bufferBindCount;
        public VkSparseBufferMemoryBindInfo[] pBufferBinds;
        public uint imageOpaqueBindCount;
        public VkSparseImageOpaqueMemoryBindInfo[] pImageOpaqueBinds;
        public uint imageBindCount;
        public VkSparseImageMemoryBindInfo[] pImageBinds;
        public uint signalSemaphoreCount;
        public VkSemaphore[] pSignalSemaphores;
    }

    public struct VkSparseImageFormatProperties
    {
        public VkImageAspectFlags aspectMask;
        public VkExtent3D imageGranularity;
        public VkSparseImageFormatFlags flags;
    }

    public struct VkSparseImageMemoryRequirements
    {
        public VkSparseImageFormatProperties formatProperties;
        public uint imageMipTailFirstLod;
        public ulong imageMipTailSize;
        public ulong imageMipTailOffset;
        public ulong imageMipTailStride;
    }


    public struct VkEventCreateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkEventCreateFlags flags;
    }

    public struct VkQueryPoolCreateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkQueryPoolCreateFlags flags;
        public VkQueryType queryType;
        public uint queryCount;
        public VkQueryPipelineStatisticFlags pipelineStatistics;
    }

    public struct VkBufferViewCreateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkBufferViewCreateFlags flags;
        public VkBuffer buffer;
        public VkFormat format;
        public ulong offset;
        public ulong range;
    }

    public struct VkSubresourceLayout
    {
        public ulong offset;
        public ulong size;
        public ulong rowPitch;
        public ulong arrayPitch;
        public ulong depthPitch;
    }

    public struct VkComponentMapping
    {
        public VkComponentSwizzle r;
        public VkComponentSwizzle g;
        public VkComponentSwizzle b;
        public VkComponentSwizzle a;
    }

    public struct VkPipelineCacheCreateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPipelineCacheCreateFlags flags;
        public int initialDataSize;
        public IntPtr pInitialData;
    }

    public struct VkSpecializationMapEntry
    {
        public uint constantID;
        public uint offset;
        public int size;
    }

    public struct VkSpecializationInfo
    {
        public uint mapEntryCount;
        public VkSpecializationMapEntry[] pMapEntries;
        public int dataSize;
        public IntPtr pData;
    }

    public struct VkPipelineShaderStageCreateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPipelineShaderStageCreateFlags flags;
        public VkShaderStageFlags stage;
        public VkShaderModule module;
        public string pName;
        public VkSpecializationInfo pSpecializationInfo;
    }

    public struct VkComputePipelineCreateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPipelineCreateFlags flags;
        public VkPipelineShaderStageCreateInfo stage;
        public VkPipelineLayout layout;
        public VkPipeline basePipelineHandle;
        public int basePipelineIndex;
    }

    public struct VkVertexInputBindingDescription
    {
        public uint binding;
        public uint stride;
        public VkVertexInputRate inputRate;
    }

    public struct VkVertexInputAttributeDescription
    {
        public uint location;
        public uint binding;
        public VkFormat format;
        public uint offset;
    }

    public struct VkPipelineVertexInputStateCreateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPipelineVertexInputStateCreateFlags flags;
        public uint vertexBindingDescriptionCount;
        public VkVertexInputBindingDescription[] pVertexBindingDescriptions;
        public uint vertexAttributeDescriptionCount;
        public VkVertexInputAttributeDescription[] pVertexAttributeDescriptions;
    }

    public struct VkPipelineInputAssemblyStateCreateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPipelineInputAssemblyStateCreateFlags flags;
        public VkPrimitiveTopology topology;
        public Bool32 primitiveRestartEnable;
    }

    public struct VkPipelineTessellationStateCreateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPipelineTessellationStateCreateFlags flags;
        public uint patchControlPoints;
    }

    public struct VkViewport
    {
        public float x;
        public float y;
        public float width;
        public float height;
        public float minDepth;
        public float maxDepth;
    }

    public struct VkPipelineViewportStateCreateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPipelineViewportStateCreateFlags flags;
        public uint viewportCount;
        public VkViewport[] pViewports;
        public uint scissorCount;
        public VkRect2D[] pScissors;
    }

    public struct VkPipelineRasterizationStateCreateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPipelineRasterizationStateCreateFlags flags;
        public Bool32 depthClampEnable;
        public Bool32 rasterizerDiscardEnable;
        public VkPolygonMode polygonMode;
        public VkCullModeFlags cullMode;
        public VkFrontFace frontFace;
        public Bool32 depthBiasEnable;
        public float depthBiasConstantFactor;
        public float depthBiasClamp;
        public float depthBiasSlopeFactor;
        public float lineWidth;
    }

    public struct VkPipelineMultisampleStateCreateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPipelineMultisampleStateCreateFlags flags;
        public VkSampleCountFlags rasterizationSamples;
        public Bool32 sampleShadingEnable;
        public float minSampleShading;
        public uint[] pSampleMask;
        public Bool32 alphaToCoverageEnable;
        public Bool32 alphaToOneEnable;
    }

    public struct VkStencilOpState
    {
        public VkStencilOp failOp;
        public VkStencilOp passOp;
        public VkStencilOp depthFailOp;
        public VkCompareOp compareOp;
        public uint compareMask;
        public uint writeMask;
        public uint reference;
    }

    public struct VkPipelineDepthStencilStateCreateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPipelineDepthStencilStateCreateFlags flags;
        public Bool32 depthTestEnable;
        public Bool32 depthWriteEnable;
        public VkCompareOp depthCompareOp;
        public Bool32 depthBoundsTestEnable;
        public Bool32 stencilTestEnable;
        public VkStencilOpState front;
        public VkStencilOpState back;
        public float minDepthBounds;
        public float maxDepthBounds;
    }

    public struct VkPipelineColorBlendAttachmentState
    {
        public Bool32 blendEnable;
        public VkBlendFactor srcColorBlendFactor;
        public VkBlendFactor dstColorBlendFactor;
        public VkBlendOp colorBlendOp;
        public VkBlendFactor srcAlphaBlendFactor;
        public VkBlendFactor dstAlphaBlendFactor;
        public VkBlendOp alphaBlendOp;
        public VkColorComponentFlags colorWriteMask;
    }

    public struct VkPipelineColorBlendStateCreateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPipelineColorBlendStateCreateFlags flags;
        public Bool32 logicOpEnable;
        public VkLogicOp logicOp;
        public uint attachmentCount;
        public VkPipelineColorBlendAttachmentState[] pAttachments;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] blendConstants;
    }

    public struct VkPipelineDynamicStateCreateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPipelineDynamicStateCreateFlags flags;
        public uint dynamicStateCount;
        public VkDynamicState[] pDynamicStates;
    }

    public struct VkPushConstantRange
    {
        public VkShaderStageFlags stageFlags;
        public uint offset;
        public uint size;
    }

    public struct VkSamplerCreateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkSamplerCreateFlags flags;
        public VkFilter magFilter;
        public VkFilter minFilter;
        public VkSamplerMipmapMode mipmapMode;
        public VkSamplerAddressMode addressModeU;
        public VkSamplerAddressMode addressModeV;
        public VkSamplerAddressMode addressModeW;
        public float mipLodBias;
        public Bool32 anisotropyEnable;
        public float maxAnisotropy;
        public Bool32 compareEnable;
        public VkCompareOp compareOp;
        public float minLod;
        public float maxLod;
        public VkBorderColor borderColor;
        public Bool32 unnormalizedCoordinates;
    }

    public struct VkDescriptorBufferInfo
    {
        public VkBuffer buffer;
        public ulong offset;
        public ulong range;
    }

    public struct VkDescriptorImageInfo
    {
        public VkSampler sampler;
        public VkImageView imageView;
        public VkImageLayout imageLayout;
    }

    public struct VkDescriptorPoolSize
    {
        public VkDescriptorType type;
        public uint descriptorCount;
    }

    public struct VkDescriptorSetLayoutBinding
    {
        public uint binding;
        public VkDescriptorType descriptorType;
        public uint descriptorCount;
        public VkShaderStageFlags stageFlags;
        public VkSampler[] pImmutableSamplers;
    }

    public struct VkAttachmentDescription
    {
        public VkAttachmentDescriptionFlags flags;
        public VkFormat format;
        public VkSampleCountFlags samples;
        public VkAttachmentLoadOp loadOp;
        public VkAttachmentStoreOp storeOp;
        public VkAttachmentLoadOp stencilLoadOp;
        public VkAttachmentStoreOp stencilStoreOp;
        public VkImageLayout initialLayout;
        public VkImageLayout finalLayout;
    }

    public struct VkAttachmentReference
    {
        public uint attachment;
        public VkImageLayout layout;
    }

    public struct VkSubpassDescription
    {
        public VkSubpassDescriptionFlags flags;
        public VkPipelineBindPoint pipelineBindPoint;
        public uint inputAttachmentCount;
        public VkAttachmentReference[] pInputAttachments;
        public uint colorAttachmentCount;
        public VkAttachmentReference[] pColorAttachments;
        public VkAttachmentReference[] pResolveAttachments;
        public VkAttachmentReference pDepthStencilAttachment;
        public uint preserveAttachmentCount;
        public uint[] pPreserveAttachments;
    }

    public struct VkSubpassDependency
    {
        public uint srcSubpass;
        public uint dstSubpass;
        public VkPipelineStageFlags srcStageMask;
        public VkPipelineStageFlags dstStageMask;
        public VkAccessFlags srcAccessMask;
        public VkAccessFlags dstAccessMask;
        public VkDependencyFlags dependencyFlags;
    }

    public struct VkCommandPoolCreateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkCommandPoolCreateFlags flags;
        public uint queueFamilyIndex;
    }

    public struct VkCommandBufferInheritanceInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkRenderPass renderPass;
        public uint subpass;
        public VkFramebuffer framebuffer;
        public Bool32 occlusionQueryEnable;
        public VkQueryControlFlags queryFlags;
        public VkQueryPipelineStatisticFlags pipelineStatistics;
    }

    public struct VkBufferCopy
    {
        public ulong srcOffset;
        public ulong dstOffset;
        public ulong size;
    }

    public struct VkImageSubresourceLayers
    {
        public VkImageAspectFlags aspectMask;
        public uint mipLevel;
        public uint baseArrayLayer;
        public uint layerCount;
    }

    public struct VkBufferImageCopy
    {
        public ulong bufferOffset;
        public uint bufferRowLength;
        public uint bufferImageHeight;
        public VkImageSubresourceLayers imageSubresource;
        public VkOffset3D imageOffset;
        public VkExtent3D imageExtent;
    }

    [StructLayout(LayoutKind.Explicit, Size = 16)]
    public struct VkClearColorValue {
        [FieldOffset(0)]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] float32;
        [FieldOffset(0)]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public int[] int32;
        [FieldOffset(0)]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public uint[] uint32;
    }

    public struct VkClearDepthStencilValue
    {
        public float depth;
        public uint stencil;
    }

    public struct VkClearAttachment
    {
        public VkImageAspectFlags aspectMask;
        public uint colorAttachment;
        public VkClearValue clearValue;
    }

    public struct VkClearRect
    {
        public VkRect2D rect;
        public uint baseArrayLayer;
        public uint layerCount;
    }

    public struct VkImageBlit
    {
        public VkImageSubresourceLayers srcSubresource;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public VkOffset3D[] srcOffsets;
        public VkImageSubresourceLayers dstSubresource;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public VkOffset3D[] dstOffsets;
    }

    public struct VkImageCopy
    {
        public VkImageSubresourceLayers srcSubresource;
        public VkOffset3D srcOffset;
        public VkImageSubresourceLayers dstSubresource;
        public VkOffset3D dstOffset;
        public VkExtent3D extent;
    }

    public struct VkImageResolve
    {
        public VkImageSubresourceLayers srcSubresource;
        public VkOffset3D srcOffset;
        public VkImageSubresourceLayers dstSubresource;
        public VkOffset3D dstOffset;
        public VkExtent3D extent;
    }

    public struct VkPhysicalDeviceSubgroupProperties
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint subgroupSize;
        public VkShaderStageFlags supportedStages;
        public VkSubgroupFeatureFlags supportedOperations;
        public Bool32 quadOperationsInAllStages;
    }

    public struct VkBindBufferMemoryInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkBuffer buffer;
        public VkDeviceMemory memory;
        public ulong memoryOffset;
    }

    public struct VkBindImageMemoryInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkImage image;
        public VkDeviceMemory memory;
        public ulong memoryOffset;
    }

    public struct VkPhysicalDevice16BitStorageFeatures
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 storageBuffer16BitAccess;
        public Bool32 uniformAndStorageBuffer16BitAccess;
        public Bool32 storagePushConstant16;
        public Bool32 storageInputOutput16;
    }

    public struct VkMemoryDedicatedRequirements
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 prefersDedicatedAllocation;
        public Bool32 requiresDedicatedAllocation;
    }

    public struct VkMemoryDedicatedAllocateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkImage image;
        public VkBuffer buffer;
    }

    public struct VkMemoryAllocateFlagsInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkMemoryAllocateFlags flags;
        public uint deviceMask;
    }

    public struct VkDeviceGroupRenderPassBeginInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint deviceMask;
        public uint deviceRenderAreaCount;
        public VkRect2D[] pDeviceRenderAreas;
    }

    public struct VkDeviceGroupCommandBufferBeginInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint deviceMask;
    }

    public struct VkDeviceGroupSubmitInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint waitSemaphoreCount;
        public uint[] pWaitSemaphoreDeviceIndices;
        public uint commandBufferCount;
        public uint[] pCommandBufferDeviceMasks;
        public uint signalSemaphoreCount;
        public uint[] pSignalSemaphoreDeviceIndices;
    }

    public struct VkDeviceGroupBindSparseInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint resourceDeviceIndex;
        public uint memoryDeviceIndex;
    }

    public struct VkBindBufferMemoryDeviceGroupInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint deviceIndexCount;
        public uint[] pDeviceIndices;
    }

    public struct VkBindImageMemoryDeviceGroupInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint deviceIndexCount;
        public uint[] pDeviceIndices;
        public uint splitInstanceBindRegionCount;
        public VkRect2D[] pSplitInstanceBindRegions;
    }

    public struct VkPhysicalDeviceGroupProperties
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint physicalDeviceCount;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = VK.VK_MAX_DEVICE_GROUP_SIZE)]
        public VkPhysicalDevice[] physicalDevices;
        public Bool32 subsetAllocation;
    }

    public struct VkDeviceGroupDeviceCreateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint physicalDeviceCount;
        public VkPhysicalDevice[] pPhysicalDevices;
    }

    public struct VkBufferMemoryRequirementsInfo2
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkBuffer buffer;
    }

    public struct VkImageMemoryRequirementsInfo2
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkImage image;
    }

    public struct VkImageSparseMemoryRequirementsInfo2
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkImage image;
    }

    public struct VkMemoryRequirements2
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkMemoryRequirements memoryRequirements;
    }

    public struct VkSparseImageMemoryRequirements2
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkSparseImageMemoryRequirements memoryRequirements;
    }

    public struct VkPhysicalDeviceFeatures2
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPhysicalDeviceFeatures features;
    }

    public struct VkPhysicalDeviceProperties2
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPhysicalDeviceProperties properties;
    }

    public struct VkFormatProperties2
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkFormatProperties formatProperties;
    }

    public struct VkImageFormatProperties2
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkImageFormatProperties imageFormatProperties;
    }

    public struct VkPhysicalDeviceImageFormatInfo2
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkFormat format;
        public VkImageType type;
        public VkImageTiling tiling;
        public VkImageUsageFlags usage;
        public VkImageCreateFlags flags;
    }

    public struct VkQueueFamilyProperties2
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkQueueFamilyProperties queueFamilyProperties;
    }

    public struct VkPhysicalDeviceMemoryProperties2
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPhysicalDeviceMemoryProperties memoryProperties;
    }

    public struct VkSparseImageFormatProperties2
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkSparseImageFormatProperties properties;
    }

    public struct VkPhysicalDeviceSparseImageFormatInfo2
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkFormat format;
        public VkImageType type;
        public VkSampleCountFlags samples;
        public VkImageUsageFlags usage;
        public VkImageTiling tiling;
    }

    public struct VkPhysicalDevicePointClippingProperties
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPointClippingBehavior pointClippingBehavior;
    }

    public struct VkInputAttachmentAspectReference
    {
        public uint subpass;
        public uint inputAttachmentIndex;
        public VkImageAspectFlags aspectMask;
    }

    public struct VkRenderPassInputAttachmentAspectCreateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint aspectReferenceCount;
        public VkInputAttachmentAspectReference[] pAspectReferences;
    }

    public struct VkImageViewUsageCreateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkImageUsageFlags usage;
    }

    public struct VkPipelineTessellationDomainOriginStateCreateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkTessellationDomainOrigin domainOrigin;
    }

    public struct VkRenderPassMultiviewCreateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint subpassCount;
        public uint[] pViewMasks;
        public uint dependencyCount;
        public int[] pViewOffsets;
        public uint correlationMaskCount;
        public uint[] pCorrelationMasks;
    }

    public struct VkPhysicalDeviceMultiviewFeatures
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 multiview;
        public Bool32 multiviewGeometryShader;
        public Bool32 multiviewTessellationShader;
    }

    public struct VkPhysicalDeviceMultiviewProperties
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint maxMultiviewViewCount;
        public uint maxMultiviewInstanceIndex;
    }

    public struct VkPhysicalDeviceVariablePointersFeatures
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 variablePointersStorageBuffer;
        public Bool32 variablePointers;
    }

    //typedef VkPhysicalDeviceVariablePointersFeatures VkPhysicalDeviceVariablePointerFeatures;

    public struct VkPhysicalDeviceProtectedMemoryFeatures
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 protectedMemory;
    }

    public struct VkPhysicalDeviceProtectedMemoryProperties
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 protectedNoFault;
    }

    public struct VkDeviceQueueInfo2
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkDeviceQueueCreateFlags flags;
        public uint queueFamilyIndex;
        public uint queueIndex;
    }

    public struct VkProtectedSubmitInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 protectedSubmit;
    }

    public struct VkSamplerYcbcrConversionCreateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkFormat format;
        public VkSamplerYcbcrModelConversion ycbcrModel;
        public VkSamplerYcbcrRange ycbcrRange;
        public VkComponentMapping components;
        public VkChromaLocation xChromaOffset;
        public VkChromaLocation yChromaOffset;
        public VkFilter chromaFilter;
        public Bool32 forceExplicitReconstruction;
    }

    public struct VkSamplerYcbcrConversionInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkSamplerYcbcrConversion conversion;
    }

    public struct VkBindImagePlaneMemoryInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkImageAspectFlags planeAspect;
    }

    public struct VkImagePlaneMemoryRequirementsInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkImageAspectFlags planeAspect;
    }

    public struct VkPhysicalDeviceSamplerYcbcrConversionFeatures
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 samplerYcbcrConversion;
    }

    public struct VkSamplerYcbcrConversionImageFormatProperties
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint combinedImageSamplerDescriptorCount;
    }

    public struct VkDescriptorUpdateTemplateEntry
    {
        public uint dstBinding;
        public uint dstArrayElement;
        public uint descriptorCount;
        public VkDescriptorType descriptorType;
        public int offset;
        public int stride;
    }

    public struct VkDescriptorUpdateTemplateCreateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkDescriptorUpdateTemplateCreateFlags flags;
        public uint descriptorUpdateEntryCount;
        public VkDescriptorUpdateTemplateEntry[] pDescriptorUpdateEntries;
        public VkDescriptorUpdateTemplateType templateType;
        public VkDescriptorSetLayout descriptorSetLayout;
        public VkPipelineBindPoint pipelineBindPoint;
        public VkPipelineLayout pipelineLayout;
        public uint set;
    }

    public struct VkExternalMemoryProperties
    {
        public VkExternalMemoryFeatureFlags externalMemoryFeatures;
        public VkExternalMemoryHandleTypeFlags exportFromImportedHandleTypes;
        public VkExternalMemoryHandleTypeFlags compatibleHandleTypes;
    }

    public struct VkPhysicalDeviceExternalImageFormatInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkExternalMemoryHandleTypeFlags handleType;
    }

    public struct VkExternalImageFormatProperties
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkExternalMemoryProperties externalMemoryProperties;
    }

    public struct VkPhysicalDeviceExternalBufferInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkBufferCreateFlags flags;
        public VkBufferUsageFlags usage;
        public VkExternalMemoryHandleTypeFlags handleType;
    }

    public struct VkExternalBufferProperties
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkExternalMemoryProperties externalMemoryProperties;
    }

    public struct VkPhysicalDeviceIDProperties
    {
        public VkStructureType sType;
        public IntPtr pNext;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = VK.VK_UUID_SIZE)]
        public byte[] deviceUUID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = VK.VK_UUID_SIZE)]
        public byte[] driverUUID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = VK.VK_LUID_SIZE)]
        public byte[] deviceLUID;
        public uint deviceNodeMask;
        public Bool32 deviceLUIDValid;
    }

    public struct VkExternalMemoryImageCreateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkExternalMemoryHandleTypeFlags handleTypes;
    }

    public struct VkExternalMemoryBufferCreateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkExternalMemoryHandleTypeFlags handleTypes;
    }

    public struct VkExportMemoryAllocateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkExternalMemoryHandleTypeFlags handleTypes;
    }

    public struct VkPhysicalDeviceExternalFenceInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkExternalFenceHandleTypeFlags handleType;
    }

    public struct VkExternalFenceProperties
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkExternalFenceHandleTypeFlags exportFromImportedHandleTypes;
        public VkExternalFenceHandleTypeFlags compatibleHandleTypes;
        public VkExternalFenceFeatureFlags externalFenceFeatures;
    }

    public struct VkExportSemaphoreCreateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkExternalSemaphoreHandleTypeFlags handleTypes;
    }

    public struct VkPhysicalDeviceExternalSemaphoreInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkExternalSemaphoreHandleTypeFlags handleType;
    }

    public struct VkExternalSemaphoreProperties
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkExternalSemaphoreHandleTypeFlags exportFromImportedHandleTypes;
        public VkExternalSemaphoreHandleTypeFlags compatibleHandleTypes;
        public VkExternalSemaphoreFeatureFlags externalSemaphoreFeatures;
    }

    public struct VkPhysicalDeviceMaintenance3Properties
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint maxPerSetDescriptors;
        public ulong maxMemoryAllocationSize;
    }

    public struct VkDescriptorSetLayoutSupport
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 supported;
    }

    public struct VkPhysicalDeviceShaderDrawParametersFeatures
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 shaderDrawParameters;
    }

    //typedef VkPhysicalDeviceShaderDrawParametersFeatures VkPhysicalDeviceShaderDrawParameterFeatures;


    public struct VkPhysicalDeviceVulkan11Features
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 storageBuffer16BitAccess;
        public Bool32 uniformAndStorageBuffer16BitAccess;
        public Bool32 storagePushConstant16;
        public Bool32 storageInputOutput16;
        public Bool32 multiview;
        public Bool32 multiviewGeometryShader;
        public Bool32 multiviewTessellationShader;
        public Bool32 variablePointersStorageBuffer;
        public Bool32 variablePointers;
        public Bool32 protectedMemory;
        public Bool32 samplerYcbcrConversion;
        public Bool32 shaderDrawParameters;
    }

    public struct VkPhysicalDeviceVulkan11Properties
    {
        public VkStructureType sType;
        public IntPtr pNext;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = VK.VK_UUID_SIZE)]
        public byte[] deviceUUID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = VK.VK_UUID_SIZE)]
        public byte[] driverUUID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = VK.VK_LUID_SIZE)]
        public byte[] deviceLUID;
        public uint deviceNodeMask;
        public Bool32 deviceLUIDValid;
        public uint subgroupSize;
        public VkShaderStageFlags subgroupSupportedStages;
        public VkSubgroupFeatureFlags subgroupSupportedOperations;
        public Bool32 subgroupQuadOperationsInAllStages;
        public VkPointClippingBehavior pointClippingBehavior;
        public uint maxMultiviewViewCount;
        public uint maxMultiviewInstanceIndex;
        public Bool32 protectedNoFault;
        public uint maxPerSetDescriptors;
        public ulong maxMemoryAllocationSize;
    }

    public struct VkPhysicalDeviceVulkan12Features
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 samplerMirrorClampToEdge;
        public Bool32 drawIndirectCount;
        public Bool32 storageBuffer8BitAccess;
        public Bool32 uniformAndStorageBuffer8BitAccess;
        public Bool32 storagePushConstant8;
        public Bool32 shaderBufferInt64Atomics;
        public Bool32 shaderSharedInt64Atomics;
        public Bool32 shaderFloat16;
        public Bool32 shaderInt8;
        public Bool32 descriptorIndexing;
        public Bool32 shaderInputAttachmentArrayDynamicIndexing;
        public Bool32 shaderUniformTexelBufferArrayDynamicIndexing;
        public Bool32 shaderStorageTexelBufferArrayDynamicIndexing;
        public Bool32 shaderUniformBufferArrayNonUniformIndexing;
        public Bool32 shaderSampledImageArrayNonUniformIndexing;
        public Bool32 shaderStorageBufferArrayNonUniformIndexing;
        public Bool32 shaderStorageImageArrayNonUniformIndexing;
        public Bool32 shaderInputAttachmentArrayNonUniformIndexing;
        public Bool32 shaderUniformTexelBufferArrayNonUniformIndexing;
        public Bool32 shaderStorageTexelBufferArrayNonUniformIndexing;
        public Bool32 descriptorBindingUniformBufferUpdateAfterBind;
        public Bool32 descriptorBindingSampledImageUpdateAfterBind;
        public Bool32 descriptorBindingStorageImageUpdateAfterBind;
        public Bool32 descriptorBindingStorageBufferUpdateAfterBind;
        public Bool32 descriptorBindingUniformTexelBufferUpdateAfterBind;
        public Bool32 descriptorBindingStorageTexelBufferUpdateAfterBind;
        public Bool32 descriptorBindingUpdateUnusedWhilePending;
        public Bool32 descriptorBindingPartiallyBound;
        public Bool32 descriptorBindingVariableDescriptorCount;
        public Bool32 runtimeDescriptorArray;
        public Bool32 samplerFilterMinmax;
        public Bool32 scalarBlockLayout;
        public Bool32 imagelessFramebuffer;
        public Bool32 uniformBufferStandardLayout;
        public Bool32 shaderSubgroupExtendedTypes;
        public Bool32 separateDepthStencilLayouts;
        public Bool32 hostQueryReset;
        public Bool32 timelineSemaphore;
        public Bool32 bufferDeviceAddress;
        public Bool32 bufferDeviceAddressCaptureReplay;
        public Bool32 bufferDeviceAddressMultiDevice;
        public Bool32 vulkanMemoryModel;
        public Bool32 vulkanMemoryModelDeviceScope;
        public Bool32 vulkanMemoryModelAvailabilityVisibilityChains;
        public Bool32 shaderOutputViewportIndex;
        public Bool32 shaderOutputLayer;
        public Bool32 subgroupBroadcastDynamicId;
    }

    public struct VkConformanceVersion
    {
        public byte major;
        public byte minor;
        public byte subminor;
        public byte patch;
    }

    public struct VkPhysicalDeviceVulkan12Properties
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkDriverId driverID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = VK.VK_MAX_DRIVER_NAME_SIZE)]
        public string driverName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = VK.VK_MAX_DRIVER_INFO_SIZE)]
        public string driverInfo;
        public VkConformanceVersion conformanceVersion;
        public VkShaderFloatControlsIndependence denormBehaviorIndependence;
        public VkShaderFloatControlsIndependence roundingModeIndependence;
        public Bool32 shaderSignedZeroInfNanPreserveFloat16;
        public Bool32 shaderSignedZeroInfNanPreserveFloat32;
        public Bool32 shaderSignedZeroInfNanPreserveFloat64;
        public Bool32 shaderDenormPreserveFloat16;
        public Bool32 shaderDenormPreserveFloat32;
        public Bool32 shaderDenormPreserveFloat64;
        public Bool32 shaderDenormFlushToZeroFloat16;
        public Bool32 shaderDenormFlushToZeroFloat32;
        public Bool32 shaderDenormFlushToZeroFloat64;
        public Bool32 shaderRoundingModeRTEFloat16;
        public Bool32 shaderRoundingModeRTEFloat32;
        public Bool32 shaderRoundingModeRTEFloat64;
        public Bool32 shaderRoundingModeRTZFloat16;
        public Bool32 shaderRoundingModeRTZFloat32;
        public Bool32 shaderRoundingModeRTZFloat64;
        public uint maxUpdateAfterBindDescriptorsInAllPools;
        public Bool32 shaderUniformBufferArrayNonUniformIndexingNative;
        public Bool32 shaderSampledImageArrayNonUniformIndexingNative;
        public Bool32 shaderStorageBufferArrayNonUniformIndexingNative;
        public Bool32 shaderStorageImageArrayNonUniformIndexingNative;
        public Bool32 shaderInputAttachmentArrayNonUniformIndexingNative;
        public Bool32 robustBufferAccessUpdateAfterBind;
        public Bool32 quadDivergentImplicitLod;
        public uint maxPerStageDescriptorUpdateAfterBindSamplers;
        public uint maxPerStageDescriptorUpdateAfterBindUniformBuffers;
        public uint maxPerStageDescriptorUpdateAfterBindStorageBuffers;
        public uint maxPerStageDescriptorUpdateAfterBindSampledImages;
        public uint maxPerStageDescriptorUpdateAfterBindStorageImages;
        public uint maxPerStageDescriptorUpdateAfterBindInputAttachments;
        public uint maxPerStageUpdateAfterBindResources;
        public uint maxDescriptorSetUpdateAfterBindSamplers;
        public uint maxDescriptorSetUpdateAfterBindUniformBuffers;
        public uint maxDescriptorSetUpdateAfterBindUniformBuffersDynamic;
        public uint maxDescriptorSetUpdateAfterBindStorageBuffers;
        public uint maxDescriptorSetUpdateAfterBindStorageBuffersDynamic;
        public uint maxDescriptorSetUpdateAfterBindSampledImages;
        public uint maxDescriptorSetUpdateAfterBindStorageImages;
        public uint maxDescriptorSetUpdateAfterBindInputAttachments;
        public VkResolveModeFlags supportedDepthResolveModes;
        public VkResolveModeFlags supportedStencilResolveModes;
        public Bool32 independentResolveNone;
        public Bool32 independentResolve;
        public Bool32 filterMinmaxSingleComponentFormats;
        public Bool32 filterMinmaxImageComponentMapping;
        public ulong maxTimelineSemaphoreValueDifference;
        public VkSampleCountFlags framebufferIntegerColorSampleCounts;
    }

    public struct VkImageFormatListCreateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint viewFormatCount;
        public VkFormat[] pViewFormats;
    }

    public struct VkAttachmentDescription2
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkAttachmentDescriptionFlags flags;
        public VkFormat format;
        public VkSampleCountFlags samples;
        public VkAttachmentLoadOp loadOp;
        public VkAttachmentStoreOp storeOp;
        public VkAttachmentLoadOp stencilLoadOp;
        public VkAttachmentStoreOp stencilStoreOp;
        public VkImageLayout initialLayout;
        public VkImageLayout finalLayout;
    }

    public struct VkAttachmentReference2
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint attachment;
        public VkImageLayout layout;
        public VkImageAspectFlags aspectMask;
    }

    public struct VkSubpassDescription2
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkSubpassDescriptionFlags flags;
        public VkPipelineBindPoint pipelineBindPoint;
        public uint viewMask;
        public uint inputAttachmentCount;
        public VkAttachmentReference2[] pInputAttachments;
        public uint colorAttachmentCount;
        public VkAttachmentReference2[] pColorAttachments;
        public VkAttachmentReference2[] pResolveAttachments;
        public VkAttachmentReference2 pDepthStencilAttachment;
        public uint preserveAttachmentCount;
        public uint[] pPreserveAttachments;
    }

    public struct VkSubpassDependency2
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint srcSubpass;
        public uint dstSubpass;
        public VkPipelineStageFlags srcStageMask;
        public VkPipelineStageFlags dstStageMask;
        public VkAccessFlags srcAccessMask;
        public VkAccessFlags dstAccessMask;
        public VkDependencyFlags dependencyFlags;
        public int viewOffset;
    }

    public struct VkRenderPassCreateInfo2
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkRenderPassCreateFlags flags;
        public uint attachmentCount;
        public VkAttachmentDescription2[] pAttachments;
        public uint subpassCount;
        public VkSubpassDescription2[] pSubpasses;
        public uint dependencyCount;
        public VkSubpassDependency2[] pDependencies;
        public uint correlatedViewMaskCount;
        public uint[] pCorrelatedViewMasks;
    }

    public struct VkSubpassBeginInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkSubpassContents contents;
    }

    public struct VkSubpassEndInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
    }

    public struct VkPhysicalDevice8BitStorageFeatures
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 storageBuffer8BitAccess;
        public Bool32 uniformAndStorageBuffer8BitAccess;
        public Bool32 storagePushConstant8;
    }

    public struct VkPhysicalDeviceDriverProperties
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkDriverId driverID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = VK.VK_MAX_DRIVER_NAME_SIZE)]
        public string driverName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = VK.VK_MAX_DRIVER_INFO_SIZE)]
        public string driverInfo;
        public VkConformanceVersion conformanceVersion;
    }

    public struct VkPhysicalDeviceShaderAtomicInt64Features
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 shaderBufferInt64Atomics;
        public Bool32 shaderSharedInt64Atomics;
    }

    public struct VkPhysicalDeviceShaderFloat16Int8Features
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 shaderFloat16;
        public Bool32 shaderInt8;
    }

    public struct VkPhysicalDeviceFloatControlsProperties
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkShaderFloatControlsIndependence denormBehaviorIndependence;
        public VkShaderFloatControlsIndependence roundingModeIndependence;
        public Bool32 shaderSignedZeroInfNanPreserveFloat16;
        public Bool32 shaderSignedZeroInfNanPreserveFloat32;
        public Bool32 shaderSignedZeroInfNanPreserveFloat64;
        public Bool32 shaderDenormPreserveFloat16;
        public Bool32 shaderDenormPreserveFloat32;
        public Bool32 shaderDenormPreserveFloat64;
        public Bool32 shaderDenormFlushToZeroFloat16;
        public Bool32 shaderDenormFlushToZeroFloat32;
        public Bool32 shaderDenormFlushToZeroFloat64;
        public Bool32 shaderRoundingModeRTEFloat16;
        public Bool32 shaderRoundingModeRTEFloat32;
        public Bool32 shaderRoundingModeRTEFloat64;
        public Bool32 shaderRoundingModeRTZFloat16;
        public Bool32 shaderRoundingModeRTZFloat32;
        public Bool32 shaderRoundingModeRTZFloat64;
    }

    public struct VkDescriptorSetLayoutBindingFlagsCreateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint bindingCount;
        public VkDescriptorBindingFlags[] pBindingFlags;
    }

    public struct VkPhysicalDeviceDescriptorIndexingFeatures
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 shaderInputAttachmentArrayDynamicIndexing;
        public Bool32 shaderUniformTexelBufferArrayDynamicIndexing;
        public Bool32 shaderStorageTexelBufferArrayDynamicIndexing;
        public Bool32 shaderUniformBufferArrayNonUniformIndexing;
        public Bool32 shaderSampledImageArrayNonUniformIndexing;
        public Bool32 shaderStorageBufferArrayNonUniformIndexing;
        public Bool32 shaderStorageImageArrayNonUniformIndexing;
        public Bool32 shaderInputAttachmentArrayNonUniformIndexing;
        public Bool32 shaderUniformTexelBufferArrayNonUniformIndexing;
        public Bool32 shaderStorageTexelBufferArrayNonUniformIndexing;
        public Bool32 descriptorBindingUniformBufferUpdateAfterBind;
        public Bool32 descriptorBindingSampledImageUpdateAfterBind;
        public Bool32 descriptorBindingStorageImageUpdateAfterBind;
        public Bool32 descriptorBindingStorageBufferUpdateAfterBind;
        public Bool32 descriptorBindingUniformTexelBufferUpdateAfterBind;
        public Bool32 descriptorBindingStorageTexelBufferUpdateAfterBind;
        public Bool32 descriptorBindingUpdateUnusedWhilePending;
        public Bool32 descriptorBindingPartiallyBound;
        public Bool32 descriptorBindingVariableDescriptorCount;
        public Bool32 runtimeDescriptorArray;
    }

    public struct VkPhysicalDeviceDescriptorIndexingProperties
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint maxUpdateAfterBindDescriptorsInAllPools;
        public Bool32 shaderUniformBufferArrayNonUniformIndexingNative;
        public Bool32 shaderSampledImageArrayNonUniformIndexingNative;
        public Bool32 shaderStorageBufferArrayNonUniformIndexingNative;
        public Bool32 shaderStorageImageArrayNonUniformIndexingNative;
        public Bool32 shaderInputAttachmentArrayNonUniformIndexingNative;
        public Bool32 robustBufferAccessUpdateAfterBind;
        public Bool32 quadDivergentImplicitLod;
        public uint maxPerStageDescriptorUpdateAfterBindSamplers;
        public uint maxPerStageDescriptorUpdateAfterBindUniformBuffers;
        public uint maxPerStageDescriptorUpdateAfterBindStorageBuffers;
        public uint maxPerStageDescriptorUpdateAfterBindSampledImages;
        public uint maxPerStageDescriptorUpdateAfterBindStorageImages;
        public uint maxPerStageDescriptorUpdateAfterBindInputAttachments;
        public uint maxPerStageUpdateAfterBindResources;
        public uint maxDescriptorSetUpdateAfterBindSamplers;
        public uint maxDescriptorSetUpdateAfterBindUniformBuffers;
        public uint maxDescriptorSetUpdateAfterBindUniformBuffersDynamic;
        public uint maxDescriptorSetUpdateAfterBindStorageBuffers;
        public uint maxDescriptorSetUpdateAfterBindStorageBuffersDynamic;
        public uint maxDescriptorSetUpdateAfterBindSampledImages;
        public uint maxDescriptorSetUpdateAfterBindStorageImages;
        public uint maxDescriptorSetUpdateAfterBindInputAttachments;
    }

    public struct VkDescriptorSetVariableDescriptorCountAllocateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint descriptorSetCount;
        public uint[] pDescriptorCounts;
    }

    public struct VkDescriptorSetVariableDescriptorCountLayoutSupport
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint maxVariableDescriptorCount;
    }

    public struct VkSubpassDescriptionDepthStencilResolve
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkResolveModeFlags depthResolveMode;
        public VkResolveModeFlags stencilResolveMode;
        public VkAttachmentReference2 pDepthStencilResolveAttachment;
    }

    public struct VkPhysicalDeviceDepthStencilResolveProperties
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkResolveModeFlags supportedDepthResolveModes;
        public VkResolveModeFlags supportedStencilResolveModes;
        public Bool32 independentResolveNone;
        public Bool32 independentResolve;
    }

    public struct VkPhysicalDeviceScalarBlockLayoutFeatures
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 scalarBlockLayout;
    }

    public struct VkImageStencilUsageCreateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkImageUsageFlags stencilUsage;
    }

    public struct VkSamplerReductionModeCreateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        VkSamplerReductionMode reductionMode;
    }

    public struct VkPhysicalDeviceSamplerFilterMinmaxProperties
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 filterMinmaxSingleComponentFormats;
        public Bool32 filterMinmaxImageComponentMapping;
    }

    public struct VkPhysicalDeviceVulkanMemoryModelFeatures
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 vulkanMemoryModel;
        public Bool32 vulkanMemoryModelDeviceScope;
        public Bool32 vulkanMemoryModelAvailabilityVisibilityChains;
    }

    public struct VkPhysicalDeviceImagelessFramebufferFeatures
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 imagelessFramebuffer;
    }

    public struct VkFramebufferAttachmentImageInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkImageCreateFlags flags;
        public VkImageUsageFlags usage;
        public uint width;
        public uint height;
        public uint layerCount;
        public uint viewFormatCount;
        public VkFormat[] pViewFormats;
    }

    public struct VkFramebufferAttachmentsCreateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint attachmentImageInfoCount;
        VkFramebufferAttachmentImageInfo[] pAttachmentImageInfos;
    }

    public struct VkRenderPassAttachmentBeginInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint attachmentCount;
        public VkImageView[] pAttachments;
    }

    public struct VkPhysicalDeviceUniformBufferStandardLayoutFeatures
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 uniformBufferStandardLayout;
    }

    public struct VkPhysicalDeviceShaderSubgroupExtendedTypesFeatures
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 shaderSubgroupExtendedTypes;
    }

    public struct VkPhysicalDeviceSeparateDepthStencilLayoutsFeatures
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 separateDepthStencilLayouts;
    }

    public struct VkAttachmentReferenceStencilLayout
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkImageLayout stencilLayout;
    }

    public struct VkAttachmentDescriptionStencilLayout
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkImageLayout stencilInitialLayout;
        public VkImageLayout stencilFinalLayout;
    }

    public struct VkPhysicalDeviceHostQueryResetFeatures
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 hostQueryReset;
    }

    public struct VkPhysicalDeviceTimelineSemaphoreFeatures
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 timelineSemaphore;
    }

    public struct VkPhysicalDeviceTimelineSemaphoreProperties
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public ulong maxTimelineSemaphoreValueDifference;
    }

    public struct VkSemaphoreTypeCreateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkSemaphoreType semaphoreType;
        public ulong initialValue;
    }

    public struct VkTimelineSemaphoreSubmitInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint waitSemaphoreValueCount;
        public ulong[] pWaitSemaphoreValues;
        public uint signalSemaphoreValueCount;
        public ulong[] pSignalSemaphoreValues;
    }

    public struct VkSemaphoreWaitInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkSemaphoreWaitFlags flags;
        public uint semaphoreCount;
        public VkSemaphore[] pSemaphores;
        public ulong[] pValues;
    }

    public struct VkSemaphoreSignalInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkSemaphore semaphore;
        public ulong value;
    }

    public struct VkPhysicalDeviceBufferDeviceAddressFeatures
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 bufferDeviceAddress;
        public Bool32 bufferDeviceAddressCaptureReplay;
        public Bool32 bufferDeviceAddressMultiDevice;
    }

    public struct VkBufferDeviceAddressInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkBuffer buffer;
    }

    public struct VkBufferOpaqueCaptureAddressCreateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public ulong opaqueCaptureAddress;
    }

    public struct VkMemoryOpaqueCaptureAddressAllocateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public ulong opaqueCaptureAddress;
    }

    public struct VkDeviceMemoryOpaqueCaptureAddressInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkDeviceMemory memory;
    }


    public struct VkPhysicalDeviceVulkan13Features
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 robustImageAccess;
        public Bool32 inlineUniformBlock;
        public Bool32 descriptorBindingInlineUniformBlockUpdateAfterBind;
        public Bool32 pipelineCreationCacheControl;
        public Bool32 privateData;
        public Bool32 shaderDemoteToHelperInvocation;
        public Bool32 shaderTerminateInvocation;
        public Bool32 subgroupSizeControl;
        public Bool32 computeFullSubgroups;
        public Bool32 synchronization2;
        public Bool32 textureCompressionASTC_HDR;
        public Bool32 shaderZeroInitializeWorkgroupMemory;
        public Bool32 dynamicRendering;
        public Bool32 shaderIntegerDotProduct;
        public Bool32 maintenance4;
    }

    public struct VkPhysicalDeviceVulkan13Properties
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint minSubgroupSize;
        public uint maxSubgroupSize;
        public uint maxComputeWorkgroupSubgroups;
        public VkShaderStageFlags requiredSubgroupSizeStages;
        public uint maxInlineUniformBlockSize;
        public uint maxPerStageDescriptorInlineUniformBlocks;
        public uint maxPerStageDescriptorUpdateAfterBindInlineUniformBlocks;
        public uint maxDescriptorSetInlineUniformBlocks;
        public uint maxDescriptorSetUpdateAfterBindInlineUniformBlocks;
        public uint maxInlineUniformTotalSize;
        public Bool32 integerDotProduct8BitUnsignedAccelerated;
        public Bool32 integerDotProduct8BitSignedAccelerated;
        public Bool32 integerDotProduct8BitMixedSignednessAccelerated;
        public Bool32 integerDotProduct4x8BitPackedUnsignedAccelerated;
        public Bool32 integerDotProduct4x8BitPackedSignedAccelerated;
        public Bool32 integerDotProduct4x8BitPackedMixedSignednessAccelerated;
        public Bool32 integerDotProduct16BitUnsignedAccelerated;
        public Bool32 integerDotProduct16BitSignedAccelerated;
        public Bool32 integerDotProduct16BitMixedSignednessAccelerated;
        public Bool32 integerDotProduct32BitUnsignedAccelerated;
        public Bool32 integerDotProduct32BitSignedAccelerated;
        public Bool32 integerDotProduct32BitMixedSignednessAccelerated;
        public Bool32 integerDotProduct64BitUnsignedAccelerated;
        public Bool32 integerDotProduct64BitSignedAccelerated;
        public Bool32 integerDotProduct64BitMixedSignednessAccelerated;
        public Bool32 integerDotProductAccumulatingSaturating8BitUnsignedAccelerated;
        public Bool32 integerDotProductAccumulatingSaturating8BitSignedAccelerated;
        public Bool32 integerDotProductAccumulatingSaturating8BitMixedSignednessAccelerated;
        public Bool32 integerDotProductAccumulatingSaturating4x8BitPackedUnsignedAccelerated;
        public Bool32 integerDotProductAccumulatingSaturating4x8BitPackedSignedAccelerated;
        public Bool32 integerDotProductAccumulatingSaturating4x8BitPackedMixedSignednessAccelerated;
        public Bool32 integerDotProductAccumulatingSaturating16BitUnsignedAccelerated;
        public Bool32 integerDotProductAccumulatingSaturating16BitSignedAccelerated;
        public Bool32 integerDotProductAccumulatingSaturating16BitMixedSignednessAccelerated;
        public Bool32 integerDotProductAccumulatingSaturating32BitUnsignedAccelerated;
        public Bool32 integerDotProductAccumulatingSaturating32BitSignedAccelerated;
        public Bool32 integerDotProductAccumulatingSaturating32BitMixedSignednessAccelerated;
        public Bool32 integerDotProductAccumulatingSaturating64BitUnsignedAccelerated;
        public Bool32 integerDotProductAccumulatingSaturating64BitSignedAccelerated;
        public Bool32 integerDotProductAccumulatingSaturating64BitMixedSignednessAccelerated;
        public ulong storageTexelBufferOffsetAlignmentBytes;
        public Bool32 storageTexelBufferOffsetSingleTexelAlignment;
        public ulong uniformTexelBufferOffsetAlignmentBytes;
        public Bool32 uniformTexelBufferOffsetSingleTexelAlignment;
        public ulong maxBufferSize;
    }

    public struct VkPipelineCreationFeedback
    {
        public VkPipelineCreationFeedbackFlags flags;
        public ulong duration;
    }

    public struct VkPipelineCreationFeedbackCreateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPipelineCreationFeedback pPipelineCreationFeedback;
        public uint pipelineStageCreationFeedbackCount;
        public VkPipelineCreationFeedback[] pPipelineStageCreationFeedbacks;
    }

    public struct VkPhysicalDeviceShaderTerminateInvocationFeatures
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 shaderTerminateInvocation;
    }

    public struct VkPhysicalDeviceToolProperties
    {
        public VkStructureType sType;
        public IntPtr pNext;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = VK.VK_MAX_EXTENSION_NAME_SIZE)]
        public string name;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = VK.VK_MAX_EXTENSION_NAME_SIZE)]
        public string version;
        public VkToolPurposeFlags purposes;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = VK.VK_MAX_DESCRIPTION_SIZE)]
        public string description;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = VK.VK_MAX_EXTENSION_NAME_SIZE)]
        public string layer;
    }

    public struct VkPhysicalDeviceShaderDemoteToHelperInvocationFeatures
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 shaderDemoteToHelperInvocation;
    }

    public struct VkPhysicalDevicePrivateDataFeatures
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 privateData;
    }

    public struct VkDevicePrivateDataCreateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint privateDataSlotRequestCount;
    }

    public struct VkPrivateDataSlotCreateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPrivateDataSlotCreateFlags flags;
    }

    public struct VkPhysicalDevicePipelineCreationCacheControlFeatures
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 pipelineCreationCacheControl;
    }

    public struct VkMemoryBarrier2
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPipelineStageFlags2 srcStageMask;
        public VkAccessFlags2 srcAccessMask;
        public VkPipelineStageFlags2 dstStageMask;
        public VkAccessFlags2 dstAccessMask;
    }

    public struct VkBufferMemoryBarrier2
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPipelineStageFlags2 srcStageMask;
        public VkAccessFlags2 srcAccessMask;
        public VkPipelineStageFlags2 dstStageMask;
        public VkAccessFlags2 dstAccessMask;
        public uint srcQueueFamilyIndex;
        public uint dstQueueFamilyIndex;
        public VkBuffer buffer;
        public ulong offset;
        public ulong size;
    }

    public struct VkImageMemoryBarrier2
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPipelineStageFlags2 srcStageMask;
        public VkAccessFlags2 srcAccessMask;
        public VkPipelineStageFlags2 dstStageMask;
        public VkAccessFlags2 dstAccessMask;
        public VkImageLayout oldLayout;
        public VkImageLayout newLayout;
        public uint srcQueueFamilyIndex;
        public uint dstQueueFamilyIndex;
        public VkImage image;
        public VkImageSubresourceRange subresourceRange;
    }

    public struct VkDependencyInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkDependencyFlags dependencyFlags;
        public uint memoryBarrierCount;
        public VkMemoryBarrier2[] pMemoryBarriers;
        public uint bufferMemoryBarrierCount;
        public VkBufferMemoryBarrier2[] pBufferMemoryBarriers;
        public uint imageMemoryBarrierCount;
        public VkImageMemoryBarrier2[] pImageMemoryBarriers;
    }

    public struct VkSemaphoreSubmitInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkSemaphore semaphore;
        public ulong value;
        public VkPipelineStageFlags2 stageMask;
        public uint deviceIndex;
    }

    public struct VkCommandBufferSubmitInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkCommandBuffer commandBuffer;
        public uint deviceMask;
    }

    public struct VkSubmitInfo2
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkSubmitFlags flags;
        public uint waitSemaphoreInfoCount;
        public VkSemaphoreSubmitInfo[] pWaitSemaphoreInfos;
        public uint commandBufferInfoCount;
        public VkCommandBufferSubmitInfo[] pCommandBufferInfos;
        public uint signalSemaphoreInfoCount;
        public VkSemaphoreSubmitInfo[] pSignalSemaphoreInfos;
    }

    public struct VkPhysicalDeviceSynchronization2Features
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 synchronization2;
    }

    public struct VkPhysicalDeviceZeroInitializeWorkgroupMemoryFeatures
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 shaderZeroInitializeWorkgroupMemory;
    }

    public struct VkPhysicalDeviceImageRobustnessFeatures
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 robustImageAccess;
    }

    public struct VkBufferCopy2
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public ulong srcOffset;
        public ulong dstOffset;
        public ulong size;
    }

    public struct VkCopyBufferInfo2
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkBuffer srcBuffer;
        public VkBuffer dstBuffer;
        public uint regionCount;
        VkBufferCopy2[] pRegions;
    }

    public struct VkImageCopy2
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkImageSubresourceLayers srcSubresource;
        public VkOffset3D srcOffset;
        public VkImageSubresourceLayers dstSubresource;
        public VkOffset3D dstOffset;
        public VkExtent3D extent;
    }

    public struct VkCopyImageInfo2
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkImage srcImage;
        public VkImageLayout srcImageLayout;
        public VkImage dstImage;
        public VkImageLayout dstImageLayout;
        public uint regionCount;
        public VkImageCopy2[] pRegions;
    }

    public struct VkBufferImageCopy2
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public ulong bufferOffset;
        public uint bufferRowLength;
        public uint bufferImageHeight;
        public VkImageSubresourceLayers imageSubresource;
        public VkOffset3D imageOffset;
        public VkExtent3D imageExtent;
    }

    public struct VkCopyBufferToImageInfo2
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkBuffer srcBuffer;
        public VkImage dstImage;
        public VkImageLayout dstImageLayout;
        public uint regionCount;
        public VkBufferImageCopy2[] pRegions;
    }

    public struct VkCopyImageToBufferInfo2
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkImage srcImage;
        public VkImageLayout srcImageLayout;
        public VkBuffer dstBuffer;
        public uint regionCount;
        public VkBufferImageCopy2[] pRegions;
    }

    public struct VkImageBlit2
    {
        public VkStructureType sType;
        public IntPtr pNext;
        VkImageSubresourceLayers srcSubresource;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public VkOffset3D[] srcOffsets;
        VkImageSubresourceLayers dstSubresource;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public VkOffset3D[] dstOffsets;
    }

    public struct VkBlitImageInfo2
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkImage srcImage;
        public VkImageLayout srcImageLayout;
        public VkImage dstImage;
        public VkImageLayout dstImageLayout;
        public uint regionCount;
        public VkImageBlit2[] pRegions;
        public VkFilter filter;
    }

    public struct VkImageResolve2
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkImageSubresourceLayers srcSubresource;
        public VkOffset3D srcOffset;
        public VkImageSubresourceLayers dstSubresource;
        public VkOffset3D dstOffset;
        public VkExtent3D extent;
    }

    public struct VkResolveImageInfo2
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkImage srcImage;
        public VkImageLayout srcImageLayout;
        public VkImage dstImage;
        public VkImageLayout dstImageLayout;
        public uint regionCount;
        public VkImageResolve2[] pRegions;
    }

    public struct VkPhysicalDeviceSubgroupSizeControlFeatures
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 subgroupSizeControl;
        public Bool32 computeFullSubgroups;
    }

    public struct VkPhysicalDeviceSubgroupSizeControlProperties
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint minSubgroupSize;
        public uint maxSubgroupSize;
        public uint maxComputeWorkgroupSubgroups;
        public VkShaderStageFlags requiredSubgroupSizeStages;
    }

    public struct VkPipelineShaderStageRequiredSubgroupSizeCreateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint requiredSubgroupSize;
    }

    public struct VkPhysicalDeviceInlineUniformBlockFeatures
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 inlineUniformBlock;
        public Bool32 descriptorBindingInlineUniformBlockUpdateAfterBind;
    }

    public struct VkPhysicalDeviceInlineUniformBlockProperties
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint maxInlineUniformBlockSize;
        public uint maxPerStageDescriptorInlineUniformBlocks;
        public uint maxPerStageDescriptorUpdateAfterBindInlineUniformBlocks;
        public uint maxDescriptorSetInlineUniformBlocks;
        public uint maxDescriptorSetUpdateAfterBindInlineUniformBlocks;
    }

    public struct VkWriteDescriptorSetInlineUniformBlock
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint dataSize;
        public IntPtr pData;
    }

    public struct VkDescriptorPoolInlineUniformBlockCreateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint maxInlineUniformBlockBindings;
    }

    public struct VkPhysicalDeviceTextureCompressionASTCHDRFeatures
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 textureCompressionASTC_HDR;
    }

    public struct VkRenderingAttachmentInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkImageView imageView;
        public VkImageLayout imageLayout;
        public VkResolveModeFlags resolveMode;
        public VkImageView resolveImageView;
        public VkImageLayout resolveImageLayout;
        public VkAttachmentLoadOp loadOp;
        public VkAttachmentStoreOp storeOp;
        public VkClearValue clearValue;
    }

    public struct VkRenderingInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkRenderingFlags flags;
        public VkRect2D renderArea;
        public uint layerCount;
        public uint viewMask;
        public uint colorAttachmentCount;
        public VkRenderingAttachmentInfo[] pColorAttachments;
        public VkRenderingAttachmentInfo pDepthAttachment;
        public VkRenderingAttachmentInfo pStencilAttachment;
    }

    public struct VkPipelineRenderingCreateInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint viewMask;
        public uint colorAttachmentCount;
        public VkFormat[] pColorAttachmentFormats;
        public VkFormat depthAttachmentFormat;
        public VkFormat stencilAttachmentFormat;
    }

    public struct VkPhysicalDeviceDynamicRenderingFeatures
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 dynamicRendering;
    }

    public struct VkCommandBufferInheritanceRenderingInfo
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkRenderingFlags flags;
        public uint viewMask;
        public uint colorAttachmentCount;
        public VkFormat[] pColorAttachmentFormats;
        public VkFormat depthAttachmentFormat;
        public VkFormat stencilAttachmentFormat;
        public VkSampleCountFlags rasterizationSamples;
    }

    public struct VkPhysicalDeviceShaderIntegerDotProductFeatures
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 shaderIntegerDotProduct;
    }

    public struct VkPhysicalDeviceShaderIntegerDotProductProperties
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 integerDotProduct8BitUnsignedAccelerated;
        public Bool32 integerDotProduct8BitSignedAccelerated;
        public Bool32 integerDotProduct8BitMixedSignednessAccelerated;
        public Bool32 integerDotProduct4x8BitPackedUnsignedAccelerated;
        public Bool32 integerDotProduct4x8BitPackedSignedAccelerated;
        public Bool32 integerDotProduct4x8BitPackedMixedSignednessAccelerated;
        public Bool32 integerDotProduct16BitUnsignedAccelerated;
        public Bool32 integerDotProduct16BitSignedAccelerated;
        public Bool32 integerDotProduct16BitMixedSignednessAccelerated;
        public Bool32 integerDotProduct32BitUnsignedAccelerated;
        public Bool32 integerDotProduct32BitSignedAccelerated;
        public Bool32 integerDotProduct32BitMixedSignednessAccelerated;
        public Bool32 integerDotProduct64BitUnsignedAccelerated;
        public Bool32 integerDotProduct64BitSignedAccelerated;
        public Bool32 integerDotProduct64BitMixedSignednessAccelerated;
        public Bool32 integerDotProductAccumulatingSaturating8BitUnsignedAccelerated;
        public Bool32 integerDotProductAccumulatingSaturating8BitSignedAccelerated;
        public Bool32 integerDotProductAccumulatingSaturating8BitMixedSignednessAccelerated;
        public Bool32 integerDotProductAccumulatingSaturating4x8BitPackedUnsignedAccelerated;
        public Bool32 integerDotProductAccumulatingSaturating4x8BitPackedSignedAccelerated;
        public Bool32 integerDotProductAccumulatingSaturating4x8BitPackedMixedSignednessAccelerated;
        public Bool32 integerDotProductAccumulatingSaturating16BitUnsignedAccelerated;
        public Bool32 integerDotProductAccumulatingSaturating16BitSignedAccelerated;
        public Bool32 integerDotProductAccumulatingSaturating16BitMixedSignednessAccelerated;
        public Bool32 integerDotProductAccumulatingSaturating32BitUnsignedAccelerated;
        public Bool32 integerDotProductAccumulatingSaturating32BitSignedAccelerated;
        public Bool32 integerDotProductAccumulatingSaturating32BitMixedSignednessAccelerated;
        public Bool32 integerDotProductAccumulatingSaturating64BitUnsignedAccelerated;
        public Bool32 integerDotProductAccumulatingSaturating64BitSignedAccelerated;
        public Bool32 integerDotProductAccumulatingSaturating64BitMixedSignednessAccelerated;
    }

    public struct VkPhysicalDeviceTexelBufferAlignmentProperties
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public ulong storageTexelBufferOffsetAlignmentBytes;
        public Bool32 storageTexelBufferOffsetSingleTexelAlignment;
        public ulong uniformTexelBufferOffsetAlignmentBytes;
        public Bool32 uniformTexelBufferOffsetSingleTexelAlignment;
    }

    public struct VkFormatProperties3
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkFormatFeatureFlags2 linearTilingFeatures;
        public VkFormatFeatureFlags2 optimalTilingFeatures;
        public VkFormatFeatureFlags2 bufferFeatures;
    }

    public struct VkPhysicalDeviceMaintenance4Features
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 maintenance4;
    }

    public struct VkPhysicalDeviceMaintenance4Properties
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public ulong maxBufferSize;
    }

    public struct VkDeviceBufferMemoryRequirements
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkBufferCreateInfo pCreateInfo;
    }

    public struct VkDeviceImageMemoryRequirements
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkImageCreateInfo pCreateInfo;
        public VkImageAspectFlags planeAspect;
    }

    public struct VkSurfaceCapabilitiesKHR
    {
        public uint minImageCount;
        public uint maxImageCount;
        public VkExtent2D currentExtent;
        public VkExtent2D minImageExtent;
        public VkExtent2D maxImageExtent;
        public uint maxImageArrayLayers;
        public VkSurfaceTransformFlagsKHR supportedTransforms;
        public VkSurfaceTransformFlagBitsKHR currentTransform;
        public VkCompositeAlphaFlagsKHR supportedCompositeAlpha;
        public VkImageUsageFlags supportedUsageFlags;
    }

    public struct VkSurfaceFormatKHR
    {
        public VkFormat format;
        public VkColorSpaceKHR colorSpace;
    }

    public struct VkDisplayModeParametersKHR
    {
        public VkExtent2D visibleRegion;
        public uint refreshRate;
    }

    public struct VkDisplayModeCreateInfoKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkDisplayModeCreateFlagsKHR flags;
        public VkDisplayModeParametersKHR parameters;
    }

    public struct VkDisplayModePropertiesKHR
    {
        public VkDisplayModeKHR displayMode;
        public VkDisplayModeParametersKHR parameters;
    }

    public struct VkDisplayPlaneCapabilitiesKHR
    {
        public VkDisplayPlaneAlphaFlagsKHR supportedAlpha;
        public VkOffset2D minSrcPosition;
        public VkOffset2D maxSrcPosition;
        public VkExtent2D minSrcExtent;
        public VkExtent2D maxSrcExtent;
        public VkOffset2D minDstPosition;
        public VkOffset2D maxDstPosition;
        public VkExtent2D minDstExtent;
        public VkExtent2D maxDstExtent;
    }

    public struct VkDisplayPlanePropertiesKHR
    {
        public VkDisplayKHR currentDisplay;
        public uint currentStackIndex;
    }

    public struct VkDisplayPropertiesKHR
    {
        public VkDisplayKHR display;
        public string displayName;
        public VkExtent2D physicalDimensions;
        public VkExtent2D physicalResolution;
        public VkSurfaceTransformFlagsKHR supportedTransforms;
        public Bool32 planeReorderPossible;
        public Bool32 persistentContent;
    }

    public struct VkDisplaySurfaceCreateInfoKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkDisplaySurfaceCreateFlagsKHR flags;
        public VkDisplayModeKHR displayMode;
        public uint planeIndex;
        public uint planeStackIndex;
        public VkSurfaceTransformFlagBitsKHR transform;
        public float globalAlpha;
        public VkDisplayPlaneAlphaFlagsKHR alphaMode;
        public VkExtent2D imageExtent;
    }

    public struct VkDisplayPresentInfoKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkRect2D srcRect;
        public VkRect2D dstRect;
        public Bool32 persistent;
    }

    public struct VkRenderingFragmentShadingRateAttachmentInfoKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkImageView imageView;
        public VkImageLayout imageLayout;
        public VkExtent2D shadingRateAttachmentTexelSize;
    }

    public struct VkRenderingFragmentDensityMapAttachmentInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkImageView imageView;
        public VkImageLayout imageLayout;
    }

    public struct VkAttachmentSampleCountInfoAMD
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint colorAttachmentCount;
        public VkSampleCountFlags[] pColorAttachmentSamples;
        public VkSampleCountFlags depthStencilAttachmentSamples;
    }

    //typedef VkAttachmentSampleCountInfoAMD VkAttachmentSampleCountInfoNV;

    public struct VkMultiviewPerViewAttributesInfoNVX
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 perViewAttributes;
        public Bool32 perViewAttributesPositionXOnly;
    }

    public struct VkImportMemoryFdInfoKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkExternalMemoryHandleTypeFlags handleType;
        public int fd;
    }

    public struct VkMemoryFdPropertiesKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint memoryTypeBits;
    }

    public struct VkMemoryGetFdInfoKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkDeviceMemory memory;
        public VkExternalMemoryHandleTypeFlags handleType;
    }

    public struct VkImportSemaphoreFdInfoKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkSemaphore semaphore;
        public VkSemaphoreImportFlags flags;
        public VkExternalSemaphoreHandleTypeFlags handleType;
        public int fd;
    }

    public struct VkSemaphoreGetFdInfoKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkSemaphore semaphore;
        public VkExternalSemaphoreHandleTypeFlags handleType;
    }

    public struct VkPhysicalDevicePushDescriptorPropertiesKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint maxPushDescriptors;
    }
    public struct VkRectLayerKHR
    {
        public VkOffset2D offset;
        public VkExtent2D extent;
        public uint layer;
    }

    public struct VkPresentRegionKHR
    {
        public uint rectangleCount;
        public VkRectLayerKHR[] pRectangles;
    }

    public struct VkPresentRegionsKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint swapchainCount;
        public VkPresentRegionKHR[] pRegions;
    }

    public struct VkSharedPresentSurfaceCapabilitiesKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkImageUsageFlags sharedPresentSupportedUsageFlags;
    }

    public struct VkImportFenceFdInfoKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkFence fence;
        public VkFenceImportFlags flags;
        public VkExternalFenceHandleTypeFlags handleType;
        public int fd;
    }

    public struct VkFenceGetFdInfoKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkFence fence;
        public VkExternalFenceHandleTypeFlags handleType;
    }

    public struct VkPhysicalDevicePerformanceQueryFeaturesKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 performanceCounterQueryPools;
        public Bool32 performanceCounterMultipleQueryPools;
    }

    public struct VkPhysicalDevicePerformanceQueryPropertiesKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 allowCommandBufferQueryCopies;
    }

    public struct VkPerformanceCounterKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPerformanceCounterUnitKHR unit;
        public VkPerformanceCounterScopeKHR scope;
        public VkPerformanceCounterStorageKHR storage;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = VK.VK_UUID_SIZE)]
        public byte[] uuid;
    }

    public struct VkPerformanceCounterDescriptionKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPerformanceCounterDescriptionFlagsKHR flags;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = VK.VK_MAX_DESCRIPTION_SIZE)]
        public string name;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = VK.VK_MAX_DESCRIPTION_SIZE)]
        public string category;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = VK.VK_MAX_DESCRIPTION_SIZE)]
        public string description;
    }

    public struct VkQueryPoolPerformanceCreateInfoKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint queueFamilyIndex;
        public uint counterIndexCount;
        public uint[] pCounterIndices;
    }

    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct VkPerformanceCounterResultKHR {
        [FieldOffset(0)]
        public int int32;
        [FieldOffset(0)]
        public long int64;
        [FieldOffset(0)]
        public uint uint32;
        [FieldOffset(0)]
        public ulong uint64;
        [FieldOffset(0)]
        public float float32;
        [FieldOffset(0)]
        public double float64;
    }

    public struct VkAcquireProfilingLockInfoKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkAcquireProfilingLockFlagsKHR flags;
        public ulong timeout;
    }

    public struct VkPerformanceQuerySubmitInfoKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint counterPassIndex;
    }

    public struct VkPhysicalDeviceSurfaceInfo2KHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkSurfaceKHR surface;
    }

    public struct VkSurfaceCapabilities2KHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkSurfaceCapabilitiesKHR surfaceCapabilities;
    }

    public struct VkSurfaceFormat2KHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkSurfaceFormatKHR surfaceFormat;
    }
    public struct VkDisplayProperties2KHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkDisplayPropertiesKHR displayProperties;
    }

    public struct VkDisplayPlaneProperties2KHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkDisplayPlanePropertiesKHR displayPlaneProperties;
    }

    public struct VkDisplayModeProperties2KHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkDisplayModePropertiesKHR displayModeProperties;
    }

    public struct VkDisplayPlaneInfo2KHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkDisplayModeKHR mode;
        public uint planeIndex;
    }

    public struct VkDisplayPlaneCapabilities2KHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkDisplayPlaneCapabilitiesKHR capabilities;
    }


    public struct VkPhysicalDeviceShaderClockFeaturesKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 shaderSubgroupClock;
        public Bool32 shaderDeviceClock;
    }

    public struct VkDeviceQueueGlobalPriorityCreateInfoKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkQueueGlobalPriorityKHR globalPriority;
    }

    public struct VkPhysicalDeviceGlobalPriorityQueryFeaturesKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 globalPriorityQuery;
    }

    public struct VkQueueFamilyGlobalPriorityPropertiesKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint priorityCount;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = VK.VK_MAX_GLOBAL_PRIORITY_SIZE_KHR)]
        public VkQueueGlobalPriorityKHR[] priorities;
    }


    public struct VkFragmentShadingRateAttachmentInfoKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkAttachmentReference2 pFragmentShadingRateAttachment;
        public VkExtent2D shadingRateAttachmentTexelSize;
    }

    public struct VkPipelineFragmentShadingRateStateCreateInfoKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkExtent2D fragmentSize;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public VkFragmentShadingRateCombinerOpKHR[] combinerOps;
    }

    public struct VkPhysicalDeviceFragmentShadingRateFeaturesKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 pipelineFragmentShadingRate;
        public Bool32 primitiveFragmentShadingRate;
        public Bool32 attachmentFragmentShadingRate;
    }

    public struct VkPhysicalDeviceFragmentShadingRatePropertiesKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkExtent2D minFragmentShadingRateAttachmentTexelSize;
        public VkExtent2D maxFragmentShadingRateAttachmentTexelSize;
        public uint maxFragmentShadingRateAttachmentTexelSizeAspectRatio;
        public Bool32 primitiveFragmentShadingRateWithMultipleViewports;
        public Bool32 layeredShadingRateAttachments;
        public Bool32 fragmentShadingRateNonTrivialCombinerOps;
        public VkExtent2D maxFragmentSize;
        public uint maxFragmentSizeAspectRatio;
        public uint maxFragmentShadingRateCoverageSamples;
        public VkSampleCountFlags maxFragmentShadingRateRasterizationSamples;
        public Bool32 fragmentShadingRateWithShaderDepthStencilWrites;
        public Bool32 fragmentShadingRateWithSampleMask;
        public Bool32 fragmentShadingRateWithShaderSampleMask;
        public Bool32 fragmentShadingRateWithConservativeRasterization;
        public Bool32 fragmentShadingRateWithFragmentShaderInterlock;
        public Bool32 fragmentShadingRateWithCustomSampleLocations;
        public Bool32 fragmentShadingRateStrictMultiplyCombiner;
    }

    public struct VkPhysicalDeviceFragmentShadingRateKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkSampleCountFlags sampleCounts;
        public VkExtent2D fragmentSize;
    }

    public struct VkSurfaceProtectedCapabilitiesKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 supportsProtected;
    }

    public struct VkPhysicalDevicePresentWaitFeaturesKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 presentWait;
    }

    public struct VkPhysicalDevicePipelineExecutablePropertiesFeaturesKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 pipelineExecutableInfo;
    }

    public struct VkPipelineInfoKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPipeline pipeline;
    }

    public struct VkPipelineExecutablePropertiesKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkShaderStageFlags stages;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = VK.VK_MAX_DESCRIPTION_SIZE)]
        public string name;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = VK.VK_MAX_DESCRIPTION_SIZE)]
        public string description;
        public uint subgroupSize;
    }

    public struct VkPipelineExecutableInfoKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPipeline pipeline;
        public uint executableIndex;
    }
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct VkPipelineExecutableStatisticValueKHR {
        [FieldOffset(0)]
        public Bool32    b32;
        [FieldOffset(0)]
        public long i64;
        [FieldOffset(0)]
        public ulong u64;
        [FieldOffset(0)]
        public double f64;
    }

    public struct VkPipelineExecutableStatisticKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = VK.VK_MAX_DESCRIPTION_SIZE)]
        public string name;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = VK.VK_MAX_DESCRIPTION_SIZE)]
        public string description;
        public VkPipelineExecutableStatisticFormatKHR format;
        public VkPipelineExecutableStatisticValueKHR value;
    }

    public struct VkPipelineExecutableInternalRepresentationKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = VK.VK_MAX_DESCRIPTION_SIZE)]
        public string name;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = VK.VK_MAX_DESCRIPTION_SIZE)]
        public string description;
        public Bool32 isText;
        public int dataSize;
        public IntPtr pData;
    }

    public struct VkPipelineLibraryCreateInfoKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint libraryCount;
        public VkPipeline[] pLibraries;
    }

    public struct VkPresentIdKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint swapchainCount;
        public ulong[] pPresentIds;
    }

    public struct VkPhysicalDevicePresentIdFeaturesKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 presentId;
    }


    public struct VkQueueFamilyCheckpointProperties2NV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPipelineStageFlags2 checkpointExecutionStageMask;
    }

    public struct VkCheckpointData2NV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPipelineStageFlags2 stage;
        public IntPtr pCheckpointMarker;
    }

    public struct VkPhysicalDeviceFragmentShaderBarycentricFeaturesKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 fragmentShaderBarycentric;
    }

    public struct VkPhysicalDeviceFragmentShaderBarycentricPropertiesKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 triStripVertexOrderIndependentOfProvokingVertex;
    }

    public struct VkPhysicalDeviceShaderSubgroupUniformControlFlowFeaturesKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 shaderSubgroupUniformControlFlow;
    }

    public struct VkPhysicalDeviceWorkgroupMemoryExplicitLayoutFeaturesKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 workgroupMemoryExplicitLayout;
        public Bool32 workgroupMemoryExplicitLayoutScalarBlockLayout;
        public Bool32 workgroupMemoryExplicitLayout8BitAccess;
        public Bool32 workgroupMemoryExplicitLayout16BitAccess;
    }
    public struct VkPhysicalDeviceRayTracingMaintenance1FeaturesKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 rayTracingMaintenance1;
        public Bool32 rayTracingPipelineTraceRaysIndirect2;
    }

    public struct VkTraceRaysIndirectCommand2KHR
    {
        public ulong raygenShaderRecordAddress;
        public ulong raygenShaderRecordSize;
        public ulong missShaderBindingTableAddress;
        public ulong missShaderBindingTableSize;
        public ulong missShaderBindingTableStride;
        public ulong hitShaderBindingTableAddress;
        public ulong hitShaderBindingTableSize;
        public ulong hitShaderBindingTableStride;
        public ulong callableShaderBindingTableAddress;
        public ulong callableShaderBindingTableSize;
        public ulong callableShaderBindingTableStride;
        public uint width;
        public uint height;
        public uint depth;
    }

    public struct VkDebugReportCallbackCreateInfoEXT
    {

        public delegate Bool32 PFN_vkDebugReportCallbackEXT(
            VkDebugReportFlagsEXT flags,
            VkDebugReportObjectTypeEXT objectType,
        ulong obj,
        int location,
        int messageCode,
        string pLayerPrefix,
        string pMessage,
        IntPtr pUserData);


        public VkStructureType sType;
        public IntPtr pNext;
        public VkDebugReportFlagsEXT flags;
        public PFN_vkDebugReportCallbackEXT pfnCallback;
        public IntPtr pUserData;
    }

    public struct VkPipelineRasterizationStateRasterizationOrderAMD
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkRasterizationOrderAMD rasterizationOrder;
    }

    public struct VkDebugMarkerObjectNameInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkDebugReportObjectTypeEXT objectType;
        public ulong obj;
        public string pObjectName;
    }

    public struct VkDebugMarkerObjectTagInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkDebugReportObjectTypeEXT objectType;
        public ulong obj;
        public ulong tagName;
        public int tagSize;
        public IntPtr pTag;
    }

    public struct VkDebugMarkerMarkerInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public string pMarkerName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] color;
    }

    public struct VkDedicatedAllocationImageCreateInfoNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 dedicatedAllocation;
    }

    public struct VkDedicatedAllocationBufferCreateInfoNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 dedicatedAllocation;
    }

    public struct VkDedicatedAllocationMemoryAllocateInfoNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkImage image;
        public VkBuffer buffer;
    }

    public struct VkPhysicalDeviceTransformFeedbackFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 transformFeedback;
        public Bool32 geometryStreams;
    }

    public struct VkPhysicalDeviceTransformFeedbackPropertiesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint maxTransformFeedbackStreams;
        public uint maxTransformFeedbackBuffers;
        public ulong maxTransformFeedbackBufferSize;
        public uint maxTransformFeedbackStreamDataSize;
        public uint maxTransformFeedbackBufferDataSize;
        public uint maxTransformFeedbackBufferDataStride;
        public Bool32 transformFeedbackQueries;
        public Bool32 transformFeedbackStreamsLinesTriangles;
        public Bool32 transformFeedbackRasterizationStreamSelect;
        public Bool32 transformFeedbackDraw;
    }

    public struct VkPipelineRasterizationStateStreamCreateInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPipelineRasterizationStateStreamCreateFlagsEXT flags;
        public uint rasterizationStream;
    }

    public struct VkCuModuleCreateInfoNVX
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public int dataSize;
        public IntPtr pData;
    }

    public struct VkCuFunctionCreateInfoNVX
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkCuModuleNVX module;
        public string pName;
    }

    public struct VkCuLaunchInfoNVX
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkCuFunctionNVX function;
        public uint gridDimX;
        public uint gridDimY;
        public uint gridDimZ;
        public uint blockDimX;
        public uint blockDimY;
        public uint blockDimZ;
        public uint sharedMemBytes;
        public int paramCount;
        public IntPtr[] pParams;
        public int extraCount;
        public IntPtr[] pExtras;
    }

    public struct VkImageViewHandleInfoNVX
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkImageView imageView;
        public VkDescriptorType descriptorType;
        public VkSampler sampler;
    }

    public struct VkImageViewAddressPropertiesNVX
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public ulong deviceAddress;
        public ulong size;
    }

    public struct VkTextureLODGatherFormatPropertiesAMD
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 supportsTextureGatherLODBiasAMD;
    }

    public struct VkShaderResourceUsageAMD
    {
        public uint numUsedVgprs;
        public uint numUsedSgprs;
        public uint ldsSizePerLocalWorkGroup;
        public int ldsUsageSizeInBytes;
        public int scratchMemUsageInBytes;
    }

    public struct VkShaderStatisticsInfoAMD
    {
        public VkShaderStageFlags shaderStageMask;
        public VkShaderResourceUsageAMD resourceUsage;
        public uint numPhysicalVgprs;
        public uint numPhysicalSgprs;
        public uint numAvailableVgprs;
        public uint numAvailableSgprs;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] computeWorkGroupSize;
    }

    public struct VkPhysicalDeviceCornerSampledImageFeaturesNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 cornerSampledImage;
    }

    public struct VkExternalImageFormatPropertiesNV
    {
        public VkImageFormatProperties imageFormatProperties;
        public VkExternalMemoryFeatureFlagsNV externalMemoryFeatures;
        public VkExternalMemoryHandleTypeFlagsNV exportFromImportedHandleTypes;
        public VkExternalMemoryHandleTypeFlagsNV compatibleHandleTypes;
    }

    public struct VkExternalMemoryImageCreateInfoNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkExternalMemoryHandleTypeFlagsNV handleTypes;
    }

    public struct VkExportMemoryAllocateInfoNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkExternalMemoryHandleTypeFlagsNV handleTypes;
    }

    public struct VkValidationFlagsEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint disabledValidationCheckCount;
        public VkValidationCheckEXT[] pDisabledValidationChecks;
    }

    public struct VkImageViewASTCDecodeModeEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkFormat decodeMode;
    }

    public struct VkPhysicalDeviceASTCDecodeFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 decodeModeSharedExponent;
    }

    public struct VkPhysicalDevicePipelineRobustnessFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 pipelineRobustness;
    }

    public struct VkPhysicalDevicePipelineRobustnessPropertiesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPipelineRobustnessBufferBehaviorEXT defaultRobustnessStorageBuffers;
        public VkPipelineRobustnessBufferBehaviorEXT defaultRobustnessUniformBuffers;
        public VkPipelineRobustnessBufferBehaviorEXT defaultRobustnessVertexInputs;
        public VkPipelineRobustnessImageBehaviorEXT defaultRobustnessImages;
    }

    public struct VkPipelineRobustnessCreateInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPipelineRobustnessBufferBehaviorEXT storageBuffers;
        public VkPipelineRobustnessBufferBehaviorEXT uniformBuffers;
        public VkPipelineRobustnessBufferBehaviorEXT vertexInputs;
        public VkPipelineRobustnessImageBehaviorEXT images;
    }

    public struct VkConditionalRenderingBeginInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkBuffer buffer;
        public ulong offset;
        public VkConditionalRenderingFlagsEXT flags;
    }

    public struct VkPhysicalDeviceConditionalRenderingFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 conditionalRendering;
        public Bool32 inheritedConditionalRendering;
    }

    public struct VkCommandBufferInheritanceConditionalRenderingInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 conditionalRenderingEnable;
    }

    public struct VkViewportWScalingNV
    {
        public float xcoeff;
        public float ycoeff;
    }

    public struct VkPipelineViewportWScalingStateCreateInfoNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 viewportWScalingEnable;
        public uint viewportCount;
        public VkViewportWScalingNV[] pViewportWScalings;
    }

    public struct VkSurfaceCapabilities2EXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint minImageCount;
        public uint maxImageCount;
        public VkExtent2D currentExtent;
        public VkExtent2D minImageExtent;
        public VkExtent2D maxImageExtent;
        public uint maxImageArrayLayers;
        public VkSurfaceTransformFlagsKHR supportedTransforms;
        public VkSurfaceTransformFlagBitsKHR currentTransform;
        public VkCompositeAlphaFlagsKHR supportedCompositeAlpha;
        public VkImageUsageFlags supportedUsageFlags;
        public VkSurfaceCounterFlagsEXT supportedSurfaceCounters;
    }

    public struct VkDisplayPowerInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkDisplayPowerStateEXT powerState;
    }

    public struct VkDeviceEventInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkDeviceEventTypeEXT deviceEvent;
    }

    public struct VkDisplayEventInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkDisplayEventTypeEXT displayEvent;
    }

    public struct VkSwapchainCounterCreateInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkSurfaceCounterFlagsEXT surfaceCounters;
    }

    public struct VkRefreshCycleDurationGOOGLE
    {
        public ulong refreshDuration;
    }

    public struct VkPastPresentationTimingGOOGLE
    {
        public uint presentID;
        public ulong desiredPresentTime;
        public ulong actualPresentTime;
        public ulong earliestPresentTime;
        public ulong presentMargin;
    }

    public struct VkPresentTimeGOOGLE
    {
        public uint presentID;
        public ulong desiredPresentTime;
    }

    public struct VkPresentTimesInfoGOOGLE
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint swapchainCount;
        public VkPresentTimeGOOGLE[] pTimes;
    }

    public struct VkPhysicalDeviceMultiviewPerViewAttributesPropertiesNVX
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 perViewPositionAllComponents;
    }


    public struct VkViewportSwizzleNV
    {
        public VkViewportCoordinateSwizzleNV x;
        public VkViewportCoordinateSwizzleNV y;
        public VkViewportCoordinateSwizzleNV z;
        public VkViewportCoordinateSwizzleNV w;
    }

    public struct VkPipelineViewportSwizzleStateCreateInfoNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkViewportCoordinateSwizzleNV flags;
        public uint viewportCount;
        public VkViewportSwizzleNV[] pViewportSwizzles;
    }

    public struct VkPhysicalDeviceDiscardRectanglePropertiesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint maxDiscardRectangles;
    }

    public struct VkPipelineDiscardRectangleStateCreateInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPipelineDiscardRectangleStateCreateFlagsEXT flags;
        public VkDiscardRectangleModeEXT discardRectangleMode;
        public uint discardRectangleCount;
        public VkRect2D[] pDiscardRectangles;
    }

    public struct VkPhysicalDeviceConservativeRasterizationPropertiesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public float primitiveOverestimationSize;
        public float maxExtraPrimitiveOverestimationSize;
        public float extraPrimitiveOverestimationSizeGranularity;
        public Bool32 primitiveUnderestimation;
        public Bool32 conservativePointAndLineRasterization;
        public Bool32 degenerateTrianglesRasterized;
        public Bool32 degenerateLinesRasterized;
        public Bool32 fullyCoveredFragmentShaderInputVariable;
        public Bool32 conservativeRasterizationPostDepthCoverage;
    }

    public struct VkPipelineRasterizationConservativeStateCreateInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPipelineRasterizationConservativeStateCreateFlagsEXT flags;
        public VkConservativeRasterizationModeEXT conservativeRasterizationMode;
        public float extraPrimitiveOverestimationSize;
    }


    public struct VkPhysicalDeviceDepthClipEnableFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 depthClipEnable;
    }

    public struct VkPipelineRasterizationDepthClipStateCreateInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPipelineRasterizationDepthClipStateCreateFlagsEXT flags;
        public Bool32 depthClipEnable;
    }

    public struct VkXYColorEXT
    {
        public float x;
        public float y;
    }

    public struct VkHdrMetadataEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkXYColorEXT displayPrimaryRed;
        public VkXYColorEXT displayPrimaryGreen;
        public VkXYColorEXT displayPrimaryBlue;
        public VkXYColorEXT whitePoint;
        public float maxLuminance;
        public float minLuminance;
        public float maxContentLightLevel;
        public float maxFrameAverageLightLevel;
    }


    public struct VkDebugUtilsLabelEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public string pLabelName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] color;
    }

    public struct VkDebugUtilsObjectNameInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkObjectType objectType;
        public ulong objectHandle;
        public string pObjectName;
    }

    public struct VkDebugUtilsMessengerCallbackDataEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkDebugUtilsMessengerCallbackDataFlagsEXT flags;
        public string pMessageIdName;
        public int messageIdNumber;
        public string pMessage;
        public uint queueLabelCount;
        public VkDebugUtilsLabelEXT[] pQueueLabels;
        public uint cmdBufLabelCount;
        public VkDebugUtilsLabelEXT[] pCmdBufLabels;
        public uint objectCount;
        public VkDebugUtilsObjectNameInfoEXT[] pObjects;
    }


    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 1)]
    public struct VkDebugUtilsMessengerCreateInfoEXT : IVkStruct
    {
        //[MarshalAs(UnmanagedType.U4)]
        public VkStructureType sType = VkStructureType.VK_STRUCTURE_TYPE_DEBUG_UTILS_MESSENGER_CREATE_INFO_EXT;
        //[MarshalAs(UnmanagedType.LPArray, SizeParamIndex =1)]
        public IntPtr pNext = IntPtr.Zero;
        //[MarshalAs(UnmanagedType.U4)]
        public VkDebugUtilsMessengerCreateFlagsEXT flags = VkDebugUtilsMessengerCreateFlagsEXT.None;
        //[MarshalAs(UnmanagedType.U4)]
        public VkDebugUtilsMessageSeverityFlagsEXT messageSeverity = VkDebugUtilsMessageSeverityFlagsEXT.None;
        //[MarshalAs(UnmanagedType.U4)]
        public VkDebugUtilsMessageTypeFlagsEXT messageType = VkDebugUtilsMessageTypeFlagsEXT.VK_DEBUG_UTILS_MESSAGE_TYPE_GENERAL_BIT_EXT;
        //[MarshalAs(UnmanagedType.FunctionPtr)]
        public IntPtr pfnUserCallback = IntPtr.Zero; // PFN_vkDebugUtilsMessengerCallbackEXT_EmptyCallback;
        //public VK.PFN_vkDebugUtilsMessengerCallbackEXT pfnUserCallback = null; // PFN_vkDebugUtilsMessengerCallbackEXT_EmptyCallback;
        //[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)]
        public IntPtr pUserData = IntPtr.Zero;

        public VkDebugUtilsMessengerCreateInfoEXT() {
            //pfnUserCallback = PFN_vkDebugUtilsMessengerCallbackEXT_EmptyCallback;
        }

        //public static Bool32 PFN_vkDebugUtilsMessengerCallbackEXT_EmptyCallback(
        //VkDebugUtilsMessageSeverityFlagBitsEXT messageSeverity,
        //VkDebugUtilsMessageTypeFlagsEXT messageTypes,
        // VkDebugUtilsMessengerCallbackDataEXT pCallbackData,
        //IntPtr pUserData){
        //    return 0;
        //    }
    }

    public struct VkDebugUtilsObjectTagInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkObjectType objectType;
        public ulong objectHandle;
        public ulong tagName;
        public int tagSize;
        public IntPtr pTag;
    }

    public struct VkSampleLocationEXT
    {
        public float x;
        public float y;
    }

    public struct VkSampleLocationsInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkSampleCountFlags sampleLocationsPerPixel;
        public VkExtent2D sampleLocationGridSize;
        public uint sampleLocationsCount;
        public VkSampleLocationEXT[] pSampleLocations;
    }

    public struct VkAttachmentSampleLocationsEXT
    {
        public uint attachmentIndex;
        public VkSampleLocationsInfoEXT sampleLocationsInfo;
    }

    public struct VkSubpassSampleLocationsEXT
    {
        public uint subpassIndex;
        public VkSampleLocationsInfoEXT sampleLocationsInfo;
    }

    public struct VkRenderPassSampleLocationsBeginInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint attachmentInitialSampleLocationsCount;
        public VkAttachmentSampleLocationsEXT[] pAttachmentInitialSampleLocations;
        public uint postSubpassSampleLocationsCount;
        public VkSubpassSampleLocationsEXT[] pPostSubpassSampleLocations;
    }

    public struct VkPipelineSampleLocationsStateCreateInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 sampleLocationsEnable;
        public VkSampleLocationsInfoEXT sampleLocationsInfo;
    }

    public struct VkPhysicalDeviceSampleLocationsPropertiesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkSampleCountFlags sampleLocationSampleCounts;
        public VkExtent2D maxSampleLocationGridSize;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public float[] sampleLocationCoordinateRange;
        public uint sampleLocationSubPixelBits;
        public Bool32 variableSampleLocations;
    }

    public struct VkMultisamplePropertiesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkExtent2D maxSampleLocationGridSize;
    }

    public struct VkPhysicalDeviceBlendOperationAdvancedFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 advancedBlendCoherentOperations;
    }

    public struct VkPhysicalDeviceBlendOperationAdvancedPropertiesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint advancedBlendMaxColorAttachments;
        public Bool32 advancedBlendIndependentBlend;
        public Bool32 advancedBlendNonPremultipliedSrcColor;
        public Bool32 advancedBlendNonPremultipliedDstColor;
        public Bool32 advancedBlendCorrelatedOverlap;
        public Bool32 advancedBlendAllOperations;
    }

    public struct VkPipelineColorBlendAdvancedStateCreateInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 srcPremultiplied;
        public Bool32 dstPremultiplied;
        public VkBlendOverlapEXT blendOverlap;
    }

    public struct VkPipelineCoverageToColorStateCreateInfoNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPipelineCoverageToColorStateCreateFlagsNV flags;
        public Bool32 coverageToColorEnable;
        public uint coverageToColorLocation;
    }


    public struct VkPipelineCoverageModulationStateCreateInfoNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPipelineCoverageModulationStateCreateFlagsNV flags;
        public VkCoverageModulationModeNV coverageModulationMode;
        public Bool32 coverageModulationTableEnable;
        public uint coverageModulationTableCount;
        public float[] pCoverageModulationTable;
    }

    public struct VkPhysicalDeviceShaderSMBuiltinsPropertiesNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint shaderSMCount;
        public uint shaderWarpsPerSM;
    }

    public struct VkPhysicalDeviceShaderSMBuiltinsFeaturesNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 shaderSMBuiltins;
    }

    public struct VkDrmFormatModifierPropertiesEXT
    {
        public ulong drmFormatModifier;
        public uint drmFormatModifierPlaneCount;
        public VkFormatFeatureFlags drmFormatModifierTilingFeatures;
    }

    public struct VkDrmFormatModifierPropertiesListEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint drmFormatModifierCount;
        public VkDrmFormatModifierPropertiesEXT[] pDrmFormatModifierProperties;
    }

    public struct VkPhysicalDeviceImageDrmFormatModifierInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public ulong drmFormatModifier;
        public VkSharingMode sharingMode;
        public uint queueFamilyIndexCount;
        public uint[] pQueueFamilyIndices;
    }

    public struct VkImageDrmFormatModifierListCreateInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint drmFormatModifierCount;
        public ulong[] pDrmFormatModifiers;
    }

    public struct VkImageDrmFormatModifierExplicitCreateInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public ulong drmFormatModifier;
        public uint drmFormatModifierPlaneCount;
        public VkSubresourceLayout[] pPlaneLayouts;
    }

    public struct VkImageDrmFormatModifierPropertiesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public ulong drmFormatModifier;
    }

    /// <summary>
    /// The VkDrmFormatModifierProperties2EXT structure describes properties of a VkFormat 
    /// when that format is combined with a Linux DRM format modifier.
    /// These properties, like those of VkFormatProperties2, are independent of any 
    /// particular image.
    /// </summary>
    public struct VkDrmFormatModifierProperties2EXT
    {
        /// <summary>
        /// A Linux DRM format modifier.
        /// </summary>
        public ulong drmFormatModifier;
        /// <summary>
        /// The number of memory planes in any image created with format and drmFormatModifier. An image’s memory planecount is distinct from its format planecount, as explained below.
        /// </summary>
        public uint drmFormatModifierPlaneCount;
        /// <summary>
        /// A bitmask of VkFormatFeatureFlagBits2 that are supported by any image created with format and drmFormatModifier.
        /// </summary>
        public VkFormatFeatureFlags2 drmFormatModifierTilingFeatures;
    }

    public struct VkDrmFormatModifierPropertiesList2EXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint drmFormatModifierCount;
        public VkDrmFormatModifierProperties2EXT[] pDrmFormatModifierProperties;
    }


    public struct VkValidationCacheCreateInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkValidationCacheCreateFlagsEXT flags;
        public int initialDataSize;
        public IntPtr pInitialData;
    }

    public struct VkShaderModuleValidationCacheCreateInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkValidationCacheEXT validationCache;
    }

    public struct VkShadingRatePaletteNV
    {
        public uint shadingRatePaletteEntryCount;
        public VkShadingRatePaletteEntryNV[] pShadingRatePaletteEntries;
    }

    public struct VkPipelineViewportShadingRateImageStateCreateInfoNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 shadingRateImageEnable;
        public uint viewportCount;
        public VkShadingRatePaletteNV[] pShadingRatePalettes;
    }

    public struct VkPhysicalDeviceShadingRateImageFeaturesNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 shadingRateImage;
        public Bool32 shadingRateCoarseSampleOrder;
    }

    public struct VkPhysicalDeviceShadingRateImagePropertiesNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkExtent2D shadingRateTexelSize;
        public uint shadingRatePaletteSize;
        public uint shadingRateMaxCoarseSamples;
    }

    public struct VkCoarseSampleLocationNV
    {
        public uint pixelX;
        public uint pixelY;
        public uint sample;
    }

    public struct VkCoarseSampleOrderCustomNV
    {
        public VkShadingRatePaletteEntryNV shadingRate;
        public uint sampleCount;
        public uint sampleLocationCount;
        public VkCoarseSampleLocationNV[] pSampleLocations;
    }

    public struct VkPipelineViewportCoarseSampleOrderStateCreateInfoNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkCoarseSampleOrderTypeNV sampleOrderType;
        public uint customSampleOrderCount;
        public VkCoarseSampleOrderCustomNV[] pCustomSampleOrders;
    }

    public struct VkRayTracingShaderGroupCreateInfoNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkRayTracingShaderGroupTypeKHR type;
        public uint generalShader;
        public uint closestHitShader;
        public uint anyHitShader;
        public uint intersectionShader;
    }

    public struct VkRayTracingPipelineCreateInfoNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPipelineCreateFlags flags;
        public uint stageCount;
        public VkPipelineShaderStageCreateInfo[] pStages;
        public uint groupCount;
        public VkRayTracingShaderGroupCreateInfoNV[] pGroups;
        public uint maxRecursionDepth;
        public VkPipelineLayout layout;
        public VkPipeline basePipelineHandle;
        public int basePipelineIndex;
    }

    public struct VkGeometryTrianglesNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkBuffer vertexData;
        public ulong vertexOffset;
        public uint vertexCount;
        public ulong vertexStride;
        public VkFormat vertexFormat;
        public VkBuffer indexData;
        public ulong indexOffset;
        public uint indexCount;
        public VkIndexType indexType;
        public VkBuffer transformData;
        public ulong transformOffset;
    }

    public struct VkGeometryAABBNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkBuffer aabbData;
        public uint numAABBs;
        public uint stride;
        public ulong offset;
    }

    public struct VkGeometryDataNV
    {
        public VkGeometryTrianglesNV triangles;
        public VkGeometryAABBNV aabbs;
    }

    public struct VkGeometryNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkGeometryTypeKHR geometryType;
        public VkGeometryDataNV geometry;
        public VkGeometryFlagsKHR flags;
    }

    public struct VkAccelerationStructureInfoNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkAccelerationStructureTypeKHR  type;
        public VkBuildAccelerationStructureFlagsKHR  flags;
        public uint instanceCount;
        public uint geometryCount;
        public VkGeometryNV[] pGeometries;
    }

    public struct VkAccelerationStructureCreateInfoNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public ulong compactedSize;
        public VkAccelerationStructureInfoNV info;
    }

    public struct VkBindAccelerationStructureMemoryInfoNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkAccelerationStructureNV accelerationStructure;
        public VkDeviceMemory memory;
        public ulong memoryOffset;
        public uint deviceIndexCount;
        public uint[] pDeviceIndices;
    }

    public struct VkWriteDescriptorSetAccelerationStructureNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint accelerationStructureCount;
        public VkAccelerationStructureNV[] pAccelerationStructures;
    }

    public struct VkAccelerationStructureMemoryRequirementsInfoNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkAccelerationStructureMemoryRequirementsTypeNV type;
        public VkAccelerationStructureNV accelerationStructure;
    }

    public struct VkPhysicalDeviceRayTracingPropertiesNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint shaderGroupHandleSize;
        public uint maxRecursionDepth;
        public uint maxShaderGroupStride;
        public uint shaderGroupBaseAlignment;
        public ulong maxGeometryCount;
        public ulong maxInstanceCount;
        public ulong maxTriangleCount;
        public uint maxDescriptorSetAccelerationStructures;
    }

    public struct VkTransformMatrixKHR
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3*4)]
        public float[][] matrix;
}

    //typedef VkTransformMatrixKHR VkTransformMatrixNV;

    public struct VkAabbPositionsKHR
    {
        public float minX;
        public float minY;
        public float minZ;
        public float maxX;
        public float maxY;
        public float maxZ;
    }

    //typedef VkAabbPositionsKHR VkAabbPositionsNV;

    public struct VkAccelerationStructureInstanceKHR
    {
        /// <summary>
        /// A VkTransformMatrixKHR structure describing a transformation to be applied to the acceleration structure.
        /// </summary>
        public VkTransformMatrixKHR transform;
        /// <summary>
        /// A 24-bit user-specified index value accessible to ray shaders in the InstanceCustomIndexKHR built-in.
        /// </summary>
        public uint instanceCustomIndex;
        /// <summary>
        /// An 8-bit visibility mask for the geometry. The instance may only be hit if Cull Mask & instance.mask != 0
        /// </summary>
        public uint mask;
        /// <summary>
        /// A 24-bit offset used in calculating the hit shader binding table index.
        /// </summary>
        public uint instanceShaderBindingTableRecordOffset;
        /// <summary>
        /// An 8-bit mask of VkGeometryInstanceFlagBitsKHR values to apply to this instance.
        /// </summary>
        public VkGeometryInstanceFlagsKHR flags;
        /// <summary>
        /// either:
        /// 
        /// a device address containing the value obtained from vkGetAccelerationStructureDeviceAddressKHR or vkGetAccelerationStructureHandleNV(used by device operations which reference acceleration structures) or,
        /// 
        /// a VkAccelerationStructureKHR object (used by host operations which reference acceleration structures).
        /// </summary>
        public ulong accelerationStructureReference;
    }

    //typedef VkAccelerationStructureInstanceKHR VkAccelerationStructureInstanceNV;


    public struct VkPhysicalDeviceRepresentativeFragmentTestFeaturesNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 representativeFragmentTest;
    }

    public struct VkPipelineRepresentativeFragmentTestStateCreateInfoNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 representativeFragmentTestEnable;
    }

    public struct VkPhysicalDeviceImageViewImageFormatInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkImageViewType imageViewType;
    }

    public struct VkFilterCubicImageViewImageFormatPropertiesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 filterCubic;
        public Bool32 filterCubicMinmax;
    }

    public struct VkImportMemoryHostPointerInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkExternalMemoryHandleTypeFlags handleType;
        public IntPtr pHostPointer;
    }

    public struct VkMemoryHostPointerPropertiesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint memoryTypeBits;
    }

    public struct VkPhysicalDeviceExternalMemoryHostPropertiesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public ulong minImportedHostPointerAlignment;
    }

    public struct VkPipelineCompilerControlCreateInfoAMD
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPipelineCompilerControlFlagsAMD compilerControlFlags;
    }

    public struct VkCalibratedTimestampInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkTimeDomainEXT timeDomain;
    }

    public struct VkPhysicalDeviceShaderCorePropertiesAMD
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint shaderEngineCount;
        public uint shaderArraysPerEngineCount;
        public uint computeUnitsPerShaderArray;
        public uint simdPerComputeUnit;
        public uint wavefrontsPerSimd;
        public uint wavefrontSize;
        public uint sgprsPerSimd;
        public uint minSgprAllocation;
        public uint maxSgprAllocation;
        public uint sgprAllocationGranularity;
        public uint vgprsPerSimd;
        public uint minVgprAllocation;
        public uint maxVgprAllocation;
        public uint vgprAllocationGranularity;
    }

    public struct VkDeviceMemoryOverallocationCreateInfoAMD
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkMemoryOverallocationBehaviorAMD overallocationBehavior;
    }

    public struct VkPhysicalDeviceVertexAttributeDivisorPropertiesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint maxVertexAttribDivisor;
    }

    public struct VkVertexInputBindingDivisorDescriptionEXT
    {
        public uint binding;
        public uint divisor;
    }

    public struct VkPipelineVertexInputDivisorStateCreateInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint vertexBindingDivisorCount;
        public VkVertexInputBindingDivisorDescriptionEXT[] pVertexBindingDivisors;
    }

    public struct VkPhysicalDeviceVertexAttributeDivisorFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 vertexAttributeInstanceRateDivisor;
        public Bool32 vertexAttributeInstanceRateZeroDivisor;
    }



    public struct VkPhysicalDeviceComputeShaderDerivativesFeaturesNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 computeDerivativeGroupQuads;
        public Bool32 computeDerivativeGroupLinear;
    }

    public struct VkPhysicalDeviceMeshShaderFeaturesNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 taskShader;
        public Bool32 meshShader;
    }

    public struct VkPhysicalDeviceMeshShaderPropertiesNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint maxDrawMeshTasksCount;
        public uint maxTaskWorkGroupInvocations;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] maxTaskWorkGroupSize;
        public uint maxTaskTotalMemorySize;
        public uint maxTaskOutputCount;
        public uint maxMeshWorkGroupInvocations;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] maxMeshWorkGroupSize;
        public uint maxMeshTotalMemorySize;
        public uint maxMeshOutputVertices;
        public uint maxMeshOutputPrimitives;
        public uint maxMeshMultiviewViewCount;
        public uint meshOutputPerVertexGranularity;
        public uint meshOutputPerPrimitiveGranularity;
    }

    public struct VkDrawMeshTasksIndirectCommandNV
    {
        public uint taskCount;
        public uint firstTask;
    }

    public struct VkPhysicalDeviceShaderImageFootprintFeaturesNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 imageFootprint;
    }

    public struct VkPipelineViewportExclusiveScissorStateCreateInfoNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint exclusiveScissorCount;
        public VkRect2D[] pExclusiveScissors;
    }

    public struct VkQueueFamilyCheckpointPropertiesNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPipelineStageFlags checkpointExecutionStageMask;
    }

    public struct VkCheckpointDataNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPipelineStageFlags stage;
        public IntPtr pCheckpointMarker;
    }

    public struct VkPhysicalDeviceShaderIntegerFunctions2FeaturesINTEL
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 shaderIntegerFunctions2;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct VkPerformanceValueDataINTEL
    {
        [FieldOffset(0)]
        public uint value32;
        [FieldOffset(0)]
        public ulong value64;
        [FieldOffset(0)]
        public float valueFloat;
        [FieldOffset(0)]
        public Bool32 valueBool;
        [FieldOffset(0)]
        public string valueString;
    }

    public struct VkPerformanceValueINTEL
    {
        public VkPerformanceValueTypeINTEL type;
        public VkPerformanceValueDataINTEL data;
    }

    public struct VkInitializePerformanceApiInfoINTEL
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public IntPtr pUserData;
    }

    public struct VkQueryPoolPerformanceQueryCreateInfoINTEL
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkQueryPoolSamplingModeINTEL performanceCountersSampling;
    }

    //typedef VkQueryPoolPerformanceQueryCreateInfoINTEL VkQueryPoolCreateInfoINTEL;

    public struct VkPerformanceMarkerInfoINTEL
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public ulong marker;
    }

    public struct VkPerformanceStreamMarkerInfoINTEL
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint marker;
    }

    public struct VkPerformanceOverrideInfoINTEL
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPerformanceOverrideTypeINTEL type;
        public Bool32 enable;
        public ulong parameter;
    }

    public struct VkPerformanceConfigurationAcquireInfoINTEL
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPerformanceConfigurationTypeINTEL type;
    }

    public struct VkPhysicalDevicePCIBusInfoPropertiesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint pciDomain;
        public uint pciBus;
        public uint pciDevice;
        public uint pciFunction;
    }

    public struct VkDisplayNativeHdrSurfaceCapabilitiesAMD
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 localDimmingSupport;
    }

    public struct VkSwapchainDisplayNativeHdrCreateInfoAMD
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 localDimmingEnable;
    }

    public struct VkPhysicalDeviceFragmentDensityMapFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 fragmentDensityMap;
        public Bool32 fragmentDensityMapDynamic;
        public Bool32 fragmentDensityMapNonSubsampledImages;
    }

    public struct VkPhysicalDeviceFragmentDensityMapPropertiesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkExtent2D minFragmentDensityTexelSize;
        public VkExtent2D maxFragmentDensityTexelSize;
        public Bool32 fragmentDensityInvocations;
    }

    public struct VkRenderPassFragmentDensityMapCreateInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkAttachmentReference fragmentDensityMapAttachment;
    }

    public struct VkPhysicalDeviceShaderCoreProperties2AMD
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkShaderCorePropertiesFlagsAMD shaderCoreFeatures;
        public uint activeComputeUnitCount;
    }

    public struct VkPhysicalDeviceCoherentMemoryFeaturesAMD
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 deviceCoherentMemory;
    }

    public struct VkPhysicalDeviceShaderImageAtomicInt64FeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 shaderImageInt64Atomics;
        public Bool32 sparseImageInt64Atomics;
    }

    public struct VkPhysicalDeviceMemoryBudgetPropertiesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = VK.VK_MAX_MEMORY_HEAPS)]
        public ulong[] heapBudget;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = VK.VK_MAX_MEMORY_HEAPS)]
        public ulong[] heapUsage;
    }

    public struct VkPhysicalDeviceMemoryPriorityFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 memoryPriority;
    }

    public struct VkMemoryPriorityAllocateInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public float priority;
    }

    public struct VkPhysicalDeviceDedicatedAllocationImageAliasingFeaturesNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 dedicatedAllocationImageAliasing;
    }

    public struct VkPhysicalDeviceBufferDeviceAddressFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 bufferDeviceAddress;
        public Bool32 bufferDeviceAddressCaptureReplay;
        public Bool32 bufferDeviceAddressMultiDevice;
    }

    public struct VkBufferDeviceAddressCreateInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public ulong deviceAddress;
    }

    public struct VkValidationFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint enabledValidationFeatureCount;
        public VkValidationFeatureEnableEXT[] pEnabledValidationFeatures;
        public uint disabledValidationFeatureCount;
        public VkValidationFeatureDisableEXT[] pDisabledValidationFeatures;
    }

    public struct VkCooperativeMatrixPropertiesNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint MSize;
        public uint NSize;
        public uint KSize;
        public VkComponentTypeNV AType;
        public VkComponentTypeNV BType;
        public VkComponentTypeNV CType;
        public VkComponentTypeNV DType;
        public VkScopeNV scope;
    }

    public struct VkPhysicalDeviceCooperativeMatrixFeaturesNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 cooperativeMatrix;
        public Bool32 cooperativeMatrixRobustBufferAccess;
    }

    public struct VkPhysicalDeviceCooperativeMatrixPropertiesNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkShaderStageFlags cooperativeMatrixSupportedStages;
    }

    public struct VkPhysicalDeviceCoverageReductionModeFeaturesNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 coverageReductionMode;
    }

    public struct VkPipelineCoverageReductionStateCreateInfoNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPipelineCoverageReductionStateCreateFlagsNV flags;
        public VkCoverageReductionModeNV coverageReductionMode;
    }

    public struct VkFramebufferMixedSamplesCombinationNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkCoverageReductionModeNV coverageReductionMode;
        public VkSampleCountFlags rasterizationSamples;
        public VkSampleCountFlags depthStencilSamples;
        public VkSampleCountFlags colorSamples;
    }

    public struct VkPhysicalDeviceFragmentShaderInterlockFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 fragmentShaderSampleInterlock;
        public Bool32 fragmentShaderPixelInterlock;
        public Bool32 fragmentShaderShadingRateInterlock;
    }

    public struct VkPhysicalDeviceYcbcrImageArraysFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 ycbcrImageArrays;
    }

    public struct VkPhysicalDeviceProvokingVertexFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 provokingVertexLast;
        public Bool32 transformFeedbackPreservesProvokingVertex;
    }

    public struct VkPhysicalDeviceProvokingVertexPropertiesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 provokingVertexModePerPipeline;
        public Bool32 transformFeedbackPreservesTriangleFanProvokingVertex;
    }

    public struct VkPipelineRasterizationProvokingVertexStateCreateInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkProvokingVertexModeEXT provokingVertexMode;
    }


    public struct VkHeadlessSurfaceCreateInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkHeadlessSurfaceCreateFlagsEXT flags;
    }


    public struct VkPhysicalDeviceLineRasterizationFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 rectangularLines;
        public Bool32 bresenhamLines;
        public Bool32 smoothLines;
        public Bool32 stippledRectangularLines;
        public Bool32 stippledBresenhamLines;
        public Bool32 stippledSmoothLines;
    }

    public struct VkPhysicalDeviceLineRasterizationPropertiesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint lineSubPixelPrecisionBits;
    }

    public struct VkPipelineRasterizationLineStateCreateInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkLineRasterizationModeEXT lineRasterizationMode;
        public Bool32 stippledLineEnable;
        public uint lineStippleFactor;
        public ushort lineStipplePattern;
    }

    public struct VkPhysicalDeviceShaderAtomicFloatFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 shaderBufferFloat32Atomics;
        public Bool32 shaderBufferFloat32AtomicAdd;
        public Bool32 shaderBufferFloat64Atomics;
        public Bool32 shaderBufferFloat64AtomicAdd;
        public Bool32 shaderSharedFloat32Atomics;
        public Bool32 shaderSharedFloat32AtomicAdd;
        public Bool32 shaderSharedFloat64Atomics;
        public Bool32 shaderSharedFloat64AtomicAdd;
        public Bool32 shaderImageFloat32Atomics;
        public Bool32 shaderImageFloat32AtomicAdd;
        public Bool32 sparseImageFloat32Atomics;
        public Bool32 sparseImageFloat32AtomicAdd;
    }

    public struct VkPhysicalDeviceIndexTypeUint8FeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 indexTypeUint8;
    }

    public struct VkPhysicalDeviceExtendedDynamicStateFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 extendedDynamicState;
    }

    public struct VkPhysicalDeviceShaderAtomicFloat2FeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 shaderBufferFloat16Atomics;
        public Bool32 shaderBufferFloat16AtomicAdd;
        public Bool32 shaderBufferFloat16AtomicMinMax;
        public Bool32 shaderBufferFloat32AtomicMinMax;
        public Bool32 shaderBufferFloat64AtomicMinMax;
        public Bool32 shaderSharedFloat16Atomics;
        public Bool32 shaderSharedFloat16AtomicAdd;
        public Bool32 shaderSharedFloat16AtomicMinMax;
        public Bool32 shaderSharedFloat32AtomicMinMax;
        public Bool32 shaderSharedFloat64AtomicMinMax;
        public Bool32 shaderImageFloat32AtomicMinMax;
        public Bool32 sparseImageFloat32AtomicMinMax;
    }

    public struct VkPhysicalDeviceDeviceGeneratedCommandsPropertiesNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint maxGraphicsShaderGroupCount;
        public uint maxIndirectSequenceCount;
        public uint maxIndirectCommandsTokenCount;
        public uint maxIndirectCommandsStreamCount;
        public uint maxIndirectCommandsTokenOffset;
        public uint maxIndirectCommandsStreamStride;
        public uint minSequencesCountBufferOffsetAlignment;
        public uint minSequencesIndexBufferOffsetAlignment;
        public uint minIndirectCommandsBufferOffsetAlignment;
    }

    public struct VkPhysicalDeviceDeviceGeneratedCommandsFeaturesNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 deviceGeneratedCommands;
    }

    public struct VkGraphicsShaderGroupCreateInfoNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint stageCount;
        public VkPipelineShaderStageCreateInfo[] pStages;
        public VkPipelineVertexInputStateCreateInfo pVertexInputState;
        public VkPipelineTessellationStateCreateInfo pTessellationState;
    }

    public struct VkGraphicsPipelineShaderGroupsCreateInfoNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint groupCount;
        public VkGraphicsShaderGroupCreateInfoNV[] pGroups;
        public uint pipelineCount;
        public VkPipeline[] pPipelines;
    }

    public struct VkBindShaderGroupIndirectCommandNV
    {
        public uint groupIndex;
    }

    public struct VkBindIndexBufferIndirectCommandNV
    {
        public ulong bufferAddress;
        public uint size;
        public VkIndexType indexType;
    }

    public struct VkBindVertexBufferIndirectCommandNV
    {
        public ulong bufferAddress;
        public uint size;
        public uint stride;
    }

    public struct VkSetStateFlagsIndirectCommandNV
    {
        public uint data;
    }

    public struct VkIndirectCommandsStreamNV
    {
        public VkBuffer buffer;
        public ulong offset;
    }

    public struct VkIndirectCommandsLayoutTokenNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkIndirectCommandsTokenTypeNV tokenType;
        public uint stream;
        public uint offset;
        public uint vertexBindingUnit;
        public Bool32 vertexDynamicStride;
        public VkPipelineLayout pushconstantPipelineLayout;
        public VkShaderStageFlags pushconstantShaderStageFlags;
        public uint pushconstantOffset;
        public uint pushconstantSize;
        public VkIndirectStateFlagsNV indirectStateFlags;
        public uint indexTypeCount;
        public VkIndexType[] pIndexTypes;
        public uint[] pIndexTypeValues;
    }

    public struct VkIndirectCommandsLayoutCreateInfoNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkIndirectCommandsLayoutUsageFlagsNV flags;
        public VkPipelineBindPoint pipelineBindPoint;
        public uint tokenCount;
        public VkIndirectCommandsLayoutTokenNV[] pTokens;
        public uint streamCount;
        public uint[] pStreamStrides;
    }

    public struct VkGeneratedCommandsInfoNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPipelineBindPoint pipelineBindPoint;
        public VkPipeline pipeline;
        public VkIndirectCommandsLayoutNV indirectCommandsLayout;
        public uint streamCount;
        public VkIndirectCommandsStreamNV[] pStreams;
        public uint sequencesCount;
        public VkBuffer preprocessBuffer;
        public ulong preprocessOffset;
        public ulong preprocessSize;
        public VkBuffer sequencesCountBuffer;
        public ulong sequencesCountOffset;
        public VkBuffer sequencesIndexBuffer;
        public ulong sequencesIndexOffset;
    }

    public struct VkGeneratedCommandsMemoryRequirementsInfoNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPipelineBindPoint pipelineBindPoint;
        public VkPipeline pipeline;
        public VkIndirectCommandsLayoutNV indirectCommandsLayout;
        public uint maxSequencesCount;
    }

    public struct VkPhysicalDeviceInheritedViewportScissorFeaturesNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 inheritedViewportScissor2D;
    }

    public struct VkCommandBufferInheritanceViewportScissorInfoNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 viewportScissor2D;
        public uint viewportDepthCount;
        public VkViewport[] pViewportDepths;
    }

    public struct VkPhysicalDeviceTexelBufferAlignmentFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 texelBufferAlignment;
    }


    public struct VkRenderPassTransformBeginInfoQCOM
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkSurfaceTransformFlagBitsKHR transform;
    }

    public struct VkCommandBufferInheritanceRenderPassTransformInfoQCOM
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkSurfaceTransformFlagBitsKHR transform;
        public VkRect2D renderArea;
    }

    public struct VkPhysicalDeviceDeviceMemoryReportFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 deviceMemoryReport;
    }

    public struct VkDeviceMemoryReportCallbackDataEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkDeviceMemoryReportEventTypeEXT flags;
        public VkDeviceMemoryReportEventTypeEXT type;
        public ulong memoryObjectId;
        public ulong size;
        public VkObjectType objectType;
        public ulong objectHandle;
        public uint heapIndex;
    }


    public struct VkDeviceDeviceMemoryReportCreateInfoEXT
    {
        public delegate void PFN_vkDeviceMemoryReportCallbackEXT(
             VkDeviceMemoryReportCallbackDataEXT pCallbackData,
            IntPtr pUserData);

        public VkStructureType sType;
        public IntPtr pNext;
        public VkDeviceMemoryReportEventTypeEXT flags;
        public PFN_vkDeviceMemoryReportCallbackEXT pfnUserCallback;
        public IntPtr pUserData;
    }



    public struct VkPhysicalDeviceRobustness2FeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 robustBufferAccess2;
        public Bool32 robustImageAccess2;
        public Bool32 nullDescriptor;
    }

    public struct VkPhysicalDeviceRobustness2PropertiesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public ulong robustStorageBufferAccessSizeAlignment;
        public ulong robustUniformBufferAccessSizeAlignment;
    }

    public struct VkSamplerCustomBorderColorCreateInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkClearColorValue customBorderColor;
        public VkFormat format;
    }

    public struct VkPhysicalDeviceCustomBorderColorPropertiesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint maxCustomBorderColorSamplers;
    }

    public struct VkPhysicalDeviceCustomBorderColorFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 customBorderColors;
        public Bool32 customBorderColorWithoutFormat;
    }

    public struct VkPhysicalDevicePresentBarrierFeaturesNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 presentBarrier;
    }

    public struct VkSurfaceCapabilitiesPresentBarrierNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 presentBarrierSupported;
    }

    public struct VkSwapchainPresentBarrierCreateInfoNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 presentBarrierEnable;
    }

    public struct VkPhysicalDeviceDiagnosticsConfigFeaturesNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 diagnosticsConfig;
    }

    public struct VkDeviceDiagnosticsConfigCreateInfoNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkDeviceDiagnosticsConfigFlagsNV flags;
    }

    public struct VkPhysicalDeviceDescriptorBufferPropertiesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 combinedImageSamplerDescriptorSingleArray;
        public Bool32 bufferlessPushDescriptors;
        public Bool32 allowSamplerImageViewPostSubmitCreation;
        public ulong descriptorBufferOffsetAlignment;
        public uint maxDescriptorBufferBindings;
        public uint maxResourceDescriptorBufferBindings;
        public uint maxSamplerDescriptorBufferBindings;
        public uint maxEmbeddedImmutableSamplerBindings;
        public uint maxEmbeddedImmutableSamplers;
        public int bufferCaptureReplayDescriptorDataSize;
        public int imageCaptureReplayDescriptorDataSize;
        public int imageViewCaptureReplayDescriptorDataSize;
        public int samplerCaptureReplayDescriptorDataSize;
        public int accelerationStructureCaptureReplayDescriptorDataSize;
        public int samplerDescriptorSize;
        public int combinedImageSamplerDescriptorSize;
        public int sampledImageDescriptorSize;
        public int storageImageDescriptorSize;
        public int uniformTexelBufferDescriptorSize;
        public int robustUniformTexelBufferDescriptorSize;
        public int storageTexelBufferDescriptorSize;
        public int robustStorageTexelBufferDescriptorSize;
        public int uniformBufferDescriptorSize;
        public int robustUniformBufferDescriptorSize;
        public int storageBufferDescriptorSize;
        public int robustStorageBufferDescriptorSize;
        public int inputAttachmentDescriptorSize;
        public int accelerationStructureDescriptorSize;
        public ulong maxSamplerDescriptorBufferRange;
        public ulong maxResourceDescriptorBufferRange;
        public ulong samplerDescriptorBufferAddressSpaceSize;
        public ulong resourceDescriptorBufferAddressSpaceSize;
        public ulong descriptorBufferAddressSpaceSize;
    }

    public struct VkPhysicalDeviceDescriptorBufferDensityMapPropertiesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public int combinedImageSamplerDensityMapDescriptorSize;
    }

    public struct VkPhysicalDeviceDescriptorBufferFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 descriptorBuffer;
        public Bool32 descriptorBufferCaptureReplay;
        public Bool32 descriptorBufferImageLayoutIgnored;
        public Bool32 descriptorBufferPushDescriptors;
    }

    public struct VkDescriptorAddressInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public ulong address;
        public ulong range;
        public VkFormat format;
    }

    public struct VkDescriptorBufferBindingInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public ulong address;
        public VkBufferUsageFlags usage;
    }

    public struct VkDescriptorBufferBindingPushDescriptorBufferHandleEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkBuffer buffer;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct VkDescriptorDataEXT {
        [FieldOffset(0)]
        public VkSampler pSampler;
        [FieldOffset(0)]
        public VkDescriptorImageInfo pCombinedImageSampler;
        [FieldOffset(0)]
        public VkDescriptorImageInfo pInputAttachmentImage;
        [FieldOffset(0)]
        public VkDescriptorImageInfo pSampledImage;
        [FieldOffset(0)]
        public VkDescriptorImageInfo pStorageImage;
        [FieldOffset(0)]
        public VkDescriptorAddressInfoEXT pUniformTexelBuffer;
        [FieldOffset(0)]
        public VkDescriptorAddressInfoEXT pStorageTexelBuffer;
        [FieldOffset(0)]
        public VkDescriptorAddressInfoEXT pUniformBuffer;
        [FieldOffset(0)]
        public VkDescriptorAddressInfoEXT pStorageBuffer;
        [FieldOffset(0)]
        public ulong accelerationStructure;
    }

    public struct VkDescriptorGetInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkDescriptorType type;
        public VkDescriptorDataEXT data;
    }

    public struct VkBufferCaptureDescriptorDataInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkBuffer buffer;
    }

    public struct VkImageCaptureDescriptorDataInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkImage image;
    }

    public struct VkImageViewCaptureDescriptorDataInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkImageView imageView;
    }

    public struct VkSamplerCaptureDescriptorDataInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkSampler sampler;
    }

    public struct VkOpaqueCaptureDescriptorDataCreateInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public IntPtr opaqueCaptureDescriptorData;
    }

    public struct VkAccelerationStructureCaptureDescriptorDataInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkAccelerationStructureKHR accelerationStructure;
        public VkAccelerationStructureNV accelerationStructureNV;
    }

    public struct VkPhysicalDeviceGraphicsPipelineLibraryFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 graphicsPipelineLibrary;
    }

    public struct VkPhysicalDeviceGraphicsPipelineLibraryPropertiesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 graphicsPipelineLibraryFastLinking;
        public Bool32 graphicsPipelineLibraryIndependentInterpolationDecoration;
    }

    public struct VkGraphicsPipelineLibraryCreateInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkGraphicsPipelineLibraryFlagsEXT flags;
    }

    public struct VkPhysicalDeviceShaderEarlyAndLateFragmentTestsFeaturesAMD
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 shaderEarlyAndLateFragmentTests;
    }

    public struct VkPhysicalDeviceFragmentShadingRateEnumsFeaturesNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 fragmentShadingRateEnums;
        public Bool32 supersampleFragmentShadingRates;
        public Bool32 noInvocationFragmentShadingRates;
    }

    public struct VkPhysicalDeviceFragmentShadingRateEnumsPropertiesNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkSampleCountFlags maxFragmentShadingRateInvocationCount;
    }

    public struct VkPipelineFragmentShadingRateEnumStateCreateInfoNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkFragmentShadingRateTypeNV shadingRateType;
        public VkFragmentShadingRateNV shadingRate;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public VkFragmentShadingRateCombinerOpKHR[] combinerOps;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct VkDeviceOrHostAddressConstKHR
    {
        [FieldOffset(0)]
        public ulong deviceAddress;
        [FieldOffset(0)]
        public IntPtr hostAddress;
    }

    public struct VkAccelerationStructureGeometryMotionTrianglesDataNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkDeviceOrHostAddressConstKHR vertexData;
    }

    public struct VkAccelerationStructureMotionInfoNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint maxInstances;
        public VkAccelerationStructureMotionInfoFlagsNV flags;
    }

    public struct VkAccelerationStructureMatrixMotionInstanceNV
    {
        /// <summary>
        /// describes a transformation to be applied to the acceleration structure at time 0.
        /// </summary>
        public VkTransformMatrixKHR transformT0;
        /// <summary>
        /// describes a transformation to be applied to the acceleration structure at time 1.
        /// </summary>
        public VkTransformMatrixKHR transformT1;
        /// <summary>
        /// a 24-bit user-specified index value accessible to ray shaders in the InstanceCustomIndexKHR built-in.
        /// </summary>
        public uint instanceCustomIndex;
        /// <summary>
        /// an 8-bit visibility mask for the geometry. The instance may only be hit if Cull Mask & instance.mask != 0
        /// </summary>
        public uint mask;
        /// <summary>
        /// a 24-bit offset used in calculating the hit shader binding table index.
        /// </summary>
        public uint instanceShaderBindingTableRecordOffset;
        /// <summary>
        ///  an 8-bit mask of VkGeometryInstanceFlagBitsKHR values to apply to this instance.
        /// </summary>
        public VkGeometryInstanceFlagsKHR flags;
        /// <summary>
        /// either:
        /// 
        /// A device address containing the value obtained from vkGetAccelerationStructureDeviceAddressKHR or vkGetAccelerationStructureHandleNV(used by device operations which reference acceleration structures) or,
        /// 
        /// A VkAccelerationStructureKHR object (used by host operations which reference acceleration structures).
        /// </summary>
        public ulong accelerationStructureReference;
    }

    public struct VkSRTDataNV
    {
        public float sx;
        public float a;
        public float b;
        public float pvx;
        public float sy;
        public float c;
        public float pvy;
        public float sz;
        public float pvz;
        public float qx;
        public float qy;
        public float qz;
        public float qw;
        public float tx;
        public float ty;
        public float tz;
    }

    public struct VkAccelerationStructureSRTMotionInstanceNV
    {
        /// <summary>
        /// describes a transformation to be applied to the acceleration structure at time 0.
        /// </summary>
        public VkSRTDataNV transformT0;
        /// <summary>
        /// describes a transformation to be applied to the acceleration structure at time 1.
        /// </summary>
        public VkSRTDataNV transformT1;
        /// <summary>
        ///  A 24-bit user-specified index value accessible to ray shaders in the InstanceCustomIndexKHR built-in.
        /// </summary>
        public uint instanceCustomIndex;
        /// <summary>
        /// An 8-bit visibility mask for the geometry. The instance may only be hit if Cull Mask & instance.mask != 0
        /// </summary>
        public uint mask;
        /// <summary>
        /// A 24-bit offset used in calculating the hit shader binding table index.
        /// </summary>
        public uint instanceShaderBindingTableRecordOffset;
        /// <summary>
        /// An 8-bit mask of VkGeometryInstanceFlagBitsKHR values to apply to this instance.
        /// </summary>
        public VkGeometryInstanceFlagsKHR flags;
        /// <summary>
        /// either:
        ///
        /// a device address containing the value obtained from vkGetAccelerationStructureDeviceAddressKHR or vkGetAccelerationStructureHandleNV(used by device operations which reference acceleration structures) or,
        ///
        /// a VkAccelerationStructureKHR object (used by host operations which reference acceleration structures).
        /// </summary>
        public ulong accelerationStructureReference;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct VkAccelerationStructureMotionInstanceDataNV {
        [FieldOffset(0)]
        public VkAccelerationStructureInstanceKHR staticInstance;
        [FieldOffset(0)]
        public VkAccelerationStructureMatrixMotionInstanceNV matrixMotionInstance;
        [FieldOffset(0)]
        public VkAccelerationStructureSRTMotionInstanceNV srtMotionInstance;
    }

    public struct VkAccelerationStructureMotionInstanceNV
    {
        public VkAccelerationStructureMotionInstanceTypeNV type;
        public VkAccelerationStructureMotionInstanceFlagsNV flags;
        public VkAccelerationStructureMotionInstanceDataNV data;
    }

    public struct VkPhysicalDeviceRayTracingMotionBlurFeaturesNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 rayTracingMotionBlur;
        public Bool32 rayTracingMotionBlurPipelineTraceRaysIndirect;
    }

    public struct VkPhysicalDeviceYcbcr2Plane444FormatsFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 ycbcr2plane444Formats;
    }

    public struct VkPhysicalDeviceFragmentDensityMap2FeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 fragmentDensityMapDeferred;
    }

    public struct VkPhysicalDeviceFragmentDensityMap2PropertiesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 subsampledLoads;
        public Bool32 subsampledCoarseReconstructionEarlyAccess;
        public uint maxSubsampledArrayLayers;
        public uint maxDescriptorSetSubsampledSamplers;
    }

    public struct VkCopyCommandTransformInfoQCOM
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkSurfaceTransformFlagBitsKHR transform;
    }

    public struct VkPhysicalDeviceImageCompressionControlFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 imageCompressionControl;
    }

    public struct VkImageCompressionControlEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkImageCompressionFlagsEXT flags;
        public uint compressionControlPlaneCount;
        public VkImageCompressionFixedRateFlagsEXT[] pFixedRateFlags;
    }

    public struct VkSubresourceLayout2EXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkSubresourceLayout subresourceLayout;
    }

    public struct VkImageSubresource2EXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkImageSubresource imageSubresource;
    }

    public struct VkImageCompressionPropertiesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkImageCompressionFlagsEXT imageCompressionFlags;
        public VkImageCompressionFixedRateFlagsEXT imageCompressionFixedRateFlags;
    }

    public struct VkPhysicalDeviceAttachmentFeedbackLoopLayoutFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 attachmentFeedbackLoopLayout;
    }

    public struct VkPhysicalDevice4444FormatsFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 formatA4R4G4B4;
        public Bool32 formatA4B4G4R4;
    }

    public struct VkPhysicalDeviceFaultFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 deviceFault;
        public Bool32 deviceFaultVendorBinary;
    }

    public struct VkDeviceFaultCountsEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint addressInfoCount;
        public uint vendorInfoCount;
        public ulong vendorBinarySize;
    }

    public struct VkDeviceFaultAddressInfoEXT
    {
        public VkDeviceFaultAddressTypeEXT addressType;
        public ulong reportedAddress;
        public ulong addressPrecision;
    }

    public struct VkDeviceFaultVendorInfoEXT
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = VK.VK_MAX_DESCRIPTION_SIZE)]
        public string description;
        public ulong vendorFaultCode;
        public ulong vendorFaultData;
    }

    public struct VkDeviceFaultInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = VK.VK_MAX_DESCRIPTION_SIZE)]
        public string description;
        public VkDeviceFaultAddressInfoEXT[] pAddressInfos;
        public VkDeviceFaultVendorInfoEXT[] pVendorInfos;
        public IntPtr pVendorBinaryData;
    }

    public struct VkDeviceFaultVendorBinaryHeaderVersionOneEXT
    {
        public uint headerSize;
        public VkDeviceFaultVendorBinaryHeaderVersionEXT headerVersion;
        public uint vendorID;
        public uint deviceID;
        public uint driverVersion;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = VK.VK_UUID_SIZE)]
        public byte[] pipelineCacheUUID;
        public uint applicationNameOffset;
        public uint applicationVersion;
        public uint engineNameOffset;
    }

    public struct VkPhysicalDeviceRasterizationOrderAttachmentAccessFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 rasterizationOrderColorAttachmentAccess;
        public Bool32 rasterizationOrderDepthAttachmentAccess;
        public Bool32 rasterizationOrderStencilAttachmentAccess;
    }

    public struct VkPhysicalDeviceRGBA10X6FormatsFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 formatRgba10x6WithoutYCbCrSampler;
    }

    public struct VkPhysicalDeviceMutableDescriptorTypeFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 mutableDescriptorType;
    }

    public struct VkMutableDescriptorTypeListEXT
    {
        public uint descriptorTypeCount;
        public VkDescriptorType[] pDescriptorTypes;
    }

    public struct VkMutableDescriptorTypeCreateInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint mutableDescriptorTypeListCount;
        public VkMutableDescriptorTypeListEXT[] pMutableDescriptorTypeLists;
    }

    public struct VkPhysicalDeviceVertexInputDynamicStateFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 vertexInputDynamicState;
    }

    public struct VkVertexInputBindingDescription2EXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint binding;
        public uint stride;
        public VkVertexInputRate inputRate;
        public uint divisor;
    }

    public struct VkVertexInputAttributeDescription2EXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint location;
        public uint binding;
        public VkFormat format;
        public uint offset;
    }

    public struct VkPhysicalDeviceDrmPropertiesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 hasPrimary;
        public Bool32 hasRender;
        public long primaryMajor;
        public long primaryMinor;
        public long renderMajor;
        public long renderMinor;
    }

    public struct VkPhysicalDeviceAddressBindingReportFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 reportAddressBinding;
    }

    public struct VkDeviceAddressBindingCallbackDataEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkDeviceAddressBindingFlagsEXT flags;
        public ulong baseAddress;
        public ulong size;
        public VkDeviceAddressBindingTypeEXT bindingType;
    }

    public struct VkPhysicalDeviceDepthClipControlFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 depthClipControl;
    }

    public struct VkPipelineViewportDepthClipControlCreateInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 negativeOneToOne;
    }

    public struct VkPhysicalDevicePrimitiveTopologyListRestartFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 primitiveTopologyListRestart;
        public Bool32 primitiveTopologyPatchListRestart;
    }

    public struct VkSubpassShadingPipelineCreateInfoHUAWEI
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkRenderPass renderPass;
        public uint subpass;
    }

    public struct VkPhysicalDeviceSubpassShadingFeaturesHUAWEI
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 subpassShading;
    }

    public struct VkPhysicalDeviceSubpassShadingPropertiesHUAWEI
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint maxSubpassShadingWorkgroupSizeAspectRatio;
    }

    public struct VkPhysicalDeviceInvocationMaskFeaturesHUAWEI
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 invocationMask;
    }

    public struct VkMemoryGetRemoteAddressInfoNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkDeviceMemory memory;
        public VkExternalMemoryHandleTypeFlags handleType;
    }

    public struct VkPhysicalDeviceExternalMemoryRDMAFeaturesNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 externalMemoryRDMA;
    }

    public struct VkPipelinePropertiesIdentifierEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = VK.VK_UUID_SIZE)]
        public byte[] pipelineIdentifier;
    }

    public struct VkPhysicalDevicePipelinePropertiesFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 pipelinePropertiesIdentifier;
    }

    public struct VkPhysicalDeviceMultisampledRenderToSingleSampledFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 multisampledRenderToSingleSampled;
    }

    public struct VkSubpassResolvePerformanceQueryEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 optimal;
    }

    public struct VkMultisampledRenderToSingleSampledInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 multisampledRenderToSingleSampledEnable;
        public VkSampleCountFlags rasterizationSamples;
    }

    public struct VkPhysicalDeviceExtendedDynamicState2FeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 extendedDynamicState2;
        public Bool32 extendedDynamicState2LogicOp;
        public Bool32 extendedDynamicState2PatchControlPoints;
    }

    public struct VkPhysicalDeviceColorWriteEnableFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 colorWriteEnable;
    }

    public struct VkPipelineColorWriteCreateInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint attachmentCount;
        public uint[] /*bool*/ pColorWriteEnables;
    }

    public struct VkPhysicalDevicePrimitivesGeneratedQueryFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 primitivesGeneratedQuery;
        public Bool32 primitivesGeneratedQueryWithRasterizerDiscard;
        public Bool32 primitivesGeneratedQueryWithNonZeroStreams;
    }

    public struct VkPhysicalDeviceImageViewMinLodFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 minLod;
    }

    public struct VkImageViewMinLodCreateInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public float minLod;
    }

    public struct VkPhysicalDeviceMultiDrawFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 multiDraw;
    }

    public struct VkPhysicalDeviceMultiDrawPropertiesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint maxMultiDrawCount;
    }

    public struct VkMultiDrawInfoEXT
    {
        public uint firstVertex;
        public uint vertexCount;
    }

    public struct VkMultiDrawIndexedInfoEXT
    {
        public uint firstIndex;
        public uint indexCount;
        public int vertexOffset;
    }

    public struct VkPhysicalDeviceImage2DViewOf3DFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 image2DViewOf3D;
        public Bool32 sampler2DViewOf3D;
    }

    public struct VkMicromapUsageEXT
    {
        public uint count;
        public uint subdivisionLevel;
        public uint format;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct VkDeviceOrHostAddressKHR {
        [FieldOffset(0)]
        public ulong deviceAddress;
        [FieldOffset(0)]
        public IntPtr hostAddress;
    }

    public struct VkMicromapBuildInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkMicromapTypeEXT type;
        public VkBuildMicromapFlagsEXT flags;
        public VkBuildMicromapModeEXT mode;
        public VkMicromapEXT dstMicromap;
        public uint usageCountsCount;
        public VkMicromapUsageEXT[] pUsageCounts;
        [MarshalAs(UnmanagedType.LPArray)]
        public VkMicromapUsageEXT[] ppUsageCounts;
        public VkDeviceOrHostAddressConstKHR data;
        public VkDeviceOrHostAddressKHR scratchData;
        public VkDeviceOrHostAddressConstKHR triangleArray;
        public ulong triangleArrayStride;
    }

    public struct VkMicromapCreateInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkMicromapCreateFlagsEXT createFlags;
        public VkBuffer buffer;
        public ulong offset;
        public ulong size;
        public VkMicromapTypeEXT type;
        public ulong deviceAddress;
    }

    public struct VkPhysicalDeviceOpacityMicromapFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 micromap;
        public Bool32 micromapCaptureReplay;
        public Bool32 micromapHostCommands;
    }

    public struct VkPhysicalDeviceOpacityMicromapPropertiesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint maxOpacity2StateSubdivisionLevel;
        public uint maxOpacity4StateSubdivisionLevel;
    }

    public struct VkMicromapVersionInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext; 
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2*VK.VK_UUID_SIZE)]
        public byte[] pVersionData;
    }

    public struct VkCopyMicromapToMemoryInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkMicromapEXT src;
        public VkDeviceOrHostAddressKHR dst;
        public VkCopyMicromapModeEXT mode;
    }

    public struct VkCopyMemoryToMicromapInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkDeviceOrHostAddressConstKHR src;
        public VkMicromapEXT dst;
        public VkCopyMicromapModeEXT mode;
    }

    public struct VkCopyMicromapInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkMicromapEXT src;
        public VkMicromapEXT dst;
        public VkCopyMicromapModeEXT mode;
    }

    public struct VkMicromapBuildSizesInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public ulong micromapSize;
        public ulong buildScratchSize;
        public Bool32 discardable;
    }

    public struct VkAccelerationStructureTrianglesOpacityMicromapEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkIndexType indexType;
        public VkDeviceOrHostAddressConstKHR indexBuffer;
        public ulong indexStride;
        public uint baseTriangle;
        public uint usageCountsCount;
        public VkMicromapUsageEXT[] pUsageCounts;
        [MarshalAs(UnmanagedType.LPArray)]
        public VkMicromapUsageEXT[] ppUsageCounts;
        public VkMicromapEXT micromap;
    }

    public struct VkMicromapTriangleEXT
    {
        public uint dataOffset;
        public ushort subdivisionLevel;
        public ushort format;
    }

    public struct VkPhysicalDeviceBorderColorSwizzleFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 borderColorSwizzle;
        public Bool32 borderColorSwizzleFromImage;
    }

    public struct VkSamplerBorderColorComponentMappingCreateInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkComponentMapping components;
        public Bool32 srgb;
    }

    public struct VkPhysicalDevicePageableDeviceLocalMemoryFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 pageableDeviceLocalMemory;
    }

    public struct VkPhysicalDeviceDescriptorSetHostMappingFeaturesVALVE
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 descriptorSetHostMapping;
    }

    public struct VkDescriptorSetBindingReferenceVALVE
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkDescriptorSetLayout descriptorSetLayout;
        public uint binding;
    }

    public struct VkDescriptorSetLayoutHostMappingInfoVALVE
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public int descriptorOffset;
        public uint descriptorSize;
    }

    public struct VkPhysicalDeviceDepthClampZeroOneFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 depthClampZeroOne;
    }

    public struct VkPhysicalDeviceNonSeamlessCubeMapFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 nonSeamlessCubeMap;
    }

    public struct VkPhysicalDeviceFragmentDensityMapOffsetFeaturesQCOM
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 fragmentDensityMapOffset;
    }

    public struct VkPhysicalDeviceFragmentDensityMapOffsetPropertiesQCOM
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkExtent2D fragmentDensityOffsetGranularity;
    }

    public struct VkSubpassFragmentDensityMapOffsetEndInfoQCOM
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint fragmentDensityOffsetCount;
        public VkOffset2D[] pFragmentDensityOffsets;
    }

    public struct VkCopyMemoryIndirectCommandNV
    {
        public ulong srcAddress;
        public ulong dstAddress;
        public ulong size;
    }

    public struct VkCopyMemoryToImageIndirectCommandNV
    {
        public ulong srcAddress;
        public uint bufferRowLength;
        public uint bufferImageHeight;
        public VkImageSubresourceLayers imageSubresource;
        public VkOffset3D imageOffset;
        public VkExtent3D imageExtent;
    }

    public struct VkPhysicalDeviceCopyMemoryIndirectFeaturesNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 indirectCopy;
    }

    public struct VkPhysicalDeviceCopyMemoryIndirectPropertiesNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkQueueFlags supportedQueues;
    }

    public struct VkDecompressMemoryRegionNV
    {
        public ulong srcAddress;
        public ulong dstAddress;
        public ulong compressedSize;
        public ulong decompressedSize;
        public VkMemoryDecompressionMethodFlagsNV decompressionMethod;
    }

    public struct VkPhysicalDeviceMemoryDecompressionFeaturesNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 memoryDecompression;
    }

    public struct VkPhysicalDeviceMemoryDecompressionPropertiesNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkMemoryDecompressionMethodFlagsNV decompressionMethods;
        public ulong maxDecompressionIndirectCount;
    }

    public struct VkPhysicalDeviceLinearColorAttachmentFeaturesNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 linearColorAttachment;
    }

    public struct VkPhysicalDeviceImageCompressionControlSwapchainFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 imageCompressionControlSwapchain;
    }

    public struct VkImageViewSampleWeightCreateInfoQCOM
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkOffset2D filterCenter;
        public VkExtent2D filterSize;
        public uint numPhases;
    }

    public struct VkPhysicalDeviceImageProcessingFeaturesQCOM
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 textureSampleWeighted;
        public Bool32 textureBoxFilter;
        public Bool32 textureBlockMatch;
    }

    public struct VkPhysicalDeviceImageProcessingPropertiesQCOM
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint maxWeightFilterPhases;
        public VkExtent2D maxWeightFilterDimension;
        public VkExtent2D maxBlockMatchRegion;
        public VkExtent2D maxBoxFilterBlockSize;
    }

    public struct VkPhysicalDeviceExtendedDynamicState3FeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 extendedDynamicState3TessellationDomainOrigin;
        public Bool32 extendedDynamicState3DepthClampEnable;
        public Bool32 extendedDynamicState3PolygonMode;
        public Bool32 extendedDynamicState3RasterizationSamples;
        public Bool32 extendedDynamicState3SampleMask;
        public Bool32 extendedDynamicState3AlphaToCoverageEnable;
        public Bool32 extendedDynamicState3AlphaToOneEnable;
        public Bool32 extendedDynamicState3LogicOpEnable;
        public Bool32 extendedDynamicState3ColorBlendEnable;
        public Bool32 extendedDynamicState3ColorBlendEquation;
        public Bool32 extendedDynamicState3ColorWriteMask;
        public Bool32 extendedDynamicState3RasterizationStream;
        public Bool32 extendedDynamicState3ConservativeRasterizationMode;
        public Bool32 extendedDynamicState3ExtraPrimitiveOverestimationSize;
        public Bool32 extendedDynamicState3DepthClipEnable;
        public Bool32 extendedDynamicState3SampleLocationsEnable;
        public Bool32 extendedDynamicState3ColorBlendAdvanced;
        public Bool32 extendedDynamicState3ProvokingVertexMode;
        public Bool32 extendedDynamicState3LineRasterizationMode;
        public Bool32 extendedDynamicState3LineStippleEnable;
        public Bool32 extendedDynamicState3DepthClipNegativeOneToOne;
        public Bool32 extendedDynamicState3ViewportWScalingEnable;
        public Bool32 extendedDynamicState3ViewportSwizzle;
        public Bool32 extendedDynamicState3CoverageToColorEnable;
        public Bool32 extendedDynamicState3CoverageToColorLocation;
        public Bool32 extendedDynamicState3CoverageModulationMode;
        public Bool32 extendedDynamicState3CoverageModulationTableEnable;
        public Bool32 extendedDynamicState3CoverageModulationTable;
        public Bool32 extendedDynamicState3CoverageReductionMode;
        public Bool32 extendedDynamicState3RepresentativeFragmentTestEnable;
        public Bool32 extendedDynamicState3ShadingRateImageEnable;
    }

    public struct VkPhysicalDeviceExtendedDynamicState3PropertiesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 dynamicPrimitiveTopologyUnrestricted;
    }

    public struct VkColorBlendEquationEXT
    {
        public VkBlendFactor srcColorBlendFactor;
        public VkBlendFactor dstColorBlendFactor;
        public VkBlendOp colorBlendOp;
        public VkBlendFactor srcAlphaBlendFactor;
        public VkBlendFactor dstAlphaBlendFactor;
        public VkBlendOp alphaBlendOp;
    }

    public struct VkColorBlendAdvancedEXT
    {
        public VkBlendOp advancedBlendOp;
        public Bool32 srcPremultiplied;
        public Bool32 dstPremultiplied;
        public VkBlendOverlapEXT blendOverlap;
        public Bool32 clampResults;
    }

    public struct VkPhysicalDeviceSubpassMergeFeedbackFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 subpassMergeFeedback;
    }

    public struct VkRenderPassCreationControlEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 disallowMerging;
    }

    public struct VkRenderPassCreationFeedbackInfoEXT
    {
        public uint postMergeSubpassCount;
    }

    public struct VkRenderPassCreationFeedbackCreateInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkRenderPassCreationFeedbackInfoEXT pRenderPassFeedback;
    }

    public struct VkRenderPassSubpassFeedbackInfoEXT
    {
        public VkSubpassMergeStatusEXT subpassMergeStatus;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = VK.VK_MAX_DESCRIPTION_SIZE)]
        public string description;
        public uint postMergeIndex;
    }

    public struct VkRenderPassSubpassFeedbackCreateInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkRenderPassSubpassFeedbackInfoEXT pSubpassFeedback;
    }


    public struct VkDirectDriverLoadingInfoLUNARG
    {
        public delegate void PFN_vkGetInstanceProcAddr(VkInstance instance, string pName);

        public VkStructureType sType;
        public IntPtr pNext;
        public VkDirectDriverLoadingFlagsLUNARG flags;
        public PFN_vkGetInstanceProcAddr pfnGetInstanceProcAddr;
    }

    public struct VkDirectDriverLoadingListLUNARG
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkDirectDriverLoadingModeLUNARG mode;
        public uint driverCount;
        public VkDirectDriverLoadingInfoLUNARG[] pDrivers;
    }

    public struct VkPhysicalDeviceShaderModuleIdentifierFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 shaderModuleIdentifier;
    }

    public struct VkPhysicalDeviceShaderModuleIdentifierPropertiesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = VK.VK_UUID_SIZE)]
        public byte[] shaderModuleIdentifierAlgorithmUUID;
    }

    public struct VkPipelineShaderStageModuleIdentifierCreateInfoEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint identifierSize;
        public byte[] pIdentifier;
    }

    public struct VkShaderModuleIdentifierEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint identifierSize;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = VK.VK_MAX_SHADER_MODULE_IDENTIFIER_SIZE_EXT)]
        public byte[] identifier;
    }

    public struct VkPhysicalDeviceOpticalFlowFeaturesNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 opticalFlow;
    }

    public struct VkPhysicalDeviceOpticalFlowPropertiesNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkOpticalFlowGridSizeFlagsNV supportedOutputGridSizes;
        public VkOpticalFlowGridSizeFlagsNV supportedHintGridSizes;
        public Bool32 hintSupported;
        public Bool32 costSupported;
        public Bool32 bidirectionalFlowSupported;
        public Bool32 globalFlowSupported;
        public uint minWidth;
        public uint minHeight;
        public uint maxWidth;
        public uint maxHeight;
        public uint maxNumRegionsOfInterest;
    }

    public struct VkOpticalFlowImageFormatInfoNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkOpticalFlowUsageFlagsNV usage;
    }

    public struct VkOpticalFlowImageFormatPropertiesNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkFormat format;
    }

    public struct VkOpticalFlowSessionCreateInfoNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint width;
        public uint height;
        public VkFormat imageFormat;
        public VkFormat flowVectorFormat;
        public VkFormat costFormat;
        public VkOpticalFlowGridSizeFlagsNV outputGridSize;
        public VkOpticalFlowGridSizeFlagsNV hintGridSize;
        public VkOpticalFlowPerformanceLevelNV performanceLevel;
        public VkOpticalFlowSessionCreateFlagsNV flags;
    }

    public struct VkOpticalFlowSessionCreatePrivateDataInfoNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint id;
        public uint size;
        public IntPtr pPrivateData;
    }

    public struct VkOpticalFlowExecuteInfoNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkOpticalFlowExecuteFlagsNV flags;
        public uint regionCount;
        public VkRect2D[] pRegions;
    }

    public struct VkPhysicalDeviceLegacyDitheringFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 legacyDithering;
    }

    public struct VkPhysicalDevicePipelineProtectedAccessFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 pipelineProtectedAccess;
    }

    public struct VkPhysicalDeviceTilePropertiesFeaturesQCOM
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 tileProperties;
    }

    public struct VkTilePropertiesQCOM
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkExtent3D tileSize;
        public VkExtent2D apronSize;
        public VkOffset2D origin;
    }

    public struct VkPhysicalDeviceAmigoProfilingFeaturesSEC
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 amigoProfiling;
    }

    public struct VkAmigoProfilingSubmitInfoSEC
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public ulong firstDrawTimestamp;
        public ulong swapBufferTimestamp;
    }

    public struct VkPhysicalDeviceMultiviewPerViewViewportsFeaturesQCOM
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 multiviewPerViewViewports;
    }

    public struct VkPhysicalDeviceRayTracingInvocationReorderPropertiesNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkRayTracingInvocationReorderModeNV rayTracingInvocationReorderReorderingHint;
    }

    public struct VkPhysicalDeviceRayTracingInvocationReorderFeaturesNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 rayTracingInvocationReorder;
    }

    public struct VkPhysicalDeviceShaderCoreBuiltinsFeaturesARM
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 shaderCoreBuiltins;
    }

    public struct VkPhysicalDeviceShaderCoreBuiltinsPropertiesARM
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public ulong shaderCoreMask;
        public uint shaderCoreCount;
        public uint shaderWarpsPerCore;
    }

    public struct VkAccelerationStructureBuildRangeInfoKHR
    {
        public uint primitiveCount;
        public uint primitiveOffset;
        public uint firstVertex;
        public uint transformOffset;
    }

    public struct VkAccelerationStructureGeometryTrianglesDataKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkFormat vertexFormat;
        public VkDeviceOrHostAddressConstKHR vertexData;
        public ulong vertexStride;
        public uint maxVertex;
        public VkIndexType indexType;
        public VkDeviceOrHostAddressConstKHR indexData;
        public VkDeviceOrHostAddressConstKHR transformData;
    }

    public struct VkAccelerationStructureGeometryAabbsDataKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkDeviceOrHostAddressConstKHR data;
        public ulong stride;
    }

    public struct VkAccelerationStructureGeometryInstancesDataKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 arrayOfPointers;
        public VkDeviceOrHostAddressConstKHR data;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct VkAccelerationStructureGeometryDataKHR {
        [FieldOffset(0)]
        public VkAccelerationStructureGeometryTrianglesDataKHR triangles;
        [FieldOffset(0)]
        public VkAccelerationStructureGeometryAabbsDataKHR aabbs;
        [FieldOffset(0)]
        public VkAccelerationStructureGeometryInstancesDataKHR instances;
    }

    public struct VkAccelerationStructureGeometryKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkGeometryTypeKHR geometryType;
        public VkAccelerationStructureGeometryDataKHR geometry;
        public VkGeometryFlagsKHR flags;
    }

    public struct VkAccelerationStructureBuildGeometryInfoKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkAccelerationStructureTypeKHR type;
        public VkBuildAccelerationStructureFlagsKHR flags;
        public VkBuildAccelerationStructureModeKHR mode;
        public VkAccelerationStructureKHR srcAccelerationStructure;
        public VkAccelerationStructureKHR dstAccelerationStructure;
        public uint geometryCount;
        public VkAccelerationStructureGeometryKHR[] pGeometries;
        [MarshalAs(UnmanagedType.LPArray)]
        public VkAccelerationStructureGeometryKHR[] ppGeometries;
        public VkDeviceOrHostAddressKHR scratchData;
    }

    public struct VkAccelerationStructureCreateInfoKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkAccelerationStructureCreateFlagsKHR createFlags;
        public VkBuffer buffer;
        public ulong offset;
        public ulong size;
        public VkAccelerationStructureTypeKHR type;
        public ulong deviceAddress;
    }

    public struct VkWriteDescriptorSetAccelerationStructureKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint accelerationStructureCount;
        public VkAccelerationStructureKHR[] pAccelerationStructures;
    }

    public struct VkPhysicalDeviceAccelerationStructureFeaturesKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 accelerationStructure;
        public Bool32 accelerationStructureCaptureReplay;
        public Bool32 accelerationStructureIndirectBuild;
        public Bool32 accelerationStructureHostCommands;
        public Bool32 descriptorBindingAccelerationStructureUpdateAfterBind;
    }

    public struct VkPhysicalDeviceAccelerationStructurePropertiesKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public ulong maxGeometryCount;
        public ulong maxInstanceCount;
        public ulong maxPrimitiveCount;
        public uint maxPerStageDescriptorAccelerationStructures;
        public uint maxPerStageDescriptorUpdateAfterBindAccelerationStructures;
        public uint maxDescriptorSetAccelerationStructures;
        public uint maxDescriptorSetUpdateAfterBindAccelerationStructures;
        public uint minAccelerationStructureScratchOffsetAlignment;
    }

    public struct VkAccelerationStructureDeviceAddressInfoKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkAccelerationStructureKHR accelerationStructure;
    }

    public struct VkAccelerationStructureVersionInfoKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2 * VK.VK_UUID_SIZE)]
        public byte[] pVersionData;
    }

    public struct VkCopyAccelerationStructureToMemoryInfoKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkAccelerationStructureKHR src;
        public VkDeviceOrHostAddressKHR dst;
        public VkCopyAccelerationStructureModeKHR mode;
    }

    public struct VkCopyMemoryToAccelerationStructureInfoKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkDeviceOrHostAddressConstKHR src;
        public VkAccelerationStructureKHR dst;
        public VkCopyAccelerationStructureModeKHR mode;
    }

    public struct VkCopyAccelerationStructureInfoKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkAccelerationStructureKHR src;
        public VkAccelerationStructureKHR dst;
        public VkCopyAccelerationStructureModeKHR mode;
    }

    public struct VkAccelerationStructureBuildSizesInfoKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public ulong accelerationStructureSize;
        public ulong updateScratchSize;
        public ulong buildScratchSize;
    }

    public struct VkRayTracingShaderGroupCreateInfoKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkRayTracingShaderGroupTypeKHR type;
        public uint generalShader;
        public uint closestHitShader;
        public uint anyHitShader;
        public uint intersectionShader;
        public IntPtr pShaderGroupCaptureReplayHandle;
    }

    public struct VkRayTracingPipelineInterfaceCreateInfoKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint maxPipelineRayPayloadSize;
        public uint maxPipelineRayHitAttributeSize;
    }

    public struct VkRayTracingPipelineCreateInfoKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkPipelineCreateFlags flags;
        public uint stageCount;
        public VkPipelineShaderStageCreateInfo[] pStages;
        public uint groupCount;
        public VkRayTracingShaderGroupCreateInfoKHR[] pGroups;
        public uint maxPipelineRayRecursionDepth;
        public VkPipelineLibraryCreateInfoKHR pLibraryInfo;
        public VkRayTracingPipelineInterfaceCreateInfoKHR pLibraryInterface;
        public VkPipelineDynamicStateCreateInfo pDynamicState;
        public VkPipelineLayout layout;
        public VkPipeline basePipelineHandle;
        public int basePipelineIndex;
    }

    public struct VkPhysicalDeviceRayTracingPipelineFeaturesKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 rayTracingPipeline;
        public Bool32 rayTracingPipelineShaderGroupHandleCaptureReplay;
        public Bool32 rayTracingPipelineShaderGroupHandleCaptureReplayMixed;
        public Bool32 rayTracingPipelineTraceRaysIndirect;
        public Bool32 rayTraversalPrimitiveCulling;
    }

    public struct VkPhysicalDeviceRayTracingPipelinePropertiesKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint shaderGroupHandleSize;
        public uint maxRayRecursionDepth;
        public uint maxShaderGroupStride;
        public uint shaderGroupBaseAlignment;
        public uint shaderGroupHandleCaptureReplaySize;
        public uint maxRayDispatchInvocationCount;
        public uint shaderGroupHandleAlignment;
        public uint maxRayHitAttributeSize;
    }

    public struct VkStridedDeviceAddressRegionKHR
    {
        public ulong deviceAddress;
        public ulong stride;
        public ulong size;
    }

    public struct VkTraceRaysIndirectCommandKHR
    {
        public uint width;
        public uint height;
        public uint depth;
    }

    public struct VkPhysicalDeviceRayQueryFeaturesKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 rayQuery;
    }

    public struct VkPhysicalDeviceMeshShaderFeaturesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 taskShader;
        public Bool32 meshShader;
        public Bool32 multiviewMeshShader;
        public Bool32 primitiveFragmentShadingRateMeshShader;
        public Bool32 meshShaderQueries;
    }

    public struct VkPhysicalDeviceMeshShaderPropertiesEXT
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint maxTaskWorkGroupTotalCount;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] maxTaskWorkGroupCount;
        public uint maxTaskWorkGroupInvocations;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] maxTaskWorkGroupSize;
        public uint maxTaskPayloadSize;
        public uint maxTaskSharedMemorySize;
        public uint maxTaskPayloadAndSharedMemorySize;
        public uint maxMeshWorkGroupTotalCount;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] maxMeshWorkGroupCount;
        public uint maxMeshWorkGroupInvocations;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] maxMeshWorkGroupSize;
        public uint maxMeshSharedMemorySize;
        public uint maxMeshPayloadAndSharedMemorySize;
        public uint maxMeshOutputMemorySize;
        public uint maxMeshPayloadAndOutputMemorySize;
        public uint maxMeshOutputComponents;
        public uint maxMeshOutputVertices;
        public uint maxMeshOutputPrimitives;
        public uint maxMeshOutputLayers;
        public uint maxMeshMultiviewViewCount;
        public uint meshOutputPerVertexGranularity;
        public uint meshOutputPerPrimitiveGranularity;
        public uint maxPreferredTaskWorkGroupInvocations;
        public uint maxPreferredMeshWorkGroupInvocations;
        public Bool32 prefersLocalInvocationVertexOutput;
        public Bool32 prefersLocalInvocationPrimitiveOutput;
        public Bool32 prefersCompactVertexOutput;
        public Bool32 prefersCompactPrimitiveOutput;
    }

    public struct VkDrawMeshTasksIndirectCommandEXT
    {
        public uint groupCountX;
        public uint groupCountY;
        public uint groupCountZ;
    }

    public struct VkSwapchainCreateInfoKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkSwapchainCreateFlagsKHR flags;
        public VkSurfaceKHR surface;
        public uint minImageCount;
        public VkFormat imageFormat;
        public VkColorSpaceKHR imageColorSpace;
        public VkExtent2D imageExtent;
        public uint imageArrayLayers;
        public VkImageUsageFlags imageUsage;
        public VkSharingMode imageSharingMode;
        public uint queueFamilyIndexCount;
        public uint[] pQueueFamilyIndices;
        public VkSurfaceTransformFlagBitsKHR preTransform;
        public VkCompositeAlphaFlagsKHR compositeAlpha;
        public VkPresentModeKHR presentMode;
        public Bool32 clipped;
        public VkSwapchainKHR oldSwapchain;
    }

    public struct VkPresentInfoKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint waitSemaphoreCount;
        public VkSemaphore[] pWaitSemaphores;
        public uint swapchainCount;
        public VkSwapchainKHR[] pSwapchains;
        public uint[] pImageIndices;
        public VkResult[] pResults;
    }

    public struct VkImageSwapchainCreateInfoKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkSwapchainKHR swapchain;
    }

    public struct VkBindImageMemorySwapchainInfoKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkSwapchainKHR swapchain;
        public uint imageIndex;
    }

    public struct VkAcquireNextImageInfoKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkSwapchainKHR swapchain;
        public ulong timeout;
        public VkSemaphore semaphore;
        public VkFence fence;
        public uint deviceMask;
    }

    public struct VkDeviceGroupPresentCapabilitiesKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = VK.VK_MAX_DEVICE_GROUP_SIZE)]
        public uint[] presentMask;
        public VkDeviceGroupPresentModeFlagsKHR modes;
    }

    public struct VkDeviceGroupPresentInfoKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public uint swapchainCount;
        public uint[] pDeviceMasks;
        public VkDeviceGroupPresentModeFlagsKHR mode;
    }

    public struct VkDeviceGroupSwapchainCreateInfoKHR
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public VkDeviceGroupPresentModeFlagsKHR modes;
    }

    public struct VkPhysicalDeviceExclusiveScissorFeaturesNV
    {
        public VkStructureType sType;
        public IntPtr pNext;
        public Bool32 exclusiveScissor;
    }
}
