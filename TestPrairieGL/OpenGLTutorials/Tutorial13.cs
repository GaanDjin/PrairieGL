using PrairieGL;
using PrairieGL.Glfw;
using PrairieGL.OpenGL;
using System.Numerics;
using System.Runtime.InteropServices;

namespace TestPrairieGL.OpenGLTutorials
{
    internal class Tutorial13
    {
        const string NormalMappingFragmentShader = @"#version 330 core

// Interpolated values from the vertex shaders
in vec2 UV;
in vec3 Position_worldspace;
in vec3 EyeDirection_cameraspace;
in vec3 LightDirection_cameraspace;

in vec3 LightDirection_tangentspace;
in vec3 EyeDirection_tangentspace;

// Ouput data
out vec3 color;

// Values that stay constant for the whole mesh.
uniform sampler2D DiffuseTextureSampler;
uniform sampler2D NormalTextureSampler;
uniform sampler2D SpecularTextureSampler;
uniform mat4 V;
uniform mat4 M;
uniform mat3 MV3x3;
uniform vec3 LightPosition_worldspace;

void main(){

	// Light emission properties
	// You probably want to put them as uniforms
	vec3 LightColor = vec3(1,1,1);
	float LightPower = 40.0;
	
	// Material properties
	vec3 MaterialDiffuseColor = texture( DiffuseTextureSampler, UV ).rgb;
	vec3 MaterialAmbientColor = vec3(0.1,0.1,0.1) * MaterialDiffuseColor;
	vec3 MaterialSpecularColor = texture( SpecularTextureSampler, UV ).rgb * 0.3;

	// Local normal, in tangent space. V tex coordinate is inverted because normal map is in TGA (not in DDS) for better quality
	vec3 TextureNormal_tangentspace = normalize(texture( NormalTextureSampler, vec2(UV.x,-UV.y) ).rgb*2.0 - 1.0);
	
	// Distance to the light
	float distance = length( LightPosition_worldspace - Position_worldspace );

	// Normal of the computed fragment, in camera space
	vec3 n = TextureNormal_tangentspace;
	// Direction of the light (from the fragment to the light)
	vec3 l = normalize(LightDirection_tangentspace);
	// Cosine of the angle between the normal and the light direction, 
	// clamped above 0
	//  - light is at the vertical of the triangle -> 1
	//  - light is perpendicular to the triangle -> 0
	//  - light is behind the triangle -> 0
	float cosTheta = clamp( dot( n,l ), 0,1 );

	// Eye vector (towards the camera)
	vec3 E = normalize(EyeDirection_tangentspace);
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

		const string NormalMappingVertexShader = @"#version 330 core

// Input vertex data, different for all executions of this shader.
layout(location = 0) in vec3 vertexPosition_modelspace;
layout(location = 1) in vec2 vertexUV;
layout(location = 2) in vec3 vertexNormal_modelspace;
layout(location = 3) in vec3 vertexTangent_modelspace;
layout(location = 4) in vec3 vertexBitangent_modelspace;

// Output data ; will be interpolated for each fragment.
out vec2 UV;
out vec3 Position_worldspace;
out vec3 EyeDirection_cameraspace;
out vec3 LightDirection_cameraspace;

out vec3 LightDirection_tangentspace;
out vec3 EyeDirection_tangentspace;

// Values that stay constant for the whole mesh.
uniform mat4 MVP;
uniform mat4 V;
uniform mat4 M;
uniform mat3 MV3x3;
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
	
	// UV of the vertex. No special space for this one.
	UV = vertexUV;
	
	// model to camera = ModelView
	vec3 vertexTangent_cameraspace = MV3x3 * vertexTangent_modelspace;
	vec3 vertexBitangent_cameraspace = MV3x3 * vertexBitangent_modelspace;
	vec3 vertexNormal_cameraspace = MV3x3 * vertexNormal_modelspace;
	
	mat3 TBN = transpose(mat3(
		vertexTangent_cameraspace,
		vertexBitangent_cameraspace,
		vertexNormal_cameraspace	
	)); // You can use dot products instead of building this matrix and transposing it. See References for details.

	LightDirection_tangentspace = TBN * LightDirection_cameraspace;
	EyeDirection_tangentspace =  TBN * EyeDirection_cameraspace;
	
	
}
";

		static GLFWwindow window;

		public static int main()
		{
			// Initialise GLFW
			if (Glfw.Init() == 0)
			{
				Console.WriteLine("Failed to initialize GLFW\n");
				
				return -1;
			}

			Glfw.WindowHint( WindowHints.GLFW_SAMPLES, 1);
			Glfw.WindowHint( WindowHints.GLFW_CONTEXT_VERSION_MAJOR, 3);
			Glfw.WindowHint( WindowHints.GLFW_CONTEXT_VERSION_MINOR, 3);
			Glfw.WindowHint( WindowHints.GLFW_OPENGL_FORWARD_COMPAT, 1); // To make MacOS happy; should not be needed
			Glfw.WindowHint( WindowHints.GLFW_OPENGL_PROFILE, Glfw.GLFW_OPENGL_CORE_PROFILE);
			//Glfw.WindowHint(GLFW_OPENGL_PROFILE, GLFW_OPENGL_COMPAT_PROFILE); // So that glBegin/glVertex/glEnd work

			// Open a window and create its OpenGL context
			window = Glfw.CreateWindow(1024, 768, "Tutorial 13 - Normal Mapping", IntPtr.Zero, IntPtr.Zero);
			if (window == null)
			{
				Console.WriteLine("Failed to open GLFW window. If you have an Intel GPU, they are not 3.3 compatible. Try the 2.1 version of the tutorials.\n");
				
				Glfw.Terminate();
				return -1;
			}
			Glfw.MakeContextCurrent(window);

			//// Initialize GLEW
			//glewExperimental = true; // Needed for core profile
			//if (glewInit() != GLEW_OK)
			//{
			//	Console.WriteLine("Failed to initialize GLEW\n");

			//	Glfw.Terminate();
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
			GL.Enable( GLCapabilities.GL_DEPTH_TEST);
			// Accept fragment if it closer to the camera than the former one
			GL.DepthFunc( GLComparisonFunctions.GL_LESS);

			// Cull triangles which normal is not towards the camera
			GL.Enable( GLCapabilities.GL_CULL_FACE);

			uint VertexArrayID = GL.GenVertexArray();
			GL.BindVertexArray(VertexArrayID);

			// Create and compile our GLSL program from the shaders
			Shader programID = Shader.LoadShader(NormalMappingVertexShader, NormalMappingFragmentShader, false);

			// Get a handle for our "MVP" uniform
			int MatrixID = GL.GetUniformLocation(programID.GLHandle, "MVP");
			int ViewMatrixID = GL.GetUniformLocation(programID.GLHandle, "V");
			int ModelMatrixID = GL.GetUniformLocation(programID.GLHandle, "M");
			int ModelView3x3MatrixID = GL.GetUniformLocation(programID.GLHandle, "MV3x3");

            // Load the texture
            Texture DiffuseTexture = new Texture("OpenGLTutorials\\diffuse.DDS");
            Texture NormalTexture = new Texture("OpenGLTutorials\\normal.bmp");
            Texture SpecularTexture = new Texture("OpenGLTutorials\\specular.DDS");

			// Get a handle for our "myTextureSampler" uniform
			int DiffuseTextureID = GL.GetUniformLocation(programID.GLHandle, "DiffuseTextureSampler");
			int NormalTextureID = GL.GetUniformLocation(programID.GLHandle, "NormalTextureSampler");
			int SpecularTextureID = GL.GetUniformLocation(programID.GLHandle, "SpecularTextureSampler");

			// Read our .obj file
			List<Vector3> vertices;
			List<Vector2> uvs;
			List<Vector3> normals;
			bool res = OBJ.loadOBJ("OpenGLTutorials\\cylinder.obj", out vertices, out uvs, out normals);

			List<Vector3> tangents = new List<Vector3>();
			List<Vector3> bitangents = new List<Vector3>();
			TangentSpace.computeTangentBasis(
				vertices, uvs, normals, // input
				tangents, bitangents    // output
			);

			List <ushort> indices = new List<ushort>();
			List<Vector3> indexed_vertices = new List<Vector3>();
			List<Vector2> indexed_uvs = new List<Vector2>();
			List<Vector3> indexed_normals = new List<Vector3>();
			List<Vector3> indexed_tangents = new List<Vector3>();
			List<Vector3> indexed_bitangents = new List<Vector3>();
			VBOIndexer.indexVBO_TBN(
				vertices, uvs, normals, tangents, bitangents,
				indices, indexed_vertices, indexed_uvs, indexed_normals, indexed_tangents, indexed_bitangents
			);

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

			uint tangentbuffer = GL.GenBuffer();
			GL.BindBuffer( BufferTargets.GL_ARRAY_BUFFER, tangentbuffer);
			GL.BufferData( BufferTargets.GL_ARRAY_BUFFER, indexed_tangents.ToArray(),  BufferUsages.GL_STATIC_DRAW);

			uint bitangentbuffer = GL.GenBuffer();
			GL.BindBuffer( BufferTargets.GL_ARRAY_BUFFER, bitangentbuffer);
			GL.BufferData( BufferTargets.GL_ARRAY_BUFFER, indexed_bitangents.ToArray(),  BufferUsages.GL_STATIC_DRAW);

			// Generate a buffer for the indices as well
			uint elementbuffer = GL.GenBuffer();
			GL.BindBuffer( BufferTargets.GL_ELEMENT_ARRAY_BUFFER, elementbuffer);
			GL.BufferData( BufferTargets.GL_ELEMENT_ARRAY_BUFFER, indices.ToArray(),  BufferUsages.GL_STATIC_DRAW);

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
					lastTime += 5.0;
				}

				// Clear the screen
				GL.Clear( GLColourMasks.GL_COLOR_BUFFER_BIT |  GLColourMasks.GL_DEPTH_BUFFER_BIT);

				// Use our shader
				GL.UseProgram(programID.GLHandle);

				// Compute the MVP matrix from keyboard and mouse input
				Controls.computeMatricesFromInputs(window);
				Matrix4x4 ProjectionMatrix = Controls.getProjectionMatrix();
				Matrix4x4 ViewMatrix = Controls.getViewMatrix();
				Matrix4x4 ModelMatrix = Matrix4x4.Identity;
				Matrix4x4 ModelViewMatrix = ViewMatrix * ModelMatrix;
				Matrix3x3 ModelView3x3Matrix = new Matrix3x3(ModelViewMatrix);
				Matrix4x4 MVP = ModelMatrix * ViewMatrix * ProjectionMatrix ;

				// Send our transformation to the currently bound shader, 
				// in the "MVP" uniform
				GL.UniformMatrix4fv(MatrixID, 1, false, MVP);
				GL.UniformMatrix4fv(ModelMatrixID, 1, false, ModelMatrix);
				GL.UniformMatrix4fv(ViewMatrixID, 1, false, ViewMatrix);
				GL.UniformMatrix4fv(ViewMatrixID, 1, false, ViewMatrix);
				GL.UniformMatrix3fv(ModelView3x3MatrixID, 1, false, ModelView3x3Matrix);


				Vector3 lightPos = new Vector3(0, 0, 4);
				GL.Uniform3f(LightID, lightPos.X, lightPos.Y, lightPos.Z);

				// Bind our diffuse texture in Texture Unit 0
				GL.ActiveTexture( TextureUnits.GL_TEXTURE0);
				GL.BindTexture( TextureTargets.GL_TEXTURE_2D, DiffuseTexture.ID);
				// Set our "DiffuseTextureSampler" sampler to use Texture Unit 0
				GL.Uniform1i(DiffuseTextureID, 0);

				// Bind our normal texture in Texture Unit 1
				GL.ActiveTexture( TextureUnits.GL_TEXTURE1);
				GL.BindTexture( TextureTargets.GL_TEXTURE_2D, NormalTexture.ID);
				// Set our "NormalTextureSampler" sampler to use Texture Unit 1
				GL.Uniform1i(NormalTextureID, 1);

				// Bind our specular texture in Texture Unit 2
				GL.ActiveTexture( TextureUnits.GL_TEXTURE2);
				GL.BindTexture( TextureTargets.GL_TEXTURE_2D, SpecularTexture.ID);
				// Set our "SpecularTextureSampler" sampler to use Texture Unit 2
				GL.Uniform1i(SpecularTextureID, 2);


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
					 GLDataTypes.GL_FLOAT,                         // type
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

				// 4th attribute buffer : tangents
				GL.EnableVertexAttribArray(3);
				GL.BindBuffer( BufferTargets.GL_ARRAY_BUFFER, tangentbuffer);
				GL.VertexAttribPointer(
					3,                                // attribute
					3,                                // size
					 GLDataTypes.GL_FLOAT,                         // type
					false,                         // normalized?
					0,                                // stride
					0                          // array buffer offset
				);

				// 5th attribute buffer : bitangents
				GL.EnableVertexAttribArray(4);
				GL.BindBuffer( BufferTargets.GL_ARRAY_BUFFER, bitangentbuffer);
				GL.VertexAttribPointer(
					4,                                // attribute
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
					 DrawIndexTypes.GL_UNSIGNED_SHORT // type
					           // element array buffer offset
				);

				GL.DisableVertexAttribArray(0);
				GL.DisableVertexAttribArray(1);
				GL.DisableVertexAttribArray(2);
				GL.DisableVertexAttribArray(3);
				GL.DisableVertexAttribArray(4);


				////////////////////////////////////////////////////////
				// DEBUG ONLY !!!
				// Don't use this in real code !!
				////////////////////////////////////////////////////////



				GL.MatrixMode( MatrixModes.GL_PROJECTION);
				GL.LoadMatrixf(ProjectionMatrix);
				GL.MatrixMode(MatrixModes.GL_MODELVIEW);
				Matrix4x4 MV = ViewMatrix * ModelMatrix;
				GL.LoadMatrixf(MV);


				GL.UseProgram(0);

				// normals
				GL.Color3f(0, 0, 1);
				GL.Begin( RenderModes.GL_LINES);
				for (int i = 0; i < indices.Count; i++)
				{
					Vector3 p = indexed_vertices[indices[i]];
					GL.Vertex3fv(new float[] { p.X });
					Vector3 o = Vector3.Normalize(indexed_normals[indices[i]]);
					p += o * 0.1f;
					GL.Vertex3fv(new float[] { p.X });
				}
				GL.End();
				// tangents
				GL.Color3f(1, 0, 0);
				GL.Begin( RenderModes.GL_LINES);
				for (int i = 0; i < indices.Count; i++)
				{
					Vector3 p = indexed_vertices[indices[i]];
					GL.Vertex3fv(new float[] { p.X });
					Vector3 o = Vector3.Normalize(indexed_tangents[indices[i]]);
					p += o * 0.1f;
					GL.Vertex3fv(new float[] { p.X });
				}
				GL.End();
				// bitangents
				GL.Color3f(0, 1, 0);
				GL.Begin( RenderModes.GL_LINES);
				for (int i = 0; i < indices.Count; i++)
				{
					Vector3 p = indexed_vertices[indices[i]];
					GL.Vertex3fv(new float[] { p.X });
					Vector3 o = Vector3.Normalize(indexed_bitangents[indices[i]]);
					p += o * 0.1f;
					GL.Vertex3fv(new float[] { p.X });
				}
				GL.End();
				// light pos
				GL.Color3f(1, 1, 1);
				GL.Begin( RenderModes.GL_LINES);
				GL.Vertex3fv(new float[] { lightPos.X });
				lightPos += new Vector3(1, 0, 0) * 0.1f;
				GL.Vertex3fv(new float[] { lightPos.X });
				lightPos -= new Vector3(1, 0, 0) * 0.1f;
				GL.Vertex3fv(new float[] { lightPos.X });
				lightPos += new Vector3(0, 1, 0) * 0.1f;
				GL.Vertex3fv(new float[] { lightPos.X });
				GL.End();

				// Swap buffers
				Glfw.SwapBuffers(window);
				Glfw.PollEvents();

			} // Check if the ESC key was pressed or the window was closed
			while (!Glfw.GetKey(window,  KeyboardKeys.GLFW_KEY_ESCAPE) &&
				   !Glfw.WindowShouldClose(window));

			// Cleanup VBO and shader
			GL.DeleteBuffer(vertexbuffer);
			GL.DeleteBuffer(uvbuffer);
			GL.DeleteBuffer(normalbuffer);
			GL.DeleteBuffer(tangentbuffer);
			GL.DeleteBuffer(bitangentbuffer);
			GL.DeleteBuffer(elementbuffer);
			GL.DeleteProgram(programID.GLHandle);
			GL.DeleteTexture(DiffuseTexture.ID);
			GL.DeleteTexture(NormalTexture.ID);
			GL.DeleteTexture(SpecularTexture.ID);
			GL.DeleteVertexArray(VertexArrayID);

			// Close OpenGL window and terminate GLFW
			Glfw.Terminate();

			return 0;
		}
	}
}
