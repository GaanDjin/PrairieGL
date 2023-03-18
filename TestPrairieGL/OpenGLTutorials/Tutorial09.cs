using PrairieGL;
using PrairieGL.Glfw;
using PrairieGL.OpenGL;
using System.Numerics;

namespace TestPrairieGL.OpenGLTutorials
{
	internal class Tutorial09
	{
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

		static GLFWwindow window;


		public static int main()
		{

			// Initialise GLFW
			if (Glfw.Init() == 0)
			{
				Console.WriteLine("Failed to initialize GLFW\n");

				return -1;
			}

			GLErrors err = GL.GetError();

			Glfw.WindowHint(WindowHints.GLFW_SAMPLES, 4);
			Glfw.WindowHint(WindowHints.GLFW_CONTEXT_VERSION_MAJOR, 3);
			Glfw.WindowHint(WindowHints.GLFW_CONTEXT_VERSION_MINOR, 3);
			Glfw.WindowHint(WindowHints.GLFW_OPENGL_FORWARD_COMPAT, 1); // To make MacOS happy; should not be needed
			Glfw.WindowHint(WindowHints.GLFW_OPENGL_PROFILE, 0x00032001);
			Glfw.WindowHint(WindowHints.GLFW_MAXIMIZED, 1);
			
			// Open a window and create its OpenGL context
			window = Glfw.CreateWindow(1024, 768, "Tutorial 09 - Rendering several models", IntPtr.Zero, IntPtr.Zero);
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
			//	Console.WriteLine("Failed to initialize GLEW\n");
			//	
			//	glfwTerminate();
			//	return -1;
			//}

			// Ensure we can capture the escape key being pressed below
			Glfw.SetInputMode(window, GlfwInputModes.GLFW_STICKY_KEYS, 1);
			// Hide the mouse and enable unlimited mouvement
			Glfw.SetInputMode(window, GlfwCursorModes.GLFW_CURSOR_DISABLED);

			// Set the mouse at the center of the screen
			Glfw.PollEvents();
			Glfw.SetCursorPos(window, 1024 / 2, 768 / 2);

			

			// Dark blue background
			GL.ClearColor(0.0f, 0.0f, 0.4f, 0.0f);

			// Enable depth test
			GL.Enable(GLCapabilities.GL_DEPTH_TEST);
			// Accept fragment if it closer to the camera than the former one
			GL.DepthFunc(GLComparisonFunctions.GL_LESS);
			err = GL.GetError(); //Depth Func Doesn't like GL_LESS

			// Cull triangles which normal is not towards the camera
			GL.Enable(GLCapabilities.GL_CULL_FACE);
			err = GL.GetError();
			err = GL.GetError();

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

			List<ushort> indices = new List<ushort>();
			List<Vector3> indexed_vertices;
			List<Vector2> indexed_uvs;
			List<Vector3> indexed_normals;
            VBOIndexer.indexVBO(vertices, uvs, normals, out indices, out indexed_vertices, out indexed_uvs, out indexed_normals);

            //for (ushort i = 0; i < vertices.Count; i++)
            //	indices.Add(i);

            //indexed_vertices = vertices;
            //indexed_uvs = uvs;
            //indexed_normals = normals;

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

			// For speed computation
			double lastTime = Glfw.GetTime();
			int nbFrames = 0;

			do
			{

				// Measure speed
				double currentTime = Glfw.GetTime();
				nbFrames++;
				if (currentTime - lastTime >= 5.0)
				{ // If last prinf() was more than 1sec ago
				  // printf and reset
					Console.WriteLine((1000.0 / (double)nbFrames) + " ms/frame");
					nbFrames = 0;
					lastTime += 1.0;
				}

				// Clear the screen
				GL.Clear(GLColourMasks.GL_COLOR_BUFFER_BIT | GLColourMasks.GL_DEPTH_BUFFER_BIT);


				// Compute the MVP matrix from keyboard and mouse input
				Controls.computeMatricesFromInputs(window);
				Matrix4x4 ProjectionMatrix = Controls.getProjectionMatrix();
				Matrix4x4 ViewMatrix = Controls.getViewMatrix();


				////// Start of the rendering of the first object //////

				// Use our shader
				GL.UseProgram(programID.GLHandle);

				Vector3 lightPos = new Vector3(4, 4, 4);
				GL.Uniform3f(LightID, lightPos.X, lightPos.Y, lightPos.Z);
				GL.UniformMatrix4fv(ViewMatrixID, 1, false, ViewMatrix); // This one doesn't change between objects, so this can be done once for all objects that use "programID"

				Matrix4x4 ModelMatrix1 = Matrix4x4.Identity;
				Matrix4x4 MVP1 = ModelMatrix1 * ViewMatrix * ProjectionMatrix;

				// Send our transformation to the currently bound shader, 
				// in the "MVP" uniform
				GL.UniformMatrix4fv(MatrixID, 1, false, MVP1);
				GL.UniformMatrix4fv(ModelMatrixID, 1, false, ModelMatrix1);


				// Bind our texture in Texture Unit 0
				GL.ActiveTexture(TextureUnits.GL_TEXTURE0);
				GL.BindTexture(TextureTargets.GL_TEXTURE_2D, texture.ID);
				// Set our "myTextureSampler" sampler to use Texture Unit 0
				GL.Uniform1i((int)TextureID, 0);

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
                     DrawIndexTypes.GL_UNSIGNED_SHORT   // type
                                                        // element array buffer offset
                );



				////// End of rendering of the first object //////
				////// Start of the rendering of the second object //////

				// In our very specific case, the 2 objects use the same shader.
				// So it's useless to re-bind the "programID" shader, since it's already the current one.
				//glUseProgram(programID);

				// Similarly : don't re-set the light position and camera matrix in programID,
				// it's still valid !
				// *** You would have to do it if you used another shader ! ***
				//glUniform3f(LightID, lightPos.x, lightPos.y, lightPos.z);
				//glUniformMatrix4fv(ViewMatrixID, 1, false, &ViewMatrix[0][0]); // This one doesn't change between objects, so this can be done once for all objects that use "programID"


				// Again : this is already done, but this only works because we use the same shader.
				//// Bind our texture in Texture Unit 0
				//glActiveTexture(GL_TEXTURE0);
				//glBindTexture(GL_TEXTURE_2D, Texture);
				//// Set our "myTextureSampler" sampler to use Texture Unit 0
				//glUniform1i(TextureID, 0);


				// BUT the Model matrix is different (and the MVP too)
				//Matrix4x4 ModelMatrix2 = Matrix4x4.Identity;
				Matrix4x4 ModelMatrix2 = Matrix4x4.CreateTranslation(new Vector3(2.0f, 0.0f, 0.0f));
				Matrix4x4 MVP2 = ModelMatrix2 * ViewMatrix * ProjectionMatrix;

				// Send our transformation to the currently bound shader, 
				// in the "MVP" uniform
				GL.UniformMatrix4fv(MatrixID, 1, false, MVP2);
				GL.UniformMatrix4fv(ModelMatrixID, 1, false, ModelMatrix2);


				// The rest is exactly the same as the first object

				// 1rst attribute buffer : vertices
				GL.EnableVertexAttribArray(0);
				GL.BindBuffer(BufferTargets.GL_ARRAY_BUFFER, vertexbuffer);
				GL.VertexAttribPointer(0, 3, GLDataTypes.GL_FLOAT, false, 0, 0);

				// 2nd attribute buffer : UVs
				GL.EnableVertexAttribArray(1);
				GL.BindBuffer(BufferTargets.GL_ARRAY_BUFFER, uvbuffer);
				GL.VertexAttribPointer(1, 2, GLDataTypes.GL_FLOAT, false, 0, 0);

				// 3rd attribute buffer : normals
				GL.EnableVertexAttribArray(2);
				GL.BindBuffer(BufferTargets.GL_ARRAY_BUFFER, normalbuffer);
				GL.VertexAttribPointer(2, 3, GLDataTypes.GL_FLOAT, false, 0, 0);

				// Index buffer
				GL.BindBuffer(BufferTargets.GL_ELEMENT_ARRAY_BUFFER, elementbuffer);

				// Draw the triangles !
				GL.DrawElements(RenderModes.GL_TRIANGLES, indices.Count, DrawIndexTypes.GL_UNSIGNED_SHORT);

				////// End of rendering of the second object //////




				GL.DisableVertexAttribArray(0);
				GL.DisableVertexAttribArray(1);
				GL.DisableVertexAttribArray(2);

				// Swap buffers
				Glfw.SwapBuffers(window);
				Glfw.PollEvents();

			} // Check if the ESC key was pressed or the window was closed
			while (!Glfw.GetKey(window, KeyboardKeys.GLFW_KEY_ESCAPE) &&
				   !Glfw.WindowShouldClose(window));

			// Cleanup VBO and shader
			GL.DeleteBuffer(vertexbuffer);
			GL.DeleteBuffer(uvbuffer);
			GL.DeleteBuffer(normalbuffer);
			GL.DeleteBuffer(elementbuffer);
			GL.DeleteProgram(programID.GLHandle);
			GL.DeleteTexture(texture.ID);
			GL.DeleteVertexArray(VertexArrayID);

			// Close OpenGL window and terminate GLFW
			Glfw.Terminate();

			return 0;
		}
	}
}
