using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrairieGL.Glfw
{
    /// <summary>
    /// Opaque monitor object.
    /// </summary>
    public class GLFWmonitor
    {
        public GLFWmonitorPtr Handle;

        public GLFWmonitor(GLFWmonitorPtr handle)
        {
            Handle = handle;
        }

        public static implicit operator GLFWmonitorPtr(GLFWmonitor from)
            {
            if (from == null) return IntPtr.Zero;
            return from.Handle;
        }

        public static implicit operator GLFWmonitor(GLFWmonitorPtr from)
            => new(from);
    }

    /// <summary>
    /// Opaque monitor object.
    /// </summary>
    public struct GLFWmonitorPtr
    {
        public IntPtr Handle;

        public static implicit operator GLFWmonitorPtr(IntPtr from)
        {
            GLFWmonitorPtr to = new GLFWmonitorPtr();
            to.Handle = from;
            return to;
        }
    }
}
