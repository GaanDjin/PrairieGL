using PrairieGL;
using PrairieGL.Glfw;
using PrairieGL.OpenGL;
using System.Numerics;
using System.Runtime.InteropServices;

namespace TestPrairieGL.OpenGLTutorials
{
    internal class Tutorial12
	{
		const string StandardShadingFragmentShader = @"#version 330 core

// Interpolated values from the vertex shaders
in vec2 UV;
in vec3 Position_worldspace;
in vec3 Normal_cameraspace;
in vec3 EyeDirection_cameraspace;
in vec3 LightDirection_cameraspace;

// Ouput data
out vec3 color;

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
	//  - light is perpendicular to the triangle -> 0
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

		const string StandardShadingVertexShader = @"#version 330 core

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
	vec3 vertexPosition_cameraspace = ( V * M * vec4(vertexPosition_modelspace,1)).xyz;
	EyeDirection_cameraspace = vec3(0,0,0) - vertexPosition_cameraspace;

	// Vector that goes from the vertex to the light, in camera space. M is ommited because it's identity.
	vec3 LightPosition_cameraspace = ( V * vec4(LightPosition_worldspace,1)).xyz;
	LightDirection_cameraspace = LightPosition_cameraspace + EyeDirection_cameraspace;
	
	// Normal of the the vertex, in camera space
	Normal_cameraspace = ( V * M * vec4(vertexNormal_modelspace,0)).xyz; // Only correct if ModelMatrix does not scale the model ! Use its inverse transpose if not.
	
	// UV of the vertex. No special space for this one.
	UV = vertexUV;
}";

		public const string TextVertexShaderFragmentShader = @"#version 330 core

// Interpolated values from the vertex shaders
in vec2 UV;

// Ouput data
out vec4 color;

// Values that stay constant for the whole mesh.
uniform sampler2D myTextureSampler;

void main(){

	color = texture( myTextureSampler, UV );
	
	
}";

		public const string TextVertexShaderVertexShader = @"#version 330 core

// Input vertex data, different for all executions of this shader.
layout(location = 0) in vec2 vertexPosition_screenspace;
layout(location = 1) in vec2 vertexUV;

// Output data ; will be interpolated for each fragment.
out vec2 UV;

void main(){

	// Output position of the vertex, in clip space
	// map [0..800][0..600] to [-1..1][-1..1]
	vec2 vertexPosition_homoneneousspace = vertexPosition_screenspace - vec2(400,300); // [0..800][0..600] -> [-400..400][-300..300]
	vertexPosition_homoneneousspace /= vec2(400,300);
	gl_Position =  vec4(vertexPosition_homoneneousspace,0,1);
	
	// UV of the vertex. No special space for this one.
	UV = vertexUV;
}";

		static GLFWwindow window;

		static Texture2D texture2d;


		// The ARB_debug_output extension, which is used in this tutorial as an example,
		// can call a function of ours with error messages.
		// This function must have this precise prototype ( parameters and return value )
		// See http://www.opengl.org/registry/specs/ARB/debug_output.txt , "New Types" : 
		//	The callback function that applications can define, and
		//	is accepted by DebugMessageCallbackARB, is defined as:
		//	
		//	    typedef void (APIENTRY *DEBUGPROCARB)(enum source,
		//	                                          enum type,
		//	                                          uint id,
		//	                                          enum severity,
		//	                                          sizei length,
		//	                                          const char* message,
		//	                                          void* userParam);
		public static void DebugOutputCallback(ErrorSources source, ErrorType type, uint id, ErrorSeverity severity, int length, IntPtr message, IntPtr userParam)
		{

			Console.WriteLine("OpenGL Debug Output message : ");

			if (source == ErrorSources.GL_DEBUG_SOURCE_API) Console.WriteLine("Source : API; ");
			else if (source == ErrorSources.GL_DEBUG_SOURCE_WINDOW_SYSTEM) Console.WriteLine("Source : WINDOW_SYSTEM; ");
			else if (source == ErrorSources.GL_DEBUG_SOURCE_SHADER_COMPILER) Console.WriteLine("Source : SHADER_COMPILER; ");
			else if (source == ErrorSources.GL_DEBUG_SOURCE_THIRD_PARTY) Console.WriteLine("Source : THIRD_PARTY; ");
			else if (source == ErrorSources.GL_DEBUG_SOURCE_APPLICATION) Console.WriteLine("Source : APPLICATION; ");
			else if (source == ErrorSources.GL_DEBUG_SOURCE_OTHER) Console.WriteLine("Source : OTHER; ");
			else Console.WriteLine("Source : Unknown; 0x" + source.ToString("X"));

			if (type == ErrorType.GL_DEBUG_TYPE_ERROR) Console.WriteLine("Type : ERROR; ");
			else if (type == ErrorType.GL_DEBUG_TYPE_DEPRECATED_BEHAVIOR) Console.WriteLine("Type : DEPRECATED_BEHAVIOR; ");
			else if (type == ErrorType.GL_DEBUG_TYPE_UNDEFINED_BEHAVIOR) Console.WriteLine("Type : UNDEFINED_BEHAVIOR; ");
			else if (type == ErrorType.GL_DEBUG_TYPE_PORTABILITY) Console.WriteLine("Type : PORTABILITY; ");
			else if (type == ErrorType.GL_DEBUG_TYPE_PERFORMANCE) Console.WriteLine("Type : PERFORMANCE; ");
			else if (type == ErrorType.GL_DEBUG_TYPE_OTHER) Console.WriteLine("Type : OTHER; ");
			else Console.WriteLine("Type : Unknown; 0x" + type.ToString("X"));

			if (severity == ErrorSeverity.GL_DEBUG_SEVERITY_HIGH) Console.WriteLine("Severity : HIGH; ");
			else if (severity == ErrorSeverity.GL_DEBUG_SEVERITY_MEDIUM) Console.WriteLine("Severity : MEDIUM; ");
			else if (severity == ErrorSeverity.GL_DEBUG_SEVERITY_LOW) Console.WriteLine("Severity : LOW; ");
			else if (severity == ErrorSeverity.GL_DEBUG_SEVERITY_NOTIFICATION) Console.WriteLine("Severity : Info; ");
			else
                Console.WriteLine("Severity : Unknown; 0x" + severity.ToString("X"));

			// You can set a breakpoint here ! Your debugger will stop the program,
			// and the callstack will immediately show you the offending call.
			Console.WriteLine("Message : " + PrairieGL.Utils.MarshalHelper.PtrToStringUTF8(message));

			Console.WriteLine("\nAt Stack: " + Environment.StackTrace);
			Console.WriteLine("\n");
		}

	public static int main()
		{
			// Initialise GLFW
			if (Glfw.Init() == 0)
			{
				Console.WriteLine("Failed to initialize GLFW\n");
				return -1;
			}

			//PrairieGL.NvApi.NvAPI.SetupNVidiaProfile();

			Glfw.WindowHint(WindowHints.GLFW_SAMPLES, 4);
			Glfw.WindowHint(WindowHints.GLFW_CONTEXT_VERSION_MAJOR, 4);
			Glfw.WindowHint(WindowHints.GLFW_CONTEXT_VERSION_MINOR, 3);
			Glfw.WindowHint(WindowHints.GLFW_OPENGL_FORWARD_COMPAT, 1); // To make MacOS happy; should not be needed
			Glfw.WindowHint(WindowHints.GLFW_OPENGL_PROFILE, Glfw.GLFW_OPENGL_CORE_PROFILE);

			// Open a window and create its OpenGL context
			window = Glfw.CreateWindow(1024, 768, "Tutorial 12 - Errors & Extensions", IntPtr.Zero, IntPtr.Zero);
			if (window == null)
			{
				Console.WriteLine("Failed to open GLFW window. If you have an Intel GPU, they are not 3.3 compatible. Try the 2.1 version of the tutorials.\n");
				Glfw.Terminate();
				return -1;
			}
			Glfw.MakeContextCurrent(window);

			// Initialize GLEW
			//glewExperimental = true; // Needed for core profile
			//if (glewInit() != GLEW_OK)
			//{
			//	fprintf(stderr, "Failed to initialize GLEW\n");
			//	getchar();
			//	glfwTerminate();
			//	return -1;
			//}

			GL.Enable(GLCapabilities.GL_DEPTH_TEST);
			GL.Enable(GLCapabilities.GL_DEBUG_OUTPUT);

			// Example 1 :
			if (GL.HasExtension("AMD_seamless_cubemap_per_texture"))
			{
				Console.WriteLine("The GL_AMD_seamless_cubemap_per_texture is present, (but we're not goint to use it)\n");
				// Now it's legal to call glTexParameterf with the TEXTURE_CUBE_MAP_SEAMLESS_ARB parameter
				// You HAVE to test this, because obviously, this code would fail on non-AMD hardware.
			}

            GL.DebugMessageCallbackDelegate debugDelegate = new GL.DebugMessageCallbackDelegate(DebugOutputCallback);

            GCHandle gch = GCHandle.Alloc(debugDelegate);//GCHandle callBackHandle = GCHandle.Alloc(callback, GCHandleType.Pinned);

            GL.DebugMessageCallback(debugDelegate, IntPtr.Zero);


            // Example 2 :
            //if (GL.HasExtension("GL_ARB_debug_output"))
            //{
            //	Console.WriteLine("The OpenGL implementation provides debug output. Let's use it !\n");

            //	err = GL.GetError();
            //	err = GL.GetError(); //Clear error.

            //	//GCHandle gch = GCHandle.Alloc(callback_delegate); 
            //	GL.DebugMessageCallbackARB(debugDelegate, IntPtr.Zero);

            //	err = GL.GetError();

            //	GL.Enable(GLCapabilities.GL_DEBUG_OUTPUT_SYNCHRONOUS_ARB);

            //	err = GL.GetError();
            //}
            //else
            //{
            //	Console.WriteLine("ARB_debug_output unavailable. You have to use glGetError() and/or gDebugger to catch mistakes.\n");
            //}


            // Ensure we can capture the escape key being pressed below
            Glfw.SetInputMode(window, GlfwInputModes.GLFW_STICKY_KEYS, 1);
			// Hide the mouse and enable unlimited mouvement
			Glfw.SetInputMode(window, GlfwCursorModes.GLFW_CURSOR_DISABLED);

			// Set the mouse at the center of the screen
			Glfw.PollEvents();
			Glfw.SetCursorPos(window, 1024 / 2, 768 / 2);

			GL.GetOpenGLInfo();

			List<string> enabledExtensions = GL.ListExtensions();

			Console.WriteLine(enabledExtensions.Count + " OpenGL Extensions: ");
			foreach (string extension in enabledExtensions)
			{
				Console.Write(extension + ", ");
			}
			Console.Write("\n");


			// Dark blue background
			GL.ClearColor(0.0f, 0.0f, 0.4f, 0.0f);

			// Enable depth test
			GL.Enable((GLCapabilities)(-1) /*GLCapabilities.GL_DEPTH_TEST*/);

			List<ErrorLog> errs = GL.GetDebugMessages();

			// Accept fragment if it closer to the camera than the former one
			GL.DepthFunc(GLComparisonFunctions.GL_LESS);

			// Cull triangles which normal is not towards the camera
			GL.Enable(GLCapabilities.GL_CULL_FACE);

			uint VertexArrayID = GL.GenVertexArray();
			GL.BindVertexArray(VertexArrayID);

			// Create and compile our GLSL program from the shaders
			Shader programID = Shader.LoadShader(StandardShadingVertexShader, StandardShadingFragmentShader, false);

			// Get a handle for our "MVP" uniform
			int MatrixID = GL.GetUniformLocation(programID.GLHandle, "MVP");
			int ViewMatrixID = GL.GetUniformLocation(programID.GLHandle, "V");
			int ModelMatrixID = GL.GetUniformLocation(programID.GLHandle, "M");

            // Load the texture
            Texture texture = new Texture("OpenGLTutorials\\uvmap.DDS");

			// Get a handle for our "myTextureSampler" uniform
			int TextureID = GL.GetUniformLocation(programID.GLHandle, "myTextureSampler");

			// Read our .obj file
			List<Vector3> vertices;
			List<Vector2> uvs;
			List<Vector3> normals;
			bool res = OBJ.loadOBJ("OpenGLTutorials\\suzanne.obj", out vertices, out uvs, out normals);

			List<ushort> indices;
			List<Vector3> indexed_vertices;
			List<Vector2> indexed_uvs;
			List<Vector3> indexed_normals;
			VBOIndexer.indexVBO(vertices, uvs, normals, out indices, out indexed_vertices, out indexed_uvs, out indexed_normals);

			// Load it into a VBO

			uint vertexbuffer = GL.GenBuffer();
			GL.BindBuffer(BufferTargets.GL_ARRAY_BUFFER, vertexbuffer);
			GL.BufferData(BufferTargets.GL_ARRAY_BUFFER, indexed_vertices.ToArray(), BufferUsages.GL_STATIC_DRAW);

			uint uvbuffer = GL.GenBuffer();
			GL.BindBuffer(BufferTargets.GL_ARRAY_BUFFER, uvbuffer);
			GL.BufferData(BufferTargets.GL_ARRAY_BUFFER, indexed_uvs.ToArray(), BufferUsages.GL_STATIC_DRAW);

			uint normalbuffer = GL.GenBuffer();
			GL.BindBuffer(BufferTargets.GL_ARRAY_BUFFER, normalbuffer);
			GL.BufferData(BufferTargets.GL_ARRAY_BUFFER, indexed_normals.ToArray(), BufferUsages.GL_STATIC_DRAW);

			// Generate a buffer for the indices as well
			uint elementbuffer = GL.GenBuffer();
			GL.BindBuffer(BufferTargets.GL_ELEMENT_ARRAY_BUFFER, elementbuffer);
			GL.BufferData(BufferTargets.GL_ELEMENT_ARRAY_BUFFER, indices.ToArray(), BufferUsages.GL_STATIC_DRAW);

			// Get a handle for our "LightPosition" uniform
			GL.UseProgram(programID.GLHandle);
			int LightID = GL.GetUniformLocation(programID.GLHandle, "LightPosition_worldspace");

			// Initialize our little text library with the Holstein font
			texture2d = new Texture2D();
			texture2d.initText2D("OpenGLTutorials\\Holstein.DDS");

			// For speed computation
			double lastTime = Glfw.GetTime();
			int nbFrames = 0;

			do
			{

				// Measure speed
				double currentTime = Glfw.GetTime();
				nbFrames++;
				if (currentTime - lastTime >= 1.0)
				{ // If last prinf() was more than 1sec ago
				  // printf and reset
					Console.WriteLine((1000.0 / (double)nbFrames) + " ms/frame");
					nbFrames = 0;
					lastTime += 1.0;
				}

				// Clear the screen
				GL.Clear(GLColourMasks.GL_COLOR_BUFFER_BIT | GLColourMasks.GL_DEPTH_BUFFER_BIT);

				// Use our shader
				GL.UseProgram(programID.GLHandle);

				// Compute the MVP matrix from keyboard and mouse input
				Controls.computeMatricesFromInputs(window);
				Matrix4x4 ProjectionMatrix = Controls.getProjectionMatrix();
				Matrix4x4 ViewMatrix = Controls.getViewMatrix();
				Matrix4x4 ModelMatrix = Matrix4x4.Identity;
				Matrix4x4 MVP = ModelMatrix * ViewMatrix * ProjectionMatrix;

				// Send our transformation to the currently bound shader, 
				// in the "MVP" uniform
				GL.UniformMatrix4fv(MatrixID, 1, false, MVP);
				GL.UniformMatrix4fv(ModelMatrixID, 1, false, ModelMatrix);
				GL.UniformMatrix4fv(ViewMatrixID, 1, false, ViewMatrix);

				Vector3 lightPos = new Vector3(4, 4, 4);
				GL.Uniform3f(LightID, lightPos.X, lightPos.Y, lightPos.Z);

				// Bind our texture in Texture Unit 0
				GL.ActiveTexture(TextureUnits.GL_TEXTURE0);
				GL.BindTexture(TextureTargets.GL_TEXTURE_2D, texture.ID);
				// Set our "myTextureSampler" sampler to use Texture Unit 0
				GL.Uniform1i(TextureID, 0);

				// 1rst attribute buffer : vertices
				GL.EnableVertexAttribArray(0);
				GL.BindBuffer(BufferTargets.GL_ARRAY_BUFFER, vertexbuffer);
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
				GL.BindBuffer(BufferTargets.GL_ARRAY_BUFFER, uvbuffer);
				GL.VertexAttribPointer(
					1,                                // attribute
					2,                                // size
					 GLDataTypes.GL_FLOAT,                         // type
					false,                         // normalized?
					0,                                // stride
					0                          // array buffer offset
				);

				// 3rd attribute buffer : normals
				GL.EnableVertexAttribArray(2);
				GL.BindBuffer(BufferTargets.GL_ARRAY_BUFFER, normalbuffer);
				GL.VertexAttribPointer(
					2,                                // attribute
					3,                                // size
					 GLDataTypes.GL_FLOAT,                         // type
					false,                         // normalized?
					0,                                // stride
					0                          // array buffer offset
				);

				// Index buffer
				GL.BindBuffer(BufferTargets.GL_ELEMENT_ARRAY_BUFFER, elementbuffer);

				// Draw the triangles !
				GL.DrawElements(
					 RenderModes.GL_TRIANGLES,      // mode
					indices.Count,    // count
					 DrawIndexTypes.GL_UNSIGNED_SHORT // type
													  // element array buffer offset
				);

				GL.DisableVertexAttribArray(0);
				GL.DisableVertexAttribArray(1);
				GL.DisableVertexAttribArray(2);

				string text = Glfw.GetTime().ToString("###0.00") + " sec";
				texture2d.printText2D(text, 10, 500, 60);

				// Swap buffers
				Glfw.SwapBuffers(window);
				Glfw.PollEvents();

			} // Check if the ESC key was pressed or the window was closed
			while (!Glfw.GetKey(window, KeyboardKeys.GLFW_KEY_ESCAPE) &&
				   !Glfw.WindowShouldClose(window));

			// Cleanup VBO, shader and texture
			GL.DeleteBuffer(vertexbuffer);
			GL.DeleteBuffer(uvbuffer);
			GL.DeleteBuffer(normalbuffer);
			GL.DeleteBuffer(elementbuffer);
			GL.DeleteProgram(programID.GLHandle);
			GL.DeleteTexture(texture.ID);
			GL.DeleteVertexArray(VertexArrayID);

			// Delete the text's VBO, the shader and the texture
			texture2d.cleanupText2D();

			// Close OpenGL window and terminate GLFW
			Glfw.Terminate();

			return 0;
		}
	}
}
