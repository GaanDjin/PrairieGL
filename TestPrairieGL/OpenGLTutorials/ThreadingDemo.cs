using PrairieGL.Glfw;
using PrairieGL.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static PrairieGL.OpenGL.GL;
using static TestPrairieGL.OpenGLTutorials.ThreadingDemo;

///https://github.com/SnopyDogy/GLFW3-Tutorials/blob/master/MultiThreadedDemo/ThreadingDemo.cpp

namespace TestPrairieGL.OpenGLTutorials
{
    internal class ThreadingDemo
    {
        ////////////////////////// Constants //////////////////////////////////
        const int c_iDefaultScreenWidth = 1280;
        const int c_iDefaultScreenHeight = 720;

        const string c_szDefaultPrimaryWindowTitle = "Threading Demo - Primary Window";
        const string c_szDefaultSecondaryWindowTitle = "Threading Demo - Secondary Window";


        ///////////////////// Custom Data Types ///////////////////////////////
        enum ExitCodes
        {
            EC_NO_ERROR = 0,
            EC_GLFW_INIT_FAIL = 1,
            EC_GLFW_FIRST_WINDOW_CREATION_FAIL = 2,
        };

        public struct WindowHandle
        {
            public GLFWwindow m_pWindow;
            //public GLContext m_pGLEWContext;
            public uint m_uiWidth;
            public uint m_uiHeight;
            public Matrix4x4 m_m4Projection;
            public Matrix4x4 m_m4ViewMatrix;

            public uint m_uiID;
        };

        public struct FPSData
        {
            public float m_fFPS;
            public float m_fFrameCount;
            public float m_fTimeBetweenChecks;
            public float m_fTimeElapsed;
            // temp vars for calcing delta time:
            public float m_fCurrnetRunTime;
            public float m_fPreviousRunTime;
        };

        public struct Vertex
        {
            public Vector4 m_v4Position;
            public Vector2 m_v2UV;
            public Vector4 m_v4Colour;
        };

        public struct Quad
        {
            public const uint c_uiNoOfIndicies = 6;
            public const uint c_uiNoOfVerticies = 4;
            public Vertex[] m_Verticies = new Vertex[c_uiNoOfVerticies];
            public uint[] m_uiIndicies = new uint[c_uiNoOfIndicies];

            public Quad() { }
        };


        /////////////////////////// Shaders ///////////////////////////////////
        const string c_szVertexShader = "#version 330\n" +
    "in vec4 Position;\n" +
    "in vec2 UV;\n" +
    "in vec4 Colour;\n" +
    "out vec2 vUV;\n" +
    "out vec4 vColour;\n" +
    "uniform mat4 Projection;\n" +
    "uniform mat4 View;\n" +
    "uniform mat4 Model;\n" +
    "void main()\n" +
    "{\n" +
        "vUV = UV;\n" +
        "vColour = Colour;" +
        "gl_Position = Projection * View * Model * Position;\n" +
    "}\n" +
    "\n";

        const string c_szPixelShader = "#version 330\n" +
    "in vec2 vUV;\n" +
    "in vec4 vColour;\n" +
    "out vec4 outColour;\n" +
    "uniform sampler2D diffuseTexture;\n" +
    "void main()\n" +
    "{\n" +
        "outColour = texture2D(diffuseTexture, vUV) + vColour;\n" +
    "}\n" +
    "\n";







        // info: http://www.baptiste-wicht.com/2012/04/c11-concurrency-tutorial-advanced-locking-and-condition-variables/
        //////////////////////// global Vars //////////////////////////////
        static uint g_uiWindowCounter = 0;                         // used to set window IDs

        static List<WindowHandle> g_lWindows = new List<WindowHandle>();
        static Dictionary<uint, uint> g_mVAOs = new Dictionary<uint, uint>();
        static Dictionary<int, WindowHandle> g_mCurrentContextMap = new Dictionary<int, WindowHandle>();   // store current contex per thread!

        static WindowHandle g_hPrimaryWindow = default(WindowHandle);
        static WindowHandle g_hSecondaryWindow = default(WindowHandle);

        static uint g_VBO = 0;
        static uint g_IBO = 0;
        static uint g_Texture = 0;
        static uint g_Shader = 0;
        static Matrix4x4 g_ModelMatrix;

        static Task g_tpWin2 = null;
        static object g_RenderLock = new object();
        static GLsync g_MainThreadFenceSync;
        static GLsync g_SecondThreadFenceSync;
        static bool g_bShouldClose;
        static bool g_bDoWork;

        static Dictionary<uint, FPSData> m_mFPSData = new Dictionary<uint, FPSData>();

        static GL.DebugMessageCallbackDelegate GLdebugDelegate;
        static GCHandle GLCallbackDelegate;


        static GlfwDelegates.GLFWerrorfun GlfwdebugDelegate;
        static GCHandle GlfwCallbackDelegate;

        static GLContext mainContext;
        static GLContext childContext = null;

        static bool parentLoopReady = false;
        static bool childLoopReady = false;

        //////////////////////// Function Definitions //////////////////////////////
        public static int Main()
        {
            ExitCodes iReturnCode = ExitCodes.EC_NO_ERROR;

            iReturnCode = Init();
            if (iReturnCode != ExitCodes.EC_NO_ERROR)
                return (int)iReturnCode;

            // use this to simulate 3ms of work per window.
            g_bDoWork = true;

            /* Use the following loop to have this demo run like the
            original Multi-Window tutorial code. its here for comparison. */
            //iReturnCode = MainLoop();

            /* My initial naive attempt at multithreading on a per window basis.
            This loop will try to render from both threads simultaneously.
            WARNING: RUN AT YOUR OWN RISK. I have had this loop crash on several occasions,
            it is not stable and is only here as an example on how not to do it. */
            //iReturnCode = MainLoopBAD();

            /* This loop is a working/stable example of how to render from multipul threads. 
            Notice that this does NOT render from both threads at the same time. 
            */
            iReturnCode = MainLoopTHREADED();


            if (iReturnCode != ExitCodes.EC_NO_ERROR)
                return (int)iReturnCode;

            iReturnCode = ShutDown();
            if (iReturnCode != ExitCodes.EC_NO_ERROR)
                return (int)iReturnCode;

            return (int)iReturnCode;
        }


        static ExitCodes Init()
        {
            // Setup Our GLFW error callback, we do this before Init so we know what goes wrong with init if it fails:

            if (GlfwCallbackDelegate != null && GlfwCallbackDelegate.IsAllocated)
                GlfwCallbackDelegate.Free();

            GlfwdebugDelegate = new GlfwDelegates.GLFWerrorfun(GLFWErrorCallback);
            GlfwCallbackDelegate = GCHandle.Alloc(GlfwdebugDelegate);

            Glfw.SetErrorCallback(GLFWErrorCallback);

            // Init GLFW:
            if (Glfw.Init() == 0)
                return ExitCodes.EC_GLFW_INIT_FAIL;

            // create our first window:
            g_hPrimaryWindow = CreateWindow(c_iDefaultScreenWidth, c_iDefaultScreenHeight, c_szDefaultPrimaryWindowTitle, null);

            if (g_hPrimaryWindow.m_pWindow.Handle.Handle == IntPtr.Zero)
            {
                Glfw.Terminate();
                return ExitCodes.EC_GLFW_FIRST_WINDOW_CREATION_FAIL;
            }

            // Print out GLFW, OpenGL version and GLEW Version:
            int iOpenGLMajor = Glfw.GetWindowAttrib(g_hPrimaryWindow.m_pWindow, WindowHints.GLFW_CONTEXT_VERSION_MAJOR);
            int iOpenGLMinor = Glfw.GetWindowAttrib(g_hPrimaryWindow.m_pWindow, WindowHints.GLFW_CONTEXT_VERSION_MINOR);
            int iOpenGLRevision = Glfw.GetWindowAttrib(g_hPrimaryWindow.m_pWindow, WindowHints.GLFW_CONTEXT_REVISION);
            Console.WriteLine("Status: Using GLFW Version " + Glfw.GetVersionString());
            Console.WriteLine("Status: Using OpenGL Version: " + iOpenGLMajor + "." + iOpenGLMinor + ", Revision: " + iOpenGLRevision);
            //Console.WriteLine("Status: Using GLEW %s\n", glewGetString(GLEW_VERSION));

            // create our second window:
            g_hSecondaryWindow = CreateWindow(c_iDefaultScreenWidth, c_iDefaultScreenHeight, c_szDefaultSecondaryWindowTitle, g_hPrimaryWindow);

            MakeContextCurrent(g_hPrimaryWindow);

            // start creating our quad data for later use:
            //std::future<Quad> fQuad = std::async(std::launch::async, CreateQuad);
            Quad fQuad = CreateQuad();
            Vector4[] ptexData = new Vector4[256 * 256];
            //std::future<Vector4*> ftexData = std::async(std::launch::async, [ptexData]().Vector4 *

            //{
            for (int i = 0; i < 256 * 256; i += 256)
            {
                for (int j = 0; j < 256; ++j)
                {
                    if (j % 2 == 0)
                        ptexData[i + j] = new Vector4(0, 0, 0, 1);
                    else
                        ptexData[i + j] = new Vector4(1, 1, 1, 1);
                }
            }

            //return ptexData;
            //} );

            // create shader:
            int iSuccess = 0;
            string acLog; // = new byte[256];
            uint vsHandle = GL.CreateShader(ShaderProgramTypes.GL_VERTEX_SHADER);
            uint fsHandle = GL.CreateShader(ShaderProgramTypes.GL_FRAGMENT_SHADER);

            GL.ShaderSource(vsHandle, 1, new string[1] { c_szVertexShader }, new int[1] { c_szVertexShader.Length });
            GL.CompileShader(vsHandle);
            GL.GetShaderiv(vsHandle, ShaderParameters.GL_COMPILE_STATUS, out iSuccess);
            GL.GetShaderInfoLog(vsHandle, 256, out _, out acLog);
            if (iSuccess == 0)
            {
                Console.WriteLine("Error: Failed to compile vertex shader!\n");
                Console.WriteLine(acLog);
                Console.WriteLine("\n");
            }

            GL.ShaderSource(fsHandle, 1, new string[1] { c_szPixelShader }, new int[1] { c_szPixelShader.Length });
            GL.CompileShader(fsHandle);
            GL.GetShaderiv(fsHandle, ShaderParameters.GL_COMPILE_STATUS, out iSuccess);
            GL.GetShaderInfoLog(fsHandle, 256, out _, out acLog);
            if (iSuccess == 0)
            {
                Console.WriteLine("Error: Failed to compile fragment shader!\n");
                Console.WriteLine(acLog);
                Console.WriteLine("\n");
            }

            g_Shader = GL.CreateProgram();
            GL.AttachShader(g_Shader, vsHandle);
            GL.AttachShader(g_Shader, fsHandle);
            GL.DeleteShader(vsHandle);
            GL.DeleteShader(fsHandle);

            // specify Vertex Attribs:
            GL.BindAttribLocation(g_Shader, 0, "Position");
            GL.BindAttribLocation(g_Shader, 1, "UV");
            GL.BindAttribLocation(g_Shader, 2, "Colour");
            GL.BindFragDataLocation(g_Shader, 0, "outColour");

            GL.LinkProgram(g_Shader);
            GL.GetProgramiv(g_Shader, ProgramParameters.GL_LINK_STATUS, out iSuccess);
            GL.GetProgramInfoLog(g_Shader, 256, out _, out acLog);
            if (iSuccess == 0)
            {
                Console.WriteLine("Error: failed to link Shader Program!\n");
                Console.WriteLine(acLog);
                Console.WriteLine("\n");
            }

            GL.UseProgram(g_Shader);

            //byte[] texData = new byte[ptexData.Length * Marshal.SizeOf<Vector4>()]; // ftexData.get();

//            Array.Copy(ptexData, 0, texData, 0, ptexData.LongLength);

            g_Texture = GL.GenTexture();
            GL.BindTexture(TextureTargets.GL_TEXTURE_2D, g_Texture);
            GL.TexImage2D(TextureTargets.GL_TEXTURE_2D, 0, ImagePixelFormats.GL_RGBA, 256, 256, 0, ImagePixelFormats.GL_RGBA, ImagePixelDataTypes.GL_FLOAT, ptexData);

            //ptexData = null;

            // specify default filtering and wrapping 
            GL.TexParameterf(TextureTargets.GL_TEXTURE_2D, TextureParameters.GL_TEXTURE_MIN_FILTER, (float)TextureParameterValues.GL_LINEAR);
            GL.TexParameterf(TextureTargets.GL_TEXTURE_2D, TextureParameters.GL_TEXTURE_MAG_FILTER, (float)TextureParameterValues.GL_LINEAR);
            GL.TexParameterf(TextureTargets.GL_TEXTURE_2D, TextureParameters.GL_TEXTURE_WRAP_S, (float)TextureParameterValues.GL_REPEAT);
            GL.TexParameterf(TextureTargets.GL_TEXTURE_2D, TextureParameters.GL_TEXTURE_WRAP_T, (float)TextureParameterValues.GL_REPEAT);

            // set the texture to use slot 0 in the shader
            int texUniformID = GL.GetUniformLocation(g_Shader, "diffuseTexture");
            GL.Uniform1i(texUniformID, 0);

            // Create VBO/IBO
            g_VBO = GL.GenBuffer();
            g_IBO = GL.GenBuffer();
            GL.BindBuffer(BufferTargets.GL_ARRAY_BUFFER, g_VBO);
            GL.BindBuffer(BufferTargets.GL_ELEMENT_ARRAY_BUFFER, g_IBO);

            // get the quad from the future:
            Quad temp = fQuad; //.get();

            GL.BufferData(BufferTargets.GL_ARRAY_BUFFER, /*(int)Quad.c_uiNoOfVerticies * Marshal.SizeOf(typeof(Vertex)),*/ temp.m_Verticies, BufferUsages.GL_STATIC_DRAW);
            GL.BufferData(BufferTargets.GL_ELEMENT_ARRAY_BUFFER, /*(int)Quad.c_uiNoOfIndicies * Marshal.SizeOf(typeof(uint)),*/ temp.m_uiIndicies, BufferUsages.GL_STATIC_DRAW);

            // Now do window specific stuff, including:
            // -. Creating a VAO with the VBO/IBO created above!
            // -. Setting Up Projection and View Matricies!
            // -. Specifing OpenGL Options for the window!
            for (int i = 0; i < g_lWindows.Count; i++)
            {
                WindowHandle window = g_lWindows[i];
                MakeContextCurrent(window);

                // Setup VAO:
                //g_mVAOs[window.m_uiID] = 0;
                g_mVAOs[window.m_uiID] = GL.GenVertexArray();
                GL.BindVertexArray(g_mVAOs[window.m_uiID]);
                GL.BindBuffer(BufferTargets.GL_ARRAY_BUFFER, g_VBO);
                GL.BindBuffer(BufferTargets.GL_ELEMENT_ARRAY_BUFFER, g_IBO);

                GL.EnableVertexAttribArray(0);
                GL.EnableVertexAttribArray(1);
                GL.EnableVertexAttribArray(2);
                GL.VertexAttribPointer(0, 4, GLDataTypes.GL_FLOAT, false, Marshal.SizeOf(typeof(Vertex)), 0);
                GL.VertexAttribPointer(1, 2, GLDataTypes.GL_FLOAT, false, Marshal.SizeOf(typeof(Vertex)), 16);
                GL.VertexAttribPointer(2, 4, GLDataTypes.GL_FLOAT, false, Marshal.SizeOf(typeof(Vertex)), 24);

                // Setup Matrix:
                window.m_m4Projection = Matrix4x4.CreatePerspective(45.0f, (float)(window.m_uiWidth) / (float)(window.m_uiHeight), 0.1f, 1000.0f);
                window.m_m4ViewMatrix = Matrix4x4.CreateLookAt(new Vector3(window.m_uiID * 8, 8, 8), new Vector3(0, 0, 0), new Vector3(0, 1, 0));

                // set OpenGL Options:
                GL.Viewport(0, 0, (int)window.m_uiWidth, (int)window.m_uiHeight);
                GL.ClearColor(0.25f, 0.25f, 0.25f, 1);
                GL.Enable(GLCapabilities.GL_DEPTH_TEST);
                GL.Enable(GLCapabilities.GL_CULL_FACE);

                // setup FPS Data
                FPSData fpsData = new FPSData();
                fpsData.m_fFPS = 0;
                fpsData.m_fTimeBetweenChecks = 3.0f;   // calc fps every 3 seconds!!
                fpsData.m_fFrameCount = 0;
                fpsData.m_fTimeElapsed = 0.0f;
                fpsData.m_fCurrnetRunTime = (float)Glfw.GetTime();
                m_mFPSData[window.m_uiID] = fpsData;
            }

            Console.WriteLine("Init completed on thread ID: " + Thread.CurrentThread.ManagedThreadId);

            return ExitCodes.EC_NO_ERROR;
        }


        //      ExitCodes MainLoop()
        //      {
        //          Console.WriteLine("Entering main loop on thread ID: " + std::this_thread::get_id());

        //          while (!ShouldClose())
        //          {
        //              float fTime = (float)glfwGetTime();   // get time for this iteration

        //              Matrix4x4 identity;
        //              g_ModelMatrix = glm::rotate(identity, fTime * 10.0f, Vector3(0.0f, 1.0f, 0.0f));

        //              // simulate work:
        //              if (g_bDoWork)
        //              {
        //                  std::chrono::milliseconds dura( 6 );
        //                  std::this_thread::sleep_for(dura);
        //              }

        //              // draw each window in sequence:
        //              for (const auto&window : g_lWindows)
        //{
        //                  MakeContextCurrent(window);

        //                  // clear the backbuffer to our clear colour and clear the depth buffer
        //                  glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

        //                  glUseProgram(g_Shader);

        //                  GLuint ProjectionID = glGetUniformLocation(g_Shader, "Projection");
        //                  GLuint ViewID = glGetUniformLocation(g_Shader, "View");
        //                  GLuint ModelID = glGetUniformLocation(g_Shader, "Model");

        //                  glUniformMatrix4fv(ProjectionID, 1, false, glm::value_ptr(window.m_m4Projection));
        //                  glUniformMatrix4fv(ViewID, 1, false, glm::value_ptr(window.m_m4ViewMatrix));
        //                  glUniformMatrix4fv(ModelID, 1, false, glm::value_ptr(g_ModelMatrix));

        //                  glActiveTexture(GL_TEXTURE0);
        //                  glBindTexture(GL_TEXTURE_2D, g_Texture);
        //                  glBindVertexArray(g_mVAOs[window.m_uiID]);
        //                  glDrawElements(GL_TRIANGLES, 6, GL_UNSIGNED_INT, 0);

        //                  glfwSwapBuffers(window.m_pWindow);  // make this loop through all current windows??

        //                  // calc FPS:
        //                  CalcFPS(window);
        //              }

        //              glfwPollEvents(); // process events!
        //          }

        //          Console.WriteLine("Exiting main loop on thread ID: " + std::this_thread::get_id());

        //          return EC_NO_ERROR;
        //      }


        //      ExitCodes MainLoopBAD()
        //      {
        //          Console.WriteLine("Entering main loop on thread ID: " + std::this_thread::get_id());

        //          MakeContextCurrent(g_hPrimaryWindow);

        //          while (!ShouldClose())
        //          {
        //              // Keep Running!
        //              // get delta time for this iteration:
        //              float fDeltaTime = (float)glfwGetTime();

        //              Matrix4x4 identity;
        //              g_ModelMatrix = glm::rotate(identity, fDeltaTime * 10.0f, Vector3(0.0f, 1.0f, 0.0f));

        //              // render threaded.
        //              std::thread renderWindow2(&Render, g_hSecondaryWindow);
        //              Render(g_hPrimaryWindow);

        //              // calc FPS:
        //              CalcFPS(g_hSecondaryWindow);
        //              CalcFPS(g_hPrimaryWindow);

        //              // join second render thread
        //              renderWindow2.join();

        //              glfwPollEvents(); // process events!
        //          }

        //          Console.WriteLine("Exiting main loop on thread ID: " + std::this_thread::get_id());

        //          return EC_NO_ERROR;
        //      }


        static ExitCodes MainLoopTHREADED()
        {
            Console.WriteLine("Entering main loop on thread ID: " + Thread.CurrentThread.ManagedThreadId);


            mainContext = new GLContext(g_hPrimaryWindow.m_pWindow);
            
            // spin off the thread for window 2 thread if it hasn't alread been done:
            if (g_tpWin2 == null)
            {
                g_tpWin2 = new Task(ChildLoop, g_hSecondaryWindow);
                g_tpWin2.Start();
            }

            while (childContext == null || !childLoopReady)
            {
                Thread.Sleep(3);
            }

            //MakeContextCurrent(g_hPrimaryWindow);
            bool currentResult = Wgl.MakeCurrent(mainContext.WindowDC, mainContext.Handle);

            parentLoopReady = true;

            // init the sync fece to something so the initial render pass for the main thread wuill work:
            g_SecondThreadFenceSync = GL.FenceSync();

            g_bShouldClose = ShouldClose();
            while (!g_bShouldClose)
            {
                // Keep Running!
                // get delta time for this iteration:
                float fDeltaTime = (float)Glfw.GetTime();

                Matrix4x4 identity;
                g_ModelMatrix = Matrix4x4.CreateRotationY(fDeltaTime * 10.0f); //, new Vector3(0.0f, 1.0f, 0.0f));

                // simulate work:
                if (g_bDoWork)
                {
                    //std::chrono::milliseconds dura( 3 );
                    //std::this_thread::sleep_for(dura);
                    Thread.Sleep(3);
                }

                lock (g_RenderLock) {
                    GL.WaitSync(g_SecondThreadFenceSync);             // tell the GPU to make sure that the second threads calls are in the pipline before adding ours!
                    GL.DeleteSync(g_SecondThreadFenceSync);
                    Render(g_hPrimaryWindow);
                    g_MainThreadFenceSync = GL.FenceSync();  // setup our fence sync for the other thread to wait on it.
                } 

                // calc FPS:
                CalcFPS(g_hPrimaryWindow);

                Glfw.PollEvents(); // process events!
                g_bShouldClose = ShouldClose();  // check if we should close:

            }

            Console.WriteLine("Exiting main loop on thread ID: " + Thread.CurrentThread.ManagedThreadId);

            return ExitCodes.EC_NO_ERROR;
        }


        static void ChildLoop(object state)
        {
            WindowHandle a_toWindow = (WindowHandle)state;

            Console.WriteLine("Starting Secondary Render Thread: " + Thread.CurrentThread.ManagedThreadId);
            //MakeContextCurrent(g_hSecondaryWindow);

            childContext = new GLContext(g_hSecondaryWindow.m_pWindow);
            bool currentResult = Wgl.MakeCurrent(IntPtr.Zero, IntPtr.Zero);
            childLoopReady = true;

            while (!g_bShouldClose && g_MainThreadFenceSync.Handle == 0 && !parentLoopReady)
            {
                 //dont start rendering until the main thread has started rendering for the first time.
                Thread.Sleep(1);
            }

            currentResult = Wgl.MakeCurrent(childContext.WindowDC, childContext.Handle);
            bool shareResult = Wgl.ShareLists(mainContext.Handle, childContext.Handle);

            while (!g_bShouldClose)
            {
                // simulate work:
                if (g_bDoWork)
                {
                    //std::chrono::milliseconds dura( 3 );
                    //std::this_thread::sleep_for(dura);
                    Thread.Sleep(3);
                }

                lock (g_RenderLock)
                {
                    GL.WaitSync(g_MainThreadFenceSync);       // tell the GPU to make sure that the second threads calls are in the pipline before adding ours!
                    GL.DeleteSync(g_MainThreadFenceSync);
                    Render(a_toWindow);
                    g_SecondThreadFenceSync = GL.FenceSync();    // setup our fence sync for the other thread to wait on it.
                } 

                // calc FPS:
                CalcFPS(g_hSecondaryWindow);
            }
        }


        static void Render(WindowHandle a_toWindow)
        {
            //MakeContextCurrent(a_toWindow);

            // clear the backbuffer to our clear colour and clear the depth buffer
            GL.Clear(GLColourMasks.GL_COLOR_BUFFER_BIT | GLColourMasks.GL_DEPTH_BUFFER_BIT);

            GL.UseProgram(g_Shader);

            int ProjectionID = GL.GetUniformLocation(g_Shader, "Projection");
            int ViewID = GL.GetUniformLocation(g_Shader, "View");
            int ModelID = GL.GetUniformLocation(g_Shader, "Model");

            GL.UniformMatrix4fv(ProjectionID, 1, false, a_toWindow.m_m4Projection);
            GL.UniformMatrix4fv(ViewID, 1, false, a_toWindow.m_m4ViewMatrix);
            GL.UniformMatrix4fv(ModelID, 1, false, g_ModelMatrix);

            GL.ActiveTexture(TextureUnits.GL_TEXTURE0);
            GL.BindTexture(TextureTargets.GL_TEXTURE_2D, g_Texture);
            GL.BindVertexArray(g_mVAOs[a_toWindow.m_uiID]);
            GL.DrawElements(RenderModes.GL_TRIANGLES, 6, DrawIndexTypes.GL_UNSIGNED_INT);

            Glfw.SwapBuffers(a_toWindow.m_pWindow);  // make this loop through all current windows??

            //CheckForGLErrors("Render Error");
        }


        static ExitCodes ShutDown()
        {
            // join the window2 thread and delete it:
            if (g_tpWin2 != null && g_tpWin2.Status == TaskStatus.Running)
            {
                g_tpWin2.Wait(); //.join();
                g_tpWin2 = null;
            }

            // delete the FPS data:
            //foreach (KeyValuePair<uint, FPSData> itr in m_mFPSData)
            //{
            //    itr.Value = null;
            //}

            // cleanup any remaining windows:
            for (int i = 0; i < g_lWindows.Count; i++)
            {
                WindowHandle window = g_lWindows[i];
                //window.m_pGLEWContext = null;
                Glfw.DestroyWindow(window.m_pWindow);

                //window; 
            }

            // terminate GLFW:
            Glfw.Terminate();


            if (GLCallbackDelegate != null && GLCallbackDelegate.IsAllocated)
                GLCallbackDelegate.Free();

            return ExitCodes.EC_NO_ERROR;
        }


        //GLContext glewGetContext()
        //{
        //    //return g_hCurrentContext.m_pGLEWContext;
        //    int thread = Thread.CurrentThread.ManagedThreadId;

        //    //if (!g_mCurrentContextMap.ContainsKey(thread))

        //        return g_mCurrentContextMap[thread].m_pGLEWContext;
        //}


        static void MakeContextCurrent(WindowHandle a_hWindowHandle)
        {
            //if (a_hWindowHandle != null)
            {
                int thread = Thread.CurrentThread.ManagedThreadId;

                Glfw.MakeContextCurrent(a_hWindowHandle.m_pWindow);
                g_mCurrentContextMap[thread] = a_hWindowHandle;
            }
        }


        static WindowHandle CreateWindow(int a_iWidth, int a_iHeight, string a_szTitle, WindowHandle? a_hShare)
        {
            // save current active context info so we can restore it later!
            int thread = Thread.CurrentThread.ManagedThreadId;
            WindowHandle hPreviousContext;

            if (g_mCurrentContextMap.ContainsKey(thread))
                hPreviousContext = g_mCurrentContextMap[thread];
            else
            {
                hPreviousContext = new WindowHandle();
                g_mCurrentContextMap.Add(thread, hPreviousContext);
            }
            // create new window data:
            WindowHandle newWindow = new WindowHandle();
            //if (newWindow == null)
            //    return null;

            //newWindow.m_pGLEWContext = null;
            newWindow.m_pWindow = null;
            newWindow.m_uiID = g_uiWindowCounter++;     // set ID and Increment Counter!
            newWindow.m_uiWidth = (uint)a_iWidth;
            newWindow.m_uiHeight = (uint)a_iHeight;

            // if compiling in debug ask for debug context:
            //#ifdef _DEBUG
            Glfw.WindowHint(WindowHints.GLFW_OPENGL_DEBUG_CONTEXT, 1);
            //#endif

            Console.WriteLine("Creating window called " + a_szTitle + " with ID " + newWindow.m_uiID);
            GLFWmonitorPtr a_pMonitor = new GLFWmonitorPtr();

            // Create Window:
            if (a_hShare != null) // Check that the Window Handle passed in is valid.
            {
                newWindow.m_pWindow = Glfw.CreateWindow(a_iWidth, a_iHeight, a_szTitle, a_pMonitor, a_hShare?.m_pWindow);  // Window handle is valid, Share its GL Context Data!
            }
            else
            {
                newWindow.m_pWindow = Glfw.CreateWindow(a_iWidth, a_iHeight, a_szTitle, a_pMonitor, IntPtr.Zero); // Window handle is invlad, do not share!
            }

            // Confirm window was created successfully:
            if (newWindow.m_pWindow.Handle.Handle == IntPtr.Zero)
            {
                Console.WriteLine("Error: Could not Create GLFW Window!\n");
                //delete newWindow;
                return newWindow;
            }

            // create GLEW Context:
            //newWindow.m_pGLEWContext = new GLContext(newWindow.m_pWindow);
            //if (newWindow.m_pGLEWContext == null)
            //{
            //    Console.WriteLine("Error: Could not create GLEW Context!\n");
            //    //delete newWindow;
            //    return newWindow;
            //}

            Glfw.MakeContextCurrent(newWindow.m_pWindow);   // Must be done before init of GLEW for this new windows Context!
            //MakeContextCurrent(newWindow);                  // and must be made current too :)

            // Init GLEW for this context:
            //GLenum err = Glew.Init();
            //if (err != GLEW_OK)
            //{
            //    // a problem occured when trying to init glew, report it:
            //    Console.WriteLine("GLEW Error occured, Description: %s\n", Glew.GetErrorString(err));
            //    Glfw.DestroyWindow(newWindow.m_pWindow);
            //    //delete newWindow;
            //    return newWindow;
            //}

            // setup callbacks:
            // setup callback for window size changes:
            Glfw.SetWindowSizeCallback(newWindow.m_pWindow, GLFWWindowSizeCallback);

            // setup openGL Error callback:
            //if (GLEW_ARB_debug_output) // test to make sure we can use the new callbacks, they wer added as an extgension in 4.1 and as a core feture in 4.3
            {
                //# ifdef _DEBUG
                GL.Enable(GLCapabilities.GL_DEBUG_OUTPUT_SYNCHRONOUS);                        // this allows us to set a break point in the callback function, no point to it if in release mode.
                                                                                              //#endif
                //GL.DebugMessageControl( ErrorSources.GL_DONT_CARE, ErrorType.GL_DONT_CARE, ErrorSeverity.GL_DONT_CARE, 0, null, true);        // tell openGl what errors we want (all).


                if (GLCallbackDelegate != null && GLCallbackDelegate.IsAllocated)
                    GLCallbackDelegate.Free();

                GLdebugDelegate = new GL.DebugMessageCallbackDelegate(GLErrorCallback);
                GLCallbackDelegate = GCHandle.Alloc(GLdebugDelegate);
                GL.DebugMessageCallback(GLdebugDelegate, IntPtr.Zero);                        // define the callback function.
            }

            // add new window to the map and increment handle counter:
            g_lWindows.Add(newWindow);
            
            // now restore previous context:
            MakeContextCurrent(hPreviousContext);

            return newWindow;
        }


        static void CalcFPS(WindowHandle a_hWindowHandle)
        {
            if (m_mFPSData.ContainsKey(a_hWindowHandle.m_uiID))
            {
                FPSData data = m_mFPSData[a_hWindowHandle.m_uiID];
                data.m_fFrameCount++;
                data.m_fPreviousRunTime = data.m_fCurrnetRunTime;
                data.m_fCurrnetRunTime = (float)Glfw.GetTime();
                data.m_fTimeElapsed += data.m_fCurrnetRunTime - data.m_fPreviousRunTime;
                if (data.m_fTimeElapsed >= data.m_fTimeBetweenChecks)
                {
                    data.m_fFPS = data.m_fFrameCount / data.m_fTimeElapsed;
                    data.m_fTimeElapsed = 0.0f;
                    data.m_fFrameCount = 0;
                    Console.WriteLine("Thread id: " + Thread.CurrentThread.ManagedThreadId + "  Window: " + a_hWindowHandle.m_uiID + " FPS = " + (int)data.m_fFPS);
                }
            }
        }


        static bool ShouldClose()
        {
            foreach (WindowHandle window in g_lWindows)
            {
                if (Glfw.WindowShouldClose(window.m_pWindow))
                {
                    return true;
                }
            }

            return false;
        }


        static Quad CreateQuad()
        {
            Quad geom = new Quad();

            geom.m_Verticies[0].m_v4Position = new Vector4(-2, 0, -2, 1);
            geom.m_Verticies[0].m_v2UV = new Vector2(0, 0);
            geom.m_Verticies[0].m_v4Colour = new Vector4(0, 1, 0, 1);
            geom.m_Verticies[1].m_v4Position = new Vector4(2, 0, -2, 1);
            geom.m_Verticies[1].m_v2UV = new Vector2(1, 0);
            geom.m_Verticies[1].m_v4Colour = new Vector4(1, 0, 0, 1);
            geom.m_Verticies[2].m_v4Position = new Vector4(2, 0, 2, 1);
            geom.m_Verticies[2].m_v2UV = new Vector2(1, 1);
            geom.m_Verticies[2].m_v4Colour = new Vector4(0, 1, 0, 1);
            geom.m_Verticies[3].m_v4Position = new Vector4(-2, 0, 2, 1);
            geom.m_Verticies[3].m_v2UV = new Vector2(0, 1);
            geom.m_Verticies[3].m_v4Colour = new Vector4(0, 0, 1, 1);

            geom.m_uiIndicies[0] = 3;
            geom.m_uiIndicies[1] = 1;
            geom.m_uiIndicies[2] = 0;
            geom.m_uiIndicies[3] = 3;
            geom.m_uiIndicies[4] = 2;
            geom.m_uiIndicies[5] = 1;

            Console.WriteLine("Created quad on thread ID: " + Thread.CurrentThread.ManagedThreadId);

            return geom;
        }


        static void GLFWErrorCallback(GlfwError a_iError, string a_szDiscription)
        {
            Console.WriteLine("GLFW Error occured, Error ID: " + a_iError + ", Description: " + a_szDiscription);
        }


        static void GLErrorCallback(ErrorSources  source , ErrorType type, uint id, ErrorSeverity severity, int length, IntPtr message, IntPtr userParam)
        {
            Console.WriteLine("---------------------opengl-callback-start------------");
            Console.WriteLine("Message: " + PrairieGL.Utils.MarshalHelper.PtrToStringUTF8(message));
            Console.WriteLine("Type: ");
            switch (type)
            {
                case ErrorType.GL_DEBUG_TYPE_ERROR:
                    Console.WriteLine("ERROR");
                    break;
                case ErrorType.GL_DEBUG_TYPE_DEPRECATED_BEHAVIOR:
                    Console.WriteLine("DEPRECATED_BEHAVIOR");
                    break;
                case ErrorType.GL_DEBUG_TYPE_UNDEFINED_BEHAVIOR:
                    Console.WriteLine("UNDEFINED_BEHAVIOR");
                    break;
                case ErrorType.GL_DEBUG_TYPE_PORTABILITY:
                    Console.WriteLine("PORTABILITY");
                    break;
                case ErrorType.GL_DEBUG_TYPE_PERFORMANCE:
                    Console.WriteLine("PERFORMANCE");
                    break;
                case ErrorType.GL_DEBUG_TYPE_OTHER:
                    Console.WriteLine("OTHER");
                    break;
            }

            Console.WriteLine("ID: " + id + ", Severity: ");
            switch (severity)
            {
                case ErrorSeverity.GL_DEBUG_SEVERITY_LOW:
                    Console.WriteLine("LOW");
                    break;
                case ErrorSeverity.GL_DEBUG_SEVERITY_MEDIUM:
                    Console.WriteLine("MEDIUM");
                    break;
                case ErrorSeverity.GL_DEBUG_SEVERITY_HIGH:
                    Console.WriteLine("HIGH");
                    break;
            }

            Console.WriteLine("---------------------opengl-callback-end--------------");
        }


        static void GLFWWindowSizeCallback(GLFWwindowPtr a_pWindow, int a_iWidth, int a_iHeight)
        {
            // find the window data corrosponding to a_pWindow;
            WindowHandle window = default(WindowHandle);
            foreach (WindowHandle itr in g_lWindows)
            {
                if (itr.m_pWindow.Handle.Handle == a_pWindow.Handle)
                {
                    window = itr;
                    window.m_uiWidth = (uint)a_iWidth;
                    window.m_uiHeight = (uint)a_iHeight;
                    window.m_m4Projection = Matrix4x4.CreatePerspective(45.0f, (float)(a_iWidth) / (float)(a_iHeight), 0.1f, 1000.0f);
                }
            }

            int thread = Thread.CurrentThread.ManagedThreadId;
            WindowHandle previousContext = g_mCurrentContextMap[thread];
            MakeContextCurrent(window);
            GL.Viewport(0, 0, a_iWidth, a_iHeight);
            MakeContextCurrent(previousContext);
        }
    }
}