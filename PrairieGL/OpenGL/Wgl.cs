using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static ICSharpCode.SharpZipLib.Zip.ExtendedUnixData;

namespace PrairieGL.OpenGL
{
    /// <summary>
    /// Windows specific OpenGL calls
    /// </summary>
    public class Wgl
    {
        /// <summary>
        /// The wglGetProcAddress function returns the address of an OpenGL extension function 
        /// for use with the current OpenGL rendering context.
        /// </summary>
        /// <param name="lpszProc">
        /// Points to a null-terminated string that is the name of the extension function. 
        /// The name of the extension function must be identical to a corresponding function implemented by OpenGL.
        /// </param>
        /// <returns>
        /// When the function succeeds, the return value is the address of the extension function.
        /// 
        /// When no current rendering context exists or the function fails, the return value is NULL.
        /// To get extended error information, call GetLastError.
        /// </returns>
        [DllImport("opengl32.dll", EntryPoint = "wglGetProcAddress", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr GetProcAddress(string lpszProc);

        /// <summary>
        /// The wglCreateContext function creates a new OpenGL rendering context, which is suitable for drawing on the device referenced by hdc. 
        /// The rendering context has the same pixel format as the device context.
        /// </summary>
        /// <param name="windowDrawingContext">Handle to a device context for which the function creates a suitable OpenGL rendering context.</param>
        /// <returns>
        /// If the function succeeds, the return value is a valid handle to an OpenGL rendering context.
        /// 
        /// If the function fails, the return value is NULL.
        /// To get extended error information, call GetLastError.
        /// </returns>
        [DllImport("opengl32.dll", EntryPoint = "wglCreateContext", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr CreateContext(IntPtr windowDrawingContext);

        /// <summary>
        /// The wglDeleteContext function deletes a specified OpenGL rendering context.
        /// </summary>
        /// <remarks>
        /// It is an error to delete an OpenGL rendering context that is the current context 
        /// of another thread. However, if a rendering context is the calling thread's current 
        /// context, the wglDeleteContext function changes the rendering context to being not 
        /// current before deleting it.
        /// 
        /// The wglDeleteContext function does not delete the device context associated with 
        /// the OpenGL rendering context when you call the wglMakeCurrent function.
        /// After calling wglDeleteContext, you must call DeleteDC to delete the associated 
        /// device context.
        /// </remarks>
        /// <param name="glRenderingContext">Handle to an OpenGL rendering context that the function will delete.</param>
        /// <returns></returns>
        [DllImport("opengl32.dll", EntryPoint = "wglDeleteContext", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern bool DeleteContext(IntPtr glRenderingContext);
        //{
        //    IntPtr ptr = Wgl.GetProcAddress("wglDeleteContext");
        //    WGLDelegates.wglDeleteContext dlg =
        //    Marshal.GetDelegateForFunctionPointer<WGLDelegates.wglDeleteContext>(ptr);
        //    return dlg(glRenderingContext);
        //}

        /// <summary>
        /// The wglMakeCurrent function makes a specified OpenGL rendering context the 
        /// calling thread's current rendering context. All subsequent OpenGL calls made 
        /// by the thread are drawn on the device identified by hdc. You can also use 
        /// wglMakeCurrent to change the calling thread's current rendering context so it's 
        /// no longer current.
        /// </summary>
        /// <param name="deviceContext">
        /// Handle to a device context. 
        /// Subsequent OpenGL calls made by the calling thread are drawn on the device identified by hdc.
        /// </param>
        /// <param name="openglRenderingContext">
        /// Handle to an OpenGL rendering context that the function 
        /// sets as the calling thread's rendering context.
        /// 
        /// If hglrc is NULL, the function makes the calling thread's current 
        /// rendering context no longer current, and releases the device context that 
        /// is used by the rendering context. In this case, hdc is ignored.
        /// </param>
        /// <returns>
        /// When the wglMakeCurrent function succeeds, the return value is TRUE; 
        /// otherwise the return value is FALSE. To get extended error information, 
        /// call GetLastError.
        /// </returns>
        [DllImport("opengl32.dll", EntryPoint = "wglMakeCurrent", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern bool MakeCurrent(IntPtr deviceContext, IntPtr openglRenderingContext);
        //{
        //    IntPtr ptr = Wgl.GetProcAddress("wglMakeCurrent");
        //    WGLDelegates.wglMakeCurrent dlg =
        //    Marshal.GetDelegateForFunctionPointer<WGLDelegates.wglMakeCurrent>(ptr);
        //    return dlg(deviceContext, openglRenderingContext);
        //}

        /// <summary>
        /// The wglShareLists function enables multiple OpenGL rendering 
        /// contexts to share a single display-list space.
        /// </summary>
        /// <param name="mainRenderContext">Specifies the OpenGL rendering context with which to share display lists.</param>
        /// <param name="secondRenderContext">
        /// Specifies the OpenGL rendering context to share display lists with hglrc1. 
        /// The hglrc2 parameter should not contain any existing display lists when wglShareLists is called.</param>
        /// <returns>When the function succeeds, the return value is TRUE.
        /// 
        /// When the function fails, the return value is FALSE and the display lists are not shared.
        /// To get extended error information, call GetLastError.
        /// </returns>
        [DllImport("opengl32.dll", EntryPoint = "wglShareLists", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern bool ShareLists(IntPtr mainRenderContext, IntPtr secondRenderContext);
        //{
        //    IntPtr ptr = Wgl.GetProcAddress("wglShareLists");
        //    WGLDelegates.wglShareLists dlg =
        //    Marshal.GetDelegateForFunctionPointer<WGLDelegates.wglShareLists>(ptr);
        //    return dlg(mainRenderContext, secondRenderContext);
        //}

        /// <summary>
        /// The wglGetCurrentContext function obtains a handle to the current 
        /// OpenGL rendering context of the calling thread.
        /// </summary>
        /// <returns>
        /// If the calling thread has a current OpenGL rendering context, 
        /// wglGetCurrentContext returns a handle to that rendering context. 
        /// Otherwise, the return value is NULL.
        /// </returns>
        [DllImport("opengl32.dll", EntryPoint = "wglGetCurrentContext", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr GetCurrentContext();

    }
}
