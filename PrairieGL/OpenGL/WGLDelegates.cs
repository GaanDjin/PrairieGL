using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrairieGL.OpenGL
{
    public class WGLDelegates
    {
        public delegate IntPtr wglCreateContext(IntPtr windowDrawingContext);
        public delegate bool wglDeleteContext(IntPtr unnamedParam1 );
        public delegate bool wglMakeCurrent(IntPtr deviceContext, IntPtr openglRenderingContext);
        public delegate bool wglShareLists(IntPtr mainRenderContext, IntPtr secondRenderContext);


    }
}
