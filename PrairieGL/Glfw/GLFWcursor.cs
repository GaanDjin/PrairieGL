namespace PrairieGL.Glfw
{
    /// <summary>
    /// Opaque cursor object.
    /// </summary>
    public class GLFWcursor
    {
        public GLFWcursorPtr Handle;

        public GLFWcursor(GLFWcursorPtr handle)
        {
            Handle = handle;
        }

        public static implicit operator GLFWcursorPtr(GLFWcursor from)
        {
            if (from == null) return IntPtr.Zero;
            return from.Handle;
        }

        public static implicit operator GLFWcursor(GLFWcursorPtr from)
            => new(from);
    }

    /// <summary>
    /// Opaque cursor object.
    /// </summary>
    public struct GLFWcursorPtr
    {
        public IntPtr Handle;

        public static implicit operator GLFWcursorPtr(IntPtr from)
        {
            GLFWcursorPtr to = new GLFWcursorPtr();
            to.Handle = from;
            return to;
        }
    }
}
