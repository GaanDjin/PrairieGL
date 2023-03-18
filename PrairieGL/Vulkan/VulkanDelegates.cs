

using System.Runtime.InteropServices;
/**
 ulong represents device memory size and offset values:

public delegate  ulong ulong;
ulong represents device buffer address values:

// Provided by VK_VERSION_1_0
public delegate  ulong ulong;

 */

namespace PrairieGL.Vulkan
{
    internal class VulkanDelegates
    {
        public delegate IntPtr vkGetInstanceProcAddr(VkInstance instance, string pName);
        public delegate IntPtr vkGetDeviceProcAddr(VkDevice device, string pName);



        /// <summary>
        /// Semaphores are a synchronization primitive that can be used to insert a dependency between queue operations or between a queue operation and the host.
        /// </summary>
        /// <param name="device">the logical device that creates the semaphore.</param>
        /// <param name="pCreateInfo">a VkSemaphoreCreateInfo structure containing information about how the semaphore is to be created.</param>
        /// <param name="pAllocator">Controls host memory allocation as described in the Memory Allocation chapter.</param>
        /// <param name="pSemaphore">A handle in which the resulting semaphore obj is returned.</param>
        /// <returns>
        /// Success
        /// VK_SUCCESS
        /// 
        /// Failure
        /// VK_ERROR_OUT_OF_HOST_MEMORY
        /// 
        /// VK_ERROR_OUT_OF_DEVICE_MEMORY
        /// </returns>
        public delegate VkResult vkCreateSemaphore(
            VkDevice device, 
            VkSemaphoreCreateInfo pCreateInfo, 
            VkAllocationCallbacks pAllocator, 
            out VkSemaphore pSemaphore);

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
        /// <param name="pFence">a handle in which the resulting fence obj is returned.</param>
        /// <returns></returns>
        public delegate VkResult vkCreateFence(
            VkDevice device, 
            VkFenceCreateInfo pCreateInfo, 
            VkAllocationCallbacks pAllocator, 
            out VkFence pFence);

        /// <summary>
        /// Allocates command buffers
        /// </summary>
        /// <param name="device">the logical device that owns the command pool.</param>
        /// <param name="pAllocateInfo">a VkCommandBufferAllocateInfo structure describing parameters of the allocation.</param>
        /// <param name="pCommandBuffers">
        /// an array of VkCommandBuffer handles in which the resulting command
        /// buffer objects are returned. The array must be at least the length 
        /// specified by the commandBufferCount member of pAllocateInfo. 
        /// Each allocated command buffer begins in the initial state.</param>
        /// <returns></returns>
        public delegate VkResult vkAllocateCommandBuffers(
            VkDevice device, 
            VkCommandBufferAllocateInfo pAllocateInfo, 
            out VkCommandBuffer pCommandBuffers);

        /// <summary>
        /// Begins recording a command buffer
        /// </summary>
        /// <param name="commandBuffer">the command buffer which is to be put in the recording state.</param>
        /// <param name="pBeginInfo">a VkCommandBufferBeginInfo structure defining additional information about how the command buffer begins recording.</param>
        /// <returns></returns>
        public delegate VkResult vkBeginCommandBuffer(
            VkCommandBuffer commandBuffer, 
            VkCommandBufferBeginInfo pBeginInfo);

        /// <summary>
        /// Once recording starts, an application records a sequence of commands (vkCmd*) to set state in the command buffer, draw, dispatch, and other commands.
        /// 
        /// Several commands can also be recorded indirectly from VkBuffer content, see Device-Generated Commands.
        /// 
        /// To complete recording of a command buffer, call:
        /// </summary>
        /// <param name="commandBuffer">the command buffer to complete recording.</param>
        public delegate VkResult vkEndCommandBuffer(VkCommandBuffer commandBuffer);

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
        public delegate VkResult vkQueueSubmit(
            VkQueue queue, 
            uint submitCount, 
            VkSubmitInfo[] pSubmits, 
            VkFence fence);

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
        public delegate VkResult vkWaitForFences(
            VkDevice device, 
            uint fenceCount, 
            VkFence[] pFences, 
            bool waitAll, 
            ulong timeout);

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
        public delegate VkResult vkResetFences(
            VkDevice device, 
            uint fenceCount, 
            VkFence[] pFences);

        public delegate void vkCmdBeginRenderPass(
            VkCommandBuffer commandBuffer, 
            VkRenderPassBeginInfo pRenderPassBegin, 
            VkSubpassContents contents);

        public delegate void vkCmdSetScissor(
            VkCommandBuffer commandBuffer, 
            uint firstScissor, 
            uint scissorCount, 
            VkRect2D[] pScissors);

        // Bind descriptor sets describing shader binding points
        public delegate void vkCmdBindDescriptorSets(
            VkCommandBuffer commandBuffer, 
            VkPipelineBindPoint pipelineBindPoint, 
            VkPipelineLayout layout, 
            uint firstSet, 
            uint descriptorSetCount, 
            VkDescriptorSet[] pDescriptorSets, 
            uint dynamicOffsetCount, 
            uint[] pDynamicOffsets);

        // Bind the rendering pipeline
        // The pipeline (state obj) contains all states of the rendering pipeline, binding it will set all the states specified at pipeline creation time
        public delegate void vkCmdBindPipeline(
            VkCommandBuffer commandBuffer, 
            VkPipelineBindPoint pipelineBindPoint, 
            VkPipeline pipeline);

        public delegate void vkCmdBindVertexBuffers(
            VkCommandBuffer commandBuffer, 
            uint firstBinding, 
            uint bindingCount, 
            VkBuffer[] pBuffers, 
            ulong[] pOffsets);

        // Bind triangle index buffer
        public delegate void vkCmdBindIndexBuffer(
            VkCommandBuffer commandBuffer, 
            VkBuffer buffer, 
            ulong offset, 
            VkIndexType indexType);

        // Draw indexed triangle
        public delegate void vkCmdDrawIndexed(
            VkCommandBuffer commandBuffer, 
            uint indexCount, 
            uint instanceCount, 
            uint firstIndex, 
            int vertexOffset, 
            uint firstInstance);

        public delegate VkResult vkCreateRenderPass(
            VkDevice device, 
            VkRenderPassCreateInfo pCreateInfo, 
            VkAllocationCallbacks pAllocator, 
            out VkRenderPass pRenderPass);

        public delegate void vkCmdEndRenderPass(VkCommandBuffer commandBuffer);

        public delegate VkResult vkCreateBuffer(
            VkDevice device, 
            VkBufferCreateInfo pCreateInfo, 
            VkAllocationCallbacks pAllocator, 
            out VkBuffer pBuffer);

        public delegate void vkGetBufferMemoryRequirements(
            VkDevice device, 
            VkBuffer buffer, 
            out VkMemoryRequirements pMemoryRequirements);

        public delegate VkResult vkMapMemory(
            VkDevice device, 
            VkDeviceMemory memory, 
            ulong offset, 
            ulong size, 
            VkMemoryMapFlags flags, 
            IntPtr ppData);

        public delegate void vkUnmapMemory(
            VkDevice device, 
            VkDeviceMemory memory);

        public delegate VkResult vkBindBufferMemory(
            VkDevice device, 
            VkBuffer buffer, 
            VkDeviceMemory memory, 
            ulong memoryOffset);

        public delegate VkResult vkAllocateMemory(
            VkDevice device, 
            VkMemoryAllocateInfo pAllocateInfo, 
            VkAllocationCallbacks pAllocator, 
            out VkDeviceMemory pMemory);

        public delegate VkResult vkCreateDescriptorPool(
            VkDevice device, 
            VkDescriptorPoolCreateInfo pCreateInfo, 
            VkAllocationCallbacks pAllocator, 
            out VkDescriptorPool pDescriptorPool);

        public delegate VkResult vkCreateDescriptorSetLayout(
            VkDevice device, 
            VkDescriptorSetLayoutCreateInfo pCreateInfo, 
            VkAllocationCallbacks pAllocator, 
            out VkDescriptorSetLayout pSetLayout);

        public delegate VkResult vkCreatePipelineLayout(
            VkDevice device, 
            VkPipelineLayoutCreateInfo pCreateInfo, 
            VkAllocationCallbacks pAllocator, 
            out VkPipelineLayout pPipelineLayout);

        public delegate VkResult vkAllocateDescriptorSets(
            VkDevice device, 
            VkDescriptorSetAllocateInfo pAllocateInfo, 
            out VkDescriptorSet pDescriptorSets);

        public delegate void vkUpdateDescriptorSets(
            VkDevice device, 
            uint descriptorWriteCount, 
            VkWriteDescriptorSet[] pDescriptorWrites, 
            uint descriptorCopyCount, 
            VkCopyDescriptorSet[] pDescriptorCopies);

        public delegate VkResult vkCreateImage(
            VkDevice device, 
            VkImageCreateInfo pCreateInfo, 
            VkAllocationCallbacks pAllocator, 
            out VkImage pImage);

        public delegate void vkGetImageMemoryRequirements(
            VkDevice device, 
            VkImage image, 
            out VkMemoryRequirements pMemoryRequirements);

        public delegate VkResult vkBindImageMemory(
            VkDevice device, 
            VkImage image, 
            VkDeviceMemory memory, 
            ulong memoryOffset);

        public delegate VkResult vkCreateImageView(
            VkDevice device, 
            VkImageViewCreateInfo pCreateInfo, 
            VkAllocationCallbacks pAllocator, 
            out VkImageView pView);

        public delegate VkResult vkCreateFramebuffer(
            VkDevice device, 
            VkFramebufferCreateInfo pCreateInfo, 
            VkAllocationCallbacks pAllocator, 
            out VkFramebuffer pFramebuffer);

        public delegate VkResult vkCreateShaderModule(
            VkDevice device, 
            VkShaderModuleCreateInfo pCreateInfo, 
            VkAllocationCallbacks pAllocator, 
            out VkShaderModule pShaderModule);

        public delegate void vkDestroyShaderModule(
            VkDevice device, 
            VkShaderModule shaderModule, 
            VkAllocationCallbacks pAllocator);

        public delegate VkResult vkCreateGraphicsPipelines(
            VkDevice device, 
            VkPipelineCache pipelineCache, 
            uint createInfoCount, 
            VkGraphicsPipelineCreateInfo[] pCreateInfos, 
            VkAllocationCallbacks pAllocator, 
            out VkPipeline[] pPipelines);

        public delegate void vkDestroyPipeline(
            VkDevice device, 
            VkPipeline pipeline, 
            VkAllocationCallbacks pAllocator);

        public delegate void vkDestroyPipelineLayout(
            VkDevice device, 
            VkPipelineLayout pipelineLayout, 
            VkAllocationCallbacks pAllocator);

        public delegate void vkDestroyDescriptorSetLayout(
            VkDevice device, 
            VkDescriptorSetLayout descriptorSetLayout, 
            VkAllocationCallbacks pAllocator);

        public delegate void vkDestroyBuffer(
            VkDevice device, 
            VkBuffer buffer, 
            VkAllocationCallbacks pAllocator);

        public delegate void vkFreeMemory(
            VkDevice device, 
            VkDeviceMemory memory, 
            VkAllocationCallbacks pAllocator);

        public delegate void vkDestroySemaphore(
            VkDevice device, 
            VkSemaphore semaphore, 
            VkAllocationCallbacks pAllocator);

        public delegate void vkDestroyFence(
            VkDevice device, 
            VkFence fence, 
            VkAllocationCallbacks pAllocator);

        public delegate void vkFreeCommandBuffers(
            VkDevice device, 
            VkCommandPool commandPool, 
            uint commandBufferCount, 
            VkCommandBuffer[] pCommandBuffers);


        public delegate void vkCmdBeginRenderingKHR(
            VkCommandBuffer commandBuffer, 
            VkRenderingInfo pRenderingInfo);

        public delegate void vkCmdEndRenderingKHR(VkCommandBuffer commandBuffer);

        public delegate VkResult vkCreateInstance(
            VkInstanceCreateInfo pCreateInfo, 
            VkAllocationCallbacks pAllocator,
            [In, Out] VkInstance pInstance);

        public delegate void vkDestroyInstance(
            VkInstance instance, 
            VkAllocationCallbacks pAllocator);

        public delegate VkResult vkEnumeratePhysicalDevices(
            VkInstance instance,
            [In, Out] ref uint pPhysicalDeviceCount,
            [In, Out] ref VkPhysicalDevice pPhysicalDevices);

        public delegate void vkGetPhysicalDeviceFeatures(
            VkPhysicalDevice physicalDevice, 
            out VkPhysicalDeviceFeatures pFeatures);

        public delegate void vkGetPhysicalDeviceFormatProperties(
            VkPhysicalDevice physicalDevice, 
            VkFormat format, 
            out VkFormatProperties pFormatProperties);

        public delegate VkResult vkGetPhysicalDeviceImageFormatProperties(
            VkPhysicalDevice physicalDevice, 
            VkFormat format, 
            VkImageType type, 
            VkImageTiling tiling, 
            VkImageUsageFlags usage, 
            VkImageCreateFlags flags, 
            out VkImageFormatProperties pImageFormatProperties);

        public delegate void vkGetPhysicalDeviceProperties(
            VkPhysicalDevice physicalDevice, 
            out VkPhysicalDeviceProperties pProperties);

        public delegate void vkGetPhysicalDeviceQueueFamilyProperties(
            VkPhysicalDevice physicalDevice, 
            ref uint pQueueFamilyPropertyCount, 
            VkQueueFamilyProperties[] pQueueFamilyProperties);

        public delegate void vkGetPhysicalDeviceMemoryProperties(
            VkPhysicalDevice physicalDevice, 
            out VkPhysicalDeviceMemoryProperties pMemoryProperties);

        public delegate VkResult vkCreateDevice(
            VkPhysicalDevice physicalDevice, 
            VkDeviceCreateInfo pCreateInfo, 
            IntPtr pAllocator, 
            [In, Out] VkDevice pDevice);

        public delegate void vkDestroyDevice(
            VkDevice device, 
            VkAllocationCallbacks pAllocator);

        public delegate VkResult vkEnumerateInstanceExtensionProperties(
            string pLayerName, 
            ref uint pPropertyCount, 
            VkExtensionProperties[] pProperties);

        public delegate VkResult vkEnumerateDeviceExtensionProperties(
            VkPhysicalDevice physicalDevice, 
            string pLayerName, 
            ref uint pPropertyCount, 
            VkExtensionProperties[] pProperties);

        public delegate VkResult vkEnumerateInstanceLayerProperties(
            ref uint pPropertyCount, 
            VkLayerProperties[] pProperties);

        public delegate VkResult vkEnumerateDeviceLayerProperties(
            VkPhysicalDevice physicalDevice, 
            ref uint pPropertyCount, 
            VkLayerProperties[] pProperties);

        public delegate void vkGetDeviceQueue(
            VkDevice device, 
            uint queueFamilyIndex, 
            uint queueIndex, 
            [In, Out] ref VkQueue pQueue);

        public delegate VkResult vkQueueWaitIdle(VkQueue queue);

        public delegate VkResult vkDeviceWaitIdle(VkDevice device);

        public delegate VkResult vkFlushMappedMemoryRanges(
            VkDevice device, 
            uint memoryRangeCount, 
            VkMappedMemoryRange[] pMemoryRanges);

        public delegate VkResult vkInvalidateMappedMemoryRanges(
            VkDevice device, 
            uint memoryRangeCount, 
            VkMappedMemoryRange[] pMemoryRanges);

        public delegate void vkGetDeviceMemoryCommitment(
            VkDevice device, 
            VkDeviceMemory memory, 
            out ulong pCommittedMemoryInBytes);

        public delegate void vkGetImageSparseMemoryRequirements(
            VkDevice device, 
            VkImage image, 
            ref uint pSparseMemoryRequirementCount, 
            VkSparseImageMemoryRequirements[] pSparseMemoryRequirements);

        public delegate void vkGetPhysicalDeviceSparseImageFormatProperties(
            VkPhysicalDevice physicalDevice, 
            VkFormat format, 
            VkImageType type,
            VkSampleCountFlags samples, 
            VkImageUsageFlags usage, 
            VkImageTiling tiling, 
            ref uint pPropertyCount, 
            VkSparseImageFormatProperties[] pProperties);

        public delegate VkResult vkQueueBindSparse(
            VkQueue queue, 
            uint bindInfoCount, 
            VkBindSparseInfo[] pBindInfo, 
            VkFence fence);
        
        public delegate VkResult vkGetFenceStatus(VkDevice device, VkFence fence);

        public delegate VkResult vkCreateEvent(
            VkDevice device, 
            VkEventCreateInfo pCreateInfo, 
            VkAllocationCallbacks pAllocator, 
            out VkEvent pEvent);
         
        public delegate void vkDestroyEvent(
            VkDevice device, 
            VkEvent evt, 
            VkAllocationCallbacks pAllocator);

        public delegate VkResult vkGetEventStatus(VkDevice device, VkEvent evt);

        public delegate VkResult vkSetEvent(VkDevice device, VkEvent evt);

        public delegate VkResult vkResetEvent(VkDevice device, VkEvent evt);

        public delegate VkResult vkCreateQueryPool(
            VkDevice device, 
            VkQueryPoolCreateInfo pCreateInfo, 
            VkAllocationCallbacks pAllocator, 
            out VkQueryPool pQueryPool);

        public delegate void vkDestroyQueryPool(
            VkDevice device, 
            VkQueryPool queryPool, 
            VkAllocationCallbacks pAllocator);

        public delegate VkResult vkGetQueryPoolResults(
            VkDevice device, 
            VkQueryPool queryPool, 
            uint firstQuery, 
            uint queryCount, 
            int dataSize, 
            IntPtr pData, 
            ulong stride, 
            VkQueryResultFlags flags);

        public delegate VkResult vkCreateBufferView(
            VkDevice device, 
            VkBufferViewCreateInfo pCreateInfo, 
            VkAllocationCallbacks pAllocator, 
            out VkBufferView pView);

        public delegate void vkDestroyBufferView(
            VkDevice device, 
            VkBufferView bufferView, 
            VkAllocationCallbacks pAllocator);

        public delegate void vkDestroyImage(
            VkDevice device, 
            VkImage image, 
            VkAllocationCallbacks pAllocator);

        public delegate void vkGetImageSubresourceLayout(
            VkDevice device, 
            VkImage image, 
            VkImageSubresource pSubresource, 
            out VkSubresourceLayout pLayout);

        public delegate void vkDestroyImageView(
            VkDevice device, 
            VkImageView imageView, 
            VkAllocationCallbacks pAllocator);

        public delegate VkResult vkCreatePipelineCache(
            VkDevice device, 
            VkPipelineCacheCreateInfo pCreateInfo, 
            VkAllocationCallbacks pAllocator, 
            out VkPipelineCache pPipelineCache);

        public delegate void vkDestroyPipelineCache(
            VkDevice device, 
            VkPipelineCache pipelineCache, 
            VkAllocationCallbacks[] pAllocator);

        public delegate VkResult vkGetPipelineCacheData(
            VkDevice device, 
            VkPipelineCache pipelineCache, 
            ref int pDataSize, 
            byte[] pData);

        public delegate VkResult vkMergePipelineCaches(
            VkDevice device, 
            VkPipelineCache dstCache, 
            uint srcCacheCount, 
            VkPipelineCache[] pSrcCaches);

        public delegate VkResult vkCreateComputePipelines(
            VkDevice device, 
            VkPipelineCache pipelineCache, 
            uint createInfoCount, 
            VkComputePipelineCreateInfo pCreateInfos, 
            VkAllocationCallbacks pAllocator, 
            out VkPipeline pPipelines);

        public delegate VkResult vkCreateSampler(
            VkDevice device, 
            VkSamplerCreateInfo pCreateInfo, 
            VkAllocationCallbacks pAllocator, 
            out VkSampler pSampler);

        public delegate void vkDestroySampler(
            VkDevice device, 
            VkSampler sampler, 
            VkAllocationCallbacks pAllocator);

        public delegate void vkDestroyDescriptorPool(
            VkDevice device, 
            VkDescriptorPool descriptorPool, 
            VkAllocationCallbacks pAllocator);

        public delegate VkResult vkResetDescriptorPool(
            VkDevice device, 
            VkDescriptorPool descriptorPool, 
            VkDescriptorPoolResetFlags flags);

        public delegate VkResult vkFreeDescriptorSets(
            VkDevice device, 
            VkDescriptorPool descriptorPool, 
            uint descriptorSetCount, 
            VkDescriptorSet pDescriptorSets);

        public delegate void vkDestroyFramebuffer(
            VkDevice device, 
            VkFramebuffer framebuffer, 
            VkAllocationCallbacks pAllocator);

        public delegate void vkDestroyRenderPass(
            VkDevice device, 
            VkRenderPass renderPass, 
            VkAllocationCallbacks pAllocator);

        public delegate void vkGetRenderAreaGranularity(
            VkDevice device, 
            VkRenderPass renderPass, 
            out VkExtent2D pGranularity);

        public delegate VkResult vkCreateCommandPool(
            VkDevice device, 
            VkCommandPoolCreateInfo pCreateInfo, 
            VkAllocationCallbacks pAllocator, 
            out VkCommandPool pCommandPool);

        public delegate void vkDestroyCommandPool(
            VkDevice device, 
            VkCommandPool commandPool, 
            VkAllocationCallbacks pAllocator);

        public delegate VkResult vkResetCommandPool(
            VkDevice device, 
            VkCommandPool commandPool, 
            VkCommandPoolResetFlags flags);

        public delegate VkResult vkResetCommandBuffer(
            VkCommandBuffer commandBuffer, 
            VkCommandBufferResetFlags flags);

        public delegate void vkCmdSetViewport(
            VkCommandBuffer commandBuffer, 
            uint firstViewport, 
            uint viewportCount, 
            VkViewport[] pViewports);

        public delegate void vkCmdSetLineWidth(
            VkCommandBuffer commandBuffer, 
            float lineWidth);

        public delegate void vkCmdSetDepthBias(
            VkCommandBuffer commandBuffer, 
            float depthBiasConstantFactor, 
            float depthBiasClamp, 
            float depthBiasSlopeFactor);

        public delegate void vkCmdSetBlendConstants(
            VkCommandBuffer commandBuffer, 
            float[] blendConstants/*[4]*/);

        public delegate void vkCmdSetDepthBounds(
            VkCommandBuffer commandBuffer, 
            float minDepthBounds, 
            float maxDepthBounds);

        public delegate void vkCmdSetStencilCompareMask(
            VkCommandBuffer commandBuffer, 
            VkStencilFaceFlags faceMask, 
            uint compareMask);

        public delegate void vkCmdSetStencilWriteMask(
            VkCommandBuffer commandBuffer, 
            VkStencilFaceFlags faceMask, 
            uint writeMask);

        public delegate void vkCmdSetStencilReference(
            VkCommandBuffer commandBuffer, 
            VkStencilFaceFlags faceMask, 
            uint reference);

        public delegate void vkCmdDraw(
            VkCommandBuffer commandBuffer, 
            uint vertexCount, 
            uint instanceCount, 
            uint firstVertex, 
            uint firstInstance);
         
        public delegate void vkCmdDrawIndirect(
            VkCommandBuffer commandBuffer, 
            VkBuffer buffer, 
            ulong offset, 
            uint drawCount, 
            uint stride);

        public delegate void vkCmdDrawIndexedIndirect(
            VkCommandBuffer commandBuffer, 
            VkBuffer buffer, 
            ulong offset, 
            uint drawCount, 
            uint stride);

        public delegate void vkCmdDispatch(
            VkCommandBuffer commandBuffer, 
            uint groupCountX, 
            uint groupCountY, 
            uint groupCountZ);

        public delegate void vkCmdDispatchIndirect(
            VkCommandBuffer commandBuffer, 
            VkBuffer buffer, 
            ulong offset);

        public delegate void vkCmdCopyBuffer(
            VkCommandBuffer commandBuffer, 
            VkBuffer srcBuffer, 
            VkBuffer dstBuffer, 
            uint regionCount, 
            VkBufferCopy[] pRegions);

        public delegate void vkCmdCopyImage(
            VkCommandBuffer commandBuffer, 
            VkImage srcImage, 
            VkImageLayout srcImageLayout, 
            VkImage dstImage, 
            VkImageLayout dstImageLayout, 
            uint regionCount, 
            VkImageCopy[] pRegions);

        public delegate void vkCmdBlitImage(
            VkCommandBuffer commandBuffer, 
            VkImage srcImage, 
            VkImageLayout srcImageLayout, 
            VkImage dstImage, 
            VkImageLayout dstImageLayout, 
            uint regionCount, 
            VkImageBlit[] pRegions, 
            VkFilter filter);

        public delegate void vkCmdCopyBufferToImage(
            VkCommandBuffer commandBuffer, 
            VkBuffer srcBuffer, 
            VkImage dstImage, 
            VkImageLayout dstImageLayout, 
            uint regionCount, 
            VkBufferImageCopy[] pRegions);

        public delegate void vkCmdCopyImageToBuffer(
            VkCommandBuffer commandBuffer, 
            VkImage srcImage, 
            VkImageLayout srcImageLayout, 
            VkBuffer dstBuffer, 
            uint regionCount, 
            VkBufferImageCopy[] pRegions);

        public delegate void vkCmdUpdateBuffer(
            VkCommandBuffer commandBuffer, 
            VkBuffer dstBuffer, 
            ulong dstOffset, 
            ulong dataSize, 
            IntPtr pData);

        public delegate void vkCmdFillBuffer(
            VkCommandBuffer commandBuffer, 
            VkBuffer dstBuffer, 
            ulong dstOffset, 
            ulong size, 
            uint data);

        public delegate void vkCmdClearColorImage(
            VkCommandBuffer commandBuffer, 
            VkImage image, 
            VkImageLayout imageLayout, 
            VkClearColorValue pColor, 
            uint rangeCount, 
            VkImageSubresourceRange[] pRanges);

        public delegate void vkCmdClearDepthStencilImage(
            VkCommandBuffer commandBuffer, 
            VkImage image, 
            VkImageLayout imageLayout, 
            VkClearDepthStencilValue pDepthStencil, 
            uint rangeCount, 
            VkImageSubresourceRange[] pRanges);

        public delegate void vkCmdClearAttachments(
            VkCommandBuffer commandBuffer, 
            uint attachmentCount, 
            VkClearAttachment[] pAttachments, 
            uint rectCount, 
            VkClearRect[] pRects);

        public delegate void vkCmdResolveImage(
            VkCommandBuffer commandBuffer, 
            VkImage srcImage, 
            VkImageLayout srcImageLayout, 
            VkImage dstImage, 
            VkImageLayout dstImageLayout, 
            uint regionCount, 
            VkImageResolve[] pRegions);

        public delegate void vkCmdSetEvent(
            VkCommandBuffer commandBuffer, 
            VkEvent evt, 
            VkPipelineStageFlags stageMask);

        public delegate void vkCmdResetEvent(
            VkCommandBuffer commandBuffer, 
            VkEvent evt, 
            VkPipelineStageFlags stageMask);

        public delegate void vkCmdWaitEvents(
            VkCommandBuffer commandBuffer, 
            uint eventCount, 
            VkEvent[] pEvents, 
            VkPipelineStageFlags srcStageMask, 
            VkPipelineStageFlags dstStageMask, 
            uint memoryBarrierCount, 
            VkMemoryBarrier[] pMemoryBarriers, 
            uint bufferMemoryBarrierCount, 
            VkBufferMemoryBarrier[] pBufferMemoryBarriers, 
            uint imageMemoryBarrierCount, 
            VkImageMemoryBarrier[] pImageMemoryBarriers);

        public delegate void vkCmdPipelineBarrier(
            VkCommandBuffer commandBuffer, 
            VkPipelineStageFlags srcStageMask, 
            VkPipelineStageFlags dstStageMask, 
            VkDependencyFlags dependencyFlags, 
            uint memoryBarrierCount, 
            VkMemoryBarrier[] pMemoryBarriers, 
            uint bufferMemoryBarrierCount, 
            VkBufferMemoryBarrier[] pBufferMemoryBarriers, 
            uint imageMemoryBarrierCount, 
            VkImageMemoryBarrier[] pImageMemoryBarriers);

        public delegate void vkCmdBeginQuery(
            VkCommandBuffer commandBuffer, 
            VkQueryPool queryPool, 
            uint query, 
            VkQueryControlFlags flags);

        public delegate void vkCmdEndQuery(
            VkCommandBuffer commandBuffer, 
            VkQueryPool queryPool, 
            uint query);

        public delegate void vkCmdResetQueryPool(
            VkCommandBuffer commandBuffer, 
            VkQueryPool queryPool, 
            uint firstQuery, 
            uint queryCount);

        public delegate void vkCmdWriteTimestamp(
            VkCommandBuffer commandBuffer, 
            VkPipelineStageFlags pipelineStage, 
            VkQueryPool queryPool, 
            uint query);

        public delegate void vkCmdCopyQueryPoolResults(
            VkCommandBuffer commandBuffer, 
            VkQueryPool queryPool, 
            uint firstQuery, 
            uint queryCount, 
            VkBuffer dstBuffer, 
            ulong dstOffset, 
            ulong stride, 
            VkQueryResultFlags flags);

        public delegate void vkCmdPushConstants(
            VkCommandBuffer commandBuffer, 
            VkPipelineLayout layout, 
            VkShaderStageFlags stageFlags, 
            uint offset, 
            uint size, 
            IntPtr pValues);

        public delegate void vkCmdNextSubpass(
            VkCommandBuffer commandBuffer, 
            VkSubpassContents contents);

        public delegate void vkCmdExecuteCommands(
            VkCommandBuffer commandBuffer, 
            uint commandBufferCount, 
            VkCommandBuffer[] pCommandBuffers);
         
        public delegate VkResult vkEnumerateInstanceVersion(
            ref uint pApiVersion);

        public delegate VkResult vkBindBufferMemory2(
            VkDevice device,
            uint bindInfoCount,
            VkBindBufferMemoryInfo[] pBindInfos);

        public delegate VkResult vkBindImageMemory2(
            VkDevice device,
            uint bindInfoCount,
            VkBindImageMemoryInfo[] pBindInfos);

        public delegate void vkGetDeviceGroupPeerMemoryFeatures(
            VkDevice device,
            uint heapIndex,
            uint localDeviceIndex,
            uint remoteDeviceIndex,
            out VkPeerMemoryFeatureFlags pPeerMemoryFeatures);

        public delegate void vkCmdSetDeviceMask(
            VkCommandBuffer commandBuffer,
            uint deviceMask);

        public delegate void vkCmdDispatchBase(
            VkCommandBuffer commandBuffer,
            uint baseGroupX, uint baseGroupY, uint baseGroupZ,
            uint groupCountX, uint groupCountY, uint groupCountZ);

        public delegate VkResult vkEnumeratePhysicalDeviceGroups(
            VkInstance instance,
            ref uint pPhysicalDeviceGroupCount,
            VkPhysicalDeviceGroupProperties[] pPhysicalDeviceGroupProperties);

        public delegate void vkGetImageMemoryRequirements2(
            VkDevice device,
            VkImageMemoryRequirementsInfo2 pInfo,
            out VkMemoryRequirements2 pMemoryRequirements);

        public delegate void vkGetBufferMemoryRequirements2(
            VkDevice device, 
            VkBufferMemoryRequirementsInfo2 pInfo, 
            out VkMemoryRequirements2 pMemoryRequirements);

        public delegate void vkGetImageSparseMemoryRequirements2(
            VkDevice device, 
            VkImageSparseMemoryRequirementsInfo2 pInfo, 
            ref uint pSparseMemoryRequirementCount, 
            VkSparseImageMemoryRequirements2[] pSparseMemoryRequirements);

        public delegate void vkGetPhysicalDeviceFeatures2(
            VkPhysicalDevice physicalDevice, 
            out VkPhysicalDeviceFeatures2 pFeatures);

        public delegate void vkGetPhysicalDeviceProperties2(
            VkPhysicalDevice physicalDevice, 
            out VkPhysicalDeviceProperties2 pProperties);

        public delegate void vkGetPhysicalDeviceFormatProperties2(
            VkPhysicalDevice physicalDevice, 
            VkFormat format, 
            out VkFormatProperties2 pFormatProperties);

        public delegate VkResult vkGetPhysicalDeviceImageFormatProperties2(
            VkPhysicalDevice physicalDevice, 
            VkPhysicalDeviceImageFormatInfo2 pImageFormatInfo, 
            out VkImageFormatProperties2 pImageFormatProperties);

        public delegate void vkGetPhysicalDeviceQueueFamilyProperties2(
            VkPhysicalDevice physicalDevice, 
            ref uint pQueueFamilyPropertyCount, 
            VkQueueFamilyProperties2[] pQueueFamilyProperties);

        public delegate void vkGetPhysicalDeviceMemoryProperties2(
            VkPhysicalDevice physicalDevice, 
            out VkPhysicalDeviceMemoryProperties2 pMemoryProperties);

        public delegate void vkGetPhysicalDeviceSparseImageFormatProperties2(
            VkPhysicalDevice physicalDevice, 
            VkPhysicalDeviceSparseImageFormatInfo2 pFormatInfo, 
            ref uint pPropertyCount, 
            VkSparseImageFormatProperties2[] pProperties);

        public delegate void vkTrimCommandPool(
            VkDevice device, 
            VkCommandPool commandPool, 
            VkCommandPoolTrimFlags flags);

        public delegate void vkGetDeviceQueue2(
            VkDevice device, 
            VkDeviceQueueInfo2 pQueueInfo, 
            out VkQueue pQueue);

        public delegate VkResult vkCreateSamplerYcbcrConversion(
            VkDevice device, 
            VkSamplerYcbcrConversionCreateInfo pCreateInfo, 
            VkAllocationCallbacks pAllocator, 
            out VkSamplerYcbcrConversion pYcbcrConversion);

        public delegate void vkDestroySamplerYcbcrConversion(
            VkDevice device, 
            VkSamplerYcbcrConversion ycbcrConversion, 
            VkAllocationCallbacks pAllocator);

        public delegate VkResult vkCreateDescriptorUpdateTemplate(
            VkDevice device, 
            VkDescriptorUpdateTemplateCreateInfo pCreateInfo, 
            VkAllocationCallbacks pAllocator, 
            out VkDescriptorUpdateTemplate pDescriptorUpdateTemplate);

        public delegate void vkDestroyDescriptorUpdateTemplate(
            VkDevice device, 
            VkDescriptorUpdateTemplate descriptorUpdateTemplate, 
            VkAllocationCallbacks pAllocator);

        public delegate void vkUpdateDescriptorSetWithTemplate(
            VkDevice device, 
            VkDescriptorSet descriptorSet, 
            VkDescriptorUpdateTemplate 
            descriptorUpdateTemplate, IntPtr pData);

        public delegate void vkGetPhysicalDeviceExternalBufferProperties(
            VkPhysicalDevice physicalDevice, 
            VkPhysicalDeviceExternalBufferInfo pExternalBufferInfo, 
            out VkExternalBufferProperties pExternalBufferProperties);

        public delegate void vkGetPhysicalDeviceExternalFenceProperties(
            VkPhysicalDevice physicalDevice, 
            VkPhysicalDeviceExternalFenceInfo pExternalFenceInfo, 
            out VkExternalFenceProperties pExternalFenceProperties);

        public delegate void vkGetPhysicalDeviceExternalSemaphoreProperties(
            VkPhysicalDevice physicalDevice, 
            VkPhysicalDeviceExternalSemaphoreInfo pExternalSemaphoreInfo, 
            out VkExternalSemaphoreProperties pExternalSemaphoreProperties);

        public delegate void vkGetDescriptorSetLayoutSupport(
            VkDevice device, 
            VkDescriptorSetLayoutCreateInfo pCreateInfo, 
            out VkDescriptorSetLayoutSupport pSupport);

        public delegate void vkCmdDrawIndirectCount(
            VkCommandBuffer commandBuffer, 
            VkBuffer buffer, 
            ulong offset, 
            VkBuffer countBuffer, 
            ulong countBufferOffset, 
            uint maxDrawCount, 
            uint stride);

        public delegate void vkCmdDrawIndexedIndirectCount(
            VkCommandBuffer commandBuffer, 
            VkBuffer buffer, 
            ulong offset, 
            VkBuffer countBuffer, 
            ulong countBufferOffset, 
            uint maxDrawCount, 
            uint stride);

        public delegate VkResult vkCreateRenderPass2(
            VkDevice device, 
            VkRenderPassCreateInfo2 pCreateInfo, 
            VkAllocationCallbacks pAllocator, 
            out VkRenderPass pRenderPass);

        public delegate void vkCmdBeginRenderPass2(
            VkCommandBuffer commandBuffer, 
            VkRenderPassBeginInfo pRenderPassBegin, 
            VkSubpassBeginInfo pSubpassBeginInfo);

        public delegate void vkCmdNextSubpass2(
            VkCommandBuffer commandBuffer, 
            VkSubpassBeginInfo pSubpassBeginInfo, 
            VkSubpassEndInfo pSubpassEndInfo);

        public delegate void vkCmdEndRenderPass2(
            VkCommandBuffer commandBuffer, 
            VkSubpassEndInfo pSubpassEndInfo);

        public delegate void vkResetQueryPool(
            VkDevice device, 
            VkQueryPool queryPool, 
            uint firstQuery, 
            uint queryCount);

        public delegate VkResult vkGetSemaphoreCounterValue(
            VkDevice device, 
            VkSemaphore semaphore, 
            out ulong pValue);

        public delegate VkResult vkWaitSemaphores(
            VkDevice device, 
            VkSemaphoreWaitInfo pWaitInfo, 
            ulong timeout);

        public delegate VkResult vkSignalSemaphore(
            VkDevice device, 
            VkSemaphoreSignalInfo pSignalInfo);

        public delegate ulong vkGetBufferDeviceAddress(
            VkDevice device, 
            out VkBufferDeviceAddressInfo pInfo);

        public delegate ulong vkGetBufferOpaqueCaptureAddress(
            VkDevice device, 
            out VkBufferDeviceAddressInfo pInfo);

        public delegate ulong vkGetDeviceMemoryOpaqueCaptureAddress(
            VkDevice device, 
            out VkDeviceMemoryOpaqueCaptureAddressInfo pInfo);

        public delegate VkResult vkCreatePrivateDataSlot(
            VkDevice device, 
            VkPrivateDataSlotCreateInfo pCreateInfo, 
            VkAllocationCallbacks pAllocator, 
            out VkPrivateDataSlot pPrivateDataSlot);

        public delegate void vkDestroyPrivateDataSlot(
            VkDevice device, 
            VkPrivateDataSlot privateDataSlot, 
            VkAllocationCallbacks pAllocator);

        public delegate VkResult vkSetPrivateData(
            VkDevice device, 
            VkObjectType objectType, 
            ulong objectHandle, 
            VkPrivateDataSlot privateDataSlot, 
            ulong data);

        public delegate void vkGetPrivateData(
            VkDevice device, 
            VkObjectType objectType, 
            ulong objectHandle, 
            VkPrivateDataSlot privateDataSlot, 
            IntPtr pData);

        public delegate void vkCmdSetEvent2(
            VkCommandBuffer commandBuffer, 
            VkEvent evt, 
            VkDependencyInfo pDependencyInfo);

        public delegate void vkCmdResetEvent2(
            VkCommandBuffer commandBuffer, 
            VkEvent evt, 
            VkPipelineStageFlags2 stageMask);

        public delegate void vkCmdWaitEvents2(
            VkCommandBuffer commandBuffer, 
            uint eventCount, 
            VkEvent pEvents, 
            VkDependencyInfo pDependencyInfos);

        public delegate void vkCmdPipelineBarrier2(
            VkCommandBuffer commandBuffer, 
            VkDependencyInfo pDependencyInfo);

        public delegate void vkCmdWriteTimestamp2(
            VkCommandBuffer commandBuffer, 
            VkPipelineStageFlags2 stage, 
            VkQueryPool queryPool, 
            uint query); 

        public delegate VkResult vkQueueSubmit2(
            VkQueue queue, 
            uint submitCount, 
            VkSubmitInfo2[] pSubmits, 
            VkFence fence);

        public delegate void vkCmdCopyBuffer2(
            VkCommandBuffer commandBuffer, 
            VkCopyBufferInfo2 pCopyBufferInfo);

        public delegate void vkCmdCopyImage2(
            VkCommandBuffer commandBuffer, 
            VkCopyImageInfo2 pCopyImageInfo);

        public delegate void vkCmdCopyBufferToImage2(
            VkCommandBuffer commandBuffer, 
            VkCopyBufferToImageInfo2 pCopyBufferToImageInfo);

        public delegate void vkCmdCopyImageToBuffer2(
            VkCommandBuffer commandBuffer, 
            VkCopyImageToBufferInfo2 pCopyImageToBufferInfo);

        public delegate void vkCmdBlitImage2(
            VkCommandBuffer commandBuffer, 
            VkBlitImageInfo2 pBlitImageInfo);

        public delegate void vkCmdResolveImage2(
            VkCommandBuffer commandBuffer, 
            VkResolveImageInfo2 pResolveImageInfo);

        public delegate void vkCmdBeginRendering(
            VkCommandBuffer commandBuffer, 
            VkRenderingInfo pRenderingInfo);
        
        public delegate void vkCmdEndRendering(VkCommandBuffer commandBuffer);

        public delegate void vkCmdSetCullMode(
            VkCommandBuffer commandBuffer, 
            VkCullModeFlags cullMode);

        public delegate void vkCmdSetFrontFace(
            VkCommandBuffer commandBuffer, 
            VkFrontFace frontFace);

        public delegate void vkCmdSetPrimitiveTopology(
            VkCommandBuffer commandBuffer, 
            VkPrimitiveTopology primitiveTopology);

        public delegate void vkCmdSetViewportWithCount(
            VkCommandBuffer commandBuffer, 
            uint viewportCount, 
            VkViewport[] pViewports);

        public delegate void vkCmdSetScissorWithCount(
            VkCommandBuffer commandBuffer, 
            uint scissorCount, 
            VkRect2D[] pScissors);

        public delegate void vkCmdBindVertexBuffers2(
            VkCommandBuffer commandBuffer, 
            uint firstBinding, 
            uint bindingCount, 
            VkBuffer[] pBuffers, 
            ulong[] pOffsets, 
            ulong[] pSizes, 
            ulong[] pStrides);

        public delegate void 
            vkCmdSetDepthTestEnable(VkCommandBuffer commandBuffer, 
            Bool32 depthTestEnable);

        public delegate void vkCmdSetDepthWriteEnable(
            VkCommandBuffer commandBuffer, 
            Bool32 depthWriteEnable);

        public delegate void vkCmdSetDepthCompareOp(
            VkCommandBuffer commandBuffer, 
            VkCompareOp depthCompareOp);

        public delegate void vkCmdSetDepthBoundsTestEnable(
            VkCommandBuffer commandBuffer, 
            Bool32 depthBoundsTestEnable);

        public delegate void vkCmdSetStencilTestEnable(
            VkCommandBuffer commandBuffer, 
            Bool32 stencilTestEnable);

        public delegate void vkCmdSetStencilOp(
            VkCommandBuffer commandBuffer, 
            VkStencilFaceFlags faceMask, 
            VkStencilOp failOp, 
            VkStencilOp passOp, 
            VkStencilOp depthFailOp, 
            VkCompareOp compareOp);

        public delegate void vkCmdSetRasterizerDiscardEnable(
            VkCommandBuffer commandBuffer, 
            Bool32 rasterizerDiscardEnable);

        public delegate void vkCmdSetDepthBiasEnable(
            VkCommandBuffer commandBuffer, 
            Bool32 depthBiasEnable);

        public delegate void vkCmdSetPrimitiveRestartEnable(
            VkCommandBuffer commandBuffer, 
            Bool32 primitiveRestartEnable);

        public delegate void vkGetDeviceBufferMemoryRequirements(
            VkDevice device, 
            VkDeviceBufferMemoryRequirements pInfo, 
            out VkMemoryRequirements2 pMemoryRequirements);

        public delegate void vkGetDeviceImageMemoryRequirements(
            VkDevice device, 
            VkDeviceImageMemoryRequirements pInfo, 
            out VkMemoryRequirements2 pMemoryRequirements);

        public delegate void vkGetDeviceImageSparseMemoryRequirements(
            VkDevice device, 
            VkDeviceImageMemoryRequirements pInfo, 
            ref uint pSparseMemoryRequirementCount, 
            VkSparseImageMemoryRequirements2[] pSparseMemoryRequirements);


        public delegate VkResult vkGetPhysicalDeviceToolProperties(
            VkPhysicalDevice physicalDevice,
            ref uint pToolCount,
            VkPhysicalDeviceToolProperties pToolProperties);


        public delegate void vkDestroySurfaceKHR(
            VkInstance instance, 
            VkSurfaceKHR surface, 
            VkAllocationCallbacks pAllocator);

        public delegate VkResult vkGetPhysicalDeviceSurfaceSupportKHR(
            VkPhysicalDevice physicalDevice, 
            uint queueFamilyIndex, 
            VkSurfaceKHR surface, 
            out Bool32 pSupported);

        public delegate VkResult vkGetPhysicalDeviceSurfaceCapabilitiesKHR(
            VkPhysicalDevice physicalDevice, 
            VkSurfaceKHR surface, 
            out VkSurfaceCapabilitiesKHR pSurfaceCapabilities);

        public delegate VkResult vkGetPhysicalDeviceSurfaceFormatsKHR(
            VkPhysicalDevice physicalDevice, 
            VkSurfaceKHR surface, 
            ref uint pSurfaceFormatCount, 
            VkSurfaceFormatKHR[] pSurfaceFormats);

        public delegate VkResult vkGetPhysicalDeviceSurfacePresentModesKHR(
            VkPhysicalDevice physicalDevice, 
            VkSurfaceKHR surface, 
            ref uint pPresentModeCount, 
            VkPresentModeKHR pPresentModes);



        public delegate VkResult vkCreateSwapchainKHR(
            VkDevice device, 
            VkSwapchainCreateInfoKHR pCreateInfo, 
            VkAllocationCallbacks pAllocator, 
            out VkSwapchainKHR pSwapchain);

        public delegate void vkDestroySwapchainKHR(
            VkDevice device, 
            VkSwapchainKHR swapchain, 
            VkAllocationCallbacks pAllocator);

        public delegate VkResult vkGetSwapchainImagesKHR(
            VkDevice device, 
            VkSwapchainKHR swapchain, 
            ref uint pSwapchainImageCount, 
            VkImage[] pSwapchainImages);

        public delegate VkResult vkAcquireNextImageKHR(
            VkDevice device, 
            VkSwapchainKHR swapchain, 
            ulong timeout, 
            VkSemaphore semaphore, 
            VkFence fence, 
            out uint pImageIndex);

        public delegate VkResult vkQueuePresentKHR(
            VkQueue queue, 
            VkPresentInfoKHR pPresentInfo);

        public delegate VkResult vkGetDeviceGroupPresentCapabilitiesKHR(
            VkDevice device, 
            out VkDeviceGroupPresentCapabilitiesKHR pDeviceGroupPresentCapabilities);

        public delegate VkResult vkGetDeviceGroupSurfacePresentModesKHR(
            VkDevice device, 
            VkSurfaceKHR surface, 
            out VkDeviceGroupPresentModeFlagsKHR pModes);

        public delegate VkResult vkGetPhysicalDevicePresentRectanglesKHR(
            VkPhysicalDevice physicalDevice, 
            VkSurfaceKHR surface, 
            ref uint pRectCount, 
            VkRect2D[] pRects);

        public delegate VkResult vkAcquireNextImage2KHR(
            VkDevice device, 
            VkAcquireNextImageInfoKHR pAcquireInfo, 
            out uint pImageIndex);


        public delegate VkResult vkGetPhysicalDeviceDisplayPropertiesKHR(
            VkPhysicalDevice physicalDevice, 
            ref uint pPropertyCount, 
            VkDisplayPropertiesKHR[] pProperties);

        public delegate VkResult vkGetPhysicalDeviceDisplayPlanePropertiesKHR(
            VkPhysicalDevice physicalDevice, 
            ref uint pPropertyCount, 
            VkDisplayPlanePropertiesKHR[] pProperties);

        public delegate VkResult vkGetDisplayPlaneSupportedDisplaysKHR(
            VkPhysicalDevice physicalDevice, 
            uint planeIndex, 
            ref uint pDisplayCount, 
            VkDisplayKHR[] pDisplays);

        public delegate VkResult vkGetDisplayModePropertiesKHR(
            VkPhysicalDevice physicalDevice, 
            VkDisplayKHR display, 
            ref uint pPropertyCount, 
            VkDisplayModePropertiesKHR[] pProperties);

        public delegate VkResult vkCreateDisplayModeKHR(
            VkPhysicalDevice physicalDevice, 
            VkDisplayKHR display, 
            VkDisplayModeCreateInfoKHR pCreateInfo, 
            VkAllocationCallbacks pAllocator, 
            out VkDisplayModeKHR pMode);

        public delegate VkResult vkGetDisplayPlaneCapabilitiesKHR(
            VkPhysicalDevice physicalDevice, 
            VkDisplayModeKHR mode, 
            uint planeIndex, 
            out VkDisplayPlaneCapabilitiesKHR pCapabilities);

        public delegate VkResult vkCreateDisplayPlaneSurfaceKHR(
            VkInstance instance, 
            VkDisplaySurfaceCreateInfoKHR pCreateInfo, 
            VkAllocationCallbacks pAllocator, 
            out VkSurfaceKHR pSurface);


        public delegate VkResult vkCreateSharedSwapchainsKHR(
            VkDevice device, 
            uint swapchainCount, 
            VkSwapchainCreateInfoKHR pCreateInfos, 
            VkAllocationCallbacks pAllocator, 
            out VkSwapchainKHR pSwapchains);

        public delegate void vkGetPhysicalDeviceFeatures2KHR(
            VkPhysicalDevice physicalDevice, 
            out VkPhysicalDeviceFeatures2 pFeatures);

        public delegate void vkGetPhysicalDeviceProperties2KHR(
            VkPhysicalDevice physicalDevice,
            out VkPhysicalDeviceProperties2 pProperties);

        public delegate void vkGetPhysicalDeviceFormatProperties2KHR(
            VkPhysicalDevice physicalDevice, 
            VkFormat format,
            out VkFormatProperties2 pFormatProperties);

        public delegate VkResult vkGetPhysicalDeviceImageFormatProperties2KHR(
            VkPhysicalDevice physicalDevice, 
            VkPhysicalDeviceImageFormatInfo2 pImageFormatInfo,
            out VkImageFormatProperties2 pImageFormatProperties);

        public delegate void vkGetPhysicalDeviceQueueFamilyProperties2KHR(
            VkPhysicalDevice physicalDevice, 
            ref uint pQueueFamilyPropertyCount, 
            VkQueueFamilyProperties2[] pQueueFamilyProperties);

        public delegate void vkGetPhysicalDeviceMemoryProperties2KHR(
            VkPhysicalDevice physicalDevice,
            out VkPhysicalDeviceMemoryProperties2 pMemoryProperties);

        public delegate void vkGetPhysicalDeviceSparseImageFormatProperties2KHR(
            VkPhysicalDevice physicalDevice, 
            VkPhysicalDeviceSparseImageFormatInfo2 pFormatInfo, 
            ref uint pPropertyCount, 
            VkSparseImageFormatProperties2[] pProperties);

        public delegate void vkGetDeviceGroupPeerMemoryFeaturesKHR(
            VkDevice device, 
            uint heapIndex, 
            uint localDeviceIndex, 
            uint remoteDeviceIndex,
            out VkPeerMemoryFeatureFlags pPeerMemoryFeatures);

        public delegate void vkCmdSetDeviceMaskKHR(
            VkCommandBuffer commandBuffer, 
            uint deviceMask);

        public delegate void vkCmdDispatchBaseKHR(
            VkCommandBuffer commandBuffer, 
            uint baseGroupX, uint baseGroupY, uint baseGroupZ, 
            uint groupCountX, uint groupCountY, uint groupCountZ);

        public delegate void vkTrimCommandPoolKHR(
            VkDevice device, 
            VkCommandPool commandPool, 
            VkCommandPoolTrimFlags flags);

        
        public delegate VkResult vkEnumeratePhysicalDeviceGroupsKHR(
            VkInstance instance,
            ref uint pPhysicalDeviceGroupCount,
            VkPhysicalDeviceGroupProperties[] pPhysicalDeviceGroupProperties);

        public delegate void vkGetPhysicalDeviceExternalBufferPropertiesKHR(
            VkPhysicalDevice physicalDevice,
             VkPhysicalDeviceExternalBufferInfo pExternalBufferInfo,
            out VkExternalBufferProperties pExternalBufferProperties);

        public delegate VkResult vkGetMemoryFdKHR(
            VkDevice device,
             VkMemoryGetFdInfoKHR pGetFdInfo,
            out int pFd);

        public delegate VkResult vkGetMemoryFdPropertiesKHR(
            VkDevice device,
            VkExternalMemoryHandleTypeFlags handleType,
            int fd,
            out VkMemoryFdPropertiesKHR pMemoryFdProperties);

        public delegate void vkGetPhysicalDeviceExternalSemaphorePropertiesKHR(
            VkPhysicalDevice physicalDevice,
             VkPhysicalDeviceExternalSemaphoreInfo pExternalSemaphoreInfo,
            out VkExternalSemaphoreProperties pExternalSemaphoreProperties);

        public delegate VkResult vkImportSemaphoreFdKHR(
            VkDevice device,
            VkImportSemaphoreFdInfoKHR pImportSemaphoreFdInfo);

        public delegate VkResult vkGetSemaphoreFdKHR(
            VkDevice device,
            VkSemaphoreGetFdInfoKHR pGetFdInfo,
            out int pFd);

        public delegate void vkCmdPushDescriptorSetKHR(
            VkCommandBuffer commandBuffer,
            VkPipelineBindPoint pipelineBindPoint,
            VkPipelineLayout layout,
            uint set,
            uint descriptorWriteCount,
            VkWriteDescriptorSet[] pDescriptorWrites);

        public delegate void vkCmdPushDescriptorSetWithTemplateKHR(
            VkCommandBuffer commandBuffer,
            VkDescriptorUpdateTemplate descriptorUpdateTemplate,
            VkPipelineLayout layout,
            uint set,
            IntPtr pData);

        public delegate VkResult vkCreateDescriptorUpdateTemplateKHR(
            VkDevice device,
            VkDescriptorUpdateTemplateCreateInfo pCreateInfo,
            VkAllocationCallbacks pAllocator,
            out VkDescriptorUpdateTemplate pDescriptorUpdateTemplate);

        public delegate void vkDestroyDescriptorUpdateTemplateKHR(
            VkDevice device,
            VkDescriptorUpdateTemplate descriptorUpdateTemplate,
            VkAllocationCallbacks pAllocator);

        public delegate void vkUpdateDescriptorSetWithTemplateKHR(
            VkDevice device,
            VkDescriptorSet descriptorSet,
            VkDescriptorUpdateTemplate descriptorUpdateTemplate,
            IntPtr pData);

        public delegate VkResult vkCreateRenderPass2KHR(
            VkDevice device,
            VkRenderPassCreateInfo2 pCreateInfo,
            VkAllocationCallbacks pAllocator,
            out VkRenderPass pRenderPass);

        public delegate void vkCmdBeginRenderPass2KHR(
            VkCommandBuffer commandBuffer,
             VkRenderPassBeginInfo pRenderPassBegin,
             VkSubpassBeginInfo pSubpassBeginInfo);

        public delegate void vkCmdNextSubpass2KHR(
            VkCommandBuffer commandBuffer,
            VkSubpassBeginInfo pSubpassBeginInfo,
            VkSubpassEndInfo pSubpassEndInfo);

        public delegate void vkCmdEndRenderPass2KHR(
            VkCommandBuffer commandBuffer,
            VkSubpassEndInfo pSubpassEndInfo);

        public delegate VkResult vkGetSwapchainStatusKHR(
            VkDevice device,
            VkSwapchainKHR swapchain);

        public delegate void vkGetPhysicalDeviceExternalFencePropertiesKHR(
            VkPhysicalDevice physicalDevice,
            VkPhysicalDeviceExternalFenceInfo pExternalFenceInfo,
            out VkExternalFenceProperties pExternalFenceProperties);

        public delegate VkResult vkImportFenceFdKHR(
            VkDevice device,
            VkImportFenceFdInfoKHR pImportFenceFdInfo);

        public delegate VkResult vkGetFenceFdKHR(
            VkDevice device,
            VkFenceGetFdInfoKHR pGetFdInfo,
            out int pFd);

        public delegate VkResult vkEnumeratePhysicalDeviceQueueFamilyPerformanceQueryCountersKHR(
            VkPhysicalDevice physicalDevice,
            uint queueFamilyIndex,
            ref uint pCounterCount,
            VkPerformanceCounterKHR[] pCounters,
            VkPerformanceCounterDescriptionKHR[] pCounterDescriptions);

        public delegate void vkGetPhysicalDeviceQueueFamilyPerformanceQueryPassesKHR(
            VkPhysicalDevice physicalDevice,
            VkQueryPoolPerformanceCreateInfoKHR pPerformanceQueryCreateInfo,
            out uint pNumPasses);

        public delegate VkResult vkAcquireProfilingLockKHR(
            VkDevice device,
            out VkAcquireProfilingLockInfoKHR pInfo);

        public delegate void vkReleaseProfilingLockKHR(
            VkDevice device);

        public delegate VkResult vkGetPhysicalDeviceSurfaceCapabilities2KHR(
            VkPhysicalDevice physicalDevice,
            VkPhysicalDeviceSurfaceInfo2KHR pSurfaceInfo,
            out VkSurfaceCapabilities2KHR pSurfaceCapabilities);

        public delegate VkResult vkGetPhysicalDeviceSurfaceFormats2KHR(
            VkPhysicalDevice physicalDevice,
            VkPhysicalDeviceSurfaceInfo2KHR pSurfaceInfo,
            ref uint pSurfaceFormatCount,
            VkSurfaceFormat2KHR[] pSurfaceFormats);

        public delegate VkResult vkGetPhysicalDeviceDisplayProperties2KHR(
            VkPhysicalDevice physicalDevice,
            ref uint pPropertyCount,
            VkDisplayProperties2KHR[] pProperties);

        public delegate VkResult vkGetPhysicalDeviceDisplayPlaneProperties2KHR(
            VkPhysicalDevice physicalDevice,
            ref uint pPropertyCount,
            VkDisplayPlaneProperties2KHR[] pProperties);

        public delegate VkResult vkGetDisplayModeProperties2KHR(
            VkPhysicalDevice physicalDevice,
            VkDisplayKHR display,
            ref uint pPropertyCount,
            VkDisplayModeProperties2KHR pProperties);

        public delegate VkResult vkGetDisplayPlaneCapabilities2KHR(
            VkPhysicalDevice physicalDevice,
            VkDisplayPlaneInfo2KHR pDisplayPlaneInfo,
            out VkDisplayPlaneCapabilities2KHR pCapabilities);

        public delegate void vkGetImageMemoryRequirements2KHR(
            VkDevice device,
            VkImageMemoryRequirementsInfo2 pInfo,
            out VkMemoryRequirements2 pMemoryRequirements);

        public delegate void vkGetBufferMemoryRequirements2KHR(
            VkDevice device,
            VkBufferMemoryRequirementsInfo2 pInfo,
            out VkMemoryRequirements2 pMemoryRequirements);

        public delegate void vkGetImageSparseMemoryRequirements2KHR(
            VkDevice device,
            VkImageSparseMemoryRequirementsInfo2 pInfo,
            ref uint pSparseMemoryRequirementCount,
            VkSparseImageMemoryRequirements2[] pSparseMemoryRequirements);

        public delegate VkResult vkCreateSamplerYcbcrConversionKHR(
            VkDevice device,
            VkSamplerYcbcrConversionCreateInfo pCreateInfo,
            VkAllocationCallbacks pAllocator,
            out VkSamplerYcbcrConversion pYcbcrConversion);

        public delegate void vkDestroySamplerYcbcrConversionKHR(
            VkDevice device,
            VkSamplerYcbcrConversion ycbcrConversion,
            VkAllocationCallbacks pAllocator);

        public delegate VkResult vkBindBufferMemory2KHR(
            VkDevice device,
            uint bindInfoCount,
            VkBindBufferMemoryInfo[] pBindInfos);

        public delegate VkResult vkBindImageMemory2KHR(
            VkDevice device,
            uint bindInfoCount,
            VkBindImageMemoryInfo[] pBindInfos);
        
        public delegate void vkGetDescriptorSetLayoutSupportKHR(
            VkDevice device,
            VkDescriptorSetLayoutCreateInfo pCreateInfo,
            out VkDescriptorSetLayoutSupport pSupport);

        public delegate void vkCmdDrawIndirectCountKHR(
            VkCommandBuffer commandBuffer,
            VkBuffer buffer,
            ulong offset,
            VkBuffer countBuffer,
            ulong countBufferOffset,
            uint maxDrawCount,
            uint stride);

        public delegate void vkCmdDrawIndexedIndirectCountKHR(
            VkCommandBuffer commandBuffer,
            VkBuffer buffer,
            ulong offset,
            VkBuffer countBuffer,
            ulong countBufferOffset,
            uint maxDrawCount,
            uint stride);

        public delegate VkResult vkGetSemaphoreCounterValueKHR(
            VkDevice device,
            VkSemaphore semaphore,
            out ulong pValue);

        public delegate VkResult vkWaitSemaphoresKHR(
            VkDevice device,
            VkSemaphoreWaitInfo pWaitInfo,
            ulong timeout);

        public delegate VkResult vkSignalSemaphoreKHR(
            VkDevice device,
            VkSemaphoreSignalInfo pSignalInfo);

        public delegate VkResult vkGetPhysicalDeviceFragmentShadingRatesKHR(
            VkPhysicalDevice physicalDevice,
            ref uint pFragmentShadingRateCount,
            VkPhysicalDeviceFragmentShadingRateKHR[] pFragmentShadingRates);

        public delegate void vkCmdSetFragmentShadingRateKHR(
            VkCommandBuffer commandBuffer,
            VkExtent2D pFragmentSize,
            VkFragmentShadingRateCombinerOpKHR[] combinerOps /*[2]*/);

        public delegate VkResult vkWaitForPresentKHR(
            VkDevice device,
            VkSwapchainKHR swapchain,
            ulong presentId,
            ulong timeout);


        public delegate ulong vkGetBufferDeviceAddressKHR(
            VkDevice device,
            VkBufferDeviceAddressInfo pInfo);

        public delegate ulong vkGetBufferOpaqueCaptureAddressKHR(
            VkDevice device,
            VkBufferDeviceAddressInfo pInfo);

        public delegate ulong vkGetDeviceMemoryOpaqueCaptureAddressKHR(
            VkDevice device,
            VkDeviceMemoryOpaqueCaptureAddressInfo pInfo);

        public delegate VkResult vkCreateDeferredOperationKHR(
            VkDevice device,
            VkAllocationCallbacks pAllocator,
            out VkDeferredOperationKHR pDeferredOperation);

        public delegate void vkDestroyDeferredOperationKHR(
            VkDevice device,
            VkDeferredOperationKHR operation,
            VkAllocationCallbacks pAllocator);

        public delegate uint vkGetDeferredOperationMaxConcurrencyKHR(
            VkDevice device,
            VkDeferredOperationKHR operation);

        public delegate VkResult vkGetDeferredOperationResultKHR(
            VkDevice device,
            VkDeferredOperationKHR operation);

        public delegate VkResult vkDeferredOperationJoinKHR(
            VkDevice device,
            VkDeferredOperationKHR operation);

        public delegate VkResult vkGetPipelineExecutablePropertiesKHR(
            VkDevice device,
            VkPipelineInfoKHR pPipelineInfo,
            ref uint pExecutableCount,
            VkPipelineExecutablePropertiesKHR[] pProperties);

        public delegate VkResult vkGetPipelineExecutableStatisticsKHR(
            VkDevice device,
            VkPipelineExecutableInfoKHR pExecutableInfo,
            ref uint pStatisticCount,
            VkPipelineExecutableStatisticKHR[] pStatistics);

        public delegate VkResult vkGetPipelineExecutableInternalRepresentationsKHR(
            VkDevice device,
            VkPipelineExecutableInfoKHR pExecutableInfo,
            ref uint pInternalRepresentationCount,
            VkPipelineExecutableInternalRepresentationKHR[] pInternalRepresentations);

        public delegate void vkCmdSetEvent2KHR(
            VkCommandBuffer commandBuffer,
            VkEvent evt,
            VkDependencyInfo pDependencyInfo);

        public delegate void vkCmdResetEvent2KHR(
            VkCommandBuffer commandBuffer,
            VkEvent evt,
            VkPipelineStageFlags2 stageMask);

        public delegate void vkCmdWaitEvents2KHR(
            VkCommandBuffer commandBuffer,
            uint eventCount,
            VkEvent[] pEvents,
            VkDependencyInfo[] pDependencyInfos);

        public delegate void vkCmdPipelineBarrier2KHR(
            VkCommandBuffer commandBuffer,
            VkDependencyInfo pDependencyInfo);

        public delegate void vkCmdWriteTimestamp2KHR(
            VkCommandBuffer commandBuffer,
            VkPipelineStageFlags2 stage,
            VkQueryPool queryPool,
            uint query);

        public delegate VkResult vkQueueSubmit2KHR(
            VkQueue queue,
            uint submitCount,
            VkSubmitInfo2[] pSubmits,
            VkFence fence);

        public delegate void vkCmdWriteBufferMarker2AMD(
            VkCommandBuffer commandBuffer,
            VkPipelineStageFlags2 stage,
            VkBuffer dstBuffer,
            ulong dstOffset,
            uint marker);

        public delegate void vkGetQueueCheckpointData2NV(
            VkQueue queue,
            ref uint pCheckpointDataCount,
            VkCheckpointData2NV[] pCheckpointData);

        public delegate void vkCmdCopyBuffer2KHR(
            VkCommandBuffer commandBuffer,
            VkCopyBufferInfo2 pCopyBufferInfo);

        public delegate void vkCmdCopyImage2KHR(
            VkCommandBuffer commandBuffer,
            VkCopyImageInfo2 pCopyImageInfo);

        public delegate void vkCmdCopyBufferToImage2KHR(
            VkCommandBuffer commandBuffer,
            VkCopyBufferToImageInfo2 pCopyBufferToImageInfo);

        public delegate void vkCmdCopyImageToBuffer2KHR(
            VkCommandBuffer commandBuffer,
            VkCopyImageToBufferInfo2 pCopyImageToBufferInfo);

        public delegate void vkCmdBlitImage2KHR(
            VkCommandBuffer commandBuffer,
            VkBlitImageInfo2 pBlitImageInfo);

        public delegate void vkCmdResolveImage2KHR(
            VkCommandBuffer commandBuffer,
            VkResolveImageInfo2 pResolveImageInfo);

        public delegate void vkCmdTraceRaysIndirect2KHR(
            VkCommandBuffer commandBuffer,
            ulong indirectDeviceAddress);

        public delegate void vkGetDeviceBufferMemoryRequirementsKHR(
            VkDevice device,
            VkDeviceBufferMemoryRequirements pInfo,
            out VkMemoryRequirements2 pMemoryRequirements);

        public delegate void vkGetDeviceImageMemoryRequirementsKHR(
            VkDevice device,
            VkDeviceImageMemoryRequirements pInfo,
            out VkMemoryRequirements2 pMemoryRequirements);

        public delegate void vkGetDeviceImageSparseMemoryRequirementsKHR(
            VkDevice device,
            VkDeviceImageMemoryRequirements pInfo,
            ref uint pSparseMemoryRequirementCount,
            VkSparseImageMemoryRequirements2[] pSparseMemoryRequirements);

        public delegate VkResult vkCreateDebugReportCallbackEXT(
            VkInstance instance,
            VkDebugReportCallbackCreateInfoEXT pCreateInfo,
            VkAllocationCallbacks pAllocator,
            VkDebugReportCallbackEXT pCallback);

        public delegate void vkDestroyDebugReportCallbackEXT(
            VkInstance instance,
            VkDebugReportCallbackEXT callback,
            VkAllocationCallbacks pAllocator);

        public delegate void vkDebugReportMessageEXT(
            VkInstance instance,
            VkDebugReportFlagsEXT flags,
            VkDebugReportObjectTypeEXT objectType,
            ulong obj,
            int location,
            int messageCode,
            string pLayerPrefix,
            string pMessage);
        
        public delegate VkResult vkDebugMarkerSetObjectTagEXT(
            VkDevice device,
            VkDebugMarkerObjectTagInfoEXT pTagInfo);

        public delegate VkResult vkDebugMarkerSetObjectNameEXT(
            VkDevice device,
            VkDebugMarkerObjectNameInfoEXT pNameInfo);

        public delegate void vkCmdDebugMarkerBeginEXT(
            VkCommandBuffer commandBuffer,
            VkDebugMarkerMarkerInfoEXT pMarkerInfo);

        public delegate void vkCmdDebugMarkerEndEXT(
            VkCommandBuffer commandBuffer);

        public delegate void vkCmdDebugMarkerInsertEXT(
            VkCommandBuffer commandBuffer,
            VkDebugMarkerMarkerInfoEXT pMarkerInfo);

        public delegate void vkCmdBindTransformFeedbackBuffersEXT(
            VkCommandBuffer commandBuffer,
            uint firstBinding,
            uint bindingCount,
            VkBuffer[] pBuffers,
            ulong[] pOffsets,
            ulong[] pSizes);

        public delegate void vkCmdBeginTransformFeedbackEXT(
            VkCommandBuffer commandBuffer,
            uint firstCounterBuffer,
            uint counterBufferCount,
            VkBuffer[] pCounterBuffers,
            ulong[] pCounterBufferOffsets);

        public delegate void vkCmdEndTransformFeedbackEXT(
            VkCommandBuffer commandBuffer,
            uint firstCounterBuffer,
            uint counterBufferCount,
            VkBuffer[] pCounterBuffers,
            ulong[] pCounterBufferOffsets);

        public delegate void vkCmdBeginQueryIndexedEXT(
            VkCommandBuffer commandBuffer,
            VkQueryPool queryPool,
            uint query,
            VkQueryControlFlags flags,
            uint index);

        public delegate void vkCmdEndQueryIndexedEXT(
            VkCommandBuffer commandBuffer,
            VkQueryPool queryPool,
            uint query,
            uint index);

        public delegate void vkCmdDrawIndirectByteCountEXT(
            VkCommandBuffer commandBuffer,
            uint instanceCount,
            uint firstInstance,
            VkBuffer counterBuffer,
            ulong counterBufferOffset,
            uint counterOffset,
            uint vertexStride);

        public delegate VkResult vkCreateCuModuleNVX(
            VkDevice device,
            VkCuModuleCreateInfoNVX pCreateInfo,
            VkAllocationCallbacks pAllocator,
            out VkCuModuleNVX pModule);

        public delegate VkResult vkCreateCuFunctionNVX(
            VkDevice device,
            VkCuFunctionCreateInfoNVX pCreateInfo,
            VkAllocationCallbacks pAllocator,
            out VkCuFunctionNVX pFunction);

        public delegate void vkDestroyCuModuleNVX(
            VkDevice device,
            VkCuModuleNVX module,
            VkAllocationCallbacks pAllocator);

        public delegate void vkDestroyCuFunctionNVX(
            VkDevice device,
            VkCuFunctionNVX function,
            VkAllocationCallbacks pAllocator);

        public delegate void vkCmdCuLaunchKernelNVX(
            VkCommandBuffer commandBuffer,
            VkCuLaunchInfoNVX pLaunchInfo);

        public delegate uint vkGetImageViewHandleNVX(
            VkDevice device,
            out VkImageViewHandleInfoNVX pInfo);

        public delegate VkResult vkGetImageViewAddressNVX(
            VkDevice device,
            VkImageView imageView,
            out VkImageViewAddressPropertiesNVX pProperties);

        public delegate void vkCmdDrawIndirectCountAMD(
            VkCommandBuffer commandBuffer,
            VkBuffer buffer,
            ulong offset,
            VkBuffer countBuffer,
            ulong countBufferOffset,
            uint maxDrawCount,
            uint stride);

        public delegate void vkCmdDrawIndexedIndirectCountAMD(
            VkCommandBuffer commandBuffer,
            VkBuffer buffer,
            ulong offset,
            VkBuffer countBuffer,
            ulong countBufferOffset,
            uint maxDrawCount,
            uint stride);

        public delegate VkResult vkGetShaderInfoAMD(
            VkDevice device,
            VkPipeline pipeline,
            VkShaderStageFlags shaderStage,
            VkShaderInfoTypeAMD infoType,
            ref int pInfoSize,
            out IntPtr pInfo);

        public delegate VkResult vkGetPhysicalDeviceExternalImageFormatPropertiesNV(
            VkPhysicalDevice physicalDevice,
            VkFormat format,
            VkImageType type,
            VkImageTiling tiling,
            VkImageUsageFlags usage,
            VkImageCreateFlags flags,
            VkExternalMemoryHandleTypeFlagsNV externalHandleType,
            out VkExternalImageFormatPropertiesNV pExternalImageFormatProperties);

        public delegate void vkCmdBeginConditionalRenderingEXT(
            VkCommandBuffer commandBuffer,
            VkConditionalRenderingBeginInfoEXT pConditionalRenderingBegin);

        public delegate void vkCmdEndConditionalRenderingEXT(
            VkCommandBuffer commandBuffer);

        public delegate void vkCmdSetViewportWScalingNV(
            VkCommandBuffer commandBuffer,
            uint firstViewport,
            uint viewportCount,
            VkViewportWScalingNV[] pViewportWScalings);


        public delegate VkResult vkReleaseDisplayEXT(
            VkPhysicalDevice physicalDevice,
            VkDisplayKHR display);

        public delegate VkResult vkGetPhysicalDeviceSurfaceCapabilities2EXT(
            VkPhysicalDevice physicalDevice,
            VkSurfaceKHR surface,
            out VkSurfaceCapabilities2EXT pSurfaceCapabilities);

        public delegate VkResult vkDisplayPowerControlEXT(
            VkDevice device,
            VkDisplayKHR display,
            VkDisplayPowerInfoEXT pDisplayPowerInfo);

        public delegate VkResult vkRegisterDeviceEventEXT(
            VkDevice device,
            VkDeviceEventInfoEXT pDeviceEventInfo,
            VkAllocationCallbacks pAllocator,
            out VkFence pFence);

        public delegate VkResult vkRegisterDisplayEventEXT(
            VkDevice device,
            VkDisplayKHR display,
            VkDisplayEventInfoEXT pDisplayEventInfo,
            VkAllocationCallbacks pAllocator,
            out VkFence pFence);

        public delegate VkResult vkGetSwapchainCounterEXT(
            VkDevice device,
            VkSwapchainKHR swapchain,
            VkSurfaceCounterFlagsEXT counter,
            out ulong pCounterValue);

        public delegate VkResult vkGetRefreshCycleDurationGOOGLE(
            VkDevice device,
            VkSwapchainKHR swapchain,
            out VkRefreshCycleDurationGOOGLE pDisplayTimingProperties);

        public delegate VkResult vkGetPastPresentationTimingGOOGLE(
            VkDevice device,
            VkSwapchainKHR swapchain,
            ref uint pPresentationTimingCount,
            VkPastPresentationTimingGOOGLE[] pPresentationTimings);

        public delegate void vkCmdSetDiscardRectangleEXT(
            VkCommandBuffer commandBuffer,
            uint firstDiscardRectangle,
            uint discardRectangleCount,
            VkRect2D[] pDiscardRectangles);

        public delegate void vkSetHdrMetadataEXT(
            VkDevice device,
            uint swapchainCount,
            VkSwapchainKHR[] pSwapchains,
            VkHdrMetadataEXT[] pMetadata);

        public delegate VkResult vkSetDebugUtilsObjectNameEXT(
            VkDevice device,
            VkDebugUtilsObjectNameInfoEXT pNameInfo);

        public delegate VkResult vkSetDebugUtilsObjectTagEXT(
            VkDevice device,
            VkDebugUtilsObjectTagInfoEXT pTagInfo);

        public delegate void vkQueueBeginDebugUtilsLabelEXT(
            VkQueue queue,
            VkDebugUtilsLabelEXT pLabelInfo);

        public delegate void vkQueueEndDebugUtilsLabelEXT(
            VkQueue queue);

        public delegate void vkQueueInsertDebugUtilsLabelEXT(
            VkQueue queue,
            VkDebugUtilsLabelEXT pLabelInfo);

        public delegate void vkCmdBeginDebugUtilsLabelEXT(
            VkCommandBuffer commandBuffer,
            VkDebugUtilsLabelEXT pLabelInfo);

        public delegate void vkCmdEndDebugUtilsLabelEXT(
            VkCommandBuffer commandBuffer);

        public delegate void vkCmdInsertDebugUtilsLabelEXT(
            VkCommandBuffer commandBuffer,
            VkDebugUtilsLabelEXT pLabelInfo);

        public delegate VkResult vkCreateDebugUtilsMessengerEXT(
            VkInstance instance,
            VkDebugUtilsMessengerCreateInfoEXT pCreateInfo,
            VkAllocationCallbacks pAllocator,
            out VkDebugUtilsMessengerEXT pMessenger);

        public delegate void vkDestroyDebugUtilsMessengerEXT(
            VkInstance instance,
            VkDebugUtilsMessengerEXT messenger,
            VkAllocationCallbacks pAllocator);

        public delegate void vkSubmitDebugUtilsMessageEXT(
            VkInstance instance,
            VkDebugUtilsMessageSeverityFlagBitsEXT messageSeverity,
            VkDebugUtilsMessageTypeFlagsEXT messageTypes,
            VkDebugUtilsMessengerCallbackDataEXT pCallbackData);

        public delegate void vkCmdSetSampleLocationsEXT(
            VkCommandBuffer commandBuffer,
            VkSampleLocationsInfoEXT pSampleLocationsInfo);

        public delegate void vkGetPhysicalDeviceMultisamplePropertiesEXT(
            VkPhysicalDevice physicalDevice,
            VkSampleCountFlags samples,
            out VkMultisamplePropertiesEXT pMultisampleProperties);

        public delegate VkResult vkGetImageDrmFormatModifierPropertiesEXT(
            VkDevice device,
            VkImage image,
            out VkImageDrmFormatModifierPropertiesEXT pProperties);
        
        public delegate VkResult vkCreateValidationCacheEXT(
            VkDevice device,
            VkValidationCacheCreateInfoEXT pCreateInfo,
            VkAllocationCallbacks pAllocator,
            out VkValidationCacheEXT pValidationCache);

        public delegate void vkDestroyValidationCacheEXT(
            VkDevice device,
            VkValidationCacheEXT validationCache,
            VkAllocationCallbacks pAllocator);

        public delegate VkResult vkMergeValidationCachesEXT(
            VkDevice device,
            VkValidationCacheEXT dstCache,
            uint srcCacheCount,
            VkValidationCacheEXT[] pSrcCaches);

        public delegate VkResult vkGetValidationCacheDataEXT(
            VkDevice device,
            VkValidationCacheEXT validationCache,
            ref int pDataSize,
            IntPtr pData);

        public delegate void vkCmdBindShadingRateImageNV(
            VkCommandBuffer commandBuffer,
            VkImageView imageView,
            VkImageLayout imageLayout);

        public delegate void vkCmdSetViewportShadingRatePaletteNV(
            VkCommandBuffer commandBuffer,
            uint firstViewport,
            uint viewportCount,
            VkShadingRatePaletteNV[] pShadingRatePalettes);

        public delegate void vkCmdSetCoarseSampleOrderNV(
            VkCommandBuffer commandBuffer,
            VkCoarseSampleOrderTypeNV sampleOrderType,
            uint customSampleOrderCount,
            VkCoarseSampleOrderCustomNV[] pCustomSampleOrders);

        public delegate VkResult vkCreateAccelerationStructureNV(
            VkDevice device,
            VkAccelerationStructureCreateInfoNV pCreateInfo,
            VkAllocationCallbacks pAllocator,
            out VkAccelerationStructureNV pAccelerationStructure);

        public delegate void vkDestroyAccelerationStructureNV(
            VkDevice device,
            VkAccelerationStructureNV accelerationStructure,
            VkAllocationCallbacks pAllocator);

        public delegate void vkGetAccelerationStructureMemoryRequirementsNV(
            VkDevice device,
            VkAccelerationStructureMemoryRequirementsInfoNV pInfo,
            out VkMemoryRequirements2 pMemoryRequirements);

        public delegate VkResult vkBindAccelerationStructureMemoryNV(
            VkDevice device,
            uint bindInfoCount,
            VkBindAccelerationStructureMemoryInfoNV[] pBindInfos);

        public delegate void vkCmdBuildAccelerationStructureNV(
            VkCommandBuffer commandBuffer,
            VkAccelerationStructureInfoNV pInfo,
            VkBuffer instanceData,
            ulong instanceOffset,
            Bool32 update,
            VkAccelerationStructureNV dst,
            VkAccelerationStructureNV src,
            VkBuffer scratch,
            ulong scratchOffset);

        public delegate void vkCmdCopyAccelerationStructureNV(
            VkCommandBuffer commandBuffer,
            VkAccelerationStructureNV dst,
            VkAccelerationStructureNV src,
            VkCopyAccelerationStructureModeKHR mode);

        public delegate void vkCmdTraceRaysNV(
            VkCommandBuffer commandBuffer,
            VkBuffer raygenShaderBindingTableBuffer,
            ulong raygenShaderBindingOffset,
            VkBuffer missShaderBindingTableBuffer,
            ulong missShaderBindingOffset,
            ulong missShaderBindingStride,
            VkBuffer hitShaderBindingTableBuffer,
            ulong hitShaderBindingOffset,
            ulong hitShaderBindingStride,
            VkBuffer callableShaderBindingTableBuffer,
            ulong callableShaderBindingOffset,
            ulong callableShaderBindingStride,
            uint width,
            uint height,
            uint depth);

        public delegate VkResult vkCreateRayTracingPipelinesNV(
            VkDevice device,
            VkPipelineCache pipelineCache,
            uint createInfoCount,
            VkRayTracingPipelineCreateInfoNV[] pCreateInfos,
            VkAllocationCallbacks pAllocator,
            out VkPipeline pPipelines);

        public delegate VkResult vkGetRayTracingShaderGroupHandlesKHR(
            VkDevice device,
            VkPipeline pipeline,
            uint firstGroup,
            uint groupCount,
            int dataSize,
            IntPtr pData);

        public delegate VkResult vkGetRayTracingShaderGroupHandlesNV(
            VkDevice device,
            VkPipeline pipeline,
            uint firstGroup,
            uint groupCount,
            int dataSize,
            IntPtr pData);

        public delegate VkResult vkGetAccelerationStructureHandleNV(
            VkDevice device,
            VkAccelerationStructureNV accelerationStructure,
            int dataSize,
            IntPtr pData);

        public delegate void vkCmdWriteAccelerationStructuresPropertiesNV(
            VkCommandBuffer commandBuffer,
            uint accelerationStructureCount,
            VkAccelerationStructureNV[] pAccelerationStructures,
            VkQueryType queryType,
            VkQueryPool queryPool,
            uint firstQuery);

        public delegate VkResult vkCompileDeferredNV(
            VkDevice device,
            VkPipeline pipeline,
            uint shader);

        public delegate VkResult vkGetMemoryHostPointerPropertiesEXT(
            VkDevice device,
            VkExternalMemoryHandleTypeFlags handleType,
            IntPtr pHostPointer,
            out VkMemoryHostPointerPropertiesEXT pMemoryHostPointerProperties);

        public delegate void vkCmdWriteBufferMarkerAMD(
            VkCommandBuffer commandBuffer,
            VkPipelineStageFlags pipelineStage,
            VkBuffer dstBuffer,
            ulong dstOffset,
            uint marker);

        public delegate VkResult vkGetPhysicalDeviceCalibrateableTimeDomainsEXT(
            VkPhysicalDevice physicalDevice,
            ref uint pTimeDomainCount,
            VkTimeDomainEXT[] pTimeDomains);

        public delegate VkResult vkGetCalibratedTimestampsEXT(
            VkDevice device,
            uint timestampCount,
            VkCalibratedTimestampInfoEXT[] pTimestampInfos,
            ulong[] pTimestamps,
            ulong[] pMaxDeviation);

        public delegate void vkCmdDrawMeshTasksNV(
            VkCommandBuffer commandBuffer,
            uint taskCount,
            uint firstTask);

        public delegate void vkCmdDrawMeshTasksIndirectNV(
            VkCommandBuffer commandBuffer,
            VkBuffer buffer,
            ulong offset,
            uint drawCount,
            uint stride);

        public delegate void vkCmdDrawMeshTasksIndirectCountNV(
            VkCommandBuffer commandBuffer,
            VkBuffer buffer,
            ulong offset,
            VkBuffer countBuffer,
            ulong countBufferOffset,
            uint maxDrawCount,
            uint stride);

        public delegate void vkCmdSetExclusiveScissorNV(
            VkCommandBuffer commandBuffer,
            uint firstExclusiveScissor,
            uint exclusiveScissorCount,
            VkRect2D[] pExclusiveScissors);

        public delegate void vkCmdSetCheckpointNV(
            VkCommandBuffer commandBuffer,
            IntPtr pCheckpointMarker);

        public delegate void vkGetQueueCheckpointDataNV(
            VkQueue queue,
            ref uint pCheckpointDataCount,
            VkCheckpointDataNV[] pCheckpointData);

        public delegate VkResult vkInitializePerformanceApiINTEL(
            VkDevice device,
            VkInitializePerformanceApiInfoINTEL pInitializeInfo);

        public delegate void vkUninitializePerformanceApiINTEL(
            VkDevice device);

        public delegate VkResult vkCmdSetPerformanceMarkerINTEL(
            VkCommandBuffer commandBuffer,
            VkPerformanceMarkerInfoINTEL pMarkerInfo);

        public delegate VkResult vkCmdSetPerformanceStreamMarkerINTEL(
            VkCommandBuffer commandBuffer,
            VkPerformanceStreamMarkerInfoINTEL pMarkerInfo);

        public delegate VkResult vkCmdSetPerformanceOverrideINTEL(
            VkCommandBuffer commandBuffer,
            VkPerformanceOverrideInfoINTEL pOverrideInfo);

        public delegate VkResult vkAcquirePerformanceConfigurationINTEL(
            VkDevice device,
            VkPerformanceConfigurationAcquireInfoINTEL pAcquireInfo,
            out VkPerformanceConfigurationINTEL pConfiguration);

        public delegate VkResult vkReleasePerformanceConfigurationINTEL(
            VkDevice device,
            VkPerformanceConfigurationINTEL configuration);

        public delegate VkResult vkQueueSetPerformanceConfigurationINTEL(
            VkQueue queue,
            VkPerformanceConfigurationINTEL configuration);

        public delegate VkResult vkGetPerformanceParameterINTEL(
            VkDevice device,
            VkPerformanceParameterTypeINTEL parameter,
            out VkPerformanceValueINTEL pValue);

        public delegate void vkSetLocalDimmingAMD(
            VkDevice device,
            VkSwapchainKHR swapChain,
            Bool32 localDimmingEnable);

        public delegate ulong vkGetBufferDeviceAddressEXT(
            VkDevice device,
            out VkBufferDeviceAddressInfo pInfo);

        public delegate VkResult vkGetPhysicalDeviceToolPropertiesEXT(
            VkPhysicalDevice physicalDevice,
            ref uint pToolCount,
            VkPhysicalDeviceToolProperties[] pToolProperties);

        public delegate VkResult vkGetPhysicalDeviceCooperativeMatrixPropertiesNV(
            VkPhysicalDevice physicalDevice,
            ref uint pPropertyCount,
            VkCooperativeMatrixPropertiesNV[] pProperties);

        public delegate VkResult vkGetPhysicalDeviceSupportedFramebufferMixedSamplesCombinationsNV(
            VkPhysicalDevice physicalDevice,
            ref uint pCombinationCount,
            VkFramebufferMixedSamplesCombinationNV[] pCombinations);

        public delegate VkResult vkCreateHeadlessSurfaceEXT(
            VkInstance instance,
            VkHeadlessSurfaceCreateInfoEXT pCreateInfo,
            VkAllocationCallbacks pAllocator,
            out VkSurfaceKHR pSurface);

        public delegate void vkResetQueryPoolEXT(
            VkDevice device,
            VkQueryPool queryPool,
            uint firstQuery,
            uint queryCount);

        public delegate void vkCmdSetCullModeEXT(
            VkCommandBuffer commandBuffer,
            VkCullModeFlags cullMode);

        public delegate void vkCmdSetFrontFaceEXT(
            VkCommandBuffer commandBuffer,
            VkFrontFace frontFace);

        public delegate void vkCmdSetPrimitiveTopologyEXT(
            VkCommandBuffer commandBuffer,
            VkPrimitiveTopology primitiveTopology);

        public delegate void vkCmdSetViewportWithCountEXT(
            VkCommandBuffer commandBuffer,
            uint viewportCount,
            VkViewport[] pViewports);

        public delegate void vkCmdSetScissorWithCountEXT(
            VkCommandBuffer commandBuffer,
            uint scissorCount,
            VkRect2D[] pScissors);

        public delegate void vkCmdBindVertexBuffers2EXT(
            VkCommandBuffer commandBuffer,
            uint firstBinding,
            uint bindingCount,
            VkBuffer[] pBuffers,
            ulong[] pOffsets,
            ulong[] pSizes,
            ulong[] pStrides);

        public delegate void vkCmdSetDepthTestEnableEXT(
            VkCommandBuffer commandBuffer,
            Bool32 depthTestEnable);

        public delegate void vkCmdSetDepthWriteEnableEXT(
            VkCommandBuffer commandBuffer,
            Bool32 depthWriteEnable);

        public delegate void vkCmdSetDepthCompareOpEXT(
            VkCommandBuffer commandBuffer,
            VkCompareOp depthCompareOp);

        public delegate void vkCmdSetDepthBoundsTestEnableEXT(
            VkCommandBuffer commandBuffer,
            Bool32 depthBoundsTestEnable);

        public delegate void vkCmdSetStencilTestEnableEXT(
            VkCommandBuffer commandBuffer,
            Bool32 stencilTestEnable);

        public delegate void vkCmdSetStencilOpEXT(
            VkCommandBuffer commandBuffer,
            VkStencilFaceFlags faceMask,
            VkStencilOp failOp,
            VkStencilOp passOp,
            VkStencilOp depthFailOp,
            VkCompareOp compareOp);

        public delegate void vkGetGeneratedCommandsMemoryRequirementsNV(
            VkDevice device,
            VkGeneratedCommandsMemoryRequirementsInfoNV pInfo,
            out VkMemoryRequirements2 pMemoryRequirements);

        public delegate void vkCmdPreprocessGeneratedCommandsNV(
            VkCommandBuffer commandBuffer,
            VkGeneratedCommandsInfoNV pGeneratedCommandsInfo);

        public delegate void vkCmdExecuteGeneratedCommandsNV(
            VkCommandBuffer commandBuffer,
            Bool32 isPreprocessed,
            VkGeneratedCommandsInfoNV pGeneratedCommandsInfo);

        public delegate void vkCmdBindPipelineShaderGroupNV(
            VkCommandBuffer commandBuffer,
            VkPipelineBindPoint pipelineBindPoint,
            VkPipeline pipeline,
            uint groupIndex);

        public delegate VkResult vkCreateIndirectCommandsLayoutNV(
            VkDevice device,
            VkIndirectCommandsLayoutCreateInfoNV pCreateInfo,
            VkAllocationCallbacks pAllocator,
            out VkIndirectCommandsLayoutNV pIndirectCommandsLayout);

        public delegate void vkDestroyIndirectCommandsLayoutNV(
            VkDevice device,
            VkIndirectCommandsLayoutNV indirectCommandsLayout,
            VkAllocationCallbacks pAllocator);

        public delegate VkResult vkAcquireDrmDisplayEXT(
            VkPhysicalDevice physicalDevice,
            int drmFd,
            VkDisplayKHR display);

        public delegate VkResult vkGetDrmDisplayEXT(
            VkPhysicalDevice physicalDevice,
            int drmFd,
            uint connectorId,
            out VkDisplayKHR display);

        public delegate VkResult vkCreatePrivateDataSlotEXT(
            VkDevice device,
            VkPrivateDataSlotCreateInfo pCreateInfo,
            VkAllocationCallbacks pAllocator,
            out VkPrivateDataSlot pPrivateDataSlot);

        public delegate void vkDestroyPrivateDataSlotEXT(
            VkDevice device,
            VkPrivateDataSlot privateDataSlot,
            VkAllocationCallbacks pAllocator);

        public delegate VkResult vkSetPrivateDataEXT(
            VkDevice device,
            VkObjectType objectType,
            ulong objectHandle,
            VkPrivateDataSlot privateDataSlot,
            ulong data);

        public delegate void vkGetPrivateDataEXT(
            VkDevice device,
            VkObjectType objectType,
            ulong objectHandle,
            VkPrivateDataSlot privateDataSlot,
            IntPtr pData);

        public delegate void vkGetDescriptorSetLayoutSizeEXT(
            VkDevice device,
            VkDescriptorSetLayout layout,
            out ulong pLayoutSizeInBytes);

        public delegate void vkGetDescriptorSetLayoutBindingOffsetEXT(
            VkDevice device,
            VkDescriptorSetLayout layout,
            uint binding,
            out ulong pOffset);

        public delegate void vkGetDescriptorEXT(
            VkDevice device,
            VkDescriptorGetInfoEXT pDescriptorInfo,
            int dataSize,
            IntPtr pDescriptor);

        public delegate void vkCmdBindDescriptorBuffersEXT(
            VkCommandBuffer commandBuffer,
            uint bufferCount,
            VkDescriptorBufferBindingInfoEXT[] pBindingInfos);

        public delegate void vkCmdSetDescriptorBufferOffsetsEXT(
            VkCommandBuffer commandBuffer,
            VkPipelineBindPoint pipelineBindPoint,
            VkPipelineLayout layout,
            uint firstSet,
            uint setCount,
            uint[] pBufferIndices,
            ulong[] pOffsets);

        public delegate void vkCmdBindDescriptorBufferEmbeddedSamplersEXT(
            VkCommandBuffer commandBuffer,
            VkPipelineBindPoint pipelineBindPoint,
            VkPipelineLayout layout,
            uint set);

        public delegate VkResult vkGetBufferOpaqueCaptureDescriptorDataEXT(
            VkDevice device,
            VkBufferCaptureDescriptorDataInfoEXT pInfo,
            out IntPtr pData);

        public delegate VkResult vkGetImageOpaqueCaptureDescriptorDataEXT(
            VkDevice device,
            VkImageCaptureDescriptorDataInfoEXT pInfo,
            out IntPtr pData);

        public delegate VkResult vkGetImageViewOpaqueCaptureDescriptorDataEXT(
            VkDevice device,
            VkImageViewCaptureDescriptorDataInfoEXT pInfo,
            out IntPtr pData);

        public delegate VkResult vkGetSamplerOpaqueCaptureDescriptorDataEXT(
            VkDevice device,
            VkSamplerCaptureDescriptorDataInfoEXT pInfo,
            out IntPtr pData);

        public delegate VkResult vkGetAccelerationStructureOpaqueCaptureDescriptorDataEXT(
            VkDevice device,
            VkAccelerationStructureCaptureDescriptorDataInfoEXT pInfo,
            IntPtr pData);

        public delegate void vkCmdSetFragmentShadingRateEnumNV(
            VkCommandBuffer commandBuffer,
            VkFragmentShadingRateNV shadingRate,
            VkFragmentShadingRateCombinerOpKHR[] combinerOps/*[2]*/);

        public delegate void vkGetImageSubresourceLayout2EXT(
            VkDevice device,
            VkImage image,
            VkImageSubresource2EXT pSubresource,
            out VkSubresourceLayout2EXT pLayout);

        public delegate VkResult vkGetDeviceFaultInfoEXT(
            VkDevice device,
            VkDeviceFaultCountsEXT pFaultCounts,
            out VkDeviceFaultInfoEXT pFaultInfo);

        public delegate void vkCmdSetVertexInputEXT(
            VkCommandBuffer commandBuffer,
            uint vertexBindingDescriptionCount,
            VkVertexInputBindingDescription2EXT pVertexBindingDescriptions,
            uint vertexAttributeDescriptionCount,
            VkVertexInputAttributeDescription2EXT[] pVertexAttributeDescriptions);

        public delegate VkResult vkGetDeviceSubpassShadingMaxWorkgroupSizeHUAWEI(
            VkDevice device,
            VkRenderPass renderpass,
            out VkExtent2D pMaxWorkgroupSize);

        public delegate void vkCmdSubpassShadingHUAWEI(
            VkCommandBuffer commandBuffer);

        public delegate void vkCmdBindInvocationMaskHUAWEI(
            VkCommandBuffer commandBuffer,
            VkImageView imageView,
            VkImageLayout imageLayout);

        public delegate VkResult vkGetMemoryRemoteAddressNV(
            VkDevice device,
            VkMemoryGetRemoteAddressInfoNV pMemoryGetRemoteAddressInfo,
            out IntPtr pAddress);

        public delegate VkResult vkGetPipelinePropertiesEXT(
            VkDevice device,
            VkPipelineInfoKHR pPipelineInfo,
            out VkBaseOutStructure pPipelineProperties);

        public delegate void vkCmdSetPatchControlPointsEXT(
            VkCommandBuffer commandBuffer,
            uint patchControlPoints);

        public delegate void vkCmdSetRasterizerDiscardEnableEXT(
            VkCommandBuffer commandBuffer,
            Bool32 rasterizerDiscardEnable);

        public delegate void vkCmdSetDepthBiasEnableEXT(
            VkCommandBuffer commandBuffer,
            Bool32 depthBiasEnable);

        public delegate void vkCmdSetLogicOpEXT(
            VkCommandBuffer commandBuffer,
            VkLogicOp logicOp);

        public delegate void vkCmdSetPrimitiveRestartEnableEXT(
            VkCommandBuffer commandBuffer,
            Bool32 primitiveRestartEnable);

        public delegate void vkCmdSetColorWriteEnableEXT(
            VkCommandBuffer commandBuffer,
            uint attachmentCount,
            out Bool32 pColorWriteEnables);

        public delegate void vkCmdDrawMultiEXT(
            VkCommandBuffer commandBuffer,
            uint drawCount,
            VkMultiDrawInfoEXT pVertexInfo,
            uint instanceCount,
            uint firstInstance,
            uint stride);

        public delegate void vkCmdDrawMultiIndexedEXT(
            VkCommandBuffer commandBuffer,
            uint drawCount,
            VkMultiDrawIndexedInfoEXT pIndexInfo,
            uint instanceCount,
            uint firstInstance,
            uint stride,
            out int pVertexOffset);

        public delegate VkResult vkCreateMicromapEXT(
            VkDevice device,
            VkMicromapCreateInfoEXT pCreateInfo,
            VkAllocationCallbacks pAllocator,
            out VkMicromapEXT pMicromap);

        public delegate void vkDestroyMicromapEXT(
            VkDevice device,
            VkMicromapEXT micromap,
            VkAllocationCallbacks pAllocator);

        public delegate void vkCmdBuildMicromapsEXT(
            VkCommandBuffer commandBuffer,
            uint infoCount,
            VkMicromapBuildInfoEXT[] pInfos);

        public delegate VkResult vkBuildMicromapsEXT(
            VkDevice device,
            VkDeferredOperationKHR deferredOperation,
            uint infoCount,
            VkMicromapBuildInfoEXT[] pInfos);

        public delegate VkResult vkCopyMicromapEXT(
            VkDevice device,
            VkDeferredOperationKHR deferredOperation,
            VkCopyMicromapInfoEXT pInfo);

        public delegate VkResult vkCopyMicromapToMemoryEXT(
            VkDevice device,
            VkDeferredOperationKHR deferredOperation,
            VkCopyMicromapToMemoryInfoEXT pInfo);

        public delegate VkResult vkCopyMemoryToMicromapEXT(
            VkDevice device,
            VkDeferredOperationKHR deferredOperation,
            VkCopyMemoryToMicromapInfoEXT pInfo);

        public delegate VkResult vkWriteMicromapsPropertiesEXT(
            VkDevice device,
            uint micromapCount,
            VkMicromapEXT[] pMicromaps,
            VkQueryType queryType,
            int dataSize,
            IntPtr pData,
            int stride);

        public delegate void vkCmdCopyMicromapEXT(
            VkCommandBuffer commandBuffer,
            VkCopyMicromapInfoEXT pInfo);

        public delegate void vkCmdCopyMicromapToMemoryEXT(
            VkCommandBuffer commandBuffer,
            VkCopyMicromapToMemoryInfoEXT pInfo);

        public delegate void vkCmdCopyMemoryToMicromapEXT(
            VkCommandBuffer commandBuffer,
            VkCopyMemoryToMicromapInfoEXT pInfo);

        public delegate void vkCmdWriteMicromapsPropertiesEXT(
            VkCommandBuffer commandBuffer,
            uint micromapCount,
            VkMicromapEXT pMicromaps,
            VkQueryType queryType,
            VkQueryPool queryPool,
            uint firstQuery);

        public delegate void vkGetDeviceMicromapCompatibilityEXT(
            VkDevice device,
            VkMicromapVersionInfoEXT pVersionInfo,
            out VkAccelerationStructureCompatibilityKHR pCompatibility);

        public delegate void vkGetMicromapBuildSizesEXT(
            VkDevice device,
            VkAccelerationStructureBuildTypeKHR buildType,
            VkMicromapBuildInfoEXT pBuildInfo,
            out VkMicromapBuildSizesInfoEXT pSizeInfo);

        public delegate void vkSetDeviceMemoryPriorityEXT(
            VkDevice device,
            VkDeviceMemory memory,
            float priority);
        
        public delegate void vkGetDescriptorSetLayoutHostMappingInfoVALVE(
            VkDevice device,
            VkDescriptorSetBindingReferenceVALVE pBindingReference,
            VkDescriptorSetLayoutHostMappingInfoVALVE pHostMapping);

        public delegate void vkGetDescriptorSetHostMappingVALVE(
            VkDevice device,
            VkDescriptorSet descriptorSet,
            IntPtr ppData);

        public delegate void vkCmdCopyMemoryIndirectNV(
            VkCommandBuffer commandBuffer,
            ulong copyBufferAddress,
            uint copyCount,
            uint stride);

        public delegate void vkCmdCopyMemoryToImageIndirectNV(
            VkCommandBuffer commandBuffer,
            ulong copyBufferAddress,
            uint copyCount,
            uint stride,
            VkImage dstImage,
            VkImageLayout dstImageLayout,
            VkImageSubresourceLayers pImageSubresources);

        public delegate void vkCmdDecompressMemoryNV(
            VkCommandBuffer commandBuffer,
            uint decompressRegionCount,
            VkDecompressMemoryRegionNV[] pDecompressMemoryRegions);

        public delegate void vkCmdDecompressMemoryIndirectCountNV(
            VkCommandBuffer commandBuffer,
            ulong indirectCommandsAddress,
            ulong indirectCommandsCountAddress,
            uint stride);

        public delegate void vkCmdSetTessellationDomainOriginEXT(
            VkCommandBuffer commandBuffer,
            VkTessellationDomainOrigin domainOrigin);

        public delegate void vkCmdSetDepthClampEnableEXT(
            VkCommandBuffer commandBuffer,
            Bool32 depthClampEnable);

        public delegate void vkCmdSetPolygonModeEXT(
            VkCommandBuffer commandBuffer,
            VkPolygonMode polygonMode);

        public delegate void vkCmdSetRasterizationSamplesEXT(
            VkCommandBuffer commandBuffer,
            VkSampleCountFlags rasterizationSamples);

        public delegate void vkCmdSetSampleMaskEXT(
            VkCommandBuffer commandBuffer,
            VkSampleCountFlags samples,
            uint pSampleMask);

        public delegate void vkCmdSetAlphaToCoverageEnableEXT(
            VkCommandBuffer commandBuffer,
            Bool32 alphaToCoverageEnable);

        public delegate void vkCmdSetAlphaToOneEnableEXT(
            VkCommandBuffer commandBuffer,
            Bool32 alphaToOneEnable);

        public delegate void vkCmdSetLogicOpEnableEXT(
            VkCommandBuffer commandBuffer,
            Bool32 logicOpEnable);

        public delegate void vkCmdSetColorBlendEnableEXT(
            VkCommandBuffer commandBuffer,
            uint firstAttachment,
            uint attachmentCount,
            uint[] /*bool*/ pColorBlendEnables);

        public delegate void vkCmdSetColorBlendEquationEXT(
            VkCommandBuffer commandBuffer,
            uint firstAttachment,
            uint attachmentCount,
            VkColorBlendEquationEXT[] pColorBlendEquations);

        public delegate void vkCmdSetColorWriteMaskEXT(
            VkCommandBuffer commandBuffer,
            uint firstAttachment,
            uint attachmentCount,
            VkColorComponentFlags[] pColorWriteMasks);

        public delegate void vkCmdSetRasterizationStreamEXT(
            VkCommandBuffer commandBuffer,
            uint rasterizationStream);

        public delegate void vkCmdSetConservativeRasterizationModeEXT(
            VkCommandBuffer commandBuffer,
            VkConservativeRasterizationModeEXT conservativeRasterizationMode);

        public delegate void vkCmdSetExtraPrimitiveOverestimationSizeEXT(
            VkCommandBuffer commandBuffer,
            float extraPrimitiveOverestimationSize);

        public delegate void vkCmdSetDepthClipEnableEXT(
            VkCommandBuffer commandBuffer,
            Bool32 depthClipEnable);

        public delegate void vkCmdSetSampleLocationsEnableEXT(
            VkCommandBuffer commandBuffer,
            Bool32 sampleLocationsEnable);

        public delegate void vkCmdSetColorBlendAdvancedEXT(
            VkCommandBuffer commandBuffer,
            uint firstAttachment,
            uint attachmentCount,
            VkColorBlendAdvancedEXT[] pColorBlendAdvanced);

        public delegate void vkCmdSetProvokingVertexModeEXT(
            VkCommandBuffer commandBuffer,
            VkProvokingVertexModeEXT provokingVertexMode);

        public delegate void vkCmdSetLineRasterizationModeEXT(
            VkCommandBuffer commandBuffer,
            VkLineRasterizationModeEXT lineRasterizationMode);

        public delegate void vkCmdSetLineStippleEnableEXT(
            VkCommandBuffer commandBuffer,
            Bool32 stippledLineEnable);

        public delegate void vkCmdSetDepthClipNegativeOneToOneEXT(
            VkCommandBuffer commandBuffer,
            Bool32 negativeOneToOne);

        public delegate void vkCmdSetViewportWScalingEnableNV(
            VkCommandBuffer commandBuffer,
            Bool32 viewportWScalingEnable);

        public delegate void vkCmdSetViewportSwizzleNV(
            VkCommandBuffer commandBuffer,
            uint firstViewport,
            uint viewportCount,
            VkViewportSwizzleNV[] pViewportSwizzles);

        public delegate void vkCmdSetCoverageToColorEnableNV(
            VkCommandBuffer commandBuffer,
            Bool32 coverageToColorEnable);

        public delegate void vkCmdSetCoverageToColorLocationNV(
            VkCommandBuffer commandBuffer,
            uint coverageToColorLocation);

        public delegate void vkCmdSetCoverageModulationModeNV(
            VkCommandBuffer commandBuffer,
            VkCoverageModulationModeNV coverageModulationMode);

        public delegate void vkCmdSetCoverageModulationTableEnableNV(
            VkCommandBuffer commandBuffer,
            Bool32 coverageModulationTableEnable);

        public delegate void vkCmdSetCoverageModulationTableNV(
            VkCommandBuffer commandBuffer,
            uint coverageModulationTableCount,
            float[] pCoverageModulationTable);

        public delegate void vkCmdSetShadingRateImageEnableNV(
            VkCommandBuffer commandBuffer,
            Bool32 shadingRateImageEnable);

        public delegate void vkCmdSetRepresentativeFragmentTestEnableNV(
            VkCommandBuffer commandBuffer,
            Bool32 representativeFragmentTestEnable);

        public delegate void vkCmdSetCoverageReductionModeNV(
            VkCommandBuffer commandBuffer,
            VkCoverageReductionModeNV coverageReductionMode);

        public delegate void vkGetShaderModuleIdentifierEXT(
            VkDevice device,
            VkShaderModule shaderModule,
            out VkShaderModuleIdentifierEXT pIdentifier);

        public delegate void vkGetShaderModuleCreateInfoIdentifierEXT(
            VkDevice device,
            VkShaderModuleCreateInfo pCreateInfo,
            out VkShaderModuleIdentifierEXT pIdentifier);

        public delegate VkResult vkGetPhysicalDeviceOpticalFlowImageFormatsNV(
            VkPhysicalDevice physicalDevice,
            VkOpticalFlowImageFormatInfoNV pOpticalFlowImageFormatInfo,
            ref uint pFormatCount,
            VkOpticalFlowImageFormatPropertiesNV[] pImageFormatProperties);

        public delegate VkResult vkCreateOpticalFlowSessionNV(
            VkDevice device,
            VkOpticalFlowSessionCreateInfoNV pCreateInfo,
            VkAllocationCallbacks pAllocator,
            out VkOpticalFlowSessionNV pSession);

        public delegate void vkDestroyOpticalFlowSessionNV(
            VkDevice device,
            VkOpticalFlowSessionNV session,
             VkAllocationCallbacks pAllocator);

        public delegate VkResult vkBindOpticalFlowSessionImageNV(
            VkDevice device,
            VkOpticalFlowSessionNV session,
            VkOpticalFlowSessionBindingPointNV bindingPoint,
            VkImageView view,
            VkImageLayout layout);

        public delegate void vkCmdOpticalFlowExecuteNV(
            VkCommandBuffer commandBuffer,
            VkOpticalFlowSessionNV session,
            VkOpticalFlowExecuteInfoNV pExecuteInfo);

        public delegate VkResult vkGetFramebufferTilePropertiesQCOM(
            VkDevice device,
            VkFramebuffer framebuffer,
            ref uint pPropertiesCount,
            VkTilePropertiesQCOM[] pProperties);

        public delegate VkResult vkGetDynamicRenderingTilePropertiesQCOM(
            VkDevice device,
            VkRenderingInfo pRenderingInfo,
            out VkTilePropertiesQCOM pProperties);

        public delegate VkResult vkCreateAccelerationStructureKHR(
            VkDevice device,
            VkAccelerationStructureCreateInfoKHR pCreateInfo,
            VkAllocationCallbacks pAllocator,
            out VkAccelerationStructureKHR pAccelerationStructure);

        public delegate void vkDestroyAccelerationStructureKHR(
            VkDevice device,
            VkAccelerationStructureKHR accelerationStructure,
             VkAllocationCallbacks pAllocator);

        public delegate void vkCmdBuildAccelerationStructuresKHR(
            VkCommandBuffer commandBuffer,
            uint infoCount,
            VkAccelerationStructureBuildGeometryInfoKHR[] pInfos,
            VkAccelerationStructureBuildRangeInfoKHR[] ppBuildRangeInfos);

        public delegate void vkCmdBuildAccelerationStructuresIndirectKHR(
            VkCommandBuffer commandBuffer,
            uint infoCount,
            VkAccelerationStructureBuildGeometryInfoKHR[] pInfos,
            ulong[] pIndirectDeviceAddresses,
            uint[] pIndirectStrides,
            uint[] ppMaxPrimitiveCounts);

        public delegate VkResult vkBuildAccelerationStructuresKHR(
            VkDevice device,
            VkDeferredOperationKHR deferredOperation,
            uint infoCount,
            VkAccelerationStructureBuildGeometryInfoKHR[] pInfos,
            VkAccelerationStructureBuildRangeInfoKHR[] ppBuildRangeInfos);

        public delegate VkResult vkCopyAccelerationStructureKHR(
            VkDevice device,
            VkDeferredOperationKHR deferredOperation,
            VkCopyAccelerationStructureInfoKHR pInfo);

        public delegate VkResult vkCopyAccelerationStructureToMemoryKHR(
            VkDevice device,
            VkDeferredOperationKHR deferredOperation,
            VkCopyAccelerationStructureToMemoryInfoKHR pInfo);

        public delegate VkResult vkCopyMemoryToAccelerationStructureKHR(
            VkDevice device,
            VkDeferredOperationKHR deferredOperation,
            VkCopyMemoryToAccelerationStructureInfoKHR pInfo);

        public delegate VkResult vkWriteAccelerationStructuresPropertiesKHR(
            VkDevice device,
            uint accelerationStructureCount,
            VkAccelerationStructureKHR pAccelerationStructures,
            VkQueryType queryType,
            int dataSize,
            IntPtr pData,
            int stride);

        public delegate void vkCmdCopyAccelerationStructureKHR(
            VkCommandBuffer commandBuffer,
            VkCopyAccelerationStructureInfoKHR pInfo);

        public delegate void vkCmdCopyAccelerationStructureToMemoryKHR(
            VkCommandBuffer commandBuffer,
            VkCopyAccelerationStructureToMemoryInfoKHR pInfo);

        public delegate void vkCmdCopyMemoryToAccelerationStructureKHR(
            VkCommandBuffer commandBuffer,
            VkCopyMemoryToAccelerationStructureInfoKHR pInfo);

        public delegate ulong vkGetAccelerationStructureDeviceAddressKHR(
            VkDevice device,
            VkAccelerationStructureDeviceAddressInfoKHR pInfo);

        public delegate void vkCmdWriteAccelerationStructuresPropertiesKHR(
            VkCommandBuffer commandBuffer,
            uint accelerationStructureCount,
            VkAccelerationStructureKHR[] pAccelerationStructures,
            VkQueryType queryType,
            VkQueryPool queryPool,
            uint firstQuery);

        public delegate void vkGetDeviceAccelerationStructureCompatibilityKHR(
            VkDevice device,
            VkAccelerationStructureVersionInfoKHR pVersionInfo,
            out VkAccelerationStructureCompatibilityKHR pCompatibility);

        public delegate void vkGetAccelerationStructureBuildSizesKHR(
            VkDevice device,
            VkAccelerationStructureBuildTypeKHR buildType,
            VkAccelerationStructureBuildGeometryInfoKHR pBuildInfo,
            ref uint pMaxPrimitiveCounts,
            VkAccelerationStructureBuildSizesInfoKHR[] pSizeInfo);

        public delegate void vkCmdTraceRaysKHR(
            VkCommandBuffer commandBuffer,
            VkStridedDeviceAddressRegionKHR pRaygenShaderBindingTable,
            VkStridedDeviceAddressRegionKHR pMissShaderBindingTable,
            VkStridedDeviceAddressRegionKHR pHitShaderBindingTable,
            VkStridedDeviceAddressRegionKHR pCallableShaderBindingTable,
            uint width,
            uint height,
            uint depth);

        public delegate VkResult vkCreateRayTracingPipelinesKHR(
            VkDevice device,
            VkDeferredOperationKHR deferredOperation,
            VkPipelineCache pipelineCache,
            uint createInfoCount,
            VkRayTracingPipelineCreateInfoKHR pCreateInfos,
            VkAllocationCallbacks pAllocator,
            out VkPipeline pPipelines);

        public delegate VkResult vkGetRayTracingCaptureReplayShaderGroupHandlesKHR(
            VkDevice device,
            VkPipeline pipeline,
            uint firstGroup,
            uint groupCount,
            int dataSize,
            IntPtr pData);

        public delegate void vkCmdTraceRaysIndirectKHR(
            VkCommandBuffer commandBuffer,
            VkStridedDeviceAddressRegionKHR pRaygenShaderBindingTable,
            VkStridedDeviceAddressRegionKHR pMissShaderBindingTable,
            VkStridedDeviceAddressRegionKHR pHitShaderBindingTable,
            VkStridedDeviceAddressRegionKHR pCallableShaderBindingTable,
            ulong indirectDeviceAddress);

        public delegate ulong vkGetRayTracingShaderGroupStackSizeKHR(
            VkDevice device,
            VkPipeline pipeline,
            uint group,
            VkShaderGroupShaderKHR groupShader);

        public delegate void vkCmdSetRayTracingPipelineStackSizeKHR(
            VkCommandBuffer commandBuffer,
            uint pipelineStackSize);
        public delegate void vkCmdDrawMeshTasksEXT(
            VkCommandBuffer commandBuffer,
            uint groupCountX,
            uint groupCountY,
            uint groupCountZ);

        public delegate void vkCmdDrawMeshTasksIndirectEXT(
            VkCommandBuffer commandBuffer,
            VkBuffer buffer,
            ulong offset,
            uint drawCount,
            uint stride);

        public delegate void vkCmdDrawMeshTasksIndirectCountEXT(
            VkCommandBuffer commandBuffer,
            VkBuffer buffer,
            ulong offset,
            VkBuffer countBuffer,
            ulong countBufferOffset,
            uint maxDrawCount,
            uint stride);

        public delegate void vkCmdSetLineStippleEXT(
            VkCommandBuffer commandBuffer,
            uint lineStippleFactor,
            ushort lineStipplePattern);

    }
}