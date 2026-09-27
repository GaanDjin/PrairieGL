using System.Text;

namespace PrairieGL.OpenGL
{

    public enum GLResourceType
    {
        Buffer,
        Texture,
        Renderbuffer,
        Framebuffer,
        Shader,
        Program,
        VertexArray
    }

    public class GLResourceInfo
    {
        public uint Id { get; set; }
        public GLResourceType Type { get; set; }
        public long SizeBytes { get; set; }   // optional for buffers/textures
        public DateTime Created { get; set; }
    }

    public class GLResourceTracker
    {
        private readonly Dictionary<GLResourceType, Dictionary<uint, GLResourceInfo>> _resources =
            new Dictionary<GLResourceType, Dictionary<uint, GLResourceInfo>>();

        // -------------------------------
        // ADD RESOURCE
        // -------------------------------
        public void Add(GLResourceType type, uint id, long sizeBytes = 0)
        {
            if (id == 0) return;

            if (!_resources.ContainsKey(type))
                _resources[type] = new Dictionary<uint, GLResourceInfo>();

            _resources[type][id] = new GLResourceInfo
            {
                Id = id,
                Type = type,
                SizeBytes = sizeBytes,
                Created = DateTime.Now
            };
        }

        // -------------------------------
        // REMOVE RESOURCE
        // -------------------------------
        public void Remove(GLResourceType type, uint id)
        {
            if (_resources.ContainsKey(type) && _resources[type].ContainsKey(id))
                _resources[type].Remove(id);
        }

        // -------------------------------
        // QUERY
        // -------------------------------
        public IEnumerable<GLResourceInfo> All() => _resources.Values.SelectMany(dict => dict.Values);

        public long TotalBytes()
        {
            long total = 0;
            foreach (var r in _resources.Values)
                foreach (var res in r.Values)
                    total += res.SizeBytes;
            return total;
        }

        public int Count(GLResourceType type)
        {
            int count = 0;
            foreach (var r in _resources[type].Values)
                if (r.Type == type)
                    count++;
            return count;
        }

        // -------------------------------
        // DEBUG PRINT
        // -------------------------------
        public override string ToString()
        {
            StringBuilder stringBuilder = new();
            stringBuilder.AppendLine("=== GPU Resource Tracker ===");   
            
            foreach(var type in _resources.Keys)
            {
                stringBuilder.AppendLine($"Type: {type}  Count: {_resources[type].Count}");
                foreach (var r in _resources[type].Values)
                {
                    stringBuilder.AppendLine($"{r.Type} #{r.Id}  Size={FormatBytes(r.SizeBytes)}  Created={r.Created}");
                }
            }
            stringBuilder.AppendLine($"Total GPU objects: {_resources.SelectMany(r => r.Value).Count()}");
            stringBuilder.AppendLine($"Total GPU memory: {FormatBytes(TotalBytes())}");
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Converts a byte size into a human-readable string (B, KB, MB, GB, TB, PB).
        /// </summary>
        /// <param name="bytes">The size in bytes.</param>
        /// <param name="decimalPlaces">Number of decimal places to display (default: 2).</param>
        /// <returns>Formatted size string.</returns>
        public static string FormatBytes(long bytes, int decimalPlaces = 2)
        {
            // Validate decimal places
            if (decimalPlaces < 0 || decimalPlaces > 10)
                throw new ArgumentOutOfRangeException(nameof(decimalPlaces), "Decimal places must be between 0 and 10.");

            // Handle negative values
            if (bytes < 0)
                return "-" + FormatBytes(-bytes, decimalPlaces);

            // Units
            string[] sizes = { "B", "KB", "MB", "GB", "TB", "PB" };

            // Handle zero explicitly
            if (bytes == 0)
                return $"0 {sizes[0]}";

            // Determine unit
            int order = (int)Math.Floor(Math.Log(bytes, 1024));
            order = Math.Min(order, sizes.Length - 1);

            // Calculate adjusted size
            double adjustedSize = bytes / Math.Pow(1024, order);

            // Format with rounding
            return $"{adjustedSize:F2} {sizes[order]}";
        }
    }
}
