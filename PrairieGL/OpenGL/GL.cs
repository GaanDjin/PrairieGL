using PrairieGL.Utils;
using System.Numerics;
using System.Runtime.InteropServices;
using static PrairieGL.OpenGL.GLDelegates;
using static PrairieGL.OpenGL.GLFunctionPointers;

namespace PrairieGL.OpenGL
{
    /// <summary>
    /// The main OpenGL class that handles all calls to OpenGL.
    /// 
    /// For more details on calls see <see href="https://registry.khronos.org/OpenGL-Refpages/gl4/"/>
    /// 
    /// Some functions call OpenGL functions via P/Invoke DllImport and 
    /// others are called via delegates pointing to memory addresses.
    /// We can't use only one or the other for all calls as Windows only works
    /// for some functions (Anything with a spec version beyond 1.0 core) 
    /// and only some are availiable via dll imports.
    /// </summary>
    public class GL
    {
        ///TODO: Test Wgl.GetProcAddress for entry point, and then fallback to DLLImport call.

        // This is a hack. DLLImport and call tells NVIDIA we want to render OpenGL using the better nvidia card if it exists. 
        [DllImport("opencl.dll", EntryPoint = "clGetPlatformIDs", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        static extern int GetPlatformIDs(int num_entries, [In, Out] IntPtr[] platforms, out int num_platforms);

        static readonly int platformids = GetPlatformIDs(0, null, out int num_platforms);

        #region DLLImports


        /// <summary>
        /// Specify clear values for the color buffers.
        /// 
        /// glClearColor specifies the red, green, blue, and alpha values used by glClear to clear the color buffers. 
        /// Values specified by glClearColor are clamped to the range [0,1].
        /// </summary>
        /// <param name="red">Specify the red value used when the color buffers are cleared. The initial value is 0.</param>
        /// <param name="green">Specify the green value used when the color buffers are cleared. The initial value is 0.</param>
        /// <param name="blue">Specify the blue value used when the color buffers are cleared. The initial value is 0.</param>
        /// <param name="alpha">Specify the alpha value used when the color buffers are cleared. The initial value is 0.</param>
        [DllImport("opengl32.dll", EntryPoint = "glClearColor", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void ClearColor(float red, float green, float blue, float alpha);
        //{
        //    IntPtr prt = Wgl.GetProcAddress("glClearColor");

        //    glClearColorDlg(red, green, blue, alpha);
        //}

        /// <summary>
        /// Clear buffers to preset values
        /// </summary>
        /// <param name="mask">Bitwise OR of masks that indicate the buffers to be cleared. 
        /// The three masks are GL_COLOR_BUFFER_BIT, GL_DEPTH_BUFFER_BIT, and GL_STENCIL_BUFFER_BIT.</param>
        [DllImport("opengl32.dll", EntryPoint = "glClear", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void Clear(GLColourMasks mask);
        //{
        //    glClearDlg(mask);
        //}

        /// <summary>
        /// Render primitives from array data
        /// </summary>
        /// <remarks>
        /// specifies multiple geometric primitives with very few subroutine calls. Instead of calling a GL procedure 
        /// to pass each individual vertex, normal, texture coordinate, edge flag, or color, you can prespecify 
        /// separate arrays of vertices, normals, and colors and use them to construct a sequence of primitives 
        /// with a single call to glDrawArrays.
        /// 
        /// When glDrawArrays is called, it uses count sequential elements from each enabled array to construct a 
        /// sequence of geometric primitives, beginning with element first.mode specifies what kind of primitives are 
        /// constructed and how the array elements construct those primitives.
        /// 
        /// Vertex attributes that are modified by glDrawArrays have an unspecified value after glDrawArrays returns.
        /// Attributes that aren't modified remain well defined.
        /// 
        /// 
        /// Notes
        /// GL_LINE_STRIP_ADJACENCY, GL_LINES_ADJACENCY, GL_TRIANGLE_STRIP_ADJACENCY and GL_TRIANGLES_ADJACENCY are 
        /// available only if the GL version is 3.2 or greater.
        /// 
        /// 
        /// Errors
        /// GL_INVALID_ENUM is generated if mode is not an accepted value.
        /// 
        /// 
        /// GL_INVALID_VALUE is generated if count is negative.
        /// 
        /// GL_INVALID_OPERATION is generated if a non-zero buffer object name is bound to an enabled array and the 
        /// buffer object's data store is currently mapped.
        /// 
        /// 
        /// GL_INVALID_OPERATION is generated if a geometry shader is active and mode is incompatible with the 
        /// input primitive type of the geometry shader in the currently installed program object.
        /// </remarks>
        /// <param name="mode">Specifies what kind of primitives to render. </param>
        /// <param name="first">Specifies the starting index in the enabled arrays.</param>
        /// <param name="count">Specifies the number of indices to be rendered.</param>
        [DllImport("opengl32.dll", EntryPoint = "glDrawArrays", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void DrawArrays(RenderModes mode, int first, int count);
        //{
        //    glDrawArraysDlg(mode, first, count);
        //}

        /// <summary>
        /// Enables server-side GL capabilities
        /// 
        /// Use glIsEnabled or glGet to determine the current setting of any capability. 
        /// The initial value for each capability with the exception of GL_DITHER and GL_MULTISAMPLE is GL_FALSE.
        /// The initial value for GL_DITHER and GL_MULTISAMPLE is GL_TRUE.
        /// </summary>
        /// <param name="cap">Specifies a symbolic constant indicating a GL capability.</param>
        [DllImport("opengl32.dll", EntryPoint = "glEnable", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void Enable(GLCapabilities cap);
        //{
        //    glEnableDlg(cap);
        //}

        /// <summary>
        /// Disables server-side GL capabilities
        /// 
        /// Use glIsEnabled or glGet to determine the current setting of any capability. 
        /// The initial value for each capability with the exception of GL_DITHER and GL_MULTISAMPLE is GL_FALSE.
        /// The initial value for GL_DITHER and GL_MULTISAMPLE is GL_TRUE.
        /// </summary>
        /// <param name="cap">Specifies a symbolic constant indicating a GL capability.</param>
        [DllImport("opengl32.dll", EntryPoint = "glDisable", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void Disable(GLCapabilities cap);
        //{
        //    glDisableDlg(cap);
        //}


        /// <summary>
        /// glDepthFunc specifies the function used to compare each incoming pixel depth value with the depth
        /// value present in the depth buffer. The comparison is performed only if depth testing is enabled. 
        /// (See glEnable and glDisable of GL_DEPTH_TEST.)
        /// 
        /// func specifies the conditions under which the pixel will be drawn.
        /// </summary>
        /// <param name="func">Specifies the depth comparison function.</param>
        [DllImport("opengl32.dll", EntryPoint = "glDepthFunc", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void DepthFunc(GLComparisonFunctions func);
        //{
        //    glDepthFuncDlg(func);
        //}

        /// <summary>
        /// Bind a named texture to a texturing target
        /// </summary>
        /// <param name="target">Specifies the target to which the texture is bound.</param>
        /// <param name="texture">Specifies the name of a texture.</param>
        [DllImport("opengl32.dll", EntryPoint = "glBindTexture", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void BindTexture(TextureTargets target, uint texture);
        //{
        //    glBindTextureDlg(target, texture);
        //}

        /// <summary>
        /// Delete named textures
        /// </summary>
        /// <param name="n">Specifies the number of textures to be deleted.</param>
        /// <param name="textures">Specifies an array of textures to be deleted.</param>
        [DllImport("opengl32.dll", EntryPoint = "glDeleteTextures", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void DeleteTextures(int n, uint[] textures);
        //{
        //    glDeleteTexturesDlg(n, textures);
        //}

        /// <summary>
        /// Delete named textures
        /// </summary>
        /// <param name="n">Specifies the number of textures to be deleted.</param>
        /// <param name="textures">Specifies an array of textures to be deleted.</param>
        public static void DeleteTexture(uint texture)
        {
            DeleteTextures(1, new uint[] { texture });
        }

        /// <summary>
        /// Generate texture names.
        /// 
        /// glGenTextures returns n texture names in textures. There is no guarantee that the names form a 
        /// contiguous set of integers; however, it is guaranteed that none of the returned names was in use 
        /// immediately before the call to glGenTextures.
        /// 
        /// The generated textures have no dimensionality; they assume the dimensionality of the texture target to 
        /// which they are first bound(see glBindTexture).
        /// 
        /// Texture names returned by a call to glGenTextures are not returned by subsequent calls, unless they are 
        /// first deleted with glDeleteTextures.
        /// </summary>
        /// <param name="n">Specifies the number of texture names to be generated.</param>
        /// <param name="textures">Specifies an array in which the generated texture names are stored.</param>
        [DllImport("opengl32.dll", EntryPoint = "glGenTextures", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void GenTextures(int n, uint[] textures);
        //{
        //    glGenTexturesDlg(n, textures);
        //}

        /// <summary>
        /// Generate a texture.
        /// </summary>
        /// <returns></returns>
        public static uint GenTexture()
        {
            uint[] textures = new uint[1];
            GenTextures(1, textures);
            return textures[0];
        }

        /// <summary>
        /// Specify a two-dimensional texture image
        /// 
        /// https://registry.khronos.org/OpenGL-Refpages/gl4/
        /// </summary>
        /// <param name="target">Specifies the target texture.</param>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image. If target is GL_TEXTURE_RECTANGLE or GL_PROXY_TEXTURE_RECTANGLE, level must be 0.</param>
        /// <param name="internalformat">Specifies the number of color components in the texture. Must be one of base internal formats given in Table 1, one of the sized internal formats given in Table 2, or one of the compressed internal formats given in Table 3, below.</param>
        /// <param name="width">Specifies the width of the texture image. All implementations support texture images that are at least 1024 texels wide.</param>
        /// <param name="height">Specifies the height of the texture image, or the number of layers in a texture array, in the case of the GL_TEXTURE_1D_ARRAY and GL_PROXY_TEXTURE_1D_ARRAY targets. All implementations support 2D texture images that are at least 1024 texels high, and texture arrays that are at least 256 layers deep.</param>
        /// <param name="border">This value must be 0.</param>
        /// <param name="format">Specifies the format of the pixel data.</param>
        /// <param name="type">Specifies the data type of the pixel data.</param>
        /// <param name="data">Specifies a pointer to the image data in memory.</param>
        [DllImport("opengl32.dll", EntryPoint = "glTexImage2D", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void TexImage2D(TextureTargets target,
             int level,
             ImagePixelFormats internalformat,
             int width,
             int height,
             int border,
             ImagePixelFormats format,
             ImagePixelDataTypes type,
             IntPtr data);
        //{
        //    GLDelegates.glTexImage2D glTexImage2DDlg = Marshal.GetDelegateForFunctionPointer<GLDelegates.glTexImage2D>(Wgl.GetProcAddress("glTexImage2D"));

        //    glTexImage2DDlg(target, level, internalformat, width, height, border, format, type, data);
        //}

        /// <summary>
        /// Specify a two-dimensional texture image
        /// 
        /// https://registry.khronos.org/OpenGL-Refpages/gl4/
        /// </summary>
        /// <param name="target">Specifies the target texture.</param>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image. If target is GL_TEXTURE_RECTANGLE or GL_PROXY_TEXTURE_RECTANGLE, level must be 0.</param>
        /// <param name="internalformat">Specifies the number of color components in the texture. Must be one of base internal formats given in Table 1, one of the sized internal formats given in Table 2, or one of the compressed internal formats given in Table 3, below.</param>
        /// <param name="width">Specifies the width of the texture image. All implementations support texture images that are at least 1024 texels wide.</param>
        /// <param name="height">Specifies the height of the texture image, or the number of layers in a texture array, in the case of the GL_TEXTURE_1D_ARRAY and GL_PROXY_TEXTURE_1D_ARRAY targets. All implementations support 2D texture images that are at least 1024 texels high, and texture arrays that are at least 256 layers deep.</param>
        /// <param name="border">This value must be 0.</param>
        /// <param name="format">Specifies the format of the pixel data.</param>
        /// <param name="type">Specifies the data type of the pixel data.</param>
        /// <param name="data">Specifies a pointer to the image data in memory.</param>
        public static void TexImage2D<T>(TextureTargets target,
             int level,
             ImagePixelFormats internalformat,
             int width,
             int height,
             int border,
             ImagePixelFormats format,
             ImagePixelDataTypes type,
             T[] data) where T : unmanaged
        {
            if (data == null)
            {
                TexImage2D(target
                    , level
                    , internalformat
                    , width
                    , height
                    , border
                    , format
                    , type
                    , IntPtr.Zero);
            }
            else
            {
                //int sz = Marshal.SizeOf(typeof(T)) * data.Length; // Marshal.SizeOf(typeof(int[])) * data.Length;

                GCHandle GlobalDataPointer = GCHandle.Alloc(data, GCHandleType.Pinned); // Marshal.AllocHGlobal(sz);

                TexImage2D(target
                    , level
                    , internalformat
                    , width
                    , height
                    , border
                    , format
                    , type
                    , GlobalDataPointer.AddrOfPinnedObject());
                GlobalDataPointer.Free();
            }
        }

        /// <summary>
        /// Specify a two-dimensional texture image
        /// 
        /// https://registry.khronos.org/OpenGL-Refpages/gl4/
        /// </summary>
        /// <param name="target">Specifies the target texture.</param>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image. If target is GL_TEXTURE_RECTANGLE or GL_PROXY_TEXTURE_RECTANGLE, level must be 0.</param>
        /// <param name="internalformat">Specifies the number of color components in the texture. Must be one of base internal formats given in Table 1, one of the sized internal formats given in Table 2, or one of the compressed internal formats given in Table 3, below.</param>
        /// <param name="width">Specifies the width of the texture image. All implementations support texture images that are at least 1024 texels wide.</param>
        /// <param name="height">Specifies the height of the texture image, or the number of layers in a texture array, in the case of the GL_TEXTURE_1D_ARRAY and GL_PROXY_TEXTURE_1D_ARRAY targets. All implementations support 2D texture images that are at least 1024 texels high, and texture arrays that are at least 256 layers deep.</param>
        /// <param name="border">This value must be 0.</param>
        /// <param name="format">Specifies the format of the pixel data.</param>
        /// <param name="type">Specifies the data type of the pixel data.</param>
        /// <param name="data">Specifies a pointer to the image data in memory.</param>
        [DllImport("opengl32.dll", EntryPoint = "glTexImage2D", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void TexImage2D(TextureTargets target,
             int level,
             ImagePixelFormats internalformat,
             int width,
             int height,
             int border,
             ImagePixelFormats format,
             ImagePixelDataTypes type,
             float[] data);
        //{
        //    GLDelegates.glTexImage2D<float> glTexImage2DDlg = Marshal.GetDelegateForFunctionPointer<GLDelegates.glTexImage2D<float>>(Wgl.GetProcAddress("glTexImage2D"));

        //    glTexImage2DDlg(target,
        //      level,
        //     internalformat,
        //     width,
        //     height,
        //      border,
        //     format,
        //     type,
        //     data);
        //}

        /// <summary>
        /// Set texture parameters
        /// </summary>
        /// <param name="target">Specifies the target to which the texture is bound for glTexParameter functions.</param>
        /// <param name="pname">Specifies the symbolic name of a single-valued texture parameter.</param>
        /// <param name="param">For the scalar commands, specifies the value of pname.</param>
        [DllImport("opengl32.dll", EntryPoint = "glTexParameterf", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void TexParameterf(TextureTargets target, TextureParameters pname, float param);
        //{
        //    glTexParameterfDlg(target, pname, param);
        //}

        /// <summary>
        /// Set texture parameters
        /// </summary>
        /// <param name="target">Specifies the target to which the texture is bound for glTexParameter functions.</param>
        /// <param name="pname">Specifies the symbolic name of a single-valued texture parameter.</param>
        /// <param name="param">For the scalar commands, specifies the value of pname.</param>
        [DllImport("opengl32.dll", EntryPoint = "glTexParameteri", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void TexParameteri(TextureTargets target, TextureParameters pname, int param);
        //{
        //    glTexParameteriDlg(target, pname, param);
        //}


        /// <summary>
        /// Set texture parameters
        /// </summary>
        /// <param name="target">Specifies the target to which the texture is bound for glTexParameter functions.</param>
        /// <param name="pname">Specifies the symbolic name of a single-valued texture parameter.</param>
        /// <param name="parameters">For the vector commands, specifies a pointer to an array where the value or values of pname are stored.</param>
        [DllImport("opengl32.dll", EntryPoint = "glTexParameterfv", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void TexParameterfv(TextureTargets target, TextureParameters pname, float[] parameters);
        //{
        //    glTexParameterfvDlg(target, pname, parameters);
        //}

        /// <summary>
        /// Set texture parameters
        /// </summary>
        /// <param name="target">Specifies the target to which the texture is bound for glTexParameter functions.</param>
        /// <param name="pname">Specifies the symbolic name of a single-valued texture parameter.</param>
        /// <param name="parameters">For the vector commands, specifies a pointer to an array where the value or values of pname are stored.</param>
        [DllImport("opengl32.dll", EntryPoint = "glTexParameteriv", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void TexParameteriv(TextureTargets target, TextureParameters pname, int[] parameters);
        //{
        //    glTexParameterivDlg(target, pname, parameters);
        //}


        /// <summary>
        /// Set pixel storage modes.
        /// 
        /// glPixelStoref can be used to set any pixel store parameter. If the parameter type is boolean, then if param is 0, the parameter is false; otherwise it is set to true. If pname is an integer type parameter, param is rounded to the nearest integer.
        /// 
        /// Likewise, glPixelStorei can also be used to set any of the pixel store parameters.Boolean parameters are set to false if param is 0 and true otherwise.
        /// </summary>
        /// <param name="pname">Specifies the symbolic name of the parameter to be set.</param>
        /// <param name="param">Specifies the value that pname is set to.</param>
        [DllImport("opengl32.dll", EntryPoint = "glPixelStoref", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void PixelStoref(PixelPackingFormats pname, float param);
        //{
        //    glPixelStorefDlg(pname, param);
        //}

        /// <summary>
        /// Set pixel storage modes
        /// 
        /// glPixelStoref can be used to set any pixel store parameter. If the parameter type is boolean, then if param is 0, the parameter is false; otherwise it is set to true. If pname is an integer type parameter, param is rounded to the nearest integer.
        /// 
        /// Likewise, glPixelStorei can also be used to set any of the pixel store parameters.Boolean parameters are set to false if param is 0 and true otherwise.
        /// </summary>
        /// <param name="pname">Specifies the symbolic name of the parameter to be set.</param>
        /// <param name="param">Specifies the value that pname is set to.</param>
        [DllImport("opengl32.dll", EntryPoint = "glPixelStorei", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void PixelStorei(PixelPackingFormats pname, int param);
        //{
        //    glPixelStoreiDlg(pname, param);
        //}

        /// <summary>
        /// Render primitives from array data
        /// </summary>
        /// <param name="mode">Specifies what kind of primitives to render. </param>
        /// <param name="count">Specifies the number of elements to be rendered.</param>
        /// <param name="type">Specifies the type of the values in indices.</param>
        /// <param name="indices">Specifies a pointer to the location where the indices are stored.</param>
        [DllImport("opengl32.dll", EntryPoint = "glDrawElements", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void DrawElements(RenderModes mode, int count, DrawIndexTypes type, byte[] indices);
        //{
        //    glDrawElementsDlgByte(mode, count, type, indices);
        //}

        /// <summary>
        /// Render primitives from array data
        /// </summary>
        /// <param name="mode">Specifies what kind of primitives to render. </param>
        /// <param name="count">Specifies the number of elements to be rendered.</param>
        /// <param name="type">Specifies the type of the values in indices.</param>
        /// <param name="indices">Specifies a pointer to the location where the indices are stored.</param>
        [DllImport("opengl32.dll", EntryPoint = "glDrawElements", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void DrawElements(RenderModes mode, int count, DrawIndexTypes type, ushort[] indices);
        //{
        //    glDrawElementsDlgUshort(mode, count, type, indices);
        //}

        /// <summary>
        /// Render primitives from array data
        /// </summary>
        /// <param name="mode">Specifies what kind of primitives to render. </param>
        /// <param name="count">Specifies the number of elements to be rendered.</param>
        /// <param name="type">Specifies the type of the values in indices.</param>
        /// <param name="indices">Specifies a pointer to the location where the indices are stored.</param>
        [DllImport("opengl32.dll", EntryPoint = "glDrawElements", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void DrawElements(RenderModes mode, int count, DrawIndexTypes type, int[] indices);
        //{
        //    glDrawElementsDlgInt(mode, count, type, indices);
        //}

        /// <summary>
        /// Render primitives from array data
        /// </summary>
        /// <param name="mode">Specifies what kind of primitives to render. </param>
        /// <param name="count">Specifies the number of elements to be rendered.</param>
        /// <param name="type">Specifies the type of the values in indices.</param>
        /// <param name="indices">Specifies a pointer to the location where the indices are stored.</param>
        [DllImport("opengl32.dll", EntryPoint = "glDrawElements", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void DrawElements(RenderModes mode, int count, DrawIndexTypes type, IntPtr indices);
        //{
        //    glDrawElementsDlgIntPtr(mode, count, type, indices);
        //}

        /// <summary>
        /// Render primitives from array data.
        /// 
        /// glDrawElements specifies multiple geometric primitives with very few subroutine calls. 
        /// Instead of calling a GL function to pass each individual vertex, normal, texture coordinate, edge flag, or color, 
        /// you can prespecify separate arrays of vertices, normals, and so on, and use them to construct a sequence of 
        /// primitives with a single call to glDrawElements.
        /// 
        /// When glDrawElements is called, it uses count sequential elements from an enabled array, starting at indices to 
        /// construct a sequence of geometric primitives.
        /// 
        /// If more than one array is enabled, each is used.
        /// 
        /// </summary>
        /// <param name="mode">Specifies what kind of primitives to render. </param>
        /// <param name="count">Specifies the number of elements to be rendered.</param>
        /// <param name="type">Specifies the type of the values to draw.</param>
        public static void DrawElements(RenderModes mode, int count, DrawIndexTypes type)
        {
            DrawElements(mode, count, type, IntPtr.Zero);
        }

        /// <summary>
        /// Return error information.
        /// 
        /// glGetError returns the value of the error flag. Each detectable error is assigned a numeric code and 
        /// symbolic name. When an error occurs, the error flag is set to the appropriate error code value. 
        /// No other errors are recorded until glGetError is called, the error code is returned, and the flag is 
        /// reset to GL_NO_ERROR. If a call to glGetError returns GL_NO_ERROR, there has been no detectable error 
        /// since the last call to glGetError, or since the GL was initialized.
        /// 
        /// To allow for distributed implementations, there may be several error flags. If any single error flag 
        /// has recorded an error, the value of that flag is returned and that flag is reset to GL_NO_ERROR when 
        /// glGetError is called.If more than one flag has recorded an error, glGetError returns and clears an 
        /// arbitrary error flag value.Thus, glGetError should always be called in a loop, until it returns GL_NO_ERROR, 
        /// if all error flags are to be reset.
        /// 
        /// Initially, all error flags are set to GL_NO_ERROR.
        /// </summary>
        /// <returns></returns>
        [DllImport("opengl32.dll", EntryPoint = "glGetError", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern GLErrors GetError();
        //{
        //    return glGetErrorDlg();
        //}

        /// <summary>
        /// specify pixel arithmetic.
        /// Pixels can be drawn using a function that blends the incoming (source) RGBA values with the 
        /// RGBA values that are already in the frame buffer (the destination values). Blending is initially disabled. 
        /// Use glEnable and glDisable with argument GL_BLEND to enable and disable blending.
        /// 
        /// Defines the operation of blending for all draw buffers when it is enabled.
        /// </summary>
        /// <remarks>
        /// Examples
        /// Transparency is best implemented using blend function(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA) with 
        /// primitives sorted from farthest to nearest.Note that this transparency calculation does not require 
        /// the presence of alpha bitplanes in the frame buffer.
        /// 
        /// Blend function (GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA) is also useful for rendering antialiased points and 
        /// lines in arbitrary order.
        /// 
        /// 
        /// Polygon antialiasing is optimized using blend function(GL_SRC_ALPHA_SATURATE, GL_ONE) with polygons 
        /// sorted from nearest to farthest. (See the glEnable, glDisable reference page and the GL_POLYGON_SMOOTH 
        /// argument for information on polygon antialiasing.) Destination alpha bitplanes, which must be present 
        /// for this blend function to operate correctly, store the accumulated coverage.
        /// 
        /// 
        /// Notes
        /// Incoming(source) alpha would typically be used as a material opacity, ranging from 1.0 (KA), 
        /// representing complete opacity, to 0.0 (0), representing complete transparency.
        /// 
        /// When more than one color buffer is enabled for drawing, the GL performs blending separately for each 
        /// enabled buffer, using the contents of that buffer for destination color. (See glDrawBuffer.)
        /// 
        /// When dual source blending is enabled(i.e., one of the blend factors requiring the second color input is used), 
        /// the maximum number of enabled draw buffers is given by GL_MAX_DUAL_SOURCE_DRAW_BUFFERS, which may be lower 
        /// than GL_MAX_DRAW_BUFFERS.
        /// </remarks>
        /// <param name="sfactor">Specifies how the red, green, blue, and alpha source blending factors are computed. The initial value is GL_ONE.</param>
        /// <param name="dfactor">Specifies how the red, green, blue, and alpha destination blending factors are computed. </param>
        [DllImport("opengl32.dll", EntryPoint = "glBlendFunc", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void BlendFunc(BlendingFactor sfactor, BlendingFactor dfactor);
        //{
        //    glBlendFuncDlg(sfactor, dfactor);
        //}

        /// <summary>
        /// specify pixel arithmetic.
        /// Pixels can be drawn using a function that blends the incoming (source) RGBA values with the 
        /// RGBA values that are already in the frame buffer (the destination values). Blending is initially disabled. 
        /// Use glEnable and glDisable with argument GL_BLEND to enable and disable blending.
        /// 
        /// Defines the operation of blending for a single draw buffer specified by buf when enabled for that draw buffer.
        /// </summary>
        /// <remarks>
        /// Examples
        /// Transparency is best implemented using blend function(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA) with 
        /// primitives sorted from farthest to nearest.Note that this transparency calculation does not require 
        /// the presence of alpha bitplanes in the frame buffer.
        /// 
        /// Blend function (GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA) is also useful for rendering antialiased points and 
        /// lines in arbitrary order.
        /// 
        /// 
        /// Polygon antialiasing is optimized using blend function(GL_SRC_ALPHA_SATURATE, GL_ONE) with polygons 
        /// sorted from nearest to farthest. (See the glEnable, glDisable reference page and the GL_POLYGON_SMOOTH 
        /// argument for information on polygon antialiasing.) Destination alpha bitplanes, which must be present 
        /// for this blend function to operate correctly, store the accumulated coverage.
        /// 
        /// 
        /// Notes
        /// Incoming(source) alpha would typically be used as a material opacity, ranging from 1.0 (KA), 
        /// representing complete opacity, to 0.0 (0), representing complete transparency.
        /// 
        /// When more than one color buffer is enabled for drawing, the GL performs blending separately for each 
        /// enabled buffer, using the contents of that buffer for destination color. (See glDrawBuffer.)
        /// 
        /// When dual source blending is enabled(i.e., one of the blend factors requiring the second color input is used), 
        /// the maximum number of enabled draw buffers is given by GL_MAX_DUAL_SOURCE_DRAW_BUFFERS, which may be lower 
        /// than GL_MAX_DRAW_BUFFERS.
        /// </remarks>
        /// <param name="buf">Specifies the index of the draw buffer for which to set the blend function.</param>
        /// <param name="sfactor">Specifies how the red, green, blue, and alpha source blending factors are computed. The initial value is GL_ONE.</param>
        /// <param name="dfactor">Specifies how the red, green, blue, and alpha destination blending factors are computed. </param>
        [DllImport("opengl32.dll", EntryPoint = "glBlendFunci", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void BlendFunci(uint buf, BlendingFactor sfactor, BlendingFactor dfactor);
        //{
        //    glBlendFunciDlg(buf, sfactor, dfactor);
        //}

        /// <summary>
        /// Return the value or values of a selected parameter.
        /// 
        /// These commands return values for simple state variables in GL. 
        /// pname is a symbolic constant indicating the state variable to be 
        /// returned, and data is a pointer to an array of the indicated type 
        /// in which to place the returned data.
        /// 
        /// Type conversion is performed if data has a different type than 
        /// the state variable value being requested.If glGetBooleanv is called, 
        /// a floating-point (or integer) value is converted to GL_FALSE if 
        /// and only if it is 0.0 (or 0). Otherwise, it is converted to GL_TRUE.
        /// If glGetIntegerv is called, boolean values are returned as GL_TRUE 
        /// or GL_FALSE, and most floating-point values are rounded to the 
        /// nearest integer value.Floating-point colors and normals, however,
        /// are returned with a linear mapping that maps 1.0 to the most
        /// positive representable integer value and −1.0
        /// to the most negative representable integer value.If glGetFloatv or 
        /// glGetDoublev is called, boolean values are returned as GL_TRUE or 
        /// GL_FALSE, and integer values are converted to floating-point values.
        /// </summary>
        /// <param name="pname">Specifies the parameter value to be returned for indexed versions of glGet. </param>
        /// <param name="data">Returns the value or values of the specified parameter.</param>
        [DllImport("opengl32.dll", EntryPoint = "glGetBooleanv", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void GetBooleanv(GetValueParameters pname, out bool[] data);
        //{
        //    glGetBooleanvDlg(pname, out data);
        //}

        /// <summary>
        /// Return the value or values of a selected parameter.
        /// 
        /// These commands return values for simple state variables in GL. 
        /// pname is a symbolic constant indicating the state variable to be 
        /// returned, and data is a pointer to an array of the indicated type 
        /// in which to place the returned data.
        /// 
        /// Type conversion is performed if data has a different type than 
        /// the state variable value being requested.If glGetBooleanv is called, 
        /// a floating-point (or integer) value is converted to GL_FALSE if 
        /// and only if it is 0.0 (or 0). Otherwise, it is converted to GL_TRUE.
        /// If glGetIntegerv is called, boolean values are returned as GL_TRUE 
        /// or GL_FALSE, and most floating-point values are rounded to the 
        /// nearest integer value.Floating-point colors and normals, however,
        /// are returned with a linear mapping that maps 1.0 to the most
        /// positive representable integer value and −1.0
        /// to the most negative representable integer value.If glGetFloatv or 
        /// glGetDoublev is called, boolean values are returned as GL_TRUE or 
        /// GL_FALSE, and integer values are converted to floating-point values.
        /// </summary>
        /// <param name="pname">Specifies the parameter value to be returned for indexed versions of glGet. </param>
        /// <param name="data">Returns the value or values of the specified parameter.</param>
        [DllImport("opengl32.dll", EntryPoint = "glGetDoublev", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void GetDoublev(GetValueParameters pname, out double[] data);
        //{
        //    glGetDoublevDlg(pname, out data);
        //}

        /// <summary>
        /// Return the value or values of a selected parameter.
        /// 
        /// These commands return values for simple state variables in GL. 
        /// pname is a symbolic constant indicating the state variable to be 
        /// returned, and data is a pointer to an array of the indicated type 
        /// in which to place the returned data.
        /// 
        /// Type conversion is performed if data has a different type than 
        /// the state variable value being requested.If glGetBooleanv is called, 
        /// a floating-point (or integer) value is converted to GL_FALSE if 
        /// and only if it is 0.0 (or 0). Otherwise, it is converted to GL_TRUE.
        /// If glGetIntegerv is called, boolean values are returned as GL_TRUE 
        /// or GL_FALSE, and most floating-point values are rounded to the 
        /// nearest integer value.Floating-point colors and normals, however,
        /// are returned with a linear mapping that maps 1.0 to the most
        /// positive representable integer value and −1.0
        /// to the most negative representable integer value.If glGetFloatv or 
        /// glGetDoublev is called, boolean values are returned as GL_TRUE or 
        /// GL_FALSE, and integer values are converted to floating-point values.
        /// </summary>
        /// <param name="pname">Specifies the parameter value to be returned for indexed versions of glGet. </param>
        /// <param name="data">Returns the value or values of the specified parameter.</param>
        [DllImport("opengl32.dll", EntryPoint = "glGetFloatv", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void GetFloatv(GetValueParameters pname, out float[] data);
        //{
        //    glGetFloatvDlg(pname, out data);
        //}

        /// <summary>
        /// Return the value or values of a selected parameter.
        /// 
        /// These commands return values for simple state variables in GL. 
        /// pname is a symbolic constant indicating the state variable to be 
        /// returned, and data is a pointer to an array of the indicated type 
        /// in which to place the returned data.
        /// 
        /// Type conversion is performed if data has a different type than 
        /// the state variable value being requested.If glGetBooleanv is called, 
        /// a floating-point (or integer) value is converted to GL_FALSE if 
        /// and only if it is 0.0 (or 0). Otherwise, it is converted to GL_TRUE.
        /// If glGetIntegerv is called, boolean values are returned as GL_TRUE 
        /// or GL_FALSE, and most floating-point values are rounded to the 
        /// nearest integer value.Floating-point colors and normals, however,
        /// are returned with a linear mapping that maps 1.0 to the most
        /// positive representable integer value and −1.0
        /// to the most negative representable integer value.If glGetFloatv or 
        /// glGetDoublev is called, boolean values are returned as GL_TRUE or 
        /// GL_FALSE, and integer values are converted to floating-point values.
        /// </summary>
        /// <param name="pname">Specifies the parameter value to be returned for indexed versions of glGet. </param>
        /// <param name="data">Returns the value or values of the specified parameter.</param>
        [DllImport("opengl32.dll", EntryPoint = "glGetIntegerv", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void GetIntegerv(GetValueParameters pname, out int data);
        //{
        //    glGetIntegervDlg(pname, out data);
        //}

        /// <summary>
        /// Return the value or values of a selected parameter.
        /// 
        /// These commands return values for simple state variables in GL. 
        /// pname is a symbolic constant indicating the state variable to be 
        /// returned, and data is a pointer to an array of the indicated type 
        /// in which to place the returned data.
        /// 
        /// Type conversion is performed if data has a different type than 
        /// the state variable value being requested.If glGetBooleanv is called, 
        /// a floating-point (or integer) value is converted to GL_FALSE if 
        /// and only if it is 0.0 (or 0). Otherwise, it is converted to GL_TRUE.
        /// If glGetIntegerv is called, boolean values are returned as GL_TRUE 
        /// or GL_FALSE, and most floating-point values are rounded to the 
        /// nearest integer value.Floating-point colors and normals, however,
        /// are returned with a linear mapping that maps 1.0 to the most
        /// positive representable integer value and −1.0
        /// to the most negative representable integer value.If glGetFloatv or 
        /// glGetDoublev is called, boolean values are returned as GL_TRUE or 
        /// GL_FALSE, and integer values are converted to floating-point values.
        /// </summary>
        /// <param name="pname">Specifies the parameter value to be returned for indexed versions of glGet. </param>
        /// <param name="data">Returns the value or values of the specified parameter.</param>
        [DllImport("opengl32.dll", EntryPoint = "glGetInteger64v", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void GetInteger64v(GetValueParameters pname, out long[] data);
        //{
        //    glGetInteger64vDlg(pname, out data);
        //}

        /// <summary>
        /// Return the value or values of a selected parameter.
        /// 
        /// These commands return values for simple state variables in GL. 
        /// pname is a symbolic constant indicating the state variable to be 
        /// returned, and data is a pointer to an array of the indicated type 
        /// in which to place the returned data.
        /// 
        /// Type conversion is performed if data has a different type than 
        /// the state variable value being requested.If glGetBooleanv is called, 
        /// a floating-point (or integer) value is converted to GL_FALSE if 
        /// and only if it is 0.0 (or 0). Otherwise, it is converted to GL_TRUE.
        /// If glGetIntegerv is called, boolean values are returned as GL_TRUE 
        /// or GL_FALSE, and most floating-point values are rounded to the 
        /// nearest integer value.Floating-point colors and normals, however,
        /// are returned with a linear mapping that maps 1.0 to the most
        /// positive representable integer value and −1.0
        /// to the most negative representable integer value.If glGetFloatv or 
        /// glGetDoublev is called, boolean values are returned as GL_TRUE or 
        /// GL_FALSE, and integer values are converted to floating-point values.
        /// </summary>
        /// <param name="target">Specifies the parameter value to be returned for indexed versions of glGet. </param>
        /// <param name="index">Specifies the index of the particular element being queried.</param>
        /// <param name="data">Returns the value or values of the specified parameter.</param>
        [DllImport("opengl32.dll", EntryPoint = "glGetBooleani_v", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void GetBooleani_v(GetValueParameters target, int index, out bool[] data);
        //{
        //    glGetBooleani_vDlg(target, index, out data);
        //}

        /// <summary>
        /// Return the value or values of a selected parameter.
        /// 
        /// These commands return values for simple state variables in GL. 
        /// pname is a symbolic constant indicating the state variable to be 
        /// returned, and data is a pointer to an array of the indicated type 
        /// in which to place the returned data.
        /// 
        /// Type conversion is performed if data has a different type than 
        /// the state variable value being requested.If glGetBooleanv is called, 
        /// a floating-point (or integer) value is converted to GL_FALSE if 
        /// and only if it is 0.0 (or 0). Otherwise, it is converted to GL_TRUE.
        /// If glGetIntegerv is called, boolean values are returned as GL_TRUE 
        /// or GL_FALSE, and most floating-point values are rounded to the 
        /// nearest integer value.Floating-point colors and normals, however,
        /// are returned with a linear mapping that maps 1.0 to the most
        /// positive representable integer value and −1.0
        /// to the most negative representable integer value.If glGetFloatv or 
        /// glGetDoublev is called, boolean values are returned as GL_TRUE or 
        /// GL_FALSE, and integer values are converted to floating-point values.
        /// </summary>
        /// <param name="target">Specifies the parameter value to be returned for indexed versions of glGet. </param>
        /// <param name="index">Specifies the index of the particular element being queried.</param>
        /// <param name="data">Returns the value or values of the specified parameter.</param>
        [DllImport("opengl32.dll", EntryPoint = "glGetIntegeri_v", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void GetIntegeri_v(GetValueParameters target, int index, int[] data);
        //{
        //    glGetIntegeri_vDlg(target, index, data);
        //}

        /// <summary>
        /// Return the value or values of a selected parameter.
        /// 
        /// These commands return values for simple state variables in GL. 
        /// pname is a symbolic constant indicating the state variable to be 
        /// returned, and data is a pointer to an array of the indicated type 
        /// in which to place the returned data.
        /// 
        /// Type conversion is performed if data has a different type than 
        /// the state variable value being requested.If glGetBooleanv is called, 
        /// a floating-point (or integer) value is converted to GL_FALSE if 
        /// and only if it is 0.0 (or 0). Otherwise, it is converted to GL_TRUE.
        /// If glGetIntegerv is called, boolean values are returned as GL_TRUE 
        /// or GL_FALSE, and most floating-point values are rounded to the 
        /// nearest integer value.Floating-point colors and normals, however,
        /// are returned with a linear mapping that maps 1.0 to the most
        /// positive representable integer value and −1.0
        /// to the most negative representable integer value.If glGetFloatv or 
        /// glGetDoublev is called, boolean values are returned as GL_TRUE or 
        /// GL_FALSE, and integer values are converted to floating-point values.
        /// </summary>
        /// <param name="target">Specifies the parameter value to be returned for indexed versions of glGet. </param>
        /// <param name="index">Specifies the index of the particular element being queried.</param>
        /// <param name="data">Returns the value or values of the specified parameter.</param>
        [DllImport("opengl32.dll", EntryPoint = "glGetFloati_v", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void GetFloati_v(GetValueParameters target, int index, float[] data);
        //{
        //    glGetFloati_vDlg(target, index, data);
        //}

        /// <summary>
        /// Return the value or values of a selected parameter.
        /// 
        /// These commands return values for simple state variables in GL. 
        /// pname is a symbolic constant indicating the state variable to be 
        /// returned, and data is a pointer to an array of the indicated type 
        /// in which to place the returned data.
        /// 
        /// Type conversion is performed if data has a different type than 
        /// the state variable value being requested.If glGetBooleanv is called, 
        /// a floating-point (or integer) value is converted to GL_FALSE if 
        /// and only if it is 0.0 (or 0). Otherwise, it is converted to GL_TRUE.
        /// If glGetIntegerv is called, boolean values are returned as GL_TRUE 
        /// or GL_FALSE, and most floating-point values are rounded to the 
        /// nearest integer value.Floating-point colors and normals, however,
        /// are returned with a linear mapping that maps 1.0 to the most
        /// positive representable integer value and −1.0
        /// to the most negative representable integer value.If glGetFloatv or 
        /// glGetDoublev is called, boolean values are returned as GL_TRUE or 
        /// GL_FALSE, and integer values are converted to floating-point values.
        /// </summary>
        /// <param name="target">Specifies the parameter value to be returned for indexed versions of glGet. </param>
        /// <param name="index">Specifies the index of the particular element being queried.</param>
        /// <param name="data">Returns the value or values of the specified parameter.</param>
        [DllImport("opengl32.dll", EntryPoint = "glGetDoublei_v", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void GetDoublei_v(GetValueParameters target, int index, double[] data);
        //{
        //    glGetDoublei_vDlg(target, index, data);
        //}

        /// <summary>
        /// Return the value or values of a selected parameter.
        /// 
        /// These commands return values for simple state variables in GL. 
        /// pname is a symbolic constant indicating the state variable to be 
        /// returned, and data is a pointer to an array of the indicated type 
        /// in which to place the returned data.
        /// 
        /// Type conversion is performed if data has a different type than 
        /// the state variable value being requested.If glGetBooleanv is called, 
        /// a floating-point (or integer) value is converted to GL_FALSE if 
        /// and only if it is 0.0 (or 0). Otherwise, it is converted to GL_TRUE.
        /// If glGetIntegerv is called, boolean values are returned as GL_TRUE 
        /// or GL_FALSE, and most floating-point values are rounded to the 
        /// nearest integer value.Floating-point colors and normals, however,
        /// are returned with a linear mapping that maps 1.0 to the most
        /// positive representable integer value and −1.0
        /// to the most negative representable integer value.If glGetFloatv or 
        /// glGetDoublev is called, boolean values are returned as GL_TRUE or 
        /// GL_FALSE, and integer values are converted to floating-point values.
        /// </summary>
        /// <param name="target">Specifies the parameter value to be returned for indexed versions of glGet. </param>
        /// <param name="index">Specifies the index of the particular element being queried.</param>
        /// <param name="data">Returns the value or values of the specified parameter.</param>
        [DllImport("opengl32.dll", EntryPoint = "glGetInteger64i_v", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void GetInteger64i_v(GetValueParameters target, int index, long[] data);
        //{
        //    glGetInteger64i_vDlg(target, index, data);
        //}

        /// <summary>
        /// Return a string describing the current GL connection
        /// </summary>
        /// <param name="name">Specifies a symbolic constant</param>
        /// <returns>glGetString returns a pointer to a static string describing some aspect of the current GL connection.</returns>
        [DllImport("opengl32.dll", EntryPoint = "glGetString", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern IntPtr GetString(CurrentConnectionInfo name);
        //{
        //    return glGetStringDlg(name);
        //}


        /// <summary>
        /// Specify which matrix is the current matrix
        /// </summary>
        /// <param name="mode">Specifies which matrix stack is the target for subsequent matrix operations.</param>
        [DllImport("opengl32.dll", EntryPoint = "glMatrixMode", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void MatrixMode(MatrixModes mode);
        //{
        //    glMatrixModeDlg(mode);
        //}

        /// <summary>
        /// Replace the current matrix with the specified matrix
        /// </summary>
        /// <param name="m">Specifies 16 consecutive values, which are used as the elements of a 4 × 4 column-major matrix.</param>
        [DllImport("opengl32.dll", EntryPoint = "glLoadMatrixd", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void LoadMatrixd(double[] m);
        //{
        //    glLoadMatrixdDlg(m);
        //}

        /// <summary>
        /// Replace the current matrix with the specified matrix
        /// </summary>
        /// <param name="m">Specifies 16 consecutive values, which are used as the elements of a 4 × 4 column-major matrix.</param>
        [DllImport("opengl32.dll", EntryPoint = "glLoadMatrixf", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void LoadMatrixf(float[] m);
        //{
        //    glLoadMatrixfDlg(m);
        //}

        /// <summary>
        /// Replace the current matrix with the specified matrix
        /// </summary>
        /// <param name="mat">Specifies a 4 × 4 column-major matrix.</param>
        public static void LoadMatrixf(Matrix4x4 mat)
        {
            LoadMatrixf(new float[] {
                        mat.M11, mat.M12, mat.M13, mat.M14,
                        mat.M21, mat.M22, mat.M23, mat.M24,
                        mat.M31, mat.M32, mat.M33, mat.M34,
                        mat.M41, mat.M42, mat.M43, mat.M44
            });
        }

        /// <summary>
        /// Set the current color
        /// </summary>
        /// <param name="red">Specify new red value for the current color.</param>
        /// <param name="green">Specify new green value for the current color.</param>
        /// <param name="blue">Specify new blue value for the current color.</param>
        [DllImport("opengl32.dll", EntryPoint = "glColor3b", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void Color3b(byte red, byte green, byte blue);
        //{
        //    glColor3bDlg(red, green, blue);
        //}

        /// <summary>
        /// Set the current color
        /// </summary>
        /// <param name="red">Specify new red value for the current color.</param>
        /// <param name="green">Specify new green value for the current color.</param>
        /// <param name="blue">Specify new blue value for the current color.</param>
        [DllImport("opengl32.dll", EntryPoint = "glColor3s", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void Color3s(short red, short green, short blue);
        //{
        //    glColor3sDlg(red, green, blue);
        //}

        /// <summary>
        /// Set the current color
        /// </summary>
        /// <param name="red">Specify new red value for the current color.</param>
        /// <param name="green">Specify new green value for the current color.</param>
        /// <param name="blue">Specify new blue value for the current color.</param>
        [DllImport("opengl32.dll", EntryPoint = "glColor3i", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void Color3i(int red, int green, int blue);
        //{
        //    glColor3iDlg(red, green, blue);
        //}

        /// <summary>
        /// Set the current color
        /// </summary>
        /// <param name="red">Specify new red value for the current color.</param>
        /// <param name="green">Specify new green value for the current color.</param>
        /// <param name="blue">Specify new blue value for the current color.</param>
        [DllImport("opengl32.dll", EntryPoint = "glColor3f", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void Color3f(float red, float green, float blue);
        //{
        //    glColor3fDlg(red, green, blue);
        //}

        /// <summary>
        /// Set the current color
        /// </summary>
        /// <param name="red">Specify new red value for the current color.</param>
        /// <param name="green">Specify new green value for the current color.</param>
        /// <param name="blue">Specify new blue value for the current color.</param>
        [DllImport("opengl32.dll", EntryPoint = "glColor3d", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void Color3d(double red, double green, double blue);
        //{
        //    glColor3dDlg(red, green, blue);
        //}

        /// <summary>
        /// Set the current color
        /// </summary>
        /// <param name="red">Specify new red value for the current color.</param>
        /// <param name="green">Specify new green value for the current color.</param>
        /// <param name="blue">Specify new blue value for the current color.</param>
        [DllImport("opengl32.dll", EntryPoint = "glColor3ub", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void Color3ub(byte red, byte green, byte blue);
        //{
        //    glColor3ubDlg(red, green, blue);
        //}

        /// <summary>
        /// Set the current color
        /// </summary>
        /// <param name="red">Specify new red value for the current color.</param>
        /// <param name="green">Specify new green value for the current color.</param>
        /// <param name="blue">Specify new blue value for the current color.</param>
        [DllImport("opengl32.dll", EntryPoint = "glColor3us", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void Color3us(ushort red, ushort green, ushort blue);
        //{
        //    glColor3usDlg(red, green, blue);
        //}

        /// <summary>
        /// Set the current color
        /// </summary>
        /// <param name="red">Specify new red value for the current color.</param>
        /// <param name="green">Specify new green value for the current color.</param>
        /// <param name="blue">Specify new blue value for the current color.</param>
        [DllImport("opengl32.dll", EntryPoint = "glColor3ui", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void Color3ui(uint red, uint green, uint blue);
        //{
        //    glColor3uiDlg(red, green, blue);
        //}

        /// <summary>
        /// Set the current color
        /// </summary>
        /// <param name="red">Specify new red value for the current color.</param>
        /// <param name="green">Specify new green value for the current color.</param>
        /// <param name="blue">Specify new blue value for the current color.</param>
        /// <param name="alpha">Specifies a new alpha value for the current color.</param>
        [DllImport("opengl32.dll", EntryPoint = "glColor4b", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void Color4b(byte red, byte green, byte blue, byte alpha);
        //{
        //    glColor4bDlg(red, green, blue, alpha);
        //}

        /// <summary>
        /// Set the current color
        /// </summary>
        /// <param name="red">Specify new red value for the current color.</param>
        /// <param name="green">Specify new green value for the current color.</param>
        /// <param name="blue">Specify new blue value for the current color.</param>
        /// <param name="alpha">Specifies a new alpha value for the current color.</param>
        [DllImport("opengl32.dll", EntryPoint = "glColor4s", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void Color4s(short red, short green, short blue, short alpha);
        //{
        //    glColor4sDlg(red, green, blue, alpha);
        //}

        /// <summary>
        /// Set the current color
        /// </summary>
        /// <param name="red">Specify new red value for the current color.</param>
        /// <param name="green">Specify new green value for the current color.</param>
        /// <param name="blue">Specify new blue value for the current color.</param>
        /// <param name="alpha">Specifies a new alpha value for the current color.</param>
        [DllImport("opengl32.dll", EntryPoint = "glColor4i", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void Color4i(int red, int green, int blue, int alpha);
        //{
        //    glColor4iDlg(red, green, blue, alpha);
        //}

        /// <summary>
        /// Set the current color
        /// </summary>
        /// <param name="red">Specify new red value for the current color.</param>
        /// <param name="green">Specify new green value for the current color.</param>
        /// <param name="blue">Specify new blue value for the current color.</param>
        /// <param name="alpha">Specifies a new alpha value for the current color.</param>
        [DllImport("opengl32.dll", EntryPoint = "glColor4f", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void Color4f(float red, float green, float blue, float alpha);
        //{
        //    glColor4fDlg(red, green, blue, alpha);
        //}

        /// <summary>
        /// Set the current color
        /// </summary>
        /// <param name="red">Specify new red value for the current color.</param>
        /// <param name="green">Specify new green value for the current color.</param>
        /// <param name="blue">Specify new blue value for the current color.</param>
        /// <param name="alpha">Specifies a new alpha value for the current color.</param>
        [DllImport("opengl32.dll", EntryPoint = "glColor4d", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void Color4d(double red, double green, double blue, double alpha);
        //{
        //    glColor4dDlg(red, green, blue, alpha);
        //}

        /// <summary>
        /// Set the current color
        /// </summary>
        /// <param name="red">Specify new red value for the current color.</param>
        /// <param name="green">Specify new green value for the current color.</param>
        /// <param name="blue">Specify new blue value for the current color.</param>
        /// <param name="alpha">Specifies a new alpha value for the current color.</param>
        [DllImport("opengl32.dll", EntryPoint = "glColor4ub", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void Color4ub(byte red, byte green, byte blue, byte alpha);
        //{
        //    glColor4ubDlg(red, green, blue, alpha);
        //}

        /// <summary>
        /// Set the current color
        /// </summary>
        /// <param name="red">Specify new red value for the current color.</param>
        /// <param name="green">Specify new green value for the current color.</param>
        /// <param name="blue">Specify new blue value for the current color.</param>
        /// <param name="alpha">Specifies a new alpha value for the current color.</param>
        [DllImport("opengl32.dll", EntryPoint = "glColor4us", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void Color4us(ushort red, ushort green, ushort blue, ushort alpha);
        //{
        //    glColor4usDlg(red, green, blue, alpha);
        //}

        /// <summary>
        /// Set the current color
        /// </summary>
        /// <param name="red">Specify new red value for the current color.</param>
        /// <param name="green">Specify new green value for the current color.</param>
        /// <param name="blue">Specify new blue value for the current color.</param>
        /// <param name="alpha">Specifies a new alpha value for the current color.</param>
        [DllImport("opengl32.dll", EntryPoint = "glColor4ui", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void Color4ui(uint red, uint green, uint blue, uint alpha);
        //{
        //    glColor4uiDlg(red, green, blue, alpha);
        //}

        /// <summary>
        /// Delimit the vertices of a primitive or a group of like primitives
        /// </summary>
        /// <param name="mode">Specifies the primitive or primitives that will be created from vertices presented between glBegin and the subsequent glEnd.</param>
        [DllImport("opengl32.dll", EntryPoint = "glBegin", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void Begin(RenderModes mode);
        //{
        //    glBeginDlg(mode);
        //}

        /// <summary>
        /// Ends delimiting the vertices of a primitive or a group of like primitives
        /// </summary>
        [DllImport("opengl32.dll", EntryPoint = "glEnd", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void End();
        //{
        //    glEndDlg();
        //}

        /// <summary>
        /// Specifies a vertex.
        /// 
        /// glVertex commands are used within glBegin/glEnd pairs to specify point, line, and polygon vertices.
        /// The current color, normal, texture coordinates, and fog coordinate are associated with the vertex when
        /// glVertex is called.
        /// 
        /// When only x and y are specified, z defaults to 0 and w defaults to 1. When x, y, and z are specified,
        /// w defaults to 1.
        /// </summary>
        /// <param name="x">Specify x coordinates of a vertex.</param>
        /// <param name="y">Specify y coordinates of a vertex.</param>
        [DllImport("opengl32.dll", EntryPoint = "glVertex2s", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void Vertex2s(short x, short y);
        //{
        //    glVertex2sDlg(x, y);
        //}

        /// <summary>
        /// Specifies a vertex.
        /// 
        /// glVertex commands are used within glBegin/glEnd pairs to specify point, line, and polygon vertices.
        /// The current color, normal, texture coordinates, and fog coordinate are associated with the vertex when
        /// glVertex is called.
        /// 
        /// When only x and y are specified, z defaults to 0 and w defaults to 1. When x, y, and z are specified,
        /// w defaults to 1.
        /// </summary>
        /// <param name="x">Specify x coordinates of a vertex.</param>
        /// <param name="y">Specify y coordinates of a vertex.</param>
        [DllImport("opengl32.dll", EntryPoint = "glVertex2i", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void Vertex2i(int x, int y);
        //{
        //    glVertex2iDlg(x, y);
        //}

        /// <summary>
        /// Specifies a vertex.
        /// 
        /// glVertex commands are used within glBegin/glEnd pairs to specify point, line, and polygon vertices.
        /// The current color, normal, texture coordinates, and fog coordinate are associated with the vertex when
        /// glVertex is called.
        /// 
        /// When only x and y are specified, z defaults to 0 and w defaults to 1. When x, y, and z are specified,
        /// w defaults to 1.
        /// </summary>
        /// <param name="x">Specify x coordinates of a vertex.</param>
        /// <param name="y">Specify y coordinates of a vertex.</param>
        [DllImport("opengl32.dll", EntryPoint = "glVertex2f", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void Vertex2f(float x, float y);
        //{
        //    glVertex2fDlg(x, y);
        //}

        /// <summary>
        /// Specifies a vertex.
        /// 
        /// glVertex commands are used within glBegin/glEnd pairs to specify point, line, and polygon vertices.
        /// The current color, normal, texture coordinates, and fog coordinate are associated with the vertex when
        /// glVertex is called.
        /// 
        /// When only x and y are specified, z defaults to 0 and w defaults to 1. When x, y, and z are specified,
        /// w defaults to 1.
        /// </summary>
        /// <param name="x">Specify x coordinates of a vertex.</param>
        /// <param name="y">Specify y coordinates of a vertex.</param>
        [DllImport("opengl32.dll", EntryPoint = "glVertex2d", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void Vertex2d(double x, double y);
        //{
        //    glVertex2dDlg(x, y);
        //}

        /// <summary>
        /// Specifies a vertex.
        /// 
        /// glVertex commands are used within glBegin/glEnd pairs to specify point, line, and polygon vertices.
        /// The current color, normal, texture coordinates, and fog coordinate are associated with the vertex when
        /// glVertex is called.
        /// 
        /// When x, y, and z are specified,
        /// w defaults to 1.
        /// </summary>
        /// <param name="x">Specify x coordinates of a vertex.</param>
        /// <param name="y">Specify y coordinates of a vertex.</param>
        /// <param name="z">Specify z coordinates of a vertex.</param>
        [DllImport("opengl32.dll", EntryPoint = "glVertex3s", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void Vertex3s(short x, short y, short z);
        //{
        //    glVertex3sDlg(x, y, z);
        //}

        /// <summary>
        /// Specifies a vertex.
        /// 
        /// glVertex commands are used within glBegin/glEnd pairs to specify point, line, and polygon vertices.
        /// The current color, normal, texture coordinates, and fog coordinate are associated with the vertex when
        /// glVertex is called.
        /// 
        /// When x, y, and z are specified,
        /// w defaults to 1.
        /// </summary>
        /// <param name="x">Specify x coordinates of a vertex.</param>
        /// <param name="y">Specify y coordinates of a vertex.</param>
        /// <param name="z">Specify z coordinates of a vertex.</param>
        [DllImport("opengl32.dll", EntryPoint = "glVertex3i", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void Vertex3i(int x, int y, int z);
        //{
        //    glVertex3iDlg(x, y, z);
        //}

        /// <summary>
        /// Specifies a vertex.
        /// 
        /// glVertex commands are used within glBegin/glEnd pairs to specify point, line, and polygon vertices.
        /// The current color, normal, texture coordinates, and fog coordinate are associated with the vertex when
        /// glVertex is called.
        /// 
        /// When x, y, and z are specified,
        /// w defaults to 1.
        /// </summary>
        /// <param name="x">Specify x coordinates of a vertex.</param>
        /// <param name="y">Specify y coordinates of a vertex.</param>
        /// <param name="z">Specify z coordinates of a vertex.</param>
        [DllImport("opengl32.dll", EntryPoint = "glVertex3f", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void Vertex3f(float x, float y, float z);
        //{
        //    glVertex3fDlg(x, y, z);
        //}

        /// <summary>
        /// Specifies a vertex.
        /// 
        /// glVertex commands are used within glBegin/glEnd pairs to specify point, line, and polygon vertices.
        /// The current color, normal, texture coordinates, and fog coordinate are associated with the vertex when
        /// glVertex is called.
        /// 
        /// When x, y, and z are specified,
        /// w defaults to 1.
        /// </summary>
        /// <param name="x">Specify x coordinates of a vertex.</param>
        /// <param name="y">Specify y coordinates of a vertex.</param>
        /// <param name="z">Specify z coordinates of a vertex.</param>
        [DllImport("opengl32.dll", EntryPoint = "glVertex3d", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void Vertex3d(double x, double y, double z);
        //{
        //    glVertex3dDlg(x, y, z);
        //}

        /// <summary>
        /// Specifies a vertex.
        /// 
        /// glVertex commands are used within glBegin/glEnd pairs to specify point, line, and polygon vertices.
        /// The current color, normal, texture coordinates, and fog coordinate are associated with the vertex when
        /// glVertex is called.
        /// </summary>
        /// <param name="x">Specify x coordinates of a vertex.</param>
        /// <param name="y">Specify y coordinates of a vertex.</param>
        /// <param name="z">Specify z coordinates of a vertex.</param>
        /// <param name="w">Specify w coordinates of a vertex.</param>
        [DllImport("opengl32.dll", EntryPoint = "glVertex4s", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void Vertex4s(short x, short y, short z, short w);
        //{
        //    glVertex4sDlg(x, y, z, w);
        //}

        /// <summary>
        /// Specifies a vertex.
        /// 
        /// glVertex commands are used within glBegin/glEnd pairs to specify point, line, and polygon vertices.
        /// The current color, normal, texture coordinates, and fog coordinate are associated with the vertex when
        /// glVertex is called.
        /// </summary>
        /// <param name="x">Specify x coordinates of a vertex.</param>
        /// <param name="y">Specify y coordinates of a vertex.</param>
        /// <param name="z">Specify z coordinates of a vertex.</param>
        /// <param name="w">Specify w coordinates of a vertex.</param>
        [DllImport("opengl32.dll", EntryPoint = "glVertex4i", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void Vertex4i(int x, int y, int z, int w);
        //{
        //    glVertex4iDlg(x, y, z, w);
        //}

        /// <summary>
        /// Specifies a vertex.
        /// 
        /// glVertex commands are used within glBegin/glEnd pairs to specify point, line, and polygon vertices.
        /// The current color, normal, texture coordinates, and fog coordinate are associated with the vertex when
        /// glVertex is called.
        /// </summary>
        /// <param name="x">Specify x coordinates of a vertex.</param>
        /// <param name="y">Specify y coordinates of a vertex.</param>
        /// <param name="z">Specify z coordinates of a vertex.</param>
        /// <param name="w">Specify w coordinates of a vertex.</param>
        [DllImport("opengl32.dll", EntryPoint = "glVertex4f", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void Vertex4f(float x, float y, float z, float w);
        //{
        //    glVertex4fDlg(x, y, z, w);
        //}

        /// <summary>
        /// Specifies a vertex.
        /// 
        /// glVertex commands are used within glBegin/glEnd pairs to specify point, line, and polygon vertices.
        /// The current color, normal, texture coordinates, and fog coordinate are associated with the vertex when
        /// glVertex is called.
        /// </summary>
        /// <param name="x">Specify x coordinates of a vertex.</param>
        /// <param name="y">Specify y coordinates of a vertex.</param>
        /// <param name="z">Specify z coordinates of a vertex.</param>
        /// <param name="w">Specify w coordinates of a vertex.</param>
        [DllImport("opengl32.dll", EntryPoint = "glVertex4d", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void Vertex4d(double x, double y, double z, double w);
        //{
        //    glVertex4dDlg(x, y, z, w);
        //}

        /// <summary>
        /// Specifies a vertex.
        /// 
        /// glVertex commands are used within glBegin/glEnd pairs to specify point, line, and polygon vertices.
        /// The current color, normal, texture coordinates, and fog coordinate are associated with the vertex when
        /// glVertex is called.
        /// 
        /// When only x and y are specified, z defaults to 0 and w defaults to 1. When x, y, and z are specified,
        /// w defaults to 1.
        /// </summary>
        /// <param name="v">
        /// Specifies an array of two, three, or four elements. 
        /// The elements of a two-element array are x and y; 
        /// of a three-element array, x, y, and z;
        /// and of a four-element array, x, y, z, and w.
        /// </param>
        [DllImport("opengl32.dll", EntryPoint = "glVertex2sv", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void Vertex2sv(short[] v);
        //{
        //    glVertex2svDlg(v);
        //}

        /// <summary>
        /// Specifies a vertex.
        /// 
        /// glVertex commands are used within glBegin/glEnd pairs to specify point, line, and polygon vertices.
        /// The current color, normal, texture coordinates, and fog coordinate are associated with the vertex when
        /// glVertex is called.
        /// 
        /// When only x and y are specified, z defaults to 0 and w defaults to 1. When x, y, and z are specified,
        /// w defaults to 1.
        /// </summary>
        /// <param name="v">
        /// Specifies an array of two, three, or four elements. 
        /// The elements of a two-element array are x and y; 
        /// of a three-element array, x, y, and z;
        /// and of a four-element array, x, y, z, and w.
        /// </param>
        [DllImport("opengl32.dll", EntryPoint = "glVertex2iv", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void Vertex2iv(int[] v);
        //{
        //    glVertex2ivDlg(v);
        //}

        /// <summary>
        /// Specifies a vertex.
        /// 
        /// glVertex commands are used within glBegin/glEnd pairs to specify point, line, and polygon vertices.
        /// The current color, normal, texture coordinates, and fog coordinate are associated with the vertex when
        /// glVertex is called.
        /// 
        /// When only x and y are specified, z defaults to 0 and w defaults to 1. When x, y, and z are specified,
        /// w defaults to 1.
        /// </summary>
        /// <param name="v">
        /// Specifies an array of two, three, or four elements. 
        /// The elements of a two-element array are x and y; 
        /// of a three-element array, x, y, and z;
        /// and of a four-element array, x, y, z, and w.
        /// </param>
        [DllImport("opengl32.dll", EntryPoint = "glVertex2fv", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void Vertex2fv(float[] v);
        //{
        //    glVertex2fvDlg(v);
        //}

        /// <summary>
        /// Specifies a vertex.
        /// 
        /// glVertex commands are used within glBegin/glEnd pairs to specify point, line, and polygon vertices.
        /// The current color, normal, texture coordinates, and fog coordinate are associated with the vertex when
        /// glVertex is called.
        /// 
        /// When only x and y are specified, z defaults to 0 and w defaults to 1. When x, y, and z are specified,
        /// w defaults to 1.
        /// </summary>
        /// <param name="v">
        /// Specifies an array of two, three, or four elements. 
        /// The elements of a two-element array are x and y; 
        /// of a three-element array, x, y, and z;
        /// and of a four-element array, x, y, z, and w.
        /// </param>
        [DllImport("opengl32.dll", EntryPoint = "glVertex2dv", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void Vertex2dv(double[] v);
        //{
        //    glVertex2dvDlg(v);
        //}

        /// <summary>
        /// Specifies a vertex.
        /// 
        /// glVertex commands are used within glBegin/glEnd pairs to specify point, line, and polygon vertices.
        /// The current color, normal, texture coordinates, and fog coordinate are associated with the vertex when
        /// glVertex is called.
        /// 
        /// When only x and y are specified, z defaults to 0 and w defaults to 1. When x, y, and z are specified,
        /// w defaults to 1.
        /// </summary>
        /// <param name="v">
        /// Specifies an array of two, three, or four elements. 
        /// The elements of a two-element array are x and y; 
        /// of a three-element array, x, y, and z;
        /// and of a four-element array, x, y, z, and w.
        /// </param>
        [DllImport("opengl32.dll", EntryPoint = "glVertex3sv", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void Vertex3sv(short[] v);
        //{
        //    glVertex3svDlg(v);
        //}

        /// <summary>
        /// Specifies a vertex.
        /// 
        /// glVertex commands are used within glBegin/glEnd pairs to specify point, line, and polygon vertices.
        /// The current color, normal, texture coordinates, and fog coordinate are associated with the vertex when
        /// glVertex is called.
        /// 
        /// When only x and y are specified, z defaults to 0 and w defaults to 1. When x, y, and z are specified,
        /// w defaults to 1.
        /// </summary>
        /// <param name="v">
        /// Specifies an array of two, three, or four elements. 
        /// The elements of a two-element array are x and y; 
        /// of a three-element array, x, y, and z;
        /// and of a four-element array, x, y, z, and w.
        /// </param>
        [DllImport("opengl32.dll", EntryPoint = "glVertex3iv", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void Vertex3iv(int[] v);
        //{
        //    glVertex3ivDlg(v);
        //}

        /// <summary>
        /// Specifies a vertex.
        /// 
        /// glVertex commands are used within glBegin/glEnd pairs to specify point, line, and polygon vertices.
        /// The current color, normal, texture coordinates, and fog coordinate are associated with the vertex when
        /// glVertex is called.
        /// 
        /// When only x and y are specified, z defaults to 0 and w defaults to 1. When x, y, and z are specified,
        /// w defaults to 1.
        /// </summary>
        /// <param name="v">
        /// Specifies an array of two, three, or four elements. 
        /// The elements of a two-element array are x and y; 
        /// of a three-element array, x, y, and z;
        /// and of a four-element array, x, y, z, and w.
        /// </param>
        [DllImport("opengl32.dll", EntryPoint = "glVertex3fv", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void Vertex3fv(float[] v);
        //{
        //    glVertex3fvDlg(v);
        //}

        /// <summary>
        /// Specifies a vertex.
        /// 
        /// glVertex commands are used within glBegin/glEnd pairs to specify point, line, and polygon vertices.
        /// The current color, normal, texture coordinates, and fog coordinate are associated with the vertex when
        /// glVertex is called.
        /// 
        /// When only x and y are specified, z defaults to 0 and w defaults to 1. When x, y, and z are specified,
        /// w defaults to 1.
        /// </summary>
        /// <param name="v">
        /// Specifies an array of two, three, or four elements. 
        /// The elements of a two-element array are x and y; 
        /// of a three-element array, x, y, and z;
        /// and of a four-element array, x, y, z, and w.
        /// </param>
        [DllImport("opengl32.dll", EntryPoint = "glVertex3dv", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void Vertex3dv(double[] v);
        //{
        //    glVertex3dvDlg(v);
        //}

        /// <summary>
        /// Specifies a vertex.
        /// 
        /// glVertex commands are used within glBegin/glEnd pairs to specify point, line, and polygon vertices.
        /// The current color, normal, texture coordinates, and fog coordinate are associated with the vertex when
        /// glVertex is called.
        /// 
        /// When only x and y are specified, z defaults to 0 and w defaults to 1. When x, y, and z are specified,
        /// w defaults to 1.
        /// </summary>
        /// <param name="v">
        /// Specifies an array of two, three, or four elements. 
        /// The elements of a two-element array are x and y; 
        /// of a three-element array, x, y, and z;
        /// and of a four-element array, x, y, z, and w.
        /// </param>
        [DllImport("opengl32.dll", EntryPoint = "glVertex4sv", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void Vertex4sv(short[] v);
        //{
        //    glVertex4svDlg(v);
        //}

        /// <summary>
        /// Specifies a vertex.
        /// 
        /// glVertex commands are used within glBegin/glEnd pairs to specify point, line, and polygon vertices.
        /// The current color, normal, texture coordinates, and fog coordinate are associated with the vertex when
        /// glVertex is called.
        /// 
        /// When only x and y are specified, z defaults to 0 and w defaults to 1. When x, y, and z are specified,
        /// w defaults to 1.
        /// </summary>
        /// <param name="v">
        /// Specifies an array of two, three, or four elements. 
        /// The elements of a two-element array are x and y; 
        /// of a three-element array, x, y, and z;
        /// and of a four-element array, x, y, z, and w.
        /// </param>
        [DllImport("opengl32.dll", EntryPoint = "glVertex4iv", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void Vertex4iv(int[] v);
        //{
        //    glVertex4ivDlg(v);
        //}

        /// <summary>
        /// Specifies a vertex.
        /// 
        /// glVertex commands are used within glBegin/glEnd pairs to specify point, line, and polygon vertices.
        /// The current color, normal, texture coordinates, and fog coordinate are associated with the vertex when
        /// glVertex is called.
        /// 
        /// When only x and y are specified, z defaults to 0 and w defaults to 1. When x, y, and z are specified,
        /// w defaults to 1.
        /// </summary>
        /// <param name="v">
        /// Specifies an array of two, three, or four elements. 
        /// The elements of a two-element array are x and y; 
        /// of a three-element array, x, y, and z;
        /// and of a four-element array, x, y, z, and w.
        /// </param>
        [DllImport("opengl32.dll", EntryPoint = "glVertex4fv", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void Vertex4fv(float[] v);
        //{
        //    glVertex4fvDlg(v);
        //}

        /// <summary>
        /// Specifies a vertex.
        /// 
        /// glVertex commands are used within glBegin/glEnd pairs to specify point, line, and polygon vertices.
        /// The current color, normal, texture coordinates, and fog coordinate are associated with the vertex when
        /// glVertex is called.
        /// 
        /// When only x and y are specified, z defaults to 0 and w defaults to 1. When x, y, and z are specified,
        /// w defaults to 1.
        /// </summary>
        /// <param name="v">
        /// Specifies an array of two, three, or four elements. 
        /// The elements of a two-element array are x and y; 
        /// of a three-element array, x, y, and z;
        /// and of a four-element array, x, y, z, and w.
        /// </param>
        [DllImport("opengl32.dll", EntryPoint = "glVertex4dv", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void Vertex4dv(double[] v);
        //{
        //    glVertex4dvDlg(v);
        //}

        /// <summary>
        /// Set the viewport.
        /// 
        /// glViewport specifies the affine transformation of x and y
        /// from normalized device coordinates to window coordinates.
        /// Let(xnd, ynd)
        /// be normalized device coordinates.Then the window coordinates
        /// (xw, yw)
        /// are computed as follows:
        /// 
        /// xw = (xnd + 1)*(width / 2) + x
        /// yw = (ynd + 1)*(height / 2) + y
        /// Viewport width and height are silently clamped to a range 
        /// that depends on the implementation.
        /// To query this range, call glGet with argument GL_MAX_VIEWPORT_DIMS.
        /// </summary>
        /// <param name="x">Specify the lower left corner of the viewport rectangle, in pixels. The initial value is (0,0).</param>
        /// <param name="y">Specify the lower left corner of the viewport rectangle, in pixels. The initial value is (0,0).</param>
        /// <param name="width">
        /// Specify the width and height of the viewport. 
        /// When a GL context is first attached to a window, width and height are set to the dimensions of that window.
        /// </param>
        /// <param name="height">
        /// Specify the width and height of the viewport. 
        /// When a GL context is first attached to a window, width and height are set to the dimensions of that window.
        /// </param>
        [DllImport("opengl32.dll", EntryPoint = "glViewport", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void Viewport(int x, int y, int width, int height);
        //{
        //    glViewportDlg(x, y, width, height);
        //}

        #endregion

        /// <summary>
        /// Returns n vertex array object names in arrays. 
        /// There is no guarantee that the names form a contiguous set of integers; 
        /// however, it is guaranteed that none of the returned names was in use immediately before the call to 
        /// glGenVertexArrays.
        /// 
        /// Vertex array object names returned by a call to glGenVertexArrays are not returned by subsequent calls, 
        /// unless they are first deleted with glDeleteVertexArrays.
        /// 
        /// The names returned in arrays are marked as used, for the purposes of glGenVertexArrays only, 
        /// but they acquire state and type only when they are first bound.
        /// </summary>
        /// <param name="n">Specifies the number of vertex array object names to generate.</param>
        /// <param name="arrays">Specifies an array in which the generated vertex array object names are stored.</param>
        public static void GenVertexArrays(int n, uint[] arrays)
        {
            if (glGenVertexArraysPtr == IntPtr.Zero) {
                glGenVertexArraysPtr = Wgl.GetProcAddress("glGenVertexArrays");
                glGenVertexArraysDlg =
                    Marshal.GetDelegateForFunctionPointer<glGenVertexArrays>(glGenVertexArraysPtr);
            }
            glGenVertexArraysDlg(n, arrays);
        }

        /// <summary>
        /// Generates a vertex array buffer.
        /// </summary>
        /// <returns>The newly created array</returns>
        public static uint GenVertexArray()
        {
            uint[] arr = new uint[1];
            GenVertexArrays(1, arr);
            return arr[0];
        }

        /// <summary>
        /// Binds the vertex array object with name array. 
        /// array is the name of a vertex array object previously returned from a call to glGenVertexArrays, 
        /// or zero to break the existing vertex array object binding.
        /// 
        /// If no vertex array object with name array exists, one is created when array is first bound.
        /// If the bind is successful no change is made to the state of the vertex array object, 
        /// and any previous vertex array object binding is broken.
        /// </summary>
        /// <param name="n">Specifies the number of elements in arrays</param>
        /// <param name="arrays">Specifies an array containing the names of the vertex arrays to bind.</param>
        public static void BindVertexArray(int n, uint[] arrays)
        {
            if (glBindVertexArrayPtr == IntPtr.Zero)
            {
                glBindVertexArrayPtr = Wgl.GetProcAddress("glBindVertexArray");
                glBindVertexArrayDlg =
                Marshal.GetDelegateForFunctionPointer<glBindVertexArray>(glBindVertexArrayPtr);
            }

            for (int i = 0; i < n; i++)
                glBindVertexArrayDlg(arrays[i]);
        }

        /// <summary>
        /// Binds the vertex array object with name array. 
        /// array is the name of a vertex array object previously returned from a call to glGenVertexArrays, 
        /// or zero to break the existing vertex array object binding.
        /// 
        /// If no vertex array object with name array exists, one is created when array is first bound.
        /// If the bind is successful no change is made to the state of the vertex array object, 
        /// and any previous vertex array object binding is broken.
        /// </summary>
        /// <param name="array">Specifies the name of the vertex array to bind.</param>
        public static void BindVertexArray(uint array)
        {
            if (glBindVertexArrayPtr == IntPtr.Zero)
            {
                glBindVertexArrayPtr = Wgl.GetProcAddress("glBindVertexArray");
                glBindVertexArrayDlg =
               Marshal.GetDelegateForFunctionPointer<glBindVertexArray>(glBindVertexArrayPtr);
            }
            glBindVertexArrayDlg(array);
        }

        /// <summary>
        /// Returns n buffer object names in buffers. 
        /// There is no guarantee that the names form a contiguous set of integers; however, it is guaranteed that 
        /// none of the returned names was in use immediately before the call to glGenBuffers.
        /// 
        /// Buffer object names returned by a call to glGenBuffers are not returned by subsequent calls, 
        /// unless they are first deleted with glDeleteBuffers.
        /// 
        /// No buffer objects are associated with the returned buffer object names until they are first bound by calling 
        /// glBindBuffer.
        /// </summary>
        /// <param name="n">Specifies the number of buffer object names to be generated.</param>
        /// <param name="buffers">Specifies an array in which the generated buffer object names are stored.</param>
        public static void GenBuffers(int n, uint[] buffers)
        {
            if (glGenBuffersPtr == IntPtr.Zero)
            {
                glGenBuffersPtr = Wgl.GetProcAddress("glGenBuffers");
                glGenBuffersDlg =
               Marshal.GetDelegateForFunctionPointer<glGenBuffers>(glGenBuffersPtr);
            }
            glGenBuffersDlg(n, buffers);
        }

        /// <summary>
        /// Generate a buffer object name.
        /// </summary>
        /// <returns>The newly created buffer</returns>
        public static uint GenBuffer()
        {
            uint[] arr = new uint[1];
            GenBuffers(1, arr);
            return arr[0];
        }

        /// <summary>
        /// Bind a named buffer object.
        /// </summary>
        /// <remarks>
        /// Binds a buffer object to the specified buffer binding point. Calling glBindBuffer with target set to one of the accepted symbolic constants and buffer set to the name of a buffer object binds that buffer object name to the target. If no buffer object with name buffer exists, one is created with that name. When a buffer object is bound to a target, the previous binding for that target is automatically broken.
        /// 
        /// Buffer object names are unsigned integers.The value zero is reserved, but there is no default buffer object for each buffer object target.Instead, buffer set to zero effectively unbinds any buffer object previously bound, and restores client memory usage for that buffer object target (if supported for that target). Buffer object names and the corresponding buffer object contents are local to the shared object space of the current GL rendering context; two rendering contexts share buffer object names only if they explicitly enable sharing between contexts through the appropriate GL windows interfaces functions.
        /// 
        /// glGenBuffers must be used to generate a set of unused buffer object names.
        /// 
        /// The state of a buffer object immediately after it is first bound is an unmapped zero-sized memory buffer with GL_READ_WRITE access and GL_STATIC_DRAW usage.
        /// 
        /// While a non-zero buffer object name is bound, GL operations on the target to which it is bound affect the bound buffer object, and queries of the target to which it is bound return state from the bound buffer object. While buffer object name zero is bound, as in the initial state, attempts to modify or query state on the target to which it is bound generates an GL_INVALID_OPERATION error.
        /// 
        /// When a non-zero buffer object is bound to the GL_ARRAY_BUFFER target, the vertex array pointer parameter is interpreted as an offset within the buffer object measured in basic machine units.
        /// 
        /// When a non-zero buffer object is bound to the GL_DRAW_INDIRECT_BUFFER target, parameters for draws issued through glDrawArraysIndirect and glDrawElementsIndirect are sourced from the specified offset in that buffer object's data store.
        /// 
        /// 
        /// When a non-zero buffer object is bound to the GL_DISPATCH_INDIRECT_BUFFER target, the parameters for compute dispatches issued through glDispatchComputeIndirect are sourced from the specified offset in that buffer object's data store.
        /// 
        /// 
        /// While a non-zero buffer object is bound to the GL_ELEMENT_ARRAY_BUFFER target, the indices parameter of glDrawElements, glDrawElementsInstanced, glDrawElementsBaseVertex, glDrawRangeElements, glDrawRangeElementsBaseVertex, glMultiDrawElements, or glMultiDrawElementsBaseVertex is interpreted as an offset within the buffer object measured in basic machine units.
        /// 
        /// While a non-zero buffer object is bound to the GL_PIXEL_PACK_BUFFER target, the following commands are affected: glGetCompressedTexImage, glGetTexImage, and glReadPixels. The pointer parameter is interpreted as an offset within the buffer object measured in basic machine units.
        /// 
        /// While a non-zero buffer object is bound to the GL_PIXEL_UNPACK_BUFFER target, the following commands are affected: glCompressedTexImage1D, glCompressedTexImage2D, glCompressedTexImage3D, glCompressedTexSubImage1D, glCompressedTexSubImage2D, glCompressedTexSubImage3D, glTexImage1D, glTexImage2D, glTexImage3D, glTexSubImage1D, glTexSubImage2D, and glTexSubImage3D. The pointer parameter is interpreted as an offset within the buffer object measured in basic machine units.
        /// 
        /// The buffer targets GL_COPY_READ_BUFFER and GL_COPY_WRITE_BUFFER are provided to allow glCopyBufferSubData to be used without disturbing the state of other bindings.However, glCopyBufferSubData may be used with any pair of buffer binding points.
        /// 
        /// The GL_TRANSFORM_FEEDBACK_BUFFER buffer binding point may be passed to glBindBuffer, but will not directly affect transform feedback state. Instead, the indexed GL_TRANSFORM_FEEDBACK_BUFFER bindings must be used through a call to glBindBufferBase or glBindBufferRange. This will affect the generic GL_TRANSFORM_FEEDBACK_BUFFER binding.
        /// 
        /// Likewise, the GL_UNIFORM_BUFFER, GL_ATOMIC_COUNTER_BUFFER and GL_SHADER_STORAGE_BUFFER buffer binding points may be used, but do not directly affect uniform buffer, atomic counter buffer or shader storage buffer state, respectively.glBindBufferBase or glBindBufferRange must be used to bind a buffer to an indexed uniform buffer, atomic counter buffer or shader storage buffer binding point.
        /// 
        /// The GL_QUERY_BUFFER binding point is used to specify a buffer object that is to receive the results of query objects through calls to the glGetQueryObject family of commands.
        /// 
        /// A buffer object binding created with glBindBuffer remains active until a different buffer object name is bound to the same target, or until the bound buffer object is deleted with glDeleteBuffers.
        /// 
        /// Once created, a named buffer object may be re-bound to any target as often as needed.However, the GL implementation may make choices about how to optimize the storage of a buffer object based on its initial binding target.
        /// 
        /// Notes
        /// The GL_COPY_READ_BUFFER, GL_UNIFORM_BUFFER and GL_TEXTURE_BUFFER targets are available only if the GL version is 3.1 or greater.
        /// 
        /// 
        /// The GL_ATOMIC_COUNTER_BUFFER target is available only if the GL version is 4.2 or greater.
        /// 
        /// 
        /// The GL_DISPATCH_INDIRECT_BUFFER and GL_SHADER_STORAGE_BUFFER targets are available only if the GL version is 4.3 or greater.
        /// 
        /// 
        /// The GL_QUERY_BUFFER target is available only if the GL version is 4.4 or greater.
        /// 
        /// 
        /// Errors
        /// GL_INVALID_ENUM is generated if target is not one of the allowable values.
        /// 
        /// 
        /// GL_INVALID_VALUE is generated if buffer is not a name previously returned from a call to glGenBuffers.
        /// </remarks>
        /// <param name="target">Specifies the target to which the buffer object is bound</param>
        /// <param name="buffer">Specifies the name of a buffer object.</param>
        public static void BindBuffer(BufferTargets target, uint buffer)
        {
            if (glBindBufferPtr == IntPtr.Zero)
            {
                glBindBufferPtr = Wgl.GetProcAddress("glBindBuffer");
                glBindBufferDlg =
               Marshal.GetDelegateForFunctionPointer<glBindBuffer>(glBindBufferPtr);
            }
            glBindBufferDlg(target, buffer);
        }

        /// <summary>
        /// Create a new data store for a buffer object. 
        /// The buffer object currently bound to target is used.
        /// 
        /// While creating the new storage, any pre-existing data store is deleted.The new data store is created with 
        /// the specified size in bytes and usage.
        /// If data is not NULL, the data store is initialized with data from this pointer.
        /// In its initial state, the new data store is not mapped, it has a NULL mapped pointer, 
        /// and its mapped access is GL_READ_WRITE.
        /// 
        /// Usage is a hint to the GL implementation as to how a buffer object's data store will be accessed. 
        /// This enables the GL implementation to make more intelligent decisions that may significantly impact 
        /// buffer object performance. 
        /// It does not, however, constrain the actual usage of the data store. 
        /// Usage can be broken down into two parts: 
        /// first, the frequency of access (modification and usage), 
        /// and second, the nature of that access.
        /// </summary>
        /// <param name="target">Specifies the target to which the buffer object is bound for</param>
        /// <param name="size">Specifies the size in bytes of the buffer object's new data store.</param>
        /// <param name="data">Specifies a pointer to data that will be copied into the data store for initialization, or NULL if no data is to be copied.</param>
        /// <param name="usage">Specifies the expected usage pattern of the data store.</param>
        public static void BufferData(BufferTargets target, /*GLsizeiptr */ int size, IntPtr data, BufferUsages usage)
        {
            if (glBufferDataPtr == IntPtr.Zero)
            {
                glBufferDataPtr = Wgl.GetProcAddress("glBufferData");
                glBufferDataDlg =
               Marshal.GetDelegateForFunctionPointer<glBufferData>(glBufferDataPtr);
            }
            glBufferDataDlg(target, size, data, usage);
        }

        /// <summary>
        /// Create a new data store for a buffer object. 
        /// The buffer object currently bound to target is used.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">Specifies the target to which the buffer object is bound for</param>
        /// <param name="data">Specifies a pointer to data that will be copied into the data store for initialization, or NULL if no data is to be copied.</param>
        /// <param name="usage">Specifies the expected usage pattern of the data store.</param>
        public static void BufferData<T>(BufferTargets target, T[] data, BufferUsages usage) where T : unmanaged
        {
            int sz = Marshal.SizeOf(typeof(T)) * data.Length; // Marshal.SizeOf(typeof(int[])) * data.Length;

            GCHandle GlobalDataPointer = GCHandle.Alloc(data, GCHandleType.Pinned); // Marshal.AllocHGlobal(sz);

            BufferData(target, sz, GlobalDataPointer.AddrOfPinnedObject(), usage);

            GlobalDataPointer.Free();
        }

        /// <summary>
        /// Create a new data store for a buffer object. 
        /// The buffer object currently bound to target is used.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">Specifies the target to which the buffer object is bound for</param>
        /// <param name="data">Specifies a pointer to data that will be copied into the data store for initialization, or NULL if no data is to be copied.</param>
        /// <param name="usage">Specifies the expected usage pattern of the data store.</param>
        public static void BufferData<T>(BufferTargets target, T data, BufferUsages usage) where T : unmanaged
        {
            int sz = Marshal.SizeOf(typeof(T));

            GCHandle GlobalDataPointer = GCHandle.Alloc(data, GCHandleType.Pinned); // Marshal.AllocHGlobal(sz);

            BufferData(target, sz, GlobalDataPointer.AddrOfPinnedObject(), usage);

            GlobalDataPointer.Free();
        }

        /// <summary>
        /// Create a new data store for a buffer object. 
        /// A buffer object associated with ID specified by the caller in buffer will be used.
        /// 
        /// While creating the new storage, any pre-existing data store is deleted.The new data store is created with 
        /// the specified size in bytes and usage.
        /// If data is not NULL, the data store is initialized with data from this pointer.
        /// In its initial state, the new data store is not mapped, it has a NULL mapped pointer, 
        /// and its mapped access is GL_READ_WRITE.
        /// 
        /// Usage is a hint to the GL implementation as to how a buffer object's data store will be accessed. 
        /// This enables the GL implementation to make more intelligent decisions that may significantly impact 
        /// buffer object performance. 
        /// It does not, however, constrain the actual usage of the data store. 
        /// Usage can be broken down into two parts: 
        /// first, the frequency of access (modification and usage), 
        /// and second, the nature of that access.
        /// </summary>
        /// <param name="buffer">Specifies the name of the buffer object</param>
        /// <param name="size">Specifies the size in bytes of the buffer object's new data store.</param>
        /// <param name="data">Specifies a pointer to data that will be copied into the data store for initialization, or NULL if no data is to be copied.</param>
        /// <param name="usage">Specifies the expected usage pattern of the data store.</param>
        public static void NamedBufferData(uint buffer, /*GLsizeiptr */ int size, IntPtr data, BufferUsages usage)
        {
            IntPtr ptr = Wgl.GetProcAddress("glNamedBufferData");
            glNamedBufferData glNamedBufferDataDlg =
           Marshal.GetDelegateForFunctionPointer<glNamedBufferData>(ptr);

            glNamedBufferDataDlg(buffer, size, data, usage);
        }

        /// <summary>
        /// Installs a program object as part of current rendering state
        /// 
        /// </summary>
        /// <remarks>
        /// Installs the program object specified by program as part of current rendering state. One or more executables are created in a program object by successfully attaching shader objects to it with glAttachShader, successfully compiling the shader objects with glCompileShader, and successfully linking the program object with glLinkProgram.
        /// 
        /// A program object will contain an executable that will run on the vertex processor if it contains one or more shader objects of type GL_VERTEX_SHADER that have been successfully compiled and linked.A program object will contain an executable that will run on the geometry processor if it contains one or more shader objects of type GL_GEOMETRY_SHADER that have been successfully compiled and linked.Similarly, a program object will contain an executable that will run on the fragment processor if it contains one or more shader objects of type GL_FRAGMENT_SHADER that have been successfully compiled and linked.
        /// 
        /// While a program object is in use, applications are free to modify attached shader objects, compile attached shader objects, attach additional shader objects, and detach or delete shader objects.None of these operations will affect the executables that are part of the current state.However, relinking the program object that is currently in use will install the program object as part of the current rendering state if the link operation was successful(see glLinkProgram). If the program object currently in use is relinked unsuccessfully, its link status will be set to GL_FALSE, but the executables and associated state will remain part of the current state until a subsequent call to glUseProgram removes it from use.After it is removed from use, it cannot be made part of current state until it has been successfully relinked.
        /// 
        /// If program is zero, then the current rendering state refers to an invalid program object and the results of shader execution are undefined.However, this is not an error.
        /// 
        /// If program does not contain shader objects of type GL_FRAGMENT_SHADER, an executable will be installed on the vertex, and possibly geometry processors, but the results of fragment shader execution will be undefined.
        /// 
        /// 
        /// Notes
        /// Like buffer and texture objects, the name space for program objects may be shared across a set of contexts, as long as the server sides of the contexts share the same address space.If the name space is shared across contexts, any attached objects and the data associated with those attached objects are shared as well.
        /// 
        /// Applications are responsible for providing the synchronization across API calls when objects are accessed from different execution threads.
        /// 
        /// 
        /// Errors
        /// GL_INVALID_VALUE is generated if program is neither 0 nor a value generated by OpenGL.
        /// 
        /// 
        /// GL_INVALID_OPERATION is generated if program is not a program object.
        /// 
        /// 
        /// GL_INVALID_OPERATION is generated if program could not be made part of current state.
        /// 
        /// GL_INVALID_OPERATION is generated if transform feedback mode is active.
        /// </remarks>
        /// <param name="program">Specifies the handle of the program object whose executables are to be used as part of current rendering state.</param>
        public static void UseProgram(uint program)
        {
            if (glUseProgramPtr == IntPtr.Zero)
            {
                glUseProgramPtr = Wgl.GetProcAddress("glUseProgram");
                glUseProgramDlg =
               Marshal.GetDelegateForFunctionPointer<glUseProgram>(glUseProgramPtr);
            }
            glUseProgramDlg(program);
        }

        /// <summary>
        /// Enable the generic vertex attribute array specified by index.
        /// Uses currently bound vertex array object for the operation
        /// </summary>
        /// <param name="index">Specifies the index of the generic vertex attribute to be enabled or disabled.</param>
        public static void EnableVertexAttribArray(uint index)
        {
            if (glEnableVertexAttribArrayPtr == IntPtr.Zero)
            {
                glEnableVertexAttribArrayPtr = Wgl.GetProcAddress("glEnableVertexAttribArray");
                glEnableVertexAttribArrayDlg =
               Marshal.GetDelegateForFunctionPointer<glEnableVertexAttribArray>(glEnableVertexAttribArrayPtr);
            }
            glEnableVertexAttribArrayDlg(index);
        }

        /// <summary>
        /// Disable the generic vertex attribute array specified by index.
        /// Uses currently bound vertex array object for the operation
        /// </summary>
        /// <param name="index">Specifies the index of the generic vertex attribute to be enabled or disabled.</param>
        public static void DisableVertexAttribArray(uint index)
        {
            if (glDisableVertexAttribArrayPtr == IntPtr.Zero)
            {
                glDisableVertexAttribArrayPtr = Wgl.GetProcAddress("glDisableVertexAttribArray");
                glDisableVertexAttribArrayDlg =
               Marshal.GetDelegateForFunctionPointer<glDisableVertexAttribArray>(glDisableVertexAttribArrayPtr);
            }
            glDisableVertexAttribArrayDlg(index);
        }

        /// <summary>
        /// Enable the generic vertex attribute array specified by index.
        /// </summary>
        /// <param name="vaobj">Specifies the name of the vertex array object</param>
        /// <param name="index">Specifies the index of the generic vertex attribute to be enabled or disabled.</param>
        public static void EnableVertexArrayAttrib(uint vaobj, uint index)
        {
            if (glEnableVertexArrayAttribPtr == IntPtr.Zero)
            {
                glEnableVertexArrayAttribPtr = Wgl.GetProcAddress("glEnableVertexArrayAttrib");
                glEnableVertexArrayAttribDlg =
               Marshal.GetDelegateForFunctionPointer<glEnableVertexArrayAttrib>(glEnableVertexArrayAttribPtr);
            }
            glEnableVertexArrayAttribDlg(vaobj, index);
        }

        /// <summary>
        /// Disable the generic vertex attribute array specified by index.
        /// </summary>
        /// <param name="vaobj">Specifies the name of the vertex array object</param>
        /// <param name="index">Specifies the index of the generic vertex attribute to be enabled or disabled.</param>
        public static void DisableVertexArrayAttrib(uint vaobj, uint index)
        {
            if (glDisableVertexArrayAttribPtr == IntPtr.Zero)
            {
                glDisableVertexArrayAttribPtr = Wgl.GetProcAddress("glDisableVertexArrayAttrib");
                glDisableVertexArrayAttribDlg =
               Marshal.GetDelegateForFunctionPointer<glDisableVertexArrayAttrib>(glDisableVertexArrayAttribPtr);
            }
            glDisableVertexArrayAttribDlg(vaobj, index);
        }

        /// <summary>
        /// Define an array of generic vertex attribute data
        /// </summary>
        /// <remarks>
        /// Specify the location and data format of the array of generic vertex attributes at index index to use when rendering. 
        /// size specifies the number of components per attribute and must be 1, 2, 3, 4, or GL_BGRA. 
        /// type specifies the data type of each component, and stride specifies the byte stride from one attribute to the 
        /// next, allowing vertices and attributes to be packed into a single array or stored in separate arrays.
        /// 
        /// For glVertexAttribPointer, if normalized is set to GL_TRUE, it indicates that values stored in an integer format 
        /// are to be mapped to the range [-1, 1] (for signed values) or [0, 1] (for unsigned values) 
        /// when they are accessed and converted to floating point.Otherwise, values will be converted to floats directly 
        /// without normalization.
        /// 
        /// For glVertexAttribIPointer, only the integer types GL_BYTE, GL_UNSIGNED_BYTE, GL_SHORT, GL_UNSIGNED_SHORT, GL_INT, 
        /// GL_UNSIGNED_INT are accepted.Values are always left as integer values.
        /// 
        /// 
        /// glVertexAttribLPointer specifies state for a generic vertex attribute array associated with a shader attribute 
        /// variable declared with 64-bit double precision components.type must be GL_DOUBLE. 
        /// index, size, and stride behave as described for glVertexAttribPointer and glVertexAttribIPointer.
        /// 
        /// If pointer is not NULL, a non-zero named buffer object must be bound to the GL_ARRAY_BUFFER target 
        /// (see glBindBuffer), otherwise an error is generated.pointer is treated as a byte offset into the buffer 
        /// object's data store. 
        /// The buffer object binding (GL_ARRAY_BUFFER_BINDING) is saved as generic vertex attribute array state 
        /// (GL_VERTEX_ATTRIB_ARRAY_BUFFER_BINDING) for index index.
        /// 
        /// 
        /// When a generic vertex attribute array is specified, size, type, normalized, stride, and pointer are saved as 
        /// vertex array state, in addition to the current vertex array buffer object binding.
        /// 
        /// 
        /// To enable and disable a generic vertex attribute array, call glEnableVertexAttribArray and 
        /// glDisableVertexAttribArray with index. 
        /// If enabled, the generic vertex attribute array is used when glDrawArrays, glMultiDrawArrays, glDrawElements, 
        /// glMultiDrawElements, or glDrawRangeElements is called.
        /// 
        /// Notes: Each generic vertex attribute array is initially disabled and isn't accessed when glDrawElements, 
        /// glDrawRangeElements, glDrawArrays, glMultiDrawArrays, or glMultiDrawElements is called.
        /// 
        /// GL_UNSIGNED_INT_10F_11F_11F_REV is accepted for type only if the GL version is 4.4 or higher.
        /// </remarks>
        /// <param name="index">Specifies the index of the generic vertex attribute to be modified.</param>
        /// <param name="size">Specifies the number of components per generic vertex attribute. Must be 1, 2, 3, 4. 
        /// Additionally, the symbolic constant GL_BGRA is accepted by glVertexAttribPointer. The initial value is 4.</param>
        /// <param name="type">Specifies the data type of each component in the array.</param>
        /// <param name="normalized">specifies whether fixed-point data values should be normalized (true) or converted directly as fixed-point values (false) when they are accessed.</param>
        /// <param name="stride">Specifies the byte offset between consecutive generic vertex attributes. If stride is 0, the generic vertex attributes are understood to be tightly packed in the array. The initial value is 0.</param>
        /// <param name="pointer">Specifies a offset of the first component of the first generic vertex attribute in the array in the data store of the buffer currently bound to the GL_ARRAY_BUFFER target. The initial value is 0.</param>
        public static void VertexAttribPointer(uint index, int size, GLDataTypes type, bool normalized, int stride, int pointer)
        {
            if (glVertexAttribPointerPtr == IntPtr.Zero)
            {
                glVertexAttribPointerPtr = Wgl.GetProcAddress("glVertexAttribPointer");
                glVertexAttribPointerDlg =
               Marshal.GetDelegateForFunctionPointer<glVertexAttribPointer>(glVertexAttribPointerPtr);
            }
            glVertexAttribPointerDlg(index, size, type, normalized, stride, pointer);
        }

        /// <summary>
        /// Define an array of generic vertex attribute data
        /// </summary>
        /// <remarks>
        /// Specify the location and data format of the array of generic vertex attributes at index index to use when rendering. 
        /// size specifies the number of components per attribute and must be 1, 2, 3, 4, or GL_BGRA. 
        /// type specifies the data type of each component, and stride specifies the byte stride from one attribute to the 
        /// next, allowing vertices and attributes to be packed into a single array or stored in separate arrays.
        /// 
        /// For glVertexAttribPointer, if normalized is set to GL_TRUE, it indicates that values stored in an integer format 
        /// are to be mapped to the range [-1, 1] (for signed values) or [0, 1] (for unsigned values) 
        /// when they are accessed and converted to floating point.Otherwise, values will be converted to floats directly 
        /// without normalization.
        /// 
        /// For glVertexAttribIPointer, only the integer types GL_BYTE, GL_UNSIGNED_BYTE, GL_SHORT, GL_UNSIGNED_SHORT, GL_INT, 
        /// GL_UNSIGNED_INT are accepted.Values are always left as integer values.
        /// 
        /// 
        /// glVertexAttribLPointer specifies state for a generic vertex attribute array associated with a shader attribute 
        /// variable declared with 64-bit double precision components.type must be GL_DOUBLE. 
        /// index, size, and stride behave as described for glVertexAttribPointer and glVertexAttribIPointer.
        /// 
        /// If pointer is not NULL, a non-zero named buffer object must be bound to the GL_ARRAY_BUFFER target 
        /// (see glBindBuffer), otherwise an error is generated.pointer is treated as a byte offset into the buffer 
        /// object's data store. 
        /// The buffer object binding (GL_ARRAY_BUFFER_BINDING) is saved as generic vertex attribute array state 
        /// (GL_VERTEX_ATTRIB_ARRAY_BUFFER_BINDING) for index index.
        /// 
        /// 
        /// When a generic vertex attribute array is specified, size, type, normalized, stride, and pointer are saved as 
        /// vertex array state, in addition to the current vertex array buffer object binding.
        /// 
        /// 
        /// To enable and disable a generic vertex attribute array, call glEnableVertexAttribArray and 
        /// glDisableVertexAttribArray with index. 
        /// If enabled, the generic vertex attribute array is used when glDrawArrays, glMultiDrawArrays, glDrawElements, 
        /// glMultiDrawElements, or glDrawRangeElements is called.
        /// 
        /// Notes: Each generic vertex attribute array is initially disabled and isn't accessed when glDrawElements, 
        /// glDrawRangeElements, glDrawArrays, glMultiDrawArrays, or glMultiDrawElements is called.
        /// 
        /// GL_UNSIGNED_INT_10F_11F_11F_REV is accepted for type only if the GL version is 4.4 or higher.
        /// </remarks>
        /// <param name="index">Specifies the index of the generic vertex attribute to be modified.</param>
        /// <param name="size">Specifies the number of components per generic vertex attribute. Must be 1, 2, 3, 4. 
        /// Additionally, the symbolic constant GL_BGRA is accepted by glVertexAttribPointer. The initial value is 4.</param>
        /// <param name="type">Specifies the data type of each component in the array.</param>
        /// <param name="stride">Specifies the byte offset between consecutive generic vertex attributes. If stride is 0, the generic vertex attributes are understood to be tightly packed in the array. The initial value is 0.</param>
        /// <param name="pointer">Specifies a offset of the first component of the first generic vertex attribute in the array in the data store of the buffer currently bound to the GL_ARRAY_BUFFER target. The initial value is 0.</param>
        public static void VertexAttribIPointer(uint index, int size, GLDataTypes type, int stride, int pointer)
        {
            if (glVertexAttribIPointerPtr == IntPtr.Zero)
            {
                glVertexAttribIPointerPtr = Wgl.GetProcAddress("glVertexAttribIPointer");
                glVertexAttribIPointerDlg =
               Marshal.GetDelegateForFunctionPointer<glVertexAttribIPointer>(glVertexAttribIPointerPtr);
            }
            glVertexAttribIPointerDlg(index, size, type, stride, pointer);
        }

        /// <summary>
        /// Define an array of generic vertex attribute data
        /// </summary>
        /// <remarks>
        /// Specify the location and data format of the array of generic vertex attributes at index index to use when rendering. 
        /// size specifies the number of components per attribute and must be 1, 2, 3, 4, or GL_BGRA. 
        /// type specifies the data type of each component, and stride specifies the byte stride from one attribute to the 
        /// next, allowing vertices and attributes to be packed into a single array or stored in separate arrays.
        /// 
        /// For glVertexAttribPointer, if normalized is set to GL_TRUE, it indicates that values stored in an integer format 
        /// are to be mapped to the range [-1, 1] (for signed values) or [0, 1] (for unsigned values) 
        /// when they are accessed and converted to floating point.Otherwise, values will be converted to floats directly 
        /// without normalization.
        /// 
        /// For glVertexAttribIPointer, only the integer types GL_BYTE, GL_UNSIGNED_BYTE, GL_SHORT, GL_UNSIGNED_SHORT, GL_INT, 
        /// GL_UNSIGNED_INT are accepted.Values are always left as integer values.
        /// 
        /// 
        /// glVertexAttribLPointer specifies state for a generic vertex attribute array associated with a shader attribute 
        /// variable declared with 64-bit double precision components.type must be GL_DOUBLE. 
        /// index, size, and stride behave as described for glVertexAttribPointer and glVertexAttribIPointer.
        /// 
        /// If pointer is not NULL, a non-zero named buffer object must be bound to the GL_ARRAY_BUFFER target 
        /// (see glBindBuffer), otherwise an error is generated.pointer is treated as a byte offset into the buffer 
        /// object's data store. 
        /// The buffer object binding (GL_ARRAY_BUFFER_BINDING) is saved as generic vertex attribute array state 
        /// (GL_VERTEX_ATTRIB_ARRAY_BUFFER_BINDING) for index index.
        /// 
        /// 
        /// When a generic vertex attribute array is specified, size, type, normalized, stride, and pointer are saved as 
        /// vertex array state, in addition to the current vertex array buffer object binding.
        /// 
        /// 
        /// To enable and disable a generic vertex attribute array, call glEnableVertexAttribArray and 
        /// glDisableVertexAttribArray with index. 
        /// If enabled, the generic vertex attribute array is used when glDrawArrays, glMultiDrawArrays, glDrawElements, 
        /// glMultiDrawElements, or glDrawRangeElements is called.
        /// 
        /// Notes: Each generic vertex attribute array is initially disabled and isn't accessed when glDrawElements, 
        /// glDrawRangeElements, glDrawArrays, glMultiDrawArrays, or glMultiDrawElements is called.
        /// 
        /// GL_UNSIGNED_INT_10F_11F_11F_REV is accepted for type only if the GL version is 4.4 or higher.
        /// </remarks>
        /// <param name="index">Specifies the index of the generic vertex attribute to be modified.</param>
        /// <param name="size">Specifies the number of components per generic vertex attribute. Must be 1, 2, 3, 4. 
        /// Additionally, the symbolic constant GL_BGRA is accepted by glVertexAttribPointer. The initial value is 4.</param>
        /// <param name="type">Specifies the data type of each component in the array.</param>
        /// <param name="stride">Specifies the byte offset between consecutive generic vertex attributes. If stride is 0, the generic vertex attributes are understood to be tightly packed in the array. The initial value is 0.</param>
        /// <param name="pointer">Specifies a offset of the first component of the first generic vertex attribute in the array in the data store of the buffer currently bound to the GL_ARRAY_BUFFER target. The initial value is 0.</param>
        public static void VertexAttribLPointer(uint index, int size, GLDataTypes type, int stride, int pointer)
        {
            if (glVertexAttribLPointerPtr == IntPtr.Zero)
            {
                glVertexAttribLPointerPtr = Wgl.GetProcAddress("glVertexAttribLPointer");
                glVertexAttribLPointerDlg =
               Marshal.GetDelegateForFunctionPointer<glVertexAttribLPointer>(glVertexAttribLPointerPtr);
            }
            glVertexAttribLPointerDlg(index, size, type, stride, pointer);
        }

        /// <summary>
        /// Render primitives from array data
        /// </summary>
        /// <param name="mode">Specifies what kind of primitives to render.</param>
        /// <param name="start">Specifies the minimum array index contained in indices.</param>
        /// <param name="end">Specifies the maximum array index contained in indices.</param>
        /// <param name="count">Specifies the number of elements to be rendered.</param>
        /// <param name="type">Specifies the type of the values in indices. Must be one of GL_UNSIGNED_BYTE, GL_UNSIGNED_SHORT, or GL_UNSIGNED_INT.</param>
        /// <param name="indices">Specifies a pointer to the location where the indices are stored.</param>
        public static void DrawRangeElements(RenderModes mode, int start, int end, int count, GLDataTypes type, uint indices)
        {
            if (glDrawRangeElementsPtr == IntPtr.Zero)
            {
                glDrawRangeElementsPtr = Wgl.GetProcAddress("glDrawRangeElements");
                glDrawRangeElementsDlg =
               Marshal.GetDelegateForFunctionPointer<glDrawRangeElements>(glDrawRangeElementsPtr);
            }
            glDrawRangeElementsDlg(mode, start, end, count, type, indices);
        }

        /// <summary>
        /// Delete named buffer objects.
        /// 
        /// Deletes n buffer objects named by the elements of the array buffers. 
        /// After a buffer object is deleted, it has no contents, and its name is free for reuse 
        /// (for example by glGenBuffers). If a buffer object that is currently bound is deleted, 
        /// the binding reverts to 0 (the absence of any buffer object).
        /// 
        /// glDeleteBuffers silently ignores 0's and names that do not correspond to existing buffer objects.
        /// </summary>
        /// <param name="n">Specifies the number of buffer objects to be deleted.</param>
        /// <param name="buffers">Specifies an array of buffer objects to be deleted.</param>
        public static void DeleteBuffers(int n, uint[] buffers)
        {
            if (glDeleteBuffersPtr == IntPtr.Zero)
            {
                glDeleteBuffersPtr = Wgl.GetProcAddress("glDeleteBuffers");
                glDeleteBuffersDlg =
               Marshal.GetDelegateForFunctionPointer<glDeleteBuffers>(glDeleteBuffersPtr);
            }
            glDeleteBuffersDlg(n, buffers);
        }

        /// <summary>
        /// Delete named buffer object.
        /// </summary>
        /// <param name="buffer">Specifies the buffer object to be deleted.</param>
        public static void DeleteBuffer(uint buffer)
        {
            DeleteBuffers(1, new uint[] { buffer });
        }

        /// <summary>
        /// Delete vertex array objects.
        /// 
        /// Deletes n vertex array objects whose names are stored in the array addressed by arrays. 
        /// Once a vertex array object is deleted it has no contents and its name is again unused. 
        /// If a vertex array object that is currently bound is deleted, the binding for that object reverts to zero 
        /// and the default vertex array becomes current. 
        /// Unused names in arrays are silently ignored, as is the value zero.
        /// </summary>
        /// <param name="n">Specifies the number of vertex array objects to be deleted.</param>
        /// <param name="arrays">Specifies the address of an array containing the n names of the objects to be deleted.</param>
        public static void DeleteVertexArrays(int n, uint[] arrays)
        {
            if (glDeleteVertexArraysPtr == IntPtr.Zero)
            {
                glDeleteVertexArraysPtr = Wgl.GetProcAddress("glDeleteVertexArrays");
                glDeleteVertexArraysDlg =
               Marshal.GetDelegateForFunctionPointer<glDeleteVertexArrays>(glDeleteVertexArraysPtr);
            }
            glDeleteVertexArraysDlg(n, arrays);
        }

        /// <summary>
        /// Delete vertex array object.
        /// </summary>
        /// <param name="array">Specifies the address of the name of the object to be deleted.</param>
        public static void DeleteVertexArray(uint array)
        {
            DeleteVertexArrays(1, new uint[] { array });
        }

        /// <summary>
        /// Deletes a program object.
        /// 
        /// Frees the memory and invalidates the name associated with the program object specified by program. 
        /// This command effectively undoes the effects of a call to glCreateProgram.
        /// 
        /// If a program object is in use as part of current rendering state, it will be flagged for deletion, 
        /// but it will not be deleted until it is no longer part of current state for any rendering context.
        /// If a program object to be deleted has shader objects attached to it, those shader objects will be 
        /// automatically detached but not deleted unless they have already been flagged for deletion by a 
        /// previous call to glDeleteShader.
        /// A value of 0 for program will be silently ignored.
        /// 
        /// To determine whether a program object has been flagged for deletion, call glGetProgram with 
        /// arguments program and GL_DELETE_STATUS.
        /// 
        /// Errors: GL_INVALID_VALUE is generated if program is not a value generated by OpenGL.
        /// </summary>
        /// <param name="program">Specifies the program object to be deleted.</param>
        public static void DeleteProgram(uint program)
        {
            if (glDeleteProgramPtr == IntPtr.Zero)
            {
                glDeleteProgramPtr = Wgl.GetProcAddress("glDeleteProgram");
                glDeleteProgramDlg =
               Marshal.GetDelegateForFunctionPointer<glDeleteProgram>(glDeleteProgramPtr);
            }
            glDeleteProgramDlg(program);
        }

        /// <summary>
        /// Creates a shader object
        /// </summary>
        /// <remarks>
        /// Creates an empty shader object and returns a non-zero value by which it can be referenced. 
        /// A shader object is used to maintain the source code strings that define a shader. 
        /// shaderType indicates the type of shader to be created. Five types of shader are supported. 
        /// A shader of type GL_COMPUTE_SHADER is a shader that is intended to run on the programmable compute processor. 
        /// A shader of type GL_VERTEX_SHADER is a shader that is intended to run on the programmable vertex processor. 
        /// A shader of type GL_TESS_CONTROL_SHADER is a shader that is intended to run on the programmable tessellation 
        /// processor in the control stage. A shader of type GL_TESS_EVALUATION_SHADER is a shader that is intended to 
        /// run on the programmable tessellation processor in the evaluation stage. 
        /// A shader of type GL_GEOMETRY_SHADER is a shader that is intended to run on the programmable geometry processor. 
        /// A shader of type GL_FRAGMENT_SHADER is a shader that is intended to run on the programmable fragment processor.
        /// 
        /// When created, a shader object's GL_SHADER_TYPE parameter is set to either 
        /// GL_COMPUTE_SHADER, GL_VERTEX_SHADER, GL_TESS_CONTROL_SHADER, GL_TESS_EVALUATION_SHADER, 
        /// GL_GEOMETRY_SHADER or GL_FRAGMENT_SHADER, depending on the value of shaderType.
        /// </remarks>
        /// <param name="shaderType">Specifies the type of shader to be created.</param>
        /// <returns>A Shader Pointer Object</returns>
        public static uint CreateShader(ShaderProgramTypes shaderType)
        {
            if (glCreateShaderPtr == IntPtr.Zero)
            {
                glCreateShaderPtr = Wgl.GetProcAddress("glCreateShader");
                glCreateShaderDlg =
               Marshal.GetDelegateForFunctionPointer<glCreateShader>(glCreateShaderPtr);
            }
            return glCreateShaderDlg(shaderType);
        }

        /// <summary>
        /// Replaces the source code in a shader object.
        /// 
        /// Sets the source code in shader to the source code in the array of strings specified by string. 
        /// Any source code previously stored in the shader object is completely replaced. 
        /// The number of strings in the array is specified by count. 
        /// If length is NULL, each string is assumed to be null terminated. 
        /// If length is a value other than NULL, it points to an array containing a string length for each of the 
        /// corresponding elements of string. Each element in the length array may contain the length of the 
        /// corresponding string (the null character is not counted as part of the string length) or 
        /// a value less than 0 to indicate that the string is null terminated. 
        /// The source code strings are not scanned or parsed at this time; they are simply copied into the specified 
        /// shader object.
        /// 
        /// Notes
        /// OpenGL copies the shader source code strings when glShaderSource is called, so an application may free 
        /// its copy of the source code strings immediately after the function returns.
        /// </summary>
        /// <param name="shader">Specifies the handle of the shader object whose source code is to be replaced.</param>
        /// <param name="count">Specifies the number of elements in the string and length arrays.</param>
        /// <param name="str">Specifies an array of strings containing the source code to be loaded into the shader.</param>
        /// <param name="length">Specifies an array of string lengths.</param>
        public static void ShaderSource(uint shader, int count, string[] str, int[] length)
        {
            if (glShaderSourcePtr == IntPtr.Zero)
            {
                glShaderSourcePtr = Wgl.GetProcAddress("glShaderSource");
                glShaderSourceDlg =
               Marshal.GetDelegateForFunctionPointer<glShaderSource>(glShaderSourcePtr);
            }
            glShaderSourceDlg(shader, count, str, length);
        }

        /// <summary>
        /// Replaces the source code in a shader object.
        /// </summary>
        /// <param name="shader">Specifies the handle of the shader object whose source code is to be replaced.</param>
        /// <param name="shaderCode">Specifies an array strings containing the source code to be loaded into the shader.</param>
        public static void ShaderSource(uint shader, string[] shaderCode)
        {
            int count = 1;
            int[] lengths = new int[shaderCode.Length];

            for (int i = 0; i < shaderCode.Length; i++)
                lengths[i] = shaderCode[i].Length;

            ShaderSource(shader, count, shaderCode, lengths);
        }

        /// <summary>
        /// Replaces the source code in a shader object.
        /// </summary>
        /// <param name="shader">Specifies the handle of the shader object whose source code is to be replaced.</param>
        /// <param name="shaderCode">Specifies the source code to be loaded into the shader.</param>
        public static void ShaderSource(uint shader, string shaderCode)
        {
            int count = 1;
            string[] strings = new string[] { shaderCode };
            int[] lengths = new int[] { shaderCode.Length };

            ShaderSource(shader, count, strings, lengths);
        }

        /// <summary>
        /// Specifies the shader object to be compiled.
        /// 
        /// Compiles the source code strings that have been stored in the shader object specified by shader.
        ///  
        /// The compilation status will be stored as part of the shader object's state. 
        /// This value will be set to GL_TRUE if the shader was compiled without errors and is ready for use, 
        /// and GL_FALSE otherwise. It can be queried by calling glGetShader with arguments shader and GL_COMPILE_STATUS.
        ///  
        /// Compilation of a shader can fail for a number of reasons as specified by the 
        /// OpenGL Shading Language Specification.
        /// Whether or not the compilation was successful, information about the compilation can be obtained from 
        /// the shader object's information log by calling glGetShaderInfoLog.
        /// </summary>
        /// <param name="shader">Specifies the shader object to be compiled.</param>
        public static void CompileShader(uint shader)
        {
            if (glCompileShaderPtr == IntPtr.Zero)
            {
                glCompileShaderPtr = Wgl.GetProcAddress("glCompileShader");
                glCompileShaderDlg =
               Marshal.GetDelegateForFunctionPointer<glCompileShader>(glCompileShaderPtr);
            }
            glCompileShaderDlg(shader);
        }

        /// <summary>
        /// Returns a parameter from a shader object
        /// </summary>
        /// <param name="shader">Specifies the shader object to be queried.</param>
        /// <param name="pname">Specifies the object parameter.</param>
        /// <param name="parameters">Returns the requested object parameter.</param>
        public static void GetShaderiv(uint shader, ShaderParameters pname, out int parameters)
        {
            if (glGetShaderivPtr == IntPtr.Zero)
            {
                glGetShaderivPtr = Wgl.GetProcAddress("glGetShaderiv");
                glGetShaderivDlg =
               Marshal.GetDelegateForFunctionPointer<glGetShaderiv>(glGetShaderivPtr);
            }
            glGetShaderivDlg(shader, pname, out parameters);
        }

        /// <summary>
        /// Returns the information log for the specified shader object.
        /// </summary>
        /// <remarks>
        /// The information log for a shader object is modified when the shader is compiled. 
        /// The string that is returned will be null terminated.
        /// 
        /// glGetShaderInfoLog returns in infoLog as much of the information log as it can, up to a maximum of 
        /// maxLength characters.
        /// The number of characters actually returned, excluding the null termination character, is specified by length.
        /// If the length of the returned string is not required, a value of NULL can be passed in the length argument.
        /// The size of the buffer required to store the returned information log can be obtained by calling glGetShader 
        /// with the value GL_INFO_LOG_LENGTH.
        /// 
        /// The information log for a shader object is a string that may contain diagnostic messages, warning messages, 
        /// and other information about the last compile operation. When a shader object is created, 
        /// its information log will be a string of length 0.
        /// 
        /// Notes
        /// The information log for a shader object is the OpenGL implementer's primary mechanism for conveying
        /// information about the compilation process. Therefore, the information log can be helpful to application 
        /// developers during the development process, even when compilation is successful. Application developers 
        /// should not expect different OpenGL implementations to produce identical information logs.
        /// </remarks>
        /// <param name="shader">Specifies the shader object whose information log is to be queried.</param>
        /// <param name="maxLength">Specifies the size of the character buffer for storing the returned information log.</param>
        /// <param name="length">Returns the length of the string returned in infoLog (excluding the null terminator).</param>
        /// <param name="infoLog">Specifies an array of characters that is used to return the information log.</param>
        public static void GetShaderInfoLog(uint shader, int maxLength, out int length, out string infoLog)
        {
            if (glGetShaderInfoLogPtr == IntPtr.Zero)
            {
                glGetShaderInfoLogPtr = Wgl.GetProcAddress("glGetShaderInfoLog");
                glGetShaderInfoLogDlg =
               Marshal.GetDelegateForFunctionPointer<glGetShaderInfoLog>(glGetShaderInfoLogPtr);
            }
            byte[] errmessage = new byte[maxLength];
            GCHandle handle = GCHandle.Alloc(errmessage, GCHandleType.Pinned);
            glGetShaderInfoLogDlg(shader, maxLength, out length, handle.AddrOfPinnedObject());

            infoLog = MarshalHelper.PtrToStringUTF8(handle.AddrOfPinnedObject());

            handle.Free();
        }

        /// <summary>
        /// Creates a program object
        /// </summary>
        /// <remarks>
        /// Creates an empty program object and returns a non-zero value by which it can be referenced. 
        /// A program object is an object to which shader objects can be attached. 
        /// This provides a mechanism to specify the shader objects that will be linked to create a program. 
        /// It also provides a means for checking the compatibility of the shaders that will be used to create a program 
        /// (for instance, checking the compatibility between a vertex shader and a fragment shader). 
        /// When no longer needed as part of a program object, shader objects can be detached.
        /// 
        /// One or more executables are created in a program object by successfully attaching shader objects to it with 
        /// glAttachShader, successfully compiling the shader objects with glCompileShader, and successfully linking 
        /// the program object with glLinkProgram.These executables are made part of current state when glUseProgram 
        /// is called.Program objects can be deleted by calling glDeleteProgram.The memory associated with the 
        /// program object will be deleted when it is no longer part of current rendering state for any context.
        /// 
        /// Notes
        /// Like buffer and texture objects, the name space for program objects may be shared across a set of contexts, 
        /// as long as the server sides of the contexts share the same address space.If the name space is shared across 
        /// contexts, any attached objects and the data associated with those attached objects are shared as well.
        /// 
        /// Applications are responsible for providing the synchronization across API calls when objects are accessed 
        /// from different execution threads.
        /// 
        /// Errors
        /// This function returns 0 if an error occurs creating the program object.
        /// </remarks>
        /// <returns>The name of the newly created Program</returns>
        public static uint CreateProgram()
        {
            if (glCreateProgramPtr == IntPtr.Zero)
            {
                glCreateProgramPtr = Wgl.GetProcAddress("glCreateProgram");
                glCreateProgramDlg =
               Marshal.GetDelegateForFunctionPointer<glCreateProgram>(glCreateProgramPtr);
            }
            return glCreateProgramDlg();
        }

        /// <summary>
        /// Attaches a shader object to a program object
        /// </summary>
        /// <remarks>
        /// In order to create a complete shader program, there must be a way to specify the list of things that 
        /// will be linked together. Program objects provide this mechanism. Shaders that are to be linked together 
        /// in a program object must first be attached to that program object. 
        /// glAttachShader attaches the shader object specified by shader to the program object specified by program. 
        /// This indicates that shader will be included in link operations that will be performed on program.
        /// 
        /// All operations that can be performed on a shader object are valid whether or not the shader object is 
        /// attached to a program object. It is permissible to attach a shader object to a program object before 
        /// source code has been loaded into the shader object or before the shader object has been compiled.
        /// It is permissible to attach multiple shader objects of the same type because each may contain a portion 
        /// of the complete shader. It is also permissible to attach a shader object to more than one program object. 
        /// If a shader object is deleted while it is attached to a program object, it will be flagged for deletion, 
        /// and deletion will not occur until glDetachShader is called to detach it from all program objects to which 
        /// it is attached.
        /// </remarks>
        /// <param name="program">Specifies the program object to which a shader object will be attached.</param>
        /// <param name="shader">Specifies the shader object that is to be attached.</param>
        public static void AttachShader(uint program, uint shader)
        {
            if (glAttachShaderPtr == IntPtr.Zero)
            {
                glAttachShaderPtr = Wgl.GetProcAddress("glAttachShader");
                glAttachShaderDlg =
               Marshal.GetDelegateForFunctionPointer<glAttachShader>(glAttachShaderPtr);
            }
            glAttachShaderDlg(program, shader);
        }

        /// <summary>
        /// Links a program object
        /// </summary>
        /// <remarks>
        /// links the program object specified by program. If any shader objects of type GL_VERTEX_SHADER are attached to program,
        /// they will be used to create an executable that will run on the programmable vertex processor. 
        /// If any shader objects of type GL_GEOMETRY_SHADER are attached to program, they will be used to create an executable 
        /// that will run on the programmable geometry processor. 
        /// If any shader objects of type GL_FRAGMENT_SHADER are attached to program, they will be used to create an executable 
        /// that will run on the programmable fragment processor.
        /// 
        /// The status of the link operation will be stored as part of the program object's state. 
        /// This value will be set to GL_TRUE if the program object was linked without errors and is ready for use, 
        /// and GL_FALSE otherwise. It can be queried by calling glGetProgram with arguments program and GL_LINK_STATUS.
        /// 
        /// As a result of a successful link operation, all active user-defined uniform variables belonging to program will be 
        /// initialized to 0, and each of the program object's active uniform variables will be assigned a location that can be 
        /// queried by calling glGetUniformLocation. Also, any active user-defined attribute variables that have not been bound 
        /// to a generic vertex attribute index will be bound to one at this time.
        /// 
        /// Linking of a program object can fail for a number of reasons as specified in the OpenGL Shading Language Specification.
        /// The following lists some of the conditions that will cause a link error.
        /// 
        /// The number of active attribute variables supported by the implementation has been exceeded.
        /// 
        /// The storage limit for uniform variables has been exceeded.
        /// 
        /// The number of active uniform variables supported by the implementation has been exceeded.
        /// 
        /// The main function is missing for the vertex, geometry or fragment shader.
        /// 
        /// A varying variable actually used in the fragment shader is not declared in the same way (or is not declared at all) 
        /// in the vertex shader, or geometry shader if present.
        /// 
        /// A reference to a function or variable name is unresolved.
        /// 
        /// A shared global is declared with two different types or two different initial values.
        /// 
        /// One or more of the attached shader objects has not been successfully compiled.
        /// 
        /// Binding a generic attribute matrix caused some rows of the matrix to fall outside the allowed maximum of 
        /// GL_MAX_VERTEX_ATTRIBS.
        /// 
        /// Not enough contiguous vertex attribute slots could be found to bind attribute matrices.
        /// 
        /// The program object contains objects to form a fragment shader but does not contain objects to form a vertex shader.
        /// 
        /// The program object contains objects to form a geometry shader but does not contain objects to form a vertex shader.
        /// 
        /// The program object contains objects to form a geometry shader and the input primitive type, output primitive type, 
        /// or maximum output vertex count is not specified in any compiled geometry shader object.
        /// 
        /// The program object contains objects to form a geometry shader and the input primitive type, 
        /// output primitive type, or maximum output vertex count is specified differently in multiple geometry shader objects.
        /// 
        /// The number of active outputs in the fragment shader is greater than the value of GL_MAX_DRAW_BUFFERS.
        /// 
        /// The program has an active output assigned to a location greater than or equal to the value of 
        /// GL_MAX_DUAL_SOURCE_DRAW_BUFFERS and has an active output assigned an index greater than or equal to one.
        /// 
        /// More than one varying out variable is bound to the same number and index.
        /// 
        /// The explicit binding assigments do not leave enough space for the linker to automatically assign a 
        /// location for a varying out array, which requires multiple contiguous locations.
        /// 
        /// The count specified by glTransformFeedbackVaryings is non-zero, but the program object has no vertex or 
        /// geometry shader.
        /// 
        /// Any variable name specified to glTransformFeedbackVaryings in the varyings array is not declared as an output in the 
        /// vertex shader (or the geometry shader, if active).
        /// 
        /// Any two entries in the varyings array given glTransformFeedbackVaryings specify the same varying variable.
        /// 
        /// The total number of components to capture in any transform feedback varying variable is greater than 
        /// the constant GL_MAX_TRANSFORM_FEEDBACK_SEPARATE_COMPONENTS and the buffer mode is GL_SEPARATE_ATTRIBS.
        /// 
        /// When a program object has been successfully linked, the program object can be made part of current state by 
        /// calling glUseProgram.Whether or not the link operation was successful, the program object's information log 
        /// will be overwritten. The information log can be retrieved by calling glGetProgramInfoLog.
        /// 
        /// glLinkProgram will also install the generated executables as part of the current rendering state if the 
        /// link operation was successful and the specified program object is already currently in use as a result of a 
        /// previous call to glUseProgram. If the program object currently in use is relinked unsuccessfully, 
        /// its link status will be set to GL_FALSE, but the executables and associated state will remain part of the 
        /// current state until a subsequent call to glUseProgram removes it from use.After it is removed from use, 
        /// it cannot be made part of current state until it has been successfully relinked.
        /// 
        /// If program contains shader objects of type GL_VERTEX_SHADER, and optionally of type GL_GEOMETRY_SHADER, 
        /// but does not contain shader objects of type GL_FRAGMENT_SHADER, the vertex shader executable will be 
        /// installed on the programmable vertex processor, the geometry shader executable, if present, will be installed 
        /// on the programmable geometry processor, but no executable will be installed on the fragment processor. 
        /// The results of rasterizing primitives with such a program will be undefined.
        /// 
        /// The program object's information log is updated and the program is generated at the time of the link operation. 
        /// After the link operation, applications are free to modify attached shader objects, compile attached shader 
        /// objects, detach shader objects, delete shader objects, and attach additional shader objects. 
        /// None of these operations affects the information log or the program that is part of the program object.
        /// 
        /// Notes
        /// If the link operation is unsuccessful, any information about a previous link operation on program is lost 
        /// (i.e., a failed link does not restore the old state of program). Certain information can still be retrieved 
        /// from program even after an unsuccessful link operation.See for instance glGetActiveAttrib and 
        /// glGetActiveUniform.
        /// </remarks>
        /// <param name="program">Specifies the handle of the program object to be linked.</param>
        public static void LinkProgram(uint program)
        {
            if (glLinkProgramPtr == IntPtr.Zero)
            {
                glLinkProgramPtr = Wgl.GetProcAddress("glLinkProgram");
                glLinkProgramDlg =
               Marshal.GetDelegateForFunctionPointer<glLinkProgram>(glLinkProgramPtr);
            }
            glLinkProgramDlg(program);
        }

        /// <summary>
        /// Returns a parameter from a program object
        /// </summary>
        /// <param name="program">Specifies the program object to be queried.</param>
        /// <param name="pname">Specifies the object parameter.</param>
        /// <param name="parameters">Returns the requested object parameter.</param>
        public static void GetProgramiv(uint program, ProgramParameters pname, out int parameters)
        {
            if (glGetProgramivPtr == IntPtr.Zero)
            {
                glGetProgramivPtr = Wgl.GetProcAddress("glGetProgramiv");
                glGetProgramivDlg =
               Marshal.GetDelegateForFunctionPointer<glGetProgramiv>(glGetProgramivPtr);
            }
            glGetProgramivDlg(program, pname, out parameters);
        }

        /// <summary>
        /// Returns the information log for a program object
        /// </summary>
        /// <remarks>
        /// Returns the information log for the specified program object. 
        /// The information log for a program object is modified when the program object is linked or validated. 
        /// The string that is returned will be null terminated.
        /// 
        /// glGetProgramInfoLog returns in infoLog as much of the information log as it can, up to a maximum of 
        /// maxLength characters. The number of characters actually returned, excluding the null termination character, 
        /// is specified by length.If the length of the returned string is not required, a value of NULL can be 
        /// passed in the length argument. The size of the buffer required to store the returned information log can be 
        /// obtained by calling glGetProgram with the value GL_INFO_LOG_LENGTH.
        /// 
        /// The information log for a program object is either an empty string, or a string containing information 
        /// about the last link operation, or a string containing information about the last validation operation. 
        /// It may contain diagnostic messages, warning messages, and other information. 
        /// When a program object is created, its information log will be a string of length 0.
        /// 
        /// Notes
        /// The information log for a program object is the OpenGL implementer's primary mechanism for conveying 
        /// information about linking and validating. Therefore, the information log can be helpful to application 
        /// developers during the development process, even when these operations are successful. 
        /// Application developers should not expect different OpenGL implementations to produce identical information logs.
        /// </remarks>
        /// <param name="program">Specifies the program object whose information log is to be queried.</param>
        /// <param name="maxLength">Specifies the size of the character buffer for storing the returned information log.</param>
        /// <param name="length">Returns the length of the string returned in infoLog (excluding the null terminator).</param>
        /// <param name="infoLog">Specifies the string that is used to return the information log.</param>
        public static void GetProgramInfoLog(uint program, int maxLength, out int length, out string infoLog)
        {
            if (glGetProgramInfoLogPtr == IntPtr.Zero)
            {
                glGetProgramInfoLogPtr = Wgl.GetProcAddress("glGetProgramInfoLog");
                glGetProgramInfoLogDlg =
               Marshal.GetDelegateForFunctionPointer<glGetProgramInfoLog>(glGetProgramInfoLogPtr);
            }
            byte[] errmessage = new byte[maxLength];
            GCHandle handle = GCHandle.Alloc(errmessage, GCHandleType.Pinned);
            glGetProgramInfoLogDlg(program, maxLength, out length, handle.AddrOfPinnedObject());

            infoLog = MarshalHelper.PtrToStringUTF8(handle.AddrOfPinnedObject());

            handle.Free();
        }

        /// <summary>
        /// Detaches a shader object from a program object to which it is attached
        /// 
        /// Detaches the shader object specified by shader from the program object specified by program. 
        /// This command can be used to undo the effect of the command glAttachShader.
        /// 
        /// If shader has already been flagged for deletion by a call to glDeleteShader and it is not attached to any 
        /// other program object, it will be deleted after it has been detached.
        /// </summary>
        /// <param name="program">Specifies the program object from which to detach the shader object.</param>
        /// <param name="shader">Specifies the shader object to be detached.</param>
        public static void DetachShader(uint program, uint shader)
        {
            if (glDetachShaderPtr == IntPtr.Zero)
            {
                glDetachShaderPtr = Wgl.GetProcAddress("glDetachShader");
                glDetachShaderDlg =
               Marshal.GetDelegateForFunctionPointer<glDetachShader>(glDetachShaderPtr);
            }
            glDetachShaderDlg(program, shader);
        }

        /// <summary>
        /// Deletes a shader object
        /// </summary>
        /// <remarks>
        /// glDeleteShader frees the memory and invalidates the name associated with the shader object specified 
        /// by shader. This command effectively undoes the effects of a call to glCreateShader.
        /// 
        /// If a shader object to be deleted is attached to a program object, it will be flagged for deletion, 
        /// but it will not be deleted until it is no longer attached to any program object, for any rendering context
        /// (i.e., it must be detached from wherever it was attached before it will be deleted). 
        /// A value of 0 for shader will be silently ignored.
        /// 
        /// To determine whether an object has been flagged for deletion, call glGetShader with arguments shader and 
        /// GL_DELETE_STATUS.
        /// </remarks>
        /// <param name="shader">Specifies the shader object to be deleted.</param>
        public static void DeleteShader(uint shader)
        {
            if (glDeleteShaderPtr == IntPtr.Zero)
            {
                glDeleteShaderPtr = Wgl.GetProcAddress("glDeleteShader");
                glDeleteShaderDlg =
               Marshal.GetDelegateForFunctionPointer<glDeleteShader>(glDeleteShaderPtr);
            }
            glDeleteShaderDlg(shader);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object
        /// 
        /// glUniform modifies the value of a uniform variable or a uniform variable array. 
        /// The location of the uniform variable to be modified is specified by location, which should be a value
        /// returned by glGetUniformLocation. 
        /// glUniform operates on the program object that was made part of current state by calling glUseProgram.
        /// </summary>
        /// <param name="location">Specifies the location of the uniform variable to be modified.</param>
        /// <param name="v0">For the scalar commands, specifies the new values to be used for the specified uniform variable.</param>
        public static void Uniform1f(int location, float v0)
        {
            if (glUniform1fPtr == IntPtr.Zero)
            {
                glUniform1fPtr = Wgl.GetProcAddress("glUniform1f");
                glUniform1fDlg =
               Marshal.GetDelegateForFunctionPointer<glUniform1f>(glUniform1fPtr);
            }
            glUniform1fDlg(location, v0);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object
        /// 
        /// glUniform modifies the value of a uniform variable or a uniform variable array. 
        /// The location of the uniform variable to be modified is specified by location, which should be a value
        /// returned by glGetUniformLocation. 
        /// glUniform operates on the program object that was made part of current state by calling glUseProgram.
        /// </summary>
        /// <param name="location">Specifies the location of the uniform variable to be modified.</param>
        /// <param name="v0">For the scalar commands, specifies the new values to be used for the specified uniform variable.</param>
        /// <param name="v1">For the scalar commands, specifies the new values to be used for the specified uniform variable.</param>
        public static void Uniform2f(int location, float v0, float v1)
        {
            if (glUniform2fPtr == IntPtr.Zero)
            {
                glUniform2fPtr = Wgl.GetProcAddress("glUniform2f");
                glUniform2fDlg =
               Marshal.GetDelegateForFunctionPointer<glUniform2f>(glUniform2fPtr);
            }
            glUniform2fDlg(location, v0, v1);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object
        /// 
        /// glUniform modifies the value of a uniform variable or a uniform variable array. 
        /// The location of the uniform variable to be modified is specified by location, which should be a value
        /// returned by glGetUniformLocation. 
        /// glUniform operates on the program object that was made part of current state by calling glUseProgram.
        /// </summary>
        /// <param name="location">Specifies the location of the uniform variable to be modified.</param>
        /// <param name="v0">For the scalar commands, specifies the new values to be used for the specified uniform variable.</param>
        /// <param name="v1">For the scalar commands, specifies the new values to be used for the specified uniform variable.</param>
        /// <param name="v2">For the scalar commands, specifies the new values to be used for the specified uniform variable.</param>
        public static void Uniform3f(int location, float v0, float v1, float v2)
        {
            if (glUniform3fPtr == IntPtr.Zero)
            {
                glUniform3fPtr = Wgl.GetProcAddress("glUniform3f");
                glUniform3fDlg =
               Marshal.GetDelegateForFunctionPointer<glUniform3f>(glUniform3fPtr);
            }
            glUniform3fDlg(location, v0, v1, v2);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object
        /// 
        /// glUniform modifies the value of a uniform variable or a uniform variable array. 
        /// The location of the uniform variable to be modified is specified by location, which should be a value
        /// returned by glGetUniformLocation. 
        /// glUniform operates on the program object that was made part of current state by calling glUseProgram.
        /// </summary>
        /// <param name="location">Specifies the location of the uniform variable to be modified.</param>
        /// <param name="v0">For the scalar commands, specifies the new values to be used for the specified uniform variable.</param>
        /// <param name="v1">For the scalar commands, specifies the new values to be used for the specified uniform variable.</param>
        /// <param name="v2">For the scalar commands, specifies the new values to be used for the specified uniform variable.</param>
        /// <param name="v3">For the scalar commands, specifies the new values to be used for the specified uniform variable.</param>
        public static void Uniform4f(int location, float v0, float v1, float v2, float v3)
        {
            if (glUniform4fPtr == IntPtr.Zero)
            {
                glUniform4fPtr = Wgl.GetProcAddress("glUniform4f");
                glUniform4fDlg =
               Marshal.GetDelegateForFunctionPointer<glUniform4f>(glUniform4fPtr);
            }
            glUniform4fDlg(location, v0, v1, v2, v3);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object
        /// 
        /// glUniform modifies the value of a uniform variable or a uniform variable array. 
        /// The location of the uniform variable to be modified is specified by location, which should be a value
        /// returned by glGetUniformLocation. 
        /// glUniform operates on the program object that was made part of current state by calling glUseProgram.
        /// </summary>
        /// <param name="location">Specifies the location of the uniform variable to be modified.</param>
        /// <param name="v0">For the scalar commands, specifies the new values to be used for the specified uniform variable.</param>
        public static void Uniform1i(int location, int v0)
        {
            if (glUniform1iPtr == IntPtr.Zero)
            {
                glUniform1iPtr = Wgl.GetProcAddress("glUniform1i");
                glUniform1iDlg =
               Marshal.GetDelegateForFunctionPointer<glUniform1i>(glUniform1iPtr);
            }
            glUniform1iDlg(location, v0);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object
        /// 
        /// glUniform modifies the value of a uniform variable or a uniform variable array. 
        /// The location of the uniform variable to be modified is specified by location, which should be a value
        /// returned by glGetUniformLocation. 
        /// glUniform operates on the program object that was made part of current state by calling glUseProgram.
        /// </summary>
        /// <param name="location">Specifies the location of the uniform variable to be modified.</param>
        /// <param name="v0">For the scalar commands, specifies the new values to be used for the specified uniform variable.</param>
        /// <param name="v1">For the scalar commands, specifies the new values to be used for the specified uniform variable.</param>
        public static void Uniform2i(int location, int v0, int v1)
        {
            if (glUniform2iPtr == IntPtr.Zero)
            {
                glUniform2iPtr = Wgl.GetProcAddress("glUniform2i");
                glUniform2iDlg =
               Marshal.GetDelegateForFunctionPointer<glUniform2i>(glUniform2iPtr);
            }
            glUniform2iDlg(location, v0, v1);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object
        /// 
        /// glUniform modifies the value of a uniform variable or a uniform variable array. 
        /// The location of the uniform variable to be modified is specified by location, which should be a value
        /// returned by glGetUniformLocation. 
        /// glUniform operates on the program object that was made part of current state by calling glUseProgram.
        /// </summary>
        /// <param name="location">Specifies the location of the uniform variable to be modified.</param>
        /// <param name="v0">For the scalar commands, specifies the new values to be used for the specified uniform variable.</param>
        /// <param name="v1">For the scalar commands, specifies the new values to be used for the specified uniform variable.</param>
        /// <param name="v2">For the scalar commands, specifies the new values to be used for the specified uniform variable.</param>
        public static void Uniform3i(int location, int v0, int v1, int v2)
        {
            if (glUniform3iPtr == IntPtr.Zero)
            {
                glUniform3iPtr = Wgl.GetProcAddress("glUniform3i");
                glUniform3iDlg =
               Marshal.GetDelegateForFunctionPointer<glUniform3i>(glUniform3iPtr);
            }
            glUniform3iDlg(location, v0, v1, v2);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object
        /// 
        /// glUniform modifies the value of a uniform variable or a uniform variable array. 
        /// The location of the uniform variable to be modified is specified by location, which should be a value
        /// returned by glGetUniformLocation. 
        /// glUniform operates on the program object that was made part of current state by calling glUseProgram.
        /// </summary>
        /// <param name="location">Specifies the location of the uniform variable to be modified.</param>
        /// <param name="v0">For the scalar commands, specifies the new values to be used for the specified uniform variable.</param>
        /// <param name="v1">For the scalar commands, specifies the new values to be used for the specified uniform variable.</param>
        /// <param name="v2">For the scalar commands, specifies the new values to be used for the specified uniform variable.</param>
        /// <param name="v3">For the scalar commands, specifies the new values to be used for the specified uniform variable.</param>
        public static void Uniform4i(int location, int v0, int v1, int v2, int v3)
        {
            if (glUniform4iPtr == IntPtr.Zero)
            {
                glUniform4iPtr = Wgl.GetProcAddress("glUniform4i");
                glUniform4iDlg =
               Marshal.GetDelegateForFunctionPointer<glUniform4i>(glUniform4iPtr);
            }
            glUniform4iDlg(location, v0, v1, v2, v3);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object
        /// 
        /// glUniform modifies the value of a uniform variable or a uniform variable array. 
        /// The location of the uniform variable to be modified is specified by location, which should be a value
        /// returned by glGetUniformLocation. 
        /// glUniform operates on the program object that was made part of current state by calling glUseProgram.
        /// </summary>
        /// <param name="location">Specifies the location of the uniform variable to be modified.</param>
        /// <param name="v0">For the scalar commands, specifies the new values to be used for the specified uniform variable.</param>
        public static void Uniform1ui(int location, uint v0)
        {
            if (glUniform1uiPtr == IntPtr.Zero)
            {
                glUniform1uiPtr = Wgl.GetProcAddress("glUniform1ui");
                glUniform1uiDlg =
               Marshal.GetDelegateForFunctionPointer<glUniform1ui>(glUniform1uiPtr);
            }
            glUniform1uiDlg(location, v0);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object
        /// 
        /// glUniform modifies the value of a uniform variable or a uniform variable array. 
        /// The location of the uniform variable to be modified is specified by location, which should be a value
        /// returned by glGetUniformLocation. 
        /// glUniform operates on the program object that was made part of current state by calling glUseProgram.
        /// </summary>
        /// <param name="location">Specifies the location of the uniform variable to be modified.</param>
        /// <param name="v0">For the scalar commands, specifies the new values to be used for the specified uniform variable.</param>
        /// <param name="v1">For the scalar commands, specifies the new values to be used for the specified uniform variable.</param>
        public static void Uniform2ui(int location, uint v0, uint v1)
        {
            if (glUniform2uiPtr == IntPtr.Zero)
            {
                glUniform2uiPtr = Wgl.GetProcAddress("glUniform2ui");
                glUniform2uiDlg =
               Marshal.GetDelegateForFunctionPointer<glUniform2ui>(glUniform2uiPtr);
            }
            glUniform2uiDlg(location, v0, v1);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object
        /// 
        /// glUniform modifies the value of a uniform variable or a uniform variable array. 
        /// The location of the uniform variable to be modified is specified by location, which should be a value
        /// returned by glGetUniformLocation. 
        /// glUniform operates on the program object that was made part of current state by calling glUseProgram.
        /// </summary>
        /// <param name="location">Specifies the location of the uniform variable to be modified.</param>
        /// <param name="v0">For the scalar commands, specifies the new values to be used for the specified uniform variable.</param>
        /// <param name="v1">For the scalar commands, specifies the new values to be used for the specified uniform variable.</param>
        /// <param name="v2">For the scalar commands, specifies the new values to be used for the specified uniform variable.</param>
        public static void Uniform3ui(int location, uint v0, uint v1, uint v2)
        {
            if (glUniform3uiPtr == IntPtr.Zero)
            {
                glUniform3uiPtr = Wgl.GetProcAddress("glUniform3ui");
                glUniform3uiDlg =
               Marshal.GetDelegateForFunctionPointer<glUniform3ui>(glUniform3uiPtr);
            }
            glUniform3uiDlg(location, v0, v1, v2);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object
        /// 
        /// glUniform modifies the value of a uniform variable or a uniform variable array. 
        /// The location of the uniform variable to be modified is specified by location, which should be a value
        /// returned by glGetUniformLocation. 
        /// glUniform operates on the program object that was made part of current state by calling glUseProgram.
        /// </summary>
        /// <param name="location">Specifies the location of the uniform variable to be modified.</param>
        /// <param name="v0">For the scalar commands, specifies the new values to be used for the specified uniform variable.</param>
        /// <param name="v1">For the scalar commands, specifies the new values to be used for the specified uniform variable.</param>
        /// <param name="v2">For the scalar commands, specifies the new values to be used for the specified uniform variable.</param>
        /// <param name="v3">For the scalar commands, specifies the new values to be used for the specified uniform variable.</param>
        public static void Uniform4ui(int location, uint v0, uint v1, uint v2, uint v3)
        {
            if (glUniform4uiPtr == IntPtr.Zero)
            {
                glUniform4uiPtr = Wgl.GetProcAddress("glUniform4ui");
                glUniform4uiDlg =
               Marshal.GetDelegateForFunctionPointer<glUniform4ui>(glUniform4uiPtr);
            }
            glUniform4uiDlg(location, v0, v1, v2, v3);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object
        /// 
        /// glUniform modifies the value of a uniform variable or a uniform variable array. 
        /// The location of the uniform variable to be modified is specified by location, which should be a value
        /// returned by glGetUniformLocation. 
        /// glUniform operates on the program object that was made part of current state by calling glUseProgram.
        /// </summary>
        /// <param name="location">Specifies the location of the uniform variable to be modified.</param>
        /// <param name="count">Specifies the number of elements that are to be modified. This should be 1 if the 
        /// targeted uniform variable is not an array, and 1 or more if it is an array.</param>
        /// <param name="value">
        /// For the vector and matrix commands, specifies a pointer to an array of count values that will be 
        /// used to update the specified uniform variable.
        /// </param>
        public static void Uniform1fv(int location, int count, float[] value)
        {
            if (glUniform1fvPtr == IntPtr.Zero)
            {
                glUniform1fvPtr = Wgl.GetProcAddress("glUniform1fv");
                glUniform1fvDlg =
               Marshal.GetDelegateForFunctionPointer<glUniform1fv>(glUniform1fvPtr);
            }
            glUniform1fvDlg(location, count, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object
        /// 
        /// glUniform modifies the value of a uniform variable or a uniform variable array. 
        /// The location of the uniform variable to be modified is specified by location, which should be a value
        /// returned by glGetUniformLocation. 
        /// glUniform operates on the program object that was made part of current state by calling glUseProgram.
        /// </summary>
        /// <param name="location">Specifies the location of the uniform variable to be modified.</param>
        /// <param name="count">Specifies the number of elements that are to be modified. This should be 1 if the 
        /// targeted uniform variable is not an array, and 1 or more if it is an array.</param>
        /// <param name="value">
        /// For the vector and matrix commands, specifies a pointer to an array of count values that will be 
        /// used to update the specified uniform variable.
        /// </param>
        public static void Uniform2fv(int location, int count, float[] value)
        {
            if (glUniform2fvPtr == IntPtr.Zero)
            {
                glUniform2fvPtr = Wgl.GetProcAddress("glUniform2fv");
                glUniform2fvDlg =
               Marshal.GetDelegateForFunctionPointer<glUniform2fv>(glUniform2fvPtr);
            }
            glUniform2fvDlg(location, count, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object
        /// 
        /// glUniform modifies the value of a uniform variable or a uniform variable array. 
        /// The location of the uniform variable to be modified is specified by location, which should be a value
        /// returned by glGetUniformLocation. 
        /// glUniform operates on the program object that was made part of current state by calling glUseProgram.
        /// </summary>
        /// <param name="location">Specifies the location of the uniform variable to be modified.</param>
        /// <param name="count">Specifies the number of elements that are to be modified. This should be 1 if the 
        /// targeted uniform variable is not an array, and 1 or more if it is an array.</param>
        /// <param name="value">
        /// For the vector and matrix commands, specifies a pointer to an array of count values that will be 
        /// used to update the specified uniform variable.
        /// </param>
        public static void Uniform3fv(int location, int count, float[] value)
        {
            if (glUniform3fvPtr == IntPtr.Zero)
            {
                glUniform3fvPtr = Wgl.GetProcAddress("glUniform3fv");
                glUniform3fvDlg =
               Marshal.GetDelegateForFunctionPointer<glUniform3fv>(glUniform3fvPtr);
            }
            glUniform3fvDlg(location, count, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object
        /// 
        /// glUniform modifies the value of a uniform variable or a uniform variable array. 
        /// The location of the uniform variable to be modified is specified by location, which should be a value
        /// returned by glGetUniformLocation. 
        /// glUniform operates on the program object that was made part of current state by calling glUseProgram.
        /// </summary>
        /// <param name="location">Specifies the location of the uniform variable to be modified.</param>
        /// <param name="count">Specifies the number of elements that are to be modified. This should be 1 if the 
        /// targeted uniform variable is not an array, and 1 or more if it is an array.</param>
        /// <param name="value">
        /// For the vector and matrix commands, specifies a pointer to an array of count values that will be 
        /// used to update the specified uniform variable.
        /// </param>
        public static void Uniform4fv(int location, int count, float[] value)
        {
            if (glUniform4fvPtr == IntPtr.Zero)
            {
                glUniform4fvPtr = Wgl.GetProcAddress("glUniform4fv");
                glUniform4fvDlg =
               Marshal.GetDelegateForFunctionPointer<glUniform4fv>(glUniform4fvPtr);
            }
            glUniform4fvDlg(location, count, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object
        /// 
        /// glUniform modifies the value of a uniform variable or a uniform variable array. 
        /// The location of the uniform variable to be modified is specified by location, which should be a value
        /// returned by glGetUniformLocation. 
        /// glUniform operates on the program object that was made part of current state by calling glUseProgram.
        /// </summary>
        /// <param name="location">Specifies the location of the uniform variable to be modified.</param>
        /// <param name="count">Specifies the number of elements that are to be modified. This should be 1 if the 
        /// targeted uniform variable is not an array, and 1 or more if it is an array.</param>
        /// <param name="value">
        /// For the vector and matrix commands, specifies a pointer to an array of count values that will be 
        /// used to update the specified uniform variable.
        /// </param>
        public static void Uniform1iv(int location, int count, int[] value)
        {
            if (glUniform1ivPtr == IntPtr.Zero)
            {
                glUniform1ivPtr = Wgl.GetProcAddress("glUniform1iv");
                glUniform1ivDlg =
               Marshal.GetDelegateForFunctionPointer<glUniform1iv>(glUniform1ivPtr);
            }
            glUniform1ivDlg(location, count, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object
        /// 
        /// glUniform modifies the value of a uniform variable or a uniform variable array. 
        /// The location of the uniform variable to be modified is specified by location, which should be a value
        /// returned by glGetUniformLocation. 
        /// glUniform operates on the program object that was made part of current state by calling glUseProgram.
        /// </summary>
        /// <param name="location">Specifies the location of the uniform variable to be modified.</param>
        /// <param name="count">Specifies the number of elements that are to be modified. This should be 1 if the 
        /// targeted uniform variable is not an array, and 1 or more if it is an array.</param>
        /// <param name="value">
        /// For the vector and matrix commands, specifies a pointer to an array of count values that will be 
        /// used to update the specified uniform variable.
        /// </param>
        public static void Uniform2iv(int location, int count, int[] value)
        {
            if (glUniform2ivPtr == IntPtr.Zero)
            {
                glUniform2ivPtr = Wgl.GetProcAddress("glUniform2iv");
                glUniform2ivDlg =
               Marshal.GetDelegateForFunctionPointer<glUniform2iv>(glUniform2ivPtr);
            }
            glUniform2ivDlg(location, count, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object
        /// 
        /// glUniform modifies the value of a uniform variable or a uniform variable array. 
        /// The location of the uniform variable to be modified is specified by location, which should be a value
        /// returned by glGetUniformLocation. 
        /// glUniform operates on the program object that was made part of current state by calling glUseProgram.
        /// </summary>
        /// <param name="location">Specifies the location of the uniform variable to be modified.</param>
        /// <param name="count">Specifies the number of elements that are to be modified. This should be 1 if the 
        /// targeted uniform variable is not an array, and 1 or more if it is an array.</param>
        /// <param name="value">
        /// For the vector and matrix commands, specifies a pointer to an array of count values that will be 
        /// used to update the specified uniform variable.
        /// </param>
        public static void Uniform3iv(int location, int count, int[] value)
        {
            if (glUniform3ivPtr == IntPtr.Zero)
            {
                glUniform3ivPtr = Wgl.GetProcAddress("glUniform3iv");
                glUniform3ivDlg =
               Marshal.GetDelegateForFunctionPointer<glUniform3iv>(glUniform3ivPtr);
            }
            glUniform3ivDlg(location, count, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object
        /// 
        /// glUniform modifies the value of a uniform variable or a uniform variable array. 
        /// The location of the uniform variable to be modified is specified by location, which should be a value
        /// returned by glGetUniformLocation. 
        /// glUniform operates on the program object that was made part of current state by calling glUseProgram.
        /// </summary>
        /// <param name="location">Specifies the location of the uniform variable to be modified.</param>
        /// <param name="count">Specifies the number of elements that are to be modified. This should be 1 if the 
        /// targeted uniform variable is not an array, and 1 or more if it is an array.</param>
        /// <param name="value">
        /// For the vector and matrix commands, specifies a pointer to an array of count values that will be 
        /// used to update the specified uniform variable.
        /// </param>
        public static void Uniform4iv(int location, int count, int[] value)
        {
            if (glUniform4ivPtr == IntPtr.Zero)
            {
                glUniform4ivPtr = Wgl.GetProcAddress("glUniform4iv");
                glUniform4ivDlg =
               Marshal.GetDelegateForFunctionPointer<glUniform4iv>(glUniform4ivPtr);
            }
            glUniform4ivDlg(location, count, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object
        /// 
        /// glUniform modifies the value of a uniform variable or a uniform variable array. 
        /// The location of the uniform variable to be modified is specified by location, which should be a value
        /// returned by glGetUniformLocation. 
        /// glUniform operates on the program object that was made part of current state by calling glUseProgram.
        /// </summary>
        /// <param name="location">Specifies the location of the uniform variable to be modified.</param>
        /// <param name="count">Specifies the number of elements that are to be modified. This should be 1 if the 
        /// targeted uniform variable is not an array, and 1 or more if it is an array.</param>
        /// <param name="value">
        /// For the vector and matrix commands, specifies a pointer to an array of count values that will be 
        /// used to update the specified uniform variable.
        /// </param>
        public static void Uniform1uiv(int location, int count, uint[] value)
        {
            if (glUniform1uivPtr == IntPtr.Zero)
            {
                glUniform1uivPtr = Wgl.GetProcAddress("glUniform1uiv");
                glUniform1uivDlg =
               Marshal.GetDelegateForFunctionPointer<glUniform1uiv>(glUniform1uivPtr);
            }
            glUniform1uivDlg(location, count, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object
        /// 
        /// glUniform modifies the value of a uniform variable or a uniform variable array. 
        /// The location of the uniform variable to be modified is specified by location, which should be a value
        /// returned by glGetUniformLocation. 
        /// glUniform operates on the program object that was made part of current state by calling glUseProgram.
        /// </summary>
        /// <param name="location">Specifies the location of the uniform variable to be modified.</param>
        /// <param name="count">Specifies the number of elements that are to be modified. This should be 1 if the 
        /// targeted uniform variable is not an array, and 1 or more if it is an array.</param>
        /// <param name="value">
        /// For the vector and matrix commands, specifies a pointer to an array of count values that will be 
        /// used to update the specified uniform variable.
        /// </param>
        public static void Uniform2uiv(int location, int count, uint[] value)
        {
            if (glUniform2uivPtr == IntPtr.Zero)
            {
                glUniform2uivPtr = Wgl.GetProcAddress("glUniform2uiv");
                glUniform2uivDlg =
               Marshal.GetDelegateForFunctionPointer<glUniform2uiv>(glUniform2uivPtr);
            }
            glUniform2uivDlg(location, count, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object
        /// 
        /// glUniform modifies the value of a uniform variable or a uniform variable array. 
        /// The location of the uniform variable to be modified is specified by location, which should be a value
        /// returned by glGetUniformLocation. 
        /// glUniform operates on the program object that was made part of current state by calling glUseProgram.
        /// </summary>
        /// <param name="location">Specifies the location of the uniform variable to be modified.</param>
        /// <param name="count">Specifies the number of elements that are to be modified. This should be 1 if the 
        /// targeted uniform variable is not an array, and 1 or more if it is an array.</param>
        /// <param name="value">
        /// For the vector and matrix commands, specifies a pointer to an array of count values that will be 
        /// used to update the specified uniform variable.
        /// </param>
        public static void Uniform3uiv(int location, int count, uint[] value)
        {
            if (glUniform3uivPtr == IntPtr.Zero)
            {
                glUniform3uivPtr = Wgl.GetProcAddress("glUniform3uiv");
                glUniform3uivDlg =
               Marshal.GetDelegateForFunctionPointer<glUniform3uiv>(glUniform3uivPtr);
            }
            glUniform3uivDlg(location, count, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object
        /// 
        /// glUniform modifies the value of a uniform variable or a uniform variable array. 
        /// The location of the uniform variable to be modified is specified by location, which should be a value
        /// returned by glGetUniformLocation. 
        /// glUniform operates on the program object that was made part of current state by calling glUseProgram.
        /// </summary>
        /// <param name="location">Specifies the location of the uniform variable to be modified.</param>
        /// <param name="count">Specifies the number of elements that are to be modified. This should be 1 if the 
        /// targeted uniform variable is not an array, and 1 or more if it is an array.</param>
        /// <param name="value">
        /// For the vector and matrix commands, specifies a pointer to an array of count values that will be 
        /// used to update the specified uniform variable.
        /// </param>
        public static void Uniform4uiv(int location, int count, uint[] value)
        {
            if (glUniform4uivPtr == IntPtr.Zero)
            {
                glUniform4uivPtr = Wgl.GetProcAddress("glUniform4uiv");
                glUniform4uivDlg =
               Marshal.GetDelegateForFunctionPointer<glUniform4uiv>(glUniform4uivPtr);
            }
            glUniform4uivDlg(location, count, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object
        /// 
        /// glUniform modifies the value of a uniform variable or a uniform variable array. 
        /// The location of the uniform variable to be modified is specified by location, which should be a value
        /// returned by glGetUniformLocation. 
        /// glUniform operates on the program object that was made part of current state by calling glUseProgram.
        /// </summary>
        /// <param name="location">Specifies the location of the uniform variable to be modified.</param>
        /// <param name="count">
        /// Specifies the number of matrices that are to be modified. This should be 1 if the targeted uniform 
        /// variable is not an array of matrices, and 1 or more if it is an array of matrices.</param>
        /// <param name="transpose">For the matrix commands, specifies whether to transpose the matrix as the values are loaded into the uniform variable.</param>
        /// <param name="value">
        /// For the vector and matrix commands, specifies a pointer to an array of count values that will be 
        /// used to update the specified uniform variable.
        /// </param>
        public static void UniformMatrix2fv(int location, int count, bool transpose, float[] value)
        {
            if (glUniformMatrix2fvPtr == IntPtr.Zero)
            {
                glUniformMatrix2fvPtr = Wgl.GetProcAddress("glUniformMatrix2fv");
                glUniformMatrix2fvDlg =
               Marshal.GetDelegateForFunctionPointer<glUniformMatrix2fv>(glUniformMatrix2fvPtr);
            }
            glUniformMatrix2fvDlg(location, count, transpose, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object
        /// 
        /// glUniform modifies the value of a uniform variable or a uniform variable array. 
        /// The location of the uniform variable to be modified is specified by location, which should be a value
        /// returned by glGetUniformLocation. 
        /// glUniform operates on the program object that was made part of current state by calling glUseProgram.
        /// </summary>
        /// <param name="location">Specifies the location of the uniform variable to be modified.</param>
        /// <param name="count">
        /// Specifies the number of matrices that are to be modified. This should be 1 if the targeted uniform 
        /// variable is not an array of matrices, and 1 or more if it is an array of matrices.</param>
        /// <param name="transpose">For the matrix commands, specifies whether to transpose the matrix as the values are loaded into the uniform variable.</param>
        /// <param name="value">
        /// For the vector and matrix commands, specifies a pointer to an array of count values that will be 
        /// used to update the specified uniform variable.
        /// </param>
        public static void UniformMatrix3fv(int location, int count, bool transpose, float[] value)
        {
            if (glUniformMatrix3fvPtr == IntPtr.Zero)
            {
                glUniformMatrix3fvPtr = Wgl.GetProcAddress("glUniformMatrix3fv");
                glUniformMatrix3fvDlg =
               Marshal.GetDelegateForFunctionPointer<glUniformMatrix3fv>(glUniformMatrix3fvPtr);
            }
            glUniformMatrix3fvDlg(location, count, transpose, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object
        /// 
        /// glUniform modifies the value of a uniform variable or a uniform variable array. 
        /// The location of the uniform variable to be modified is specified by location, which should be a value
        /// returned by glGetUniformLocation. 
        /// glUniform operates on the program object that was made part of current state by calling glUseProgram.
        /// </summary>
        /// <param name="location">Specifies the location of the uniform variable to be modified.</param>
        /// <param name="count">
        /// Specifies the number of matrices that are to be modified. This should be 1 if the targeted uniform 
        /// variable is not an array of matrices, and 1 or more if it is an array of matrices.</param>
        /// <param name="transpose">For the matrix commands, specifies whether to transpose the matrix as the values are loaded into the uniform variable.</param>
        /// <param name="mat">
        /// Specifies a Matrix4x4 
        /// used to update the specified uniform variable.
        /// </param>
        public static void UniformMatrix3fv(int location, int count, bool transpose, Matrix3x3 mat)
        {
            if (glUniformMatrix3fvPtr == IntPtr.Zero)
            {
                glUniformMatrix3fvPtr = Wgl.GetProcAddress("glUniformMatrix3fv");
                glUniformMatrix3fvDlg =
               Marshal.GetDelegateForFunctionPointer<glUniformMatrix3fv>(glUniformMatrix3fvPtr);
            }
            glUniformMatrix3fvDlg(location, count, transpose, new float[] {
                        mat.M11, mat.M12, mat.M13,
                        mat.M21, mat.M22, mat.M23,
                        mat.M31, mat.M32, mat.M33
                    });
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object
        /// 
        /// glUniform modifies the value of a uniform variable or a uniform variable array. 
        /// The location of the uniform variable to be modified is specified by location, which should be a value
        /// returned by glGetUniformLocation. 
        /// glUniform operates on the program object that was made part of current state by calling glUseProgram.
        /// </summary>
        /// <param name="location">Specifies the location of the uniform variable to be modified.</param>
        /// <param name="count">
        /// Specifies the number of matrices that are to be modified. This should be 1 if the targeted uniform 
        /// variable is not an array of matrices, and 1 or more if it is an array of matrices.</param>
        /// <param name="transpose">For the matrix commands, specifies whether to transpose the matrix as the values are loaded into the uniform variable.</param>
        /// <param name="value">
        /// For the vector and matrix commands, specifies a pointer to an array of count values that will be 
        /// used to update the specified uniform variable.
        /// </param>
        public static void UniformMatrix4fv(int location, int count, bool transpose, float[] value)
        {
            if (glUniformMatrix4fvPtr == IntPtr.Zero)
            {
                glUniformMatrix4fvPtr = Wgl.GetProcAddress("glUniformMatrix4fv");
                glUniformMatrix4fvDlg =
               Marshal.GetDelegateForFunctionPointer<glUniformMatrix4fv>(glUniformMatrix4fvPtr);
            }
            glUniformMatrix4fvDlg(location, count, transpose, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object
        /// 
        /// glUniform modifies the value of a uniform variable or a uniform variable array. 
        /// The location of the uniform variable to be modified is specified by location, which should be a value
        /// returned by glGetUniformLocation. 
        /// glUniform operates on the program object that was made part of current state by calling glUseProgram.
        /// </summary>
        /// <param name="location">Specifies the location of the uniform variable to be modified.</param>
        /// <param name="count">
        /// Specifies the number of matrices that are to be modified. This should be 1 if the targeted uniform 
        /// variable is not an array of matrices, and 1 or more if it is an array of matrices.</param>
        /// <param name="transpose">For the matrix commands, specifies whether to transpose the matrix as the values are loaded into the uniform variable.</param>
        /// <param name="mat">
        /// For the vector and matrix commands, specifies a pointer to an array of count values that will be 
        /// used to update the specified uniform variable.
        /// </param>
        public static void UniformMatrix4fv(int location, int count, bool transpose, Matrix4x4 mat)
        {
            UniformMatrix4fv(location, count, transpose,
                             new float[] {
                        mat.M11, mat.M12, mat.M13, mat.M14,
                        mat.M21, mat.M22, mat.M23, mat.M24,
                        mat.M31, mat.M32, mat.M33, mat.M34,
                        mat.M41, mat.M42, mat.M43, mat.M44,
                    }
                );
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object
        /// 
        /// glUniform modifies the value of a uniform variable or a uniform variable array. 
        /// The location of the uniform variable to be modified is specified by location, which should be a value
        /// returned by glGetUniformLocation. 
        /// glUniform operates on the program object that was made part of current state by calling glUseProgram.
        /// </summary>
        /// <param name="location">Specifies the location of the uniform variable to be modified.</param>
        /// <param name="count">
        /// Specifies the number of matrices that are to be modified. This should be 1 if the targeted uniform 
        /// variable is not an array of matrices, and 1 or more if it is an array of matrices.</param>
        /// <param name="transpose">For the matrix commands, specifies whether to transpose the matrix as the values are loaded into the uniform variable.</param>
        /// <param name="value">
        /// For the vector and matrix commands, specifies a pointer to an array of count values that will be 
        /// used to update the specified uniform variable.
        /// </param>
        public static void UniformMatrix2x3fv(int location, int count, bool transpose, float[] value)
        {
            if (glUniformMatrix2x3fvPtr == IntPtr.Zero)
            {
                glUniformMatrix2x3fvPtr = Wgl.GetProcAddress("glUniformMatrix2x3fv");
                glUniformMatrix2x3fvDlg =
               Marshal.GetDelegateForFunctionPointer<glUniformMatrix2x3fv>(glUniformMatrix2x3fvPtr);
            }
            glUniformMatrix2x3fvDlg(location, count, transpose, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object
        /// 
        /// glUniform modifies the value of a uniform variable or a uniform variable array. 
        /// The location of the uniform variable to be modified is specified by location, which should be a value
        /// returned by glGetUniformLocation. 
        /// glUniform operates on the program object that was made part of current state by calling glUseProgram.
        /// </summary>
        /// <param name="location">Specifies the location of the uniform variable to be modified.</param>
        /// <param name="count">
        /// Specifies the number of matrices that are to be modified. This should be 1 if the targeted uniform 
        /// variable is not an array of matrices, and 1 or more if it is an array of matrices.</param>
        /// <param name="transpose">For the matrix commands, specifies whether to transpose the matrix as the values are loaded into the uniform variable.</param>
        /// <param name="value">
        /// For the vector and matrix commands, specifies a pointer to an array of count values that will be 
        /// used to update the specified uniform variable.
        /// </param>
        public static void UniformMatrix3x2fv(int location, int count, bool transpose, float[] value)
        {
            if (glUniformMatrix3x2fvPtr == IntPtr.Zero)
            {
                glUniformMatrix3x2fvPtr = Wgl.GetProcAddress("glUniformMatrix3x2fv");
                glUniformMatrix3x2fvDlg =
               Marshal.GetDelegateForFunctionPointer<glUniformMatrix3x2fv>(glUniformMatrix3x2fvPtr);
            }
            glUniformMatrix3x2fvDlg(location, count, transpose, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object
        /// 
        /// glUniform modifies the value of a uniform variable or a uniform variable array. 
        /// The location of the uniform variable to be modified is specified by location, which should be a value
        /// returned by glGetUniformLocation. 
        /// glUniform operates on the program object that was made part of current state by calling glUseProgram.
        /// </summary>
        /// <param name="location">Specifies the location of the uniform variable to be modified.</param>
        /// <param name="count">
        /// Specifies the number of matrices that are to be modified. This should be 1 if the targeted uniform 
        /// variable is not an array of matrices, and 1 or more if it is an array of matrices.</param>
        /// <param name="transpose">For the matrix commands, specifies whether to transpose the matrix as the values are loaded into the uniform variable.</param>
        /// <param name="value">
        /// For the vector and matrix commands, specifies a pointer to an array of count values that will be 
        /// used to update the specified uniform variable.
        /// </param>
        public static void UniformMatrix2x4fv(int location, int count, bool transpose, float[] value)
        {
            if (glUniformMatrix2x4fvPtr == IntPtr.Zero)
            {
                glUniformMatrix2x4fvPtr = Wgl.GetProcAddress("glUniformMatrix2x4fv");
                glUniformMatrix2x4fvDlg =
               Marshal.GetDelegateForFunctionPointer<glUniformMatrix2x4fv>(glUniformMatrix2x4fvPtr);
            }
            glUniformMatrix2x4fvDlg(location, count, transpose, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object
        /// 
        /// glUniform modifies the value of a uniform variable or a uniform variable array. 
        /// The location of the uniform variable to be modified is specified by location, which should be a value
        /// returned by glGetUniformLocation. 
        /// glUniform operates on the program object that was made part of current state by calling glUseProgram.
        /// </summary>
        /// <param name="location">Specifies the location of the uniform variable to be modified.</param>
        /// <param name="count">
        /// Specifies the number of matrices that are to be modified. This should be 1 if the targeted uniform 
        /// variable is not an array of matrices, and 1 or more if it is an array of matrices.</param>
        /// <param name="transpose">For the matrix commands, specifies whether to transpose the matrix as the values are loaded into the uniform variable.</param>
        /// <param name="value">
        /// For the vector and matrix commands, specifies a pointer to an array of count values that will be 
        /// used to update the specified uniform variable.
        /// </param>
        public static void UniformMatrix4x2fv(int location, int count, bool transpose, float[] value)
        {
            if (glUniformMatrix4x2fvPtr == IntPtr.Zero)
            {
                glUniformMatrix4x2fvPtr = Wgl.GetProcAddress("glUniformMatrix4x2fv");
                glUniformMatrix4x2fvDlg =
               Marshal.GetDelegateForFunctionPointer<glUniformMatrix4x2fv>(glUniformMatrix4x2fvPtr);
            }
            glUniformMatrix4x2fvDlg(location, count, transpose, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object
        /// 
        /// glUniform modifies the value of a uniform variable or a uniform variable array. 
        /// The location of the uniform variable to be modified is specified by location, which should be a value
        /// returned by glGetUniformLocation. 
        /// glUniform operates on the program object that was made part of current state by calling glUseProgram.
        /// </summary>
        /// <param name="location">Specifies the location of the uniform variable to be modified.</param>
        /// <param name="count">
        /// Specifies the number of matrices that are to be modified. This should be 1 if the targeted uniform 
        /// variable is not an array of matrices, and 1 or more if it is an array of matrices.</param>
        /// <param name="transpose">For the matrix commands, specifies whether to transpose the matrix as the values are loaded into the uniform variable.</param>
        /// <param name="value">
        /// For the vector and matrix commands, specifies a pointer to an array of count values that will be 
        /// used to update the specified uniform variable.
        /// </param>
        public static void UniformMatrix3x4fv(int location, int count, bool transpose, float[] value)
        {
            if (glUniformMatrix3x4fvPtr == IntPtr.Zero)
            {
                glUniformMatrix3x4fvPtr = Wgl.GetProcAddress("glUniformMatrix3x4fv");
                glUniformMatrix3x4fvDlg =
               Marshal.GetDelegateForFunctionPointer<glUniformMatrix3x4fv>(glUniformMatrix3x4fvPtr);
            }
            glUniformMatrix3x4fvDlg(location, count, transpose, value);
        }

        /// <summary>
        /// Specify the value of a uniform variable for the current program object
        /// 
        /// glUniform modifies the value of a uniform variable or a uniform variable array. 
        /// The location of the uniform variable to be modified is specified by location, which should be a value
        /// returned by glGetUniformLocation. 
        /// glUniform operates on the program object that was made part of current state by calling glUseProgram.
        /// </summary>
        /// <param name="location">Specifies the location of the uniform variable to be modified.</param>
        /// <param name="count">
        /// Specifies the number of matrices that are to be modified. This should be 1 if the targeted uniform 
        /// variable is not an array of matrices, and 1 or more if it is an array of matrices.</param>
        /// <param name="transpose">For the matrix commands, specifies whether to transpose the matrix as the values are loaded into the uniform variable.</param>
        /// <param name="value">
        /// For the vector and matrix commands, specifies a pointer to an array of count values that will be 
        /// used to update the specified uniform variable.
        /// </param>
        public static void UniformMatrix4x3fv(int location, int count, bool transpose, float[] value)
        {
            if (glUniformMatrix4x3fvPtr == IntPtr.Zero)
            {
                glUniformMatrix4x3fvPtr = Wgl.GetProcAddress("glUniformMatrix4x3fv");
                glUniformMatrix4x3fvDlg =
               Marshal.GetDelegateForFunctionPointer<glUniformMatrix4x3fv>(glUniformMatrix4x3fvPtr);
            }
            glUniformMatrix4x3fvDlg(location, count, transpose, value);
        }

        /// <summary>
        /// Returns the location of a uniform variable
        /// </summary>
        /// <remarks>
        /// glGetUniformLocation returns an integer that represents the location of a specific uniform variable within a 
        /// program object. name must be a null terminated string that contains no white space. name must be an active 
        /// uniform variable name in program that is not a structure, an array of structures, or a subcomponent of a 
        /// vector or a matrix. This function returns -1 if name does not correspond to an active uniform variable in 
        /// program, if name starts with the reserved prefix "gl_", or if name is associated with an atomic counter or a 
        /// named uniform block.
        /// 
        /// Uniform variables that are structures or arrays of structures may be queried by calling glGetUniformLocation 
        /// for each field within the structure.The array element operator "[]" and the structure field operator "." 
        /// may be used in name in order to select elements within an array or fields within a structure. 
        /// The result of using these operators is not allowed to be another structure, an array of structures, 
        /// or a subcomponent of a vector or a matrix.
        /// Except if the last part of name indicates a uniform variable array, the location of the first element of an 
        /// array can be retrieved by using the name of the array, or by using the name appended by "[0]".
        /// 
        /// The actual locations assigned to uniform variables are not known until the program object is linked 
        /// successfully.After linking has occurred, the command glGetUniformLocation can be used to obtain the 
        /// location of a uniform variable. This location value can then be passed to glUniform to set the value of the 
        /// uniform variable or to glGetUniform in order to query the current value of the uniform variable. 
        /// After a program object has been linked successfully, the index values for uniform variables remain fixed 
        /// until the next link command occurs. Uniform variable locations and values can only be queried after a 
        /// link if the link was successful.
        /// 
        /// Errors
        /// GL_INVALID_VALUE is generated if program is not a value generated by OpenGL.
        /// GL_INVALID_OPERATION is generated if program is not a program object.
        /// GL_INVALID_OPERATION is generated if program has not been successfully linked.
        /// </remarks>
        /// <param name="program">Specifies the program object to be queried.</param>
        /// <param name="name">Points to a null terminated string containing the name of the uniform variable whose location is to be queried.</param>
        /// <returns>An integer that represents the location of a specific uniform variable within a program object.</returns>
        public static int GetUniformLocation(uint program, string name)
        {
            if (glGetUniformLocationPtr == IntPtr.Zero)
            {
                glGetUniformLocationPtr = Wgl.GetProcAddress("glGetUniformLocation");
                glGetUniformLocationDlg =
               Marshal.GetDelegateForFunctionPointer<glGetUniformLocation>(glGetUniformLocationPtr);
            }
            return glGetUniformLocationDlg(program, name);
        }

        /// <summary>
        /// Returns the value of a uniform variable.
        /// </summary>
        /// <param name="program">Specifies the program object to be queried.</param>
        /// <param name="location">Specifies the location of the uniform variable to be queried.</param>
        /// <param name="parameter">Returns the value of the specified uniform variable.</param>
        public static void GetUniformfv(uint program, int location, out float parameter)
        {
            if (glGetUniformfvPtr == IntPtr.Zero)
            {
                glGetUniformfvPtr = Wgl.GetProcAddress("glGetUniformfv");
                glGetUniformfvDlg =
               Marshal.GetDelegateForFunctionPointer<glGetUniformfv>(glGetUniformfvPtr);
            }
            glGetUniformfvDlg(program, location, out parameter);
        }

        /// <summary>
        /// Returns the value of a uniform variable.
        /// </summary>
        /// <param name="program">Specifies the program object to be queried.</param>
        /// <param name="location">Specifies the location of the uniform variable to be queried.</param>
        /// <param name="parameter">Returns the value of the specified uniform variable.</param>
        public static void GetUniformiv(uint program, int location, out int parameter)
        {
            if (glGetUniformivPtr == IntPtr.Zero)
            {
                glGetUniformivPtr = Wgl.GetProcAddress("glGetUniformiv");
                glGetUniformivDlg =
               Marshal.GetDelegateForFunctionPointer<glGetUniformiv>(glGetUniformivPtr);
            }
            glGetUniformivDlg(program, location, out parameter);
        }

        /// <summary>
        /// Returns the value of a uniform variable.
        /// </summary>
        /// <param name="program">Specifies the program object to be queried.</param>
        /// <param name="location">Specifies the location of the uniform variable to be queried.</param>
        /// <param name="parameter">Returns the value of the specified uniform variable.</param>
        public static void GetUniformuiv(uint program, int location, out uint parameter)
        {
            if (glGetUniformuivPtr == IntPtr.Zero)
            {
                glGetUniformuivPtr = Wgl.GetProcAddress("glGetUniformuiv");
                glGetUniformuivDlg =
               Marshal.GetDelegateForFunctionPointer<glGetUniformuiv>(glGetUniformuivPtr);
            }
            glGetUniformuivDlg(program, location, out parameter);
        }

        /// <summary>
        /// Returns the value of a uniform variable.
        /// </summary>
        /// <param name="program">Specifies the program object to be queried.</param>
        /// <param name="location">Specifies the location of the uniform variable to be queried.</param>
        /// <param name="parameter">Returns the value of the specified uniform variable.</param>
        public static void GetUniformdv(uint program, int location, out double parameter)
        {
            if (glGetUniformdvPtr == IntPtr.Zero)
            {
                glGetUniformdvPtr = Wgl.GetProcAddress("glGetUniformdv");
                glGetUniformdvDlg =
               Marshal.GetDelegateForFunctionPointer<glGetUniformdv>(glGetUniformdvPtr);
            }
            glGetUniformdvDlg(program, location, out parameter);
        }

        /// <summary>
        /// Returns the value of a uniform variable.
        /// </summary>
        /// <param name="program">Specifies the program object to be queried.</param>
        /// <param name="location">Specifies the location of the uniform variable to be queried.</param>
        /// <param name="bufSize">Specifies the size of the buffer params.</param>
        /// <param name="parameters">Returns the value of the specified uniform variable.</param>
        public static void GetnUniformfv(uint program, int location, int bufSize, out float[] parameters)
        {
            if (glGetnUniformfvPtr == IntPtr.Zero)
            {
                glGetnUniformfvPtr = Wgl.GetProcAddress("glGetnUniformfv");
                glGetnUniformfvDlg =
               Marshal.GetDelegateForFunctionPointer<glGetnUniformfv>(glGetnUniformfvPtr);
            }
            parameters = new float[bufSize];

            glGetnUniformfvDlg(program, location, bufSize, ref parameters);
        }

        /// <summary>
        /// Returns the value of a uniform variable.
        /// </summary>
        /// <param name="program">Specifies the program object to be queried.</param>
        /// <param name="location">Specifies the location of the uniform variable to be queried.</param>
        /// <param name="bufSize">Specifies the size of the buffer params.</param>
        /// <param name="parameters">Returns the value of the specified uniform variable.</param>
        public static void GetnUniformiv(uint program, int location, int bufSize, out int[] parameters)
        {
            if (glGetnUniformivPtr == IntPtr.Zero)
            {
                glGetnUniformivPtr = Wgl.GetProcAddress("glGetnUniformiv");
                glGetnUniformivDlg =
               Marshal.GetDelegateForFunctionPointer<glGetnUniformiv>(glGetnUniformivPtr);
            }
            parameters = new int[bufSize];
            glGetnUniformivDlg(program, location, bufSize, ref parameters);
        }

        /// <summary>
        /// Returns the value of a uniform variable.
        /// </summary>
        /// <param name="program">Specifies the program object to be queried.</param>
        /// <param name="location">Specifies the location of the uniform variable to be queried.</param>
        /// <param name="bufSize">Specifies the size of the buffer params.</param>
        /// <param name="parameters">Returns the value of the specified uniform variable.</param>
        public static void GetnUniformuiv(uint program, int location, int bufSize, out uint[] parameters)
        {
            if (glGetnUniformuivPtr == IntPtr.Zero)
            {
                glGetnUniformuivPtr = Wgl.GetProcAddress("glGetnUniformuiv");
                glGetnUniformuivDlg =
               Marshal.GetDelegateForFunctionPointer<glGetnUniformuiv>(glGetnUniformuivPtr);
            }
            parameters = new uint[bufSize];
            glGetnUniformuivDlg(program, location, bufSize, ref parameters);
        }

        /// <summary>
        /// Returns the value of a uniform variable.
        /// </summary>
        /// <param name="program">Specifies the program object to be queried.</param>
        /// <param name="location">Specifies the location of the uniform variable to be queried.</param>
        /// <param name="bufSize">Specifies the size of the buffer params.</param>
        /// <param name="parameters">Returns the value of the specified uniform variable.</param>
        public static void GetnUniformdv(uint program, int location, int bufSize, out double[] parameters)
        {
            if (glGetnUniformdvPtr == IntPtr.Zero)
            {
                glGetnUniformdvPtr = Wgl.GetProcAddress("glGetnUniformdv");
                glGetnUniformdvDlg =
               Marshal.GetDelegateForFunctionPointer<glGetnUniformdv>(glGetnUniformdvPtr);
            }
            parameters = new double[bufSize];
            glGetnUniformdvDlg(program, location, bufSize, ref parameters);
        }


        /// <summary>
        /// Enables server-side GL capabilities
        /// 
        /// Use glIsEnabled or glGet to determine the current setting of any capability. 
        /// The initial value for each capability with the exception of GL_DITHER and GL_MULTISAMPLE is GL_FALSE.
        /// The initial value for GL_DITHER and GL_MULTISAMPLE is GL_TRUE.
        /// </summary>
        /// <param name="cap">Specifies a symbolic constant indicating a GL capability.</param>
        /// <param name="index">Specifies the index of the switch to disable</param>
        public static void Enablei(GLCapabilities cap, uint index)
        {
            if (glEnableiPtr == IntPtr.Zero)
            {
                glEnableiPtr = Wgl.GetProcAddress("glEnablei");
                glEnableiDlg =
               Marshal.GetDelegateForFunctionPointer<glEnablei>(glEnableiPtr);
            }
            glEnableiDlg(cap, index);
        }

        /// <summary>
        /// Disables server-side GL capabilities
        /// 
        /// Use glIsEnabled or glGet to determine the current setting of any capability. 
        /// The initial value for each capability with the exception of GL_DITHER and GL_MULTISAMPLE is GL_FALSE.
        /// The initial value for GL_DITHER and GL_MULTISAMPLE is GL_TRUE.
        /// </summary>
        /// <param name="cap">Specifies a symbolic constant indicating a GL capability.</param>
        /// <param name="index">Specifies the index of the switch to disable</param>
        public static void Disablei(GLCapabilities cap, uint index)
        {
            if (glDisableiPtr == IntPtr.Zero)
            {
                glDisableiPtr = Wgl.GetProcAddress("glDisablei");
                glDisableiDlg =
               Marshal.GetDelegateForFunctionPointer<glDisablei>(glDisableiPtr);
            }
            glDisableiDlg(cap, index);
        }

        /// <summary>
        /// select active texture unit.
        /// 
        /// glActiveTexture selects which texture unit subsequent texture state calls will affect. 
        /// The number of texture units an implementation supports is implementation dependent, but must be at least 80.
        /// </summary>
        /// <param name="texture">Specifies which texture unit to make active. </param>
        public static void ActiveTexture(TextureUnits texture)
        {
            if (glActiveTexturePtr == IntPtr.Zero)
            {
                glActiveTexturePtr = Wgl.GetProcAddress("glActiveTexture");
                glActiveTextureDlg =
               Marshal.GetDelegateForFunctionPointer<glActiveTexture>(glActiveTexturePtr);
            }
            glActiveTextureDlg(texture);
        }

        /// <summary>
        /// Set texture parameters.
        /// </summary>
        /// <param name="texture">Specifies the texture object name for glTextureParameter functions.</param>
        /// <param name="pname">Specifies the symbolic name of a single-valued texture parameter.</param>
        /// <param name="param">For the scalar commands, specifies the value of pname.</param>
        public static void TextureParameterf(uint texture, TextureParameters pname, float param)
        {
            if (glTextureParameterfPtr == IntPtr.Zero)
            {
                glTextureParameterfPtr = Wgl.GetProcAddress("glTextureParameterf");
                glTextureParameterfDlg =
               Marshal.GetDelegateForFunctionPointer<glTextureParameterf>(glTextureParameterfPtr);
            }
            glTextureParameterfDlg(texture, pname, param);
        }

        /// <summary>
        /// Set texture parameters.
        /// </summary>
        /// <param name="texture">Specifies the texture object name for glTextureParameter functions.</param>
        /// <param name="pname">Specifies the symbolic name of a single-valued texture parameter.</param>
        /// <param name="param">For the scalar commands, specifies the value of pname.</param>
        public static void TextureParameteri(uint texture, TextureParameters pname, int param)
        {
            if (glTextureParameteriPtr == IntPtr.Zero)
            {
                glTextureParameteriPtr = Wgl.GetProcAddress("glTextureParameteri");
                glTextureParameteriDlg =
               Marshal.GetDelegateForFunctionPointer<glTextureParameteri>(glTextureParameteriPtr);
            }
            glTextureParameteriDlg(texture, pname, param);
        }

        /// <summary>
        /// Set texture parameters.
        /// </summary>
        /// <param name="target">Specifies the target to which the texture is bound for glTexParameter functions.</param>
        /// <param name="pname">Specifies the symbolic name of a single-valued texture parameter.</param>
        /// <param name="parameters">Specifies an array where the value or values of pname are stored.</param>
        public static void TexParameterIiv(TextureTargets target, TextureParameters pname, int[] parameters)
        {
            if (glTexParameterIivPtr == IntPtr.Zero)
            {
                glTexParameterIivPtr = Wgl.GetProcAddress("glTexParameterIiv");
                glTexParameterIivDlg =
               Marshal.GetDelegateForFunctionPointer<glTexParameterIiv>(glTexParameterIivPtr);
            }
            glTexParameterIivDlg(target, pname, parameters);
        }

        /// <summary>
        /// Set texture parameters.
        /// </summary>
        /// <param name="target">Specifies the target to which the texture is bound for glTexParameter functions.</param>
        /// <param name="pname">Specifies the symbolic name of a single-valued texture parameter.</param>
        /// <param name="parameters">Specifies an array where the value or values of pname are stored.</param>
        public static void TexParameterIuiv(TextureTargets target, TextureParameters pname, uint[] parameters)
        {
            if (glTexParameterIuivPtr == IntPtr.Zero)
            {
                glTexParameterIuivPtr = Wgl.GetProcAddress("glTexParameterIuiv");
                glTexParameterIuivDlg =
               Marshal.GetDelegateForFunctionPointer<glTexParameterIuiv>(glTexParameterIuivPtr);
            }
            glTexParameterIuivDlg(target, pname, parameters);
        }

        /// <summary>
        /// Set texture parameters.
        /// </summary>
        /// <param name="texture">Specifies the texture object name for glTextureParameter functions.</param>
        /// <param name="pname">Specifies the symbolic name of a single-valued texture parameter.</param>
        /// <param name="parameters">Specifies an array where the value or values of pname are stored.</param>
        public static void TextureParameterfv(uint texture, TextureParameters pname, float[] parameters)
        {
            if (glTextureParameterfvPtr == IntPtr.Zero)
            {
                glTextureParameterfvPtr = Wgl.GetProcAddress("glTextureParameterfv");
                glTextureParameterfvDlg =
               Marshal.GetDelegateForFunctionPointer<glTextureParameterfv>(glTextureParameterfvPtr);
            }
            glTextureParameterfvDlg(texture, pname, parameters);
        }

        /// <summary>
        /// Set texture parameters.
        /// </summary>
        /// <param name="texture">Specifies the texture object name for glTextureParameter functions.</param>
        /// <param name="pname">Specifies the symbolic name of a single-valued texture parameter.</param>
        /// <param name="parameters">Specifies an array where the value or values of pname are stored.</param>
        public static void TextureParameteriv(uint texture, TextureParameters pname, int[] parameters)
        {
            if (glTextureParameterivPtr == IntPtr.Zero)
            {
                glTextureParameterivPtr = Wgl.GetProcAddress("glTextureParameteriv");
                glTextureParameterivDlg =
               Marshal.GetDelegateForFunctionPointer<glTextureParameteriv>(glTextureParameterivPtr);
            }
            glTextureParameterivDlg(texture, pname, parameters);
        }

        /// <summary>
        /// Set texture parameters.
        /// </summary>
        /// <param name="texture">Specifies the texture object name for glTextureParameter functions.</param>
        /// <param name="pname">Specifies the symbolic name of a single-valued texture parameter.</param>
        /// <param name="parameters">Specifies an array where the value or values of pname are stored.</param>
        public static void TextureParameterIiv(uint texture, TextureParameters pname, int[] parameters)
        {
            if (glTexParameterIivPtr == IntPtr.Zero)
            {
                glTexParameterIivPtr = Wgl.GetProcAddress("glTextureParameterIiv");
                glTextureParameterIivDlg =
               Marshal.GetDelegateForFunctionPointer<glTextureParameterIiv>(glTexParameterIivPtr);
            }
            glTextureParameterIivDlg(texture, pname, parameters);
        }

        /// <summary>
        /// Set texture parameters.
        /// </summary>
        /// <param name="texture">Specifies the texture object name for glTextureParameter functions.</param>
        /// <param name="pname">Specifies the symbolic name of a single-valued texture parameter.</param>
        /// <param name="parameters">Specifies an array where the value or values of pname are stored.</param>
        public static void TextureParameterIuiv(uint texture, TextureParameters pname, uint[] parameters)
        {
            if (glTextureParameterIuivPtr == IntPtr.Zero)
            {
                glTextureParameterIuivPtr = Wgl.GetProcAddress("glTextureParameterIuiv");
                glTextureParameterIuivDlg =
               Marshal.GetDelegateForFunctionPointer<glTextureParameterIuiv>(glTextureParameterIuivPtr);
            }
            glTextureParameterIuivDlg(texture, pname, parameters);
        }

        /// <summary>
        /// Generate mipmaps for a specified texture object
        /// </summary>
        /// <param name="target">Specifies the target to which the texture object is bound</param>
        public static void GenerateMipmap(TextureTargets target)
        {
            if (glGenerateMipmapPtr == IntPtr.Zero)
            {
                glGenerateMipmapPtr = Wgl.GetProcAddress("glGenerateMipmap");
                glGenerateMipmapDlg =
               Marshal.GetDelegateForFunctionPointer<glGenerateMipmap>(glGenerateMipmapPtr);
            }
            glGenerateMipmapDlg(target);
        }

        /// <summary>
        /// Generate mipmaps for a specified texture object
        /// </summary>
        /// <param name="texture">Specifies the texture object name</param>
        public static void GenerateTextureMipmap(uint texture)
        {
            if (glGenerateTextureMipmapPtr == IntPtr.Zero)
            {
                glGenerateTextureMipmapPtr = Wgl.GetProcAddress("glGenerateTextureMipmap");
                glGenerateTextureMipmapDlg =
               Marshal.GetDelegateForFunctionPointer<glGenerateTextureMipmap>(glGenerateTextureMipmapPtr);
            }
            glGenerateTextureMipmapDlg(texture);
        }

        /// <summary>
        /// Specify a two-dimensional texture image in a compressed format
        /// </summary>
        /// <param name="target">Specifies the target texture.</param>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="internalformat">Specifies the format of the compressed image data stored at address data.</param>
        /// <param name="width">Specifies the width of the texture image. All implementations support 2D texture and cube map texture images that are at least 16384 texels wide.</param>
        /// <param name="height">Specifies the height of the texture image. All implementations support 2D texture and cube map texture images that are at least 16384 texels high.</param>
        /// <param name="border">This value must be 0.</param>
        /// <param name="imageSize">Specifies the number of unsigned bytes of image data starting at the address specified by data.</param>
        /// <param name="data">Specifies the compressed image data in memory.</param>
        public static void CompressedTexImage2D(TextureTargets target, int level, CompressedTextureImageFormats internalformat, int width, int height, int border, int imageSize, byte[] data)
        {
            if (glCompressedTexImage2DPtr == IntPtr.Zero)
            {
                glCompressedTexImage2DPtr = Wgl.GetProcAddress("glCompressedTexImage2D");
                glCompressedTexImage2DDlg =
               Marshal.GetDelegateForFunctionPointer<glCompressedTexImage2D>(glCompressedTexImage2DPtr);
            }
            glCompressedTexImage2DDlg(target, level, internalformat, width, height, border, imageSize, data);
        }

        /// <summary>
        /// Return a string describing the current GL connection
        /// </summary>
        /// <param name="name">Specifies a symbolic constant of the parameter to get.</param>
        /// <param name="index">Specifies the index of the string to return.</param>
        /// <returns>Returns the extension string supported by the implementation at index.</returns>
        public static IntPtr GetStringi(CurrentConnectionInfo name, int index)
        {
            if (glGetStringiPtr == IntPtr.Zero)
            {
                glGetStringiPtr = Wgl.GetProcAddress("glGetStringi");
                glGetStringiDlg =
               Marshal.GetDelegateForFunctionPointer<glGetStringi>(glGetStringiPtr);
            }
            return glGetStringiDlg(name, index);
        }

        /// <summary>
        /// Checks to see if the specified extension is availiable in OpenGL
        /// </summary>
        /// <param name="extensionName">The name of the extension to check.</param>
        /// <returns>True if the extension exists; Otherwise false.</returns>
        public static bool HasExtension(string extensionName)
        {
            List<string> extensions = ListExtensions();

            foreach (string ext in extensions)
            {
                if (ext.Equals(extensionName, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Lists the extensions enabled in OpenGL.
        /// </summary>
        /// <returns>The list of enabled extensions.</returns>
        public static List<string> ListExtensions()
        {
            List<string> extensions = new List<string>();

            int NumberOfExtensions;
            GetIntegerv(GetValueParameters.GL_NUM_EXTENSIONS, out NumberOfExtensions);

            for (int i = 0; i < NumberOfExtensions; i++)
            {
                string ccc = MarshalHelper.PtrToStringUTF8(GL.GetStringi(CurrentConnectionInfo.GL_EXTENSIONS, i));
                extensions.Add(ccc);
            }

            return extensions;
        }

        /// <summary>
        /// Get OpenGL Info returns some basic info about openGL:
        /// "Renderer"
        /// "Shader Language Version"
        /// "Vendor"
        /// and 
        /// "GL Version"
        /// </summary>
        /// <returns>The keyed list of OpenGL values</returns>
        public static Dictionary<string, string> GetOpenGLInfo()
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

            string renderer = MarshalHelper.PtrToStringUTF8(GL.GetString(CurrentConnectionInfo.GL_RENDERER));
            string shaderLangVers = MarshalHelper.PtrToStringUTF8(GL.GetString(CurrentConnectionInfo.GL_SHADING_LANGUAGE_VERSION));
            string vendor = MarshalHelper.PtrToStringUTF8(GL.GetString(CurrentConnectionInfo.GL_VENDOR));
            string version = MarshalHelper.PtrToStringUTF8(GL.GetString(CurrentConnectionInfo.GL_VERSION));

            keyValuePairs.Add("Renderer", renderer);
            keyValuePairs.Add("Shader Language Version", shaderLangVers);
            keyValuePairs.Add("Vendor", vendor);
            keyValuePairs.Add("GL Version", version);

            return keyValuePairs;
        }

        /// <summary>
        /// Controls the reporting of debug messages generated by a debug context. 
        /// The parameters source, type and severity form a filter to select messages 
        /// from the pool of potential messages generated by the GL.
        /// </summary>
        /// <param name="source">The source of debug messages to enable or disable.</param>
        /// <param name="type">The type of debug messages to enable or disable.</param>
        /// <param name="severity">The severity of debug messages to enable or disable.</param>
        /// <param name="count">The length of the array ids.</param>
        /// <param name="ids">An array of unsigned integers contianing the ids of the messages to enable or disable.</param>
        /// <param name="enabled">A Boolean flag determining whether the selected messages should be enabled or disabled.</param>
        public static void DebugMessageControl(ErrorSources source,
     ErrorType type,
     ErrorSeverity severity,
     int count,
     uint[] ids,
     bool enabled)
        {
            if (glDebugMessageControlPtr == IntPtr.Zero)
            {
                glDebugMessageControlPtr = Wgl.GetProcAddress("glDebugMessageControl");
                glDebugMessageControlDlg =
               Marshal.GetDelegateForFunctionPointer<glDebugMessageControl>(glDebugMessageControlPtr);
            }
            glDebugMessageControlDlg(source, type, severity, count, ids, enabled);
        }

        /// <summary>
        /// Define a callback function in C# for open GL to call when it encounters an error. 
        /// 
        /// Then enable the feature with:
        /// GL.Enable(GLCapabilities.GL_DEBUG_OUTPUT_SYNCHRONOUS_ARB);
        ///
        /// THIS DOES NOT DO ANYTHING AND I DON'T KNOW WHY :`( 
        /// 
        /// See http://www.opengl.org/registry/specs/ARB/debug_output.txt
        /// 
        /// </summary>
        /// <param name="callback">The function OpenGL should call when ete's an error.</param>
        /// <param name="userParam">An optional user supplied pointer that will be passed on each invocation of callback.. Can be IntPtr.Zero</param>
        public static void DebugMessageCallbackARB(GLDelegates.glDebugOutputCallbackARB callback, IntPtr userParam)
        {
            if (glDebugMessageCallbackARBPtr == IntPtr.Zero)
            {
                glDebugMessageCallbackARBPtr = Wgl.GetProcAddress("glDebugMessageCallbackARB");
                glDebugMessageCallbackARBDlg =
               Marshal.GetDelegateForFunctionPointer<glDebugMessageCallbackARB>(glDebugMessageCallbackARBPtr);
            }
            glDebugMessageCallbackARBDlg(callback, userParam);
        }

        /// <summary>
        /// The callback pattern used to receive debugging messages from the GL.
        /// 
        /// OpenGL Version 4.3+
        ///
        /// Don't forget to enable debugging:
        /// 
        /// GL.Enable(GLCapabilities.GL_DEBUG_OUTPUT);
        /// 
        /// Use: PrairieGL.Utils.MarshalHelper.PtrToStringUTF8(message)) to get the message as a string.
        /// </summary>
        /// <param name="source">The message source. What it the API, Windows, App or somewhere else</param>
        /// <param name="type">The message type. If it was an error or use of a depreciated call or a performance issue</param>
        /// <param name="id">The message id</param>
        /// <param name="severity">How bad are we talking?</param>
        /// <param name="length">The length of the message</param>
        /// <param name="message">A string of the error message.</param>
        /// <param name="userParam">Optional Data that can be set up and will be passed to that callback.</param>
        public delegate void DebugMessageCallbackDelegate(ErrorSources source, ErrorType type, uint id, ErrorSeverity severity, int length, IntPtr message, IntPtr userParam);

        /// <summary>
        /// Define a callback function in C# for open GL to call when it encounters an error. 
        /// 
        /// OpenGL Version 4.3+
        ///
        /// Don't forget to enable debugging:
        /// 
        /// GL.Enable(GLCapabilities.GL_DEBUG_OUTPUT);
        /// 
        /// See http://www.opengl.org/registry/specs/ARB/debug_output.txt
        /// 
        /// </summary>
        /// <param name="callback">
        /// The function OpenGL should call when ete's an error. 
        /// Make sure to Pin call back in GCHandle to avoid Garbage collector invalidating the address of the callback.
        /// </param>
        /// <param name="userParam">An optional user supplied pointer that will be passed on each invocation of callback.. Can be IntPtr.Zero</param>
        public static void DebugMessageCallback(DebugMessageCallbackDelegate callback, IntPtr userParam)
        {
            if (glDebugMessageCallbackPtr == IntPtr.Zero)
            {
                glDebugMessageCallbackPtr = Wgl.GetProcAddress("glDebugMessageCallback");
                glDebugMessageCallbackDlg =
               Marshal.GetDelegateForFunctionPointer<glDebugMessageCallback>(glDebugMessageCallbackPtr);
            }
            glDebugMessageCallbackDlg(callback, userParam);
        }

        /// <summary>
        /// Gets debug messages from OpenGL
        /// 
        /// OpenGL Version 4.3+
        ///
        /// Don't forget to enable debugging:
        /// 
        /// GL.Enable(GLCapabilities.GL_DEBUG_OUTPUT);
        /// </summary>
        /// <param name="count"></param>
        /// <param name="bufSize"></param>
        /// <param name="sources"></param>
        /// <param name="types"></param>
        /// <param name="ids"></param>
        /// <param name="severities"></param>
        /// <param name="lengths"></param>
        /// <param name="messageLog"></param>
        /// <returns></returns>
        public static uint GetDebugMessageLog(uint count, int bufSize, ref ErrorSources[] sources,
            ref ErrorType[] types, ref uint[] ids, ref ErrorSeverity[] severities, ref int[] lengths, IntPtr messageLog)
        {
            if (glGetDebugMessageLogPtr == IntPtr.Zero)
            {
                glGetDebugMessageLogPtr = Wgl.GetProcAddress("glGetDebugMessageLog");
                glGetDebugMessageLogDlg =
               Marshal.GetDelegateForFunctionPointer<glGetDebugMessageLog>(glGetDebugMessageLogPtr);
            }
            return glGetDebugMessageLogDlg(count, bufSize, ref sources, ref types, ref ids, ref severities, ref lengths, messageLog);
        }

        /// <summary>
        /// Gets the list of errors waiting to be retreived (but not yet done). 
        /// 
        /// OpenGL Version 4.3+
        ///
        /// Don't forget to enable debugging:
        /// 
        /// GL.Enable(GLCapabilities.GL_DEBUG_OUTPUT);
        /// 
        /// TODO: If something went wrong null is returned. Need better error checking on the error tracking function.
        /// </summary>
        /// <returns>The list of errors OpenGL has generated</returns>
        public static List<ErrorLog> GetDebugMessages()
        {
            //int[] arrLogCount;
            int logCount;
            GetIntegerv(GetValueParameters.GL_DEBUG_LOGGED_MESSAGES, out logCount);

            if (logCount == 0)
                return new List<ErrorLog>();
            //logCount = arrLogCount[0];

            //Up to a *yikes* 10Mb log.
            byte[] messageLog = new byte[Math.Min(1024 * logCount, 0xA00000)];
            GCHandle messageLodHwnd = GCHandle.Alloc(messageLog, GCHandleType.Pinned);

            ErrorSources[] sources = new ErrorSources[logCount];
            ErrorType[] types = new ErrorType[logCount];
            uint[] ids = new uint[logCount];
            ErrorSeverity[] severities = new ErrorSeverity[logCount];
            int[] lengths = new int[logCount];

            uint messagesRead = GetDebugMessageLog((uint)logCount, messageLog.Length, ref sources,
            ref types, ref ids, ref severities, ref lengths, messageLodHwnd.AddrOfPinnedObject());

            if (messagesRead == 0)
            {
                GLErrors err = GetError();
                err = GetError();
                ///TODO: Make log bigger and try again.
                return null;
            }

            string log = Marshal.PtrToStringUTF8(messageLodHwnd.AddrOfPinnedObject());
            messageLodHwnd.Free();

            int start = 0;

            List<ErrorLog> errors = new List<ErrorLog>();
            for (int i = 0; i < logCount; i++)
            {
                ErrorLog error = new ErrorLog();

                error.Source = sources[i];
                error.Type = types[i];
                error.Id = ids[i];
                error.Severity = severities[i];

                if (log != null && start + lengths[i] < log.Length)
                {
                    error.Message = log.Substring(start, lengths[i]);
                    start += lengths[i];
                }
            }

            return errors;
        }

        /// <summary>
        /// Generate framebuffer object names
        /// </summary>
        /// <param name="n">Specifies the number of framebuffer object names to generate.</param>
        /// <param name="buffers">Specifies an array in which the generated framebuffer object names are stored.</param>
        public static void GenFramebuffers(int n, uint[] buffers)
        {
            if (glGenFramebuffersPtr == IntPtr.Zero)
            {
                glGenFramebuffersPtr = Wgl.GetProcAddress("glGenFramebuffers");
                glGenFramebuffersDlg =
               Marshal.GetDelegateForFunctionPointer<glGenFramebuffers>(glGenFramebuffersPtr);
            }
            glGenFramebuffersDlg(n, buffers);
        }

        /// <summary>
        /// Generate framebuffer object names
        /// </summary>
        /// <returns>The newly created buffer</returns>
        public static uint GenFramebuffer()
        {
            uint[] arr = new uint[1];
            GenFramebuffers(1, arr);
            return arr[0];
        }

        /// <summary>
        /// Bind a framebuffer to a framebuffer target.
        /// 
        /// If a framebuffer object is bound to GL_DRAW_FRAMEBUFFER or GL_READ_FRAMEBUFFER, 
        /// it becomes the target for rendering or readback operations, respectively, 
        /// until it is deleted or another framebuffer is bound to the corresponding bind point. 
        /// Calling glBindFramebuffer with target set to GL_FRAMEBUFFER binds framebuffer to both 
        /// the read and draw framebuffer targets. framebuffer is the name of a framebuffer object previously 
        /// returned from a call to glGenFramebuffers, or zero to break the existing binding of a 
        /// framebuffer object to target.
        /// </summary>
        /// <param name="target">Specifies the framebuffer target of the binding operation.</param>
        /// <param name="framebuffer">Specifies the name of the framebuffer object to bind.</param>
        public static void BindFramebuffer(FrameBufferTargets target, uint framebuffer)
        {
            if (glBindFramebufferPtr == IntPtr.Zero)
            {
                glBindFramebufferPtr = Wgl.GetProcAddress("glBindFramebuffer");
                glBindFramebufferDlg =
               Marshal.GetDelegateForFunctionPointer<glBindFramebuffer>(glBindFramebufferPtr);
            }
            glBindFramebufferDlg(target, framebuffer);
        }

        /// <summary>
        /// Generate renderbuffer  object names
        /// </summary>
        /// <param name="n">Specifies the number of renderbuffer  object names to generate.</param>
        /// <param name="buffers">Specifies an array in which the generated renderbuffer  object names are stored.</param>
        public static void GenRenderbuffers(int n, uint[] buffers)
        {
            if (glGenRenderbuffersPtr == IntPtr.Zero)
            {
                glGenRenderbuffersPtr = Wgl.GetProcAddress("glGenRenderbuffers");
                glGenRenderbuffersDlg =
               Marshal.GetDelegateForFunctionPointer<glGenRenderbuffers>(glGenRenderbuffersPtr);
            }
            glGenRenderbuffersDlg(n, buffers);
        }

        /// <summary>
        /// Generate renderbuffer  object names
        /// </summary>
        /// <returns>The newly created buffer</returns>
        public static uint GenRenderbuffer()
        {
            uint[] arr = new uint[1];
            GenRenderbuffers(1, arr);
            return arr[0];
        }

        /// <summary>
        /// Bind a renderbuffer to a renderbuffer target
        /// </summary>
        /// <param name="target">Specifies the renderbuffer target of the binding operation. target must be GL_RENDERBUFFER.</param>
        /// <param name="renderbuffer">Specifies the name of the renderbuffer object to bind.</param>
        public static void BindRenderbuffer(RenderBufferTargets target, uint renderbuffer)
        {
            if (glBindRenderbufferPtr == IntPtr.Zero)
            {
                glBindRenderbufferPtr = Wgl.GetProcAddress("glBindRenderbuffer");
                glBindRenderbufferDlg =
               Marshal.GetDelegateForFunctionPointer<glBindRenderbuffer>(glBindRenderbufferPtr);
            }
            glBindRenderbufferDlg(target, renderbuffer);
        }

        /// <summary>
        /// Establish data storage, format and dimensions of a renderbuffer object's image
        /// </summary>
        /// <param name="target">Specifies a binding target of the allocation for glRenderbufferStorage function. Must be GL_RENDERBUFFER.</param>
        /// <param name="internalformat">Specifies the internal format to use for the renderbuffer object's image.</param>
        /// <param name="width">Specifies the width of the renderbuffer, in pixels.</param>
        /// <param name="height">Specifies the height of the renderbuffer, in pixels.</param>
        public static void RenderbufferStorage(RenderBufferTargets target, ImagePixelFormats internalformat, int width, int height)
        {
            if (glRenderbufferStoragePtr == IntPtr.Zero)
            {
                glRenderbufferStoragePtr = Wgl.GetProcAddress("glRenderbufferStorage");
                glRenderbufferStorageDlg =
               Marshal.GetDelegateForFunctionPointer<glRenderbufferStorage>(glRenderbufferStoragePtr);
            }
            glRenderbufferStorageDlg(target, internalformat, width, height);
        }

        /// <summary>
        /// Establish data storage, format and dimensions of a renderbuffer object's image
        /// </summary>
        /// <param name="renderbuffer">Specifies the name of the renderbuffer object</param>
        /// <param name="internalformat">Specifies the internal format to use for the renderbuffer object's image.</param>
        /// <param name="width">Specifies the width of the renderbuffer, in pixels.</param>
        /// <param name="height">Specifies the height of the renderbuffer, in pixels.</param>
        public static void NamedRenderbufferStorage(uint renderbuffer, ImagePixelFormats internalformat, int width, int height)
        {
            if (glNamedRenderbufferStoragePtr == IntPtr.Zero)
            {
                glNamedRenderbufferStoragePtr = Wgl.GetProcAddress("glNamedRenderbufferStorage");
                glNamedRenderbufferStorageDlg =
               Marshal.GetDelegateForFunctionPointer<glNamedRenderbufferStorage>(glNamedRenderbufferStoragePtr);
            }
            glNamedRenderbufferStorageDlg(renderbuffer, internalformat, width, height);
        }

        /// <summary>
        /// Attach a renderbuffer as a logical buffer of a framebuffer object
        /// </summary>
        /// <param name="target">Specifies the target to which the framebuffer is bound for</param>
        /// <param name="attachment">Specifies the attachment point of the framebuffer.</param>
        /// <param name="renderbuffertarget">Specifies the renderbuffer target. Must be GL_RENDERBUFFER.</param>
        /// <param name="renderbuffer">Specifies the name of an existing renderbuffer object of type renderbuffertarget to attach.</param>
        public static void FramebufferRenderbuffer(FrameBufferTargets target, RenderBufferAttachments attachment, RenderBufferTargets renderbuffertarget, uint renderbuffer)
        {
            if (glFramebufferRenderbufferPtr == IntPtr.Zero)
            {
                glFramebufferRenderbufferPtr = Wgl.GetProcAddress("glFramebufferRenderbuffer");
                glFramebufferRenderbufferDlg =
               Marshal.GetDelegateForFunctionPointer<glFramebufferRenderbuffer>(glFramebufferRenderbufferPtr);
            }
            glFramebufferRenderbufferDlg(target, attachment, renderbuffertarget, renderbuffer);
        }

        /// <summary>
        /// Attach a renderbuffer as a logical buffer of a framebuffer object
        /// </summary>
        /// <param name="framebuffer">Specifies the name of the framebuffer object</param>
        /// <param name="attachment">Specifies the attachment point of the framebuffer.</param>
        /// <param name="renderbuffertarget">Specifies the renderbuffer target. Must be GL_RENDERBUFFER.</param>
        /// <param name="renderbuffer">Specifies the name of an existing renderbuffer object of type renderbuffertarget to attach.</param>
        public static void NamedFramebufferRenderbuffer(uint framebuffer, RenderBufferAttachments attachment, RenderBufferTargets renderbuffertarget, uint renderbuffer)
        {
            if (glNamedFramebufferRenderbufferPtr == IntPtr.Zero)
            {
                glNamedFramebufferRenderbufferPtr = Wgl.GetProcAddress("glNamedFramebufferRenderbuffer");
                glNamedFramebufferRenderbufferDlg =
               Marshal.GetDelegateForFunctionPointer<glNamedFramebufferRenderbuffer>(glNamedFramebufferRenderbufferPtr);
            }
            glNamedFramebufferRenderbufferDlg(framebuffer, attachment, renderbuffertarget, renderbuffer);
        }

        /// <summary>
        /// Attach a level of a texture object as a logical buffer of a framebuffer object
        /// </summary>
        /// <param name="target">Specifies the target to which the framebuffer is bound</param>
        /// <param name="attachment">Specifies the attachment point of the framebuffer.</param>
        /// <param name="texture">Specifies the name of an existing texture object to attach.</param>
        /// <param name="level">Specifies the mipmap level of the texture object to attach.</param>
        public static void FramebufferTexture(FrameBufferTargets target,
             RenderBufferAttachments attachment,
             uint texture,
             int level)
        {
            if (glFramebufferTexturePtr == IntPtr.Zero)
            {
                glFramebufferTexturePtr = Wgl.GetProcAddress("glFramebufferTexture");
                glFramebufferTextureDlg =
               Marshal.GetDelegateForFunctionPointer<glFramebufferTexture>(glFramebufferTexturePtr);
            }
            glFramebufferTextureDlg(target, attachment, texture, level);
        }

        /// <summary>
        /// Attach a level of a texture object as a logical buffer of a framebuffer object
        /// </summary>
        /// <param name="target">Specifies the target to which the framebuffer is bound</param>
        /// <param name="attachment">Specifies the attachment point of the framebuffer.</param>
        /// <param name="textarget">specifies what type of texture is expected in the texture parameter, or for cube map textures, which face is to be attached.</param>
        /// <param name="texture">Specifies the name of an existing texture object to attach.</param>
        /// <param name="level">Specifies the mipmap level of the texture object to attach.</param>
        public static void FramebufferTexture1D(FrameBufferTargets target,
             RenderBufferAttachments attachment,
             TextureTargets textarget,
             uint texture,
             int level)
        {
            if (glFramebufferTexture1DPtr == IntPtr.Zero)
            {
                glFramebufferTexture1DPtr = Wgl.GetProcAddress("glFramebufferTexture1D");
                glFramebufferTexture1DDlg =
               Marshal.GetDelegateForFunctionPointer<glFramebufferTexture1D>(glFramebufferTexture1DPtr);
            }
            glFramebufferTexture1DDlg(target, attachment, textarget, texture, level);
        }

        /// <summary>
        /// Attach a level of a texture object as a logical buffer of a framebuffer object
        /// </summary>
        /// <param name="target">Specifies the target to which the framebuffer is bound</param>
        /// <param name="attachment">Specifies the attachment point of the framebuffer.</param>
        /// <param name="textarget">specifies what type of texture is expected in the texture parameter, or for cube map textures, which face is to be attached.</param>
        /// <param name="texture">Specifies the name of an existing texture object to attach.</param>
        /// <param name="level">Specifies the mipmap level of the texture object to attach.</param>
        public static void FramebufferTexture2D(FrameBufferTargets target,
             RenderBufferAttachments attachment,
             TextureTargets textarget,
             uint texture,
             int level)
        {
            if (glFramebufferTexture2DPtr == IntPtr.Zero)
            {
                glFramebufferTexture2DPtr = Wgl.GetProcAddress("glFramebufferTexture2D");
                glFramebufferTexture2DDlg =
               Marshal.GetDelegateForFunctionPointer<glFramebufferTexture2D>(glFramebufferTexture2DPtr);
            }
            glFramebufferTexture2DDlg(target, attachment, textarget, texture, level);
        }

        /// <summary>
        /// Attach a level of a texture object as a logical buffer of a framebuffer object
        /// </summary>
        /// <param name="target">Specifies the target to which the framebuffer is bound</param>
        /// <param name="attachment">Specifies the attachment point of the framebuffer.</param>
        /// <param name="textarget">specifies what type of texture is expected in the texture parameter, or for cube map textures, which face is to be attached.</param>
        /// <param name="texture">Specifies the name of an existing texture object to attach.</param>
        /// <param name="level">Specifies the mipmap level of the texture object to attach.</param>
        /// <param name="layer">Specifies the layer of a 2-dimensional image within a 3-dimensional texture.</param>
        public static void FramebufferTexture3D(FrameBufferTargets target,
             RenderBufferAttachments attachment,
             TextureTargets textarget,
             uint texture,
             int level,
             int layer)
        {
            if (glFramebufferTexture3DPtr == IntPtr.Zero)
            {
                glFramebufferTexture3DPtr = Wgl.GetProcAddress("glFramebufferTexture3D");
                glFramebufferTexture3DDlg =
               Marshal.GetDelegateForFunctionPointer<glFramebufferTexture3D>(glFramebufferTexture3DPtr);
            }
            glFramebufferTexture3DDlg(target, attachment, textarget, texture, level, layer);
        }

        /// <summary>
        /// Attach a level of a texture object as a logical buffer of a framebuffer object
        /// </summary>
        /// <param name="framebuffer">Specifies the name of the framebuffer object</param>
        /// <param name="attachment">Specifies the attachment point of the framebuffer.</param>
        /// <param name="texture">Specifies the name of an existing texture object to attach.</param>
        /// <param name="level">Specifies the mipmap level of the texture object to attach.</param>
        public static void NamedFramebufferTexture(uint framebuffer,
             RenderBufferAttachments attachment,
             uint texture,
             int level)
        {
            if (glNamedFramebufferTexturePtr == IntPtr.Zero)
            {
                glNamedFramebufferTexturePtr = Wgl.GetProcAddress("glNamedFramebufferTexture");
                glNamedFramebufferTextureDlg =
               Marshal.GetDelegateForFunctionPointer<glNamedFramebufferTexture>(glNamedFramebufferTexturePtr);
            }
            glNamedFramebufferTextureDlg(framebuffer, attachment, texture, level);
        }

        /// <summary>
        /// Specifies a list of color buffers to be drawn into
        /// </summary>
        /// <param name="n">Specifies the number of buffers in bufs.</param>
        /// <param name="bufs">Points to an array of symbolic constants specifying the buffers into which fragment colors or data values will be written.</param>
        public static void DrawBuffers(int n, RenderBufferAttachments[] bufs)
        {
            if (glDrawBuffersPtr == IntPtr.Zero)
            {
                glDrawBuffersPtr = Wgl.GetProcAddress("glDrawBuffers");
                glDrawBuffersDlg =
               Marshal.GetDelegateForFunctionPointer<glDrawBuffers>(glDrawBuffersPtr);
            }
            glDrawBuffersDlg(n, bufs);
        }

        /// <summary>
        /// Specifies a list of color buffers to be drawn into
        /// </summary>
        /// <param name="framebuffer">Specifies the name of the framebuffer object</param>
        /// <param name="n">Specifies the number of buffers in bufs.</param>
        /// <param name="bufs">Points to an array of symbolic constants specifying the buffers into which fragment colors or data values will be written.</param>
        public static void NamedFramebufferDrawBuffers(uint framebuffer, int n, RenderBufferAttachments[] bufs)
        {
            if (glNamedFramebufferDrawBuffersPtr == IntPtr.Zero)
            {
                glNamedFramebufferDrawBuffersPtr = Wgl.GetProcAddress("glNamedFramebufferDrawBuffers");
                glNamedFramebufferDrawBuffersDlg =
               Marshal.GetDelegateForFunctionPointer<glNamedFramebufferDrawBuffers>(glNamedFramebufferDrawBuffersPtr);
            }
            glNamedFramebufferDrawBuffersDlg(framebuffer, n, bufs);
        }

        /// <summary>
        /// check the completeness status of a framebuffer
        /// </summary>
        /// <param name="target">Specify the target to which the framebuffer is bound for glCheckFramebufferStatus, and the target against which framebuffer completeness of framebuffer is checked for glCheckNamedFramebufferStatus.</param>
        /// <returns>The return value is GL_FRAMEBUFFER_COMPLETE if the specified framebuffer is complete. </returns>
        public static FrameBufferStatuses CheckFramebufferStatus(FrameBufferTargets target)
        {
            if (glCheckFramebufferStatusPtr == IntPtr.Zero)
            {
                glCheckFramebufferStatusPtr = Wgl.GetProcAddress("glCheckFramebufferStatus");
                glCheckFramebufferStatusDlg =
               Marshal.GetDelegateForFunctionPointer<glCheckFramebufferStatus>(glCheckFramebufferStatusPtr);
            }
            return glCheckFramebufferStatusDlg(target);
        }

        /// <summary>
        /// check the completeness status of a framebuffer
        /// </summary>
        /// <param name="framebuffer">Specifies the name of the framebuffer object</param>
        /// <param name="target">Specify the target to which the framebuffer is bound for glCheckFramebufferStatus, and the target against which framebuffer completeness of framebuffer is checked for glCheckNamedFramebufferStatus.</param>
        /// <returns>The return value is GL_FRAMEBUFFER_COMPLETE if the specified framebuffer is complete. </returns>
        public static FrameBufferStatuses CheckNamedFramebufferStatus(uint framebuffer, FrameBufferTargets target)
        {
            if (glCheckNamedFramebufferStatusPtr == IntPtr.Zero)
            {
                glCheckNamedFramebufferStatusPtr = Wgl.GetProcAddress("glCheckNamedFramebufferStatus");
                glCheckNamedFramebufferStatusDlg =
               Marshal.GetDelegateForFunctionPointer<glCheckNamedFramebufferStatus>(glCheckNamedFramebufferStatusPtr);
            }
            return glCheckNamedFramebufferStatusDlg(framebuffer, target);
        }

        /// <summary>
        /// Delete framebuffer objects
        /// </summary>
        /// <param name="n">Specifies the number of framebuffer objects to be deleted.</param>
        /// <param name="framebuffers">A pointer to an array containing n framebuffer objects to be deleted.</param>
        public static void DeleteFramebuffers(int n, uint[] framebuffers)
        {
            if (glDeleteFramebuffersPtr == IntPtr.Zero)
            {
                glDeleteFramebuffersPtr = Wgl.GetProcAddress("glDeleteFramebuffers");
                glDeleteFramebuffersDlg =
               Marshal.GetDelegateForFunctionPointer<glDeleteFramebuffers>(glDeleteFramebuffersPtr);
            }
            glDeleteFramebuffersDlg(n, framebuffers);
        }

        /// <summary>
        /// Delete framebuffer object
        /// </summary>
        /// <param name="buffer">The Frame buffer to delete</param>
        public static void DeleteFramebuffer(uint buffer)
        {
            DeleteFramebuffers(1, new uint[] { buffer });
        }

        /// <summary>
        /// Delete renderbuffer objects
        /// </summary>
        /// <param name="n">Specifies the number of renderbuffer objects to be deleted.</param>
        /// <param name="renderbuffers">A pointer to an array containing n renderbuffer objects to be deleted.</param>
        public static void DeleteRenderbuffers(int n, uint[] renderbuffers)
        {
            if (glDeleteRenderbuffersPtr == IntPtr.Zero)
            {
                glDeleteRenderbuffersPtr = Wgl.GetProcAddress("glDeleteRenderbuffers");
                glDeleteRenderbuffersDlg =
               Marshal.GetDelegateForFunctionPointer<glDeleteRenderbuffers>(glDeleteRenderbuffersPtr);
            }
            glDeleteRenderbuffersDlg(n, renderbuffers);
        }

        /// <summary>
        /// Delete renderbuffer object
        /// </summary>
        /// <param name="buffer">The Render buffer to delete</param>
        public static void DeleteRenderbuffer(uint buffer)
        {
            DeleteRenderbuffers(1, new uint[] { buffer });
        }

        /// <summary>
        /// Updates a subset of a buffer object's data store
        /// </summary>
        /// <param name="target">Specifies the target to which the buffer object is bound</param>
        /// <param name="offset">Specifies the offset into the buffer object's data store where data replacement will begin, measured in bytes</param>
        /// <param name="size">Specifies the size in bytes of the data store region being replaced.</param>
        /// <param name="data">Specifies a pointer to the new data that will be copied into the data store.</param>
        public static void BufferSubData(BufferTargets target, int offset, int size, IntPtr data)
        {
            if (glBufferSubDataPtr == IntPtr.Zero)
            {
                glBufferSubDataPtr = Wgl.GetProcAddress("glBufferSubData");
                glBufferSubDataDlg =
               Marshal.GetDelegateForFunctionPointer<glBufferSubData>(glBufferSubDataPtr);
            }
            glBufferSubDataDlg(target, offset, size, data);
        }

        /// <summary>
        /// Updates a subset of a buffer object's data store
        /// </summary>
        /// <typeparam name="T">An unmanaged data type like float or int</typeparam>
        /// <param name="target">Specifies the target to which the buffer object is bound</param>
        /// <param name="offset">Specifies the offset into the buffer object's data store where data replacement will begin, measured in bytes</param>
        /// <param name="data">Specifies an array of the new data that will be copied into the data store.</param>
        public static void BufferSubData<T>(BufferTargets target, int offset, T[] data) where T : unmanaged
        {
            int sz = Marshal.SizeOf(typeof(T)) * data.Length; // Marshal.SizeOf(typeof(int[])) * data.Length;

            GCHandle GlobalDataPointer = GCHandle.Alloc(data, GCHandleType.Pinned); // Marshal.AllocHGlobal(sz);

            BufferSubData(target, offset, sz, GlobalDataPointer.AddrOfPinnedObject());
            GlobalDataPointer.Free();
        }

        /// <summary>
        /// Updates a subset of a buffer object's data store
        /// </summary>
        /// <param name="buffer">Specifies the name of the buffer object</param>
        /// <param name="offset">Specifies the offset into the buffer object's data store where data replacement will begin, measured in bytes</param>
        /// <param name="size">Specifies the size in bytes of the data store region being replaced.</param>
        /// <param name="data">Specifies a pointer to the new data that will be copied into the data store.</param>
        public static void NamedBufferSubData(uint buffer, int offset, int size, IntPtr data)
        {
            if (glNamedBufferSubDataPtr == IntPtr.Zero)
            {
                glNamedBufferSubDataPtr = Wgl.GetProcAddress("glNamedBufferSubData");
                glNamedBufferSubDataDlg =
               Marshal.GetDelegateForFunctionPointer<glNamedBufferSubData>(glNamedBufferSubDataPtr);
            }
            glNamedBufferSubDataDlg(buffer, offset, size, data);
        }

        /// <summary>
        /// Updates a subset of a buffer object's data store
        /// </summary>
        /// <typeparam name="T">An unmanaged data type like float or int</typeparam>
        /// <param name="buffer">Specifies the name of the buffer object</param>
        /// <param name="offset">Specifies the offset into the buffer object's data store where data replacement will begin, measured in bytes</param>
        /// <param name="data">Specifies an array of the new data that will be copied into the data store.</param>
        public static void NamedBufferSubData<T>(uint buffer, int offset, T[] data) where T : unmanaged
        {
            int sz = Marshal.SizeOf(typeof(T)) * data.Length; // Marshal.SizeOf(typeof(int[])) * data.Length;

            GCHandle GlobalDataPointer = GCHandle.Alloc(data, GCHandleType.Pinned); // Marshal.AllocHGlobal(sz);

            NamedBufferSubData(buffer, offset, sz, GlobalDataPointer.AddrOfPinnedObject());
            GlobalDataPointer.Free();
        }

        /// <summary>
        /// Modify the rate at which generic vertex attributes advance during instanced rendering.
        /// 
        /// glVertexAttribDivisor modifies the rate at which generic vertex attributes advance when rendering 
        /// multiple instances of primitives in a single draw call. 
        /// If divisor is zero, the attribute at slot index advances once per vertex.
        /// If divisor is non-zero, the attribute advances once per divisor instances of the set(s) of vertices 
        /// being rendered. An attribute is referred to as instanced if its GL_VERTEX_ATTRIB_ARRAY_DIVISOR value 
        /// is non-zero.
        /// 
        /// index must be less than the value of GL_MAX_VERTEX_ATTRIBS.
        /// </summary>
        /// <param name="index">Specify the index of the generic vertex attribute.</param>
        /// <param name="divisor">Specify the number of instances that will pass between updates of the generic 
        /// attribute at slot index.</param>
        public static void VertexAttribDivisor(uint index, uint divisor)
        {
            if (glVertexAttribDivisorPtr == IntPtr.Zero)
            {
                glVertexAttribDivisorPtr = Wgl.GetProcAddress("glVertexAttribDivisor");
                glVertexAttribDivisorDlg =
               Marshal.GetDelegateForFunctionPointer<glVertexAttribDivisor>(glVertexAttribDivisorPtr);
            }
            glVertexAttribDivisorDlg(index, divisor);
        }

        /// <summary>
        /// Draw multiple instances of a range of elements
        /// </summary>
        /// <param name="mode">Specifies what kind of primitives to render.</param>
        /// <param name="first">Specifies the starting index in the enabled arrays.</param>
        /// <param name="count">Specifies the number of indices to be rendered.</param>
        /// <param name="instancecount">Specifies the number of instances of the specified range of indices to be rendered.</param>
        public static void DrawArraysInstanced(RenderModes mode, int first, int count, int instancecount)
        {
            if (glDrawArraysInstancedPtr == IntPtr.Zero)
            {
                glDrawArraysInstancedPtr = Wgl.GetProcAddress("glDrawArraysInstanced");
                glDrawArraysInstancedDlg =
               Marshal.GetDelegateForFunctionPointer<glDrawArraysInstanced>(glDrawArraysInstancedPtr);
            }
            glDrawArraysInstancedDlg(mode, first, count, instancecount);
        }

        /// <summary>
        /// Returns information about an active uniform variable for the specified program object
        /// 
        /// The number of active uniform variables can be obtained by calling glGetProgram with the value 
        /// GL_ACTIVE_UNIFORMS. A value of 0 for index selects the first active uniform variable. 
        /// Permissible values for index range from zero to the number of active uniform variables minus one.
        /// </summary>
        /// <param name="program">Specifies the program object to be queried.</param>
        /// <param name="index">Specifies the index of the uniform variable to be queried.</param>
        /// <param name="size">Returns the size of the uniform variable.</param>
        /// <param name="type">Returns the data type of the uniform variable.</param>
        /// <param name="name">Returns a string containing the name of the uniform variable.</param>
        public static void GetActiveUniform(uint program, int index, out int size, out GLDataTypes type, out string name)
        {
            if (glGetActiveUniformPtr == IntPtr.Zero)
            {
                glGetActiveUniformPtr = Wgl.GetProcAddress("glGetActiveUniform");
                glGetActiveUniformDlg =
               Marshal.GetDelegateForFunctionPointer<glGetActiveUniform>(glGetActiveUniformPtr);
            }
            int bufSize = 2048;
            int length;

            byte[] errmessage = new byte[bufSize];
            GCHandle handle = GCHandle.Alloc(errmessage, GCHandleType.Pinned);
            glGetActiveUniformDlg(program, index, bufSize, out length, out size, out type, handle.AddrOfPinnedObject());

            name = MarshalHelper.PtrToStringUTF8(handle.AddrOfPinnedObject());
            handle.Free();
        }

        /// <summary>
        /// Returns information about an active uniform variable for the specified program object
        /// 
        /// The number of active uniform variables can be obtained by calling glGetProgram with the value 
        /// GL_ACTIVE_UNIFORMS. A value of 0 for index selects the first active uniform variable. 
        /// Permissible values for index range from zero to the number of active uniform variables minus one.
        /// </summary>
        /// <param name="program">Specifies the program object to be queried.</param>
        /// <param name="index">Specifies the index of the uniform variable to be queried.</param>
        /// <param name="bufSize">Specifies the maximum number of characters OpenGL is allowed to write in the character buffer indicated by name.</param>
        /// <param name="length">Returns the number of characters actually written by OpenGL in the string indicated by name (excluding the null terminator) if a value other than NULL is passed.</param>
        /// <param name="size">Returns the size of the uniform variable.</param>
        /// <param name="type">Returns the data type of the uniform variable.</param>
        /// <param name="name">Returns a string containing the name of the uniform variable.</param>
        public static void GetActiveUniform(uint program, int index, int bufSize,
           out int length, out int size, out GLDataTypes type, out string name)
        {
            if (glGetActiveUniformPtr == IntPtr.Zero)
            {
                glGetActiveUniformPtr = Wgl.GetProcAddress("glGetActiveUniform");
                glGetActiveUniformDlg =
               Marshal.GetDelegateForFunctionPointer<glGetActiveUniform>(glGetActiveUniformPtr);
            }
            byte[] errmessage = new byte[bufSize];
            GCHandle handle = GCHandle.Alloc(errmessage, GCHandleType.Pinned);
            glGetActiveUniformDlg(program, index, bufSize, out length, out size, out type, handle.AddrOfPinnedObject());

            name = MarshalHelper.PtrToStringUTF8(handle.AddrOfPinnedObject());
            handle.Free();
        }

        /// <summary>
        /// Returns the location of an attribute variable.
        /// 
        /// glGetAttribLocation queries the previously linked program object specified by program for the 
        /// attribute variable specified by name and returns the index of the generic vertex attribute that 
        /// is bound to that attribute variable. If name is a matrix attribute variable, the index of the 
        /// first column of the matrix is returned. If the named attribute variable is not an active attribute 
        /// in the specified program object or if name starts with the reserved prefix "gl_", a value of -1 is returned.
        /// 
        /// The association between an attribute variable name and a generic attribute index can be specified at 
        /// any time by calling glBindAttribLocation.
        /// Attribute bindings do not go into effect until glLinkProgram is called.
        /// After a program object has been linked successfully, the index values for attribute variables remain 
        /// fixed until the next link command occurs.The attribute values can only be queried after a link if the 
        /// link was successful. glGetAttribLocation returns the binding that actually went into effect the last 
        /// time glLinkProgram was called for the specified program object.
        /// Attribute bindings that have been specified since the last link operation are not returned by glGetAttribLocation.
        /// </summary>
        /// <param name="program">Specifies the program object to be queried.</param>
        /// <param name="name">Points to a null terminated string containing the name of the attribute variable whose location is to be queried.</param>
        /// <returns></returns>
        public static int GetAttribLocation(uint program, string name)
        {
            if (glGetAttribLocationPtr == IntPtr.Zero)
            {
                glGetAttribLocationPtr = Wgl.GetProcAddress("glGetAttribLocation");
                glGetAttribLocationDlg =
               Marshal.GetDelegateForFunctionPointer<glGetAttribLocation>(glGetAttribLocationPtr);
            }
            return glGetAttribLocationDlg(program, name);
        }


        /// <summary>
        /// Used to associate a user-defined attribute variable in the program object 
        /// specified by program with a generic vertex attribute index.
        /// </summary>
        /// <param name="program">Specifies the handle of the program object in which the association is to be made.</param>
        /// <param name="index">Specifies the index of the generic vertex attribute to be bound.</param>
        /// <param name="name">Specifies a null terminated string containing the name of the vertex shader attribute variable to which index is to be bound.</param>
        /// <remarks>
        /// glBindAttribLocation can be called before any vertex shader objects are bound to the 
        /// specified program object. It is also permissible to bind a generic attribute 
        /// index to an attribute variable name that is never used in a vertex shader.
        /// 
        /// If name was bound previously, that information is lost.
        /// Thus you cannot bind one user-defined attribute variable to multiple indices, 
        /// but you can bind multiple user-defined attribute variables to the same index.
        /// Applications are allowed to bind more than one user-defined attribute variable to 
        /// the same generic vertex attribute index.
        /// This is called aliasing, and it is allowed only if just one of the aliased 
        /// attributes is active in the executable program, or if no path through the 
        /// shader consumes more than one attribute of a set of attributes aliased to 
        /// the same location. The compiler and linker are allowed to assume that no aliasing 
        /// is done and are free to employ optimizations that work only in the absence of aliasing.
        /// OpenGL implementations are not required to do error checking to detect aliasing.
        /// Active attributes that are not explicitly bound will be bound by the linker when 
        /// glLinkProgram is called.
        /// The locations assigned can be queried by calling glGetAttribLocation.
        /// OpenGL copies the name string when glBindAttribLocation is called, 
        /// so an application may free its copy of the name string immediately after the 
        /// function returns.
        /// 
        /// Generic attribute locations may be specified in the shader source text using a 
        /// location layout qualifier.
        /// In this case, the location of the attribute specified in the shader's source takes 
        /// precedence and may be queried by calling glGetAttribLocation.
        /// </remarks>
        public static void BindAttribLocation(uint program, int index, string name)
        {
            if (glBindAttribLocationPtr == IntPtr.Zero)
            {
                glBindAttribLocationPtr = Wgl.GetProcAddress("glBindAttribLocation");
                glBindAttribLocationDlg =
               Marshal.GetDelegateForFunctionPointer<glBindAttribLocation>(glBindAttribLocationPtr);
            }
            glBindAttribLocationDlg(program, index, name);
        }

        /// <summary>
        /// glBindFragDataLocation explicitly specifies the binding of the user-defined varying
        /// out variable name to fragment shader color number colorNumber for program program. 
        /// If name was bound previously, its assigned binding is replaced with colorNumber. 
        /// name must be a null-terminated string. colorNumber must be less than GL_MAX_DRAW_BUFFERS.
        /// 
        /// The bindings specified by glBindFragDataLocation have no effect until program is 
        /// next linked.
        /// Bindings may be specified at any time after program has been created.
        /// Specifically, they may be specified before shader objects are attached to the program.
        /// Therefore, any name may be specified in name, including a name that is never 
        /// used as a varying out variable in any fragment shader object. Names beginning with 
        /// gl_ are reserved by the GL.
        /// 
        /// In addition to the errors generated by glBindFragDataLocation, 
        /// the program program will fail to link if:
        /// 
        /// The number of active outputs is greater than the value GL_MAX_DRAW_BUFFERS.
        /// 
        /// More than one varying out variable is bound to the same color number.
        /// </summary>
        /// <param name="program">The name of the program containing varying out variable whose binding to modify</param>
        /// <param name="colorNumber">The color number to bind the user-defined varying out variable to</param>
        /// <param name="name">The name of the user-defined varying out variable whose binding to modify</param>
        public static void BindFragDataLocation(uint program, uint colorNumber, string name)
        {
            if (glBindFragDataLocationPtr == IntPtr.Zero)
            {
                glBindFragDataLocationPtr = Wgl.GetProcAddress("glBindFragDataLocation");
                glBindFragDataLocationDlg =
               Marshal.GetDelegateForFunctionPointer<glBindFragDataLocation>(glBindFragDataLocationPtr);
            }
            glBindFragDataLocationDlg(program, colorNumber, name);
        }

        /// <summary>
        /// glWaitSync causes the GL server to block and wait until sync becomes signaled. 
        /// Sync is the name of an existing sync object upon which to wait. 
        /// Flags and timeout are currently not used and must be set to zero and the 
        /// special value GL_TIMEOUT_IGNORED, respectively. 
        /// glWaitSync will always wait no longer than an implementation-dependent timeout. 
        /// The duration of this timeout in nanoseconds may be queried by calling glGet with 
        /// the parameter GL_MAX_SERVER_WAIT_TIMEOUT. There is currently no way to determine 
        /// whether glWaitSync unblocked because the timeout expired or because the sync 
        /// object being waited on was signaled.
        /// 
        /// If an error occurs, glWaitSync does not cause the GL server to block.
        /// 
        /// glWaitSync is available only if the GL version is 3.2 or higher.
        /// </summary>
        /// <param name="sync"></param>
        /// <param name="flags"></param>
        /// <param name="timeout"></param>
        public static void WaitSync(GLsync sync, uint flags = 0, ulong timeout = 0xFFFFFFFFFFFFFFFFul)
        {
            if (glWaitSyncPtr == IntPtr.Zero)
            {
                glWaitSyncPtr = Wgl.GetProcAddress("glWaitSync");
                glWaitSyncDlg =
               Marshal.GetDelegateForFunctionPointer<glWaitSync>(glWaitSyncPtr);
            }
            glWaitSyncDlg(sync.Handle, flags, timeout);
        }

        /// <summary>
        /// glDeleteSync deletes the sync object specified by sync. 
        /// If the fence command corresponding to the specified sync object has completed, 
        /// or if no glWaitSync or glClientWaitSync commands are blocking on sync, 
        /// the object is deleted immediately. Otherwise, sync is flagged for deletion and 
        /// will be deleted when it is no longer associated with any fence command and is 
        /// no longer blocking any glWaitSync or glClientWaitSync command. 
        /// In either case, after glDeleteSync returns, the name sync is invalid and can 
        /// no longer be used to refer to the sync object.
        /// </summary>
        /// <param name="sync">The sync object to be deleted.</param>
        public static void DeleteSync(GLsync sync)
        {
            if (glDeleteSyncPtr == IntPtr.Zero)
            {
                glDeleteSyncPtr = Wgl.GetProcAddress("glDeleteSync");
                glDeleteSyncDlg =
               Marshal.GetDelegateForFunctionPointer<glDeleteSync>(glDeleteSyncPtr);
            }
            glDeleteSyncDlg(sync.Handle);
        }

        /// <summary>
        /// glFenceSync creates a new fence sync object, inserts a fence command into the 
        /// GL command stream and associates it with that sync object, and returns a 
        /// non-zero name corresponding to the sync object.
        /// 
        /// When the specified condition of the sync object is satisfied by the fence command, 
        /// the sync object is signaled by the GL, causing any glWaitSync, glClientWaitSync 
        /// commands blocking in sync to unblock.No other state is affected by glFenceSync or 
        /// by the execution of the associated fence command.
        /// 
        /// condition must be GL_SYNC_GPU_COMMANDS_COMPLETE.This condition is satisfied by
        /// completion of the fence command corresponding to the sync object and all preceding 
        /// commands in the same command stream. The sync object will not be signaled until 
        /// all effects from these commands on GL client and server state and the framebuffer 
        /// are fully realized.Note that completion of the fence command occurs once the state 
        /// of the corresponding sync object has been changed, but commands waiting on that 
        /// sync object may not be unblocked until after the fence command completes.
        /// </summary>
        /// <param name="condition">Specifies the condition that must be met to set the sync 
        /// object's state to signaled. condition must be GL_SYNC_GPU_COMMANDS_COMPLETE.</param>
        /// <param name="flags">
        /// Specifies a bitwise combination of flags controlling the 
        /// behavior of the sync object. 
        /// No flags are presently defined for this operation and flags must be zero.</param>
        /// <returns></returns>
        public static GLsync FenceSync(uint condition = 0x9117, uint flags = 0)
        {
            if (glFenceSyncPtr == IntPtr.Zero)
            {
                glFenceSyncPtr = Wgl.GetProcAddress("glFenceSync");
                glFenceSyncDlg =
               Marshal.GetDelegateForFunctionPointer<glFenceSync>(glFenceSyncPtr);
            }
            return new GLsync() { Handle = glFenceSyncDlg(condition, flags) };
        }
    }
}