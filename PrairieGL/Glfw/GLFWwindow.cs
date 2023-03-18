using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrairieGL.Glfw
{
    /// <summary>
    /// Opaque window object.
    /// </summary>
    public class GLFWwindow
    {
        public GLFWwindowPtr Handle; 

        public GLFWwindow(GLFWwindowPtr handle)
        {
            Handle = handle;
        }

        public static implicit operator GLFWwindowPtr(GLFWwindow from)
        {
            if (from == null) return IntPtr.Zero;
            return from.Handle;
        }
        public static implicit operator GLFWwindow(GLFWwindowPtr from)
            => new(from);
    }

    /// <summary>
    /// Opaque window object.
    /// </summary>
    public struct GLFWwindowPtr
    {
        public IntPtr Handle;

        public static implicit operator GLFWwindowPtr(IntPtr from)
        {
            GLFWwindowPtr to = new GLFWwindowPtr();
            to.Handle = from;
            return to;
        }

    }
}
