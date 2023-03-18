using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PrairieGL.Glfw
{
    /// <summary>
    /// This describes the input state of a gamepad.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct GLFWgamepadstate
    {
        /// <summary>
        /// The states of each gamepad button, 1 (GLFW_PRESS) or 0 (GLFW_RELEASE).
        /// </summary>
        public byte[] buttons /*[15]*/;
        /// <summary>
        /// The states of each gamepad axis, in the range -1.0 to 1.0 inclusive.
        /// </summary>
        public float[] axes /*[6]*/;
    }

    /// <summary>
    /// This describes a single 2D image. See the documentation for each related function what the expected pixel format is.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct GLFWimage
    {
        /// <summary>
        /// The width, in pixels, of this image.
        /// </summary>
        public int width;
        /// <summary>
        /// The height, in pixels, of this image.
        /// </summary>
        public int height;
        /// <summary>
        /// The pixel data of this image, arranged left-to-right, top-to-bottom.
        /// </summary>
        public byte[] pixels;
    }

    /// <summary>
    /// This describes a single video mode.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct GLFWvidmode
    {
        /// <summary>
        /// The width, in screen coordinates, of the video mode.
        /// </summary>
        public int width;
        /// <summary>
        /// The height, in screen coordinates, of the video mode.
        /// </summary>
        public int height;
        /// <summary>
        /// The bit depth of the red channel of the video mode.
        /// </summary>
        public int redBits;
        /// <summary>
        /// The bit depth of the green channel of the video mode.
        /// </summary>
        public int greenBits;
        /// <summary>
        /// The bit depth of the blue channel of the video mode.
        /// </summary>
        public int blueBits;
        /// <summary>
        /// The refresh rate, in Hz, of the video mode.
        /// </summary>
        public int refreshRate;
    }

    /// <summary>
    /// This describes the gamma ramp for a monitor.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct GLFWgammaramp
    {
        /// <summary>
        /// An array of value describing the response of the red channel.
        /// </summary>
        public short[] red;
        /// <summary>
        /// An array of value describing the response of the green channel.
        /// </summary>
        public short[] green;
        /// <summary>
        /// An array of value describing the response of the blue channel.
        /// </summary>
        public short[] blue;
        /// <summary>
        /// The number of elements in each array.
        /// </summary>
        public int size;
    }

}
