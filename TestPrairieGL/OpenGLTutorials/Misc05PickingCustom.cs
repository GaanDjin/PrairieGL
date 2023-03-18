using PrairieGL;
using PrairieGL.Glfw;
using PrairieGL.OpenGL;
using System.Numerics;

namespace TestPrairieGL.OpenGLTutorials
{
	/// <summary>
	/// Well it kinda works.... I think the matrix and quats math is not the same as openGL and a bit messed
	/// </summary>
	internal class Misc05PickingCustom
	{
		const string PickingFragmentShader = @"#version 330 core

// Ouput data
out vec4 color;

// Values that stay constant for the whole mesh.
uniform vec4 PickingColor;

void main(){
	
	color = PickingColor;

}";
		const string PickingVertexShader = @"#version 330 core

// Input vertex data, different for all executions of this shader.
layout(location = 0) in vec3 vertexPosition_modelspace;

// Values that stay constant for the whole mesh.
uniform mat4 MVP;

void main(){

	// Output position of the vertex, in clip space : MVP * position
	gl_Position =  MVP * vec4(vertexPosition_modelspace,1);
	
}";

		static GLFWwindow window;

		static void ScreenPosToWorldRay(
			int mouseX, int mouseY,             // Mouse position, in pixels, from bottom-left corner of the window
			int screenWidth, int screenHeight,  // Window size, in pixels
			Matrix4x4 ViewMatrix,               // Camera position and orientation
			Matrix4x4 ProjectionMatrix,         // Camera parameters (ratio, field of view, near and far planes)
			out Vector3 out_origin,              // Ouput : Origin of the ray. /!\ Starts at the near plane, so if you want the ray to start at the camera's position instead, ignore this.
			out Vector3 out_direction            // Ouput : Direction, in world space, of the ray that goes "through" the mouse.
)
		{

			// The ray Start and End positions, in Normalized Device Coordinates (Have you read Tutorial 4 ?)
			Vector4 lRayStart_NDC = new Vector4(
				((float)mouseX / (float)screenWidth - 0.5f) * 2.0f, // [0,1024] -> [-1,1]
		((float)mouseY / (float)screenHeight - 0.5f) * 2.0f, // [0, 768] -> [-1,1]
		-1.0f, // The near plane maps to Z=-1 in Normalized Device Coordinates
		1.0f
			);
			Vector4 lRayEnd_NDC = new Vector4(
				((float)mouseX / (float)screenWidth - 0.5f) * 2.0f,
		((float)mouseY / (float)screenHeight - 0.5f) * 2.0f,
		0.0f,
		1.0f
			);


			// The Projection matrix goes from Camera Space to NDC.
			// So inverse(ProjectionMatrix) goes from NDC to Camera Space.
			Matrix4x4 InverseProjectionMatrix;

			Matrix4x4.Invert(ProjectionMatrix, out InverseProjectionMatrix);

			// The View Matrix goes from World Space to Camera Space.
			// So inverse(ViewMatrix) goes from Camera Space to World Space.
			Matrix4x4 InverseViewMatrix;
			Matrix4x4.Invert(ViewMatrix, out InverseViewMatrix);

			

			Vector4 lRayStart_camera = ApplyMatrix(InverseProjectionMatrix , lRayStart_NDC); lRayStart_camera /= lRayStart_camera.W;
			Vector4 lRayStart_world = ApplyMatrix(InverseViewMatrix , lRayStart_camera); lRayStart_world /= lRayStart_world.W;
			Vector4 lRayEnd_camera = ApplyMatrix(InverseProjectionMatrix , lRayEnd_NDC); lRayEnd_camera /= lRayEnd_camera.W;
			Vector4 lRayEnd_world = ApplyMatrix(InverseViewMatrix , lRayEnd_camera); lRayEnd_world /= lRayEnd_world.W;


			// Faster way (just one inverse)
			//Matrix4x4 M = glm::inverse(ProjectionMatrix * ViewMatrix);
			//Vector4 lRayStart_world = M * lRayStart_NDC; lRayStart_world/=lRayStart_world.w;
			//Vector4 lRayEnd_world   = M * lRayEnd_NDC  ; lRayEnd_world  /=lRayEnd_world.w;


			Vector3 lRayDir_world = (new Vector3(lRayEnd_world.X, lRayEnd_world.Y, lRayEnd_world.Z) - new Vector3(lRayStart_world.X, lRayStart_world.Y, lRayStart_world.Z));
			lRayDir_world = Vector3.Normalize(lRayDir_world);


			out_origin = new Vector3(lRayStart_world.X, lRayStart_world.Y, lRayStart_world.Z);
			out_direction = Vector3.Normalize(lRayDir_world);
		}

		public static Vector4 ApplyMatrix(Matrix4x4 matrix, Vector4 self)
		{
			return new Vector4(
				matrix.M11 * self.X + matrix.M12 * self.Y + matrix.M13 * self.Z + matrix.M14 * self.W,
				matrix.M21 * self.X + matrix.M22 * self.Y + matrix.M23 * self.Z + matrix.M24 * self.W,
				matrix.M31 * self.X + matrix.M32 * self.Y + matrix.M33 * self.Z + matrix.M34 * self.W,
				matrix.M41 * self.X + matrix.M42 * self.Y + matrix.M43 * self.Z + matrix.M44 * self.W
			);
		}

		static bool TestRayOBBIntersection(
			Vector3 ray_origin,        // Ray origin, in world space
			Vector3 ray_direction,     // Ray direction (NOT target position!), in world space. Must be normalize()'d.
			Vector3 aabb_min,          // Minimum X,Y,Z coords of the mesh when not transformed at all.
			Vector3 aabb_max,          // Maximum X,Y,Z coords. Often aabb_min*-1 if your mesh is centered, but it's not always the case.
			Matrix4x4 ModelMatrix,       // Transformation applied to the mesh (which will thus be also applied to its bounding box)
			out float intersection_distance // Output : distance between ray_origin and the intersection with the OBB
)
		{
			intersection_distance = 0;

			// Intersection method from Real-Time Rendering and Essential Mathematics for Games

			float tMin = 0.0f;
			float tMax = 100000.0f;

			Vector3 OBBposition_worldspace = new Vector3(ModelMatrix.M41, ModelMatrix.M42, ModelMatrix.M43);

			Vector3 delta = OBBposition_worldspace - ray_origin;

			// Test intersection with the 2 planes perpendicular to the OBB's X axis
			{
				Vector3 xaxis = new Vector3(ModelMatrix.M11, ModelMatrix.M12, ModelMatrix.M13);
				float e = Vector3.Dot(xaxis, delta);
				float f = Vector3.Dot(ray_direction, xaxis);

				if (MathF.Abs(f) > 0.001f)
				{ // Standard case

					float t1 = (e + aabb_min.X) / f; // Intersection with the "left" plane
					float t2 = (e + aabb_max.X) / f; // Intersection with the "right" plane
													 // t1 and t2 now contain distances betwen ray origin and ray-plane intersections

					// We want t1 to represent the nearest intersection, 
					// so if it's not the case, invert t1 and t2
					if (t1 > t2)
					{
						float w = t1; t1 = t2; t2 = w; // swap t1 and t2
					}

					// tMax is the nearest "far" intersection (amongst the X,Y and Z planes pairs)
					if (t2 < tMax)
						tMax = t2;
					// tMin is the farthest "near" intersection (amongst the X,Y and Z planes pairs)
					if (t1 > tMin)
						tMin = t1;

					// And here's the trick :
					// If "far" is closer than "near", then there is NO intersection.
					// See the images in the tutorials for the visual explanation.
					if (tMax < tMin)
						return false;

				}
				else
				{ // Rare case : the ray is almost parallel to the planes, so they don't have any "intersection"
					if (-e + aabb_min.X > 0.0f || -e + aabb_max.X < 0.0f)
						return false;
				}
			}


			// Test intersection with the 2 planes perpendicular to the OBB's Y axis
			// Exactly the same thing than above.
			{
				Vector3 yaxis = new Vector3(ModelMatrix.M11, ModelMatrix.M12, ModelMatrix.M13);
				float e = Vector3.Dot(yaxis, delta);
				float f = Vector3.Dot(ray_direction, yaxis);

				if (MathF.Abs(f) > 0.001f)
				{

					float t1 = (e + aabb_min.Y) / f;
					float t2 = (e + aabb_max.Y) / f;

					if (t1 > t2) { float w = t1; t1 = t2; t2 = w; }

					if (t2 < tMax)
						tMax = t2;
					if (t1 > tMin)
						tMin = t1;
					if (tMin > tMax)
						return false;

				}
				else
				{
					if (-e + aabb_min.Y > 0.0f || -e + aabb_max.Y < 0.0f)
						return false;
				}
			}


			// Test intersection with the 2 planes perpendicular to the OBB's Z axis
			// Exactly the same thing than above.
			{
				Vector3 zaxis = new Vector3(ModelMatrix.M31, ModelMatrix.M32, ModelMatrix.M33);
				float e = Vector3.Dot(zaxis, delta);
				float f = Vector3.Dot(ray_direction, zaxis);

				if (MathF.Abs(f) > 0.001f)
				{

					float t1 = (e + aabb_min.Z) / f;
					float t2 = (e + aabb_max.Z) / f;

					if (t1 > t2) { float w = t1; t1 = t2; t2 = w; }

					if (t2 < tMax)
						tMax = t2;
					if (t1 > tMin)
						tMin = t1;
					if (tMin > tMax)
						return false;

				}
				else
				{
					if (-e + aabb_min.Z > 0.0f || -e + aabb_max.Z < 0.0f)
						return false;
				}
			}

			intersection_distance = tMin;
			return true;

		}

		public static int main()
		{
			// Initialise GLFW
			if (Glfw.Init() == 0)
			{
				Console.WriteLine("Failed to initialize GLFW\n");

				return -1;
			}


			Glfw.WindowHint(WindowHints.GLFW_SAMPLES, 4);
			Glfw.WindowHint(WindowHints.GLFW_CONTEXT_VERSION_MAJOR, 3);
			Glfw.WindowHint(WindowHints.GLFW_CONTEXT_VERSION_MINOR, 3);
			Glfw.WindowHint(WindowHints.GLFW_OPENGL_FORWARD_COMPAT, 1); // To make MacOS happy; should not be needed
			Glfw.WindowHint(WindowHints.GLFW_OPENGL_PROFILE, Glfw.GLFW_OPENGL_CORE_PROFILE);
			//Glfw.WindowHint(WindowHints.GLFW_MAXIMIZED, 1);

			// Open a window and create its OpenGL context
			window = Glfw.CreateWindow(1024, 768, "Misc 05 - version with custom Ray-OBB code", IntPtr.Zero, IntPtr.Zero);
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
			//	Glfw.Terminate();
			//	return -1;
			//}

			//// Initialize the GUI
			//TwInit(TW_OPENGL_CORE, null);
			//TwWindowSize(1024, 768);
			//TwBar* GUI = TwNewBar("Picking");
			//TwSetParam(GUI, null, "refresh", TW_PARAM_CSTRING, 1, "0.1");
			//std::string message;
			//TwAddVarRW(GUI, "Last picked object", TW_TYPE_STDSTRING, &message, null);

			// Ensure we can capture the escape key being pressed below
			Glfw.SetInputMode(window, GlfwInputModes.GLFW_STICKY_KEYS, 1);
			Glfw.SetCursorPos(window, 1024 / 2, 768 / 2);

			// Dark blue background
			GL.ClearColor(0.0f, 0.0f, 0.4f, 0.0f);

			// Enable depth test
			GL.Enable(GLCapabilities.GL_DEPTH_TEST);
			// Accept fragment if it closer to the camera than the former one
			GL.DepthFunc(GLComparisonFunctions.GL_LESS);

			// Cull triangles which normal is not towards the camera
			GL.Enable(GLCapabilities.GL_CULL_FACE);

			uint VertexArrayID = GL.GenVertexArray();
			GL.BindVertexArray(VertexArrayID);

			// Create and compile our GLSL program from the shaders
			Shader programID = Shader.LoadShader(Tutorial08.StandardShadingVertexShader, Tutorial08.StandardShadingFragmentShader, false);


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
			List<Vector3> indexed_vertices = new List<Vector3>();
			List<Vector2> indexed_uvs = new List<Vector2>();
			List<Vector3> indexed_normals = new List<Vector3>();
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



			// Generate positions & rotations for 100 monkeys
			Vector3[] positions = new Vector3[100];
			Quaternion[] orientations = new Quaternion[100];
			for (int i = 0; i < positions.Length; i++)
			{
				//positions[i] = new Vector3(0, 0, 0);
				orientations[i] = Quaternion.Identity;
                positions[i] = new Vector3(Random.Shared.Next() % 20 - 10, Random.Shared.Next() % 20 - 10, Random.Shared.Next() % 20 - 10);
                //orientations[i] = new Quaternion(new Vector3(Random.Shared.Next() % 360, Random.Shared.Next() % 360, Random.Shared.Next() % 360), 1);
            }



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
					Console.WriteLine((1000.0 / (double)(nbFrames)) + " ms/frame\n");
					nbFrames = 0;
					lastTime += 5.0;
				}


				// Compute the MVP matrix from keyboard and mouse input
				Controls.computeMatricesFromInputs(window);
				Matrix4x4 ProjectionMatrix = Controls.getProjectionMatrix();
				Matrix4x4 ViewMatrix = Controls.getViewMatrix();



				// PICKING IS DONE HERE
				// (Instead of picking each frame if the mouse button is down, 
				// you should probably only check if the mouse button was just released)
				if (Glfw.GetMouseButton(window, MouseButtons.GLFW_MOUSE_BUTTON_LEFT))
				{

					Vector3 ray_origin;
					Vector3 ray_direction;
					ScreenPosToWorldRay(
						1024 / 2, 768 / 2,
						1024, 768,
						ViewMatrix,
						ProjectionMatrix,
						out ray_origin,
						out ray_direction
					);

					//ray_direction = ray_direction*20.0f;

					//message = "background";

					// Test each each Oriented Bounding Box (OBB).
					// A physics engine can be much smarter than this, 
					// because it already has some spatial partitionning structure, 
					// like Binary Space Partitionning Tree (BSP-Tree),
					// Bounding Volume Hierarchy (BVH) or other.
					for (int i = 0; i < positions.Length; i++)
					{

						float intersection_distance; // Output of TestRayOBBIntersection()
						Vector3 aabb_min = new Vector3(-1.0f, -1.0f, -1.0f);
						Vector3 aabb_max = new Vector3(1.0f, 1.0f, 1.0f);

						// The ModelMatrix transforms :
						// - the mesh to its desired position and orientation
						// - but also the AABB (defined with aabb_min and aabb_max) into an OBB
						Matrix4x4 RotationMatrix = Matrix4x4.CreateFromQuaternion(orientations[i]);
						Matrix4x4 TranslationMatrix = Matrix4x4.CreateTranslation(positions[i]);
						Matrix4x4 ModelMatrix = TranslationMatrix * RotationMatrix;


						if (TestRayOBBIntersection(
							ray_origin,
							ray_direction,
							aabb_min,
							aabb_max,
							ModelMatrix,
							out intersection_distance)
						)
						{
							Console.WriteLine("mesh " + i + " Clicked");
							//std::ostringstream oss;
							//oss << "mesh " << i;
							//message = oss.str();
							break;
						}
					}


				}


				// Dark blue background
				GL.ClearColor(0.0f, 0.0f, 0.4f, 0.0f);
				// Re-clear the screen for real rendering
				GL.Clear(GLColourMasks.GL_COLOR_BUFFER_BIT | GLColourMasks.GL_DEPTH_BUFFER_BIT);


				// Use our shader
				GL.UseProgram(programID.GLHandle);

				GL.EnableVertexAttribArray(0);
				GL.EnableVertexAttribArray(1);
				GL.EnableVertexAttribArray(2);

				for (int i = 0; i < positions.Length; i++)
				{


					Matrix4x4 RotationMatrix = Matrix4x4.CreateFromQuaternion(orientations[i]);
					Matrix4x4 TranslationMatrix = Matrix4x4.CreateTranslation(positions[i]);
					Matrix4x4 ModelMatrix = TranslationMatrix * RotationMatrix;

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


				}

				GL.DisableVertexAttribArray(0);
				GL.DisableVertexAttribArray(1);
				GL.DisableVertexAttribArray(2);

				// Draw GUI
				//TwDraw();

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