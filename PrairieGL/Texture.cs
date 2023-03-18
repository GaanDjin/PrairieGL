using PrairieGL.OpenGL;
using PrairieGL.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrairieGL
{
	/// <summary>
	/// Loads an image file into an OpenGL Texture
	/// </summary>
	public class Texture: IDisposable
	{
        /// <summary>
        /// The OpenGL Texture Handle. <see cref="GL.GenTexture()"/>
		/// If the ID is 0 this Texture has been disposed of and shouldn't be used. 
        /// </summary>
        public uint ID { get;set; }

		/// <summary>
		/// The width of the Texture in pixels
		/// </summary>
		public int Width { get; set; }

        /// <summary>
        /// The height of the Texture in pixels
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// The depth of the Texture if it is a 3D texture.
        /// </summary>
        public int Depth { get; set; }

		/// <summary>
		/// The format of the texure. Currently unused.
		/// </summary>
		public int Format { get; set; }

        /// <summary>
        /// The units of the texure. Currently unused.
        /// </summary>
        public int Units { get; set; }

		/// <summary>
		/// Create a texture from an image file.
		/// Currently supported file types are: BMP, DDS, PNG, and JPG
		/// </summary>
		/// <param name="imagepath">The path to the image file.</param>
		/// <exception cref="NotImplementedException">
		/// Thrown if the file type is unrecognized.
		/// </exception>
		public Texture(string imagepath)
        {
			Stream image = File.OpenRead(imagepath);
			byte[] filecode = new byte[10];
			image.Read(filecode, 0, 10);
			image.Seek(0, SeekOrigin.Begin);

			if (filecode[0] == 'B' && filecode[1] == 'M')
				LoadBMP(image);
			else if (filecode[0] == 'D' && filecode[1] == 'D' && filecode[2] == 'S' && filecode[3] == ' ')
				LoadDDS(image);
			else if (filecode[0] == 0x89 && filecode[1] == 0x50 && filecode[2] == 0x4E && filecode[3] == 0x47 &&
				filecode[4] == 0x0D && filecode[5] == 0x0A && filecode[6] == 0x1A && filecode[7] == 0x0A)
				LoadPNG(image);
			else if (filecode[0] == 0xFF && filecode[1] == 0xD8 && filecode[2] == 0xFF)
				LoadJPG(image);
			else
			{
				throw new NotImplementedException("Image type not supported! Please use: BMP, PNG, or DDS.");
			}
		}

        /// <summary>
        /// Create a texture from an stream object.
        /// Currently supported image types are: BMP, DDS, PNG, and JPG
        /// </summary>
        /// <param name="imagepath">The Stream containing the image data</param>
        /// <exception cref="NotImplementedException">
        /// Thrown if the image type is unrecognized.
        /// </exception>
        public Texture(Stream image)
		{
			byte[] filecode = new byte[10];
			image.Read(filecode, 0, 10);
			image.Seek(0, SeekOrigin.Begin);

			if (filecode[0] == 'B' && filecode[1] == 'M')
				LoadBMP(image);
			else if (filecode[0] == 'D' && filecode[1] == 'D' && filecode[2] == 'S' && filecode[3] == ' ')
				LoadDDS(image);
			else if (filecode[0] == 0x89 && filecode[1] == 0x50 && filecode[2] == 0x4E && filecode[3] == 0x47 &&
				filecode[4] == 0x0D && filecode[5] == 0x0A && filecode[6] == 0x1A && filecode[7] == 0x0A)
				LoadPNG(image); //.PNG....
			else if (filecode[0] == 0xFF && filecode[1] == 0xD8 && filecode[2] == 0xFF)
			{
				
				LoadJPG(image);
			}
			else
			{

				throw new NotImplementedException("Image type not supported! Please use: BMP, PNG, or DDS.");
			}
		}

		/// <summary>
		/// Reads a null terminated string and returns the string.
		/// Assumes the strings are one byte each and that the string ends with a 00 (null) character.
		/// </summary>
		/// <param name="reader">The stream that has the pointer at the beginning of the string to read</param>
		/// <returns>The string read. If the stream points to a 0x00 byte then an empty string is returned.</returns>
		private string ReadNullTerminatedString(BinaryReader reader)
        {
			string s = "";
			byte b = reader.ReadByte();
			while (b != 0x00)
            {
				s += (char)b;
				b = reader.ReadByte();
			}

			return s;
        }

		/// <summary>
		/// Reads a 2 byte unsigned number from the stream using Big Endian.
		/// Converts the number to an int (For ease of casting)
		/// </summary>
		/// <param name="reader">The stream at the beginning of the number to read.</param>
		/// <returns>The read number.</returns>
		private int ReadUshort(BinaryReader reader)
        {
			byte[] data = reader.ReadBytes(2);
			int value = (data[2] << 8 | data[3]);
			return value;
		}

        /// <summary>
        /// Convert a Y, Cr, Cb colour format to RGB.
        /// </summary>
		/// <see href="https://en.wikipedia.org/wiki/YCbCr#:~:text=YCbCr%2C%20Y%E2%80%B2CbCr%2C%20or,and%20red%2Ddifference%20chroma%20components."/>
        /// <param name="Y">The luma component</param>
        /// <param name="Cr">The red-difference chroma</param>
        /// <param name="Cb">The blue-difference chroma</param>
        /// <returns>A 3-byte array containing the R, G, and B values.</returns>
        private byte[] ToRGBFromYCbCr(byte Y, byte Cr, byte Cb)
        {
			byte[] toRet = new byte[3];

			float R = Y + 1.402f * (Cr - 128);
			float G = Y - 0.34414f * (Cb - 128) - 0.71414f * (Cr - 128);
			float B = Y + 1.772f * (Cb - 128);

			toRet[0] = (byte)(R * 255); 
			toRet[1] = (byte)(G * 255); 
			toRet[2] = (byte)(B * 255);

			return toRet;
		}

        /// <summary>
        /// Convert a RGB colour format to Y, Cr, Cb.
        /// </summary>
        /// <see href="https://en.wikipedia.org/wiki/YCbCr#:~:text=YCbCr%2C%20Y%E2%80%B2CbCr%2C%20or,and%20red%2Ddifference%20chroma%20components."/>
        /// <param name="R">The Red colour channel</param>
        /// <param name="G">The Green colour channel</param>
        /// <param name="B">The Blue colour channel</param>
        /// <returns>A 3-byte array containing the Y, Cb, and Cr values.</returns>
        private byte[] ToYCbCrFromRGB(byte R, byte G, byte B)
        {
			float Y = 0.299f * R + 0.587f * G + 0.114f * B;
			float Cb = -0.1687f * R - 0.3313f * G + 0.5f * B + 128;
			float Cr = 0.5f * R - 0.4187f * G - 0.0813f * B + 128;

			return new byte[] { (byte)Y, (byte)Cb, (byte)Cr};
		}

		/// <summary>
		/// Loads a BMP image into this Texture.
		/// </summary>
		/// <param name="stream">The stream containing the BMP image data</param>
		/// <exception cref="Exception">Thrown if the stream contains invalid data or is null.</exception>
		private void LoadBMP(Stream stream)
		{
			// Data read from the header of the BMP file
			byte[] header = new byte[54];
			int dataPos;
			int imageSize;
			// Actual RGB data
			byte[] data;

			// Open the file
			BinaryReader file = new BinaryReader(stream);



			// Read the header, i.e. the 54 first bytes

			// If less than 54 bytes are read, problem
			header = file.ReadBytes(54);
			
			// Make sure this is a 24bpp file

			if (header[0x1E] != 0) { file.Close(); throw new Exception("Not a correct 24bpp BMP file\n"); }
			if (header[0x1C] != 24) { file.Close(); throw new Exception("Not a correct 24bpp BMP file\n"); }

			// Read the information about the image
			dataPos = BitConverter.ToInt32(header, 0x0A);
			imageSize = BitConverter.ToInt32(header, 0x22);
			Width = BitConverter.ToInt32(header, 0x12);
			Height = BitConverter.ToInt32(header, 0x16);

			// Some BMP files are misformatted, guess missing information
			if (imageSize == 0) imageSize = Width * Height * 3; // 3 : one byte for each Red, Green and Blue component
			if (dataPos == 0) dataPos = 54; // The BMP header is done that way

			// Create a buffer
			//data = new byte[imageSize];

			// Read the actual data from the file into the buffer
			data = file.ReadBytes(imageSize);  //fread(data, 1, imageSize, file);

			// Everything is in memory now, the file can be closed.
			file.Close();

			// Create one OpenGL texture
			uint textureID = GL.GenTexture();

			// "Bind" the newly created texture : all future texture functions will modify this texture
			GL.BindTexture(TextureTargets.GL_TEXTURE_2D, textureID);

			// Give the image to OpenGL
			GL.TexImage2D(TextureTargets.GL_TEXTURE_2D, 0, ImagePixelFormats.GL_RGB, Width, Height, 0, ImagePixelFormats.GL_BGR, ImagePixelDataTypes.GL_UNSIGNED_BYTE, data);

			// OpenGL has now copied the data. Free our own version
			//delete[] data;

			// Poor filtering, or ...
			//glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_NEAREST);
			//glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_NEAREST); 

			// ... nice trilinear filtering ...
			GL.TexParameteri(TextureTargets.GL_TEXTURE_2D, TextureParameters.GL_TEXTURE_WRAP_S, (int)TextureParameterValues.GL_REPEAT);
			GL.TexParameteri(TextureTargets.GL_TEXTURE_2D, TextureParameters.GL_TEXTURE_WRAP_T, (int)TextureParameterValues.GL_REPEAT);
			GL.TexParameteri(TextureTargets.GL_TEXTURE_2D, TextureParameters.GL_TEXTURE_MAG_FILTER, (int)TextureParameterValues.GL_LINEAR);
			GL.TexParameteri(TextureTargets.GL_TEXTURE_2D, TextureParameters.GL_TEXTURE_MIN_FILTER, (int)TextureParameterValues.GL_LINEAR_MIPMAP_LINEAR);
			// ... which requires mipmaps. Generate them automatically.
			GL.GenerateMipmap(TextureTargets.GL_TEXTURE_2D);

			// Return the ID of the texture we just created
			ID = textureID;
		}

        /// <summary>
        /// Loads a DDS image into this Texture.
        /// </summary>
        /// <param name="stream">The stream containing the DDS image data</param>
		/// <exception cref="Exception">Thrown if the stream contains invalid data or is null.</exception>
        private void LoadDDS(Stream stream)
		{
			/* try to open the file */
							BinaryReader fp = new BinaryReader(stream);
			
			/* verify the type of file */
			byte[] filecode = fp.ReadBytes(4);
			

			/* get the surface desc */
			byte[] header = fp.ReadBytes(124);

			Height = BitConverter.ToInt32(header, 8);
			Width = BitConverter.ToInt32(header, 12);
			int linearSize = BitConverter.ToInt32(header, 16);
			int mipMapCount = BitConverter.ToInt32(header, 24);
			int fourCC = BitConverter.ToInt32(header, 80);


			byte[] buffer;
			int bufsize;
			/* how big is it going to be including all mipmaps? */
			bufsize = mipMapCount > 1 ? linearSize * 2 : linearSize;
			buffer = fp.ReadBytes(bufsize);
			/* close the file pointer */
			fp.Close();

			int components = (fourCC == FOURCC_DXT1) ? 3 : 4;
			CompressedTextureImageFormats format;
			switch (fourCC)
			{
				case FOURCC_DXT1:
					format = CompressedTextureImageFormats.GL_COMPRESSED_RGBA_S3TC_DXT1_EXT;
					break;
				case FOURCC_DXT3:
					format = CompressedTextureImageFormats.GL_COMPRESSED_RGBA_S3TC_DXT3_EXT;
					break;
				case FOURCC_DXT5:
					format = CompressedTextureImageFormats.GL_COMPRESSED_RGBA_S3TC_DXT5_EXT;
					break;
				default:
					throw new Exception("Unexpected Format in DDS image.");
			}

			// Create one OpenGL texture
			uint textureID = GL.GenTexture();

			// "Bind" the newly created texture : all future texture functions will modify this texture
			GL.BindTexture(TextureTargets.GL_TEXTURE_2D, textureID);
			GL.PixelStorei(PixelPackingFormats.GL_UNPACK_ALIGNMENT, 1);

			int blockSize = (format == CompressedTextureImageFormats.GL_COMPRESSED_RGBA_S3TC_DXT1_EXT) ? 8 : 16;
			int offset = 0;

			/* load the mipmaps */
			for (int level = 0; level < mipMapCount && (Width > 0 || Height > 0); ++level)
			{
				int size = ((Width + 3) / 4) * ((Height + 3) / 4) * blockSize;
				byte[] data = new byte[size];
				Array.Copy(buffer, offset, data, 0, size);
				GL.CompressedTexImage2D(TextureTargets.GL_TEXTURE_2D, level, format, Width, Height, 0, size, data);

				offset += size;
				Width /= 2;
				Height /= 2;

				// Deal with Non-Power-Of-Two textures. This code is not included in the webpage to reduce clutter.
				if (Width < 1) Width = 1;
				if (Height < 1) Height = 1;

			}


			ID = textureID;

		}

        /// <summary>
        /// Loads a PNG image into this Texture.
        /// </summary>
        /// <param name="stream">The stream containing the PNG image data</param>
		/// <exception cref="Exception">Thrown if the stream contains invalid data or is null.</exception>
        private void LoadPNG(Stream stream)
		{

            float[] data = PNG.Read(stream, out int width, out int height, out ImagePixelFormats format, out ImagePixelDataTypes datasize);
			Width = width;
			Height = height;

			// Create one OpenGL texture
			uint textureID = GL.GenTexture();

			// "Bind" the newly created texture : all future texture functions will modify this texture
			GL.BindTexture(TextureTargets.GL_TEXTURE_2D, textureID);

			// Give the image to OpenGL
			GL.TexImage2D(TextureTargets.GL_TEXTURE_2D, 0, format, Width, Height, 0, format, datasize, data);

			// OpenGL has now copied the data. Free our own version
			//delete[] data;

			// Poor filtering, or ...
			//glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_NEAREST);
			//glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_NEAREST); 

			// ... nice trilinear filtering ...
			GL.TexParameteri(TextureTargets.GL_TEXTURE_2D, TextureParameters.GL_TEXTURE_WRAP_S, (int)TextureParameterValues.GL_REPEAT);
			GL.TexParameteri(TextureTargets.GL_TEXTURE_2D, TextureParameters.GL_TEXTURE_WRAP_T, (int)TextureParameterValues.GL_REPEAT);
			GL.TexParameteri(TextureTargets.GL_TEXTURE_2D, TextureParameters.GL_TEXTURE_MAG_FILTER, (int)TextureParameterValues.GL_LINEAR);
			GL.TexParameteri(TextureTargets.GL_TEXTURE_2D, TextureParameters.GL_TEXTURE_MIN_FILTER, (int)TextureParameterValues.GL_LINEAR_MIPMAP_LINEAR);
			// ... which requires mipmaps. Generate them automatically.
			GL.GenerateMipmap(TextureTargets.GL_TEXTURE_2D);

			// Return the ID of the texture we just created
			ID = textureID;
		}

        /// <summary>
        /// Loads a JPG image into this Texture.
        /// </summary>
        /// <param name="stream">The stream containing the JPG image data</param>
		/// <exception cref="Exception">Thrown if the stream contains invalid data or is null.</exception>
		private void LoadJPG(Stream stream)
		{
			byte[] data = new byte[stream.Length];
			stream.Read(data, 0, (int)stream.Length);
			Utils.NanoJpeg.Image img = new Utils.NanoJpeg.Image(data);
			data = img.Data;


			Width = img.Width;
			Height = img.Height;


			// Create one OpenGL texture
			uint textureID = GL.GenTexture();

			// "Bind" the newly created texture : all future texture functions will modify this texture
			GL.BindTexture(TextureTargets.GL_TEXTURE_2D, textureID);

			// Give the image to OpenGL
			GL.TexImage2D(TextureTargets.GL_TEXTURE_2D, 0, ImagePixelFormats.GL_RGB, Width, Height, 0, ImagePixelFormats.GL_RGB, ImagePixelDataTypes.GL_UNSIGNED_BYTE, data);

			// OpenGL has now copied the data. Free our own version
			//delete[] data;

			// Poor filtering, or ...
			//glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_NEAREST);
			//glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_NEAREST); 

			// ... nice trilinear filtering ...
			GL.TexParameteri(TextureTargets.GL_TEXTURE_2D, TextureParameters.GL_TEXTURE_WRAP_S, (int)TextureParameterValues.GL_REPEAT);
			GL.TexParameteri(TextureTargets.GL_TEXTURE_2D, TextureParameters.GL_TEXTURE_WRAP_T, (int)TextureParameterValues.GL_REPEAT);
			GL.TexParameteri(TextureTargets.GL_TEXTURE_2D, TextureParameters.GL_TEXTURE_MAG_FILTER, (int)TextureParameterValues.GL_LINEAR);
			GL.TexParameteri(TextureTargets.GL_TEXTURE_2D, TextureParameters.GL_TEXTURE_MIN_FILTER, (int)TextureParameterValues.GL_LINEAR_MIPMAP_LINEAR);
			// ... which requires mipmaps. Generate them automatically.
			GL.GenerateMipmap(TextureTargets.GL_TEXTURE_2D);

			// Return the ID of the texture we just created
			ID = textureID;
		}


        const int FOURCC_DXT1 = 0x31545844; // Equivalent to "DXT1" in ASCII
		const int FOURCC_DXT3 = 0x33545844; // Equivalent to "DXT3" in ASCII
		const int FOURCC_DXT5 = 0x35545844; // Equivalent to "DXT5" in ASCII

		~Texture()
		{
			//Dispose();
		}

		/// <summary>
		/// Release the texture when no longer needed. 
		/// </summary>
        public void Dispose()
        {
			if (ID > 0)
			{
				GL.DeleteTexture(ID);
				ID = 0;
			}
        }


        #region JFIF
        ///TODO: To be implemented

        //private void LoadJFIF(Stream stream)
        //{
        //	/* try to open the file */
        //	BinaryReader fp = new BinaryReader(stream);

        //	/* verify the type of file */
        //	fp.ReadBytes(2); //First to bytes at FF D8 (Start of image)

        //          /* get the surface desc */
        //          //byte[] header = fp.ReadBytes(124);

        //          Dictionary<int, byte[]> defineQuantizationTables = new Dictionary<int, byte[]>();
        //          //Dictionary<int, byte[]> huffmanTables = new Dictionary<int, byte[]>();
        //          Dictionary<byte, Dictionary<HuffmanTree.HuffKey, byte>>  huffData = new Dictionary<byte, Dictionary<HuffmanTree.HuffKey, byte>>();
        //	List<byte> compressedData = new List<byte>();

        //	byte YSamplingFactor;
        //	byte YQuantizationTableNumber;
        //	byte CbSamplingFactor;
        //	byte CbQuantizationTableNumber;
        //	byte CrSamplingFactor;
        //	byte CrQuantizationTableNumber;

        //	byte YHuffmanTable;
        //	byte CbHuffmanTable;
        //	byte CrHuffmanTable;

        //	/*
        //	 JFIF file structure
        //	Segment		Code			Description
        //	SOI			FF D8			Start of Image
        //	JFIF-APP0	FF E0 s1 s2 4A 46 49 46 00 ...	see below
        //	JFXX-APP0	FF E0 s1 s2 4A 46 58 58 00 ...	optional, see below… 
        //	additional marker segments (for example SOF, DHT, COM)
        //	SOS			FF DA			Start of Scan compressed image data	
        //	EOI			FF D9			End of Image
        //	*/

        //	bool eof = false;

        //	while (!eof)
        //          {
        //		byte[] data = fp.ReadBytes(2);
        //		int segmentCode = data[0] << 8 | data[1];

        //		data = fp.ReadBytes(2);
        //		int segmentLength = (data[0] << 8 | data[1]) - 2; //Length including length feild. So sub 2.

        //		switch (segmentCode)
        //		{
        //			case 0xFFE0:
        //				//APP0 (application data) - Thumbnail info. Should be a zero thumb.
        //				int xThumb;
        //				int yThumb;
        //				int n;

        //				string segmentID = ReadNullTerminatedString(fp);

        //				if (segmentID == "JFIF")
        //				{
        //					data = fp.ReadBytes(2);
        //					int JFIFversion = data[0] << 8 | data[1];

        //					/*	
        //					 Units for the following pixel density fields
        //						00 : No units; width:height pixel aspect ratio = Ydensity:Xdensity
        //						01 : Pixels per inch (2.54 cm)
        //						02 : Pixels per centimeter
        //					*/

        //					data = fp.ReadBytes(2);
        //					int densityUnits = data[0] << 8 | data[1];


        //					data = fp.ReadBytes(2);
        //					int Xdensity = data[0] << 8 | data[1];

        //					data = fp.ReadBytes(2);
        //					int Ydensity = data[0] << 8 | data[1];

        //					xThumb = fp.ReadByte();
        //					yThumb = fp.ReadByte();

        //					n = xThumb * yThumb;

        //					//Uncompressed 24 bit RGB (8 bits per color channel) raster thumbnail data
        //					//in the order R0, G0, B0, ... Rn-1, Gn-1, Bn-1
        //					fp.ReadBytes(n * 3);
        //				}
        //				else if (segmentID == "JFXX")
        //				{
        //					/*
        //						Specifies what data format is used for the following embedded thumbnail:
        //						10 : JPEG format
        //						11 : 1 byte per pixel palettized format
        //						13 : 3 byte per pixel RGB format
        //					*/
        //					int thumbFormat = fp.ReadByte();

        //					switch (thumbFormat)
        //					{
        //						case 10:
        //							LoadJFIF(fp.BaseStream);
        //							break;
        //						case 11:

        //							xThumb = fp.ReadByte();
        //							yThumb = fp.ReadByte();

        //							//256 palette entries, each containing a 24 bit RGB color value
        //							fp.ReadBytes(768);

        //							n = xThumb * yThumb;
        //							//One byte per pixel containing the index of the color within the palette 
        //							fp.ReadBytes(n);

        //							break;
        //						case 13:

        //							xThumb = fp.ReadByte();
        //							yThumb = fp.ReadByte();

        //							n = xThumb * yThumb;
        //							//Three bytes per pixel containing the index of the color within the palette 
        //							fp.ReadBytes(n * 3);

        //							break;
        //					}
        //				}
        //				break;
        //			case 0xFFDB:
        //				//DQT (define quantization table) 
        //				for (int i = 0; i < segmentLength; i += 65)
        //				{
        //					byte destination = fp.ReadByte();
        //					/* destination:
        //					 * luminance = 00
        //					 * chrominance = 01
        //					 */

        //					byte[] table = fp.ReadBytes(64);
        //					/* 8x8 table */

        //					defineQuantizationTables.Add(destination, table);
        //				}
        //				break;
        //			case 0xFFC4:
        //				//DHT (define Huffman table)

        //				//fp.BaseStream.Seek(-4, SeekOrigin.Current);
        //                      byte[] huffmanTableData = fp.ReadBytes(segmentLength);

        //				dht(huffmanTableData, huffData);

        //				//int bytesRead = 0;

        //				//while (bytesRead < segmentLength)
        //				//{
        //				//	byte huffmanTableID = fp.ReadByte();

        //				//	int size = 0;

        //				//	for (int i = 0; i < 16; i++)
        //				//		size = fp.ReadByte();

        //				//	byte[] huffmanTableData = fp.ReadBytes(size);

        //				//	huffmanTables.Add(huffmanTableID, huffmanTableData);

        //				//	bytesRead += size + 17;
        //				//}
        //				break;
        //			case 0xFFC0:
        //				int bpp = fp.ReadByte();            // bits per pixel
        //				Height = ReadUshort(fp);            // image height
        //				Width = ReadUshort(fp);             // image width
        //				byte numComponents = fp.ReadByte(); // number of components (should be 1 or 3)

        //				for (int i = 0; i < numComponents; i++) {
        //					byte componenetNumber = fp.ReadByte();
        //					byte samplingFactor = fp.ReadByte();
        //					byte qtablenum = fp.ReadByte();

        //					switch (componenetNumber)
        //					{
        //						case 1:
        //							YSamplingFactor = samplingFactor;
        //							YQuantizationTableNumber = qtablenum;
        //							break;
        //						case 2:
        //							CbSamplingFactor = samplingFactor;
        //							CbQuantizationTableNumber = qtablenum;
        //							break;
        //						case 3:
        //							CrSamplingFactor = samplingFactor;
        //							CrQuantizationTableNumber = qtablenum;
        //							break;
        //					}
        //				}
        //				break;
        //			case 0xFFDA:

        //				byte numcomponenets = fp.ReadByte();

        //				for (int i = 0; i < numcomponenets; i++)
        //				{
        //					byte component = fp.ReadByte();

        //					switch (component)
        //					{
        //						case 1:
        //							YHuffmanTable = fp.ReadByte();
        //							break;
        //						case 2:
        //							CbHuffmanTable = fp.ReadByte();
        //							break;
        //						case 3:
        //							CrHuffmanTable = fp.ReadByte();
        //							break;
        //					}
        //				}

        //				byte startOfSpectralSelectionOrPredictorSelection = fp.ReadByte();
        //				byte endOfSpectralSelection = fp.ReadByte();
        //				byte successiveApproximationBitPositionOrPointTransform = fp.ReadByte();

        //				bool endOfData = false;

        //				byte last = fp.ReadByte();
        //				byte current = fp.ReadByte();


        //				while(true)
        //                      {
        //					if (last == 0xFF && current != 0x00)
        //                          {
        //						break;
        //					}
        //					else if (last == 0xFF && current == 0x00)
        //					{
        //						// byte stuffing. If the last byte was FF and the current byte is 00 then
        //						// we keep the last byte and loose the escape character 00.
        //						// and read ahead.
        //						compressedData.Add(last);
        //						last = fp.ReadByte();
        //						current = fp.ReadByte();
        //						break;
        //					}
        //                          else
        //					{
        //						compressedData.Add(last);
        //						last = current;
        //						current = fp.ReadByte();
        //					}


        //				}

        //				break;
        //			case 0xFFD9:
        //				eof = true; break;
        //			default:
        //				//Unknown segment. Skip it.
        //				fp.ReadBytes(segmentLength);
        //				break;
        //		}
        //          }


        //}

        //static int dht(byte[] segment, Dictionary<byte, Dictionary<HuffmanTree.HuffKey, byte>> huffData /*[32]*/)
        //{


        //	int fp = 0;

        //	int i, j;

        //	// A counter of how many bytes have been read
        //	int ctr = 0;

        //	// The incrementing code to be used to build the map
        //	ushort code = 0;

        //	// First byte of a DHT segment is the table ID, between 0 and 31
        //	byte table = segment[fp++];
        //	ctr++;

        //	// Next sixteen bytes are the counts for each code length
        //	byte[] counts = new byte[16];
        //	for (i = 0; i < 16; i++)
        //	{
        //		counts[i] = segment[fp++];
        //		ctr++;
        //	}

        //	huffData.Add(table, new Dictionary<HuffmanTree.HuffKey, byte>());

        //	// Remaining bytes are the data values to be mapped
        //	// Build the Huffman map of (length, code) -> value
        //	for (i = 0; i < 16; i++)
        //	{
        //		for (j = 0; j < counts[i]; j++)
        //		{
        //			huffData[table].Add(new HuffmanTree.HuffKey(i + 1, code), segment[fp++]);
        //			code++;
        //			ctr++;
        //		}
        //		code <<= 1;
        //	}

        //	// Once the map has been built, print it out
        //	Console.WriteLine("Huffman table", table.ToString("X") + ":");

        //	foreach (KeyValuePair<HuffmanTree.HuffKey, byte> iter in huffData[table])
        //	{
        //		Console.WriteLine("    " + iter.Key.Code.ToString("X") + " at length "+iter.Key.Length+" = "+iter.Value.ToString("X"));
        //	}

        //	return ctr;
        //}

        //		// Decode the DHT marker segment (Huffman Tables)
        //		// In some cases (such as for MotionJPEG), we fake out
        //		// the DHT tables (when bInject=true) with a standard table
        //		// as each JPEG frame in the MJPG does not include the DHT.
        //		// In all other cases (bInject=false), we simply read the
        //		// DHT table from the file buffer via Buf()
        //		//
        //		// ITU-T standard indicates that we can expect up to a
        //		// maximum of 16-bit huffman code bitstrings.
        //		void DecodeDHT(byte[] Buf, bool bInject)
        //		{
        //			//For debugging
        //			bool bOutputDHTexpand = false;

        //#if DEBUG
        //			bOutputDHTexpand = true;
        //#endif

        //			int length;
        //			int tmp;
        //			string tmpStr, fullStr;
        //			int nPosEnd;
        //			int nPosSaved = 0;

        //			bool bRet;

        //			int m_nPos = 2;

        //			if (bInject)
        //			{
        //				// Redirect Buf() to DHT table in MJPGDHTSeg[]
        //				// ... so change mode that Buf() call uses
        //				m_bBufFakeDHT = true;

        //				// Preserve the "m_nPos" pointer, at end we undo it
        //				// And we also start at 2 which is just after FFC4 in array
        //				nPosSaved = m_nPos;
        //				m_nPos = 2;
        //			}

        //			length = Buf[m_nPos] * 256 + Buf[m_nPos + 1];
        //			nPosEnd = m_nPos + length;
        //			m_nPos += 2;
        //			tmpStr = "  Huffman table length = " + length;
        //			Console.WriteLine(tmpStr);

        //			int dht_class, dht_dest_id;

        //			// In various places, added m_bStateAbort check to allow us
        //			// to escape in case we get in excessive number of DHT entries
        //			// See BUG FIX #1003
        //			bool m_bStateAbort = false;

        //			while ((!m_bStateAbort) && (nPosEnd > m_nPos))
        //			{
        //				Console.WriteLine("  ----");

        //				tmp = Buf[m_nPos++];
        //				dht_class = (tmp & 0xF0) >> 4;
        //				dht_dest_id = tmp & 0x0F;
        //				tmpStr = "  Destination ID = "+dht_dest_id;
        //				Console.WriteLine(tmpStr);
        //				tmpStr = "  Class = " + dht_class + " (" + (dht_class > 0 ? "AC Table" : "DC / Lossless Table") + ")";
        //				Console.WriteLine(tmpStr);

        //				// Add in some error checking to prevent 
        //				if (dht_class >= 2)
        //				{
        //					tmpStr = "ERROR: Invalid DHT Class (" + dht_class + "). Aborting DHT Load.";
        //					Console.WriteLine(tmpStr);
        //					m_nPos = nPosEnd;
        //					//m_bStateAbort = true;	// Stop decoding
        //					break;
        //				}
        //				if (dht_dest_id >= 4)
        //				{
        //					tmpStr = "ERROR: Invalid DHT Dest ID (" + dht_dest_id + "). Aborting DHT Load.";
        //					Console.WriteLine(tmpStr);
        //					m_nPos = nPosEnd;
        //					//m_bStateAbort = true;	// Stop decoding
        //					break;
        //				}

        //				int[] m_anImgDhtCodesLen = new int[17];

        //				// Read in the array of DHT code lengths
        //				for (int i = 1; i <= 16; i++)
        //				{
        //					m_anImgDhtCodesLen[i] = Buf[m_nPos++];
        //				}

        //				int DECODE_DHT_MAX_DHT = 256;

        //				int[] dht_code_list = new int[DECODE_DHT_MAX_DHT + 1]; // Should only need max 162 codes
        //				int dht_ind;
        //				int dht_codes_total;

        //				// Clear out the code list
        //				for (dht_ind = 0; dht_ind < DECODE_DHT_MAX_DHT; dht_ind++)
        //				{
        //					dht_code_list[dht_ind] = 0xFFFF; // Dummy value
        //				}

        //				// Now read in all of the DHT codes according to the lengths
        //				// read in earlier
        //				dht_codes_total = 0;
        //				dht_ind = 0;
        //				for (int ind_len = 1; ((!m_bStateAbort) && (ind_len <= 16)); ind_len++)
        //				{
        //					// Keep a total count of the number of DHT codes read
        //					dht_codes_total += m_anImgDhtCodesLen[ind_len];

        //					fullStr = "    Codes of length "+ ind_len + " bits ("+ m_anImgDhtCodesLen[ind_len] + " total): ";
        //					for (int ind_code = 0; ((!m_bStateAbort) && (ind_code < m_anImgDhtCodesLen[ind_len])); ind_code++)
        //					{
        //						// Start a new line for every 16 codes
        //						if ((ind_code != 0) && ((ind_code % 16) == 0))
        //						{
        //							fullStr = "                                         ";
        //						}
        //						tmp = Buf[m_nPos++];
        //						tmpStr = tmp.ToString("X") + " ";
        //						fullStr += tmpStr;

        //						// Only write 16 codes per line
        //						if ((ind_code % 16) == 15)
        //						{
        //							Console.WriteLine(fullStr);
        //							fullStr = "";
        //						}

        //						// Save the huffman code
        //						// Just in case we have more DHT codes than we expect, trap
        //						// the range check here, otherwise we'll have buffer overrun!
        //						if (dht_ind < DECODE_DHT_MAX_DHT)
        //						{
        //							dht_code_list[dht_ind++] = tmp;
        //						}
        //						else
        //						{
        //							dht_ind++;
        //							tmpStr = "Excessive DHT entries ("+ dht_ind + ")... skipping";
        //							Console.WriteLine(tmpStr);
        //							if (!m_bStateAbort) { DecodeErrCheck(true); }
        //						}

        //					}
        //					Console.WriteLine(fullStr);
        //				}
        //				tmpStr = "    Total number of codes: %03u"), dht_codes_total);
        //				Console.WriteLine(tmpStr);

        //				int dht_lookup_ind = 0;

        //				// Now print out the actual binary strings!
        //				long bit_val = 0;
        //				int code_val = 0;
        //				dht_ind = 0;
        //				if (bOutputDHTexpand)
        //				{
        //					Console.WriteLine("");
        //					Console.WriteLine("  Expanded Form of Codes:");
        //				}
        //				for (int bit_len = 1; ((!m_bStateAbort) && (bit_len <= 16)); bit_len++)
        //				{
        //					if (m_anImgDhtCodesLen[bit_len] != 0)
        //					{
        //						if (bOutputDHTexpand)
        //						{
        //							tmpStr = "    Codes of length "+bit_len+" bits:";
        //							Console.WriteLine(tmpStr);
        //						}
        //						// Codes exist for this bit-length
        //						// Walk through and generate the bitvalues
        //						for (int bit_ind = 1; ((!m_bStateAbort) && (bit_ind <= m_anImgDhtCodesLen[bit_len])); bit_ind++)
        //						{
        //							int decval = code_val;
        //							int bin_bit;
        //							char[] binstr = new char[17];
        //							int binstr_len = 0;

        //							// If the user has enabled output of DHT expanded tables,
        //							// report the bit-string sequences.
        //							if (bOutputDHTexpand)
        //							{
        //								for (int bin_ind = bit_len; bin_ind >= 1; bin_ind--)
        //								{
        //									bin_bit = (decval >> (bin_ind - 1)) & 1;
        //									binstr[binstr_len++] = (bin_bit > 0) ? '1' : '0';
        //								}
        //								binstr[binstr_len] = '\0';
        //								fullStr = "      "+ binstr + " = " + dht_code_list[dht_ind].ToString("X");
        //								if (dht_code_list[dht_ind] == 0x00) { fullStr += " (EOB)"; }
        //								if (dht_code_list[dht_ind] == 0xF0) { fullStr += " (ZRL)"; }

        //								tmpStr = fullStr + " (Total Len = "+ bit_len + (dht_code_list[dht_ind] & 0xF)+")";

        //								Console.WriteLine(tmpStr);
        //							}

        //							// Store the lookup value
        //							// Shift left to MSB of 32-bit
        //							int tmp_mask = m_anMaskLookup[bit_len];

        //							int tmp_bits = decval << (32 - bit_len);
        //							int tmp_code = dht_code_list[dht_ind];
        //							bRet = m_pImgDec.SetDhtEntry(dht_dest_id, dht_class, dht_lookup_ind, bit_len,
        //								tmp_bits, tmp_mask, tmp_code);

        //							DecodeErrCheck(bRet);

        //							dht_lookup_ind++;

        //							// Move to the next code
        //							code_val++;
        //							dht_ind++;
        //						}
        //					}
        //					// For each loop iteration (on bit length), we shift the code value
        //					code_val <<= 1;
        //				}


        //				// Now store the dht_lookup_size
        //				int tmp_size = dht_lookup_ind;
        //				bRet = m_pImgDec.SetDhtSize(dht_dest_id, dht_class, tmp_size);
        //				if (!m_bStateAbort) { DecodeErrCheck(bRet); }

        //				Console.WriteLine("");

        //			}

        //			if (bInject)
        //			{
        //				// Restore position (as if we didn't move)
        //				m_nPos = nPosSaved;
        //				m_bBufFakeDHT = false;
        //			}
        //		}

        #endregion
    }
}
