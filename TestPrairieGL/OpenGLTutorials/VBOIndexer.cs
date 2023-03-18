using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TestPrairieGL.OpenGLTutorials
{
	internal class VBOIndexer
	{
		// Returns true iif v1 can be considered equal to v2
		public static bool is_near(float v1, float v2)
		{
			return MathF.Abs(v1 - v2) < 0.01f;
		}

		// Searches through all already-exported vertices
		// for a similar one.
		// Similar = same position + same UVs + same normal
		public static bool getSimilarVertexIndex(
			Vector3 in_vertex,
			Vector2 in_uv,
			Vector3 in_normal,
			List<Vector3> out_vertices,
			List<Vector2> out_uvs,
			List<Vector3> out_normals,
			out ushort result
		)
		{
			// Lame linear search
			for (int i = 0; i < out_vertices.Count; i++)
			{
				if (
					is_near(in_vertex.X, out_vertices[i].X) &&
					is_near(in_vertex.Y, out_vertices[i].Y) &&
					is_near(in_vertex.Z, out_vertices[i].Z) &&
					is_near(in_uv.X, out_uvs[i].X) &&
					is_near(in_uv.Y, out_uvs[i].Y) &&
					is_near(in_normal.X, out_normals[i].X) &&
					is_near(in_normal.Y, out_normals[i].Y) &&
					is_near(in_normal.Z, out_normals[i].Z)
				)
				{
					result = (ushort)i;
					return true;
				}
			}
			// No other vertex could be used instead.
			// Looks like we'll have to add it to the VBO.
			result = 0;
			return false;
		}

		public static void indexVBO_slow(
			List<Vector3> in_vertices,
			List<Vector2> in_uvs,
			List<Vector3> in_normals,

			List<ushort> out_indices,
			List<Vector3> out_vertices,
			List<Vector2> out_uvs,
			List<Vector3> out_normals
		)
		{
			// For each input vertex
			for (int i = 0; i < in_vertices.Count; i++)
			{

				// Try to find a similar vertex in out_XXXX
				ushort index;
				bool found = getSimilarVertexIndex(in_vertices[i], in_uvs[i], in_normals[i], out_vertices, out_uvs, out_normals, out index);

				if (found)
				{ // A similar vertex is already in the VBO, use it instead !
					out_indices.Add(index);
				}
				else
				{ // If not, it needs to be added in the output data.
					out_vertices.Add(in_vertices[i]);
					out_uvs.Add(in_uvs[i]);
					out_normals.Add(in_normals[i]);
					out_indices.Add((ushort)(out_vertices.Count - 1));
				}
			}
		}

		public struct PackedVertex
		{
			public Vector3 position;
			public Vector2 uv;
			public Vector3 normal;
			//bool operator <(const PackedVertex that) const{
			//	return memcmp((void*)this, (void*)&that, sizeof(PackedVertex))>0;
			//};
		}

		public static bool getSimilarVertexIndex_fast(
			PackedVertex packed,
			Dictionary<PackedVertex, ushort> VertexToOutIndex,
			out ushort result
		)
		{
			if (!VertexToOutIndex.ContainsKey(packed))
			{
				result = 0;
				return false;
			}
			else
			{
				result = VertexToOutIndex[packed];
				return true;
			}
		}

		public static void indexVBO(
			List<Vector3> in_vertices,
			List<Vector2> in_uvs,
			List<Vector3> in_normals,

			out List<ushort> out_indices,
			out List<Vector3> out_vertices,
			out List<Vector2> out_uvs,
			out List<Vector3> out_normals
		)
		{


			out_indices = new List<ushort>();
			out_vertices = new List<Vector3>();
			out_uvs = new List<Vector2>();
			out_normals = new List<Vector3> ();

			Dictionary<PackedVertex, ushort> VertexToOutIndex = new Dictionary<PackedVertex, ushort>();

			// For each input vertex
			for (int i = 0; i < in_vertices.Count; i++)
			{

				PackedVertex packed = new PackedVertex() { position = in_vertices[i], uv = in_uvs[i], normal = in_normals[i] };


				// Try to find a similar vertex in out_XXXX
				ushort index;
				bool found = getSimilarVertexIndex_fast(packed, VertexToOutIndex, out index);

				if (found)
				{ // A similar vertex is already in the VBO, use it instead !
					out_indices.Add(index);
				}
				else
				{ // If not, it needs to be added in the output data.
					out_vertices.Add(in_vertices[i]);
					out_uvs.Add(in_uvs[i]);
					out_normals.Add(in_normals[i]);
					ushort newindex = (ushort)(out_vertices.Count - 1);
					out_indices.Add(newindex);
					VertexToOutIndex.Add(packed, newindex);
				}
			}
		}







		public static void indexVBO_TBN(
			List<Vector3> in_vertices,
			List<Vector2> in_uvs,
			List<Vector3> in_normals,
			List<Vector3> in_tangents,
			List<Vector3> in_bitangents,

			List<ushort> out_indices,
			List<Vector3> out_vertices,
			List<Vector2> out_uvs,
			List<Vector3> out_normals,
			List<Vector3> out_tangents,
			List<Vector3> out_bitangents
		)
		{
			// For each input vertex
			for (int i = 0; i < in_vertices.Count; i++)
			{

				// Try to find a similar vertex in out_XXXX
				ushort index;
				bool found = getSimilarVertexIndex(in_vertices[i], in_uvs[i], in_normals[i], out_vertices, out_uvs, out_normals, out index);

				if (found)
				{ // A similar vertex is already in the VBO, use it instead !
					out_indices.Add(index);

					// Average the tangents and the bitangents
					out_tangents[index] += in_tangents[i];
					out_bitangents[index] += in_bitangents[i];
				}
				else
				{ // If not, it needs to be added in the output data.
					out_vertices.Add(in_vertices[i]);
					out_uvs.Add(in_uvs[i]);
					out_normals.Add(in_normals[i]);
					out_tangents.Add(in_tangents[i]);
					out_bitangents.Add(in_bitangents[i]);
					out_indices.Add((ushort)(out_vertices.Count - 1));
				}
			}
		}
	}
}
