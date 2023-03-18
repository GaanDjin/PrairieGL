using PrairieGL.Glfw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrairieGL.OpenGL
{
    /// <summary>
    /// Contains information about an OpenGL error message.
    /// </summary>
    public struct ErrorLog
    {
        /// <summary>
        /// The source of the error message.
        /// </summary>
        public ErrorSources Source;
        /// <summary>
        /// The type of error.
        /// </summary>
        public ErrorType Type;
        /// <summary>
        /// The error ID.
        /// </summary>
        public uint Id;
        /// <summary>
        /// The sevarity of the error
        /// </summary>
        public ErrorSeverity Severity;
        /// <summary>
        /// The error message.
        /// </summary>
        public string Message;
    }

    /// <summary>
    /// Used to *supposedly* syncronize OpenGL across threads.
    /// </summary>
    public struct GLsync
    {
        /// <summary>
        /// The handle of this Sync object
        /// </summary>
        public int Handle;
    }

    /// <summary>
    /// Used to *supposedly* handle rendering OpenGL across different windows.
    /// </summary>
    public class GLContext
    {
        /// <summary>
        /// The OpenGL handle
        /// </summary>
        public IntPtr Handle;
        /// <summary>
        /// The handle of the drawing control that OpenGL will draw to. 
        /// </summary>
        public IntPtr WindowDC;
        /// <summary>
        /// The window that this OpenGL instance belongs to.
        /// </summary>
        public IntPtr WindowHandle;

        /// <summary>
        /// Create a new GLContext that this window binds to.
        /// </summary>
        /// <param name="window">The window that this Context will belong to</param>
        public GLContext(GLFWwindowPtr window)
        {
            WindowHandle = Glfw.Glfw.GetWin32Window(window);
            WindowDC = WindowsApi.GetDC(WindowHandle);
            Handle = Wgl.CreateContext(WindowDC);
            //Wgl.CreateRenderingContext
        }

        ~GLContext()
        {
            Wgl.DeleteContext(Handle);
        }
    }
}
