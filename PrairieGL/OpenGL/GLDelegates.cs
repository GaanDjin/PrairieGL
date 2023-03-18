using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static PrairieGL.OpenGL.GLDelegates;

namespace PrairieGL.OpenGL
{
    /// <summary>
    /// This class holds the OpenGL function header definitions. 
    /// Used by the <see cref="GL"/> class to invoke OpenGL.
    /// For more details see the <see cref="GL"/> class.
    /// </summary>
    public class GLDelegates
    {
        public delegate void glClearColor(float red, float green, float blue, float alpha);

        public delegate void glClear(GLColourMasks mask);

        public delegate void glGenVertexArrays(int n, uint[] arrays);

        public delegate void glBindVertexArray(uint array);

        public delegate void glGenBuffers(int n, uint[] buffers);

        public delegate void glBindBuffer(BufferTargets target, uint buffer);

        public delegate void glBufferData(BufferTargets target, /*intptr */ int size, IntPtr data, BufferUsages usage);

        public delegate void glNamedBufferData(uint buffer, /*intptr */ int size, IntPtr data, BufferUsages usage);

        public delegate void glUseProgram(uint program);

        public delegate void glEnableVertexAttribArray(uint index);

        public delegate void glDisableVertexAttribArray(uint index);
 
        public delegate void glEnableVertexArrayAttrib(uint vaobj, uint index);

        public delegate void glDisableVertexArrayAttrib(uint vaobj, uint index);

        public delegate void glVertexAttribPointer(uint index, int size, GLDataTypes type, bool normalized, int stride, int pointer);

        public delegate void glVertexAttribIPointer(uint index, int size, GLDataTypes type, int stride, int pointer);
 
        public delegate void glVertexAttribLPointer(uint index, int size, GLDataTypes type, int stride, int pointer);
 
        public delegate void glDrawArrays(RenderModes mode, int first, int count);

        public delegate void glDrawRangeElements(RenderModes mode,
             int start,
        int end,
             int count,
             GLDataTypes type,
     uint indices);

        public delegate void glDeleteBuffers(int n, uint[] buffers);

        public delegate void glDeleteVertexArrays(int n, uint[] arrays);

        public delegate void glDeleteProgram(uint program);

        public delegate uint glCreateShader(ShaderProgramTypes shaderType);

        public delegate void glShaderSource(uint shader, int count, string[] str, int[] length);

        public delegate void glCompileShader(uint shader);

        public delegate void glGetShaderiv(uint shader, ShaderParameters pname, out int parameters);
 
        public delegate void glGetShaderInfoLog(uint shader, int maxLength, out int length, IntPtr infoLog);

        public delegate uint glCreateProgram();

        public delegate void glAttachShader(uint program, uint shader);

        public delegate void glLinkProgram(uint program);

        public delegate void glGetProgramiv(uint program, ProgramParameters pname, out int parameters);
 
        public delegate void glGetProgramInfoLog(uint program, int maxLength, out int length, IntPtr infoLog);

        public delegate void glDetachShader(uint program, uint shader);

        public delegate void glDeleteShader(uint shader);

        public delegate void glUniform1f(int location, float v0);

        public delegate void glUniform2f(int location, float v0, float v1);

        public delegate void glUniform3f(int location, float v0, float v1, float v2);

        public delegate void glUniform4f(int location, float v0, float v1, float v2, float v3);

        public delegate void glUniform1i(int location, int v0);

        public delegate void glUniform2i(int location, int v0, int v1);

        public delegate void glUniform3i(int location, int v0, int v1, int v2);

        public delegate void glUniform4i(int location, int v0, int v1, int v2, int v3);

        public delegate void glUniform1ui(int location, uint v0);

        public delegate void glUniform2ui(int location, uint v0, uint v1);

        public delegate void glUniform3ui(int location, uint v0, uint v1, uint v2);

        public delegate void glUniform4ui(int location, uint v0, uint v1, uint v2, uint v3);

        public delegate void glUniform1fv(int location, int count, float[] value);

        public delegate void glUniform2fv(int location, int count, float[] value);

        public delegate void glUniform3fv(int location, int count, float[] value);

        public delegate void glUniform4fv(int location, int count, float[] value);

        public delegate void glUniform1iv(int location, int count, int[] value);

        public delegate void glUniform2iv(int location, int count, int[] value);

        public delegate void glUniform3iv(int location, int count, int[] value);

        public delegate void glUniform4iv(int location, int count, int[] value);

        public delegate void glUniform1uiv(int location, int count, uint[] value);

        public delegate void glUniform2uiv(int location, int count, uint[] value);

        public delegate void glUniform3uiv(int location, int count, uint[] value);

        public delegate void glUniform4uiv(int location, int count, uint[] value);

        public delegate void glUniformMatrix2fv(int location, int count, bool transpose, float[] value);

        public delegate void glUniformMatrix3fv(int location, int count, bool transpose, float[] value);

        public delegate void glUniformMatrix4fv(int location, int count, bool transpose, float[] value);

        public delegate void glUniformMatrix2x3fv(int location, int count, bool transpose, float[] value);

        public delegate void glUniformMatrix3x2fv(int location, int count, bool transpose, float[] value);

        public delegate void glUniformMatrix2x4fv(int location, int count, bool transpose, float[] value);

        public delegate void glUniformMatrix4x2fv(int location, int count, bool transpose, float[] value);

        public delegate void glUniformMatrix3x4fv(int location, int count, bool transpose, float[] value);

        public delegate void glUniformMatrix4x3fv(int location, int count, bool transpose, float[] value);

        public delegate int glGetUniformLocation(uint program, string name);

        public delegate void glGetUniformfv(uint program, int location, out float parameters);

        public delegate void glGetUniformiv(uint program, int location, out int parameters);

        public delegate void glGetUniformuiv(uint program, int location, out uint parameters);

        public delegate void glGetUniformdv(uint program, int location, out double parameters);

        public delegate void glGetnUniformfv(uint program, int location, int bufSize, ref float[] parameters);

        public delegate void glGetnUniformiv(uint program, int location, int bufSize, ref int[] parameters);

        public delegate void glGetnUniformuiv(uint program, int location, int bufSize, ref uint[] parameters);

        public delegate void glGetnUniformdv(uint program, int location, int bufSize, ref double[] parameters);

        public delegate void glEnable(GLCapabilities cap);

        public delegate void glDisable(GLCapabilities cap);

        public delegate void glEnablei(GLCapabilities cap, uint index);

        public delegate void glDisablei(GLCapabilities cap, uint index);

        public delegate void glDepthFunc(GLComparisonFunctions func);

        public delegate void glActiveTexture(TextureUnits texture);

        public delegate void glBindTexture(TextureTargets target, uint texture);

        public delegate void glDeleteTextures(int n, uint[] textures);

        public delegate void glGenTextures(int n, uint[] textures);


        public delegate void glTexImage2D<T>(TextureTargets target,
             int level,
             ImagePixelFormats internalformat,
             int width,
             int height,
             int border,
             ImagePixelFormats format,
             ImagePixelDataTypes type,
             T[] data);

        public delegate void glTexImage2D(TextureTargets target,
             int level,
             ImagePixelFormats internalformat,
             int width,
             int height,
             int border,
             ImagePixelFormats format,
             ImagePixelDataTypes type,
             IntPtr data);

        public delegate void glTexParameterf(TextureTargets target, TextureParameters pname, float param);

        public delegate void glTexParameteri(TextureTargets target, TextureParameters pname, int param);

        public delegate void glTextureParameterf(uint texture, TextureParameters pname, float param);

        public delegate void glTextureParameteri(uint texture, TextureParameters pname, int param);

        public delegate void glTexParameterfv(TextureTargets target, TextureParameters pname, float[] parameters);

        public delegate void glTexParameteriv(TextureTargets target, TextureParameters pname, int[] parameters);

        public delegate void glTexParameterIiv(TextureTargets target, TextureParameters pname, int[] parameters);

        public delegate void glTexParameterIuiv(TextureTargets target, TextureParameters pname, uint[] parameters);

        public delegate void glTextureParameterfv(uint texture, TextureParameters pname, float[] parameters);

        public delegate void glTextureParameteriv(uint texture, TextureParameters pname, int[] parameters);

        public delegate void glTextureParameterIiv(uint texture, TextureParameters pname,  int[] parameters);

        public delegate void glTextureParameterIuiv(uint texture, TextureParameters pname, uint[] parameters);

        public delegate void glGenerateMipmap(TextureTargets target);

        public delegate void glGenerateTextureMipmap(uint texture);

        public delegate void glPixelStoref(PixelPackingFormats pname, float param);

        public delegate void glPixelStorei(PixelPackingFormats pname, int param);

        public delegate void glCompressedTexImage2D(TextureTargets target, int level, CompressedTextureImageFormats internalformat, int width, int height, int border, int imageSize, byte[] data);

        public delegate void glDrawElements<T>(RenderModes mode, int count, DrawIndexTypes type, T[] indices) where T: unmanaged;

        public delegate void glDrawElements(RenderModes mode, int count, DrawIndexTypes type, IntPtr indices);

        public delegate GLErrors glGetError();

        public delegate void glBlendFunc(BlendingFactor sfactor, BlendingFactor dfactor);

        public delegate void glBlendFunci(uint buf, BlendingFactor sfactor, BlendingFactor dfactor);

        public delegate void glGetBooleanv(GetValueParameters pname, out bool[] data);

        public delegate void glGetDoublev(GetValueParameters pname, out double[] data);

        public delegate void glGetFloatv(GetValueParameters pname, out float[] data);

        public delegate void glGetIntegerv(GetValueParameters pname, out int[] data);

        public delegate void glGetInteger64v(GetValueParameters pname, out long[] data);

        public delegate void glGetBooleani_v(GetValueParameters target, int index, out bool[] data);

        public delegate void glGetIntegeri_v(GetValueParameters target, int index, int[] data);

        public delegate void glGetFloati_v(GetValueParameters target, int index, float[] data);

        public delegate void glGetDoublei_v(GetValueParameters target, int index, double[] data);

        public delegate void glGetInteger64i_v(GetValueParameters target, int index, long[] data);

        public delegate IntPtr glGetString(CurrentConnectionInfo name);

        public delegate IntPtr glGetStringi(CurrentConnectionInfo name, int index);

        public delegate void glDebugMessageControl(ErrorSources source,
     ErrorType type,
     ErrorSeverity severity,
     int count, 
     uint[] ids,
     bool enabled);

        public delegate void glDebugOutputCallbackARB(
            ErrorSources source, 
            ErrorType type, 
            uint id, 
            ErrorSeverity severity, 
            int length, 
            IntPtr message, 
            IntPtr userParam);

        public delegate void glDebugMessageCallbackARB(glDebugOutputCallbackARB callback, IntPtr userParam);


        public delegate void glDebugMessageCallback(GL.DebugMessageCallbackDelegate callback, IntPtr userParam);

        public delegate uint glGetDebugMessageLog(uint count, int bufSize, ref ErrorSources[] sources,
            ref ErrorType[] types, ref uint[] ids, ref ErrorSeverity[] severities, ref int[] lengths, IntPtr messageLog);

        public delegate void glMatrixMode(MatrixModes mode);

        public delegate void glLoadMatrixd( double[] m);

        public delegate void glLoadMatrixf( float[] m);

        public delegate void glColor3b(byte red, byte green, byte blue);

        public delegate void glColor3s(short red, short green, short blue);

        public delegate void glColor3i(int red, int green, int blue);

        public delegate void glColor3f(float red, float green, float blue);

        public delegate void glColor3d(double red, double green, double blue);

        public delegate void glColor3ub(byte red, byte green, byte blue);

        public delegate void glColor3us(ushort red, ushort green, ushort blue);

        public delegate void glColor3ui(uint red, uint green, uint blue);

        public delegate void glColor4b(byte red, byte green, byte blue, byte alpha);

        public delegate void glColor4s(short red, short green, short blue, short alpha);

        public delegate void glColor4i(int red, int green, int blue, int alpha);

        public delegate void glColor4f(float red, float green, float blue, float alpha);

        public delegate void glColor4d(double red, double green, double blue, double alpha);

        public delegate void glColor4ub(byte red, byte green, byte blue, byte alpha);

        public delegate void glColor4us(ushort red, ushort green, ushort blue, ushort alpha);

        public delegate void glColor4ui(uint red, uint green, uint blue, uint alpha);

        public delegate void glBegin(RenderModes mode);

        public delegate void glEnd();

        public delegate void glVertex2s(short x, short y);

        public delegate void glVertex2i(int x, int y);

        public delegate void glVertex2f(float x, float y);

        public delegate void glVertex2d(double x, double y);

        public delegate void glVertex3s(short x, short y, short z);

        public delegate void glVertex3i(int x, int y, int z);

        public delegate void glVertex3f(float x, float y, float z);

        public delegate void glVertex3d(double x, double y, double z);

        public delegate void glVertex4s(short x, short y, short z, short w);

        public delegate void glVertex4i(int x, int y, int z, int w);

        public delegate void glVertex4f(float x, float y, float z, float w);

        public delegate void glVertex4d(double x, double y, double z, double w);

        public delegate void glVertex2sv(short[] v);

        public delegate void glVertex2iv(int[] v);

        public delegate void glVertex2fv(float[] v);

        public delegate void glVertex2dv(double[] v);

        public delegate void glVertex3sv(short[] v);

        public delegate void glVertex3iv(int[] v);

        public delegate void glVertex3fv(float[] v);

        public delegate void glVertex3dv(double[] v);

        public delegate void glVertex4sv(short[] v);

        public delegate void glVertex4iv(int[] v);

        public delegate void glVertex4fv(float[] v);

        public delegate void glVertex4dv(double[] v);

        public delegate void glGenFramebuffers(int n, uint[] ids);

        public delegate void glBindFramebuffer(FrameBufferTargets target, uint framebuffer);

        public delegate void glGenRenderbuffers(int n, uint[] renderbuffers);

        public delegate void glBindRenderbuffer(RenderBufferTargets target, uint renderbuffer);

        public delegate void glRenderbufferStorage(RenderBufferTargets target, ImagePixelFormats internalformat, int width, int height);

        public delegate void glNamedRenderbufferStorage(uint renderbuffer, ImagePixelFormats internalformat, int width, int height);

        public delegate void glFramebufferRenderbuffer(FrameBufferTargets target, RenderBufferAttachments attachment, RenderBufferTargets renderbuffertarget, uint renderbuffer);

        public delegate void glNamedFramebufferRenderbuffer(uint framebuffer, RenderBufferAttachments attachment, RenderBufferTargets renderbuffertarget, uint renderbuffer);

        public delegate void glFramebufferTexture(FrameBufferTargets target, RenderBufferAttachments attachment,
             uint texture, int level);

        public delegate void glFramebufferTexture1D(FrameBufferTargets target,
             RenderBufferAttachments attachment, TextureTargets textarget,
             uint texture, int level);

        public delegate void glFramebufferTexture2D(FrameBufferTargets target,
             RenderBufferAttachments attachment, TextureTargets textarget,
             uint texture, int level);

        public delegate void glFramebufferTexture3D(FrameBufferTargets target,
             RenderBufferAttachments attachment, TextureTargets textarget,
             uint texture, int level, int layer);

        public delegate void glNamedFramebufferTexture(uint framebuffer, RenderBufferAttachments attachment, 
            uint texture, int level);

        public delegate void glDrawBuffers(int n, RenderBufferAttachments[] bufs);

        public delegate void glNamedFramebufferDrawBuffers(uint framebuffer, int n, RenderBufferAttachments[] bufs);

        public delegate FrameBufferStatuses glCheckFramebufferStatus(FrameBufferTargets target);

        public delegate FrameBufferStatuses glCheckNamedFramebufferStatus(uint framebuffer, FrameBufferTargets target);

        public delegate void glViewport(int x, int y, int width, int height);

        public delegate void glDeleteFramebuffers(int n, uint[]  framebuffers);

        public delegate void glDeleteRenderbuffers(int n, uint[] renderbuffers);

        public delegate void glBufferSubData(BufferTargets target, int offset, int size, IntPtr data);

        public delegate void glNamedBufferSubData(uint buffer, int offset, int size, IntPtr data);

        public delegate void glVertexAttribDivisor(uint index, uint divisor);

        public delegate void glDrawArraysInstanced(RenderModes mode, int first, int count, int instancecount);

        public delegate void glGetActiveUniform(uint program, int index, int bufSize,
           out int length, out int size, out GLDataTypes type, IntPtr name);

        public delegate int glGetAttribLocation(uint program, string name);

        public delegate void glBindAttribLocation(uint program, int index, string name);

        public delegate void glBindFragDataLocation(uint program, uint colorNumber, string name);

        public delegate void glWaitSync(int sync, uint flags, ulong timeout);

        public delegate void glDeleteSync(int sync);

        public delegate int glFenceSync(uint condition, uint flags);

    }
}
