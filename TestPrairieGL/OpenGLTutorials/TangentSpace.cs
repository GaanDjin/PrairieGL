

using System.Numerics;

namespace TestPrairieGL.OpenGLTutorials
{
	public class TangentSpace
	{
		public static void computeTangentBasis(
	// inputs
	List<Vector3> vertices,
	List<Vector2> uvs,
	List<Vector3> normals,
	// outputs
	List<Vector3> tangents,
	List<Vector3> bitangents
)
		{

			for (int i = 0; i < vertices.Count; i += 3)
			{

				// Shortcuts for vertices
				Vector3 v0 = vertices[i + 0];
				Vector3 v1 = vertices[i + 1];
				Vector3 v2 = vertices[i + 2];

				// Shortcuts for UVs
				Vector2 uv0 = uvs[i + 0];
				Vector2 uv1 = uvs[i + 1];
				Vector2 uv2 = uvs[i + 2];

				// Edges of the triangle : postion delta
				Vector3 deltaPos1 = v1 - v0;
				Vector3 deltaPos2 = v2 - v0;

				// UV delta
				Vector2 deltaUV1 = uv1 - uv0;
				Vector2 deltaUV2 = uv2 - uv0;

				float r = 1.0f / (deltaUV1.X * deltaUV2.Y - deltaUV1.Y * deltaUV2.X);
				Vector3 tangent = (deltaPos1 * deltaUV2.Y - deltaPos2 * deltaUV1.Y) * r;
				Vector3 bitangent = (deltaPos2 * deltaUV1.X - deltaPos1 * deltaUV2.X) * r;

				// Set the same tangent for all three vertices of the triangle.
				// They will be merged later, in vboindexer.cpp
				tangents.Add(tangent);
				tangents.Add(tangent);
				tangents.Add(tangent);

				// Same thing for binormals
				bitangents.Add(bitangent);
				bitangents.Add(bitangent);
				bitangents.Add(bitangent);

			}

			// See "Going Further"
			for (int i = 0; i < vertices.Count; i += 1)
			{
				Vector3 n = normals[i];
				Vector3 t = tangents[i];
				Vector3 b = bitangents[i];

				// Gram-Schmidt orthogonalize
				t = Vector3.Normalize(t - n * Vector3.Dot(n, t));

				// Calculate handedness
				if (Vector3.Dot(Vector3.Cross(n, t), b) < 0.0f)
				{
					t = t * -1.0f;
				}

			}


		}

	}
}