using PrairieGL;
using PrairieGL.Glfw;
using PrairieGL.OpenGL;
using System.Numerics;
using System.Runtime.InteropServices;

namespace TestPrairieGL.OpenGLTutorials
{
    internal class Tutorial14
    {
        const string PassthroughVertexShader = @"#version 330 core

// Input vertex data, different for all executions of this shader.
layout(location = 0) in vec3 vertexPosition_modelspace;

// Output data ; will be interpolated for each fragment.
out vec2 UV;

void main(){
	gl_Position =  vec4(vertexPosition_modelspace,1);
	UV = (vertexPosition_modelspace.xy+vec2(1,1))/2.0;
}";
        const string StandardShadingRTTFragmentShader = @"#version 330 core

// Interpolated values from the vertex shaders
in vec2 UV;
in vec3 Position_worldspace;
in vec3 Normal_cameraspace;
in vec3 EyeDirection_cameraspace;
in vec3 LightDirection_cameraspace;

// Ouput data
layout(location = 0) out vec3 color;

// Values that stay constant for the whole mesh.
uniform sampler2D myTextureSampler;
uniform mat4 MV;
uniform vec3 LightPosition_worldspace;

void main(){

	// Light emission properties
	// You probably want to put them as uniforms
	vec3 LightColor = vec3(1,1,1);
	float LightPower = 50.0f;
	
	// Material properties
	vec3 MaterialDiffuseColor = texture( myTextureSampler, UV ).rgb;
	vec3 MaterialAmbientColor = vec3(0.1,0.1,0.1) * MaterialDiffuseColor;
	vec3 MaterialSpecularColor = vec3(0.3,0.3,0.3);

	// Distance to the light
	float distance = length( LightPosition_worldspace - Position_worldspace );

	// Normal of the computed fragment, in camera space
	vec3 n = normalize( Normal_cameraspace );
	// Direction of the light (from the fragment to the light)
	vec3 l = normalize( LightDirection_cameraspace );
	// Cosine of the angle between the normal and the light direction, 
	// clamped above 0
	//  - light is at the vertical of the triangle -> 1
	//  - light is perpendiular to the triangle -> 0
	//  - light is behind the triangle -> 0
	float cosTheta = clamp( dot( n,l ), 0,1 );
	
	// Eye vector (towards the camera)
	vec3 E = normalize(EyeDirection_cameraspace);
	// Direction in which the triangle reflects the light
	vec3 R = reflect(-l,n);
	// Cosine of the angle between the Eye vector and the Reflect vector,
	// clamped to 0
	//  - Looking into the reflection -> 1
	//  - Looking elsewhere -> < 1
	float cosAlpha = clamp( dot( E,R ), 0,1 );
	
	color = 
		// Ambient : simulates indirect lighting
		MaterialAmbientColor +
		// Diffuse : 'color' of the object
		MaterialDiffuseColor* LightColor * LightPower* cosTheta / (distance* distance) +
		// Specular : reflective highlight, like a mirror
		MaterialSpecularColor* LightColor * LightPower* pow(cosAlpha,5) / (distance* distance);

}";
        const string StandardShadingRTTVertexShader = @"#version 330 core

// Input vertex data, different for all executions of this shader.
layout(location = 0) in vec3 vertexPosition_modelspace;
layout(location = 1) in vec2 vertexUV;
layout(location = 2) in vec3 vertexNormal_modelspace;

// Output data ; will be interpolated for each fragment.
out vec2 UV;
out vec3 Position_worldspace;
out vec3 Normal_cameraspace;
out vec3 EyeDirection_cameraspace;
out vec3 LightDirection_cameraspace;

// Values that stay constant for the whole mesh.
uniform mat4 MVP;
uniform mat4 V;
uniform mat4 M;
uniform vec3 LightPosition_worldspace;

void main(){

	// Output position of the vertex, in clip space : MVP * position
	gl_Position =  MVP * vec4(vertexPosition_modelspace,1);
	
	// Position of the vertex, in worldspace : M * position
	Position_worldspace = (M * vec4(vertexPosition_modelspace,1)).xyz;
	
	// Vector that goes from the vertex to the camera, in camera space.
	// In camera space, the camera is at the origin (0,0,0).
	EyeDirection_cameraspace = vec3(0,0,0) - ( V * M * vec4(vertexPosition_modelspace,1)).xyz;

	// Vector that goes from the vertex to the light, in camera space
	vec3 LightPosition_cameraspace = ( V * vec4(LightPosition_worldspace,1)).xyz;
	LightDirection_cameraspace = LightPosition_cameraspace + EyeDirection_cameraspace;
	
	// Normal of the the vertex, in camera space
	Normal_cameraspace = ( V * M * vec4(vertexNormal_modelspace,0)).xyz; // Only correct if ModelMatrix does not scale the model ! Use its inverse transpose if not.
	
	// UV of the vertex. No special space for this one.
	UV = vertexUV;
}";
        const string WobblyTextureFragmentShader = @"#version 330 core

in vec2 UV;

out vec3 color;

uniform sampler2D renderedTexture;
uniform float time;

void main(){
	color = texture( renderedTexture, UV + 0.005*vec2( sin(time+1024.0*UV.x),cos(time+768.0*UV.y)) ).xyz ;
}";

        static GLFWwindow window;


        public static int main()
        {
            // Initialise GLFW
            if (Glfw.Init() == 0)
            {
                Console.WriteLine("Failed to initialize GLFW\n");
                
                return -1;
            }

            Glfw.WindowHint( WindowHints.GLFW_SAMPLES, 4);
            Glfw.WindowHint( WindowHints.GLFW_CONTEXT_VERSION_MAJOR, 3);
            Glfw.WindowHint( WindowHints.GLFW_CONTEXT_VERSION_MINOR, 3);
            Glfw.WindowHint( WindowHints.GLFW_OPENGL_FORWARD_COMPAT, 1); // To make MacOS happy; should not be needed
            Glfw.WindowHint( WindowHints.GLFW_OPENGL_PROFILE, Glfw.GLFW_OPENGL_CORE_PROFILE);
            Glfw.WindowHint(WindowHints.GLFW_MAXIMIZED, 1);

            // Open a window and create its OpenGL context
            window = Glfw.CreateWindow(1024, 768, "Tutorial 14 - Render To Texture", IntPtr.Zero, IntPtr.Zero);
            if (window == null)
            {
                Console.WriteLine("Failed to open GLFW window. If you have an Intel GPU, they are not 3.3 compatible. Try the 2.1 version of the tutorials.\n");
                
                Glfw.Terminate();
                return -1;
            }
            Glfw.MakeContextCurrent(window);

            // We would expect width and height to be 1024 and 768
            int windowWidth = 1024;
            int windowHeight = 768;
            // But on MacOS X with a retina screen it'll be 1024*2 and 768*2, so we get the actual framebuffer size:
            Glfw.GetFramebufferSize(window, out windowWidth, out windowHeight);

            int windowWidthSz = 1024;
            int windowHeightSz = 768;
            Glfw.GetWindowSize(window, out windowWidthSz, out windowHeightSz);
            

            //// Initialize GLEW
            //glewExperimental = true; // Needed for core profile
            //if (glewInit() != GLEW_OK)
            //{
            //    Console.WriteLine("Failed to initialize GLEW\n");

            //    Glfw.Terminate();
            //    return -1;
            //}

            // Ensure we can capture the escape key being pressed below
            Glfw.SetInputMode(window, GlfwInputModes.GLFW_STICKY_KEYS, 1);
            // Hide the mouse and enable unlimited mouvement
            Glfw.SetInputMode(window, GlfwCursorModes.GLFW_CURSOR_DISABLED);

            // Set the mouse at the center of the screen
            Glfw.PollEvents();
            Glfw.SetCursorPos(window, 1024 / 2, 768 / 2);


            GL.Enable(GLCapabilities.GL_DEBUG_OUTPUT);
            GL.DebugMessageCallbackDelegate debugDelegate = new GL.DebugMessageCallbackDelegate(Tutorial12.DebugOutputCallback);

            GCHandle gch = GCHandle.Alloc(debugDelegate);//GCHandle callBackHandle = GCHandle.Alloc(callback, GCHandleType.Pinned);

            GL.DebugMessageCallback(debugDelegate, IntPtr.Zero);


            // Dark blue background
            GL.ClearColor(0.0f, 0.0f, 0.4f, 0.0f);

            // Enable depth test
            GL.Enable( GLCapabilities.GL_DEPTH_TEST);
            // Accept fragment if it closer to the camera than the former one
            //GL.DepthFunc( GLComparisonFunctions.GL_LESS);

            // Cull triangles which normal is not towards the camera
            GL.Enable( GLCapabilities.GL_CULL_FACE);

            uint VertexArrayID = GL.GenVertexArray();
            GL.BindVertexArray(VertexArrayID);

            // Create and compile our GLSL program from the shaders
            Shader programID = Shader.LoadShader(StandardShadingRTTVertexShader, StandardShadingRTTFragmentShader, false);

            // Get a handle for our "MVP" uniform
            int MatrixID = GL.GetUniformLocation(programID.GLHandle, "MVP");
            int ViewMatrixID = GL.GetUniformLocation(programID.GLHandle, "V");
            int ModelMatrixID = GL.GetUniformLocation(programID.GLHandle, "M");

            // Load the texture
            Texture texture = new Texture("OpenGLTutorials\\uvtemplate.DDS");

            // Get a handle for our "myTextureSampler" uniform
            int TextureID = GL.GetUniformLocation(programID.GLHandle, "myTextureSampler");

            // Read our .obj file
            List<Vector3> vertices;
            List<Vector2> uvs;
            List<Vector3> normals;
            bool res = OBJ.loadOBJ("OpenGLTutorials\\suzanne.obj", out vertices, out uvs, out normals);

            List < ushort> indices;
            List<Vector3> indexed_vertices;
            List<Vector2> indexed_uvs;
            List<Vector3> indexed_normals;
            VBOIndexer.indexVBO(vertices, uvs, normals, out indices, out indexed_vertices, out indexed_uvs, out indexed_normals);

            // Load it into a VBO

            uint vertexbuffer = GL.GenBuffer();
            GL.BindBuffer( BufferTargets.GL_ARRAY_BUFFER, vertexbuffer);
            GL.BufferData( BufferTargets.GL_ARRAY_BUFFER, indexed_vertices.ToArray(),  BufferUsages.GL_STATIC_DRAW);

            uint uvbuffer = GL.GenBuffer();
            GL.BindBuffer( BufferTargets.GL_ARRAY_BUFFER, uvbuffer);
            GL.BufferData( BufferTargets.GL_ARRAY_BUFFER, indexed_uvs.ToArray(),  BufferUsages.GL_STATIC_DRAW);

            uint normalbuffer = GL.GenBuffer();
            GL.BindBuffer( BufferTargets.GL_ARRAY_BUFFER, normalbuffer);
            GL.BufferData( BufferTargets.GL_ARRAY_BUFFER, indexed_normals.ToArray(),  BufferUsages.GL_STATIC_DRAW);

            // Generate a buffer for the indices as well
            uint elementbuffer = GL.GenBuffer();
            GL.BindBuffer( BufferTargets.GL_ELEMENT_ARRAY_BUFFER, elementbuffer);
            GL.BufferData( BufferTargets.GL_ELEMENT_ARRAY_BUFFER, indices.ToArray(),  BufferUsages.GL_STATIC_DRAW);

            // Get a handle for our "LightPosition" uniform
            GL.UseProgram(programID.GLHandle);
            int LightID = GL.GetUniformLocation(programID.GLHandle, "LightPosition_worldspace");


            // ---------------------------------------------
            // Render to Texture - specific code begins here
            // ---------------------------------------------

            // The framebuffer, which regroups 0, 1, or more textures, and 0 or 1 depth buffer.
            uint FramebufferName = GL.GenFramebuffer();
            GL.BindFramebuffer( FrameBufferTargets.GL_FRAMEBUFFER, FramebufferName);

            // The texture we're going to render to
            uint renderedTexture = GL.GenTexture();

            // "Bind" the newly created texture : all future texture functions will modify this texture
            GL.BindTexture( TextureTargets.GL_TEXTURE_2D, renderedTexture);

            // Give an empty image to OpenGL ( the last "0" means "empty" )
            GL.TexImage2D( TextureTargets.GL_TEXTURE_2D, 0,  ImagePixelFormats.GL_RGB, windowWidth, windowHeight, 0,  ImagePixelFormats.GL_RGB, ImagePixelDataTypes. GL_UNSIGNED_BYTE, (byte[])null);

            // Poor filtering
            GL.TexParameteri( TextureTargets.GL_TEXTURE_2D,  TextureParameters.GL_TEXTURE_MAG_FILTER, (int)TextureParameterValues.GL_NEAREST);
            GL.TexParameteri( TextureTargets.GL_TEXTURE_2D,  TextureParameters.GL_TEXTURE_MIN_FILTER, (int)TextureParameterValues.GL_NEAREST);
            GL.TexParameteri( TextureTargets.GL_TEXTURE_2D,  TextureParameters.GL_TEXTURE_WRAP_S, (int)TextureParameterValues.GL_CLAMP_TO_EDGE);
            GL.TexParameteri( TextureTargets.GL_TEXTURE_2D,  TextureParameters.GL_TEXTURE_WRAP_T, (int)TextureParameterValues.GL_CLAMP_TO_EDGE);

            // The depth buffer
            uint depthrenderbuffer = GL.GenRenderbuffer();
            GL.BindRenderbuffer( RenderBufferTargets.GL_RENDERBUFFER, depthrenderbuffer);
            GL.RenderbufferStorage( RenderBufferTargets.GL_RENDERBUFFER,  ImagePixelFormats.GL_DEPTH_COMPONENT, windowWidth, windowHeight);
            GL.FramebufferRenderbuffer(FrameBufferTargets.GL_FRAMEBUFFER, RenderBufferAttachments.GL_DEPTH_ATTACHMENT, RenderBufferTargets.GL_RENDERBUFFER, depthrenderbuffer);

            //// Alternative : Depth texture. Slower, but you can sample it later in your shader
            //int depthTexture;
            //glGenTextures(1, &depthTexture);
            //glBindTexture(GL_TEXTURE_2D, depthTexture);
            //glTexImage2D(GL_TEXTURE_2D, 0,GL_DEPTH_COMPONENT24, 1024, 768, 0,GL_DEPTH_COMPONENT, GL_FLOAT, 0);
            //glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_NEAREST);
            //glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_NEAREST); 
            //glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_CLAMP_TO_EDGE);
            //glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_CLAMP_TO_EDGE);

            // Set "renderedTexture" as our colour attachement #0
            GL.FramebufferTexture(FrameBufferTargets.GL_FRAMEBUFFER, RenderBufferAttachments.GL_COLOR_ATTACHMENT0, renderedTexture, 0);

            //// Depth texture alternative : 
            //glFramebufferTexture(GL_FRAMEBUFFER, GL_DEPTH_ATTACHMENT, depthTexture, 0);


            // Set the list of draw buffers.
            RenderBufferAttachments[] DrawBuffers = new RenderBufferAttachments[] { RenderBufferAttachments.GL_COLOR_ATTACHMENT0 };
            GL.DrawBuffers(1, DrawBuffers); // "1" is the size of DrawBuffers

            FrameBufferStatuses result = GL.CheckFramebufferStatus(FrameBufferTargets.GL_FRAMEBUFFER);
            // Always check that our framebuffer is ok
            //if (result != FrameBufferStatuses.GL_FRAMEBUFFER_COMPLETE)
            //    return 0;


            // The fullscreen quad's FBO
            float[] g_quad_vertex_buffer_data = {
        -1.0f, -1.0f, 0.0f,
         1.0f, -1.0f, 0.0f,
        -1.0f,  1.0f, 0.0f,
        -1.0f,  1.0f, 0.0f,
         1.0f, -1.0f, 0.0f,
         1.0f,  1.0f, 0.0f,
    };

            uint quad_vertexbuffer = GL.GenBuffer();
            GL.BindBuffer( BufferTargets.GL_ARRAY_BUFFER, quad_vertexbuffer);
            GL.BufferData( BufferTargets.GL_ARRAY_BUFFER, g_quad_vertex_buffer_data,  BufferUsages.GL_STATIC_DRAW);

            // Create and compile our GLSL program from the shaders
            Shader quad_programID = Shader.LoadShader(PassthroughVertexShader, WobblyTextureFragmentShader, false);
            int texID = GL.GetUniformLocation(quad_programID.GLHandle, "renderedTexture");
            int timeID = GL.GetUniformLocation(quad_programID.GLHandle, "time");


            do
            {
                // Render to our framebuffer
                GL.BindFramebuffer( FrameBufferTargets.GL_FRAMEBUFFER, FramebufferName);
                GL.Viewport(0, 0, windowWidth, windowHeight); // Render on the whole framebuffer, complete from the lower left corner to the upper right

                // Clear the screen
                GL.Clear( GLColourMasks.GL_COLOR_BUFFER_BIT |  GLColourMasks.GL_DEPTH_BUFFER_BIT);

                // Use our shader
                GL.UseProgram(programID.GLHandle);

                // Compute the MVP matrix from keyboard and mouse input
                Controls.computeMatricesFromInputs(window);
                Matrix4x4 ProjectionMatrix = Controls.getProjectionMatrix();
                Matrix4x4 ViewMatrix = Controls.getViewMatrix();
                Matrix4x4 ModelMatrix = Matrix4x4.Identity;
                Matrix4x4 MVP = ModelMatrix * ViewMatrix * ProjectionMatrix ;

                // Send our transformation to the currently bound shader, 
                // in the "MVP" uniform
                GL.UniformMatrix4fv(MatrixID, 1, false, MVP);
                GL.UniformMatrix4fv(ModelMatrixID, 1, false, ModelMatrix);
                GL.UniformMatrix4fv(ViewMatrixID, 1, false, ViewMatrix);

                Vector3 lightPos = new Vector3(4, 4, 4);
                GL.Uniform3f(LightID, lightPos.X, lightPos.Y, lightPos.Z);

                // Bind our texture in Texture Unit 0
                GL.ActiveTexture( TextureUnits.GL_TEXTURE0);
                GL.BindTexture( TextureTargets.GL_TEXTURE_2D, texture.ID);
                // Set our "myTextureSampler" sampler to use Texture Unit 0
                GL.Uniform1i(TextureID, 0);

                // 1rst attribute buffer : vertices
                GL.EnableVertexAttribArray(0);
                GL.BindBuffer( BufferTargets.GL_ARRAY_BUFFER, vertexbuffer);
                GL.VertexAttribPointer(
                    0,                  // attribute
                    3,                  // size
                     GLDataTypes.GL_FLOAT,           // type
                    false,           // normalized?
                    0,                  // stride
                    0            // array buffer offset
                );

                // 2nd attribute buffer : UVs
                GL.EnableVertexAttribArray(1);
                GL.BindBuffer( BufferTargets.GL_ARRAY_BUFFER, uvbuffer);
                GL.VertexAttribPointer(
                    1,                                // attribute
                    2,                                // size
                    GLDataTypes. GL_FLOAT,                         // type
                    false,                         // normalized?
                    0,                                // stride
                    0                          // array buffer offset
                );

                // 3rd attribute buffer : normals
                GL.EnableVertexAttribArray(2);
                GL.BindBuffer( BufferTargets.GL_ARRAY_BUFFER, normalbuffer);
                GL.VertexAttribPointer(
                    2,                                // attribute
                    3,                                // size
                     GLDataTypes.GL_FLOAT,                         // type
                    false,                         // normalized?
                    0,                                // stride
                    0                          // array buffer offset
                );

                // Index buffer
                GL.BindBuffer( BufferTargets.GL_ELEMENT_ARRAY_BUFFER, elementbuffer);

                // Draw the triangles !
                GL.DrawElements(
                     RenderModes.GL_TRIANGLES,      // mode
                    indices.Count,    // count
                    DrawIndexTypes. GL_UNSIGNED_SHORT // type
                               // element array buffer offset
                );

                GL.DisableVertexAttribArray(0);
                GL.DisableVertexAttribArray(1);
                GL.DisableVertexAttribArray(2);



                // Render to the screen
                GL.BindFramebuffer( FrameBufferTargets.GL_FRAMEBUFFER, 0);
                // Render on the whole framebuffer, complete from the lower left corner to the upper right
                GL.Viewport(0, 0, windowWidth, windowHeight);

                // Clear the screen
                GL.Clear( GLColourMasks.GL_COLOR_BUFFER_BIT |  GLColourMasks.GL_DEPTH_BUFFER_BIT);

                // Use our shader
                GL.UseProgram(quad_programID.GLHandle);

                // Bind our texture in Texture Unit 0
                GL.ActiveTexture( TextureUnits.GL_TEXTURE0);
                GL.BindTexture( TextureTargets.GL_TEXTURE_2D, renderedTexture);
                // Set our "renderedTexture" sampler to use Texture Unit 0
                GL.Uniform1i(texID, 0);

                GL.Uniform1f(timeID, (float)(Glfw.GetTime() * 10.0f));

                // 1rst attribute buffer : vertices
                GL.EnableVertexAttribArray(0);
                GL.BindBuffer( BufferTargets.GL_ARRAY_BUFFER, quad_vertexbuffer);
                GL.VertexAttribPointer(
                    0,                  // attribute 0. No particular reason for 0, but must match the layout in the shader.
                    3,                  // size
                     GLDataTypes.GL_FLOAT,           // type
                    false,           // normalized?
                    0,                  // stride
                    0            // array buffer offset
                );

                // Draw the triangles !
                GL.DrawArrays( RenderModes.GL_TRIANGLES, 0, 6); // 2*3 indices starting at 0 -> 2 triangles

                GL.DisableVertexAttribArray(0);


                // Swap buffers
                Glfw.SwapBuffers(window);
                Glfw.PollEvents();

            } // Check if the ESC key was pressed or the window was closed
            while (!Glfw.GetKey(window,  KeyboardKeys.GLFW_KEY_ESCAPE) &&
                   !Glfw.WindowShouldClose(window) );

            // Cleanup VBO and shader
            GL.DeleteBuffer(vertexbuffer);
            GL.DeleteBuffer(uvbuffer);
            GL.DeleteBuffer(normalbuffer);
            GL.DeleteBuffer(elementbuffer);
            GL.DeleteProgram(programID.GLHandle);
            GL.DeleteTexture(texture.ID);

            GL.DeleteFramebuffer(FramebufferName);
            GL.DeleteTexture(renderedTexture);
            GL.DeleteRenderbuffer(depthrenderbuffer);
            GL.DeleteBuffer(quad_vertexbuffer);
            GL.DeleteVertexArray(VertexArrayID);


            // Close OpenGL window and terminate GLFW
            Glfw.Terminate();

            return 0;
        }

    }
}
