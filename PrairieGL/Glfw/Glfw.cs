using Microsoft.VisualBasic;
using PrairieGL.Vulkan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PrairieGL.Glfw
{
    public class Glfw
    {
        public const int GLFW_OPENGL_CORE_PROFILE = 0x00032001;
        public const int GLFW_OPENGL_ANY_PROFILE = 0;
        public const int GLFW_OPENGL_COMPAT_PROFILE = 0x00032002;
        public const int GLFW_NO_API = 0;
        public const int GLFW_FALSE = 0;
        public const int GLFW_TRUE = 1;

        /// <summary>
        /// This function initializes the GLFW library. Before most GLFW functions can be used, GLFW must be initialized, 
        /// and before an application terminates GLFW should be terminated in order to free any resources allocated 
        /// during or after initialization.
        /// 
        /// If this function fails, it calls glfwTerminate before returning.
        /// If it succeeds, you should call glfwTerminate before the application exits.
        /// 
        /// Possible errors include GLFW_PLATFORM_ERROR.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// 
        /// Additional calls to this function after successful initialization but before termination will return 
        /// GLFW_TRUE (1) immediately.
        /// </summary>
        /// <returns></returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwInit", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int Init();

        /// <summary>
        /// This function destroys all remaining windows and cursors, restores any modified gamma ramps and frees any 
        /// other allocated resources. Once this function is called, you must again call glfwInit successfully before 
        /// you will be able to use most GLFW functions.
        /// 
        /// If GLFW has been successfully initialized, this function should be called before the application exits.
        /// If initialization fails, there is no need to call this function, as it is called by glfwInit before it 
        /// returns failure.
        /// 
        /// This function has no effect if GLFW is not initialized.
        /// 
        /// Errors: Possible errors include GLFW_PLATFORM_ERROR.
        /// Remarks: This function may be called before glfwInit.
        /// Warning: The contexts of any remaining windows must not be current on any other thread when this function is called.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <returns></returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwTerminate", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int Terminate();

        /// <summary>
        /// This function sets hints for the next call to glfwCreateWindow. 
        /// The hints, once set, retain their values until changed by a call to this function or glfwDefaultWindowHints, 
        /// or until the library is terminated.
        /// 
        /// Only integer value hints can be set with this function.String value hints are set with glfwWindowHintString.
        /// 
        /// This function does not check whether the specified hint values are valid.If you set hints to invalid values 
        /// this will instead be reported by the next call to glfwCreateWindow.
        /// 
        /// Some hints are platform specific. These may be set on any platform but they will only affect their specific 
        /// platform.
        /// Other platforms will ignore them.Setting these hints requires no platform specific headers or functions.
        /// 
        /// Errors: Possible errors include GLFW_NOT_INITIALIZED and GLFW_INVALID_ENUM.
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="hint">The window hint to set.</param>
        /// <param name="value">The new value of the window hint.</param>
        [DllImport("glfw3.dll", EntryPoint = "glfwWindowHint", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void WindowHint(WindowHints hint, int value);

        /// <summary>
        /// This function creates a window and its associated OpenGL or OpenGL ES context. 
        /// Most of the options controlling how the window and its context should be created are specified with window hints.
        /// 
        /// Successful creation does not change which context is current. Before you can use the newly created context, 
        /// you need to make it current. 
        /// For information about the share parameter, see Context object sharing.
        /// 
        /// The created window, framebuffer and context may differ from what you requested, as not all parameters and 
        /// hints are hard constraints. This includes the size of the window, especially for full screen windows.
        /// To query the actual attributes of the created window, framebuffer and context, see glfwGetWindowAttrib, 
        /// glfwGetWindowSize and glfwGetFramebufferSize.
        /// 
        /// To create a full screen window, you need to specify the monitor the window will cover.
        /// If no monitor is specified, the window will be windowed mode.Unless you have a way for the user to choose a 
        /// specific monitor, it is recommended that you pick the primary monitor.For more information on how to query 
        /// connected monitors, see Retrieving monitors.
        /// 
        /// For full screen windows, the specified size becomes the resolution of the window's desired video mode. 
        /// As long as a full screen window is not iconified, the supported video mode most closely matching the desired 
        /// video mode is set for the specified monitor. 
        /// For more information about full screen windows, including the creation of so called windowed full screen or 
        /// borderless full screen windows, see "Windowed full screen" windows.
        /// 
        /// 
        /// Once you have created the window, you can switch it between windowed and full screen mode with 
        /// glfwSetWindowMonitor. This will not affect its OpenGL or OpenGL ES context.
        /// 
        /// 
        /// By default, newly created windows use the placement recommended by the window system.
        /// To create the window at a specific position, make it initially invisible using the GLFW_VISIBLE window hint, 
        /// set its position and then show it.
        /// 
        /// As long as at least one full screen window is not iconified, the screensaver is prohibited from starting.
        /// 
        /// Window systems put limits on window sizes.Very large or very small window dimensions may be overridden by the 
        /// window system on creation.Check the actual size after creation.
        /// 
        /// The swap interval is not set during window creation and the initial value may vary depending on driver 
        /// settings and defaults.
        /// 
        /// Remarks
        /// Windows: Window creation will fail if the Microsoft GDI software OpenGL implementation is the only one available.
        /// Windows: If the executable has an icon resource named GLFW_ICON, it will be set as the initial icon for the window. If no such icon is present, the IDI_APPLICATION icon will be used instead.To set a different icon, see glfwSetWindowIcon.
        /// Windows: The context to share resources with must not be current on any other thread.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="width">The desired width, in screen coordinates, of the window. This must be greater than zero.</param>
        /// <param name="height">The desired height, in screen coordinates, of the window. This must be greater than zero.</param>
        /// <param name="title">The initial, UTF-8 encoded window title.</param>
        /// <param name="monitor">The monitor to use for full screen mode, or NULL for windowed mode.</param>
        /// <param name="share">The window whose context to share resources with, or NULL to not share resources.</param>
        /// <returns>The handle of the created window, or NULL if an error occurred.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwCreateWindow", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern GLFWwindowPtr CreateWindow(int width, int height, string title, GLFWmonitorPtr monitor, GLFWwindowPtr share);

        /// <summary>
        /// This function makes the OpenGL or OpenGL ES context of the specified window current on the calling thread. 
        /// A context must only be made current on a single thread at a time and each thread can have only a 
        /// single current context at a time.
        /// 
        /// When moving a context between threads, you must make it non-current on the old thread before making it 
        /// current on the new one.
        /// 
        /// By default, making a context non-current implicitly forces a pipeline flush. On machines that support 
        /// GL_KHR_context_flush_control, you can control whether a context performs this flush by setting the 
        /// GLFW_CONTEXT_RELEASE_BEHAVIOR hint.
        /// 
        /// The specified window must have an OpenGL or OpenGL ES context.Specifying a window without a context will 
        /// generate a GLFW_NO_WINDOW_CONTEXT error.
        /// </summary>
        /// <param name="window"></param>
        [DllImport("glfw3.dll", EntryPoint = "glfwMakeContextCurrent", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void MakeContextCurrent(GLFWwindowPtr window);


        /// <summary>
        /// This function destroys the specified window and its context. On calling this function, no further callbacks will be called for that window.
        /// 
        /// If the context of the specified window is current on the main thread, it is detached before being destroyed.
        /// </summary>
        /// <param name="window">The window to destroy.</param>
        [DllImport("glfw3.dll", EntryPoint = "glfwDestroyWindow", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void DestroyWindow(GLFWwindowPtr window);

        /// <summary>
        /// This function sets an input mode option for the specified window. 
        /// 
        /// If the mode is GLFW_CURSOR, the value must be one of the following cursor modes:
        /// 
        /// GLFW_CURSOR_NORMAL makes the cursor visible and behaving normally.
        /// GLFW_CURSOR_HIDDEN makes the cursor invisible when it is over the content area of the window but does not restrict the cursor from leaving.
        /// GLFW_CURSOR_DISABLED hides and grabs the cursor, providing virtual and unlimited cursor movement.This is useful for implementing for example 3D camera controls.
        /// If the mode is GLFW_STICKY_KEYS, the value must be either GLFW_TRUE to enable sticky keys, or GLFW_FALSE to disable it.If sticky keys are enabled, a key press will ensure that glfwGetKey returns GLFW_PRESS the next time it is called even if the key had been released before the call. This is useful when you are only interested in whether keys have been pressed but not when or in which order.
        /// 
        /// 
        /// If the mode is GLFW_STICKY_MOUSE_BUTTONS, the value must be either GLFW_TRUE to enable sticky mouse buttons, or GLFW_FALSE to disable it.If sticky mouse buttons are enabled, a mouse button press will ensure that glfwGetMouseButton returns GLFW_PRESS the next time it is called even if the mouse button had been released before the call.This is useful when you are only interested in whether mouse buttons have been pressed but not when or in which order.
        /// 
        /// 
        /// If the mode is GLFW_LOCK_KEY_MODS, the value must be either GLFW_TRUE to enable lock key modifier bits, or GLFW_FALSE to disable them.If enabled, callbacks that receive modifier bits will also have the GLFW_MOD_CAPS_LOCK bit set when the event was generated with Caps Lock on, and the GLFW_MOD_NUM_LOCK bit when Num Lock was on.
        /// 
        /// If the mode is GLFW_RAW_MOUSE_MOTION, the value must be either GLFW_TRUE to enable raw (unscaled and unaccelerated) mouse motion when the cursor is disabled, or GLFW_FALSE to disable it.If raw motion is not supported, attempting to set this will emit GLFW_PLATFORM_ERROR.Call glfwRawMouseMotionSupported to check for support.
        /// </summary>
        /// <param name="window">The window whose input mode to set.</param>
        /// <param name="mode"></param>
        /// <param name="value">The new value of the specified input mode.</param>
        [DllImport("glfw3.dll", EntryPoint = "glfwSetInputMode", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void SetInputMode(GLFWwindowPtr window, GlfwInputModes mode, int value);

        /// <summary>
        /// This function sets the Cursor input mode option for the specified window.
        /// 
        /// </summary>
        /// <param name="window">The window whose input mode to set.</param>
        /// <param name="value">The new value of the specified input mode.</param>
        public static void SetInputMode(GLFWwindowPtr window, GlfwCursorModes value)
        {
            SetInputMode(window, GlfwInputModes.GLFW_CURSOR, (int)value);
        }

        /// <summary>
        /// This function sets an input mode option for the specified window.
        /// 
        /// </summary>
        /// <param name="window">The window whose input mode to set.</param>
        /// <param name="mode">Must NOT be GLFW_CURSOR</param>
        /// <param name="value">The new value of the specified input mode.</param>
        public static void SetInputMode(GLFWwindowPtr window, GlfwInputModes mode, bool value)
        {
            SetInputMode(window, mode, value ? 1 : 0);
        }

        /// <summary>
        /// This function swaps the front and back buffers of the specified window when rendering with OpenGL or OpenGL ES. 
        /// If the swap interval is greater than zero, the GPU driver waits the specified number of screen updates before 
        /// swapping the buffers.
        /// 
        /// The specified window must have an OpenGL or OpenGL ES context.
        /// Specifying a window without a context will generate a GLFW_NO_WINDOW_CONTEXT error.
        /// 
        /// This function does not apply to Vulkan. If you are rendering with Vulkan, see vkQueuePresentKHR instead.
        /// 
        /// Errors: Possible errors include GLFW_NOT_INITIALIZED, GLFW_NO_WINDOW_CONTEXT and GLFW_PLATFORM_ERROR.
        /// Thread safety: This function may be called from any thread.
        /// EGL: The context of the specified window must be current on the calling thread.
        /// </summary>
        /// <param name="window">The window whose buffers to swap.</param>
        [DllImport("glfw3.dll", EntryPoint = "glfwSwapBuffers", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void SwapBuffers(GLFWwindowPtr window);

        /// <summary>
        /// This function processes only those events that are already in the event queue and then returns immediately. Processing events will cause the window and input callbacks associated with those events to be called.
        /// 
        /// On some platforms, a window move, resize or menu operation will cause event processing to block.This is due to how event processing is designed on those platforms. You can use the window refresh callback to redraw the contents of your window when necessary during such operations.
        /// 
        /// Do not assume that callbacks you set will only be called in response to event processing functions like this one.While it is necessary to poll for events, window systems that require GLFW to register callbacks of its own can pass events to GLFW in response to many window system function calls.GLFW will pass those events on to the application callbacks before returning.
        /// 
        /// Event processing is not required for joystick input to work.
        /// 
        /// Errors: Possible errors include GLFW_NOT_INITIALIZED and GLFW_PLATFORM_ERROR.
        /// Reentrancy:  This function must not be called from a callback.
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        [DllImport("glfw3.dll", EntryPoint = "glfwPollEvents", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void PollEvents();

        /// <summary>
        /// This function returns the last state reported for the specified key to the specified window. 
        /// The returned state is one of GLFW_PRESS or GLFW_RELEASE. 
        /// The higher-level action GLFW_REPEAT is only reported to the key callback.
        /// 
        /// Errors: Possible errors include GLFW_NOT_INITIALIZED and GLFW_INVALID_ENUM.
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="window">The desired window.</param>
        /// <param name="key">The desired keyboard key. GLFW_KEY_UNKNOWN is not a valid key for this function.</param>
        /// <returns>One of GLFW_PRESS or GLFW_RELEASE.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetKey", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern int glfwGetKey(GLFWwindowPtr window, KeyboardKeys key);

        /// <summary>
        /// This function returns the last state reported for the specified key to the specified window. 
        /// The returned state is one of true if pressed or false if released. 
        /// The higher-level action GLFW_REPEAT is only reported to the key callback.
        /// 
        /// Errors: Possible errors include GLFW_NOT_INITIALIZED and GLFW_INVALID_ENUM.
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="window">The desired window.</param>
        /// <param name="key">The desired keyboard key. GLFW_KEY_UNKNOWN is not a valid key for this function.</param>
        /// <returns>true if pressed or false if released.</returns>

        public static bool GetKey(GLFWwindowPtr window, KeyboardKeys key)
        {
            return glfwGetKey(window, key) == 1;
        }

        /// <summary>
        /// This function returns the value of the close flag of the specified window.
        /// 
        /// Errors: Possible errors include GLFW_NOT_INITIALIZED.
        /// Thread safety: This function may be called from any thread.Access is not synchronized.
        /// </summary>
        /// <param name="window">The window to query.</param>
        /// <returns>The value of the close flag.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwWindowShouldClose", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern int glfwWindowShouldClose(GLFWwindowPtr window);

        /// <summary>
        /// This function returns the value of the close flag of the specified window.
        /// 
        /// Errors: Possible errors include GLFW_NOT_INITIALIZED.
        /// Thread safety: This function may be called from any thread.Access is not synchronized.
        /// </summary>
        /// <param name="window">The window to query.</param>
        /// <returns>true if the close flag is set; Otherwise, false.</returns>
        public static bool WindowShouldClose(GLFWwindowPtr window)
        {
            return glfwWindowShouldClose(window) >= 1;
        }

        /// <summary>
        /// This function sets the position, in screen coordinates, of the cursor relative to the upper-left corner of 
        /// the content area of the specified window. The window must have input focus. 
        /// If the window does not have input focus when this function is called, it fails silently.
        /// 
        /// Do not use this function to implement things like camera controls.
        /// GLFW already provides the GLFW_CURSOR_DISABLED cursor mode that hides the cursor, 
        /// transparently re-centers it and provides unconstrained cursor motion.
        /// See glfwSetInputMode for more information.
        /// 
        /// If the cursor mode is GLFW_CURSOR_DISABLED then the cursor position is unconstrained and 
        /// limited only by the minimum and maximum values of a double.
        /// 
        /// Remarks
        /// Wayland: This function will only work when the cursor mode is GLFW_CURSOR_DISABLED, otherwise it will do nothing.
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="window">The desired window.</param>
        /// <param name="xpos">The desired x-coordinate, relative to the left edge of the content area.</param>
        /// <param name="ypos">The desired y-coordinate, relative to the top edge of the content area.</param>
        [DllImport("glfw3.dll", EntryPoint = "glfwSetCursorPos", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void SetCursorPos(GLFWwindowPtr window, double xpos, double ypos);

        /// <summary>
        /// This function returns the position of the cursor, in screen coordinates, relative to the upper-left corner 
        /// of the content area of the specified window.
        /// 
        /// If the cursor is disabled (with GLFW_CURSOR_DISABLED) then the cursor position is unbounded and 
        /// limited only by the minimum and maximum values of a double.
        /// 
        /// The coordinate can be converted to their integer equivalents with the floor function.
        /// Casting directly to an integer type works for positive coordinates, but fails for negative ones.
        /// 
        /// Any or all of the position arguments may be NULL.If an error occurs, all non-NULL position arguments 
        /// will be set to zero.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="window">The desired window.</param>
        /// <param name="xpos">Where to store the cursor x-coordinate, relative to the left edge of the content area</param>
        /// <param name="ypos">Where to store the cursor y-coordinate, relative to the to top edge of the content area</param>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetCursorPos", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void GetCursorPos(GLFWwindowPtr window, out double xpos, out double ypos);

        /// <summary>
        /// This function returns the current GLFW time, in seconds. 
        /// Unless the time has been set using glfwSetTime it measures time elapsed since GLFW was initialized.
        /// 
        /// This function and glfwSetTime are helper functions on top of glfwGetTimerFrequency and glfwGetTimerValue.
        /// 
        /// The resolution of the timer is system dependent, but is usually on the order of a few micro- or nanoseconds.
        /// It uses the highest-resolution monotonic time source on each supported platform.
        /// 
        /// Thread safety: This function may be called from any thread.Reading and writing of the internal base 
        /// time is not atomic, so it needs to be externally synchronized with calls to glfwSetTime.
        /// </summary>
        /// <returns>The current time, in seconds, or zero if an error occurred.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetTime", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern double GetTime();

        /// <summary>
        /// This function retrieves the size, in pixels, of the framebuffer of the specified window. 
        /// If you wish to retrieve the size of the window in screen coordinates, see glfwGetWindowSize.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="window">The window whose framebuffer to query.</param>
        /// <param name="width">Where to store the width, in pixels, of the framebuffer</param>
        /// <param name="height">Where to store the height, in pixels, of the framebuffer</param>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetFramebufferSize", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void GetFramebufferSize(GLFWwindowPtr window, out int width, out int height);


        /// <summary>
        /// This function retrieves the size, in screen coordinates, of the content area of the specified window. 
        /// 
        /// If you wish to retrieve the size of the framebuffer of the window in pixels, see glfwGetFramebufferSize.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="window">The window whose size to retrieve.</param>
        /// <param name="width">Where to store the width, in screen coordinates, of the content area</param>
        /// <param name="height">Where to store the height, in screen coordinates, of the content area</param>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetWindowSize", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void GetWindowSize(GLFWwindowPtr window, out int width, out int height);

        [DllImport("glfw3.dll", EntryPoint = "glfwGetMouseButton", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int glfwGetMouseButton(GLFWwindowPtr window, MouseButtons button);

        /// <summary>
        /// This function returns the last state reported for the specified mouse button to the specified window. 
        /// The returned state is one of GLFW_PRESS or GLFW_RELEASE.
        /// 
        /// If the GLFW_STICKY_MOUSE_BUTTONS input mode is enabled, this function returns GLFW_PRESS the first
        /// time you call it for a mouse button that was pressed, even if that mouse button has already been released.
        /// </summary>
        /// <param name="window">The desired window</param>
        /// <param name="button">The desired mouse button.</param>
        /// <returns>true if the button is pressed; Otherwise false.</returns>
        public static bool GetMouseButton(GLFWwindowPtr window, MouseButtons button)
        {
            return glfwGetMouseButton(window, button) != 0;
        }

        /// <summary>
        /// This function returns the value of an input option for the specified window.
        /// 
        /// Errors: Possible errors include GLFW_NOT_INITIALIZED and GLFW_INVALID_ENUM.
        /// Thread safety:  This function must only be called from the main thread.
        /// </summary>
        /// <param name="window">The window to query.</param>
        /// <param name="mode">The mode to get</param>
        /// <returns>returns the value of an input option for the specified window.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetInputMode", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int GetInputMode(GLFWwindowPtr window, GlfwInputModes mode);

        [DllImport("glfw3.dll", EntryPoint = "glfwRawMouseMotionSupported", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern int glfwRawMouseMotionSupported();

        /// <summary>
        /// This function returns whether raw mouse motion is supported on the current system. 
        /// This status does not change after GLFW has been initialized so you only need to check this once. 
        /// If you attempt to enable raw motion on a system that does not support it, GLFW_PLATFORM_ERROR will be emitted.
        /// 
        /// Raw mouse motion is closer to the actual motion of the mouse across a surface.
        /// It is not affected by the scaling and acceleration applied to the motion of the desktop cursor.
        /// That processing is suitable for a cursor while raw motion is better for controlling for example a 3D camera.
        /// Because of this, raw mouse motion is only provided when the cursor is disabled.
        /// 
        /// Errors: Possible errors include GLFW_NOT_INITIALIZED.
        /// Thread safety : This function must only be called from the main thread.
        /// </summary>
        /// <returns>true if raw mouse motion is supported on the current machine, or false otherwise.</returns>
        public static bool RawMouseMotionSupported()
        {
            return glfwRawMouseMotionSupported() != 0;
        }

        [DllImport("glfw3.dll", EntryPoint = "glfwGetKeyName", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern IntPtr glfwGetKeyName(KeyboardKeys key, int scancode);

        /// <summary>
        /// This function returns the name of the specified printable key, encoded as UTF-8. 
        /// This is typically the character that key would produce without any modifier keys, intended for displaying 
        /// key bindings to the user. For dead keys, it is typically the diacritic it would add to a character.
        /// 
        /// Do not use this function for text input. You will break text input for many languages even if it happens to 
        /// work for yours.
        /// </summary>
        /// <remarks>
        /// 
        /// If the key is GLFW_KEY_UNKNOWN, the scancode is used to identify the key, otherwise the scancode is ignored.
        /// If you specify a non-printable key, or GLFW_KEY_UNKNOWN and a scancode that maps to a non-printable key, 
        /// this function returns NULL but does not emit an error.
        /// 
        /// This behavior allows you to always pass in the arguments in the key callback without modification.
        /// 
        /// The printable keys are:
        /// 
        /// GLFW_KEY_APOSTROPHE
        /// GLFW_KEY_COMMA
        /// GLFW_KEY_MINUS
        /// GLFW_KEY_PERIOD
        /// GLFW_KEY_SLASH
        /// GLFW_KEY_SEMICOLON
        /// GLFW_KEY_EQUAL
        /// GLFW_KEY_LEFT_BRACKET
        /// GLFW_KEY_RIGHT_BRACKET
        /// GLFW_KEY_BACKSLASH
        /// GLFW_KEY_WORLD_1
        /// GLFW_KEY_WORLD_2
        /// GLFW_KEY_0 to GLFW_KEY_9
        /// GLFW_KEY_A to GLFW_KEY_Z
        /// GLFW_KEY_KP_0 to GLFW_KEY_KP_9
        /// GLFW_KEY_KP_DECIMAL
        /// GLFW_KEY_KP_DIVIDE
        /// GLFW_KEY_KP_MULTIPLY
        /// GLFW_KEY_KP_SUBTRACT
        /// GLFW_KEY_KP_ADD
        /// GLFW_KEY_KP_EQUAL
        /// Names for printable keys depend on keyboard layout, while names for non-printable keys are the same across 
        /// layouts but depend on the application language and should be localized along with other user interface text.
        /// </remarks>
        /// <param name="key">The key to query, or GLFW_KEY_UNKNOWN</param>
        /// <param name="scancode">The scancode of the key to query.</param>
        /// <returns> layout-specific name of the key, or NULL.</returns>
        public static string GetKeyName(KeyboardKeys key, int scancode)
        {
            IntPtr result = glfwGetKeyName(key, scancode);

            string toreturn = "";
            char c = (char)Marshal.ReadByte(result);

            while (c != '\0')
            {
                toreturn += c;
                result += 1;
                c = (char)Marshal.ReadByte(result);
            }

            return toreturn;
        }

        /// <summary>
        /// This function returns the platform-specific scancode of the specified key.
        /// 
        /// If the key is GLFW_KEY_UNKNOWN or does not exist on the keyboard this method will return -1.
        /// 
        /// Thread safety: This function may be called from any thread.
        /// </summary>
        /// <param name="key">Any named key.</param>
        /// <returns>The platform-specific scancode for the key, or -1 if an error occurred.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetKeyScancode", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int GetKeyScancode(KeyboardKeys key);

        /// <summary>
        /// Creates a new custom cursor image that can be set for a window with glfwSetCursor. 
        /// The cursor can be destroyed with glfwDestroyCursor. 
        /// Any remaining cursors are destroyed by glfwTerminate.
        /// 
        /// The pixels are 32-bit, little-endian, non-premultiplied RGBA, i.e. eight bits per channel with the red channel first.
        /// They are arranged canonically as packed sequential rows, starting from the top-left corner.
        /// 
        /// The cursor hotspot is specified in pixels, relative to the upper-left corner of the cursor image. 
        /// Like all other coordinate systems in GLFW, the X-axis points to the right and the Y-axis points down.
        /// 
        /// Pointer lifetime:  The specified image data is copied before this function returns.
        /// Thread safety:  This function must only be called from the main thread.
        /// </summary>
        /// <param name="image">The desired cursor image.</param>
        /// <param name="xhot">The desired x-coordinate, in pixels, of the cursor hotspot.</param>
        /// <param name="yhot">The desired y-coordinate, in pixels, of the cursor hotspot.</param>
        /// <returns>The handle of the created cursor, or NULL if an error occurred.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwCreateCursor", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern GLFWcursorPtr CreateCursor(GLFWimage image, int xhot, int yhot);

        /// <summary>
        /// Returns a cursor with a standard shape, that can be set for a window with glfwSetCursor.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="shape">One of the standard shapes.</param>
        /// <returns>A new cursor ready to use or NULL if an error occurred.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwCreateStandardCursor", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern GLFWcursorPtr CreateStandardCursor(StandardCursorShapes shape);

        /// <summary>
        /// This function destroys a cursor previously created with glfwCreateCursor. 
        /// Any remaining cursors will be destroyed by glfwTerminate.
        /// 
        /// If the specified cursor is current for any window, that window will be reverted to the default cursor.
        /// This does not affect the cursor mode.
        /// 
        /// Reentrancy: This function must not be called from a callback.
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="cursor">The cursor object to destroy.</param>
        [DllImport("glfw3.dll", EntryPoint = "glfwDestroyCursor", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void DestroyCursor(GLFWcursorPtr cursor);

        /// <summary>
        /// This function sets the cursor image to be used when the cursor is over the content area of the 
        /// specified window. 
        /// The set cursor will only be visible when the cursor mode of the window is GLFW_CURSOR_NORMAL.
        /// 
        /// On some platforms, the set cursor may not be visible unless the window also has input focus.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="window">The window to set the cursor for.</param>
        /// <param name="cursor">The cursor to set, or NULL to switch back to the default arrow cursor.</param>
        [DllImport("glfw3.dll", EntryPoint = "glfwSetCursor", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void SetCursor(GLFWwindowPtr window, GLFWcursorPtr cursor);

        /// <summary>
        /// This function sets the key callback of the specified window, which is called when a key is pressed, 
        /// repeated or released.
        /// 
        /// The key functions deal with physical keys, with layout independent key tokens named after their values 
        /// in the standard US keyboard layout.If you want to input text, use the character callback instead.
        /// 
        /// When a window loses input focus, it will generate synthetic key release events for all pressed keys.
        /// You can tell these events from user-generated events by the fact that the synthetic ones are generated 
        /// after the focus loss event has been processed, i.e.after the window focus callback has been called.
        /// 
        /// The scancode of a key is specific to that platform or sometimes even to that machine. Scancodes are 
        /// intended to allow users to bind keys that don't have a GLFW key token. Such keys have key set to 
        /// GLFW_KEY_UNKNOWN, their state is not saved and so it cannot be queried with glfwGetKey.
        /// 
        /// 
        /// Sometimes GLFW needs to generate synthetic key events, in which case the scancode may be zero.
        /// </summary>
        /// <param name="window">The window whose callback to set.</param>
        /// <param name="callback">The new key callback, or NULL to remove the currently set callback.</param>
        /// <returns>The previously set callback, or NULL if no callback was set or the library had not been initialized.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwSetKeyCallback", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern GlfwDelegates.GLFWkeyfun SetKeyCallback(GLFWwindowPtr window, IntPtr callback);

        /// <summary>
        /// This function sets the key callback of the specified window, which is called when a key is pressed, 
        /// repeated or released.
        /// 
        /// The key functions deal with physical keys, with layout independent key tokens named after their values 
        /// in the standard US keyboard layout.If you want to input text, use the character callback instead.
        /// 
        /// When a window loses input focus, it will generate synthetic key release events for all pressed keys.
        /// You can tell these events from user-generated events by the fact that the synthetic ones are generated 
        /// after the focus loss event has been processed, i.e.after the window focus callback has been called.
        /// 
        /// The scancode of a key is specific to that platform or sometimes even to that machine. Scancodes are 
        /// intended to allow users to bind keys that don't have a GLFW key token. Such keys have key set to 
        /// GLFW_KEY_UNKNOWN, their state is not saved and so it cannot be queried with glfwGetKey.
        /// 
        /// 
        /// Sometimes GLFW needs to generate synthetic key events, in which case the scancode may be zero.
        /// </summary>
        /// <param name="window">The window whose callback to set.</param>
        /// <param name="callback">The new key callback, or NULL to remove the currently set callback.</param>
        /// <returns>The previously set callback, or NULL if no callback was set or the library had not been initialized.</returns>
        public static GlfwDelegates.GLFWkeyfun SetKeyCallback(GLFWwindowPtr window, GlfwDelegates.GLFWkeyfun callback)
        {
            IntPtr ip = Marshal.GetFunctionPointerForDelegate(callback);
            return SetKeyCallback(window, ip);
        }


        /// <summary>
        /// This function sets the character callback of the specified window, which is called when a 
        /// Unicode character is input.
        /// 
        /// The character callback is intended for Unicode text input.As it deals with characters, 
        /// it is keyboard layout dependent, whereas the key callback is not.
        /// Characters do not map 1:1 to physical keys, as a key may produce zero, one or more characters.
        /// If you want to know whether a specific physical key was pressed or released, see the key callback instead.
        /// 
        /// The character callback behaves as system text input normally does and will not be called if modifier 
        /// keys are held down that would prevent normal text input on that platform, for example a Super (Command) key 
        /// on macOS or Alt key on Windows.
        /// </summary>
        /// <param name="window">The window whose callback to set.</param>
        /// <param name="callback">The new callback, or NULL to remove the currently set callback.</param>
        /// <returns>The previously set callback, or NULL if no callback was set or the library had not been initialized.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwSetCharCallback", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern GlfwDelegates.GLFWcharfun SetCharCallback(GLFWwindowPtr window, IntPtr callback);

        /// <summary>
        /// This function sets the character callback of the specified window, which is called when a 
        /// Unicode character is input.
        /// 
        /// The character callback is intended for Unicode text input.As it deals with characters, 
        /// it is keyboard layout dependent, whereas the key callback is not.
        /// Characters do not map 1:1 to physical keys, as a key may produce zero, one or more characters.
        /// If you want to know whether a specific physical key was pressed or released, see the key callback instead.
        /// 
        /// The character callback behaves as system text input normally does and will not be called if modifier 
        /// keys are held down that would prevent normal text input on that platform, for example a Super (Command) key 
        /// on macOS or Alt key on Windows.
        /// </summary>
        /// <param name="window">The window whose callback to set.</param>
        /// <param name="callback">The new callback, or NULL to remove the currently set callback.</param>
        /// <returns>The previously set callback, or NULL if no callback was set or the library had not been initialized.</returns>
        public static GlfwDelegates.GLFWcharfun SetCharCallback(GLFWwindowPtr window, GlfwDelegates.GLFWcharfun callback)
        {
            IntPtr ip = Marshal.GetFunctionPointerForDelegate(callback);
            return SetCharCallback(window, ip);
        }

        /// <summary>
        /// This function sets the character with modifiers callback of the specified window, which is called when a 
        /// Unicode character is input regardless of what modifier keys are used.
        /// 
        /// The character with modifiers callback is intended for implementing custom Unicode character input.
        /// For regular Unicode text input, see the character callback.Like the character callback, the character with 
        /// modifiers callback deals with characters and is keyboard layout dependent.Characters do not map 1:1 to physical keys,
        /// as a key may produce zero, one or more characters. If you want to know whether a specific physical key was pressed
        /// or released, see the key callback instead.
        /// </summary>
        /// <param name="window">The window whose callback to set.</param>
        /// <param name="callback">The new callback, or NULL to remove the currently set callback.</param>
        /// <returns>The previously set callback, or NULL if no callback was set or an error occurred.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwSetCharModsCallback", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern GlfwDelegates.GLFWcharmodsfun SetCharModsCallback(GLFWwindowPtr window, IntPtr callback);

        /// <summary>
        /// This function sets the character with modifiers callback of the specified window, which is called when a 
        /// Unicode character is input regardless of what modifier keys are used.
        /// 
        /// The character with modifiers callback is intended for implementing custom Unicode character input.
        /// For regular Unicode text input, see the character callback.Like the character callback, the character with 
        /// modifiers callback deals with characters and is keyboard layout dependent.Characters do not map 1:1 to physical keys,
        /// as a key may produce zero, one or more characters. If you want to know whether a specific physical key was pressed
        /// or released, see the key callback instead.
        /// </summary>
        /// <param name="window">The window whose callback to set.</param>
        /// <param name="callback">The new callback, or NULL to remove the currently set callback.</param>
        /// <returns>The previously set callback, or NULL if no callback was set or an error occurred.</returns>
        public static GlfwDelegates.GLFWcharmodsfun SetCharModsCallback(GLFWwindowPtr window, GlfwDelegates.GLFWcharmodsfun callback)
        {
            IntPtr ip = Marshal.GetFunctionPointerForDelegate(callback);
            return SetCharModsCallback(window, ip);
        }

        /// <summary>
        /// This function sets the mouse button callback of the specified window, which is called when a mouse button is 
        /// pressed or released.
        /// 
        /// When a window loses input focus, it will generate synthetic mouse button release events for all pressed mouse buttons.
        /// You can tell these events from user-generated events by the fact that the synthetic ones are generated after the 
        /// focus loss event has been processed, i.e.after the window focus callback has been called.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="window">The window whose callback to set.</param>
        /// <param name="callback">The new callback, or NULL to remove the currently set callback.</param>
        /// <returns>The previously set callback, or NULL if no callback was set or the library had not been initialized.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwSetMouseButtonCallback", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern GlfwDelegates.GLFWmousebuttonfun SetMouseButtonCallback(GLFWwindowPtr window, IntPtr callback);

        public static GlfwDelegates.GLFWmousebuttonfun SetMouseButtonCallback(GLFWwindowPtr window, GlfwDelegates.GLFWmousebuttonfun callback)
        {
            IntPtr ip = Marshal.GetFunctionPointerForDelegate(callback);
            return SetMouseButtonCallback(window, ip);
        }

        /// <summary>
        /// This function sets the cursor position callback of the specified window, which is called when the cursor is 
        /// moved. The callback is provided with the position, in screen coordinates, relative to the upper-left 
        /// corner of the content area of the window.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="window">The window whose callback to set.</param>
        /// <param name="callback">The new callback, or NULL to remove the currently set callback.</param>
        /// <returns>The previously set callback, or NULL if no callback was set or the library had not been initialized.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwSetCursorPosCallback", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern GlfwDelegates.GLFWcursorposfun SetCursorPosCallback(GLFWwindowPtr window, IntPtr callback);

        /// <summary>
        /// This function sets the cursor position callback of the specified window, which is called when the cursor is 
        /// moved. The callback is provided with the position, in screen coordinates, relative to the upper-left 
        /// corner of the content area of the window.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="window">The window whose callback to set.</param>
        /// <param name="callback">The new callback, or NULL to remove the currently set callback.</param>
        /// <returns>The previously set callback, or NULL if no callback was set or the library had not been initialized.</returns>
        public static GlfwDelegates.GLFWcursorposfun SetCursorPosCallback(GLFWwindowPtr window, GlfwDelegates.GLFWcursorposfun callback)
        {
            IntPtr ip = Marshal.GetFunctionPointerForDelegate(callback);
            return SetCursorPosCallback(window, ip);
        }

        /// <summary>
        /// This function sets the cursor boundary crossing callback of the specified window, 
        /// which is called when the cursor enters or leaves the content area of the window.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="window">The window whose callback to set.</param>
        /// <param name="callback">The new callback, or NULL to remove the currently set callback.</param>
        /// <returns>The previously set callback, or NULL if no callback was set or the library had not been initialized.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwSetCursorEnterCallback", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern GlfwDelegates.GLFWcursorenterfun SetCursorEnterCallback(GLFWwindowPtr window, IntPtr callback);

        /// <summary>
        /// This function sets the cursor boundary crossing callback of the specified window, 
        /// which is called when the cursor enters or leaves the content area of the window.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="window">The window whose callback to set.</param>
        /// <param name="callback">The new callback, or NULL to remove the currently set callback.</param>
        /// <returns>The previously set callback, or NULL if no callback was set or the library had not been initialized.</returns>
        public static GlfwDelegates.GLFWcursorenterfun SetCursorEnterCallback(GLFWwindowPtr window, GlfwDelegates.GLFWcursorenterfun callback)
        {
            IntPtr ip = Marshal.GetFunctionPointerForDelegate(callback);
            return SetCursorEnterCallback(window, ip);
        }

        /// <summary>
        /// This function sets the scroll callback of the specified window, which is called when a scrolling device 
        /// is used, such as a mouse wheel or scrolling area of a touchpad.
        /// 
        /// The scroll callback receives all scrolling input, like that from a mouse wheel or a touchpad scrolling area.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="window">The window whose callback to set.</param>
        /// <param name="callback">The new scroll callback, or NULL to remove the currently set callback.</param>
        /// <returns>The previously set callback, or NULL if no callback was set or the library had not been initialized.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwSetScrollCallback", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern GlfwDelegates.GLFWscrollfun SetScrollCallback(GLFWwindowPtr window, IntPtr callback);

        /// <summary>
        /// This function sets the scroll callback of the specified window, which is called when a scrolling device 
        /// is used, such as a mouse wheel or scrolling area of a touchpad.
        /// 
        /// The scroll callback receives all scrolling input, like that from a mouse wheel or a touchpad scrolling area.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="window">The window whose callback to set.</param>
        /// <param name="callback">The new scroll callback, or NULL to remove the currently set callback.</param>
        /// <returns>The previously set callback, or NULL if no callback was set or the library had not been initialized.</returns>
        public static GlfwDelegates.GLFWscrollfun SetScrollCallback(GLFWwindowPtr window, GlfwDelegates.GLFWscrollfun callback)
        {
            IntPtr ip = Marshal.GetFunctionPointerForDelegate(callback);
            return SetScrollCallback(window, ip);
        }

        /// <summary>
        /// This function sets the path drop callback of the specified window, which is called when one or more dragged paths 
        /// are dropped on the window.
        /// 
        /// Because the path array and its strings may have been generated specifically for that event, they are not guaranteed 
        /// to be valid after the callback has returned. If you wish to use them after the callback returns, you need to make a 
        /// deep copy.
        /// 
        /// Remarks: Wayland - File drop is currently unimplemented.
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="window">The window whose callback to set.</param>
        /// <param name="callback">The new file drop callback, or NULL to remove the currently set callback.</param>
        /// <returns>The previously set callback, or NULL if no callback was set or the library had not been initialized.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwSetDropCallback", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern GlfwDelegates.GLFWdropfun SetDropCallback(GLFWwindowPtr window, IntPtr callback);

        /// <summary>
        /// This function sets the path drop callback of the specified window, which is called when one or more dragged paths 
        /// are dropped on the window.
        /// 
        /// Because the path array and its strings may have been generated specifically for that event, they are not guaranteed 
        /// to be valid after the callback has returned. If you wish to use them after the callback returns, you need to make a 
        /// deep copy.
        /// 
        /// Remarks: Wayland - File drop is currently unimplemented.
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="window">The window whose callback to set.</param>
        /// <param name="callback">The new file drop callback, or NULL to remove the currently set callback.</param>
        /// <returns>The previously set callback, or NULL if no callback was set or the library had not been initialized.</returns>
        public static GlfwDelegates.GLFWdropfun SetDropCallback(GLFWwindowPtr window, GlfwDelegates.GLFWdropfun callback)
        {
            IntPtr ip = Marshal.GetFunctionPointerForDelegate(callback);
            return SetDropCallback(window, ip);
        }

        /// <summary>
        /// This function returns whether the specified joystick is present.
        /// 
        /// There is no need to call this function before other functions that accept a joystick ID, 
        /// as they all check for presence before performing any other work.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="jid">The joystick to query.</param>
        /// <returns>true if the joystick is present, or false otherwise.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwJoystickPresent", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int JoystickPresent(Joysticks jid);

        /// <summary>
        /// This function returns the values of all axes of the specified joystick. 
        /// Each element in the array is a value between -1.0 and 1.0.
        /// 
        /// If the specified joystick is not present this function will return NULL but will not generate an error.
        /// This can be used instead of first calling glfwJoystickPresent.
        /// 
        /// Pointer lifetime: The returned array is allocated and freed by GLFW.You should not free it yourself.
        /// It is valid until the specified joystick is disconnected or the library is terminated.
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="jid">The joystick to query.</param>
        /// <param name="count">
        /// Where to store the number of axis values in the returned array. 
        /// This is set to zero if the joystick is not present or an error occurred.
        /// </param>
        /// <returns>An array of axis values, or NULL if the joystick is not present or an error occurred.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetJoystickAxes", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern float[] GetJoystickAxes(Joysticks jid, out int count);

        /// <summary>
        /// This function returns the state of all buttons of the specified joystick. Each element in the array is 
        /// either GLFW_PRESS or GLFW_RELEASE.
        /// 
        /// For backward compatibility with earlier versions that did not have glfwGetJoystickHats, the button array 
        /// also includes all hats, each represented as four buttons.
        /// The hats are in the same order as returned by glfwGetJoystickHats and are in the order 
        /// up, right, down and left.
        /// To disable these extra buttons, set the GLFW_JOYSTICK_HAT_BUTTONS init hint before initialization.
        /// 
        /// If the specified joystick is not present this function will return NULL but will not generate an error.
        /// This can be used instead of first calling glfwJoystickPresent.
        /// 
        /// Pointer lifetime: The returned array is allocated and freed by GLFW.You should not free it yourself.It is valid until the specified joystick is disconnected or the library is terminated.
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="jid">The joystick to query.</param>
        /// <param name="count">Where to store the number of button states in the returned array. This is set to zero if the joystick is not present or an error occurred.</param>
        /// <returns>An array of button states, or NULL if the joystick is not present or an error occurred.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetJoystickButtons", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern byte[] GetJoystickButtons(Joysticks jid, out int count);

        /// <summary>
        /// This function returns the state of all hats of the specified joystick.
        /// </summary>
        /// <param name="jid">The joystick to query.</param>
        /// <param name="count">Where to store the number of hat states in the returned array. This is set to zero if the joystick is not present or an error occurred.</param>
        /// <returns>An array of hat states, or NULL if the joystick is not present or an error occurred.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetJoystickHats", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern JoystickHats[] GetJoystickHats(Joysticks jid, out int count);

        [DllImport("glfw3.dll", EntryPoint = "glfwGetJoystickName", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern IntPtr glfwGetJoystickName(Joysticks jid);

        /// <summary>
        /// This function returns the name, encoded as UTF-8, of the specified joystick. 
        /// The returned string is allocated and freed by GLFW. You should not free it yourself.
        /// 
        /// If the specified joystick is not present this function will return NULL but will not generate an error.
        /// This can be used instead of first calling glfwJoystickPresent.
        /// 
        /// Pointer lifetime: The returned string is allocated and freed by GLFW.You should not free it yourself.It is valid until the specified joystick is disconnected or the library is terminated.
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="jid">The joystick to query.</param>
        /// <returns>The UTF-8 encoded name of the joystick, or NULL if the joystick is not present or an error occurred.</returns>
        public static string GetJoystickName(Joysticks jid)
        {
            IntPtr result = glfwGetJoystickName(jid);

            string toreturn = "";
            char c = (char)Marshal.ReadByte(result);

            while (c != '\0')
            {
                toreturn += c;
                result += 1;
                c = (char)Marshal.ReadByte(result);
            }

            return toreturn;
        }

        [DllImport("glfw3.dll", EntryPoint = "glfwGetJoystickGUID", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr glfwGetJoystickGUID(Joysticks jid);

        /// <summary>
        /// This function returns the SDL compatible GUID, as a UTF-8 encoded hexadecimal string, 
        /// of the specified joystick. The returned string is allocated and freed by GLFW. 
        /// You should not free it yourself.
        /// 
        /// The GUID is what connects a joystick to a gamepad mapping. A connected joystick will always have a 
        /// GUID even if there is no gamepad mapping assigned to it.
        /// 
        /// If the specified joystick is not present this function will return NULL but will not generate an error.
        /// This can be used instead of first calling glfwJoystickPresent.
        /// 
        /// The GUID uses the format introduced in SDL 2.0.5. This GUID tries to uniquely identify the make and model 
        /// of a joystick but does not identify a specific unit, e.g. all wired Xbox 360 controllers will have the 
        /// same GUID on that platform. The GUID for a unit may vary between platforms depending on what hardware 
        /// information the platform specific APIs provide.
        /// 
        /// Pointer lifetime: The returned string is allocated and freed by GLFW.You should not free it yourself.It is valid until the specified joystick is disconnected or the library is terminated.
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="jid">The joystick to query.</param>
        /// <returns>The UTF-8 encoded GUID of the joystick, or NULL if the joystick is not present or an error occurred.</returns>
        public static string GetJoystickGUID(Joysticks jid)
        {
            IntPtr result = glfwGetJoystickGUID(jid);

            string toreturn = "";
            char c = (char)Marshal.ReadByte(result);

            while (c != '\0')
            {
                toreturn += c;
                result += 1;
                c = (char)Marshal.ReadByte(result);
            }

            return toreturn;
        }

        /// <summary>
        /// This function sets the user-defined pointer of the specified joystick. The current value is retained 
        /// until the joystick is disconnected. The initial value is NULL.
        /// 
        /// This function may be called from the joystick callback, even for a joystick that is being disconnected.
        /// 
        /// Thread safety: This function may be called from any thread.Access is not synchronized.
        /// </summary>
        /// <param name="jid">The joystick whose pointer to set.</param>
        /// <param name="pointer">The new value.</param>
        [DllImport("glfw3.dll", EntryPoint = "glfwSetJoystickUserPointer", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void SetJoystickUserPointer(Joysticks jid, IntPtr pointer);

        /// <summary>
        /// This function returns the current value of the user-defined pointer of the specified joystick. The initial value is NULL.
        /// 
        /// This function may be called from the joystick callback, even for a joystick that is being disconnected.
        /// 
        /// Thread safety: This function may be called from any thread.Access is not synchronized.
        /// </summary>
        /// <param name="jid">The joystick whose pointer to return.</param>
        /// <returns>the user-defined pointer of the specified joystick. Or null if un-set.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetJoystickUserPointer", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr GetJoystickUserPointer(Joysticks jid);

        /// <summary>
        /// This function returns whether the specified joystick is both present and has a gamepad mapping.
        /// 
        /// If the specified joystick is present but does not have a gamepad mapping this function will return false but 
        /// will not generate an error. Call glfwJoystickPresent to check if a joystick is present regardless of whether 
        /// it has a mapping.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="jid">The joystick to query.</param>
        /// <returns>true if a joystick is both present and has a gamepad mapping, or false otherwise.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwJoystickIsGamepad", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int JoystickIsGamepad(Joysticks jid);

        /// <summary>
        /// This function sets the joystick configuration callback, or removes the currently set callback. 
        /// This is called when a joystick is connected to or disconnected from the system.
        /// 
        /// For joystick connection and disconnection events to be delivered on all platforms, 
        /// you need to call one of the event processing functions.Joystick disconnection may also be 
        /// detected and the callback called by joystick functions.
        /// The function will then return whatever it returns if the joystick is not present.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="callback">The new callback, or NULL to remove the currently set callback.</param>
        /// <returns>The previously set callback, or NULL if no callback was set or the library had not been initialized.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwSetJoystickCallback", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern GlfwDelegates.GLFWjoystickfun SetJoystickCallback(IntPtr callback);

        /// <summary>
        /// This function sets the joystick configuration callback, or removes the currently set callback. 
        /// This is called when a joystick is connected to or disconnected from the system.
        /// 
        /// For joystick connection and disconnection events to be delivered on all platforms, 
        /// you need to call one of the event processing functions.Joystick disconnection may also be 
        /// detected and the callback called by joystick functions.
        /// The function will then return whatever it returns if the joystick is not present.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="callback">The new callback, or NULL to remove the currently set callback.</param>
        /// <returns>The previously set callback, or NULL if no callback was set or the library had not been initialized.</returns>
        public static GlfwDelegates.GLFWjoystickfun SetJoystickCallback(GlfwDelegates.GLFWjoystickfun callback)
        {
            IntPtr ip = Marshal.GetFunctionPointerForDelegate(callback);
            return SetJoystickCallback(ip);
        }

        /// <summary>
        /// This function parses the specified ASCII encoded string and updates the internal list with any 
        /// gamepad mappings it finds. This string may contain either a single gamepad mapping or many mappings 
        /// separated by newlines. The parser supports the full format of the gamecontrollerdb.txt source file 
        /// including empty lines and comments.
        /// 
        /// See Gamepad mappings for a description of the format.
        /// 
        /// If there is already a gamepad mapping for a given GUID in the internal list, it will be replaced by 
        /// the one passed to this function.If the library is terminated and re-initialized the internal list will 
        /// revert to the built-in default.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="str">The string containing the gamepad mappings.</param>
        /// <returns>true if successful, or false if an error occurred.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwUpdateGamepadMappings", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int UpdateGamepadMappings(string str);

        /// <summary>
        /// This function returns the human-readable name of the gamepad from the gamepad mapping assigned to the 
        /// specified joystick.
        /// 
        /// If the specified joystick is not present or does not have a gamepad mapping this function will return 
        /// NULL but will not generate an error.Call glfwJoystickPresent to check whether it is present regardless of 
        /// whether it has a mapping.
        /// 
        /// Pointer lifetime: The returned string is allocated and freed by GLFW. You should not free it yourself.
        /// It is valid until the specified joystick is disconnected, the gamepad mappings are updated or the 
        /// library is terminated.
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="jid">The joystick to query.</param>
        /// <returns>The UTF-8 encoded name of the gamepad, or NULL if the joystick is not present, does not have a mapping or an error occurred.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetGamepadName", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern IntPtr glfwGetGamepadName(Joysticks jid);

        /// <summary>
        /// This function returns the human-readable name of the gamepad from the gamepad mapping assigned to the 
        /// specified joystick.
        /// 
        /// If the specified joystick is not present or does not have a gamepad mapping this function will return 
        /// NULL but will not generate an error.Call glfwJoystickPresent to check whether it is present regardless of 
        /// whether it has a mapping.
        /// 
        /// Pointer lifetime: The returned string is allocated and freed by GLFW. You should not free it yourself.
        /// It is valid until the specified joystick is disconnected, the gamepad mappings are updated or the 
        /// library is terminated.
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="jid">The joystick to query.</param>
        /// <returns>The UTF-8 encoded name of the gamepad, or NULL if the joystick is not present, does not have a mapping or an error occurred.</returns>
        public static string GetGamepadName(Joysticks jid)
        {
            IntPtr result = glfwGetGamepadName(jid);

            string toreturn = "";
            char c = (char)Marshal.ReadByte(result);

            while (c != '\0')
            {
                toreturn += c;
                result += 1;
                c = (char)Marshal.ReadByte(result);
            }

            return toreturn;
        }

        /// <summary>
        /// This function retrieves the state of the specified joystick remapped to an Xbox-like gamepad.
        /// 
        /// If the specified joystick is not present or does not have a gamepad mapping this function will return 
        /// false but will not generate an error. Call glfwJoystickPresent to check whether it is present 
        /// regardless of whether it has a mapping.
        /// 
        /// The Guide button may not be available for input as it is often hooked by the system or the Steam client.
        /// 
        /// Not all devices have all the buttons or axes provided by GLFWgamepadstate. 
        /// Unavailable buttons and axes will always report GLFW_RELEASE and 0.0 respectively.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="jid">The joystick to query</param>
        /// <param name="state">The gamepad input state of the joystick.</param>
        /// <returns>true if successful, or false if no joystick is connected, it has no gamepad mapping or an error occurred.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetGamepadState", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int GetGamepadState(Joysticks jid, out GLFWgamepadstate state);

        /// <summary>
        /// This function sets the system clipboard to the specified, UTF-8 encoded string.
        /// 
        /// Pointer lifetime: The specified string is copied before this function returns.
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="window">Deprecated. Any valid window or NULL.</param>
        /// <param name="str">A UTF-8 encoded string.</param>
        [DllImport("glfw3.dll", EntryPoint = "glfwSetClipboardString", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void SetClipboardString(GLFWwindowPtr window, string str);

        [DllImport("glfw3.dll", EntryPoint = "glfwGetClipboardString", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern IntPtr glfwGetClipboardString(GLFWwindowPtr window);

        /// <summary>
        /// This function returns the contents of the system clipboard, if it contains or is convertible to a 
        /// UTF-8 encoded string. If the clipboard is empty or if its contents cannot be converted, 
        /// NULL is returned and a GLFW_FORMAT_UNAVAILABLE error is generated.
        /// 
        /// Pointer lifetime: The returned string is allocated and freed by GLFW.You should not free it yourself.It is valid until the next call to glfwGetClipboardString or glfwSetClipboardString, or until the library is terminated.
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="window">Deprecated. Any valid window or NULL.</param>
        /// <returns>The contents of the clipboard as a UTF-8 encoded string, or NULL if an error occurred.</returns>
        public static string GetClipboardString(GLFWwindowPtr window)
        {
            IntPtr result = glfwGetClipboardString(window);

            string toreturn = "";
            char c = (char)Marshal.ReadByte(result);

            while (c != '\0')
            {
                toreturn += c;
                result += 1;
                c = (char)Marshal.ReadByte(result);
            }

            return toreturn;
        }

        /// <summary>
        /// This function sets the current GLFW time, in seconds. The value must be a positive finite number less 
        /// than or equal to 18446744073.0, which is approximately 584.5 years.
        /// 
        /// This function and glfwGetTime are helper functions on top of glfwGetTimerFrequency and glfwGetTimerValue.
        /// 
        /// Thread safety: This function may be called from any thread.Reading and writing of the internal base time is not atomic, so it needs to be externally synchronized with calls to glfwGetTime.
        /// </summary>
        /// <remarks>
        /// The upper limit of GLFW time is calculated as floor((264 - 1) / 109) and is due to implementations storing 
        /// nanoseconds in 64 bits. The limit may be increased in the future.
        /// </remarks>
        /// <param name="time">The new value, in seconds.</param>
        [DllImport("glfw3.dll", EntryPoint = "glfwSetTime", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void SetTime(double time);

        /// <summary>
        /// This function returns the current value of the raw timer, measured in 1 / frequency seconds. 
        /// To get the frequency, call glfwGetTimerFrequency.
        /// 
        /// Thread safety: This function may be called from any thread.
        /// </summary>
        /// <returns>The value of the timer, or zero if an error occurred.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetTimerValue", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern ulong GetTimerValue();

        /// <summary>
        /// This function returns the frequency, in Hz, of the raw timer.
        /// 
        /// Thread safety: This function may be called from any thread.
        /// </summary>
        /// <returns>The frequency of the timer, in Hz, or zero if an error occurred.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetTimerFrequency", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern ulong GetTimerFrequency();


        /// <summary>
        /// This function sets hints for the next initialization of GLFW.
        /// 
        /// The values you set hints to are never reset by GLFW, but they only take effect during initialization.
        /// Once GLFW has been initialized, any values you set will be ignored until the library is terminated and 
        /// initialized again.
        /// 
        /// Some hints are platform specific. These may be set on any platform but they will only affect their 
        /// specific platform.Other platforms will ignore them.
        /// Setting these hints requires no platform specific headers or functions.
        /// </summary>
        /// <param name="hint">The init hint to set.</param>
        /// <param name="value">The new value of the init hint.</param>
        [DllImport("glfw3.dll", EntryPoint = "glfwInitHint", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void InitHint(InitHints hint, int value);

        /// <summary>
        /// This function retrieves the major, minor and revision numbers of the GLFW library. 
        /// It is intended for when you are using GLFW as a shared library and want to ensure that 
        /// you are using the minimum required version.
        /// </summary>
        /// <param name="major">Where to store the major version number</param>
        /// <param name="minor">Where to store the minor version number</param>
        /// <param name="rev">Where to store the revision number</param>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetVersion", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void GetVersion(out int major, out int minor, out int rev);

        [DllImport("glfw3.dll", EntryPoint = "glfwGetVersionString", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern IntPtr glfwGetVersionString();

        /// <summary>
        /// This function returns the compile-time generated version string of the GLFW library binary. 
        /// It describes the version, platform, compiler and any platform-specific compile-time options. 
        /// It should not be confused with the OpenGL or OpenGL ES version string, queried with glGetString.
        /// 
        /// Do not use the version string to parse the GLFW library version.
        /// The glfwGetVersion function provides the version of the running library binary in numerical format.
        /// </summary>
        /// <returns>The ASCII encoded GLFW version string.</returns>
        public static string GetVersionString()
        {
            IntPtr result = glfwGetVersionString();

            string toreturn = "";
            char c = (char)Marshal.ReadByte(result);

            while (c != '\0')
            {
                toreturn += c;
                result += 1;
                c = (char)Marshal.ReadByte(result);
            }

            return toreturn;
        }

        /// <summary>
        /// This function returns and clears the error code of the last error that occurred on the calling thread, 
        /// and optionally a UTF-8 encoded human-readable description of it. 
        /// If no error has occurred since the last call, it returns GLFW_NO_ERROR (zero) and the description 
        /// pointer is set to NULL.
        /// 
        /// Remarks: This function may be called before glfwInit.
        /// Thread safety: This function may be called from any thread.
        /// </summary>
        /// <param name="description">Where to store the error description pointer, or NULL.</param>
        /// <returns>The last error code for the calling thread, or GLFW_NO_ERROR (zero).</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetError", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern GlfwError GetError(string description);

        /// <summary>
        /// This function sets the error callback, which is called with an error code and a human-readable 
        /// description each time a GLFW error occurs.
        /// 
        /// The error code is set before the callback is called.Calling glfwGetError from the error callback 
        /// will return the same value as the error code argument.
        /// 
        /// The error callback is called on the thread where the error occurred. If you are using GLFW from 
        /// multiple threads, your error callback needs to be written accordingly.
        /// 
        /// Because the description string may have been generated specifically for that error, 
        /// it is not guaranteed to be valid after the callback has returned. If you wish to use it after the 
        /// callback returns, you need to make a copy.
        /// 
        /// 
        /// Once set, the error callback remains set even after the library has been terminated.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="callback">The new callback, or NULL to remove the currently set callback.</param>
        /// <returns>The previously set callback, or NULL if no callback was set.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwSetErrorCallback", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern GlfwDelegates.GLFWerrorfun SetErrorCallback(GlfwDelegates.GLFWerrorfun callback);

        /// <summary>
        /// This function returns an array of handles for all currently connected monitors. 
        /// The primary monitor is always first in the returned array.
        /// If no monitors were found, this function returns NULL.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="count">
        /// Where to store the number of monitors in the returned array. 
        /// This is set to zero if an error occurred.
        /// </param>
        /// <returns>An array of monitor handles, or NULL if no monitors were found or if an error occurred.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetMonitors", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern GLFWmonitorPtr[] GetMonitors(out int count);

        /// <summary>
        /// This function returns the primary monitor. 
        /// This is usually the monitor where elements like the task bar or global menu bar are located.
        /// </summary>
        /// <returns>The primary monitor, or NULL if no monitors were found or if an error occurred.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetPrimaryMonitor", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern GLFWmonitorPtr GetPrimaryMonitor();

        /// <summary>
        /// This function returns the position, in screen coordinates, of the upper-left corner of the specified monitor.
        /// 
        /// Any or all of the position arguments may be NULL. If an error occurs, all non-NULL position arguments 
        /// will be set to zero.
        /// </summary>
        /// <param name="monitor">The monitor to query.</param>
        /// <param name="xpos">Where to store the monitor x-coordinate</param>
        /// <param name="ypos">Where to store the monitor y-coordinate</param>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetMonitorPos", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void GetMonitorPos(GLFWmonitorPtr monitor, out int xpos, out int ypos);

        /// <summary>
        /// This function returns the position, in screen coordinates, of the upper-left corner of the work area 
        /// of the specified monitor along with the work area size in screen coordinates. 
        /// The work area is defined as the area of the monitor not occluded by the operating system task 
        /// bar where present. If no task bar exists then the work area is the monitor resolution in screen coordinates.
        /// 
        /// Any or all of the position and size arguments may be NULL.If an error occurs, all non-NULL position and 
        /// size arguments will be set to zero.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="monitor">The monitor to query.</param>
        /// <param name="xpos">Where to store the monitor x-coordinate</param>
        /// <param name="ypos">Where to store the monitor y-coordinate</param>
        /// <param name="width">Where to store the monitor width</param>
        /// <param name="height">Where to store the monitor height</param>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetMonitorWorkarea", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void GetMonitorWorkarea(GLFWmonitorPtr monitor, out int xpos, out int ypos, out int width, out int height);

        /// <summary>
        /// This function returns the size, in millimetres, of the display area of the specified monitor.
        /// 
        /// Some systems do not provide accurate monitor size information, either because the monitor EDID data 
        /// is incorrect or because the driver does not report it accurately.
        /// 
        /// Any or all of the size arguments may be NULL. If an error occurs, all non-NULL size arguments will 
        /// be set to zero.
        /// 
        /// Remarks: Windows: On Windows 8 and earlier the physical size is calculated from the current resolution and system DPI instead of querying the monitor EDID data.
        /// Thread safety: This function must only be called from the main thread
        /// </summary>
        /// <param name="monitor">The monitor to query.</param>
        /// <param name="widthMM">Where to store the width, in millimetres, of the monitor's display area</param>
        /// <param name="heightMM">Where to store the height, in millimetres, of the monitor's display area</param>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetMonitorPhysicalSize", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void GetMonitorPhysicalSize(GLFWmonitorPtr monitor, out int widthMM, out int heightMM);

        /// <summary>
        /// This function retrieves the content scale for the specified monitor. The content scale is the ratio 
        /// between the current DPI and the platform's default DPI. This is especially important for text and any 
        /// UI elements. If the pixel dimensions of your UI scaled by this look appropriate on your machine then it 
        /// should appear at a reasonable size on other machines regardless of their DPI and scaling settings. 
        /// This relies on the system DPI and scaling settings being somewhat correct.
        /// 
        /// The content scale may depend on both the monitor resolution and pixel density and on user settings.
        /// It may be very different from the raw DPI calculated from the physical size and current resolution.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="monitor">The monitor to query.</param>
        /// <param name="xscale">Where to store the x-axis content scale</param>
        /// <param name="yscale">Where to store the y-axis content scale</param>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetMonitorContentScale", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void GetMonitorContentScale(GLFWmonitorPtr monitor, out float xscale, out float yscale);

        [DllImport("glfw3.dll", EntryPoint = "glfwGetMonitorName", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern IntPtr glfwGetMonitorName(GLFWmonitorPtr monitor);

        /// <summary>
        /// This function returns a human-readable name, encoded as UTF-8, of the specified monitor. 
        /// The name typically reflects the make and model of the monitor and is not guaranteed to be 
        /// unique among the connected monitors.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="monitor">The monitor to query.</param>
        /// <returns>The UTF-8 encoded name of the monitor, or NULL if an error occurred.</returns>
        public static string GetMonitorName(GLFWmonitorPtr monitor)
        {
            IntPtr result = glfwGetMonitorName(monitor);

            string toreturn = "";
            char c = (char)Marshal.ReadByte(result);

            while (c != '\0')
            {
                toreturn += c;
                result += 1;
                c = (char)Marshal.ReadByte(result);
            }

            return toreturn;
        }

        /// <summary>
        /// This function sets the user-defined pointer of the specified monitor. The current value is 
        /// retained until the monitor is disconnected. The initial value is NULL.
        /// 
        /// This function may be called from the monitor callback, even for a monitor that is being disconnected.
        /// 
        /// Thread safety: This function may be called from any thread.Access is not synchronized.
        /// </summary>
        /// <param name="monitor">The monitor whose pointer to set.</param>
        /// <param name="pointer">The new value.</param>
        [DllImport("glfw3.dll", EntryPoint = "glfwSetMonitorUserPointer", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void SetMonitorUserPointer(GLFWmonitorPtr monitor, IntPtr pointer);

        /// <summary>
        /// This function returns the current value of the user-defined pointer of the specified monitor. 
        /// The initial value is NULL.
        ///
        ///This function may be called from the monitor callback, even for a monitor that is being disconnected.
        ///
        /// Thread safety: This function may be called from any thread. Access is not synchronized.
        /// </summary>
        /// <param name="monitor">The monitor whose pointer to return.</param>
        /// <returns>Returns the current value of the user-defined pointer of the specified monitor.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetMonitorUserPointer", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr GetMonitorUserPointer(GLFWmonitorPtr monitor);

        /// <summary>
        /// This function sets the monitor configuration callback, or removes the currently set callback. 
        /// This is called when a monitor is connected to or disconnected from the system.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="callback">The new callback, or NULL to remove the currently set callback.</param>
        /// <returns>The previously set callback, or NULL if no callback was set or the library had not been initialized.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwSetMonitorCallback", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern GlfwDelegates.GLFWmonitorfun SetMonitorCallback(GlfwDelegates.GLFWmonitorfun callback);

        [DllImport("glfw3.dll", EntryPoint = "glfwGetVideoModes", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr glfwGetVideoModes(GLFWmonitorPtr monitor, out int count);

        /// <summary>
        /// This function returns an array of all video modes supported by the specified monitor. 
        /// The returned array is sorted in ascending order, first by color bit depth (the sum of all channel depths), 
        /// then by resolution area (the product of width and height), then resolution width and finally by refresh rate.
        /// </summary>
        /// <param name="monitor">The monitor to query.</param>
        /// <param name="count">
        /// Where to store the number of video modes in the returned array. 
        /// This is set to zero if an error occurred.
        /// </param>
        /// <returns>An array of video modes, or NULL if an error occurred.</returns>
        public static GLFWvidmode[] GetVideoModes(GLFWmonitorPtr monitor, out int count)
        {
            IntPtr ptr = glfwGetVideoModes(monitor, out count);

            int sz = Marshal.SizeOf(typeof(GLFWvidmode));
            GLFWvidmode[] modes = new GLFWvidmode[count];

            //byte[] data = new byte[sz * count];
            //Marshal.Copy(ptr, data, 0, count);

            for (int i = 0; i < count; i++)
            {
                modes[i] = Marshal.PtrToStructure<GLFWvidmode>(ptr);
                ptr += sz;
            }

            return modes;
        }

        /// <summary>
        /// This function returns the current video mode of the specified monitor. 
        /// If you have created a full screen window for that monitor, the return value will depend on whether 
        /// that window is iconified.
        /// </summary>
        /// <param name="monitor">The monitor to query.</param>
        /// <returns>The current mode of the monitor, or NULL if an error occurred.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetVideoMode", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern GLFWvidmode GetVideoMode(GLFWmonitorPtr monitor);

        /// <summary>
        /// This function generates an appropriately sized gamma ramp from the specified exponent and then calls 
        /// glfwSetGammaRamp with it. The value must be a finite number greater than zero.
        /// 
        /// The software controlled gamma ramp is applied in addition to the hardware gamma correction, 
        /// which today is usually an approximation of sRGB gamma. This means that setting a perfectly linear ramp, 
        /// or gamma 1.0, will produce the default (usually sRGB-like) behavior.
        /// 
        /// For gamma correct rendering with OpenGL or OpenGL ES, see the GLFW_SRGB_CAPABLE hint.
        /// 
        /// Remarks: Wayland: Gamma handling is a privileged protocol, this function will thus never be implemented 
        /// and emits GLFW_PLATFORM_ERROR.
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="monitor">The monitor whose gamma ramp to set.</param>
        /// <param name="gamma">The desired exponent.</param>
        [DllImport("glfw3.dll", EntryPoint = "glfwSetGamma", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void SetGamma(GLFWmonitorPtr monitor, float gamma);

        /// <summary>
        /// This function returns the current gamma ramp of the specified monitor.
        /// 
        /// Remarks: Wayland: Gamma handling is a privileged protocol, this function will thus never be implemented 
        /// and emits GLFW_PLATFORM_ERROR while returning NULL.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="monitor">The monitor to query.</param>
        /// <returns>The current gamma ramp, or NULL if an error occurred.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetGammaRamp", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern GLFWgammaramp GetGammaRamp(GLFWmonitorPtr monitor);

        /// <summary>
        /// This function sets the current gamma ramp for the specified monitor. The original gamma ramp for that 
        /// monitor is saved by GLFW the first time this function is called and is restored by glfwTerminate.
        /// 
        /// The software controlled gamma ramp is applied in addition to the hardware gamma correction, 
        /// which today is usually an approximation of sRGB gamma. This means that setting a perfectly linear ramp, 
        /// or gamma 1.0, will produce the default (usually sRGB-like) behavior.
        /// 
        /// For gamma correct rendering with OpenGL or OpenGL ES, see the GLFW_SRGB_CAPABLE hint.
        /// 
        /// Remarks: The size of the specified gamma ramp should match the size of the current ramp for that monitor.
        /// Windows: The gamma ramp size must be 256.
        /// Wayland: Gamma handling is a privileged protocol, this function will thus never be implemented and emits 
        /// GLFW_PLATFORM_ERROR.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="monitor">The monitor whose gamma ramp to set.</param>
        /// <param name="ramp">The gamma ramp to use.</param>
        [DllImport("glfw3.dll", EntryPoint = "glfwSetGammaRamp", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void SetGammaRamp(GLFWmonitorPtr monitor, GLFWgammaramp ramp);

        /// <summary>
        /// This function resets all window hints to their default values.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        [DllImport("glfw3.dll", EntryPoint = "glfwDefaultWindowHints", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void DefaultWindowHints();

        /// <summary>
        /// This function sets hints for the next call to glfwCreateWindow. The hints, once set, retain their values 
        /// until changed by a call to this function or glfwDefaultWindowHints, or until the library is terminated.
        /// 
        /// Only string type hints can be set with this function.Integer value hints are set with glfwWindowHint.
        /// 
        /// This function does not check whether the specified hint values are valid. If you set hints to invalid 
        /// values this will instead be reported by the next call to glfwCreateWindow.
        /// 
        /// 
        /// Some hints are platform specific. These may be set on any platform but they will only affect their specific 
        /// platform. Other platforms will ignore them.Setting these hints requires no platform specific headers or functions.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="hint">The window hint to set.</param>
        /// <param name="value">	The new value of the window hint.</param>
        [DllImport("glfw3.dll", EntryPoint = "glfwWindowHintString", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void WindowHintString(int hint, string value);

        /// <summary>
        /// This function sets the value of the close flag of the specified window. 
        /// This can be used to override the user's attempt to close the window, or to signal that it should be closed.
        /// 
        /// Thread safety: This function may be called from any thread.Access is not synchronized.
        /// </summary>
        /// <param name="window">The window whose flag to change.</param>
        /// <param name="value">The new value.</param>
        [DllImport("glfw3.dll", EntryPoint = "glfwSetWindowShouldClose", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void SetWindowShouldClose(GLFWwindowPtr window, int value);

        /// <summary>
        /// This function sets the window title, encoded as UTF-8, of the specified window.
        /// </summary>
        /// <param name="window">The window whose title to change.</param>
        /// <param name="title">The UTF-8 encoded window title.</param>
        [DllImport("glfw3.dll", EntryPoint = "glfwSetWindowTitle", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void SetWindowTitle(GLFWwindowPtr window, string title);

        /// <summary>
        /// This function sets the icon of the specified window. If passed an array of candidate images, those 
        /// of or closest to the sizes desired by the system are selected. If no images are specified, 
        /// the window reverts to its default icon.
        /// 
        /// The pixels are 32-bit, little-endian, non-premultiplied RGBA, 
        /// i.e. eight bits per channel with the red channel first. They are arranged canonically as packed sequential 
        /// rows, starting from the top-left corner.
        /// 
        /// The desired image sizes varies depending on platform and system settings. 
        /// The selected images will be rescaled as needed.Good sizes include 16x16, 32x32 and 48x48.
        /// 
        /// Remarks: 
        /// macOS: The GLFW window has no icon, as it is not a document window, so this function does nothing.The dock icon will be the same as the application bundle's icon. For more information on bundles, see the Bundle Programming Guide in the Mac Developer Library.
        /// Wayland: There is no existing protocol to change an icon, the window will thus inherit the one defined in the application's desktop file. This function always emits GLFW_PLATFORM_ERROR.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="window">The window whose icon to set.</param>
        /// <param name="count">The number of images in the specified array, or zero to revert to the default window icon.</param>
        /// <param name="images">The images to create the icon from. This is ignored if count is zero.</param>
        [DllImport("glfw3.dll", EntryPoint = "glfwSetWindowIcon", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void SetWindowIcon(GLFWwindowPtr window, int count, GLFWimage[] images);

        /// <summary>
        /// This function retrieves the position, in screen coordinates, of the upper-left corner of the content area 
        /// of the specified window.
        /// 
        /// Any or all of the position arguments may be NULL.If an error occurs, all non-NULL position arguments 
        /// will be set to zero.
        /// </summary>
        /// <param name="window">The window to query.</param>
        /// <param name="xpos">Where to store the x-coordinate of the upper-left corner of the content area</param>
        /// <param name="ypos">Where to store the y-coordinate of the upper-left corner of the content area</param>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetWindowPos", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void GetWindowPos(GLFWwindowPtr window, out int xpos, out int ypos);

        /// <summary>
        /// This function sets the position, in screen coordinates, of the upper-left corner of the content 
        /// area of the specified windowed mode window. If the window is a full screen window, 
        /// this function does nothing.
        /// 
        /// Do not use this function to move an already visible window unless you have very good reasons for doing so, 
        /// as it will confuse and annoy the user.
        /// 
        /// The window manager may put limits on what positions are allowed.GLFW cannot and should not override these 
        /// limits.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="window">The window to query.</param>
        /// <param name="xpos">The x-coordinate of the upper-left corner of the content area.</param>
        /// <param name="ypos">The y-coordinate of the upper-left corner of the content area.</param>
        [DllImport("glfw3.dll", EntryPoint = "glfwSetWindowPos", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void SetWindowPos(GLFWwindowPtr window, int xpos, int ypos);

        /// <summary>
        /// This function sets the size limits of the content area of the specified window. 
        /// If the window is full screen, the size limits only take effect once it is made windowed. 
        /// If the window is not resizable, this function does nothing.
        /// 
        /// The size limits are applied immediately to a windowed mode window and may cause it to be resized.
        /// 
        /// The maximum dimensions must be greater than or equal to the minimum dimensions and all must be 
        /// greater than or equal to zero.
        /// 
        /// Remarks: If you set size limits and an aspect ratio that conflict, the results are undefined.
        /// Wayland: The size limits will not be applied until the window is actually resized, either by the user or by the compositor.
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="window">The window to set limits for.</param>
        /// <param name="minwidth">The minimum width, in screen coordinates, of the content area, or -1 (GLFW_DONT_CARE).</param>
        /// <param name="minheight">The minimum height, in screen coordinates, of the content area, or -1 (GLFW_DONT_CARE).</param>
        /// <param name="maxwidth">The maximum width, in screen coordinates, of the content area, or -1 (GLFW_DONT_CARE).</param>
        /// <param name="maxheight">The maximum height, in screen coordinates, of the content area, or -1 (GLFW_DONT_CARE).</param>
        [DllImport("glfw3.dll", EntryPoint = "glfwSetWindowSizeLimits", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void SetWindowSizeLimits(GLFWwindowPtr window, int minwidth, int minheight, int maxwidth, int maxheight);

        /// <summary>
        /// This function sets the required aspect ratio of the content area of the specified window. If the window is full screen, the aspect ratio only takes effect once it is made windowed. If the window is not resizable, this function does nothing.
        /// 
        /// The aspect ratio is specified as a numerator and a denominator and both values must be greater than zero.For example, the common 16:9 aspect ratio is specified as 16 and 9, respectively.
        /// 
        /// If the numerator and denominator is set to GLFW_DONT_CARE then the aspect ratio limit is disabled.
        /// 
        /// The aspect ratio is applied immediately to a windowed mode window and may cause it to be resized.
        /// 
        /// Remarks: If you set size limits and an aspect ratio that conflict, the results are undefined.
        /// Wayland: The aspect ratio will not be applied until the window is actually resized, either by the user or by the compositor.
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="window">The window to set limits for.</param>
        /// <param name="numer">The numerator of the desired aspect ratio, or -1 (GLFW_DONT_CARE).</param>
        /// <param name="denom">The denominator of the desired aspect ratio, or -1 (GLFW_DONT_CARE).</param>
        [DllImport("glfw3.dll", EntryPoint = "glfwSetWindowAspectRatio", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void SetWindowAspectRatio(GLFWwindowPtr window, int numer, int denom);

        /// <summary>
        /// This function sets the size, in screen coordinates, of the content area of the specified window.
        /// 
        /// For full screen windows, this function updates the resolution of its desired video mode and switches 
        /// to the video mode closest to it, without affecting the window's context. As the context is unaffected,
        /// the bit depths of the framebuffer remain unchanged.
        /// 
        /// If you wish to update the refresh rate of the desired video mode in addition to its resolution, 
        /// see glfwSetWindowMonitor.
        /// 
        /// The window manager may put limits on what sizes are allowed.GLFW cannot and should not override these limits.
        /// 
        /// Remarks: Wayland: A full screen window will not attempt to change the mode, no matter what the requested size.
        /// Thread safety :This function must only be called from the main thread.
        /// </summary>
        /// <param name="window">The window to resize.</param>
        /// <param name="width">The desired width, in screen coordinates, of the window content area.</param>
        /// <param name="height">The desired height, in screen coordinates, of the window content area.</param>
        [DllImport("glfw3.dll", EntryPoint = "glfwSetWindowSize", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void SetWindowSize(GLFWwindowPtr window, int width, int height);

        /// <summary>
        /// This function retrieves the size, in screen coordinates, of each edge of the frame of the specified window.
        /// This size includes the title bar, if the window has one. The size of the frame may vary depending on the
        /// window-related hints used to create it.
        /// 
        /// Because this function retrieves the size of each window frame edge and not the offset along a particular 
        /// coordinate axis, the retrieved values will always be zero or positive.
        /// 
        /// Any or all of the size arguments may be NULL. If an error occurs, all non-NULL size arguments will be set 
        /// to zero.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="window">The window whose frame size to query.</param>
        /// <param name="left">	Where to store the size, in screen coordinates, of the left edge of the window frame</param>
        /// <param name="top">Where to store the size, in screen coordinates, of the top edge of the window frame</param>
        /// <param name="right">Where to store the size, in screen coordinates, of the right edge of the window frame</param>
        /// <param name="bottom">Where to store the size, in screen coordinates, of the bottom edge of the window frame</param>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetWindowFrameSize", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void GetWindowFrameSize(GLFWwindowPtr window, out int left, out int top, out int right, out int bottom);

        /// <summary>
        /// This function retrieves the content scale for the specified window. The content scale is the ratio between 
        /// the current DPI and the platform's default DPI. This is especially important for text and any UI elements. 
        /// If the pixel dimensions of your UI scaled by this look appropriate on your machine then it should appear 
        /// at a reasonable size on other machines regardless of their DPI and scaling settings. 
        /// This relies on the system DPI and scaling settings being somewhat correct.
        /// 
        /// On systems where each monitors can have its own content scale, the window content scale will depend on 
        /// which monitor the system considers the window to be on.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="window">The window to query.</param>
        /// <param name="xscale">Where to store the x-axis content scale</param>
        /// <param name="yscale">Where to store the y-axis content scale</param>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetWindowContentScale", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void GetWindowContentScale(GLFWwindowPtr window, out float xscale, out float yscale);

        /// <summary>
        /// This function returns the opacity of the window, including any decorations.
        /// 
        /// The opacity(or alpha) value is a positive finite number between zero and one, where zero is fully
        /// transparent and one is fully opaque.If the system does not support whole window transparency, 
        /// this function always returns one.
        /// 
        /// The initial opacity value for newly created windows is one.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="window">The window to query.</param>
        /// <returns>The opacity value of the specified window.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetWindowOpacity", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern float GetWindowOpacity(GLFWwindowPtr window);

        /// <summary>
        /// This function sets the opacity of the window, including any decorations.
        /// 
        /// The opacity(or alpha) value is a positive finite number between zero and one, where zero is fully 
        /// transparent and one is fully opaque.
        /// 
        /// The initial opacity value for newly created windows is one.
        /// 
        /// A window created with framebuffer transparency may not use whole window transparency. 
        /// The results of doing this are undefined.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="window">The window to set the opacity for.</param>
        /// <param name="opacity">The desired opacity of the specified window.</param>
        [DllImport("glfw3.dll", EntryPoint = "glfwSetWindowOpacity", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void SetWindowOpacity(GLFWwindowPtr window, float opacity);

        /// <summary>
        /// This function iconifies (minimizes) the specified window if it was previously restored. If the window is already iconified, this function does nothing.
        /// 
        /// If the specified window is a full screen window, GLFW restores the original video mode of the monitor.
        /// The window's desired video mode is set again when the window is restored.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="window">The window to iconify.</param>
        [DllImport("glfw3.dll", EntryPoint = "glfwIconifyWindow", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void IconifyWindow(GLFWwindowPtr window);

        /// <summary>
        /// This function restores the specified window if it was previously iconified (minimized) or maximized. 
        /// If the window is already restored, this function does nothing.
        /// 
        /// If the specified window is an iconified full screen window, its desired video mode is set again for 
        /// its monitor when the window is restored.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="window">The window to restore.</param>
        [DllImport("glfw3.dll", EntryPoint = "glfwRestoreWindow", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void RestoreWindow(GLFWwindowPtr window);

        /// <summary>
        /// This function maximizes the specified window if it was previously not maximized.
        /// If the window is already maximized, this function does nothing.
        /// 
        /// If the specified window is a full screen window, this function does nothing.
        /// 
        /// Thread Safety: This function may only be called from the main thread.
        /// </summary>
        /// <param name="window">The window to maximize.</param>
        [DllImport("glfw3.dll", EntryPoint = "glfwMaximizeWindow", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void MaximizeWindow(GLFWwindowPtr window);

        /// <summary>
        /// This function makes the specified window visible if it was previously hidden. 
        /// If the window is already visible or is in full screen mode, this function does nothing.
        /// 
        /// By default, windowed mode windows are focused when shown Set the GLFW_FOCUS_ON_SHOW window hint to 
        /// change this behavior for all newly created windows, or change the behavior for an existing window with 
        /// glfwSetWindowAttrib.
        /// 
        /// Remarks
        /// Wayland: Because Wayland wants every frame of the desktop to be complete, this function does not immediately make the window visible.Instead it will become visible the next time the window framebuffer is updated after this call.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="window">The window to make visible.</param>
        [DllImport("glfw3.dll", EntryPoint = "glfwShowWindow", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void ShowWindow(GLFWwindowPtr window);

        /// <summary>
        /// This function hides the specified window if it was previously visible. 
        /// If the window is already hidden or is in full screen mode, this function does nothing.
        /// 
        /// hread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="window">The window to hide.</param>
        [DllImport("glfw3.dll", EntryPoint = "glfwHideWindow", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void HideWindow(GLFWwindowPtr window);

        /// <summary>
        /// This function brings the specified window to front and sets input focus. The window should already be 
        /// visible and not iconified.
        /// 
        /// By default, both windowed and full screen mode windows are focused when initially created.
        /// Set the GLFW_FOCUSED to disable this behavior.
        /// 
        /// Also by default, windowed mode windows are focused when shown with glfwShowWindow.
        /// Set the GLFW_FOCUS_ON_SHOW to disable this behavior.
        /// 
        /// Do not use this function to steal focus from other applications unless you are certain that is what the 
        /// user wants. Focus stealing can be extremely disruptive.
        /// 
        /// 
        /// For a less disruptive way of getting the user's attention, see attention requests.
        /// 
        /// Remarks
        /// Wayland: It is not possible for an application to bring its windows to front, this function will always
        /// emit GLFW_PLATFORM_ERROR.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="window">The window to give input focus.</param>
        [DllImport("glfw3.dll", EntryPoint = "glfwFocusWindow", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void FocusWindow(GLFWwindowPtr window);

        /// <summary>
        /// This function requests user attention to the specified window. On platforms where this is not supported, 
        /// attention is requested to the application as a whole.
        /// 
        /// Once the user has given attention, usually by focusing the window or application, the system will 
        /// end the request automatically.
        /// 
        /// Remarks
        /// macOS: Attention is requested to the application as a whole, not the specific window.
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="window">The window to request attention to.</param>
        [DllImport("glfw3.dll", EntryPoint = "glfwRequestWindowAttention", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void RequestWindowAttention(GLFWwindowPtr window);

        /// <summary>
        /// This function returns the handle of the monitor that the specified window is in full screen on.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="window">The window to query.</param>
        /// <returns>The monitor, or NULL if the window is in windowed mode or an error occurred.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetWindowMonitor", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern GLFWmonitorPtr GetWindowMonitor(GLFWwindowPtr window);

        /// <summary>
        /// This function sets the monitor that the window uses for full screen mode or, if the monitor is NULL, 
        /// makes it windowed mode.
        /// 
        /// When setting a monitor, this function updates the width, height and refresh rate of the desired 
        /// video mode and switches to the video mode closest to it.
        /// The window position is ignored when setting a monitor.
        /// 
        /// When the monitor is NULL, the position, width and height are used to place the window content area.
        /// The refresh rate is ignored when no monitor is specified.
        /// 
        /// If you only wish to update the resolution of a full screen window or the size of a windowed mode window, 
        /// see glfwSetWindowSize.
        /// 
        /// 
        /// When a window transitions from full screen to windowed mode, this function restores any previous window 
        /// settings such as whether it is decorated, floating, resizable, has size or aspect ratio limits, etc.
        /// 
        /// Remarks
        /// The OpenGL or OpenGL ES context will not be destroyed or otherwise affected by any resizing or mode switching, although you may need to update your viewport if the framebuffer size has changed.
        /// Wayland: The desired window position is ignored, as there is no way for an application to set this property.
        /// Wayland: Setting the window to full screen will not attempt to change the mode, no matter what the requested size or refresh rate.
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="window">The window whose monitor, size or video mode to set.</param>
        /// <param name="monitor">The desired monitor, or NULL to set windowed mode.</param>
        /// <param name="xpos">The desired x-coordinate of the upper-left corner of the content area.</param>
        /// <param name="ypos">The desired y-coordinate of the upper-left corner of the content area.</param>
        /// <param name="width">The desired with, in screen coordinates, of the content area or video mode.</param>
        /// <param name="height">The desired height, in screen coordinates, of the content area or video mode.</param>
        /// <param name="refreshRate">The desired refresh rate, in Hz, of the video mode, or -1 (GLFW_DONT_CARE).</param>
        [DllImport("glfw3.dll", EntryPoint = "glfwSetWindowMonitor", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void SetWindowMonitor(GLFWwindowPtr window, GLFWmonitorPtr monitor, int xpos, int ypos, int width, int height, int refreshRate);

        /// <summary>
        /// This function returns the value of an attribute of the specified window or its OpenGL or OpenGL ES context.
        /// 
        /// Remarks
        /// Framebuffer related hints are not window attributes.See Framebuffer related attributes for more information.
        /// Zero is a valid value for many window and context related attributes so you cannot use a return value of 
        /// zero as an indication of errors. However, this function should not fail as long as it is passed valid 
        /// arguments and the library has been initialized.
        /// Wayland: The Wayland protocol provides no way to check whether a window is iconfied, so GLFW_ICONIFIED 
        /// always returns GLFW_FALSE.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="window">The window to query.</param>
        /// <param name="attrib">The window attribute whose value to return.</param>
        /// <returns>The value of the attribute, or zero if an error occurred.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetWindowAttrib", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int GetWindowAttrib(GLFWwindowPtr window, WindowHints attrib);

        /// <summary>
        /// This function sets the value of an attribute of the specified window.
        /// 
        /// Some of these attributes are ignored for full screen windows. 
        /// The new value will take effect if the window is later made windowed.
        /// 
        /// Some of these attributes are ignored for windowed mode windows.
        /// The new value will take effect if the window is later made full screen.
        /// 
        /// Remarks
        /// Calling glfwGetWindowAttrib will always return the latest value, even if that value is ignored by the current mode of the window.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="window">The window to set the attribute for.</param>
        /// <param name="attrib">
        /// A supported window attribute.
        /// 
        /// The supported attributes are GLFW_DECORATED, GLFW_RESIZABLE, GLFW_FLOATING, GLFW_AUTO_ICONIFY and GLFW_FOCUS_ON_SHOW.
        /// </param>
        /// <param name="value">GLFW_TRUE or GLFW_FALSE.</param>
        [DllImport("glfw3.dll", EntryPoint = "glfwSetWindowAttrib", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void SetWindowAttrib(GLFWwindowPtr window, WindowHints attrib, int value);

        /// <summary>
        /// This function sets the user-defined pointer of the specified window. 
        /// The current value is retained until the window is destroyed. 
        /// The initial value is NULL.
        /// 
        /// Thread safety: This function may be called from any thread.Access is not synchronized.
        /// </summary>
        /// <param name="window">The window whose pointer to set.</param>
        /// <param name="pointer">The new value.</param>
        [DllImport("glfw3.dll", EntryPoint = "glfwSetWindowUserPointer", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void SetWindowUserPointer(GLFWwindowPtr window, IntPtr pointer);

        /// <summary>
        /// This function returns the current value of the user-defined pointer of the specified window. The initial value is NULL.
        /// 
        /// Thread safety: This function may be called from any thread.Access is not synchronized.
        /// </summary>
        /// <param name="window">The window whose pointer to return.</param>
        /// <returns>The current value of the user-defined pointer of the specified window.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetWindowUserPointer", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr GetWindowUserPointer(GLFWwindowPtr window);

        /// <summary>
        /// This function sets the position callback of the specified window, which is called when the window is moved. 
        /// The callback is provided with the position, in screen coordinates, of the upper-left corner 
        /// of the content area of the window.
        /// 
        /// Remarks
        /// Wayland: This callback will never be called, as there is no way for an application to know its global position.
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="window">The window whose callback to set.</param>
        /// <param name="callback">The new callback, or NULL to remove the currently set callback.</param>
        /// <returns>The previously set callback, or NULL if no callback was set or the library had not been initialized.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwSetWindowPosCallback", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern GlfwDelegates.GLFWwindowposfun SetWindowPosCallback(GLFWwindowPtr window, GlfwDelegates.GLFWwindowposfun callback);

        /// <summary>
        /// This function sets the size callback of the specified window, which is called when the window is resized. 
        /// The callback is provided with the size, in screen coordinates, of the content area of the window.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="window">The window whose callback to set.</param>
        /// <param name="callback">The new callback, or NULL to remove the currently set callback.</param>
        /// <returns>The previously set callback, or NULL if no callback was set or the library had not been initialized.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwSetWindowSizeCallback", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern GlfwDelegates.GLFWwindowsizefun SetWindowSizeCallback(GLFWwindowPtr window, GlfwDelegates.GLFWwindowsizefun callback);

        /// <summary>
        /// This function sets the close callback of the specified window, which is called when the user attempts 
        /// to close the window, for example by clicking the close widget in the title bar.
        /// 
        /// The close flag is set before this callback is called, but you can modify it at any time with 
        /// glfwSetWindowShouldClose.
        /// 
        /// The close callback is not triggered by glfwDestroyWindow.
        /// 
        /// Remarks
        /// macOS: Selecting Quit from the application menu will trigger the close callback for all windows.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="window">The window whose callback to set.</param>
        /// <param name="callback">The new callback, or NULL to remove the currently set callback.</param>
        /// <returns>The previously set callback, or NULL if no callback was set or the library had not been initialized.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwSetWindowCloseCallback", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern GlfwDelegates.GLFWwindowclosefun SetWindowCloseCallback(GLFWwindowPtr window, GlfwDelegates.GLFWwindowclosefun callback);

        /// <summary>
        /// This function sets the refresh callback of the specified window, which is called when the content area 
        /// of the window needs to be redrawn, for example if the window has been exposed after having been covered 
        /// by another window.
        /// 
        /// On compositing window systems such as Aero, Compiz, Aqua or Wayland, where the window contents are saved 
        /// off-screen, this callback may be called only very infrequently or never at all.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="window">The window whose callback to set.</param>
        /// <param name="callback">The new callback, or NULL to remove the currently set callback.</param>
        /// <returns>The previously set callback, or NULL if no callback was set or the library had not been initialized.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwSetWindowRefreshCallback", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern GlfwDelegates.GLFWwindowrefreshfun SetWindowRefreshCallback(GLFWwindowPtr window, GlfwDelegates.GLFWwindowrefreshfun callback);

        /// <summary>
        /// This function sets the focus callback of the specified window, which is called when the window gains or 
        /// loses input focus.
        /// 
        /// After the focus callback is called for a window that lost input focus, synthetic key and mouse button 
        /// release events will be generated for all such that had been pressed.
        /// For more information, see glfwSetKeyCallback and glfwSetMouseButtonCallback.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="window">The window whose callback to set.</param>
        /// <param name="callback">The new callback, or NULL to remove the currently set callback.</param>
        /// <returns>The previously set callback, or NULL if no callback was set or the library had not been initialized.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwSetWindowFocusCallback", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern GlfwDelegates.GLFWwindowfocusfun SetWindowFocusCallback(GLFWwindowPtr window, GlfwDelegates.GLFWwindowfocusfun callback);

        /// <summary>
        /// This function sets the iconification callback of the specified window, 
        /// which is called when the window is iconified or restored.
        /// 
        /// Remarks
        /// Wayland: The XDG-shell protocol has no event for iconification, so this callback will never be called.
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="window">The window whose callback to set.</param>
        /// <param name="callback">The new callback, or NULL to remove the currently set callback.</param>
        /// <returns>The previously set callback, or NULL if no callback was set or the library had not been initialized.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwSetWindowIconifyCallback", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern GlfwDelegates.GLFWwindowiconifyfun SetWindowIconifyCallback(GLFWwindowPtr window, GlfwDelegates.GLFWwindowiconifyfun callback);

        /// <summary>
        /// This function sets the maximization callback of the specified window,
        /// which is called when the window is maximized or restored.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="window">The window whose callback to set.</param>
        /// <param name="callback">The new callback, or NULL to remove the currently set callback.</param>
        /// <returns>The previously set callback, or NULL if no callback was set or the library had not been initialized.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwSetWindowMaximizeCallback", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern GlfwDelegates.GLFWwindowmaximizefun SetWindowMaximizeCallback(GLFWwindowPtr window, GlfwDelegates.GLFWwindowmaximizefun callback);

        /// <summary>
        /// This function sets the framebuffer resize callback of the specified window, 
        /// which is called when the framebuffer of the specified window is resized.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="window">The window whose callback to set.</param>
        /// <param name="callback">The new callback, or NULL to remove the currently set callback.</param>
        /// <returns>The previously set callback, or NULL if no callback was set or the library had not been initialized.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwSetFramebufferSizeCallback", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern GlfwDelegates.GLFWframebuffersizefun SetFramebufferSizeCallback(GLFWwindowPtr window, GlfwDelegates.GLFWframebuffersizefun callback);

        /// <summary>
        /// This function sets the window content scale callback of the specified window, 
        /// which is called when the content scale of the specified window changes.
        /// 
        /// Thread safety: This function must only be called from the main thread
        /// </summary>
        /// <param name="window">The window whose callback to set.</param>
        /// <param name="callback">The new callback, or NULL to remove the currently set callback.</param>
        /// <returns>The previously set callback, or NULL if no callback was set or the library had not been initialized.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwSetWindowContentScaleCallback", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern GlfwDelegates.GLFWwindowcontentscalefun SetWindowContentScaleCallback(GLFWwindowPtr window, GlfwDelegates.GLFWwindowcontentscalefun callback);

        /// <summary>
        /// This function puts the calling thread to sleep until at least one event is available in the event queue. 
        /// Once one or more events are available, it behaves exactly like glfwPollEvents, i.e. the events in the 
        /// queue are processed and the function then returns immediately. 
        /// Processing events will cause the window and input callbacks associated with those events to be called.
        /// 
        /// Since not all events are associated with callbacks, this function may return without a callback having 
        /// been called even if you are monitoring all callbacks.
        /// 
        /// On some platforms, a window move, resize or menu operation will cause event processing to block.
        /// This is due to how event processing is designed on those platforms. 
        /// You can use the window refresh callback to redraw the contents of your window when necessary during 
        /// such operations.
        /// 
        /// Do not assume that callbacks you set will only be called in response to event processing functions 
        /// like this one. While it is necessary to poll for events, window systems that require GLFW to 
        /// register callbacks of its own can pass events to GLFW in response to many window system function calls.
        /// GLFW will pass those events on to the application callbacks before returning.
        /// 
        /// Event processing is not required for joystick input to work.
        /// 
        /// Reentrancy: This function must not be called from a callback.
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        [DllImport("glfw3.dll", EntryPoint = "glfwWaitEvents", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void WaitEvents();

        /// <summary>
        /// This function puts the calling thread to sleep until at least one event is available in the event queue,
        /// or until the specified timeout is reached. If one or more events are available, it behaves exactly like 
        /// glfwPollEvents, i.e. the events in the queue are processed and the function then returns immediately.
        /// Processing events will cause the window and input callbacks associated with those events to be called.
        /// 
        /// The timeout value must be a positive finite number.
        /// 
        /// Since not all events are associated with callbacks, this function may return without a callback having 
        /// been called even if you are monitoring all callbacks.
        /// 
        /// On some platforms, a window move, resize or menu operation will cause event processing to block.
        /// This is due to how event processing is designed on those platforms. You can use the window refresh 
        /// callback to redraw the contents of your window when necessary during such operations.
        /// 
        /// Do not assume that callbacks you set will only be called in response to event processing functions like 
        /// this one.While it is necessary to poll for events, window systems that require GLFW to register callbacks 
        /// of its own can pass events to GLFW in response to many window system function calls. GLFW will pass those 
        /// events on to the application callbacks before returning.
        /// 
        /// Event processing is not required for joystick input to work.
        /// 
        /// Reentrancy: This function must not be called from a callback.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="timeout"></param>
        [DllImport("glfw3.dll", EntryPoint = "glfwWaitEventsTimeout", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void WaitEventsTimeout(double timeout);

        /// <summary>
        /// This function posts an empty event from the current thread to the event queue, 
        /// causing glfwWaitEvents or glfwWaitEventsTimeout to return.
        /// 
        /// Thread safety: This function may be called from any thread.
        /// </summary>
        [DllImport("glfw3.dll", EntryPoint = "glfwPostEmptyEvent", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void PostEmptyEvent();

        /// <summary>
        /// This function returns the window whose OpenGL or OpenGL ES context is current on the calling thread.
        /// 
        /// Thread safety: This function may be called from any thread.
        /// </summary>
        /// <returns>The window whose context is current, or NULL if no window's context is current.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetCurrentContext", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern GLFWwindowPtr GetCurrentContext();

        /// <summary>
        /// This function sets the swap interval for the current OpenGL or OpenGL ES context, 
        /// i.e. the number of screen updates to wait from the time glfwSwapBuffers was called before swapping the 
        /// buffers and returning. This is sometimes called vertical synchronization, vertical retrace synchronization 
        /// or just vsync.
        /// 
        /// A context that supports either of the WGL_EXT_swap_control_tear and GLX_EXT_swap_control_tear extensions 
        /// also accepts negative swap intervals, which allows the driver to swap immediately even if a frame arrives a 
        /// little bit late.You can check for these extensions with glfwExtensionSupported.
        /// 
        /// A context must be current on the calling thread. Calling this function without a current context will cause a 
        /// GLFW_NO_CURRENT_CONTEXT error.
        /// 
        /// 
        /// This function does not apply to Vulkan.If you are rendering with Vulkan, see the present mode of your swapchain 
        /// instead.
        /// 
        /// Remarks: 
        /// This function is not called during context creation, leaving the swap interval set to whatever is the default on that platform.This is done because some swap interval extensions used by GLFW do not allow the swap interval to be reset to zero once it has been set to a non-zero value.
        /// Some GPU drivers do not honor the requested swap interval, either because of a user setting that overrides the application's request or due to bugs in the driver.
        /// Thread safety: This function may be called from any thread.
        /// </summary>
        /// <param name="interval">The minimum number of screen updates to wait for until the buffers are swapped by glfwSwapBuffers.</param>
        [DllImport("glfw3.dll", EntryPoint = "glfwSwapInterval", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void SwapInterval(int interval);

        /// <summary>
        /// This function returns whether the specified API extension is supported by the current OpenGL or 
        /// OpenGL ES context. It searches both for client API extension and context creation API extensions.
        /// 
        /// A context must be current on the calling thread.Calling this function without a current context 
        /// will cause a GLFW_NO_CURRENT_CONTEXT error.
        /// 
        /// 
        /// As this functions retrieves and searches one or more extension strings each call, 
        /// it is recommended that you cache its results if it is going to be used frequently.
        /// The extension strings will not change during the lifetime of a context, so there is no danger in doing this.
        /// 
        /// 
        /// This function does not apply to Vulkan.If you are using Vulkan, 
        /// see glfwGetRequiredInstanceExtensions, vkEnumerateInstanceExtensionProperties and 
        /// vkEnumerateDeviceExtensionProperties instead.
        /// </summary>
        /// <param name="extension">The ASCII encoded name of the extension.</param>
        /// <returns>GLFW_TRUE if the extension is available, or GLFW_FALSE otherwise.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwExtensionSupported", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int ExtensionSupported(string extension);

        /// <summary>
        /// This function returns the address of the specified OpenGL or OpenGL ES core or extension function, 
        /// if it is supported by the current context.
        /// 
        /// A context must be current on the calling thread.Calling this function without a current context will 
        /// cause a GLFW_NO_CURRENT_CONTEXT error.
        /// 
        /// 
        /// This function does not apply to Vulkan. If you are rendering with Vulkan, 
        /// see glfwGetInstanceProcAddress, vkGetInstanceProcAddr and vkGetDeviceProcAddr instead.
        /// 
        /// Remarks
        /// The address of a given function is not guaranteed to be the same between contexts.
        /// This function may return a non-NULL address despite the associated version or extension not being available.Always check the context version or extension string first.
        /// 
        /// Thread safety: This function may be called from any thread.
        /// </summary>
        /// <param name="procname">The ASCII encoded name of the function.</param>
        /// <returns>The address of the function, or NULL if an error occurred.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetProcAddress", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr GetProcAddress(string procname);

        #region Vulkan Stuff

        /// <summary>
        /// This function returns whether the Vulkan loader and any minimally functional ICD have been found.
        /// 
        /// The availability of a Vulkan loader and even an ICD does not by itself guarantee that surface creation 
        /// or even instance creation is possible.Call glfwGetRequiredInstanceExtensions to check whether 
        /// the extensions necessary for Vulkan surface creation are available and 
        /// glfwGetPhysicalDevicePresentationSupport to check whether a queue family of a physical device supports 
        /// image presentation.
        /// 
        /// Thread safety: This function may be called from any thread.
        /// </summary>
        /// <returns>GLFW_TRUE if Vulkan is minimally available, or GLFW_FALSE otherwise.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwVulkanSupported", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int VulkanSupported();

        /// <summary>
        /// This function returns an array of names of Vulkan instance extensions required by GLFW for creating 
        /// Vulkan surfaces for GLFW windows. If successful, the list will always contain VK_KHR_surface, 
        /// so if you don't require any additional extensions you can pass this list directly to the 
        /// VkInstanceCreateInfo struct.
        /// 
        /// If Vulkan is not available on the machine, this function returns NULL and generates a 
        /// GLFW_API_UNAVAILABLE error. Call glfwVulkanSupported to check whether Vulkan is at least minimally available.
        /// 
        /// 
        /// If Vulkan is available but no set of extensions allowing window surface creation was found, 
        /// this function returns NULL.You may still use Vulkan for off-screen rendering and compute work.
        /// 
        /// Remarks:
        /// Additional extensions may be required by future versions of GLFW.
        /// You should check if any extensions you wish to enable are already in the returned array, 
        /// as it is an error to specify an extension more than once in the VkInstanceCreateInfo struct.
        /// 
        /// Thread safety: This function may be called from any thread.
        /// </summary>
        /// <param name="count">
        /// Where to store the number of extensions in the returned array. This is set to zero if an error occurred.
        /// </param>
        /// <returns>An array of ASCII encoded extension names, or NULL if an error occurred.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetRequiredInstanceExtensions", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        //[return: MarshalAs(UnmanagedType.HString)]
        private static extern IntPtr glfwGetRequiredInstanceExtensions(out uint count);

        /// <summary>
        /// This function returns an array of names of Vulkan instance extensions required by GLFW for creating 
        /// Vulkan surfaces for GLFW windows. If successful, the list will always contain VK_KHR_surface, 
        /// so if you don't require any additional extensions you can pass this list directly to the 
        /// VkInstanceCreateInfo struct.
        /// 
        /// If Vulkan is not available on the machine, this function returns NULL and generates a 
        /// GLFW_API_UNAVAILABLE error. Call glfwVulkanSupported to check whether Vulkan is at least minimally available.
        /// 
        /// 
        /// If Vulkan is available but no set of extensions allowing window surface creation was found, 
        /// this function returns NULL.You may still use Vulkan for off-screen rendering and compute work.
        /// 
        /// Remarks:
        /// Additional extensions may be required by future versions of GLFW.
        /// You should check if any extensions you wish to enable are already in the returned array, 
        /// as it is an error to specify an extension more than once in the VkInstanceCreateInfo struct.
        /// 
        /// Thread safety: This function may be called from any thread.
        /// </summary>
        /// <param name="count">
        /// Where to store the number of extensions in the returned array. This is set to zero if an error occurred.
        /// </param>
        /// <returns>An array of ASCII encoded extension names, or NULL if an error occurred.</returns>
        public static string[] GetRequiredInstanceExtensions()
        {
            uint count;
            IntPtr result = glfwGetRequiredInstanceExtensions(out count);
            string[] toReturn = new string[count];
            //int idx = 0;
            for (int i = 0; i < count; i++)
            {
                IntPtr ptr = Marshal.ReadIntPtr(result);
                toReturn[i] = Marshal.PtrToStringAnsi(ptr);
                result += Marshal.SizeOf<IntPtr>();

            }

            return toReturn;
        }

        /// <summary>
        /// This function returns the address of the specified Vulkan core or extension function for the specified instance. 
        /// If instance is set to NULL it can return any function exported from the Vulkan loader, including at least 
        /// the following functions:
        /// 
        /// vkEnumerateInstanceExtensionProperties
        /// vkEnumerateInstanceLayerProperties
        /// vkCreateInstance
        /// vkGetInstanceProcAddr
        /// If Vulkan is not available on the machine, this function returns NULL and generates a GLFW_API_UNAVAILABLE error.
        /// Call glfwVulkanSupported to check whether Vulkan is at least minimally available.
        /// 
        /// This function is equivalent to calling vkGetInstanceProcAddr with a platform-specific query of the Vulkan loader 
        /// as a fallback.
        /// 
        /// Thread safety: This function may be called from any thread.
        /// </summary>
        /// <param name="instance">The Vulkan instance to query, or NULL to retrieve functions related to instance creation.</param>
        /// <param name="procname">The ASCII encoded name of the function.</param>
        /// <returns>The address of the function, or NULL if an error occurred.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetInstanceProcAddress", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr GetInstanceProcAddress(VkInstance instance, string procname);

        /// <summary>
        /// This function returns whether the specified queue family of the specified physical device supports 
        /// presentation to the platform GLFW was built for.
        /// 
        /// If Vulkan or the required window surface creation instance extensions are not available on the machine, 
        /// or if the specified instance was not created with the required extensions, 
        /// this function returns GLFW_FALSE and generates a GLFW_API_UNAVAILABLE error.
        /// Call glfwVulkanSupported to check whether Vulkan is at least minimally available and 
        /// glfwGetRequiredInstanceExtensions to check what instance extensions are required.
        /// 
        /// Remarks
        /// macOS: This function currently always returns GLFW_TRUE, as the VK_MVK_macos_surface and VK_EXT_metal_surface extensions do not provide a vkGetPhysicalDevice*PresentationSupport type function.
        /// 
        /// Thread safety: This function may be called from any thread.For synchronization details of Vulkan objects, see the Vulkan specification.
        /// </summary>
        /// <param name="instance">The instance that the physical device belongs to.</param>
        /// <param name="device">The physical device that the queue family belongs to.</param>
        /// <param name="queuefamily">The index of the queue family to query.</param>
        /// <returns>GLFW_TRUE if the queue family supports presentation, or GLFW_FALSE otherwise.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetPhysicalDevicePresentationSupport", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int GetPhysicalDevicePresentationSupport(VkInstance instance, VkPhysicalDevice device, int queuefamily);

        /// <summary>
        /// This function creates a Vulkan surface for the specified window.
        /// 
        /// If the Vulkan loader or at least one minimally functional ICD were not found, this function returns 
        /// VK_ERROR_INITIALIZATION_FAILED and generates a GLFW_API_UNAVAILABLE error.Call glfwVulkanSupported to 
        /// check whether Vulkan is at least minimally available.
        /// 
        /// 
        /// If the required window surface creation instance extensions are not available or if the specified 
        /// instance was not created with these extensions enabled, this function returns 
        /// VK_ERROR_EXTENSION_NOT_PRESENT and generates a GLFW_API_UNAVAILABLE error. 
        /// Call glfwGetRequiredInstanceExtensions to check what instance extensions are required.
        /// 
        /// The window surface cannot be shared with another API so the window must have been created with the 
        /// client api hint set to GLFW_NO_API otherwise it generates a GLFW_INVALID_VALUE error and returns 
        /// VK_ERROR_NATIVE_WINDOW_IN_USE_KHR.
        /// 
        /// The window surface must be destroyed before the specified Vulkan instance.It is the responsibility of 
        /// the caller to destroy the window surface. GLFW does not destroy it for you.Call vkDestroySurfaceKHR to 
        /// destroy the surface.
        /// 
        /// Remarks
        /// If an error occurs before the creation call is made, GLFW returns the Vulkan error code most appropriate 
        /// for the error.Appropriate use of glfwVulkanSupported and glfwGetRequiredInstanceExtensions should eliminate 
        /// almost all occurrences of these errors.
        /// macOS: GLFW prefers the VK_EXT_metal_surface extension, with the VK_MVK_macos_surface extension as a fallback.
        /// The name of the selected extension, if any, is included in the array returned by 
        /// glfwGetRequiredInstanceExtensions.
        /// macOS: This function creates and sets a CAMetalLayer instance for the window content view, which is required 
        /// for MoltenVK to function.
        /// 
        /// Thread safety: This function may be called from any thread. For synchronization details of Vulkan objects, 
        /// see the Vulkan specification.
        /// </summary>
        /// <param name="instance">The Vulkan instance to create the surface in.</param>
        /// <param name="window">The window to create the surface for.</param>
        /// <param name="allocator">The allocator to use, or NULL to use the default allocator.</param>
        /// <param name="surface">Where to store the handle of the surface. This is set to VK_NULL_HANDLE if an error occurred.</param>
        /// <returns>VK_SUCCESS if successful, or a Vulkan error code if an error occurred.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwCreateWindowSurface", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern VkResult CreateWindowSurface(VkInstance instance, GLFWwindowPtr window, VkAllocationCallbacks? allocator, out VkSurfaceKHR surface);

        #endregion

        #region GLFW Native Calls

        [DllImport("glfw3.dll", EntryPoint = "glfwGetWin32Adapter", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern IntPtr glfwGetWin32Adapter(GLFWmonitorPtr monitor);

        /// <summary>
        /// Returns the adapter device name of the specified monitor.
        /// 
        /// Thread safety: This function may be called from any thread. Access is not synchronized.
        /// </summary>
        /// <param name="monitor"></param>
        /// <returns>The UTF-8 encoded adapter device name (for example \\.\DISPLAY1) of the specified monitor, or NULL if an error occurred.</returns>
        public static string GetWin32Adapter(GLFWmonitorPtr monitor)
        {
            IntPtr result = glfwGetWin32Adapter(monitor);

            string toreturn = "";
            char c = (char)Marshal.ReadByte(result);

            while (c != '\0')
            {
                toreturn += c;
                result += 1;
                c = (char)Marshal.ReadByte(result);
            }

            return toreturn;
        }

        [DllImport("glfw3.dll", EntryPoint = "glfwGetWin32Monitor", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern IntPtr glfwGetWin32Monitor(GLFWmonitorPtr monitor);

        /// <summary>
        /// Returns the display device name of the specified monitor.
        /// Thread safety: This function may be called from any thread. Access is not synchronized.
        /// </summary>
        /// <param name="monitor"></param>
        /// <returns>The UTF-8 encoded display device name (for example \\.\DISPLAY1\Monitor0) of the specified monitor, or NULL if an error occurred.</returns>
        public static string GetWin32Monitor(GLFWmonitorPtr monitor)
        {
            IntPtr result = glfwGetWin32Monitor(monitor);

            string toreturn = "";
            char c = (char)Marshal.ReadByte(result);

            while (c != '\0')
            {
                toreturn += c;
                result += 1;
                c = (char)Marshal.ReadByte(result);
            }

            return toreturn;
        }

        /// <summary>
        /// Returns the HWND of the specified window.
        /// 
        /// The HDC associated with the window can be queried with the GetDC function.
        /// HDC dc = GetDC(glfwGetWin32Window(window));
        /// This DC is private and does not need to be released.
        /// 
        /// Thread safety: This function may be called from any thread. Access is not synchronized.
        /// </summary>
        /// <param name="window"></param>
        /// <returns>The HWND of the specified window, or NULL if an error occurred.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetWin32Window", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr GetWin32Window(GLFWwindowPtr window);

        /// <summary>
        /// Returns the HGLRC of the specified window.
        /// 
        /// The HDC associated with the window can be queried with the GetDC function.
        /// HDC dc = GetDC(glfwGetWin32Window(window));
        /// This DC is private and does not need to be released.
        /// 
        /// Thread safety: This function may be called from any thread. Access is not synchronized.
        /// </summary>
        /// <param name="window"></param>
        /// <returns>The HGLRC of the specified window, or NULL if an error occurred.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetWGLContext", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr GetWGLContext(GLFWwindowPtr window);

        /// <summary>
        /// Returns the CGDirectDisplayID of the specified monitor.
        /// 
        /// OSX
        /// 
        /// Thread safety: This function may be called from any thread. Access is not synchronized.
        /// </summary>
        /// <param name="monitor"></param>
        /// <returns>The CGDirectDisplayID of the specified monitor, or kCGNullDirectDisplay if an error occurred.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetCocoaMonitor", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr GetCocoaMonitor(GLFWmonitorPtr monitor);

        /// <summary>
        /// Returns the NSWindow of the specified window.
        /// 
        /// OSX
        /// 
        /// Thread safety: This function may be called from any thread. Access is not synchronized.
        /// </summary>
        /// <param name="window"></param>
        /// <returns>The NSWindow of the specified window, or nil if an error occurred.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetCocoaWindow", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr GetCocoaWindow(GLFWwindowPtr window);

        /// <summary>
        /// Returns the NSOpenGLContext of the specified window.
        /// 
        /// OSX
        /// 
        /// Thread safety: This function may be called from any thread. Access is not synchronized.
        /// </summary>
        /// <param name="window"></param>
        /// <returns>The NSOpenGLContext of the specified window, or nil if an error occurred.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetNSGLContext", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr GetNSGLContext(GLFWwindowPtr window);

        /// <summary>
        /// Returns the Display used by GLFW.
        /// 
        /// Thread safety: This function may be called from any thread. Access is not synchronized.
        /// </summary>
        /// <returns>The Display used by GLFW, or NULL if an error occurred.</returns>
        [DllImport("glfw3.dll", EntryPoint = "GetX11Display", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr glfwGetX11Display();

        /// <summary>
        /// Returns the RRCrtc of the specified monitor.
        /// 
        /// Thread safety: This function may be called from any thread. Access is not synchronized.
        /// </summary>
        /// <param name="monitor"></param>
        /// <returns>The RRCrtc of the specified monitor, or None if an error occurred.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetX11Adapter", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr GetX11Adapter(GLFWmonitorPtr monitor);

        /// <summary>
        /// Returns the RROutput of the specified monitor.
        /// 
        /// Thread safety: This function may be called from any thread. Access is not synchronized.
        /// </summary>
        /// <param name="monitor"></param>
        /// <returns>The RROutput of the specified monitor, or None if an error occurred.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetX11Monitor", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr GetX11Monitor(GLFWmonitorPtr monitor);

        /// <summary>
        /// Returns the Window of the specified window.
        /// 
        /// Thread safety: This function may be called from any thread. Access is not synchronized.
        /// </summary>
        /// <param name="window"></param>
        /// <returns>The Window of the specified window, or None if an error occurred.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetX11Window", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr GetX11Window(GLFWwindowPtr window);

        /// <summary>
        /// Sets the current primary selection to the specified string.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <param name="str"></param>
        [DllImport("glfw3.dll", EntryPoint = "glfwSetX11SelectionString", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void SetX11SelectionString(string str);

        [DllImport("glfw3.dll", EntryPoint = "glfwGetX11SelectionString", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern IntPtr glfwGetX11SelectionString();

        /// <summary>
        /// Returns the contents of the current primary selection as a string.
        /// 
        /// If the selection is empty or if its contents cannot be converted, NULL is returned and a GLFW_FORMAT_UNAVAILABLE error is generated.
        /// 
        /// Thread safety: This function must only be called from the main thread.
        /// </summary>
        /// <returns>The contents of the selection, or NULL if an error occurred.</returns>
        public static string GetX11SelectionString()
        {
            IntPtr result = glfwGetX11SelectionString();

            string toreturn = "";
            char c = (char)Marshal.ReadByte(result);

            while (c != '\0')
            {
                toreturn += c;
                result += 1;
                c = (char)Marshal.ReadByte(result);
            }

            return toreturn;
        }

        /// <summary>
        /// Returns the GLXContext of the specified window.
        /// 
        /// Thread safety: This function may be called from any thread. Access is not synchronized.
        /// </summary>
        /// <param name="window"></param>
        /// <returns>The GLXContext of the specified window, or NULL if an error occurred.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetGLXContext", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr GetGLXContext(GLFWwindowPtr window);

        /// <summary>
        /// Returns the GLXWindow of the specified window.
        /// 
        /// Thread safety: This function may be called from any thread.Access is not synchronized.
        /// </summary>
        /// <param name="window"></param>
        /// <returns>The GLXWindow of the specified window, or None if an error occurred.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetGLXWindow", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr GetGLXWindow(GLFWwindowPtr window);

        /// <summary>
        /// Returns the struct wl_display* used by GLFW.
        /// 
        /// Wayland - A replacement for the X11 window system protocol
        /// 
        /// Thread safety: This function may be called from any thread. Access is not synchronized.
        /// </summary>
        /// <returns>The struct wl_display used by GLFW, or NULL if an error occurred.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetWaylandDisplay", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr GetWaylandDisplay();

        /// <summary>
        /// Returns the struct wl_output* of the specified monitor.
        /// 
        /// Wayland - A replacement for the X11 window system protocol
        /// 
        /// Thread safety: This function may be called from any thread. Access is not synchronized.
        /// </summary>
        /// <param name="monitor"></param>
        /// <returns>The struct wl_output of the specified monitor, or NULL if an error occurred.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetWaylandMonitor", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr GetWaylandMonitor(GLFWmonitorPtr monitor);

        /// <summary>
        /// Returns the main struct wl_surface of the specified window.
        /// 
        /// Wayland - A replacement for the X11 window system protocol
        /// 
        /// Thread safety: This function may be called from any thread. Access is not synchronized.
        /// </summary>
        /// <param name="window"></param>
        /// <returns>The main struct wl_surface of the specified window, or NULL if an error occurred.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetWaylandWindow", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr GetWaylandWindow(GLFWwindowPtr window);

        /// <summary>
        /// Returns the EGLDisplay used by GLFW.
        /// 
        /// Because EGL is initialized on demand, this function will return EGL_NO_DISPLAY until the first context has been created via EGL.
        /// 
        /// EGLDisplay - The EGLDisplay can be allocated by Android
        /// 
        /// Thread safety: This function may be called from any thread. Access is not synchronized.
        /// </summary>
        /// <returns>The EGLDisplay used by GLFW, or EGL_NO_DISPLAY if an error occurred.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetEGLDisplay", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr GetEGLDisplay();

        /// <summary>
        /// Returns the EGLContext of the specified window. 
        /// 
        /// EGLContext - The EGLContext can be allocated by Android
        /// 
        /// Thread safety: This function may be called from any thread. Access is not synchronized.
        /// </summary>
        /// <param name="window"></param>
        /// <returns>The EGLContext of the specified window, or EGL_NO_CONTEXT if an error occurred.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetEGLContext", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr GetEGLContext(GLFWwindowPtr window);

        /// <summary>
        /// Returns the EGLSurface of the specified window.
        /// 
        /// EGLSurfaces - The EGLSurface can be an off-screen buffer allocated by Android EGL
        /// 
        /// Thread safety: This function may be called from any thread. Access is not synchronized.
        /// </summary>
        /// <param name="window"></param>
        /// <returns>The EGLSurface of the specified window, or EGL_NO_SURFACE if an error occurred.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetEGLSurface", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr GetEGLSurface(GLFWwindowPtr window);

        /// <summary>
        /// Retrieves the color buffer associated with the specified window.
        /// 
        /// Thread safety: This function may be called from any thread. Access is not synchronized.
        /// </summary>
        /// <param name="window">The window whose color buffer to retrieve.</param>
        /// <param name="width">Where to store the width of the color buffer</param>
        /// <param name="height">Where to store the height of the color buffer</param>
        /// <param name="format">Where to store the OSMesa pixel format of the color buffer</param>
        /// <param name="buffer">Where to store the address of the color buffer, or IntPtr.Zero.</param>
        /// <returns></returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetOSMesaColorBuffer", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int GetOSMesaColorBuffer(GLFWwindowPtr window, out int width, out int height, out int format, ref IntPtr buffer);

        /// <summary>
        /// Retrieves the depth buffer associated with the specified window.
        /// 
        /// Thread safety: This function may be called from any thread. Access is not synchronized.
        /// </summary>
        /// <param name="window">The window whose depth buffer to retrieve.</param>
        /// <param name="width">Where to store the width of the depth buffer</param>
        /// <param name="height">Where to store the height of the depth buffer</param>
        /// <param name="bytesPerValue">Where to store the number of bytes per depth buffer element</param>
        /// <param name="buffer">Where to store the address of the depth buffer, or IntPtr.Zero</param>
        /// <returns>1 if successful, or 0 if an error occurred.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetOSMesaDepthBuffer", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int GetOSMesaDepthBuffer(GLFWwindowPtr window, out int width, out int height, out int bytesPerValue, ref IntPtr buffer);

        /// <summary>
        /// Returns the OSMesaContext of the specified window.
        /// 
        /// See: https://docs.mesa3d.org/index.html
        /// Used by Intel and AMD for their respective hardware
        /// 
        /// Thread safety: This function may be called from any thread. Access is not synchronized.
        /// </summary>
        /// <param name="window">The window whose OSMesaContext to retrieve.</param>
        /// <returns>The OSMesaContext of the specified window, or null if an error occurred.</returns>
        [DllImport("glfw3.dll", EntryPoint = "glfwGetOSMesaContext", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr GetOSMesaContext(GLFWwindowPtr window);

        #endregion
    }
}
