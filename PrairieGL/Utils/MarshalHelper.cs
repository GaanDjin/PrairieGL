using System.Runtime.InteropServices;
using System.Text;

namespace PrairieGL.Utils
{
    /// <summary>
    /// Helper functions for Marshalling data from Unmanaged DLLs.
    /// </summary>
    public class MarshalHelper
    {
        /// <summary>
        /// Copies a block of null terminated Utf8 text from memory 
        /// and converts it to a string.
        /// There is no gurad beyond the marshaller so invalid pointers will 
        /// throw garbage out until it reaches the first '\0' byte.
        /// </summary>
        /// <param name="nativeUtf8">The pointer to the text in memory</param>
        /// <returns>The string value of the text. 
        /// If the pointer is zero then null is returned.</returns>
        public static string PtrToStringUTF8(IntPtr nativeUtf8)
        {
            if (nativeUtf8 == IntPtr.Zero)
                return null;

            int len = 0;
            while (Marshal.ReadByte(nativeUtf8, len) != 0) ++len;
            byte[] buffer = new byte[len];
            Marshal.Copy(nativeUtf8, buffer, 0, buffer.Length);
            return Encoding.UTF8.GetString(buffer);
        }
    }
}
