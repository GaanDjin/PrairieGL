using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrairieGL.Glfw
{
    public class GlfwDelegates
    {
        /// <summary>
        /// This is the function pointer type for mouse button callback functions. 
        /// 
        /// When a window loses input focus, it will generate synthetic mouse button release events for 
        /// all pressed mouse buttons. You can tell these events from user-generated events by the fact 
        /// that the synthetic ones are generated after the focus loss event has been processed, 
        /// i.e. after the window focus callback has been called.
        /// </summary>
        /// <param name="window">The window that received the event.</param>
        /// <param name="button">The mouse button that was pressed or released.</param>
        /// <param name="action">One of GLFW_PRESS or GLFW_RELEASE. Future releases may add more actions.</param>
        /// <param name="mods">Bit field describing which modifier keys were held down.</param>
        public delegate void GLFWmousebuttonfun(GLFWwindowPtr window, MouseButtons button, int action, ModifierKeys mods);

        /// <summary>
        /// This is the function pointer type for cursor position callbacks which is called when the cursor is moved
        /// </summary>
        /// <param name="window">The window that received the event.</param>
        /// <param name="xpos">The new cursor x-coordinate, relative to the left edge of the content area.</param>
        /// <param name="ypos">The new cursor y-coordinate, relative to the top edge of the content area.</param>

        public delegate void GLFWcursorposfun(GLFWwindowPtr window, double xpos, double ypos);

        /// <summary>
        /// This function sets the cursor boundary crossing callback of the specified window,
        /// which is called when the cursor enters or leaves the content area of the window.
        /// </summary>
        /// <param name="window">The window whose callback to set.</param>
        /// <param name="entered">GLFW_TRUE if the cursor entered the window's content area, or GLFW_FALSE if it left it.</param>
        public delegate void GLFWcursorenterfun(GLFWwindowPtr window, int entered);

        /// <summary>
        /// This function sets the scroll callback of the specified window, which is called when a scrolling 
        /// device is used, such as a mouse wheel or scrolling area of a touchpad.
        /// 
        /// The scroll callback receives all scrolling input, like that from a mouse wheel or a touchpad scrolling area.
        /// </summary>
        /// <param name="window">The window whose callback to set.</param>
        /// <param name="xoffset">The scroll offset along the x-axis.</param>
        /// <param name="yoffset">The scroll offset along the y-axis.</param>
        public delegate void GLFWscrollfun(GLFWwindowPtr window, double xoffset, double yoffset);

        /// <summary>
        /// Called when a key is pressed, repeated or released.
        ///
        /// The key functions deal with physical keys, with layout independent key tokens named after 
        /// their values in the standard US keyboard layout. If you want to input text, use the character callback instead.
        /// 
        /// When a window loses input focus, it will generate synthetic key release events for all pressed keys.
        /// You can tell these events from user-generated events by the fact that the synthetic ones are generated 
        /// after the focus loss event has been processed, i.e.after the window focus callback has been called.
        /// 
        /// The scancode of a key is specific to that platform or sometimes even to that machine. 
        /// Scancodes are intended to allow users to bind keys that don't have a GLFW key token.
        /// Such keys have key set to GLFW_KEY_UNKNOWN, their state is not saved and so it cannot be queried with 
        /// glfwGetKey.
        /// 
        /// Sometimes GLFW needs to generate synthetic key events, in which case the scancode may be zero.
        /// </summary>
        /// <param name="window">The window that received the event.</param>
        /// <param name="key">The keyboard key that was pressed or released.</param>
        /// <param name="scancode">The system-specific scancode of the key.</param>
        /// <param name="action">GLFW_PRESS, GLFW_RELEASE or GLFW_REPEAT. Future releases may add more actions.</param>
        /// <param name="mods">Bit field describing which modifier keys were held down.</param>
        public delegate void GLFWkeyfun(GLFWwindowPtr window, KeyboardKeys key, int scancode, KeyActions action, ModifierKeys mods);

        /// <summary>
        /// Called when a Unicode character is input.
        /// 
        /// The character callback is intended for Unicode text input. As it deals with characters, it is keyboard 
        /// layout dependent, whereas the key callback is not. Characters do not map 1:1 to physical keys, as a key 
        /// may produce zero, one or more characters. If you want to know whether a specific physical key was pressed 
        /// or released, see the key callback instead.
        /// 
        /// The character callback behaves as system text input normally does and will not be called if modifier keys 
        /// are held down that would prevent normal text input on that platform, 
        /// for example a Super (Command) key on macOS or Alt key on Windows.
        /// </summary>
        /// <param name="window">The window that received the event.</param>
        /// <param name="codepoint">The Unicode code point of the character.</param>
        public delegate void GLFWcharfun(GLFWwindowPtr window, uint codepoint);

        /// <summary>
        /// Called when a Unicode character is input regardless of what modifier keys are used.
        /// 
        /// The character with modifiers callback is intended for implementing custom Unicode character input.
        /// For regular Unicode text input, see the character callback.
        /// Like the character callback, the character with modifiers callback deals with characters and is 
        /// keyboard layout dependent. Characters do not map 1:1 to physical keys, as a key may produce zero, 
        /// one or more characters. If you want to know whether a specific physical key was pressed or released, 
        /// see the key callback instead.
        /// 
        /// Deprecated: Scheduled for removal in version 4.0.
        /// </summary>
        /// <param name="window">The window that received the event.</param>
        /// <param name="codepoint">The Unicode code point of the character.</param>
        /// <param name="mods">	Bit field describing which modifier keys were held down.</param>
        public delegate void GLFWcharmodsfun(GLFWwindowPtr window, uint codepoint, ModifierKeys mods);

        /// <summary>
        /// Called when one or more dragged paths are dropped on the window.
        /// 
        /// Because the path array and its strings may have been generated specifically for that event, 
        /// they are not guaranteed to be valid after the callback has returned. 
        /// If you wish to use them after the callback returns, you need to make a deep copy.
        /// </summary>
        /// <param name="window">The window that received the event.</param>
        /// <param name="path_count">The number of dropped paths.</param>
        /// <param name="paths">The UTF-8 encoded file and/or directory path names.</param>
        public delegate void GLFWdropfun(GLFWwindowPtr window, int path_count, string[] paths);

        /// <summary>
        /// Called when a joystick is connected to or disconnected from the system.
        /// 
        /// For joystick connection and disconnection events to be delivered on all platforms, 
        /// you need to call one of the event processing functions. Joystick disconnection may 
        /// also be detected and the callback called by joystick functions. 
        /// The function will then return whatever it returns if the joystick is not present.
        /// </summary>
        /// <param name="jid">The joystick that was connected or disconnected.</param>
        /// <param name="evt">One of GLFW_CONNECTED or GLFW_DISCONNECTED. Future releases may add more events.</param>
        public delegate void GLFWjoystickfun(int jid, int evt);

        /// <summary>
        /// Called with an error code and a human-readable description each time a GLFW error occurs.
        /// 
        /// The error code is set before the callback is called.Calling glfwGetError from the error callback will return the same value as the error code argument.
        /// 
        /// The error callback is called on the thread where the error occurred. If you are using GLFW from multiple threads, your error callback needs to be written accordingly.
        /// 
        /// Because the description string may have been generated specifically for that error, it is not guaranteed to be valid after the callback has returned. If you wish to use it after the callback returns, you need to make a copy.
        /// 
        /// Once set, the error callback remains set even after the library has been terminated.
        /// </summary>
        /// <param name="error_code">An error code. Future releases may add more error codes</param>
        /// <param name="description">A UTF-8 encoded string describing the error.</param>
        public delegate void GLFWerrorfun(GlfwError error_code, string description);

        /// <summary>
        /// Called when the window is moved. The callback is provided with the position, 
        /// in screen coordinates, of the upper-left corner of the content area of the window.
        /// </summary>
        /// <param name="window">The window that was moved.</param>
        /// <param name="xpos">The new x-coordinate, in screen coordinates, of the upper-left corner of the content area of the window.</param>
        /// <param name="ypos">The new y-coordinate, in screen coordinates, of the upper-left corner of the content area of the window.</param>
        public delegate void GLFWwindowposfun(GLFWwindowPtr window, int xpos, int ypos);

        /// <summary>
        /// Called when the window is resized. 
        /// The callback is provided with the size, in screen coordinates, of the content area of the window.
        /// </summary>
        /// <param name="window">The window that was resized.</param>
        /// <param name="width">The new width, in screen coordinates, of the window.</param>
        /// <param name="height">The new height, in screen coordinates, of the window.</param>
        public delegate void GLFWwindowsizefun(GLFWwindowPtr window, int width, int height);

        /// <summary>
        /// Called when the user attempts to close the window, for example by clicking the close widget in the title bar.
        /// 
        /// The close flag is set before this callback is called, but you can modify it at any time with 
        /// glfwSetWindowShouldClose.
        /// 
        /// The close callback is not triggered by glfwDestroyWindow.
        /// </summary>
        /// <param name="window">The window that the user attempted to close.</param>
        public delegate void GLFWwindowclosefun(GLFWwindowPtr window);

        /// <summary>
        /// Called when the content area of the window needs to be redrawn, for example if the window has been exposed after 
        /// having been covered by another window.
        /// 
        /// On compositing window systems such as Aero, Compiz, Aqua or Wayland, where the window contents are saved off-screen, 
        /// this callback may be called only very infrequently or never at all.
        /// </summary>
        /// <param name="window">The window whose content needs to be refreshed.</param>
        public delegate void GLFWwindowrefreshfun(GLFWwindowPtr window);

        /// <summary>
        /// Called when the window gains or loses input focus.
        /// 
        /// After the focus callback is called for a window that lost input focus, 
        /// synthetic key and mouse button release events will be generated for all such that had been pressed.
        /// For more information, see glfwSetKeyCallback and glfwSetMouseButtonCallback.
        /// </summary>
        /// <param name="window">The window that gained or lost input focus.</param>
        /// <param name="focused">GLFW_TRUE if the window was given input focus, or GLFW_FALSE if it lost it.</param>
        public delegate void GLFWwindowfocusfun(GLFWwindowPtr window, int focused);

        /// <summary>
        /// Called when the window is iconified or restored.
        /// </summary>
        /// <param name="window">The window that was iconified or restored.</param>
        /// <param name="iconified">GLFW_TRUE if the window was iconified, or GLFW_FALSE if it was restored.</param>
        public delegate void GLFWwindowiconifyfun(GLFWwindowPtr window, int iconified);

        /// <summary>
        /// Called when the window is maximized or restored.
        /// </summary>
        /// <param name="window">The window that was maximized or restored.</param>
        /// <param name="maximized">GLFW_TRUE if the window was maximized, or GLFW_FALSE if it was restored.</param>
        public delegate void GLFWwindowmaximizefun(GLFWwindowPtr window, int maximized);

        /// <summary>
        /// Called when the framebuffer of the specified window is resized.
        /// </summary>
        /// <param name="window">The window whose framebuffer was resized.</param>
        /// <param name="width">The new width, in pixels, of the framebuffer.</param>
        /// <param name="height">The new height, in pixels, of the framebuffer.</param>
        public delegate void GLFWframebuffersizefun(GLFWwindowPtr window, int width, int height);

        /// <summary>
        /// Called when the content scale of the specified window changes.
        /// </summary>
        /// <param name="window">The window whose content scale changed.</param>
        /// <param name="xscale">The new x-axis content scale of the window.</param>
        /// <param name="yscale">The new y-axis content scale of the window.</param>
        public delegate void GLFWwindowcontentscalefun(GLFWwindowPtr window, float xscale, float yscale);

        /// <summary>
        /// Called when a monitor is connected to or disconnected from the system.
        /// </summary>
        /// <param name="monitor">The monitor that was connected or disconnected.</param>
        /// <param name="evt">One of GLFW_CONNECTED or GLFW_DISCONNECTED. Future releases may add more events.</param>
        public delegate void GLFWmonitorfun(GLFWmonitorPtr monitor, int evt);

    }
}
