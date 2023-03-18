using PrairieGL.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.Zip.Compression;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;

namespace PrairieGL.Utils
{
    /// <summary>
    /// A Basic PNG Decoder to read PNG images and return the pixel data.
    /// Some features like Interlacing are not supported.
    /// </summary>
    /// <remarks>
    /// http://www.libpng.org/pub/png/spec/1.2/
    /// https://github.com/Adamantcheese/PNG_Quantizer/blob/master/lodepng.c
    /// https://wiki.tcl-lang.org/page/PNG+Decoder
    /// TODO: Implement the Encoder part.
    /// </remarks>
    public class PNG
    {
        /// <summary>
        /// Reads a PNG image from a file and returns the pixel data. 
        /// 
        /// Currently the returned bytes are converted to floats in an RGB Layout.
        /// 1 Pixel = float[] { R, G, B, A }. 
        /// Making format and datasize kind of redunant but reserved for future use.
        /// </summary>
        /// <param name="filename">The file path containing the PNG image.</param>
        /// <param name="width">Returns the Width of the image</param>
        /// <param name="height">Returns the Height of the image</param>
        /// <param name="format">
        /// Returns the image format of the returned pixels. This may not match
        /// the data format stored in the PNG image itself
        /// </param>
        /// <param name="datasize">The size of each colour channel in the 
        /// returned pixels. This may not match the data size stored in the PNG
        /// image itself</param>
        /// <param name="flip">If true this image will be flipped upside down; 
        /// Otherwise the image will be in the same order it appears in the original PNG</param>
        /// <returns>An array of pixel data as described by format and datasize.</returns>
        /// <exception cref="Exception">
        /// Thrown if the PNG has invalid data.
        /// The Stream is Corrupted.
        /// The PNG is interlaced (Currently Not Supported).
        /// </exception>
        public static float[] Read(string filename, out int width, out int height, out ImagePixelFormats format, out ImagePixelDataTypes datasize, bool flip = false)
        {
            return Read(File.OpenRead(filename), out width, out height, out format, out datasize, flip);
        }

        /// <summary>
        /// Reads a PNG image from a Stream and returns the pixel data. 
        /// 
        /// Currently the returned bytes are converted to floats in an RGB Layout.
        /// 1 Pixel = float[] { R, G, B, A }. 
        /// Making format and datasize kind of redunant but reserved for future use.
        /// </summary>
        /// <param name="pngdata">The Stream containing the PNG image.</param>
        /// <param name="width">Returns the Width of the image</param>
        /// <param name="height">Returns the Height of the image</param>
        /// <param name="format">
        /// Returns the image format of the returned pixels. This may not match
        /// the data format stored in the PNG image itself
        /// </param>
        /// <param name="datasize">The size of each colour channel in the 
        /// returned pixels. This may not match the data size stored in the PNG
        /// image itself</param>
        /// <param name="flip">If true this image will be flipped upside down; 
        /// Otherwise the image will be in the same order it appears in the original PNG</param>
        /// <returns>An array of pixel data as described by format and datasize.</returns>
        /// <exception cref="Exception">
        /// Thrown if the PNG has invalid data.
        /// The Stream is Corrupted.
        /// The PNG is interlaced (Currently Not Supported).
        /// </exception>
        public static float[] Read(Stream pngdata, out int width, out int height, out ImagePixelFormats format, out ImagePixelDataTypes datasize, bool flip = false)
        {
            BinaryReader reader = new BinaryReader(pngdata);

            byte[] header = reader.ReadBytes(8);

            if (header[0] != 0x89 || header[1] != 0x50 || header[2] != 0x4E || header[3] != 0x47 ||
                header[4] != 0x0D || header[5] != 0x0A || header[6] != 0x1A || header[7] != 0x0A)
                throw new Exception("Invalid PNG Header!");

            PNGChunk IHDR = ReadChunk(reader);
            BinaryReader readerIHDR = IHDR.DataStream;
            width = ReadInt32(readerIHDR);
            height = ReadInt32(readerIHDR);
            byte bitDepth = readerIHDR.ReadByte();
            ColourType colorType = (ColourType)(readerIHDR.ReadByte() & 0x7);
            byte compressionMethod = readerIHDR.ReadByte();
            byte filterMethod = readerIHDR.ReadByte();
            InterlaceMethod interlaceMethod = (InterlaceMethod)readerIHDR.ReadByte();

            if (interlaceMethod != InterlaceMethod.None)
                throw new NotImplementedException("Interlaced PNGs are not supported.");

            //switch (colorType)
            //{
            //    case ColourType.GrascaleWithAlpha:
            //        format = ImagePixelFormats.GL_RGBA;
            //        break;
            //    case ColourType.Grayscale:
            //        format = ImagePixelFormats.GL_RGB;
            //        break;
            //    case ColourType.Indexed:
            //        format = ImagePixelFormats.GL_RGB;
            //        break;
            //    case ColourType.RGB:
            //        format = ImagePixelFormats.GL_RGB;
            //        break;
            //    case ColourType.RGBA:
            //        format = ImagePixelFormats.GL_RGBA;
            //        break;
            //    default:
            //        throw new Exception("Unexpected Pixel Format.");

            //}
            datasize = ImagePixelDataTypes.GL_FLOAT;
            format = ImagePixelFormats.GL_RGBA;

            /*
               Color    Allowed    Interpretation
   Type    Bit Depths

   0       1,2,4,8,16  Each pixel is a grayscale sample.

   2       8,16        Each pixel is an R,G,B triple.

   3       1,2,4,8     Each pixel is a palette index;
                       a PLTE chunk must appear.

   4       8,16        Each pixel is a grayscale sample,
                       followed by an alpha sample.

   6       8,16        Each pixel is an R,G,B triple,
                       followed by an alpha sample.
             */

            if (colorType == ColourType.Grayscale && (bitDepth != 1 && bitDepth != 2 && bitDepth != 4 && bitDepth != 8 && bitDepth != 16))
                throw new Exception("Grayscale png has an invalid bit depth.");
            else if (colorType == ColourType.RGB && (bitDepth != 8 && bitDepth != 16))
                throw new Exception("RGB png has an invalid bit depth.");
            else if (colorType == ColourType.Indexed && (bitDepth != 1 && bitDepth != 2 && bitDepth != 4 && bitDepth != 8))
                throw new Exception("Indexed png has an invalid bit depth.");
            else if (colorType == ColourType.GrascaleWithAlpha && (bitDepth != 8 && bitDepth != 16))
                throw new Exception("GrascaleWithAlpha png has an invalid bit depth.");
            else if (colorType == ColourType.RGBA && (bitDepth != 8 && bitDepth != 16))
                throw new Exception("RGBA png has an invalid bit depth.");

            if (compressionMethod != 0)
                throw new Exception("PNG has an invalid compression method.");
            if (filterMethod != 0)
                throw new Exception("PNG has an invalid filter method.");


            PNGChunk PLTE = new PNGChunk();
            //uint[] palette = new uint[0];
            byte[] data;

            //List<PNGChunk> imageData = new List<PNGChunk>();
            using (MemoryStream imageData = new MemoryStream())
            {

                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    PNGChunk currentChunk = ReadChunk(reader);

                    if (currentChunk.ChunkType == "PLTE")
                    {
                        PLTE = currentChunk;
                        //DecodePalette(PLTE);
                    }
                    else if (currentChunk.ChunkType == "IDAT")
                    {
                        // imageData.Add(currentChunk);
                        imageData.Write(currentChunk.Data);
                    }
                    else if (currentChunk.ChunkType == "IEND")
                        break;
                    else
                    {
                        //Ancillary chunks
                        /*
                        Other image attributes that can be stored in PNG files include gamma values, background color, and textual metadata information. PNG also supports color management through the inclusion of ICC color profiles.[20]

                        bKGD gives the default background color. It is intended for use when there is no better choice available, such as in standalone image viewers (but not web browsers; see below for more details).
                        cHRM gives the chromaticity coordinates of the display primaries and white point.
                        dSIG is for storing digital signatures.[21]
                        eXIf stores Exif metadata.[22]
                        gAMA specifies gamma. The gAMA chunk contains only 4 bytes, and its value represents the gamma value multiplied by 100,000; for example, the gamma value 1/3.4 calculates to 29411.7647059 ((1/3.4)*(100,000)) and is converted to an integer (29412) for storage.[23]
                        hIST can store the histogram, or total amount of each color in the image.
                        iCCP is an ICC color profile.
                        iTXt contains a keyword and UTF-8 text, with encodings for possible compression and translations marked with language tag. The Extensible Metadata Platform (XMP) uses this chunk with a keyword 'XML:com.adobe.xmp'
                        pHYs holds the intended pixel size (or pixel aspect ratio); the pHYs contains "Pixels per unit, X axis" (4 bytes), "Pixels per unit, Y axis" (4 bytes), and "Unit specifier" (1 byte) for a total of 9 bytes.[24]
                        sBIT (significant bits) indicates the color-accuracy of the source data; this chunk contains a total of between 1 and 5 bytes, depending on the color type.[25][26][27]
                        sPLT suggests a palette to use if the full range of colors is unavailable.
                        sRGB indicates that the standard sRGB color space is used; the sRGB chunk contains only 1 byte, which is used for "rendering intent" (4 values—0, 1, 2, and 3—are defined for rendering intent).[28]
                        sTER stereo-image indicator chunk for stereoscopic images.[29]
                        tEXt can store text that can be represented in ISO/IEC 8859-1, with one key-value pair for each chunk. The "key" must be between 1 and 79 characters long. Separator is a null character. The "value" can be any length, including zero up to the maximum permissible chunk size minus the length of the keyword and separator. Neither "key" nor "value" can contain null character. Leading or trailing spaces are also disallowed.
                        tIME stores the time that the image was last changed.
                        tRNS contains transparency information. For indexed images, it stores alpha channel values for one or more palette entries. For truecolor and grayscale images, it stores a single pixel value that is to be regarded as fully transparent.
                        zTXt contains compressed text (and a compression method marker) with the same limits as tEXt.
                        The lowercase first letter in these chunks indicates that they are not needed for the PNG specification. The lowercase last letter in some chunks indicates that they are safe to copy, even if the application concerned does not understand them.
                        */
                    }
                }

                imageData.Seek(0, SeekOrigin.Begin);
                data = Deflate(imageData.ToArray());
            }

            //byte[][] scanlines = new byte[height][];
            byte[][] output = new byte[height][];

            int scanlength = ((width * bitDepth + 7) / 8);
            switch (colorType)
            {
                case ColourType.RGB:
                    scanlength *= 3;
                    break;
                case ColourType.Indexed:
                    scanlength *= 1;
                    break;
                case ColourType.GrascaleWithAlpha:
                    scanlength *= 2;
                    break;
                case ColourType.Grayscale:
                    scanlength *= 1;
                    break;
                case ColourType.RGBA:
                    scanlength *= 4;
                    break;

            }
            int inputlinelength = scanlength + 1;

            int DataRowindex = 0;

            for (int i = 0; i < output.Length; i++)
            {

                int lineFilterMethod = data[i * inputlinelength];

                //scanlines[i] = new byte[scanlength];
                output[i] = new byte[scanlength];
                DataRowindex = (i * inputlinelength) + 1;

                if (flip)
                    Array.Copy(data, ((output.Length - i - 1) * inputlinelength) + 1, output[i], 0, scanlength);
                else
                    Array.Copy(data, (i * inputlinelength) + 1, output[i], 0, scanlength);

                unFilterScanline(out output[i], output[i], i > 0 ? output[i - 1] : null, (scanlength / width), lineFilterMethod, scanlength);
            }

            float[] colours = new float[width * height * 4];
            int coloursIndex = 0;

            //float r1, g1, b1;
            //float r2, g2, b2;
            //float r3, g3, b3;
            //float r4, g4, b4;
            //float r5, g5, b5;
            //float r6, g6, b6;
            //float r7, g7, b7;

            //float a1, a2, a3, a4, a5, a6, a7;
            //Stream tmpoutput = File.OpenWrite("Assets\\TestPNGBytesOut.dat");
            //MemoryStream outputBytes = new MemoryStream();
            for (int i = 0; i < output.Length; i++)
            {
                //outputBytes.Write(output[i]);
                //tmpoutput.Write(output[i]);
                for (int j = 0; j < output[i].Length;)
                {
                    //float a = 1, r = 0, g = 0, b = 0;
                    switch (colorType)
                    {
                        case ColourType.RGB:
                            //8,16        Each pixel is an R,G,B triple.

                            switch (bitDepth)
                            {
                                case 8:
                                    colours[coloursIndex++] = output[i][j] / 255.0f; //R
                                    colours[coloursIndex++] = output[i][j + 1] / 255.0f; //G
                                    colours[coloursIndex++] = output[i][j + 2] / 255.0f; //B
                                    colours[coloursIndex++] = 1; //A
                                    j += 3;
                                    break;
                                case 16:
                                    colours[coloursIndex++] = (output[i][j] << 8 | output[i][j + 1]) / 65535.0f;
                                    colours[coloursIndex++] = (output[i][j + 2] << 8 | output[i][j + 3]) / 65535.0f;
                                    colours[coloursIndex++] = (output[i][j + 4] << 8 | output[i][j + 5]) / 65535.0f;
                                    colours[coloursIndex++] = 1; //A
                                    j += 6;
                                    break;
                            }
                            break;
                        case ColourType.Indexed:
                            // 1,2,4,8     Each pixel is a palette index; a PLTE chunk must appear.
                            ///TODO: Implement me!
                            j++;
                            break;
                        case ColourType.GrascaleWithAlpha:
                            //8,16        Each pixel is a grayscale sample, followed by an alpha sample.

                            switch (bitDepth)
                            {
                                case 4:
                                    colours[coloursIndex++] = (output[i][j] >> 4) / 15f;
                                    colours[coloursIndex++] = (output[i][j] >> 4) / 15f;
                                    colours[coloursIndex++] = (output[i][j] >> 4) / 15f;
                                    colours[coloursIndex++] = (output[i][j + 1] >> 4) / 15f;


                                    colours[coloursIndex++] = (output[i][j] & 0xF) / 15f;
                                    colours[coloursIndex++] = (output[i][j] & 0xF) / 15f;
                                    colours[coloursIndex++] = (output[i][j] & 0xF) / 15f;
                                    colours[coloursIndex++] = (output[i][j + 1] & 0xF) / 15f;

                                    j += 1;
                                    break;
                                case 8:
                                    colours[coloursIndex++] = output[i][j] / 255.0f;
                                    colours[coloursIndex++] = output[i][j] / 255.0f;
                                    colours[coloursIndex++] = output[i][j] / 255.0f;
                                    colours[coloursIndex++] = output[i][j + 1] / 255.0f;

                                    j += 2;
                                    break;
                                case 16:
                                    colours[coloursIndex++] = (output[i][j] << 8 | output[i][j + 1]) / 65535.0f;
                                    colours[coloursIndex++] = (output[i][j] << 8 | output[i][j + 1]) / 65535.0f;
                                    colours[coloursIndex++] = (output[i][j] << 8 | output[i][j + 1]) / 65535.0f;
                                    colours[coloursIndex++] = (output[i][j + 2] << 8 | output[i][j + 3]) / 65535.0f;

                                    j += 4;
                                    break;
                            }
                            break;
                        case ColourType.Grayscale:
                            //1,2,4,8,16  Each pixel is a grayscale sample.
                            switch (bitDepth)
                            {
                                case 1:
                                    colours[coloursIndex++] = ((output[i][j] & 0x80) == 0x80) ? 1 : 0;
                                    colours[coloursIndex++] = ((output[i][j] & 0x80) == 0x80) ? 1 : 0;
                                    colours[coloursIndex++] = ((output[i][j] & 0x80) == 0x80) ? 1 : 0;
                                    colours[coloursIndex++] = 1;

                                    colours[coloursIndex++] = ((output[i][j] & 0x40) == 0x40) ? 1 : 0;
                                    colours[coloursIndex++] = ((output[i][j] & 0x40) == 0x40) ? 1 : 0;
                                    colours[coloursIndex++] = ((output[i][j] & 0x40) == 0x40) ? 1 : 0;
                                    colours[coloursIndex++] = 1;

                                    colours[coloursIndex++] = ((output[i][j] & 0x20) == 0x22) ? 1 : 0;
                                    colours[coloursIndex++] = ((output[i][j] & 0x20) == 0x22) ? 1 : 0;
                                    colours[coloursIndex++] = ((output[i][j] & 0x20) == 0x22) ? 1 : 0;
                                    colours[coloursIndex++] = 1;

                                    colours[coloursIndex++] = ((output[i][j] & 0x10) == 0x10) ? 1 : 0;
                                    colours[coloursIndex++] = ((output[i][j] & 0x10) == 0x10) ? 1 : 0;
                                    colours[coloursIndex++] = ((output[i][j] & 0x10) == 0x10) ? 1 : 0;
                                    colours[coloursIndex++] = 1;

                                    colours[coloursIndex++] = ((output[i][j] & 0x8) == 0x8) ? 1 : 0;
                                    colours[coloursIndex++] = ((output[i][j] & 0x8) == 0x8) ? 1 : 0;
                                    colours[coloursIndex++] = ((output[i][j] & 0x8) == 0x8) ? 1 : 0;
                                    colours[coloursIndex++] = 1;

                                    colours[coloursIndex++] = ((output[i][j] & 0x4) == 0x4) ? 1 : 0;
                                    colours[coloursIndex++] = ((output[i][j] & 0x4) == 0x4) ? 1 : 0;
                                    colours[coloursIndex++] = ((output[i][j] & 0x4) == 0x4) ? 1 : 0;
                                    colours[coloursIndex++] = 1;

                                    colours[coloursIndex++] = ((output[i][j] & 0x2) == 0x2) ? 1 : 0;
                                    colours[coloursIndex++] = ((output[i][j] & 0x2) == 0x2) ? 1 : 0;
                                    colours[coloursIndex++] = ((output[i][j] & 0x2) == 0x2) ? 1 : 0;
                                    colours[coloursIndex++] = 1;

                                    colours[coloursIndex++] = ((output[i][j] & 0x1) == 0x1) ? 1 : 0;
                                    colours[coloursIndex++] = ((output[i][j] & 0x1) == 0x1) ? 1 : 0;
                                    colours[coloursIndex++] = ((output[i][j] & 0x1) == 0x1) ? 1 : 0;
                                    colours[coloursIndex++] = 1;

                                    j += 1;
                                    break;
                                case 2:
                                    colours[coloursIndex++] = ((output[i][j] >> 6) & 0x3) / 3f;
                                    colours[coloursIndex++] = ((output[i][j] >> 6) & 0x3) / 3f;
                                    colours[coloursIndex++] = ((output[i][j] >> 6) & 0x3) / 3f;
                                    colours[coloursIndex++] = 1;

                                    colours[coloursIndex++] = ((output[i][j] >> 4) & 0x3) / 3f;
                                    colours[coloursIndex++] = ((output[i][j] >> 4) & 0x3) / 3f;
                                    colours[coloursIndex++] = ((output[i][j] >> 4) & 0x3) / 3f;
                                    colours[coloursIndex++] = 1;

                                    colours[coloursIndex++] = ((output[i][j] >> 2) & 0x3) / 3f;
                                    colours[coloursIndex++] = ((output[i][j] >> 2) & 0x3) / 3f;
                                    colours[coloursIndex++] = ((output[i][j] >> 2) & 0x3) / 3f;
                                    colours[coloursIndex++] = 1;

                                    colours[coloursIndex++] = (output[i][j] & 0x3) / 3f;
                                    colours[coloursIndex++] = (output[i][j] & 0x3) / 3f;
                                    colours[coloursIndex++] = (output[i][j] & 0x3) / 3f;
                                    colours[coloursIndex++] = 1;

                                    j += 1;
                                    break;
                                case 4:
                                    colours[coloursIndex++] = (output[i][j] >> 4) / 15f;
                                    colours[coloursIndex++] = (output[i][j] >> 4) / 15f;
                                    colours[coloursIndex++] = (output[i][j] >> 4) / 15f;
                                    colours[coloursIndex++] = 1;

                                    colours[coloursIndex++] = (output[i][j] & 0xF) / 15f;
                                    colours[coloursIndex++] = (output[i][j] & 0xF) / 15f;
                                    colours[coloursIndex++] = (output[i][j] & 0xF) / 15f;
                                    colours[coloursIndex++] = 1;

                                    j += 1;
                                    break;
                                case 8:
                                    colours[coloursIndex++] = output[i][j] / 255.0f;
                                    colours[coloursIndex++] = output[i][j] / 255.0f;
                                    colours[coloursIndex++] = output[i][j] / 255.0f;
                                    colours[coloursIndex++] = output[i][j + 1] / 255.0f;

                                    j += 2;
                                    break;
                                case 16:
                                    colours[coloursIndex++] = (output[i][j] << 8 | output[i][j + 1]) / 65535.0f;
                                    colours[coloursIndex++] = (output[i][j] << 8 | output[i][j + 1]) / 65535.0f;
                                    colours[coloursIndex++] = (output[i][j] << 8 | output[i][j + 1]) / 65535.0f;
                                    colours[coloursIndex++] = (output[i][j + 2] << 8 | output[i][j + 3]) / 65535.0f;

                                    j += 4;
                                    break;
                            }
                            break;
                        case ColourType.RGBA:
                            //8,16        Each pixel is an R,G,B triple, followed by an alpha sample.
                            switch (bitDepth)
                            {
                                case 8:
                                    colours[coloursIndex++] = output[i][j] / 255.0f;
                                    colours[coloursIndex++] = output[i][j + 1] / 255.0f;
                                    colours[coloursIndex++] = output[i][j + 2] / 255.0f;
                                    colours[coloursIndex++] = output[i][j + 3] / 255.0f;
                                    j += 4;
                                    break;
                                case 16:
                                    colours[coloursIndex++] = (output[i][j] << 8 | output[i][j + 1]) / 65535.0f;
                                    colours[coloursIndex++] = (output[i][j + 2] << 8 | output[i][j + 3]) / 65535.0f;
                                    colours[coloursIndex++] = (output[i][j + 4] << 8 | output[i][j + 5]) / 65535.0f;
                                    colours[coloursIndex++] = (output[i][j + 6] << 8 | output[i][j + 7]) / 65535.0f;
                                    j += 8;
                                    break;
                            }
                            break;
                    }
                }
            }
            //tmpoutput.Close();
            return colours;
            //return outputBytes.ToArray();
        }

        /// <summary>
        /// Decodes an encoded scanline using the method in filterType.
        /// 
        /// Filter type must be one of the following:
        /// 
        ///    Type    Name
        ///    0       None
        ///    1       Sub
        ///    2       Up
        ///    3       Average
        ///    4       Paeth
        /// </summary>
        /// <param name="unfilteredscanline">Outputs the scanline data with filter applied</param>
        /// <param name="scanline">The current scanline to process</param>
        /// <param name="prevscanline">The previous scan line</param>
        /// <param name="bytewidth">The width of each pixel</param>
        /// <param name="filterType">The filter type to apply.</param>
        /// <param name="length">The length of the scanline</param>
        /// <exception cref="Exception">Unexpected / Unknown filter type!</exception>
        static void unFilterScanline(out byte[] unfilteredscanline, byte[] scanline, byte[] prevscanline, int bytewidth, int filterType, int length)
        {
            unfilteredscanline = scanline; // new byte[length];

            int i;
            int n;
            switch (filterType)
            {
                case 0: for (i = 0; i < length; i++) unfilteredscanline[i] = scanline[i]; break;
                case 1: //unfilterSub
                    for (i = 0; i < bytewidth; i++) unfilteredscanline[i] = scanline[i];
                    for (i = bytewidth; i < length; i++) unfilteredscanline[i] = (byte)(scanline[i] + scanline[i - bytewidth]);
                    break;
                case 2: //unfilterUp
                    if (prevscanline != null) 
                        for (i = 0; i < length; i++) unfilteredscanline[i] = (byte)(scanline[i] + prevscanline[i]);
                    else 
                        for (i = 0; i < length; i++) unfilteredscanline[i] = scanline[i];
                    break;
                case 3: //unfilterAverage
                    for (i = 0; i < scanline.Length; i++)
                    {
                        int Raw = 0;
                        int prev_index = i - bytewidth;
                        if (prev_index >= 0)
                            Raw = unfilteredscanline[prev_index];

                        int Prior = 0;
                        if (prevscanline != null)
                            Prior = prevscanline[i];

                        int Average = ((0xff & Raw) + (0xff & Prior)) / 2;

                        unfilteredscanline[i] = (byte)((scanline[i] + Average) % 256);
                        //                dst[i] = scanline[i];
                        //                dst[i] = (byte) 255;
                    }
                    break;
                case 4: //unfilterPaeth
                    if (prevscanline != null)
                    {
                        for (i = 0; i < bytewidth; i++) unfilteredscanline[i] = (byte)(scanline[i] + PaethPredictor(0, prevscanline[i], 0));
                        for (i = bytewidth; i < length; i++) unfilteredscanline[i] = (byte)(scanline[i] + PaethPredictor(unfilteredscanline[i - bytewidth], prevscanline[i], prevscanline[i - bytewidth]));
                    }
                    else
                    {
                        for (i = 0; i < bytewidth; i++) unfilteredscanline[i] = scanline[i];
                        for (i = bytewidth; i < length; i++) unfilteredscanline[i] = (byte)(scanline[i] + PaethPredictor(unfilteredscanline[i - bytewidth], 0, 0));
                    }
                    break;
                default: throw new Exception("Unexpected / Unknown filter type!"); //error: unexisting filter type given
            }
        }

        /// <summary>
        /// The Paeth() filter computes a simple linear function of the three 
        /// neighboring pixels (left, above, upper left), then chooses as predictor 
        /// the neighboring pixel closest to the computed value. 
        /// This technique is due to Alan W. Paeth
        /// </summary>
        /// <param name="a">The byte to the left</param>
        /// <param name="b">The byte above</param>
        /// <param name="c">The byte to the upper left</param>
        /// <returns>The neighboring byte closest to the computed value</returns>
        static byte PaethPredictor(byte a, byte b, byte c)
        {
            // a = left, b = above, c = upper left
            int p = a + b - c; // initial estimate
            int pa = Math.Abs(p - a); // distances to a, b, c
            int pb = Math.Abs(p - b);
            int pc = Math.Abs(p - c);
            // return nearest of a, b, c,
            // breaking ties in order a, b, c.
            if (pa <= pb && pa <= pc) return a;
            else if (pb <= pc) return b;
            else return c;
        }

        //void adam7Pass(ref byte[] output, byte[] linen, byte[] lineo, byte[] input, int w, int passleft, int passtop, int spacex, int spacey, int passw, int passh, int bpp)
        //{ 
        //    //filter and reposition the pixels into the output when the image is Adam7 interlaced. This function can only do it after the full image is already decoded. The out buffer must have the correct allocated memory size already.
        //    if (passw == 0) return;
        //    int bytewidth = (bpp + 7) / 8, linelength = 1 + ((bpp * passw + 7) / 8);
        //    for (int y = 0; y < passh; y++)
        //    {
        //        byte filterType = input[y * linelength], *prevline = (y == 0) ? 0 : lineo;
        //        unFilterScanline(linen, &input[y * linelength + 1], prevline, bytewidth, filterType, (w * bpp + 7) / 8); if (error) return;
        //        if (bpp >= 8) for (int i = 0; i < passw; i++) for (int b = 0; b < bytewidth; b++) //b = current byte of this pixel
        //                    output[bytewidth * w * (passtop + spacey * y) + bytewidth * (passleft + spacex * i) + b] = linen[bytewidth * i + b];
        //        else for (int i = 0; i < passw; i++)
        //            {
        //                int obp = bpp * w * (passtop + spacey * y) + bpp * (passleft + spacex * i), bp = i * bpp;
        //                for (int b = 0; b < bpp; b++) setBitOfReversedStream(obp, output, readBitFromReversedStream(bp, &linen[0]));
        //            }
        //        byte* temp = linen; linen = lineo; lineo = temp; //swap the two buffer pointers "line old" and "line new"
        //    }
        //}

        /// <summary>
        /// Decompresses a byte array of data.
        /// </summary>
        /// <param name="compressedbytes">The compressed bytes to deflate</param>
        /// <returns>The decompressed data</returns>
        private static byte[] Deflate(byte[] compressedbytes)
        {
            ///TODO: Remove need for SharpZipLib reference. 

            byte[] temp = new byte[1024];
            MemoryStream memory = new MemoryStream();

            ICSharpCode.SharpZipLib.Zip.Compression.Inflater def = new ICSharpCode.SharpZipLib.Zip.Compression.Inflater();
            def.SetInput(compressedbytes);
            //def.
            while (!def.IsFinished)
            {
                int extracted = def.Inflate(temp);
                if (extracted > 0)
                {
                    memory.Write(temp, 0, extracted);
                }
                else
                {
                    break;
                }
            }
            return memory.ToArray();

        }

        /// <summary>
        /// The colour formats that a PNG may be encoded as.
        /// </summary>
        public enum ColourType : byte
        {
            /// <summary>
            /// Grayscale
            /// </summary>
            Grayscale = 0,
            /// <summary>
            /// Red, Green and Blue: rgb/truecolor
            /// </summary>
            RGB = 2,
            /// <summary>
            /// Indexed: channel containing indices into a palette of colors
            /// </summary>
            Indexed = 3,
            /// <summary>
            /// Grayscale and Alpha: level of opacity for each pixel
            /// </summary>
            GrascaleWithAlpha = 4,

            /// <summary>
            /// Red, Green, Blue and Alpha
            /// </summary>
            RGBA = 6
        }

        /// <summary>
        /// If the PNG image is interlaced or not.
        /// </summary>
        public enum InterlaceMethod
        {
            None = 0,
            ///Adam7 interlace
            Adam7Interlace = 1
        }

        /// <summary>
        /// Reads a data chunk from the PNG image.
        /// </summary>
        /// <param name="reader">The reader pointed at the beginning of the chunk.</param>
        /// <returns>The chunk data read from the stream.</returns>
        static PNGChunk ReadChunk(BinaryReader reader)
        {
            PNGChunk pNGChunk = new PNGChunk();

            pNGChunk.Length = ReadInt32(reader);
            pNGChunk.ChunkType = new string(reader.ReadChars(4));

            pNGChunk.Data = reader.ReadBytes(pNGChunk.Length);

            pNGChunk.Crc32 = ReadInt32(reader);

            return pNGChunk;
        }

        /// <summary>
        /// Reads a 32-bit int from the Stream.
        /// </summary>
        /// <param name="reader">The Stream to Read.</param>
        /// <returns>The int read at the Stream position.</returns>
        private static int ReadInt32(BinaryReader reader)
        {
            return (reader.ReadByte() << 24) |
            (reader.ReadByte() << 16) |
            (reader.ReadByte() << 8) | reader.ReadByte();
        }

        //static Colour[] DecodePalette(PNGChunk chunk)
        //{
        //    Colour[] palette = new Colour[chunk.Length / 3];
        //    BinaryReader reader = chunk.DataStream;
        //    for (int i = 0; i < palette.Length; i++)
        //    {
        //        palette[i] = new Colour(reader.ReadByte(), reader.ReadByte(), reader.ReadByte());
        //    }

        //    return palette;
        //}

        /// <summary>
        /// A PNG data chunk as defined by RFC-2083
        /// </summary>
        struct PNGChunk
        {
            /// <summary>
            /// A 4-byte unsigned integer giving the number of bytes in the 
            /// chunk's data field. The length counts only the data field, 
            /// not itself, the chunk type code, or the CRC. 
            /// Zero is a valid length. Although encoders and decoders should 
            /// treat the length as unsigned, its value must not exceed 231-1 
            /// bytes.
            /// </summary>
            public int Length;

            /// <summary>
            /// A 4-byte chunk type code. 
            /// For convenience in description and in examining PNG files, 
            /// type codes are restricted to consist of uppercase and lowercase 
            /// ASCII letters (A-Z and a-z, or 65-90 and 97-122 decimal). 
            /// However, encoders and decoders must treat the codes as fixed
            /// binary values, not character strings. For example, it would not 
            /// be correct to represent the type code IDAT by the EBCDIC 
            /// equivalents of those letters.
            /// </summary>
            public string ChunkType;

            /// <summary>
            /// The data bytes appropriate to the chunk type, if any. 
            /// This field can be of zero length.
            /// </summary>
            public byte[] Data;

            /// <summary>
            /// A 4-byte CRC (Cyclic Redundancy Check) calculated on the 
            /// preceding bytes in the chunk, including the chunk type code 
            /// and chunk data fields, but not including the length field. 
            /// The CRC is always present, even for chunks containing no data. 
            /// </summary>
            public int Crc32;

            /// <summary>
            /// Chunks that are not strictly necessary in order to meaningfully 
            /// display the contents of the file are known as "ancillary" chunks.
            /// A decoder encountering an unknown chunk in which the ancillary 
            /// bit is 1 can safely ignore the chunk and proceed to display the 
            /// image. The time chunk (tIME) is an example of an ancillary chunk.
            /// 
            /// Chunks that are necessary for successful display of the file's 
            /// contents are called "critical" chunks. A decoder encountering an 
            /// unknown chunk in which the ancillary bit is 0 must indicate to 
            /// the user that the image contains information it cannot safely 
            /// interpret. The image header chunk (IHDR) is an example of a 
            /// critical chunk.
            /// </summary>
            public bool IsCritical
            {
                get { return ChunkType != null && ChunkType.Length == 4 && ChunkType[0] >= 0x41 && ChunkType[0] <= 0x5A; }
            }

            /// <summary>
            /// A public chunk is one that is part of the PNG specification or 
            /// is registered in the list of PNG special-purpose public chunk 
            /// types. Applications can also define private (unregistered) 
            /// chunks for their own purposes. The names of private chunks must 
            /// have a lowercase second letter, while public chunks will always
            /// be assigned names with uppercase second letters. Note that 
            /// decoders do not need to test the private-chunk property bit, 
            /// since it has no functional significance; it is simply an 
            /// administrative convenience to ensure that public and private 
            /// chunk names will not conflict.
            /// </summary>
            public bool IsPublic
            {
                get { return ChunkType != null && ChunkType.Length == 4 && ChunkType[1] >= 0x41 && ChunkType[1] <= 0x5A; }
            }

            /// <summary>
            /// This property bit is not of interest to pure decoders, 
            /// but it is needed by PNG editors (programs that modify PNG files).
            /// This bit defines the proper handling of unrecognized chunks in 
            /// a file that is being modified.
            /// 
            /// If a chunk's safe-to-copy bit is 1, the chunk may be copied to 
            /// a modified PNG file whether or not the software recognizes the 
            /// chunk type, and regardless of the extent of the file 
            /// modifications.
            /// 
            /// If a chunk's safe-to-copy bit is 0, it indicates that the chunk 
            /// depends on the image data. If the program has made any 
            /// changes to critical chunks, including addition, modification, 
            /// deletion, or reordering of critical chunks, then unrecognized 
            /// unsafe chunks must not be copied to the output PNG file. 
            /// (Of course, if the program does recognize the chunk, it can 
            /// choose to output an appropriately modified version.)
            /// 
            /// A PNG editor is always allowed to copy all unrecognized chunks 
            /// if it has only added, deleted, modified, or reordered ancillary 
            /// chunks. This implies that it is not permissible for ancillary 
            /// chunks to depend on other ancillary chunks.
            /// 
            /// PNG editors that do not recognize a critical chunk must report 
            /// an error and refuse to process that PNG file at all. 
            /// The safe/unsafe mechanism is intended for use with ancillary 
            /// chunks.
            /// The safe-to-copy bit will always be 0 for critical chunks.
            /// </summary>
            public bool IsSafeToCopy
            {
                get { return ChunkType != null && ChunkType.Length == 4 && ChunkType[3] >= 0x41 && ChunkType[3] <= 0x5A; }
            }

            /// <summary>
            /// A Helper function to read the data as a BinaryStream.
            /// </summary>
            public BinaryReader DataStream
            {
                get { return new BinaryReader(new MemoryStream(Data)); }
            }
        }
    }

}
