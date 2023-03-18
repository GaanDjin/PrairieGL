using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestPrairieGL
{
	public class OBJ
	{

		// Very, VERY simple OBJ loader.
		// Here is a short list of features a real function would provide : 
		// - Binary files. Reading a model should be just a few memcpy's away, not parsing a file at runtime. In short : OBJ is not very great.
		// - Animations & bones (includes bones weights)
		// - Multiple UVs
		// - All attributes should be optional, not "forced"
		// - More stable. Change a line in the OBJ file and it crashes.
		// - More secure. Change another line and you can inject code.
		// - Loading from memory, stream, etc

		public static bool loadOBJ(string path,
	out List<Vector3> out_vertices,
	out List<Vector2> out_uvs,
	out List<Vector3> out_normals
)
		{
			out_vertices = new List<Vector3>();
			out_uvs = new List<Vector2>();
			out_normals = new List<Vector3>();

			//Console.WriteLine("Loading OBJ file "+ path + "...");

			List<int> vertexIndices = new List<int>();
			List<int> uvIndices = new List<int>();
			List<int> normalIndices = new List<int>();
			List<Vector3> temp_vertices = new List<Vector3>();
			List<Vector2> temp_uvs = new List<Vector2>();
			List<Vector3> temp_normals = new List<Vector3>();


			TextReader file = new StreamReader(File.OpenRead(path));
			if (file == null)
			{
				Console.WriteLine("Impossible to open the file ! Are you in the right path ? See Tutorial 1 for details\n");

				return false;
			}


			Regex re = new Regex("[\\d]+");

			while (true)
			{

				string lineHeader = file.ReadLine(); //[128];
													 // read the first word of the line
													 //int res = fscanf(file, "%s", lineHeader);
				if (lineHeader == null)
					break; // EOF = End Of File. Quit the loop.

				// else : parse lineHeader

				string[] splitLine = lineHeader.Split(' ');

				if (lineHeader.StartsWith("v "))
				{
					Vector3 vertex = new Vector3(float.Parse(splitLine[1]), float.Parse(splitLine[2]), float.Parse(splitLine[3]));
					temp_vertices.Add(vertex);
				}
				else if (lineHeader.StartsWith("vt "))
				{
					Vector2 uv = new Vector2(float.Parse(splitLine[1]), float.Parse(splitLine[2]));
					uv.Y = -uv.Y; // Invert V coordinate since we will only use DDS texture, which are inverted. Remove if you want to use TGA or BMP loaders.
					temp_uvs.Add(uv);
				}
				else if (lineHeader.StartsWith("vn "))
				{
					Vector3 normal = new Vector3(float.Parse(splitLine[1]), float.Parse(splitLine[2]), float.Parse(splitLine[3]));
					temp_normals.Add(normal);
				}
				else if (lineHeader.StartsWith("f "))
				{
					/*
					f 1 2 3
					f 3/1 4/2 5/3
					f 6/4/1 3/5/3 7/6/5
					f 7//1 8//2 9//3
					*/
					//string vertex1, vertex2, vertex3;
					//int[] vertexIndex = new int[3], uvIndex = new int[3], normalIndex = new int[3];
					
					List<int> tmpIndex = new List<int>();
					List<int> tmpUV = new List<int>();
					List<int> tmpNorm = new List<int>();

                    int currPart = -1;
					string currValue = "";
					int value;

                    foreach (char c in lineHeader)
					{
						if ((byte)c >= 48 && (byte)c <= 57)
							currValue += c;
						else if (c == '/')
                        {
                            if (currValue.Length > 0) value = int.Parse(currValue);
                            else value = 0;

							switch (currPart)
							{
								case 0:
									tmpIndex.Add(value);
									break;
								case 1:
									tmpUV.Add(value);
									break;
								case 2:
									tmpNorm.Add(value);
									break;
							}
							currPart++;
							currValue = "";
                        }
						else if (c == ' ')
						{
							if (currValue.Length > 0) value = int.Parse(currValue);
							else value = 0;
                            switch (currPart)
                            {
                                case 0:
                                    tmpIndex.Add(value);
                                    break;
                                case 1:
                                    tmpUV.Add(value);
                                    break;
                                case 2:
                                    tmpNorm.Add(value);
                                    break;
                            }

							currPart = 0;
                            currValue = "";
                        }
                    }

                    value = int.Parse(currValue);
                    switch (currPart)
                    {
                        case 0:
                            tmpIndex.Add(value);
                            break;
                        case 1:
                            tmpUV.Add(value);
                            break;
                        case 2:
                            tmpNorm.Add(value);
                            break;
                    }

					if (tmpIndex.Count == 3)
                    {
                        vertexIndices.AddRange(tmpIndex);
                        uvIndices.AddRange(tmpUV);
                        normalIndices.AddRange(tmpNorm);
                    }
					else
					{
						vertexIndices.AddRange(TrianglesFromPloygons(tmpIndex.ToArray()));
                        uvIndices.AddRange(TrianglesFromPloygons(tmpUV.ToArray()));
                        normalIndices.AddRange(TrianglesFromPloygons(tmpNorm.ToArray()));
                    }

                    //List<int> matches = new List<int>();
                    //foreach (Match m in re.Matches(lineHeader))
                    //{
                    //	matches.Add(int.Parse(m.Value));
                    //}

                    //if (matches.Count == 9)
                    //               {
                    //	vertexIndices.Add(matches[0]);
                    //	vertexIndices.Add(matches[3]);
                    //	vertexIndices.Add(matches[6]);
                    //	uvIndices.Add(matches[1]);
                    //	uvIndices.Add(matches[4]);
                    //	uvIndices.Add(matches[7]);
                    //	normalIndices.Add(matches[2]);
                    //	normalIndices.Add(matches[5]);
                    //	normalIndices.Add(matches[8]);
                    //}
                    //else
                    //{

                    //	//	Console.WriteLine("File can't be read by our simple parser :-( Try exporting with other options\n");
                    //	//file.Close();
                    //	//return false;
                    //}

                }
				else
				{
					// Probably a comment, eat up the rest of the line

				}

			}

			// For each vertex of each triangle
			for (int i = 0; i < vertexIndices.Count; i++)
			{

				// Get the indices of its attributes
				int vertexIndex = vertexIndices[i];
				int uvIndex = uvIndices[i];
				int normalIndex = normalIndices[i];

				// Get the attributes thanks to the index
				Vector3 vertex = temp_vertices[vertexIndex - 1];
				Vector2 uv = temp_uvs[uvIndex - 1];
				Vector3 normal = temp_normals[normalIndex - 1];

				// Put the attributes in buffers
				out_vertices.Add(vertex);
				out_uvs.Add(uv);
				out_normals.Add(normal);

			}
			file.Close();
			return true;
		}

        public static int[] TrianglesFromPloygons(int[] polygon)
        {
            //TODO: Implement ear clipping: https://www.geometrictools.com/Documentation/TriangulationByEarClipping.pdf
            switch (polygon.Length)
            {
                case 0:
                case 1:
                    Console.WriteLine("Warning: processing polygon unsupported polygon size! Points: " + polygon.Length);
                    return new int[0];
                //    return new int[] { polygon[0], polygon[0], polygon[0] };
                //case 2:
                //    Console.WriteLine("Warning: processing polygon unsupported polygon size! Points: " + polygon.Length);
                //    return new int[] { polygon[0], polygon[1], polygon[1] };
                case 3:
                    return polygon;
                case 4:
                    return new int[] { polygon[0], polygon[1], polygon[2], polygon[0], polygon[2], polygon[3] };
                case 5:
                    return new int[] { polygon[0], polygon[1], polygon[2], polygon[0], polygon[2], polygon[3], polygon[0], polygon[3], polygon[4] };
                default:
                    //Simple triangle fan type.
                    List<int> result = new List<int>();
                    for (int i = 1; i < polygon.Length - 1; i++)
                    {
                        result.Add(polygon[0]);
                        result.Add(polygon[i]);
                        result.Add(polygon[i + 1]);
                    }
                    return result.ToArray();
            }
        }

    }
}
