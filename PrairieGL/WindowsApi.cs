using System.Runtime.InteropServices;

namespace PrairieGL
{
    /// <summary>
    /// P/Invoke Handlers to the Windows API. 
    /// Used internally as helpers.
    /// </summary>
    internal class WindowsApi
    {
        /// <summary>
        /// Specifies how the DC is created.
        /// <see cref="GetDCEx"/>
        /// </summary>
        public enum DeviceContextValues
        {
            /// <summary>
            /// Returns a DC that corresponds to the window rectangle rather than the 
            /// client rectangle.
            /// </summary>
            DCX_WINDOW = 1,
            /// <summary>
            /// Returns a DC from the cache, rather than the OWNDC or CLASSDC window. 
            /// Essentially overrides CS_OWNDC and CS_CLASSDC.
            /// </summary>
            DCX_CACHE = 2,
            /// <summary>
            /// Uses the visible region of the parent window. 
            /// The parent's WS_CLIPCHILDREN and CS_PARENTDC style bits are ignored. 
            /// The origin is set to the upper-left corner of the window identified by hWnd.
            /// </summary>
            DCX_PARENTCLIP = 32,
            /// <summary>
            /// Excludes the visible regions of all sibling windows above 
            /// the window identified by hWnd.
            /// </summary>
            DCX_CLIPSIBLINGS = 16,
            /// <summary>
            /// Excludes the visible regions of all child windows 
            /// below the window identified by hWnd.
            /// </summary>
            DCX_CLIPCHILDREN = 8,
            /// <summary>
            /// This flag is ignored.
            /// </summary>
            DCX_NORESETATTRS = 4,
            /// <summary>
            /// Allows drawing even if there is a LockWindowUpdate call in
            /// effect that would otherwise exclude this window. 
            /// Used for drawing during tracking.
            /// </summary>
            DCX_LOCKWINDOWUPDATE = 0x400,
            /// <summary>
            /// The clipping region identified by hrgnClip is 
            /// excluded from the visible region of the returned DC.
            /// </summary>
            DCX_EXCLUDERGN = 64,
            /// <summary>
            /// The clipping region identified by hrgnClip is 
            /// with the visible region of the returned DC.
            /// </summary>
            DCX_INTERSECTRGN = 128,
            /// <summary>
            /// Reserved; do not use.
            /// </summary>
            DCX_VALIDATE = 0x200000,
        }

        //https://learn.microsoft.com/en-us/windows/win32/debug/system-error-codes--0-499-

        /// <summary>
        /// Retrieves the calling thread's last-error code value. 
        /// The last-error code is maintained on a per-thread basis. 
        /// Multiple threads do not overwrite each other's last-error code.
        /// </summary>
        /// <see href="https://learn.microsoft.com/en-us/windows/win32/api/errhandlingapi/nf-errhandlingapi-getlasterror"/>
        /// <returns>
        /// The return value is the calling thread's last-error code.
        /// 
        /// The Return Value section of the documentation for each function 
        /// that sets the last-error code notes the conditions under which the 
        /// function sets the last-error code.
        /// Most functions that set the thread's last-error code set it when 
        /// they fail. However, some functions also set the last-error code 
        /// when they succeed. If the function is not documented to set the 
        /// last-error code, the value returned by this function is simply 
        /// the most recent last-error code to have been set; some functions 
        /// set the last-error code to 0 on success and others do not.
        /// </returns>

        [DllImport("Kernel32.dll", EntryPoint = "GetLastError", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int GetLastError();

        /// <summary>
        /// The GetDCEx function retrieves a handle to a device context (DC) 
        /// for the client area of a specified window or for the entire screen. 
        /// You can use the returned handle in subsequent GDI functions to 
        /// draw in the DC. The device context is an opaque data structure, 
        /// whose values are used internally by GDI.
        /// 
        /// This function is an extension to the GetDC function, which gives 
        /// an application more control over how and whether clipping occurs 
        /// in the client area.
        /// </summary>
        /// <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getdcex"/>
        /// <param name="hWnd">
        /// A handle to the window whose DC is to be retrieved. 
        /// If this value is NULL, GetDCEx retrieves the DC for the entire screen.
        /// </param>
        /// <param name="hrgnClip">
        /// A clipping region that may be combined with the visible region of 
        /// the DC. If the value of flags is DCX_INTERSECTRGN or DCX_EXCLUDERGN, 
        /// then the operating system assumes ownership of the region and will 
        /// automatically delete it when it is no longer needed. 
        /// In this case, the application should not use or delete the region 
        /// after a successful call to GetDCEx.
        /// </param>
        /// <param name="flags">Specifies how the DC is created.</param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to the 
        /// DC for the specified window.
        /// 
        /// If the function fails, the return value is NULL.
        /// An invalid value for the hWnd parameter will cause the function 
        /// to fail.
        /// </returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetDCEx(IntPtr hWnd, IntPtr hrgnClip, DeviceContextValues flags);

        /// <summary>
        /// The GetDC function retrieves a handle to a device context (DC) 
        /// for the client area of a specified window or for the entire screen. 
        /// You can use the returned handle in subsequent GDI functions to draw 
        /// in the DC. The device context is an opaque data structure, whose 
        /// values are used internally by GDI.
        /// 
        /// The GetDCEx function is an extension to GetDC, which gives an 
        /// application more control over how and whether clipping occurs in 
        /// the client area.
        /// </summary>
        /// <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getdc?redirectedfrom=MSDN"/>
        /// <param name="hWnd">
        /// A handle to the window whose DC is to be retrieved. 
        /// If this value is NULL, GetDC retrieves the DC for the entire screen.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the 
        /// DC for the specified window's client area.
        /// 
        /// If the function fails, the return value is NULL.
        /// </returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hWnd);

        /// <summary>
        /// The ReleaseDC function releases a device context (DC), 
        /// freeing it for use by other applications. 
        /// The effect of the ReleaseDC function depends on the type of DC. 
        /// It frees only common and window DCs. 
        /// It has no effect on class or private DCs.
        /// </summary>
        /// <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-releasedc"/>
        /// <param name="hWnd">A handle to the window whose DC is to be released.</param>
        /// <param name="hDC">A handle to the DC to be released.</param>
        /// <returns>
        /// The return value indicates whether the DC was released. 
        /// If the DC was released, the return value is 1.
        /// 
        /// If the DC was not released, the return value is zero.
        /// </returns>
        [DllImport("user32.dll")]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        /// <summary>
        /// Retrieves the address of an exported function 
        /// (also known as a procedure) or variable from the specified 
        /// dynamic-link library (DLL).
        /// </summary>
        /// <see href="https://learn.microsoft.com/en-us/windows/win32/api/libloaderapi/nf-libloaderapi-getprocaddress"/>
        /// <param name="hModule">
        /// A handle to the DLL module that contains the function or variable. 
        /// GetModuleHandle function returns this handle.
        /// </param>
        /// <param name="procName">
        /// The function or variable name, or the function's 
        /// ordinal value. If this parameter is an ordinal value, it must be in the 
        /// low-order word; the high-order word must be zero.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the address of the 
        /// exported function or variable.
        /// 
        /// If the function fails, the return value is NULL.To get extended 
        /// error information, call GetLastError.
        /// </returns>
        [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        /// <summary>
        /// Retrieves a module handle for the specified module. 
        /// The module must have been loaded by the calling process.
        /// </summary>
        /// <see href="https://learn.microsoft.com/en-us/windows/win32/api/libloaderapi/nf-libloaderapi-getmodulehandlea"/>
        /// <param name="module">
        /// The name of the loaded module (either a .dll or .exe file). 
        /// If the file name extension is omitted, the default library extension .dll 
        /// is appended. The file name string can include a trailing point character (.) 
        /// to indicate that the module name has no extension. 
        /// The string does not have to specify a path. When specifying a path, 
        /// be sure to use backslashes (\), not forward slashes (/). 
        /// The name is compared (case independently) to the names of modules currently
        /// mapped into the address space of the calling process.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the specified module.
        /// If the function fails, the return value is NULL.To get extended error information, call GetLastError.
        /// </returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetModuleHandle(string module);

        /// <summary>   
        /// Retrieves the address of an exported function (also known as a procedure) or variable from the specified dynamic-link library (DLL).
        /// </summary>
        /// <see href="https://learn.microsoft.com/en-us/windows/win32/api/libloaderapi/nf-libloaderapi-getprocaddress"/>
        /// <param name="dllname">
        /// The name of the loaded module (either a .dll or .exe file). 
        /// If the file name extension is omitted, the default library extension .dll 
        /// is appended. The file name string can include a trailing point character (.) 
        /// to indicate that the module name has no extension. 
        /// The string does not have to specify a path. When specifying a path, 
        /// be sure to use backslashes (\), not forward slashes (/). 
        /// The name is compared (case independently) to the names of modules currently
        /// mapped into the address space of the calling process.
        /// </param>
        /// <param name="procName">
        /// The function or variable name, or the function's 
        /// ordinal value. If this parameter is an ordinal value, it must be in the 
        /// low-order word; the high-order word must be zero.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the address of the 
        /// exported function or variable.
        /// If the function fails, the return value is NULL.
        /// To get extended error information, call GetLastError.
        /// </returns>
        public static IntPtr GetProcAddress(string dllname, string procName)
        {
            IntPtr module = GetModuleHandle(dllname);
            return GetProcAddress(module, procName);
        }

        /// <summary>
        /// Copies a block of memory from one location to another.
        /// 
        /// The first parameter, Destination, must be large enough to hold Length bytes of Source;
        /// otherwise, a buffer overrun may occur. This may lead to a denial of service 
        /// attack against the application if an access violation occurs or, in the worst case, 
        /// allow an attacker to inject executable code into your process. 
        /// This is especially true if Destination is a stack-based buffer.
        /// Be aware that the last parameter, Length, is the number of bytes to copy into 
        /// Destination, not the size of the Destination.
        /// </summary>
        /// <see href="https://learn.microsoft.com/en-us/previous-versions/windows/desktop/legacy/aa366535(v=vs.85)"/>
        /// <param name="dest">A pointer to the starting address of the copied block's destination.</param>
        /// <param name="src">A pointer to the starting address of the block of memory to copy.</param>
        /// <param name="count">The size of the block of memory to copy, in bytes.</param>
        [DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
        public static extern void CopyMemory(IntPtr dest, IntPtr src, UIntPtr count);



    }
}
