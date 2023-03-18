using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrairieGL.Glfw
{
    /// <summary>
    /// Initialization hints are set before glfwInit and affect how the library behaves until termination. 
    /// Hints are set with glfwInitHint.
    /// </summary>
    public enum InitHints
    {
        /// <summary>
        /// specifies whether to also expose joystick hats as buttons, 
        /// for compatibility with earlier versions of GLFW that did not have glfwGetJoystickHats. 
        /// </summary>
        GLFW_JOYSTICK_HAT_BUTTONS = 0x00050001,
        /// <summary>
        /// Sspecifies whether to set the current directory to the application to the Contents/Resources subdirectory 
        /// of the application's bundle, if present. Set this with glfwInitHint.
        /// </summary>
        GLFW_COCOA_CHDIR_RESOURCES = 0x00051001,
        /// <summary>
        /// Specifies whether to create a basic menu bar, either from a nib or manually, when the first window is created, 
        /// which is when AppKit is initialized. Set this with glfwInitHint.
        /// </summary>
        GLFW_COCOA_MENUBAR = 0x00051002,
        GLFW_DONT_CARE              =-1
    }

    public enum GlfwInputModes : int
    {
        GLFW_CURSOR                 = 0x00033001,
        GLFW_STICKY_KEYS            = 0x00033002,
        GLFW_STICKY_MOUSE_BUTTONS   = 0x00033003,
        GLFW_LOCK_KEY_MODS          = 0x00033004,
        GLFW_RAW_MOUSE_MOTION       = 0x00033005
    }

    public enum GlfwCursorModes
    {
        /// <summary>
        /// makes the cursor visible and behaving normally.
        /// </summary>
        GLFW_CURSOR_NORMAL = 0x00034001,
        /// <summary>
        /// makes the cursor invisible when it is over the content area of the window but does not restrict the cursor from leaving.
        /// </summary>
        GLFW_CURSOR_HIDDEN = 0x00034002,
        /// <summary>
        /// hides and grabs the cursor, providing virtual and unlimited cursor movement. 
        /// This is useful for implementing for example 3D camera controls.
        /// </summary>
        GLFW_CURSOR_DISABLED = 0x00034003
    }

    /// <summary>
    /// These key codes are inspired by the _USB HID Usage Tables v1.12_ (p. 53-60),
    ///  but re-arranged to map to 7-bit ASCII for printable keys(function keys are
    ///  put in the 256+ range).
    /// 
    ///  The naming of the key codes follow these rules:
    ///    - The US keyboard layout is used
    ///    - Names of printable alpha-numeric characters are used(e.g. "A", "R",
    ///      "3", etc.)
    ///    - For non-alphanumeric characters, Unicode:ish names are used(e.g.
    ///      "COMMA", "LEFT_SQUARE_BRACKET", etc.). Note that some names do not
    ///  correspond to the Unicode standard(usually for brevity)
    ///    - Keys that lack a clear US mapping are named "WORLD_x"
    ///    - For non-printable keys, custom names are used(e.g. "F4",
    ///      "BACKSPACE", etc.)
    /// 
    /// </summary>
    public enum KeyboardKeys : int
    {
        GLFW_KEY_UNKNOWN = -1,

        /* Printable keys */
        GLFW_KEY_SPACE = 32,
        /// <summary>
        /// '
        /// </summary>
        GLFW_KEY_APOSTROPHE = 39,  /* ' */
        /// <summary>
        /// ,
        /// </summary>
        GLFW_KEY_COMMA = 44,  /* , */
        /// <summary>
        /// -
        /// </summary>
        GLFW_KEY_MINUS = 45,  /* - */
        /// <summary>
        /// .
        /// </summary>
        GLFW_KEY_PERIOD = 46,  /* . */
        /// <summary>
        /// /
        /// </summary>
        GLFW_KEY_SLASH = 47,  /* / */
        GLFW_KEY_0 = 48,
        GLFW_KEY_1 = 49,
        GLFW_KEY_2 = 50,
        GLFW_KEY_3 = 51,
        GLFW_KEY_4 = 52,
        GLFW_KEY_5 = 53,
        GLFW_KEY_6 = 54,
        GLFW_KEY_7 = 55,
        GLFW_KEY_8 = 56,
        GLFW_KEY_9 = 57,
        /// <summary>
        /// ;
        /// </summary>
        GLFW_KEY_SEMICOLON = 59,  /* ; */
        /// <summary>
        /// =
        /// </summary>
        GLFW_KEY_EQUAL = 61,  /* = */
        GLFW_KEY_A = 65,
        GLFW_KEY_B = 66,
        GLFW_KEY_C = 67,
        GLFW_KEY_D = 68,
        GLFW_KEY_E = 69,
        GLFW_KEY_F = 70,
        GLFW_KEY_G = 71,
        GLFW_KEY_H = 72,
        GLFW_KEY_I = 73,
        GLFW_KEY_J = 74,
        GLFW_KEY_K = 75,
        GLFW_KEY_L = 76,
        GLFW_KEY_M = 77,
        GLFW_KEY_N = 78,
        GLFW_KEY_O = 79,
        GLFW_KEY_P = 80,
        GLFW_KEY_Q = 81,
        GLFW_KEY_R = 82,
        GLFW_KEY_S = 83,
        GLFW_KEY_T = 84,
        GLFW_KEY_U = 85,
        GLFW_KEY_V = 86,
        GLFW_KEY_W = 87,
        GLFW_KEY_X = 88,
        GLFW_KEY_Y = 89,
        GLFW_KEY_Z = 90,
        /// <summary>
        /// [
        /// </summary>
        GLFW_KEY_LEFT_BRACKET = 91,  /* [ */
        /// <summary>
        /// \
        /// </summary>
        GLFW_KEY_BACKSLASH = 92,  /* \ */
        /// <summary>
        /// ]
        /// </summary>
        GLFW_KEY_RIGHT_BRACKET = 93,  /* ] */
        /// <summary>
        /// `
        /// </summary>
        GLFW_KEY_GRAVE_ACCENT = 96,  /* ` */
        /// <summary>
        /// non-US #1
        /// </summary>
        GLFW_KEY_WORLD_1 = 161, /* non-US #1 */
        /// <summary>
        /// non-US #2
        /// </summary>
        GLFW_KEY_WORLD_2 = 162, /* non-US #2 */

        /* Function keys */
        GLFW_KEY_ESCAPE = 256,
        GLFW_KEY_ENTER = 257,
        GLFW_KEY_TAB = 258,
        GLFW_KEY_BACKSPACE = 259,
        GLFW_KEY_INSERT = 260,
        GLFW_KEY_DELETE = 261,
        GLFW_KEY_RIGHT = 262,
        GLFW_KEY_LEFT = 263,
        GLFW_KEY_DOWN = 264,
        GLFW_KEY_UP = 265,
        GLFW_KEY_PAGE_UP = 266,
        GLFW_KEY_PAGE_DOWN = 267,
        GLFW_KEY_HOME = 268,
        GLFW_KEY_END = 269,
        GLFW_KEY_CAPS_LOCK = 280,
        GLFW_KEY_SCROLL_LOCK = 281,
        GLFW_KEY_NUM_LOCK = 282,
        GLFW_KEY_PRINT_SCREEN = 283,
        GLFW_KEY_PAUSE = 284,
        GLFW_KEY_F1 = 290,
        GLFW_KEY_F2 = 291,
        GLFW_KEY_F3 = 292,
        GLFW_KEY_F4 = 293,
        GLFW_KEY_F5 = 294,
        GLFW_KEY_F6 = 295,
        GLFW_KEY_F7 = 296,
        GLFW_KEY_F8 = 297,
        GLFW_KEY_F9 = 298,
        GLFW_KEY_F10 = 299,
        GLFW_KEY_F11 = 300,
        GLFW_KEY_F12 = 301,
        GLFW_KEY_F13 = 302,
        GLFW_KEY_F14 = 303,
        GLFW_KEY_F15 = 304,
        GLFW_KEY_F16 = 305,
        GLFW_KEY_F17 = 306,
        GLFW_KEY_F18 = 307,
        GLFW_KEY_F19 = 308,
        GLFW_KEY_F20 = 309,
        GLFW_KEY_F21 = 310,
        GLFW_KEY_F22 = 311,
        GLFW_KEY_F23 = 312,
        GLFW_KEY_F24 = 313,
        GLFW_KEY_F25 = 314,
        GLFW_KEY_KP_0 = 320,
        GLFW_KEY_KP_1 = 321,
        GLFW_KEY_KP_2 = 322,
        GLFW_KEY_KP_3 = 323,
        GLFW_KEY_KP_4 = 324,
        GLFW_KEY_KP_5 = 325,
        GLFW_KEY_KP_6 = 326,
        GLFW_KEY_KP_7 = 327,
        GLFW_KEY_KP_8 = 328,
        GLFW_KEY_KP_9 = 329,
        GLFW_KEY_KP_DECIMAL = 330,
        GLFW_KEY_KP_DIVIDE = 331,
        GLFW_KEY_KP_MULTIPLY = 332,
        GLFW_KEY_KP_SUBTRACT = 333,
        GLFW_KEY_KP_ADD = 334,
        GLFW_KEY_KP_ENTER = 335,
        GLFW_KEY_KP_EQUAL = 336,
        GLFW_KEY_LEFT_SHIFT = 340,
        GLFW_KEY_LEFT_CONTROL = 341,
        GLFW_KEY_LEFT_ALT = 342,
        GLFW_KEY_LEFT_SUPER = 343,
        GLFW_KEY_RIGHT_SHIFT = 344,
        GLFW_KEY_RIGHT_CONTROL = 345,
        GLFW_KEY_RIGHT_ALT = 346,
        GLFW_KEY_RIGHT_SUPER = 347,
        GLFW_KEY_MENU = 348,

        GLFW_KEY_LAST = GLFW_KEY_MENU

    }

    public enum ModifierKeys: int
    {
        /// <summary>
        /// If this bit is set one or more Shift keys were held down.
        /// </summary>
        GLFW_MOD_SHIFT = 0x0001,


        /// <summary>
        /// If this bit is set one or more Control keys were held down.
        /// </summary>
        GLFW_MOD_CONTROL = 0x0002,


        /// <summary>
        /// If this bit is set one or more Alt keys were held down.
        /// </summary>
        GLFW_MOD_ALT = 0x0004,


        /// <summary>
        /// If this bit is set one or more Super keys were held down.
        /// </summary>
        GLFW_MOD_SUPER = 0x0008,


        /// <summary>
        /// If this bit is set the Caps Lock key is enabled and the GLFW_LOCK_KEY_MODS input mode is set.
        /// </summary>
        GLFW_MOD_CAPS_LOCK = 0x0010,


        /// <summary>
        /// If this bit is set the Num Lock key is enabled and the GLFW_LOCK_KEY_MODS input mode is set.
        /// </summary>
        GLFW_MOD_NUM_LOCK = 0x0020,

    }

    public enum KeyActions
    {
        GLFW_RELEASE               = 0,
        GLFW_PRESS                 = 1,
        GLFW_REPEAT                = 2
    }

    /// <summary>
    /// There are a number of hints that can be set before the creation of a window and context. 
    /// Some affect the window itself, others affect the framebuffer or context. 
    /// These hints are set to their default values each time the library is initialized with glfwInit. 
    /// Integer value hints can be set individually with glfwWindowHint and string value hints with glfwWindowHintString. 
    /// You can reset all at once to their defaults with glfwDefaultWindowHints.
    /// 
    /// Some hints are platform specific. These are always valid to set on any platform but they will only affect 
    /// their specific platform. Other platforms will ignore them.Setting these hints requires no platform specific 
    /// headers or calls.
    /// 
    /// Note
    /// Window hints need to be set before the creation of the window and context you wish to have the specified 
    /// attributes.They function as additional arguments to glfwCreateWindow.
    /// 
    /// Hard and soft constraints
    /// Some window hints are hard constraints. These must match the available capabilities exactly for window and 
    /// context creation to succeed. Hints that are not hard constraints are matched as closely as possible, 
    /// but the resulting context and framebuffer may differ from what these hints requested.
    /// 
    /// The following hints are always hard constraints:
    /// 
    /// GLFW_STEREO
    /// GLFW_DOUBLEBUFFER
    /// GLFW_CLIENT_API
    /// GLFW_CONTEXT_CREATION_API
    /// 
    /// The following additional hints are hard constraints when requesting an OpenGL context, 
    /// but are ignored when requesting an OpenGL ES context:
    /// 
    /// 
    /// GLFW_OPENGL_FORWARD_COMPAT
    /// GLFW_OPENGL_PROFILE
    /// </summary>
    public enum WindowHints
    {
        /// <summary>
        /// Specifies whether the windowed mode window will be resizable by the user. 
        /// The window will still be resizable using the glfwSetWindowSize function. 
        /// This hint is ignored for full screen and undecorated windows.
        /// 
        /// Default Value: 1 (True)
        /// Valid options: 1 (True) or 0 (False)
        /// </summary>
        GLFW_RESIZABLE = 0x00020003,
        /// <summary>
        /// Specifies whether the windowed mode window will be initially visible. 
        /// This hint is ignored for full screen windows.
        /// 
        /// 1 (True)
        /// Valid options: 1 (True) or 0 (False)
        /// </summary>
        GLFW_VISIBLE = 0x00020004,
        /// <summary>
        /// Specifies whether the windowed mode window will have window decorations such as a border, a close widget, etc. 
        /// An undecorated window will not be resizable by the user but will still allow the user to generate 
        /// close events on some platforms.
        /// This hint is ignored for full screen windows.
        /// 
        /// Default Value: 1 (True)
        /// Valid options: 1 (True) or 0 (False)
        /// </summary>
        GLFW_DECORATED = 0x00020005,
        /// <summary>
        /// specifies whether the windowed mode window will be given input focus when created. 
        /// This hint is ignored for full screen and initially hidden windows.
        /// 
        /// Default Value: 1 (True)
        /// Valid options: 1 (True) or 0 (False)
        /// </summary>
        GLFW_FOCUSED = 0x00020001,
        /// <summary>
        /// Specifies whether the full screen window will automatically iconify and restore the previous 
        /// video mode on input focus loss. 
        /// This hint is ignored for windowed mode windows.
        /// 
        /// Default Value: 1 (True)
        /// Valid options: 1 (True) or 0 (False)
        /// </summary>
        GLFW_AUTO_ICONIFY = 0x00020006,
        /// <summary>
        /// Specifies whether the windowed mode window will be floating above other regular windows, also called topmost or 
        /// always-on-top. This is intended primarily for debugging purposes and cannot be used to implement proper full 
        /// screen windows. 
        /// This hint is ignored for full screen windows.
        /// 
        /// Default Value: 1 (True)
        /// Valid options: 1 (True) or 0 (False)
        /// </summary>
        GLFW_FLOATING = 0x00020007,
        /// <summary>
        /// Specifies whether the windowed mode window will be maximized when created.
        /// This hint is ignored for full screen windows.
        /// 
        /// Default Value: 1 (True)
        /// Valid options: 1 (True) or 0 (False)
        /// </summary>
        GLFW_MAXIMIZED = 0x00020008,
        /// <summary>
        /// Specifies whether the cursor should be centered over newly created full screen windows. 
        /// This hint is ignored for windowed mode windows.
        /// 
        /// Default Value: 1 (True)
        /// Valid options: 1 (True) or 0 (False)
        /// </summary>
        GLFW_CENTER_CURSOR = 0x00020009,
        /// <summary>
        /// Specifies whether the window framebuffer will be transparent. 
        /// If enabled and supported by the system, the window framebuffer alpha channel will be used to combine the 
        /// framebuffer with the background. 
        /// This does not affect window decorations.
        /// 
        /// Default Value: 1 (True)
        /// Valid options: 1 (True) or 0 (False)
        /// </summary>
        GLFW_TRANSPARENT_FRAMEBUFFER = 0x0002000A,
        /// <summary>
        /// Specifies whether the window will be given input focus when glfwShowWindow is called. 
        /// 
        /// Default Value: 1 (True)
        /// Valid options: 1 (True) or 0 (False)
        /// </summary>
        GLFW_FOCUS_ON_SHOW = 0x0002000C,
        /// <summary>
        /// Specified whether the window content area should be resized based on the monitor content scale of 
        /// any monitor it is placed on. This includes the initial placement when the window is created.
        ///
        /// This hint only has an effect on platforms where screen coordinates and pixels always map 1:1 
        /// such as Windows and X11. On platforms like macOS the resolution of the framebuffer is changed 
        /// independently of the window size.
        /// 
        /// Default Value: 1 (True)
        /// Valid options: 1 (True) or 0 (False)
        /// </summary>
        GLFW_SCALE_TO_MONITOR = 0x0002200C,
        /// <summary>
        /// Specifies the desired bit depths of the various components of the default framebuffer. 
        /// A value of GLFW_DONT_CARE means the application has no preference.
        /// 
        /// Default Value: 8
        /// Valid options: 0 to INT_MAX or GLFW_DONT_CARE
        /// </summary>
        GLFW_RED_BITS = 0x00021001,

        /// <summary>
        /// Specifies the desired bit depths of the various components of the default framebuffer. 
        /// A value of GLFW_DONT_CARE means the application has no preference.
        /// 
        /// Default Value: 8
        /// Valid options: 0 to INT_MAX or GLFW_DONT_CARE
        /// </summary>
        GLFW_GREEN_BITS = 0x00021002,

        /// <summary>
        /// Specifies the desired bit depths of the various components of the default framebuffer. 
        /// A value of GLFW_DONT_CARE means the application has no preference.
        /// 
        /// Default Value: 8
        /// Valid options: 0 to INT_MAX or GLFW_DONT_CARE
        /// </summary>
        GLFW_BLUE_BITS = 0x00021003,

        /// <summary>
        /// Specifies the desired bit depths of the various components of the default framebuffer. 
        /// A value of GLFW_DONT_CARE means the application has no preference.
        /// 
        /// Default Value: 8
        /// Valid options: 0 to INT_MAX or GLFW_DONT_CARE
        /// </summary>
        GLFW_ALPHA_BITS = 0x00021004,

        /// <summary>
        /// Specifies the desired bit depths of the various components of the default framebuffer. 
        /// A value of GLFW_DONT_CARE means the application has no preference.
        /// 
        /// Default Value: 24
        /// Valid options: 0 to INT_MAX or GLFW_DONT_CARE
        /// </summary>
        /// Specifies the desired bit depths of the various components of the default framebuffer. 
        /// A value of GLFW_DONT_CARE means the application has no preference.
        /// 
        GLFW_DEPTH_BITS = 0x00021005,

        /// <summary>
        /// Specifies the desired bit depths of the various components of the default framebuffer. 
        /// A value of GLFW_DONT_CARE means the application has no preference.
        /// 
        /// Default Value: 8
        /// Valid options: 0 to INT_MAX or GLFW_DONT_CARE
        /// </summary>
        GLFW_STENCIL_BITS = 0x00021006,

        /// <summary>
        /// Specifies the desired bit depths of the various components of the default framebuffer. 
        /// A value of GLFW_DONT_CARE means the application has no preference.
        /// Accumulation buffers are a legacy OpenGL feature and should not be used in new code.
        /// 
        /// Default Value: 0
        /// Valid options: 0 to INT_MAX or GLFW_DONT_CARE
        /// </summary>
        [Obsolete]
        GLFW_ACCUM_RED_BITS = 0x00021007,

        /// <summary>
        /// Specifies the desired bit depths of the various components of the default framebuffer. 
        /// A value of GLFW_DONT_CARE means the application has no preference.
        /// Accumulation buffers are a legacy OpenGL feature and should not be used in new code.
        /// 
        /// Default Value: 0
        /// Valid options: 0 to INT_MAX or GLFW_DONT_CARE
        /// </summary>
        [Obsolete]
        GLFW_ACCUM_GREEN_BITS = 0x00021008,

        /// <summary>
        /// Specifies the desired bit depths of the various components of the default framebuffer. 
        /// A value of GLFW_DONT_CARE means the application has no preference.
        /// Accumulation buffers are a legacy OpenGL feature and should not be used in new code.
        /// 
        /// Default Value: 0
        /// Valid options: 0 to INT_MAX or GLFW_DONT_CARE
        /// </summary>
        [Obsolete]
        GLFW_ACCUM_BLUE_BITS = 0x00021009,

        /// <summary>
        /// Specifies the desired bit depths of the various components of the default framebuffer. 
        /// A value of GLFW_DONT_CARE means the application has no preference.
        /// Accumulation buffers are a legacy OpenGL feature and should not be used in new code.
        /// 
        /// Default Value: 0
        /// Valid options: 0 to INT_MAX or GLFW_DONT_CARE
        /// </summary>
        [Obsolete]
        GLFW_ACCUM_ALPHA_BITS = 0x0002100A,

        /// <summary>
        /// Specifies the desired number of auxiliary buffers.
        /// A value of GLFW_DONT_CARE means the application has no preference. 
        /// Accumulation buffers are a legacy OpenGL feature and should not be used in new code.
        /// 
        /// Default Value: 0
        /// Valid options: 0 to INT_MAX or GLFW_DONT_CARE
        /// </summary>
        [Obsolete]
        GLFW_AUX_BUFFERS = 0x0002100B,

        /// <summary>
        /// Specifies the desired number of samples to use for multisampling. 
        /// Zero disables multisampling. 
        /// A value of GLFW_DONT_CARE means the application has no preference.
        /// 
        /// Default Value: 0
        /// Valid options: 0 to INT_MAX or GLFW_DONT_CARE
        /// </summary>
        GLFW_SAMPLES = 0x0002100D,

        /// <summary>
        /// Specifies the desired refresh rate for full screen windows. 
        /// A value of GLFW_DONT_CARE means the highest available refresh rate will be used. 
        /// This hint is ignored for windowed mode windows.
        /// 
        /// Default Value: GLFW_DONT_CARE
        /// Valid options: 0 to INT_MAX or GLFW_DONT_CARE
        /// </summary>
        GLFW_REFRESH_RATE = 0x0002100F,

        /// <summary>
        /// Specifies whether to use OpenGL stereoscopic rendering. 
        /// This is a hard constraint.
        /// 
        /// Default Value: 0 (False)
        /// Valid options: 1 (True) or 0 (False)
        /// </summary>
        GLFW_STEREO = 0x0002100C,

        /// <summary>
        /// Specifies whether the framebuffer should be sRGB capable. 
        /// 
        /// Note
        /// OpenGL: If enabled and supported by the system, the GL_FRAMEBUFFER_SRGB enable will control sRGB rendering. By default, sRGB rendering will be disabled.
        /// OpenGL ES: If enabled and supported by the system, the context will always have sRGB rendering enabled.
        /// 
        /// Default Value: 0 (False)
        /// Valid options: 1 (True) or 0 (False)
        /// </summary>
        GLFW_SRGB_CAPABLE = 0x0002100E,

        /// <summary>
        /// Specifies whether the framebuffer should be double buffered. You nearly always want to use double buffering. 
        /// This is a hard constraint. 
        /// 
        /// Default Value: 1 (True)
        /// Valid options: 1 (True) or 0 (False)
        /// </summary>
        GLFW_DOUBLEBUFFER = 0x00021010,

        /// <summary>
        /// Specifies which client API to create the context for. 
        /// Possible values are GLFW_OPENGL_API, GLFW_OPENGL_ES_API and GLFW_NO_API. 
        /// This is a hard constraint.
        /// 
        /// Default Value: GLFW_OPENGL_API
        /// Valid options: GLFW_OPENGL_API, GLFW_OPENGL_ES_API or GLFW_NO_API
        /// </summary>
        GLFW_CLIENT_API = 0x00022001,

        /// <summary>
        /// Specifies which context creation API to use to create the context. 
        /// Possible values are GLFW_NATIVE_CONTEXT_API, GLFW_EGL_CONTEXT_API and GLFW_OSMESA_CONTEXT_API. 
        /// This is a hard constraint. If no client API is requested, this hint is ignored.
        /// 
        /// An extension loader library that assumes it knows which API was used to create the current context may fail 
        /// if you change this hint. This can be resolved by having it load functions via glfwGetProcAddress.
        /// 
        /// Default Value: GLFW_NATIVE_CONTEXT_API
        /// Valid options: GLFW_NATIVE_CONTEXT_API, GLFW_EGL_CONTEXT_API or GLFW_OSMESA_CONTEXT_API
        /// </summary>
        GLFW_CONTEXT_CREATION_API = 0x0002200B,

        /// <summary>
        /// Specify the client API version that the created context must be compatible with. 
        /// The exact behavior of these hints depend on the requested client API.
        /// 
        /// While there is no way to ask the driver for a context of the highest supported version, 
        /// GLFW will attempt to provide this when you ask for a version 1.0 context, which is the default for these hints.
        /// 
        /// Do not confuse these hints with GLFW_VERSION_MAJOR and GLFW_VERSION_MINOR, 
        /// which provide the API version of the GLFW header.
        /// 
        /// Default Value: 1
        /// Valid options: Any valid major version number of the chosen client API
        /// </summary>
        GLFW_CONTEXT_VERSION_MAJOR = 0x00022002,

        /// <summary>
        /// Specify the client API version that the created context must be compatible with. 
        /// The exact behavior of these hints depend on the requested client API.
        /// 
        /// While there is no way to ask the driver for a context of the highest supported version, 
        /// GLFW will attempt to provide this when you ask for a version 1.0 context, which is the default for these hints.
        /// 
        /// Do not confuse these hints with GLFW_VERSION_MAJOR and GLFW_VERSION_MINOR, 
        /// which provide the API version of the GLFW header.
        /// 
        /// Default Value: 0
        /// Valid options: Any valid minor version number of the chosen client API
        /// </summary>
        GLFW_CONTEXT_VERSION_MINOR = 0x00022003,

        /// <summary>
        /// Specifies the robustness strategy to be used by the context. 
        /// This can be one of GLFW_NO_RESET_NOTIFICATION or GLFW_LOSE_CONTEXT_ON_RESET, or GLFW_NO_ROBUSTNESS 
        /// to not request a robustness strategy.
        /// 
        /// Default Value: 0 (GLFW_NO_ROBUSTNESS)
        /// Valid options: 0 (GLFW_NO_ROBUSTNESS), 0x00031001 (GLFW_NO_RESET_NOTIFICATION) or 0x00031002 (GLFW_LOSE_CONTEXT_ON_RESET)
        /// </summary>
        GLFW_CONTEXT_ROBUSTNESS = 0x00022005,

        /// <summary>
        /// Specifies the release behavior to be used by the context. 
        /// Possible values are one of GLFW_ANY_RELEASE_BEHAVIOR, GLFW_RELEASE_BEHAVIOR_FLUSH or GLFW_RELEASE_BEHAVIOR_NONE. 
        /// If the behavior is GLFW_ANY_RELEASE_BEHAVIOR, the default behavior of the context creation API will be used. 
        /// If the behavior is GLFW_RELEASE_BEHAVIOR_FLUSH, the pipeline will be flushed whenever the context is released 
        /// from being the current one. 
        /// If the behavior is GLFW_RELEASE_BEHAVIOR_NONE, the pipeline will not be flushed on release.
        /// Default Value: 0 (GLFW_ANY_RELEASE_BEHAVIOR)
        /// Valid options: 
        /// 0 (GLFW_ANY_RELEASE_BEHAVIOR), 
        /// 0x00035001 (GLFW_RELEASE_BEHAVIOR_FLUSH) or 
        /// 0x00035002 (GLFW_RELEASE_BEHAVIOR_NONE)
        /// </summary>
        GLFW_CONTEXT_RELEASE_BEHAVIOR = 0x00022009,

        /// <summary>
        /// Specifies whether the OpenGL context should be forward-compatible, 
        /// i.e. one where all functionality deprecated in the requested version of OpenGL is removed. 
        /// This must only be used if the requested OpenGL version is 3.0 or above. 
        /// If OpenGL ES is requested, this hint is ignored.
        /// 
        ///  Default Value: 0 (False)
        /// Valid options: 1 (True) or 0 (False)
        /// </summary>
        GLFW_OPENGL_FORWARD_COMPAT = 0x00022006,

        /// <summary>
        /// Specifies whether the context should be created in debug mode, which may provide additional error and 
        /// diagnostic reporting functionality. 
        /// 
        /// Default Value: 0 (False)
        /// Valid options: 1 (True) or 0 (False)
        /// </summary>
        GLFW_OPENGL_DEBUG_CONTEXT = 0x00022007,

        /// <summary>
        /// Specifies whether errors should be generated by the context. 
        /// Possible values are 1 (True) and 0 (False). 
        /// If enabled, situations that would have generated errors instead cause undefined behavior.
        /// </summary>
        GLFW_CONTEXT_NO_ERROR = 0x0002200A,

        /// <summary>
        /// Specifies which OpenGL profile to create the context for. 
        /// Possible values are one of GLFW_OPENGL_CORE_PROFILE or GLFW_OPENGL_COMPAT_PROFILE, or GLFW_OPENGL_ANY_PROFILE 
        /// to not request a specific profile.
        /// If requesting an OpenGL version below 3.2, GLFW_OPENGL_ANY_PROFILE must be used. 
        /// If OpenGL ES is requested, this hint is ignored.
        /// 
        /// Default Value: 0 (GLFW_OPENGL_ANY_PROFILE)
        /// Valid options: 
        /// 0 (GLFW_OPENGL_ANY_PROFILE), 
        /// 0x00032002 (GLFW_OPENGL_COMPAT_PROFILE) or 
        /// 0x00032001 (GLFW_OPENGL_CORE_PROFILE)
        /// </summary>
        GLFW_OPENGL_PROFILE = 0x00022008,

        /// <summary>
        /// Specifies whether to use full resolution framebuffers on Retina displays. 
        /// This is ignored on other platforms.
        /// 
        /// Default Value: 1 (True)
        /// Valid options: 1 (True) or 0 (False)
        /// </summary>
        GLFW_COCOA_RETINA_FRAMEBUFFER = 0x00023001,

        /// <summary>
        /// Specifies the UTF-8 encoded name to use for autosaving the window frame, or if empty disables frame autosaving 
        /// for the window. 
        /// This is ignored on other platforms. 
        /// This is set with glfwWindowHintString.
        /// 
        /// Default Value: ""
        /// Valid options: A UTF-8 encoded frame autosave name
        /// </summary>
        GLFW_COCOA_FRAME_NAME = 0x00023002,

        /// <summary>
        /// Specifies whether to in Automatic Graphics Switching, i.e. to allow the system to choose the 
        /// integrated GPU for the OpenGL context and move it between GPUs if necessary or whether 
        /// to force it to always run on the discrete GPU. 
        /// This only affects systems with both integrated and discrete GPUs. 
        /// This is ignored on other platforms.
        /// 
        /// Simpler programs and tools may want to enable this to save power, while games and other 
        /// applications performing advanced rendering will want to leave it disabled.
        /// 
        /// A bundled application that wishes to participate in Automatic Graphics Switching should also declare this 
        /// in its Info.plist by setting the NSSupportsAutomaticGraphicsSwitching key to true.
        /// 
        /// Default Value: 0 (False)
        /// Valid options: 1 (True) or 0 (False)
        /// </summary>
        GLFW_COCOA_GRAPHICS_SWITCHING = 0x00023003,

        /// <summary>
        /// Specifies the desired ASCII encoded class and instance parts of the ICCCM WM_CLASS window property. 
        /// This is set with glfwWindowHintString.
        /// 
        /// Default Value: ""
        /// Valid options: An ASCII encoded WM_CLASS class name
        /// </summary>
        GLFW_X11_CLASS_NAME = 0x00024001,

        /// <summary>
        /// Specifies the desired ASCII encoded class and instance parts of the ICCCM WM_CLASS window property. 
        /// This is set with glfwWindowHintString.
        /// 
        /// Default Value: ""
        /// Valid options: An ASCII encoded WM_CLASS instance name
        /// </summary>
        GLFW_X11_INSTANCE_NAME = 0x00024002,

        GLFW_CONTEXT_REVISION = 0x00022004
    }

    public enum MouseButtons
    {
        GLFW_MOUSE_BUTTON_1 = 0,
        GLFW_MOUSE_BUTTON_2 = 1,
        GLFW_MOUSE_BUTTON_3 = 2,
        GLFW_MOUSE_BUTTON_4 = 3,
        GLFW_MOUSE_BUTTON_5 = 4,
        GLFW_MOUSE_BUTTON_6 = 5,
        GLFW_MOUSE_BUTTON_7 = 6,
        GLFW_MOUSE_BUTTON_8 = 7,
        GLFW_MOUSE_BUTTON_LAST = GLFW_MOUSE_BUTTON_8,
        GLFW_MOUSE_BUTTON_LEFT = GLFW_MOUSE_BUTTON_1,
        GLFW_MOUSE_BUTTON_RIGHT = GLFW_MOUSE_BUTTON_2,
        GLFW_MOUSE_BUTTON_MIDDLE = GLFW_MOUSE_BUTTON_3
    }

    public enum StandardCursorShapes
    {
        /// <summary>
        /// The regular arrow cursor.
        /// </summary>
        GLFW_ARROW_CURSOR = 0x00036001,

        /// <summary>
        /// The text input I-beam cursor shape.
        /// </summary>
        GLFW_IBEAM_CURSOR = 0x00036002,

        /// <summary>
        /// The crosshair shape.
        /// </summary>
        GLFW_CROSSHAIR_CURSOR = 0x00036003,

        /// <summary>
        /// The hand shape.
        /// </summary>
        GLFW_HAND_CURSOR = 0x00036004,

        /// <summary>
        /// The horizontal resize arrow shape.
        /// </summary>
        GLFW_HRESIZE_CURSOR = 0x00036005,

        /// <summary>
        /// The vertical resize arrow shape.
        /// </summary>
        GLFW_VRESIZE_CURSOR = 0x00036006
    }

    public enum Joysticks
    {
        GLFW_JOYSTICK_1 = 0,
        GLFW_JOYSTICK_2 = 1,
        GLFW_JOYSTICK_3 = 2,
        GLFW_JOYSTICK_4 = 3,
        GLFW_JOYSTICK_5 = 4,
        GLFW_JOYSTICK_6 = 5,
        GLFW_JOYSTICK_7 = 6,
        GLFW_JOYSTICK_8 = 7,
        GLFW_JOYSTICK_9 = 8,
        GLFW_JOYSTICK_10 = 9,
        GLFW_JOYSTICK_11 = 10,
        GLFW_JOYSTICK_12 = 11,
        GLFW_JOYSTICK_13 = 12,
        GLFW_JOYSTICK_14 = 13,
        GLFW_JOYSTICK_15 = 14,
        GLFW_JOYSTICK_16 = 15,
        GLFW_JOYSTICK_LAST = GLFW_JOYSTICK_16
    }

    /// <summary>
    /// The diagonal directions are bitwise combinations of the primary (up, right, down and left) 
    /// directions and you can test for these individually by ANDing it with the corresponding direction.
    /// </summary>
    public enum JoystickHats: byte
    {
        GLFW_HAT_CENTERED = 0,
        GLFW_HAT_UP = 1,
        GLFW_HAT_RIGHT = 2,
        GLFW_HAT_DOWN = 4,
        GLFW_HAT_LEFT = 8,
        GLFW_HAT_RIGHT_UP = GLFW_HAT_RIGHT | GLFW_HAT_UP,
        GLFW_HAT_RIGHT_DOWN = GLFW_HAT_RIGHT | GLFW_HAT_DOWN,
        GLFW_HAT_LEFT_UP = GLFW_HAT_LEFT | GLFW_HAT_UP,
        GLFW_HAT_LEFT_DOWN = GLFW_HAT_LEFT | GLFW_HAT_DOWN
    }

    public enum GlfwError
    {
        /// <summary>
        /// No error has occurred.
        /// 
        /// Analysis: 
        /// Yay.
        /// </summary>
        GLFW_NO_ERROR =  0,
        /// <summary>
        /// This occurs if a GLFW function was called that must not be called unless the library is initialized.
        /// 
        /// Analysis:
        /// Application programmer error. Initialize GLFW before calling any function that requires initialization.
        /// </summary>
        GLFW_NOT_INITIALIZED = 0x00010001,
        /// <summary>
        /// This occurs if a GLFW function was called that needs and operates on the current OpenGL or OpenGL ES 
        /// context but no context is current on the calling thread. One such function is glfwSwapInterval.
        /// 
        /// Analysis:
        /// Application programmer error. Ensure a context is current before calling functions that require a current context.
        /// </summary>
        GLFW_NO_CURRENT_CONTEXT = 0x00010002,
        /// <summary>
        /// One of the arguments to the function was an invalid enum value, for example requesting 
        /// GLFW_RED_BITS with glfwGetWindowAttrib.
        /// 
        /// Analysis: 
        /// Application programmer error. Fix the offending call.
        /// </summary>
        GLFW_INVALID_ENUM =  0x00010003,
        /// <summary>
        /// One of the arguments to the function was an invalid value, for example requesting a non-existent 
        /// OpenGL or OpenGL ES version like 2.7.
        /// 
        /// Requesting a valid but unavailable OpenGL or OpenGL ES version will instead result in a 
        /// GLFW_VERSION_UNAVAILABLE error.
        /// 
        /// Analysis: 
        /// Application programmer error. Fix the offending call.
        /// </summary>
        GLFW_INVALID_VALUE = 0x00010004,
        /// <summary>
        /// A memory allocation failed.
        /// 
        /// Analysis
        /// A bug in GLFW or the underlying operating system. Report the bug to our issue tracker.
        /// </summary>
        GLFW_OUT_OF_MEMORY =  0x00010005,
        /// <summary>
        /// GLFW could not find support for the requested API on the system.
        /// 
        /// Analysis
        /// The installed graphics driver does not support the requested API, or does not support it via the 
        /// chosen context creation backend.Below are a few examples.
        /// Some pre-installed Windows graphics drivers do not support OpenGL. AMD only supports OpenGL ES via EGL, 
        /// while Nvidia and Intel only support it via a WGL or GLX extension. 
        /// macOS does not provide OpenGL ES at all. The Mesa EGL, OpenGL and OpenGL ES libraries do not interface 
        /// with the Nvidia binary driver.
        /// Older graphics drivers do not support Vulkan.
        /// </summary>
        GLFW_API_UNAVAILABLE =  0x00010006,
        /// <summary>
        /// The requested OpenGL or OpenGL ES version (including any requested context or framebuffer hints) 
        /// is not available on this machine.
        /// 
        /// Analysis
        /// The machine does not support your requirements. If your application is sufficiently flexible, 
        /// downgrade your requirements and try again. Otherwise, inform the user that their machine does not match 
        /// your requirements.
        /// Future invalid OpenGL and OpenGL ES versions, for example OpenGL 4.8 if 5.0 comes out before the 4.x 
        /// series gets that far, also fail with this error and not GLFW_INVALID_VALUE, because GLFW cannot know what 
        /// future versions will exist.
        /// </summary>
        GLFW_VERSION_UNAVAILABLE =  0x00010007,
        /// <summary>
        /// A platform-specific error occurred that does not match any of the more specific categories.
        /// 
        /// Analysis
        /// A bug or configuration error in GLFW, the underlying operating system or its drivers, 
        /// or a lack of required resources. Report the issue to our issue tracker.
        /// </summary>
        GLFW_PLATFORM_ERROR =  0x00010008,
        /// <summary>
        /// If emitted during window creation, the requested pixel format is not supported.
        /// 
        /// If emitted when querying the clipboard, the contents of the clipboard could not be converted to the 
        /// requested format.
        /// 
        /// Analysis
        /// If emitted during window creation, one or more hard constraints did not match any of the 
        /// available pixel formats. If your application is sufficiently flexible, downgrade your requirements 
        /// and try again. Otherwise, inform the user that their machine does not match your requirements.
        /// If emitted when querying the clipboard, ignore the error or report it to the user, as appropriate.
        /// </summary>
        GLFW_FORMAT_UNAVAILABLE = 0x00010009,
        /// <summary>
        /// A window that does not have an OpenGL or OpenGL ES context was passed to a function that requires 
        /// it to have one.
        /// 
        /// Analysis
        /// Application programmer error. Fix the offending call.
        /// </summary>
        GLFW_NO_WINDOW_CONTEXT = 0x0001000A,
    }
}
