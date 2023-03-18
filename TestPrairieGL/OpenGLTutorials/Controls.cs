using PrairieGL.Glfw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TestPrairieGL.OpenGLTutorials
{
    internal class Controls
	{
		static Matrix4x4 ViewMatrix;
		static Matrix4x4 ProjectionMatrix;

		public static Matrix4x4 getViewMatrix()
		{
			return ViewMatrix;
		}
		public static Matrix4x4 getProjectionMatrix()
		{
			return ProjectionMatrix;
		}

		public static Vector3 getCameraPosition()
		{
			return position;
		}

		// Initial position : on +Z
		static Vector3 position = new Vector3(0, 0, 5);
		// Initial horizontal angle : toward -Z
		static float horizontalAngle = 3.14f;
		// Initial vertical angle : none
		static float verticalAngle = 0.0f;
		// Initial Field of View
		static float initialFoV = 45.0f;

		static float speed = 3.0f; // 3 units / second
		static float mouseSpeed = 0.005f;

		static double lastTime;

		public static void computeMatricesFromInputs(GLFWwindow window)
		{

			// glfwGetTime is called only once, the first time this function is called
			if(lastTime == 0)
				lastTime = Glfw.GetTime();

			// Compute time difference between current and last frame
			double currentTime = Glfw.GetTime();
			float deltaTime = (float)(currentTime - lastTime);

			// Get mouse position
			double xpos, ypos;
			Glfw.GetCursorPos(window, out xpos, out ypos);

			// Reset mouse position for next frame
			Glfw.SetCursorPos(window, 1024 / 2, 768 / 2);

			// Compute new orientation
			horizontalAngle += mouseSpeed * (float)(1024 / 2 - xpos);
			verticalAngle += mouseSpeed * (float)(768 / 2 - ypos);

			// Direction : Spherical coordinates to Cartesian coordinates conversion
			Vector3 direction = new Vector3(
				MathF.Cos(verticalAngle)* MathF.Sin(horizontalAngle),
				MathF.Sin(verticalAngle),
				MathF.Cos(verticalAngle)* MathF.Cos(horizontalAngle)
		
			);

			// Right vector
			Vector3 right = new Vector3(
				MathF.Sin(horizontalAngle - 3.14f / 2.0f),
				0,
				MathF.Cos(horizontalAngle - 3.14f / 2.0f)
			);

			// Up vector
			Vector3 up = Vector3.Cross(right, direction);

			// Move forward
			if (Glfw.GetKey(window, KeyboardKeys.GLFW_KEY_W))
			{
				position += direction * deltaTime * speed;
			}
			// Move backward
			if (Glfw.GetKey(window, KeyboardKeys.GLFW_KEY_S))
			{
				position -= direction * deltaTime * speed;
			}
			// Strafe right
			if (Glfw.GetKey(window, KeyboardKeys.GLFW_KEY_D))
			{
				position += right * deltaTime * speed;
			}
			// Strafe left
			if (Glfw.GetKey(window,  KeyboardKeys.GLFW_KEY_A))
			{
				position -= right * deltaTime * speed;
			}
			// Strafe up
			if (Glfw.GetKey(window, KeyboardKeys.GLFW_KEY_LEFT_SHIFT))
			{
				position += up * deltaTime * speed;
			}
			//down
			if (Glfw.GetKey(window, KeyboardKeys.GLFW_KEY_LEFT_CONTROL))
			{
				position -= up * deltaTime * speed;
			}

			float FoV = initialFoV;// - 5 * glfwGetMouseWheel(); // Now GLFW 3 requires setting up a callback for this. It's a bit too complicated for this beginner's tutorial, so it's disabled instead.

			// Projection matrix : 45° Field of View, 4:3 ratio, display range : 0.1 unit <-> 100 units
			ProjectionMatrix = Matrix4x4.CreatePerspectiveFieldOfView((FoV) * MathF.PI * 2f / 360f, 4.0f / 3.0f, 0.1f, 100.0f);
			// Camera matrix
			ViewMatrix = Matrix4x4.CreateLookAt(
										position,           // Camera is here
										position + direction, // and looks here : at the same position, plus "direction"
										up                  // Head is up (set to 0,-1,0 to look upside-down)
								   );

			// For the next frame, the "last time" will be "now"
			lastTime = currentTime;
		}


		private static Matrix4x4 MakeLookAt(Vector3 eye, Vector3 center, Vector3 up)
		{
			Vector3 f = Vector3.Normalize(center - eye);
			Vector3 u = Vector3.Normalize(up);
			Vector3 s = Vector3.Normalize(Vector3.Cross(f, u));
			u = Vector3.Cross(s, f); // no norm needed because s,f both unit length and orthogonal

			Matrix4x4 m = Matrix4x4.Identity;
			m.M11 = s.X; m.M21 = s.Y; m.M31 = s.Z; m.M41 = -Vector3.Dot(s, eye); ;
			m.M12 = u.X; m.M22 = u.Y; m.M32 = u.Z; m.M42 = -Vector3.Dot(s, eye); ;
			m.M13 = -f.X; m.M23 = -f.Y; m.M33 = -f.Z; m.M43 = -Vector3.Dot(s, eye); ;
			m.M14 = 0.0f; m.M24 = 0.0f; m.M34 = 0.0f; m.M44 = 1.0f;
			return m;
		}
	}
}
