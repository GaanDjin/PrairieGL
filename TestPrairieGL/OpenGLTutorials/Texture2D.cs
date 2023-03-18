using PrairieGL;
using PrairieGL.OpenGL;
using System.Numerics;

namespace TestPrairieGL.OpenGLTutorials
{
	internal class Texture2D
	{
        Texture Text2DTextureID;
		uint Text2DVertexBufferID;
		uint Text2DUVBufferID;
		Shader Text2DShaderID;
		int Text2DUniformID;

		public void initText2D(string texturePath)
		{

			// Initialize texture
			Text2DTextureID = new Texture(texturePath);

			// Initialize VBO
			Text2DVertexBufferID = GL.GenBuffer();
			Text2DUVBufferID = GL.GenBuffer();

			// Initialize Shader
			Text2DShaderID = Shader.LoadShader(Tutorial11.TextVertexShaderVertexShader, Tutorial11.TextVertexShaderFragmentShader, false);

			// Initialize uniforms' IDs
			Text2DUniformID = GL.GetUniformLocation(Text2DShaderID.GLHandle, "myTextureSampler");

		}

		public void printText2D(string text, int x, int y, int size)
		{

			int length = text.Length;

			// Fill buffers
			List<Vector2> vertices = new List<Vector2>();
			List<Vector2> UVs = new List<Vector2>();
			for (int i = 0; i < length; i++)
			{

				Vector2 vertex_up_left = new Vector2(x + i * size, y + size);
				Vector2 vertex_up_right = new Vector2(x + i * size + size, y + size);
				Vector2 vertex_down_right = new Vector2(x + i * size + size, y);
				Vector2 vertex_down_left = new Vector2(x + i * size, y);

				vertices.Add(vertex_up_left);
				vertices.Add(vertex_down_left);
				vertices.Add(vertex_up_right);

				vertices.Add(vertex_down_right);
				vertices.Add(vertex_up_right);
				vertices.Add(vertex_down_left);

				//Get the position of the character on the texture.
				char character = text[i]; 
				float uv_x = (character % 16) / 16.0f;
				float uv_y = (character / 16) / 16.0f;

				Vector2 uv_up_left = new Vector2(uv_x, uv_y);
				Vector2 uv_up_right = new Vector2(uv_x + 1.0f / 16.0f, uv_y);
				Vector2 uv_down_right = new Vector2(uv_x + 1.0f / 16.0f, (uv_y + 1.0f / 16.0f));
				Vector2 uv_down_left = new Vector2(uv_x, (uv_y + 1.0f / 16.0f));
				UVs.Add(uv_up_left);
				UVs.Add(uv_down_left);
				UVs.Add(uv_up_right);

				UVs.Add(uv_down_right);
				UVs.Add(uv_up_right);
				UVs.Add(uv_down_left);
			}
			GL.BindBuffer(BufferTargets.GL_ARRAY_BUFFER, Text2DVertexBufferID);
			GL.BufferData(BufferTargets.GL_ARRAY_BUFFER, vertices.ToArray(), BufferUsages.GL_STATIC_DRAW);
			GL.BindBuffer(BufferTargets.GL_ARRAY_BUFFER, Text2DUVBufferID);
			GL.BufferData(BufferTargets.GL_ARRAY_BUFFER, UVs.ToArray(), BufferUsages.GL_STATIC_DRAW);

			// Bind shader
			GL.UseProgram(Text2DShaderID.GLHandle);

			// Bind texture
			GL.ActiveTexture(TextureUnits.GL_TEXTURE0);
			GL.BindTexture(TextureTargets.GL_TEXTURE_2D, Text2DTextureID.ID);
			// Set our "myTextureSampler" sampler to use Texture Unit 0
			GL.Uniform1i(Text2DUniformID, 0);

			// 1rst attribute buffer : vertices
			GL.EnableVertexAttribArray(0);
			GL.BindBuffer(BufferTargets.GL_ARRAY_BUFFER, Text2DVertexBufferID);
			GL.VertexAttribPointer(0, 2, GLDataTypes.GL_FLOAT, false, 0, 0);

			// 2nd attribute buffer : UVs
			GL.EnableVertexAttribArray(1);
			GL.BindBuffer(BufferTargets.GL_ARRAY_BUFFER, Text2DUVBufferID);
			GL.VertexAttribPointer(1, 2, GLDataTypes.GL_FLOAT, false, 0, 0);

			GL.Enable(GLCapabilities.GL_BLEND);
			GL.BlendFunc(BlendingFactor.GL_SRC_ALPHA, BlendingFactor.GL_ONE_MINUS_SRC_ALPHA);

			// Draw call
			GL.DrawArrays(RenderModes.GL_TRIANGLES, 0, vertices.Count);

			GL.Disable(GLCapabilities.GL_BLEND);

			GL.DisableVertexAttribArray(0);
			GL.DisableVertexAttribArray(1);

		}

		public void cleanupText2D()
		{

			// Delete buffers
			GL.DeleteBuffer(Text2DVertexBufferID);
			GL.DeleteBuffer(Text2DUVBufferID);

			// Delete texture
			GL.DeleteTexture(Text2DTextureID.ID);

			// Delete shader
			GL.DeleteProgram(Text2DShaderID.GLHandle);
		}
	}
}
