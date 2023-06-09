﻿using PrairieGL.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PrairieGL
{
	/// <summary>
	/// A Material stores information the shader can use to apply colour and 
	/// Texture to objects.
	/// </summary>
    public class Material
    {
		/// <summary>
		/// A Simple 2x2 White PNG image used as a default Texture.
		/// </summary>
		private readonly byte[] DefaultTexture = new byte[] {
			0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A, 0x00, 0x00, 0x00, 0x0D, 0x49, 0x48, 0x44, 0x52, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x02, 0x00, 0x08, 0x02, 0x00, 0x00, 0x00, 0x7B, 0x1A, 0x43, 0xAD, 0x00, 0x00, 0x00, 0x01, 0x73, 0x52, 0x47, 0x42, 0x00, 0xAE, 0xCE, 0x1C, 0xE9, 0x00, 0x00, 0x00, 0x04, 0x67, 0x41, 0x4D, 0x41, 0x00, 0x00, 0xB1, 0x8F, 0x0B, 0xFC, 0x61, 0x05, 0x00, 0x00, 0x00, 0x09, 0x70, 0x48, 0x59, 0x73, 0x00, 0x00, 0x12, 0x74, 0x00, 0x00, 0x12, 0x74, 0x01, 0xDE, 0x66, 0x1F, 0x78, 0x00, 0x00, 0x06, 0xD7, 0x49, 0x44, 0x41, 0x54, 0x78, 0x5E, 0xED, 0xD5, 0x01, 0x01, 0x00, 0x00, 0x08, 0xC3, 0x20, 0xFB, 0x97, 0xBE, 0x41, 0x06, 0x25, 0xB8, 0x01, 0x90, 0x24, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0xA2, 0x04, 0x00, 0x10, 0x25, 0x00, 0x80, 0x28, 0x01, 0x00, 0x44, 0x09, 0x00, 0x20, 0x4A, 0x00, 0x00, 0x51, 0x02, 0x00, 0x88, 0x12, 0x00, 0x40, 0x94, 0x00, 0x00, 0x92, 0xB6, 0x07, 0x65, 0x9A, 0xB3, 0x4D, 0xEF, 0xFA, 0x04, 0xC4, 0x00, 0x00, 0x00, 0x00, 0x49, 0x45, 0x4E, 0x44, 0xAE, 0x42, 0x60, 0x82 };

		/// <summary>
		/// The Diffuse texture used by this Material.
		/// </summary>
		public Texture DiffuseTexture;

        /// <summary>
        /// The Normal texture used by this Material.
        /// </summary>
        public Texture NormalTexture;

        /// <summary>
        /// The Specular texture used by this Material.
        /// </summary>
        public Texture SpecularTexture;

        /// <summary>
        /// The Ambient Colour of this Material.
        /// </summary>
        public Vector3 AmbientColour;

        /// <summary>
        /// The Diffuse Colour of this Material.
        /// </summary>
		public Vector3 DiffuseColour;

        /// <summary>
        /// The Specular Colour of this Material.
        /// </summary>
        public Vector3 SpecularColour;

        /// <summary>
        /// The Shininess of this Material.
        /// </summary>
        public float Shininess;

        /// <summary>
        /// Create a new Material using the Default Textures, Colour Black, 
        /// and a Shininess of 0.3f.
        /// </summary>
        public Material()
        {
			Shininess = 0.3f;
			AmbientColour = new Vector3(0.5f, 0.5f, 0.5f);
			DiffuseColour = new Vector3(0.5f, 0.5f, 0.5f);
			SpecularColour = new Vector3(0.1f, 0.1f, 0.1f);

			DiffuseTexture = new Texture(new MemoryStream(DefaultTexture));
			NormalTexture = new Texture(new MemoryStream(DefaultTexture));
			SpecularTexture = new Texture(new MemoryStream(DefaultTexture));
		}

        /// <summary>
        /// Sets the currently active Shader to use this mterial parameters.
        /// This assumes the fragment shader has a material struct. See the example.
        /// </summary>
		/// <example>
        /// struct Material {
        /// sampler2D DiffuseTexture;
        /// sampler2D NormalTexture;
        /// sampler2D SpecularTexture;
        /// 
        /// float Shininess;
        /// vec3 AmbientColour;
        /// vec3 DiffuseColour;
        /// vec3 SpecularColour;
        /// };
        /// 
        /// uniform Material material;
		/// </example>
        /// <param name="shader">The currently active shader.</param>
        public void Use(Shader shader)
		{
			///TODO: Use the Shader functions to set the Uniform values.
			if (DiffuseTexture != null)
			{
				// Bind our diffuse texture in Texture Unit 0
				GL.ActiveTexture(TextureUnits.GL_TEXTURE0);
				GL.BindTexture(TextureTargets.GL_TEXTURE_2D, DiffuseTexture.ID);
				// Set our "DiffuseTextureSampler" sampler to use Texture Unit 0
				//GL.Uniform1i(DiffuseTextureID, 0);
				GL.Uniform1i((int)shader.GetAttribLocation("material.DiffuseTexture"), 0);
			}

			if (NormalTexture != null)
			{
				// Bind our normal texture in Texture Unit 1
				GL.ActiveTexture(TextureUnits.GL_TEXTURE1);
				GL.BindTexture(TextureTargets.GL_TEXTURE_2D, NormalTexture.ID);
				// Set our "NormalTextureSampler" sampler to use Texture Unit 1
				//GL.Uniform1i(NormalTextureID, 1);
				GL.Uniform1i((int)shader.GetAttribLocation("material.NormalTexture"), 1);
			}

			if (SpecularTexture != null)
			{
				// Bind our specular texture in Texture Unit 2
				GL.ActiveTexture(TextureUnits.GL_TEXTURE2);
				GL.BindTexture(TextureTargets.GL_TEXTURE_2D, SpecularTexture.ID);
				// Set our "SpecularTextureSampler" sampler to use Texture Unit 2
				//GL.Uniform1i(SpecularTextureID, 2);
				GL.Uniform1i((int)shader.GetAttribLocation("material.SpecularTexture"), 2);
			}


			GL.Uniform3f((int)shader.GetAttribLocation("material.AmbientColour"), AmbientColour.X, AmbientColour.Y, AmbientColour.Z);
			GL.Uniform3f((int)shader.GetAttribLocation("material.DiffuseColour"), DiffuseColour.X, DiffuseColour.Y, DiffuseColour.Z);
			GL.Uniform3f((int)shader.GetAttribLocation("material.SpecularColour"), SpecularColour.X, SpecularColour.Y, SpecularColour.Z);
			GL.Uniform1f((int)shader.GetAttribLocation("material.Shininess"), Shininess);
		}
	}
}
