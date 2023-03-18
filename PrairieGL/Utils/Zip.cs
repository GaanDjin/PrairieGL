using System.IO.Compression;

namespace PrairieGL.Utils
{
    /// <summary>
    /// Helper Class to use System Compression. 
    /// Good for if compressed here then decompress here.
    /// Be warned there are some bugs in 
    /// dot.net that this may not decompress external compressed streams. 
    /// For those use the SharpZipLib from Nuget.
    /// </summary>
    public class Zip
    {
        /// <summary>
        /// Inputs an array of bytes and compresses them using the <see cref="DeflateStream"/>
        /// and then returns the compressed bytes.
        /// </summary>
        /// <param name="bytes">Data to compress</param>
        /// <returns>The compressed data</returns>
        public static byte[] Compress(byte[] bytes)
        {
            using (var compressStream = new MemoryStream())
            using (var compressor = new DeflateStream(compressStream, CompressionMode.Compress))
            {
                compressor.Write(bytes);
                compressor.Close();
                return compressStream.ToArray();
            }
        }

        /// <summary>
        /// Inputs an array of compressed bytes and deflates them using the <see cref="DeflateStream"/>
        /// and then returns the expanded bytes.
        /// </summary>
        /// <param name="compressedbytes">The compressed data</param>
        /// <returns>The expanded data</returns>
        public static byte[] Expand(byte[] compressedbytes)
        {
            var output = new MemoryStream();

            using (var compressStream = new MemoryStream(compressedbytes))
            using (var decompressor = new DeflateStream(compressStream, CompressionMode.Decompress))
                decompressor.CopyTo(output);

            output.Position = 0;
            return output.ToArray();
        }

    }
}
