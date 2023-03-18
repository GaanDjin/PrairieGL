
namespace TestPrairieGL.VulkanTutorials
{
    public struct QueueFamilyIndices
    {
        public uint? graphicsFamily;

        public bool isComplete()
        {
            return graphicsFamily != null;
        }
    };
}
