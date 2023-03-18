using static PrairieGL.OpenGL.GLDelegates;

namespace PrairieGL.OpenGL
{
    /// <summary>
    /// This class holds all the function pointers used by the GL class for 
    /// calls to OpenGL that are pointers to unmanaged code rather than 
    /// DLLImports. 
    /// </summary>
    /// <remarks>
    /// It's set up this way so that each function called will check to see 
    /// if it has a valid pointer and if not it should get the pointer and create
    /// a delegate to execute. Once the delegate is created we don't have to 
    /// create it again. An "if intptr != 0" is a cheap test to perform.
    /// I tried creating an init function to call when the application starts
    /// but for some crazy reason the delegates would fail with a ptr cannot be 
    /// zero error. The only way I could get it to work is to have each function 
    /// in GL get the pointer and create the delegate on the fly. Now. Doing this 
    /// each time a function is called is really expensive and the program I'm working 
    /// on would drop from ~75fps to ~25fps. 
    /// So we'll do it this way. :-)
    /// </remarks>
    public class GLFunctionPointers
    {
        public static  IntPtr glGenVertexArraysPtr = IntPtr.Zero; //Wgl.GetProcAddress("glGenVertexArrays");
        public static glGenVertexArrays glGenVertexArraysDlg = null;
        //Marshal.GetDelegateForFunctionPointer<glGenVertexArrays>(glGenVertexArraysPtr);

        public static  IntPtr glBindVertexArrayPtr = IntPtr.Zero; //Wgl.GetProcAddress("glBindVertexArray");
        public static glBindVertexArray glBindVertexArrayDlg = null;
        //Marshal.GetDelegateForFunctionPointer<glBindVertexArray>(glBindVertexArrayPtr);

        public static  IntPtr glGenBuffersPtr = IntPtr.Zero; //Wgl.GetProcAddress("glGenBuffers");
        public static glGenBuffers glGenBuffersDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glGenBuffers>(glGenBuffersPtr);

        public static  IntPtr glBindBufferPtr = IntPtr.Zero; //Wgl.GetProcAddress("glBindBuffer");
        public static glBindBuffer glBindBufferDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glBindBuffer>(glBindBufferPtr);

        public static  IntPtr glBufferDataPtr = IntPtr.Zero; //Wgl.GetProcAddress("glBufferData");
        public static glBufferData glBufferDataDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glBufferData>(glBufferDataPtr);

        public static  IntPtr glNamedBufferDataPtr = IntPtr.Zero; //Wgl.GetProcAddress("glNamedBufferData");
        public static glNamedBufferData glNamedBufferDataDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glNamedBufferData>(glNamedBufferDataPtr);

        public static  IntPtr glUseProgramPtr = IntPtr.Zero; //Wgl.GetProcAddress("glUseProgram");
        public static glUseProgram glUseProgramDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glUseProgram>(glUseProgramPtr);

        public static  IntPtr glEnableVertexAttribArrayPtr = IntPtr.Zero; //Wgl.GetProcAddress("glEnableVertexAttribArray");
        public static glEnableVertexAttribArray glEnableVertexAttribArrayDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glEnableVertexAttribArray>(glEnableVertexAttribArrayPtr);

        public static  IntPtr glDisableVertexAttribArrayPtr = IntPtr.Zero; //Wgl.GetProcAddress("glDisableVertexAttribArray");
        public static glDisableVertexAttribArray glDisableVertexAttribArrayDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glDisableVertexAttribArray>(glDisableVertexAttribArrayPtr);

        public static  IntPtr glEnableVertexArrayAttribPtr = IntPtr.Zero; //Wgl.GetProcAddress("glEnableVertexArrayAttrib");
        public static glEnableVertexArrayAttrib glEnableVertexArrayAttribDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glEnableVertexArrayAttrib>(glEnableVertexArrayAttribPtr);

        public static  IntPtr glDisableVertexArrayAttribPtr = IntPtr.Zero; //Wgl.GetProcAddress("glDisableVertexArrayAttrib");
        public static glDisableVertexArrayAttrib glDisableVertexArrayAttribDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glDisableVertexArrayAttrib>(glDisableVertexArrayAttribPtr);

        public static  IntPtr glVertexAttribPointerPtr = IntPtr.Zero; //Wgl.GetProcAddress("glVertexAttribPointer");
        public static glVertexAttribPointer glVertexAttribPointerDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glVertexAttribPointer>(glVertexAttribPointerPtr);

        public static  IntPtr glVertexAttribIPointerPtr = IntPtr.Zero; //Wgl.GetProcAddress("glVertexAttribIPointer");
        public static glVertexAttribIPointer glVertexAttribIPointerDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glVertexAttribIPointer>(glVertexAttribIPointerPtr);

        public static  IntPtr glVertexAttribLPointerPtr = IntPtr.Zero; //Wgl.GetProcAddress("glVertexAttribLPointer");
        public static glVertexAttribLPointer glVertexAttribLPointerDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glVertexAttribLPointer>(glVertexAttribLPointerPtr);

        public static  IntPtr glDrawRangeElementsPtr = IntPtr.Zero; //Wgl.GetProcAddress("glDrawRangeElements");
        public static glDrawRangeElements glDrawRangeElementsDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glDrawRangeElements>(glDrawRangeElementsPtr);

        public static  IntPtr glDeleteBuffersPtr = IntPtr.Zero; //Wgl.GetProcAddress("glDeleteBuffers");
        public static glDeleteBuffers glDeleteBuffersDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glDeleteBuffers>(glDeleteBuffersPtr);

        public static  IntPtr glDeleteVertexArraysPtr = IntPtr.Zero; //Wgl.GetProcAddress("glDeleteVertexArrays");
        public static glDeleteVertexArrays glDeleteVertexArraysDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glDeleteVertexArrays>(glDeleteVertexArrays);

        public static  IntPtr glDeleteProgramPtr = IntPtr.Zero; //Wgl.GetProcAddress("glDeleteProgram");
        public static glDeleteProgram glDeleteProgramDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glDeleteProgram>(glDeleteProgramPtr);

        public static  IntPtr glCreateShaderPtr = IntPtr.Zero; //Wgl.GetProcAddress("glCreateShader");
        public static glCreateShader glCreateShaderDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glCreateShader>(glCreateShaderPtr);

        public static  IntPtr glShaderSourcePtr = IntPtr.Zero; //Wgl.GetProcAddress("glShaderSource");
        public static glShaderSource glShaderSourceDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glShaderSource>(glShaderSourcePtr);

        public static  IntPtr glCompileShaderPtr = IntPtr.Zero; //Wgl.GetProcAddress("glCompileShader");
        public static glCompileShader glCompileShaderDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glCompileShader>(glCompileShaderPtr);

        public static  IntPtr glGetShaderivPtr = IntPtr.Zero; //Wgl.GetProcAddress("glGetShaderiv");
        public static glGetShaderiv glGetShaderivDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glGetShaderiv>(glGetShaderivPtr);

        public static  IntPtr glGetShaderInfoLogPtr = IntPtr.Zero; //Wgl.GetProcAddress("glGetShaderInfoLog");
        public static glGetShaderInfoLog glGetShaderInfoLogDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glGetShaderInfoLog>(glGetShaderInfoLogPtr);

        public static  IntPtr glCreateProgramPtr = IntPtr.Zero; //Wgl.GetProcAddress("glCreateProgram");
        public static glCreateProgram glCreateProgramDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glCreateProgram>(glCreateProgramPtr);

        public static  IntPtr glAttachShaderPtr = IntPtr.Zero; //Wgl.GetProcAddress("glAttachShader");
        public static glAttachShader glAttachShaderDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glAttachShader>(glAttachShaderPtr);

        public static  IntPtr glLinkProgramPtr = IntPtr.Zero; //Wgl.GetProcAddress("glLinkProgram");
        public static glLinkProgram glLinkProgramDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glLinkProgram>(glLinkProgramPtr);

        public static  IntPtr glGetProgramivPtr = IntPtr.Zero; //Wgl.GetProcAddress("glGetProgramiv");
        public static glGetProgramiv glGetProgramivDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glGetProgramiv>(glGetProgramivPtr);

        public static  IntPtr glGetProgramInfoLogPtr = IntPtr.Zero; //Wgl.GetProcAddress("glGetProgramInfoLog");
        public static glGetProgramInfoLog glGetProgramInfoLogDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glGetProgramInfoLog>(glGetProgramInfoLogPtr);

        public static  IntPtr glDetachShaderPtr = IntPtr.Zero; //Wgl.GetProcAddress("glDetachShader");
        public static glDetachShader glDetachShaderDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glDetachShader>(glDetachShaderPtr);

        public static  IntPtr glDeleteShaderPtr = IntPtr.Zero; //Wgl.GetProcAddress("glDeleteShader");
        public static glDeleteShader glDeleteShaderDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glDeleteShader>(glDeleteShaderPtr);

        public static  IntPtr glUniform1fPtr = IntPtr.Zero; //Wgl.GetProcAddress("glUniform1f");
        public static glUniform1f glUniform1fDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glUniform1f>(glUniform1fPtr);

        public static  IntPtr glUniform2fPtr = IntPtr.Zero; //Wgl.GetProcAddress("glUniform2f");
        public static glUniform2f glUniform2fDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glUniform2f>(glUniform2fPtr);

        public static  IntPtr glUniform3fPtr = IntPtr.Zero; //Wgl.GetProcAddress("glUniform3f");
        public static glUniform3f glUniform3fDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glUniform3f>(glUniform3fPtr);

        public static  IntPtr glUniform4fPtr = IntPtr.Zero; //Wgl.GetProcAddress("glUniform4f");
        public static glUniform4f glUniform4fDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glUniform4f>(glUniform4fPtr);

        public static  IntPtr glUniform1iPtr = IntPtr.Zero; //Wgl.GetProcAddress("glUniform1i");
        public static glUniform1i glUniform1iDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glUniform1i>(glUniform1iPtr);

        public static  IntPtr glUniform2iPtr = IntPtr.Zero; //Wgl.GetProcAddress("glUniform2i");
        public static glUniform2i glUniform2iDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glUniform2i>(glUniform2iPtr);

        public static  IntPtr glUniform3iPtr = IntPtr.Zero; //Wgl.GetProcAddress("glUniform3i");
        public static glUniform3i glUniform3iDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glUniform3i>(glUniform3iPtr);

        public static  IntPtr glUniform4iPtr = IntPtr.Zero; //Wgl.GetProcAddress("glUniform4i");
        public static glUniform4i glUniform4iDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glUniform4i>(glUniform4iPtr);

        public static  IntPtr glUniform1uiPtr = IntPtr.Zero; //Wgl.GetProcAddress("glUniform1ui");
        public static glUniform1ui glUniform1uiDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glUniform1ui>(glUniform1uiPtr);

        public static  IntPtr glUniform2uiPtr = IntPtr.Zero; //Wgl.GetProcAddress("glUniform2ui");
        public static glUniform2ui glUniform2uiDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glUniform2ui>(glUniform2uiPtr);

        public static  IntPtr glUniform3uiPtr = IntPtr.Zero; //Wgl.GetProcAddress("glUniform3ui");
        public static glUniform3ui glUniform3uiDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glUniform3ui>(glUniform3uiPtr);

        public static  IntPtr glUniform4uiPtr = IntPtr.Zero; //Wgl.GetProcAddress("glUniform4ui");
        public static glUniform4ui glUniform4uiDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glUniform4ui>(glUniform4uiPtr);

        public static  IntPtr glUniform1fvPtr = IntPtr.Zero; //Wgl.GetProcAddress("glUniform1fv");
        public static glUniform1fv glUniform1fvDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glUniform1fv>(glUniform1fvPtr);

        public static  IntPtr glUniform2fvPtr = IntPtr.Zero; //Wgl.GetProcAddress("glUniform2fv");
        public static glUniform2fv glUniform2fvDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glUniform2fv>(glUniform2fvPtr);

        public static  IntPtr glUniform3fvPtr = IntPtr.Zero; //Wgl.GetProcAddress("glUniform3fv");
        public static glUniform3fv glUniform3fvDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glUniform3fv>(glUniform3fvPtr);

        public static  IntPtr glUniform4fvPtr = IntPtr.Zero; //Wgl.GetProcAddress("glUniform4fv");
        public static glUniform4fv glUniform4fvDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glUniform4fv>(glUniform4fvPtr);

        public static  IntPtr glUniform1ivPtr = IntPtr.Zero; //Wgl.GetProcAddress("glUniform1iv");
        public static glUniform1iv glUniform1ivDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glUniform1iv>(glUniform1ivPtr);

        public static  IntPtr glUniform2ivPtr = IntPtr.Zero; //Wgl.GetProcAddress("glUniform2iv");
        public static glUniform2iv glUniform2ivDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glUniform2iv>(glUniform2ivPtr);

        public static  IntPtr glUniform3ivPtr = IntPtr.Zero; //Wgl.GetProcAddress("glUniform3iv");
        public static glUniform3iv glUniform3ivDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glUniform3iv>(glUniform3ivPtr);

        public static  IntPtr glUniform4ivPtr = IntPtr.Zero; //Wgl.GetProcAddress("glUniform4iv");
        public static glUniform4iv glUniform4ivDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glUniform4iv>(glUniform4ivPtr);

        public static  IntPtr glUniform1uivPtr = IntPtr.Zero; //Wgl.GetProcAddress("glUniform1uiv");
        public static glUniform1uiv glUniform1uivDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glUniform1uiv>(glUniform1uivPtr);

        public static  IntPtr glUniform2uivPtr = IntPtr.Zero; //Wgl.GetProcAddress("glUniform2uiv");
        public static glUniform2uiv glUniform2uivDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glUniform2uiv>(glUniform2uivPtr);

        public static  IntPtr glUniform3uivPtr = IntPtr.Zero; //Wgl.GetProcAddress("glUniform3uiv");
        public static glUniform3uiv glUniform3uivDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glUniform3uiv>(glUniform3uivPtr);

        public static  IntPtr glUniform4uivPtr = IntPtr.Zero; //Wgl.GetProcAddress("glUniform4uiv");
        public static glUniform4uiv glUniform4uivDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glUniform4uiv>(glUniform4uivPtr);

        public static  IntPtr glUniformMatrix2fvPtr = IntPtr.Zero; //Wgl.GetProcAddress("glUniformMatrix2fv");
        public static glUniformMatrix2fv glUniformMatrix2fvDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glUniformMatrix2fv>(glUniformMatrix2fvPtr);

        public static  IntPtr glUniformMatrix3fvPtr = IntPtr.Zero; //Wgl.GetProcAddress("glUniformMatrix3fv");
        public static glUniformMatrix3fv glUniformMatrix3fvDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glUniformMatrix3fv>(glUniformMatrix3fvPtr);

        public static  IntPtr glUniformMatrix4fvPtr = IntPtr.Zero; //Wgl.GetProcAddress("glUniformMatrix4fv");
        public static glUniformMatrix4fv glUniformMatrix4fvDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glUniformMatrix4fv>(glUniformMatrix4fvPtr);

        public static  IntPtr glUniformMatrix2x3fvPtr = IntPtr.Zero; //Wgl.GetProcAddress("glUniformMatrix2x3fv");
        public static glUniformMatrix2x3fv glUniformMatrix2x3fvDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glUniformMatrix2x3fv>(glUniformMatrix2x3fvPtr);

        public static  IntPtr glUniformMatrix3x2fvPtr = IntPtr.Zero; //Wgl.GetProcAddress("glUniformMatrix3x2fv");
        public static glUniformMatrix3x2fv glUniformMatrix3x2fvDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glUniformMatrix3x2fv>(glUniformMatrix3x2fvPtr);

        public static  IntPtr glUniformMatrix2x4fvPtr = IntPtr.Zero; //Wgl.GetProcAddress("glUniformMatrix2x4fv");
        public static glUniformMatrix2x4fv glUniformMatrix2x4fvDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glUniformMatrix2x4fv>(glUniformMatrix2x4fvPtr);

        public static  IntPtr glUniformMatrix4x2fvPtr = IntPtr.Zero; //Wgl.GetProcAddress("glUniformMatrix4x2fv");
        public static glUniformMatrix4x2fv glUniformMatrix4x2fvDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glUniformMatrix4x2fv>(glUniformMatrix4x2fvPtr);

        public static  IntPtr glUniformMatrix3x4fvPtr = IntPtr.Zero; //Wgl.GetProcAddress("glUniformMatrix3x4fv");
        public static glUniformMatrix3x4fv glUniformMatrix3x4fvDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glUniformMatrix3x4fv>(glUniformMatrix3x4fvPtr);

        public static  IntPtr glUniformMatrix4x3fvPtr = IntPtr.Zero; //Wgl.GetProcAddress("glUniformMatrix4x3fv");
        public static glUniformMatrix4x3fv glUniformMatrix4x3fvDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glUniformMatrix4x3fv>(glUniformMatrix4x3fvPtr);

        public static  IntPtr glGetUniformLocationPtr = IntPtr.Zero; //Wgl.GetProcAddress("glGetUniformLocation");
        public static glGetUniformLocation glGetUniformLocationDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glGetUniformLocation>(glGetUniformLocationPtr);

        public static  IntPtr glGetUniformfvPtr = IntPtr.Zero; //Wgl.GetProcAddress("glGetUniformfv");
        public static glGetUniformfv glGetUniformfvDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glGetUniformfv>(glGetUniformfvPtr);

        public static  IntPtr glGetUniformivPtr = IntPtr.Zero; //Wgl.GetProcAddress("glGetUniformiv");
        public static glGetUniformiv glGetUniformivDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glGetUniformiv>(glGetUniformivPtr);

        public static  IntPtr glGetUniformuivPtr = IntPtr.Zero; //Wgl.GetProcAddress("glGetUniformuiv");
        public static glGetUniformuiv glGetUniformuivDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glGetUniformuiv>(glGetUniformuivPtr);

        public static  IntPtr glGetUniformdvPtr = IntPtr.Zero; //Wgl.GetProcAddress("glGetUniformdv");
        public static glGetUniformdv glGetUniformdvDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glGetUniformdv>(glGetUniformdvPtr);

        public static  IntPtr glGetnUniformfvPtr = IntPtr.Zero; //Wgl.GetProcAddress("glGetnUniformfv");
        public static glGetnUniformfv glGetnUniformfvDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glGetnUniformfv>(glGetnUniformfvPtr);

        public static  IntPtr glGetnUniformivPtr = IntPtr.Zero; //Wgl.GetProcAddress("glGetnUniformiv");
        public static glGetnUniformiv glGetnUniformivDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glGetnUniformiv>(glGetnUniformivPtr);

        public static  IntPtr glGetnUniformuivPtr = IntPtr.Zero; //Wgl.GetProcAddress("glGetnUniformuiv");
        public static glGetnUniformuiv glGetnUniformuivDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glGetnUniformuiv>(glGetnUniformuivPtr);

        public static  IntPtr glGetnUniformdvPtr = IntPtr.Zero; //Wgl.GetProcAddress("glGetnUniformdv");
        public static glGetnUniformdv glGetnUniformdvDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glGetnUniformdv>(glGetnUniformdvPtr);

        public static  IntPtr glEnableiPtr = IntPtr.Zero; //Wgl.GetProcAddress("glEnablei");
        public static glEnablei glEnableiDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glEnablei>(glEnableiPtr);

        public static  IntPtr glDisableiPtr = IntPtr.Zero; //Wgl.GetProcAddress("glDisablei");
        public static glDisablei glDisableiDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glDisablei>(glDisableiPtr);

        public static  IntPtr glActiveTexturePtr = IntPtr.Zero; //Wgl.GetProcAddress("glActiveTexture");
        public static glActiveTexture glActiveTextureDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glActiveTexture>(glActiveTexturePtr);

        public static  IntPtr glTextureParameterfPtr = IntPtr.Zero; //Wgl.GetProcAddress("glTextureParameterf");
        public static glTextureParameterf glTextureParameterfDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glTextureParameterf>(glTextureParameterfPtr);

        public static  IntPtr glTextureParameteriPtr = IntPtr.Zero; //Wgl.GetProcAddress("glTextureParameteri");
        public static glTextureParameteri glTextureParameteriDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glTextureParameteri>(glTextureParameteriPtr);

        public static  IntPtr glTexParameterIivPtr = IntPtr.Zero; //Wgl.GetProcAddress("glTexParameterIiv");
        public static glTexParameterIiv glTexParameterIivDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glTexParameterIiv>(glTexParameterIivPtr);

        public static  IntPtr glTexParameterIuivPtr = IntPtr.Zero; //Wgl.GetProcAddress("glTexParameterIuiv");
        public static glTexParameterIuiv glTexParameterIuivDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glTexParameterIuiv>(glTexParameterIuivPtr);

        public static  IntPtr glTextureParameterfvPtr = IntPtr.Zero; //Wgl.GetProcAddress("glTextureParameterfv");
        public static glTextureParameterfv glTextureParameterfvDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glTextureParameterfv>(glTextureParameterfvPtr);

        public static  IntPtr glTextureParameterivPtr = IntPtr.Zero; //Wgl.GetProcAddress("glTextureParameteriv");
        public static glTextureParameteriv glTextureParameterivDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glTextureParameteriv>(glTextureParameterivPtr);

        public static  IntPtr glTextureParameterIivPtr = IntPtr.Zero; //Wgl.GetProcAddress("glTextureParameterIiv");
        public static glTextureParameterIiv glTextureParameterIivDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glTextureParameterIiv>(glTextureParameterIivPtr);

        public static  IntPtr glTextureParameterIuivPtr = IntPtr.Zero; //Wgl.GetProcAddress("glTextureParameterIuiv");
        public static glTextureParameterIuiv glTextureParameterIuivDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glTextureParameterIuiv>(glTextureParameterIuivPtr);

        public static  IntPtr glGenerateMipmapPtr = IntPtr.Zero; //Wgl.GetProcAddress("glGenerateMipmap");
        public static glGenerateMipmap glGenerateMipmapDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glGenerateMipmap>(glGenerateMipmapPtr);

        public static  IntPtr glGenerateTextureMipmapPtr = IntPtr.Zero; //Wgl.GetProcAddress("glGenerateTextureMipmap");
        public static glGenerateTextureMipmap glGenerateTextureMipmapDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glGenerateTextureMipmap>(glGenerateTextureMipmapPtr);

        public static  IntPtr glCompressedTexImage2DPtr = IntPtr.Zero; //Wgl.GetProcAddress("glCompressedTexImage2D");
        public static glCompressedTexImage2D glCompressedTexImage2DDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glCompressedTexImage2D>(glCompressedTexImage2DPtr);

        public static  IntPtr glGetStringiPtr = IntPtr.Zero; //Wgl.GetProcAddress("glGetStringi");
        public static glGetStringi glGetStringiDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glGetStringi>(glGetStringiPtr);

        public static  IntPtr glDebugMessageControlPtr = IntPtr.Zero; //Wgl.GetProcAddress("glDebugMessageControl");
        public static glDebugMessageControl glDebugMessageControlDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glDebugMessageControl>(glDebugMessageControlPtr);

        public static  IntPtr glDebugMessageCallbackARBPtr = IntPtr.Zero; //Wgl.GetProcAddress("glDebugMessageCallbackARB");
        public static glDebugMessageCallbackARB glDebugMessageCallbackARBDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glDebugMessageCallbackARB>(glDebugMessageCallbackARBPtr);

        public static  IntPtr glDebugMessageCallbackPtr = IntPtr.Zero; //Wgl.GetProcAddress("glDebugMessageCallback");
        public static glDebugMessageCallback glDebugMessageCallbackDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glDebugMessageCallback>(glDebugMessageCallbackPtr);


        public static  IntPtr glGetDebugMessageLogPtr = IntPtr.Zero; //Wgl.GetProcAddress("glGetDebugMessageLog");
        public static glGetDebugMessageLog glGetDebugMessageLogDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glGetDebugMessageLog>(glGetDebugMessageLogPtr);

        public static  IntPtr glGenFramebuffersPtr = IntPtr.Zero; //Wgl.GetProcAddress("glGenFramebuffers");
        public static glGenFramebuffers glGenFramebuffersDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glGenFramebuffers>(glGenFramebuffersPtr);

        public static  IntPtr glBindFramebufferPtr = IntPtr.Zero; //Wgl.GetProcAddress("glBindFramebuffer");
        public static glBindFramebuffer glBindFramebufferDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glBindFramebuffer>(glBindFramebufferPtr);

        public static  IntPtr glGenRenderbuffersPtr = IntPtr.Zero; //Wgl.GetProcAddress("glGenRenderbuffers");
        public static glGenRenderbuffers glGenRenderbuffersDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glGenRenderbuffers>(glGenRenderbuffersPtr);

        public static  IntPtr glBindRenderbufferPtr = IntPtr.Zero; //Wgl.GetProcAddress("glBindRenderbuffer");
        public static glBindRenderbuffer glBindRenderbufferDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glBindRenderbuffer>(glBindRenderbufferPtr);

        public static  IntPtr glRenderbufferStoragePtr = IntPtr.Zero; //Wgl.GetProcAddress("glRenderbufferStorage");
        public static glRenderbufferStorage glRenderbufferStorageDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glRenderbufferStorage>(glRenderbufferStoragePtr);

        public static  IntPtr glNamedRenderbufferStoragePtr = IntPtr.Zero; //Wgl.GetProcAddress("glNamedRenderbufferStorage");
        public static glNamedRenderbufferStorage glNamedRenderbufferStorageDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glNamedRenderbufferStorage>(glNamedRenderbufferStoragePtr);

        public static  IntPtr glFramebufferRenderbufferPtr = IntPtr.Zero; //Wgl.GetProcAddress("glFramebufferRenderbuffer");
        public static glFramebufferRenderbuffer glFramebufferRenderbufferDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glFramebufferRenderbuffer>(glFramebufferRenderbufferPtr);

        public static  IntPtr glNamedFramebufferRenderbufferPtr = IntPtr.Zero; //Wgl.GetProcAddress("glNamedFramebufferRenderbuffer");
        public static glNamedFramebufferRenderbuffer glNamedFramebufferRenderbufferDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glNamedFramebufferRenderbuffer>(glNamedFramebufferRenderbufferPtr);

        public static  IntPtr glFramebufferTexturePtr = IntPtr.Zero; //Wgl.GetProcAddress("glFramebufferTexture");
        public static glFramebufferTexture glFramebufferTextureDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glFramebufferTexture>(glFramebufferTexturePtr);

        public static  IntPtr glFramebufferTexture1DPtr = IntPtr.Zero; //Wgl.GetProcAddress("glFramebufferTexture1D");
        public static glFramebufferTexture1D glFramebufferTexture1DDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glFramebufferTexture1D>(glFramebufferTexture1DPtr);

        public static  IntPtr glFramebufferTexture2DPtr = IntPtr.Zero; //Wgl.GetProcAddress("glFramebufferTexture2D");
        public static glFramebufferTexture2D glFramebufferTexture2DDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glFramebufferTexture2D>(glFramebufferTexture2DPtr);

        public static  IntPtr glFramebufferTexture3DPtr = IntPtr.Zero; //Wgl.GetProcAddress("glFramebufferTexture3D");
        public static glFramebufferTexture3D glFramebufferTexture3DDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glFramebufferTexture3D>(glFramebufferTexture3DPtr);

        public static  IntPtr glNamedFramebufferTexturePtr = IntPtr.Zero; //Wgl.GetProcAddress("glNamedFramebufferTexture");
        public static glNamedFramebufferTexture glNamedFramebufferTextureDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glNamedFramebufferTexture>(glNamedFramebufferTexturePtr);

        public static  IntPtr glDrawBuffersPtr = IntPtr.Zero; //Wgl.GetProcAddress("glDrawBuffers");
        public static glDrawBuffers glDrawBuffersDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glDrawBuffers>(glDrawBuffersPtr);

        public static  IntPtr glNamedFramebufferDrawBuffersPtr = IntPtr.Zero; //Wgl.GetProcAddress("glNamedFramebufferDrawBuffers");
        public static glNamedFramebufferDrawBuffers glNamedFramebufferDrawBuffersDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glNamedFramebufferDrawBuffers>(glNamedFramebufferDrawBuffersPtr);

        public static  IntPtr glCheckFramebufferStatusPtr = IntPtr.Zero; //Wgl.GetProcAddress("glCheckFramebufferStatus");
        public static glCheckFramebufferStatus glCheckFramebufferStatusDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glCheckFramebufferStatus>(glCheckFramebufferStatusPtr);

        public static  IntPtr glCheckNamedFramebufferStatusPtr = IntPtr.Zero; //Wgl.GetProcAddress("glCheckNamedFramebufferStatus");
        public static glCheckNamedFramebufferStatus glCheckNamedFramebufferStatusDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glCheckNamedFramebufferStatus>(glCheckNamedFramebufferStatusPtr);

        public static  IntPtr glDeleteFramebuffersPtr = IntPtr.Zero; //Wgl.GetProcAddress("glDeleteFramebuffers");
        public static glDeleteFramebuffers glDeleteFramebuffersDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glDeleteFramebuffers>(glDeleteFramebuffersPtr);

        public static  IntPtr glDeleteRenderbuffersPtr = IntPtr.Zero; //Wgl.GetProcAddress("glDeleteRenderbuffers");
        public static glDeleteRenderbuffers glDeleteRenderbuffersDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glDeleteRenderbuffers>(glDeleteRenderbuffersPtr);

        public static  IntPtr glBufferSubDataPtr = IntPtr.Zero; //Wgl.GetProcAddress("glBufferSubData");
        public static glBufferSubData glBufferSubDataDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glBufferSubData>(glBufferSubDataPtr);
        
        public static  IntPtr glNamedBufferSubDataPtr = IntPtr.Zero; //Wgl.GetProcAddress("glNamedBufferSubData");
        public static glNamedBufferSubData glNamedBufferSubDataDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glNamedBufferSubData>(glNamedBufferSubDataPtr);

        public static  IntPtr glVertexAttribDivisorPtr = IntPtr.Zero; //Wgl.GetProcAddress("glVertexAttribDivisor");
        public static glVertexAttribDivisor glVertexAttribDivisorDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glVertexAttribDivisor>(glVertexAttribDivisorPtr);

        public static  IntPtr glDrawArraysInstancedPtr = IntPtr.Zero; //Wgl.GetProcAddress("glDrawArraysInstanced");
        public static glDrawArraysInstanced glDrawArraysInstancedDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glDrawArraysInstanced>(glDrawArraysInstancedPtr);

        public static  IntPtr glGetActiveUniformPtr = IntPtr.Zero; //Wgl.GetProcAddress("glGetActiveUniform");
        public static glGetActiveUniform glGetActiveUniformDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glGetActiveUniform>(glGetActiveUniformPtr);

        public static  IntPtr glGetAttribLocationPtr = IntPtr.Zero; //Wgl.GetProcAddress("glGetAttribLocation");
        public static glGetAttribLocation glGetAttribLocationDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glGetAttribLocation>(glGetAttribLocationPtr);

        public static  IntPtr glBindAttribLocationPtr = Wgl.GetProcAddress("glBindAttribLocation");
        public static glBindAttribLocation glBindAttribLocationDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glBindAttribLocation>(glBindAttribLocationPtr);

        public static  IntPtr glBindFragDataLocationPtr = IntPtr.Zero; //Wgl.GetProcAddress("glBindFragDataLocation");
        public static glBindFragDataLocation glBindFragDataLocationDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glBindFragDataLocation>(glBindFragDataLocationPtr);

        public static  IntPtr glWaitSyncPtr = IntPtr.Zero; //Wgl.GetProcAddress("glWaitSync");
        public static glWaitSync glWaitSyncDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glWaitSync>(glWaitSyncPtr);

        public static  IntPtr glDeleteSyncPtr = IntPtr.Zero; //Wgl.GetProcAddress("glDeleteSync");
        public static glDeleteSync glDeleteSyncDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glDeleteSync>(glDeleteSyncPtr);

        public static  IntPtr glFenceSyncPtr = IntPtr.Zero; //Wgl.GetProcAddress("glFenceSync");
        public static glFenceSync glFenceSyncDlg = null;
       //Marshal.GetDelegateForFunctionPointer<glFenceSync>(glFenceSyncPtr);

    }
}
