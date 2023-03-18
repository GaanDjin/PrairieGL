using PrairieGL.OpenGL;
using System.Numerics;

namespace PrairieGL
{
    /// <summary>
    /// The sharder class loads, then compiles, and sends the shader program to 
    /// the GPU for rendering objects that use this Shader. 
    /// 
    ///TODO: If common shader code gets unruly move to embedded resource file. 
    ///TODO: Or plain file for editing w/o recompiling?
    ///TODO: Implement other Shader program types (Geometry, tessellation).
    /// </summary>
    public class Shader : IDisposable
    {
        /// <summary>
        /// The list of active Shaders that have been compiled and may be in use.
        /// </summary>
        private static List<Shader> Shaders { get; set; } = new List<Shader>();

        /// <summary>
        /// The OpenGL handle to this shader. 
        /// </summary>
        public readonly uint GLHandle;

        /// <summary>
        /// Gets all uniform (Variable) names and handles used by this shader. 
        /// If the shader code has uniforms that aren't actually used by the shader
        /// they will not appear in the list. 
        /// </summary>
        private readonly Dictionary<string, int> uniformLocations;

        /// <summary>
        /// Gets all uniform (Variable) names used by this shader. 
        /// If the shader code has uniforms that aren't actually used by the shader
        /// they will not appear in the list. 
        /// </summary>
        public List<string> Uniforms { get {
                if (uniformLocations.Count == 0) ListUniforms();
                return uniformLocations.Keys.ToList();
            } }

        /// <summary>
        /// The final source code of the Vertex portion of this Shader.
        /// </summary>
        public readonly string VertexSource;

        /// <summary>
        /// The final source code of the Fragment portion of this Shader.
        /// </summary>
        public readonly string FragmentSource;

        
        /// <summary>
        /// The Common Helper code to be injected into the Global region of the 
        /// Vertex Shader. Inserted on the line after the #version directive.
        /// </summary>
        public const string CommonVertGlobalVariables = @"

const int MAX_BONES = 100;
const int MAX_BONE_INFLUENCE = 4;

layout(location = 0) in vec3 aPosition; //gl_Vertex
layout(location = 1) in vec2 aTexCoord;
layout(location = 2) in vec3 aNormal;
layout(location = 3) in vec4 aColour;

layout(location = 4) in vec4 boneIds;
layout(location = 5) in vec4 boneWeights;

out vec3 Normal;
out vec4 WorldPosition;
out vec4 LocalPosition;
out vec4 Colour;
out vec2 TexCoords;

uniform vec3 _Size;
uniform vec3 _Center;

uniform int _UseBones;
uniform mat4 BonePositions[MAX_BONES];

uniform mat4 modelRot;
uniform mat4 modelScale;
uniform mat4 modelPos;

uniform mat4 view;
uniform mat4 projection;
// Values that stay constant for the whole mesh.
//uniform mat4 MVP;

uniform float time;


";

        /// <summary>
        /// The Common Helper code to be injected into the 
        /// beginning of main function of the Vertex Shader. 
        /// </summary>
        public const string CommonVertMainInitValues = @"

    if (_UseBones == 1){
        vec4 totalPosition = vec4(0.0f);
        for(int i = 0 ; i < MAX_BONE_INFLUENCE ; i++)
        {
            if(boneIds[i] == -1) 
                continue;
            if(boneIds[i] >= MAX_BONES) 
            {
                totalPosition = vec4(aPosition,1.0f);
                break;
            }
            vec4 localPosition = BonePositions[int(boneIds[i])] * vec4(aPosition,1.0f);
            totalPosition += localPosition * boneWeights[i];
            Normal = mat3(BonePositions[int(boneIds[i])]) * aNormal;
        }
        
        LocalPosition = totalPosition; // vec4(aPosition, 1.0);
    }
    else
    {
        Normal = aNormal;
        LocalPosition = vec4(aPosition, 1.0);
    }

mat4 model = modelScale * modelRot * modelPos;

	WorldPosition = LocalPosition * model * view * projection;
	Colour = aColour;
	TexCoords = aTexCoord;
";

        /// <summary>
        /// The Common Helper code to be injected into the Global region of the 
        /// Fragment Shader. Inserted on the line after the #version directive. 
        /// </summary>
        public const string CommonFragGlobalVariables = @"

        struct Material {
    sampler2D DiffuseTexture;
    sampler2D NormalTexture;
    sampler2D SpecularTexture;

    float Shininess;
    vec3 AmbientColour;
	vec3 DiffuseColour;
	vec3 SpecularColour;
}; 


out vec4 outputColor;

in vec2 TexCoords;
in vec3 Normal;
in vec4 WorldPosition;
in vec4 LocalPosition;
in vec4 Colour;

uniform vec3 _Size;
uniform vec3 _Center;

uniform Material material;

uniform float time;
uniform vec2 resolution;






// A single iteration of Bob Jenkins' One-At-A-Time hashing algorithm.
uint hash( uint x ) {
    x += ( x << 10u );
    x ^= ( x >>  6u );
    x += ( x <<  3u );
    x ^= ( x >> 11u );
    x += ( x << 15u );
    return x;
}



// Compound versions of the hashing algorithm I whipped together.
uint hash( uvec2 v ) { return hash( v.x ^ hash(v.y)                         ); }
uint hash( uvec3 v ) { return hash( v.x ^ hash(v.y) ^ hash(v.z)             ); }
uint hash( uvec4 v ) { return hash( v.x ^ hash(v.y) ^ hash(v.z) ^ hash(v.w) ); }



// Construct a float with half-open range [0:1] using low 23 bits.
// All zeroes yields 0.0, all ones yields the next smallest representable value below 1.0.
float floatConstruct( uint m ) {
    const uint ieeeMantissa = 0x007FFFFFu; // binary32 mantissa bitmask
    const uint ieeeOne      = 0x3F800000u; // 1.0 in IEEE binary32

    m &= ieeeMantissa;                     // Keep only mantissa bits (fractional part)
    m |= ieeeOne;                          // Add fractional part to 1.0

    float  f = uintBitsToFloat( m );       // Range [1:2]
    return f - 1.0;                        // Range [0:1]
}



// Pseudo-random value in half-open range [0:1].
float random( float x ) { return floatConstruct(hash(floatBitsToUint(x))); }
float random( vec2  v ) { return floatConstruct(hash(floatBitsToUint(v))); }
float random( vec3  v ) { return floatConstruct(hash(floatBitsToUint(v))); }
float random( vec4  v ) { return floatConstruct(hash(floatBitsToUint(v))); }


vec3 mod289f3(vec3 x) {
    return x - floor(x* (1.0 / 289.0)) * 289.0;
}


vec4 mod289f4(vec4 x) {
    return x - floor(x * (1.0 / 289.0)) * 289.0;
}

vec4 permute(vec4 x) {
    return mod289f4(((x * 34.0) + 10.0) * x);
}



vec4 taylorInvSqrt(vec4 r)
{
    return 1.79284291400159 - 0.85373472095314 * r;
}


float snoise(vec3 v)
{
    vec2  C = vec2(1.0 / 6.0, 1.0 / 3.0);
    vec4  D = vec4(0.0, 0.5, 1.0, 2.0);

    // First corner
    vec3 i = floor(v + dot(v, C.yyy));
    vec3 x0 = v - i + dot(i, C.xxx);

    // Other corners
    vec3 g = step(x0.yzx, x0.xyz);
    vec3 l = 1.0 - g;
    vec3 i1 = min(g.xyz, l.zxy);
    vec3 i2 = max(g.xyz, l.zxy);

    //   x0 = x0 - 0.0 + 0.0 * C.xxx;
    //   x1 = x0 - i1  + 1.0 * C.xxx;
    //   x2 = x0 - i2  + 2.0 * C.xxx;
    //   x3 = x0 - 1.0 + 3.0 * C.xxx;
    vec3 x1 = x0 - i1 + C.xxx;
    vec3 x2 = x0 - i2 + C.yyy; // 2.0*C.x = 1/3 = C.y
    vec3 x3 = x0 - D.yyy;      // -1.0+3.0*C.x = -0.5 = -D.y

    // Permutations
    i = mod289f3(i);
    vec4 p = permute(permute(permute(
        i.z + vec4(0.0, i1.z, i2.z, 1.0))
        + i.y + vec4(0.0, i1.y, i2.y, 1.0))
        + i.x + vec4(0.0, i1.x, i2.x, 1.0));


    // Gradients: 7x7 points over a square, mapped onto an octahedron.
    // The ring size 17*17 = 289 is close to a multiple of 49 (49*6 = 294)
    float n_ = 0.142857142857; // 1.0/7.0
    vec3  ns = n_ * D.wyz - D.xzx;

    vec4 j = p - 49.0 * floor(p * ns.z * ns.z);  //  mod(p,7*7)

    vec4 x_ = floor(j * ns.z);
    vec4 y_ = floor(j - 7.0 * x_);    // mod(j,N)


    vec4 x = x_ * ns.x + ns.yyyy;
    vec4 y = y_ * ns.x + ns.yyyy;

    vec4 h;
    h.x = 1.0 - abs(x.x) - abs(y.x);
    h.y = 1.0 - abs(x.y) - abs(y.y);
    h.z = 1.0 - abs(x.z) - abs(y.z);
    h.w = 1.0 - abs(x.w) - abs(y.w);

    vec4 b0 = vec4(x.xy, y.xy);
    vec4 b1 = vec4(x.zw, y.zw);

    //vec4 s0 = vec4(lessThan(b0,0.0))*2.0 - 1.0;
    //vec4 s1 = vec4(lessThan(b1,0.0))*2.0 - 1.0;
    vec4 s0 = floor(b0) * 2.0 + 1.0;
    vec4 s1 = floor(b1) * 2.0 + 1.0;
    vec4 sh = -step(h, vec4(0.0));

    vec4 a0 = b0.xzyw + s0.xzyw * sh.xxyy;
    vec4 a1 = b1.xzyw + s1.xzyw * sh.zzww;

    vec3 p0 = vec3(a0.xy, h.x);
    vec3 p1 = vec3(a0.zw, h.y);
    vec3 p2 = vec3(a1.xy, h.z);
    vec3 p3 = vec3(a1.zw, h.w);

    //Normalise gradients
    vec4 norm = taylorInvSqrt(vec4(dot(p0, p0), dot(p1, p1), dot(p2, p2), dot(p3, p3)));
    p0 *= norm.x;
    p1 *= norm.y;
    p2 *= norm.z;
    p3 *= norm.w;

    // Mix final noise value
    vec4 tmp = vec4(0.5 - dot(x0, x0), 0.5 - dot(x1, x1), 0.5 - dot(x2, x2), 0.5 - dot(x3, x3));
    vec4 zero = vec4(0, 0, 0, 0);
    vec4 m = max(tmp, zero);

    m = m * m;
    return 105.0 * dot(m * m, vec4(dot(p0, x0), dot(p1, x1),
        dot(p2, x2), dot(p3, x3)));
}


//Adjusts a colour slightly.
vec4 perturb(vec4 c, vec3 randPoint, float scale)
{
    float PHI = 1.61803398874989484820459;  // Φ = Golden Ratio   

    float fx = (tan(distance(c, c * PHI) * random(randPoint)) * c.z);
    fx = (fx - floor(fx)) / scale; ///Divide by higher numbers like 5.0 means less difference and lower numbers like 0.5 means more difference.
    float fy = (tan(distance(c, c * PHI) * random(randPoint)) * c.z);
    fy = (fy - floor(fy)) / scale; ///Divide by higher numbers like 5.0 means less difference and lower numbers like 0.5 means more difference.
    float fz = (tan(distance(c, c * PHI) * random(randPoint)) * c.x);
    fz = (fz - floor(fz)) / scale; ///Divide by higher numbers like 5.0 means less difference and lower numbers like 0.5 means more difference.

    c.x *= (fx + 1);
    c.y *= (fy + 1);
    c.z *= (fz + 1);

    return c;
}

//Adjusts a colour slightly. 
vec3 perturb(vec3 c, vec3 randPoint, float scale){
    return perturb(vec4(c, 1), randPoint, scale).xyz;
}


";

        /// <summary>
        /// The Common Helper code to be injected into the 
        /// beginning of main function of the Fragment Shader. 
        /// </summary>
        public const string CommonFragMainInitValues = @"
// properties
    vec3 norm = normalize(Normal);
    vec3 viewDir = normalize(LocalPosition - WorldPosition).xyz;
    
    vec4 result = Colour;

    outputColor = result;
";

        /// <summary>
        /// Injects the common Shader code into the provided Shader source.
        /// </summary>
        /// <param name="userVertCode">The Vertex Shader source code</param>
        /// <param name="userFragCode">The Fragment Shader source code</param>
		private static void InjectCommonShaderCode(ref string userVertCode, ref string userFragCode)
		{
			userVertCode = InjectCommonShaderCode(userVertCode, true);
			userFragCode = InjectCommonShaderCode(userFragCode, false);
		}

        /// <summary>
        /// Injects the common Shader code into the provided Shader source.
        /// </summary>
        /// <param name="userCode">The Shader source code</param>
        /// <param name="isVertShader">If true then the userCode is expected to be a Vertex Shader; Otherwise Fragment shader source is expected.</param>
		private static string InjectCommonShaderCode(string userCode, bool isVertShader)
		{
			//For both Frag and Vert
			//Find Version Tag: "#version "
			//Next line inject variables and global shutches 
			//Find main function "void main"
			//Find next open curly brace: {
			//Inject initialization code before user code. 

			string globalVars = isVertShader ? CommonVertGlobalVariables : CommonFragGlobalVariables;
			string mainInitCode = isVertShader ? CommonVertMainInitValues : CommonFragMainInitValues;

			//Gawd it's bad when you have to write old skool because Regex won't work right! (Yes I tested the very same strings and regex in js without issue.)

			//Match match = Regex.Match(userCode, @"(\#version\s)(.)*(\n|\r)");

			//int insertLocation = match.Index + match.Length + 1;

			//string fullCode = userCode.Insert(insertLocation, globalVars);

			//match = Regex.Match(fullCode, @"void\smain(.|\n|\r)*\{");

			//insertLocation = match.Index + match.Length + 1;

			//return fullCode.Insert(insertLocation, mainInitCode);

			///TODO: This is open to so many faulures
			///Doesn't account for commented out blocks. 
			///The white space is tabs instead of a space char.
			///if there's more than one space in "void main"

			string fullCode = userCode;

			int versIndex = fullCode.IndexOf("#version ");
			int newlineIndex = fullCode.IndexOf('\n', versIndex);
			fullCode = fullCode.Insert(newlineIndex + 1, globalVars);


			int mainIndex = fullCode.IndexOf("void main(");
			int openBraceIndex = fullCode.IndexOf('{', mainIndex);
			fullCode = fullCode.Insert(openBraceIndex + 1, mainInitCode);

			return fullCode;
		}

        /// <summary>
        /// Creates a Shader object from an existing compiled shader. 
        /// This does not clone a shader but rather creates a reference copy to 
        /// an existing Shader. The source is saved but not compiled or used here.
        /// </summary>
        /// <param name="handle">The OpenGL handle of the Shader to use</param>
        /// <param name="refVert">The Vertex shader source, for reference.</param>
        /// <param name="refFrag">The Fragment shader source, for reference.</param>
		private Shader(uint handle, string refVert, string refFrag)
        {
            VertexSource = refVert;
            FragmentSource = refFrag;

            GLHandle = handle;
			uniformLocations = new Dictionary<string, int>();
            ListUniforms();

            Shaders.Add(this);
        }

        /// <summary>
        /// Tell the GPU this is the activa shader that will be used to render any
        /// subsiquent calls.
        /// </summary>
        public void Use()
        {
            GL.UseProgram(GLHandle);
        }

        /// <summary>
        /// Loads a shader from the source code located in the file system.
        /// </summary>
        /// <param name="vertex_file_path">The path to the vertex shader source code file</param>
        /// <param name="fragment_file_path">The path to the fragmet shader source code</param>
        /// <param name="includeCommon">Use to include built in shader code or just the passed source</param>
        /// <returns>The newly created shader</returns>
        /// <remarks>
        /// When a mesh is being rendered from PrairieEngine these shader attributes are set:
        /// 
        /// "_Size" = Mesh.Bounds.Size
        /// "_Center" = Mesh.Bounds.Center
        /// "_UseBones" = 0 ///TODO: Implement Bones & Animations in Mesh Class
        /// 
        /// Vertex Attrib Arrays:
        /// (0) = Vertex Buffer
        /// (1) = uvbuffer
        /// (2) = normalbuffer
        /// (3) = colorbuffer
        /// And indicies are bound as GL_ELEMENT_ARRAY_BUFFER and then drawn as triangels via DrawElements
        /// 
        /// "modelScale" = GlobalScale;
        /// "modelRot" = GlobalRotation;
        /// "modelPos" = GlobalPosition;
        /// And the final position of the model is then calculated as:
        /// mat4 model = modelScale * modelRot * modelPos
        /// 
        /// When writing a shader one should take care to use the same attributes in the same order. 
        /// More can be added and set as the program requires. 
        /// </remarks>
		public static Shader LoadShaderFromFile(string vertex_file_path, string fragment_file_path, bool includeCommon = true)
		{
			// Read the Vertex Shader code from the file
			string VertexShaderCode = File.ReadAllText(vertex_file_path);
			// Read the Fragment Shader code from the file
			string FragmentShaderCode = File.ReadAllText(fragment_file_path);

			return LoadShader(VertexShaderCode, FragmentShaderCode);
		}

        /// <summary>
        /// Loads a shadrer fromthe source code passed as a string.
        /// </summary>
        /// <param name="VertexShaderCode">The string containing the vertex source code</param>
        /// <param name="FragmentShaderCode">The string containing the fragment source code</param>
        /// <param name="includeCommon">Use to include built in shader code or just the passed source</param>
        /// <returns>The newly created shader</returns>
		public static Shader LoadShader(string VertexShaderCode, string FragmentShaderCode, bool includeCommon = true)
		{
            if (includeCommon)
    			InjectCommonShaderCode(ref VertexShaderCode, ref FragmentShaderCode);


			// Create the shaders
			uint VertexShaderID = GL.CreateShader(ShaderProgramTypes.GL_VERTEX_SHADER);
			uint FragmentShaderID = GL.CreateShader(ShaderProgramTypes.GL_FRAGMENT_SHADER);



			int Result = 0; // GL_FALSE;
			int InfoLogLength;


			// Compile Vertex Shader
			//Console.WriteLine("Compiling vertex shader\n");

			GL.ShaderSource(VertexShaderID, VertexShaderCode);
			GL.CompileShader(VertexShaderID);

			// Check Vertex Shader
			GL.GetShaderiv(VertexShaderID, ShaderParameters.GL_COMPILE_STATUS, out Result);
			GL.GetShaderiv(VertexShaderID, ShaderParameters.GL_INFO_LOG_LENGTH, out InfoLogLength);
			if (InfoLogLength > 0)
			{
				string VertexShaderErrorMessage;
				GL.GetShaderInfoLog(VertexShaderID, InfoLogLength, out _, out VertexShaderErrorMessage);
				Console.WriteLine(VertexShaderErrorMessage);
			}



			// Compile Fragment Shader
			//Console.WriteLine("Compiling fragment shader\n");

			GL.ShaderSource(FragmentShaderID, FragmentShaderCode);
			GL.CompileShader(FragmentShaderID);

			// Check Fragment Shader
			GL.GetShaderiv(FragmentShaderID, ShaderParameters.GL_COMPILE_STATUS, out Result);
			GL.GetShaderiv(FragmentShaderID, ShaderParameters.GL_INFO_LOG_LENGTH, out InfoLogLength);
			if (InfoLogLength > 0)
			{
				string FragmentShaderErrorMessage;
				GL.GetShaderInfoLog(FragmentShaderID, InfoLogLength, out _, out FragmentShaderErrorMessage);
				Console.WriteLine(FragmentShaderErrorMessage);
			}



			// Link the program
			//Console.WriteLine("Linking program\n");
			uint ProgramID = GL.CreateProgram();
			GL.AttachShader(ProgramID, VertexShaderID);
			GL.AttachShader(ProgramID, FragmentShaderID);
			GL.LinkProgram(ProgramID);

			// Check the program
			GL.GetProgramiv(ProgramID, ProgramParameters.GL_LINK_STATUS, out Result);
			GL.GetProgramiv(ProgramID, ProgramParameters.GL_INFO_LOG_LENGTH, out InfoLogLength);
			if (InfoLogLength > 0)
			{
				string ProgramErrorMessage;
				GL.GetProgramInfoLog(ProgramID, InfoLogLength, out _, out ProgramErrorMessage);
				Console.WriteLine(ProgramErrorMessage);
			}


			GL.DetachShader(ProgramID, VertexShaderID);
			GL.DetachShader(ProgramID, FragmentShaderID);

			GL.DeleteShader(VertexShaderID);
			GL.DeleteShader(FragmentShaderID);



			Shader s = new Shader(ProgramID, VertexShaderCode, FragmentShaderCode);
            return s;
        }

        /// <summary>
        /// Queries the GPU for all uniforms (Variables) used by this shader. 
        /// If the shader code has uniforms that aren't actually used by the shader
        /// they will not appear in the list. 
        /// </summary>
        private void ListUniforms()
        {
            // First, we have to get the number of active uniforms in the shader.
            GL.GetProgramiv(GLHandle, ProgramParameters.GL_ACTIVE_UNIFORMS, out int numberOfUniforms);

            // Loop over all the uniforms,
            for (int i = 0; i < numberOfUniforms; i++)
            {
                // get the name of this uniform,
                GL.GetActiveUniform(GLHandle, i, out _, out _, out string key);

                // get the location,
                int location = GL.GetUniformLocation(GLHandle, key);

                // and then add it to the dictionary.
                uniformLocations.Add(key, location);

                //GL.GetUniform(Handle, i, out float uniformValue);

            }

        }

        /// <summary>
        /// Gets the OpenGL ID of the specidied Attribute (Variable) used by this shader. 
        /// If the shader does not contain the requested Attribute -1 is returned.
        /// </summary>
        /// <param name="attribName">The name of the Attribute (Variable) to get.</param>
        /// <returns>The ID of the Attribute or -1 if it doesn't exist.</returns>
        public int GetAttribLocation(string attribName)
        {

            if (HasUniform(attribName))
                return uniformLocations[attribName];
            return -1;
        }

        #region Uniform setters
        // Uniforms are variables that can be set by user code, instead of reading them from the VBO.
        // You use VBOs for vertex-related data, and uniforms for almost everything else.

        // Setting a uniform is almost always the exact same, so I'll explain it here once, instead of in every method:
        //     1. Bind the program you want to set the uniform on
        //     2. Get a handle to the location of the uniform with GL.GetUniformLocation.
        //     3. Use the appropriate GL.Uniform* function to set the uniform.

        /// <summary>
        /// Set a uniform (variable) int value on this shader.
        /// </summary>
        /// <param name="name">The name of the uniform</param>
        /// <param name="data">The data to set</param>
        public void SetUniform(string name, int data)
        {
            if (HasUniform(name))
            {
                GL.UseProgram(GLHandle);
                GL.Uniform1i(uniformLocations[name], data);
            }
        }

        /// <summary>
        /// Set a uniform (variable) float value on this shader.
        /// </summary>
        /// <param name="name">The name of the uniform</param>
        /// <param name="data">The data to set</param>
        public void SetUniform(string name, float data)
        {
            if (HasUniform(name))
            {
                GL.UseProgram(GLHandle);
                GL.Uniform1f(uniformLocations[name], data);
            }
        }

        /// <summary>
        /// Set a uniform (variable) double value on this shader.
        /// </summary>
        /// <param name="name">The name of the uniform</param>
        /// <param name="data">The data to set</param>
        public void SetUniform(string name, double data)
        {
            if (HasUniform(name))
            {
                GL.UseProgram(GLHandle);
                GL.Uniform1f(uniformLocations[name], (float)data);
            }
        }

        /// <summary>
        /// Set a uniform (variable) Matrix4x4 value on this shader.
        /// </summary>
        /// <param name="name">The name of the uniform</param>
        /// <param name="data">The data to set</param>
        public void SetUniform(string name, Matrix4x4 data)
        {
            if (HasUniform(name))
            {
                //ReadOnlySpan<float> matrices = new ReadOnlySpan<float>(data.ToArray());

                GL.UseProgram(GLHandle);
                GL.UniformMatrix4fv(uniformLocations[name], 1, true, data);
            }
        }

        /// <summary>
        /// Set a uniform (variable) Matrix3x3 value on this shader.
        /// </summary>
        /// <param name="name">The name of the uniform</param>
        /// <param name="data">The data to set</param>
        public void SetUniform(string name, Matrix3x3 data)
        {
            if (HasUniform(name))
            {
                //ReadOnlySpan<float> matrices = new ReadOnlySpan<float>(data.ToArray());

                GL.UseProgram(GLHandle);
                GL.UniformMatrix3fv(uniformLocations[name], 1, true, data);
            }
        }

        /// <summary>
        /// Set a uniform (variable) Vector3 value on this shader.
        /// </summary>
        /// <param name="name">The name of the uniform</param>
        /// <param name="data">The data to set</param>
        public void SetUniform(string name, Vector3 data)
        {
            if (HasUniform(name))
            {
                GL.UseProgram(GLHandle);
                GL.Uniform3f(uniformLocations[name], data.X, data.Y, data.Z);
            }
        }

        /// <summary>
        /// Set a uniform (variable) Vector2 value on this shader.
        /// </summary>
        /// <param name="name">The name of the uniform</param>
        /// <param name="data">The data to set</param>
        public void SetUniform(string name, Vector2 data)
        {
            if (HasUniform(name))
            {
                GL.UseProgram(GLHandle);
                GL.Uniform2f(uniformLocations[name], data.X, data.Y);
            }
        }

        /// <summary>
        /// Set a uniform (variable) Vector4 value on this shader.
        /// </summary>
        /// <param name="name">The name of the uniform</param>
        /// <param name="data">The data to set</param>
        public void SetUniform(string name, Vector4 data)
        {
            if (HasUniform(name))
            {
                GL.UseProgram(GLHandle);
                GL.Uniform4f(uniformLocations[name], data.X, data.Y, data.Z, data.W);
            }
        }

        /// <summary>
        /// Set a uniform (variable) Quaternion value on this shader.
        /// </summary>
        /// <param name="name">The name of the uniform</param>
        /// <param name="data">The data to set</param>
        public void SetUniform(string name, Quaternion data)
        {
            if (HasUniform(name))
            {
                GL.UseProgram(GLHandle);
                GL.Uniform4f(uniformLocations[name], data.X, data.Y, data.Z, data.W);
            }
        }

        /// <summary>
        /// Checks the Shader program (Queries the GPU) to see if the reqested Uniform exists.
        /// For array values the array "[]" portion is stripped and only the name is 
        /// queried. Array bounds are not validated!
        /// </summary>
        /// <param name="name">The name of the uniform to check.</param>
        /// <returns>True if this Shader has the specified uniform; Otherwise false.</returns>
        public bool HasUniform(string name)
        {
            if (uniformLocations.ContainsKey(name))
            {
                return true;
            }

            if (name.Contains("["))
                name = name.Substring(0, name.IndexOf("["));

            if (uniformLocations.ContainsKey(name))
            {
                return true;
            }

            return false;
        }

        #endregion

        #region Set all shader values

        /// <summary>
        /// Set a uniform int value on all shaders.
        /// </summary>
        /// <param name="name">The name of the uniform</param>
        /// <param name="data">The data to set</param>
        public static void SetUniformAll(string name, int data)
        {
            foreach (Shader s in Shaders)
            {
                s.SetUniform(name, data);
            }
        }

        /// <summary>
        /// Set a uniform float value on all shaders.
        /// </summary>
        /// <param name="name">The name of the uniform</param>
        /// <param name="data">The data to set</param>
        public static void SetUniformAll(string name, float data)
        {
            foreach (Shader s in Shaders)
            {
                s.SetUniform(name, data);
            }
        }

        /// <summary>
        /// Set a uniform Matrix4x4 value on all shaders.
        /// </summary>
        /// <param name="name">The name of the uniform</param>
        /// <param name="data">The data to set</param>
        /// </remarks>
        public static void SetUniformAll(string name, Matrix4x4 data)
        {
            foreach (Shader s in Shaders)
            {
                s.SetUniform(name, data);
            }
        }

        /// <summary>
        /// Set a uniform Matrix3x3 value on all shaders.
        /// </summary>
        /// <param name="name">The name of the uniform</param>
        /// <param name="data">The data to set</param>
        public static void SetUniformAll(string name, Matrix3x3 data)
        {
            foreach (Shader s in Shaders)
            {
                s.SetUniform(name, data);
            }
        }

        /// <summary>
        /// Set a uniform Vector3 value on all shaders.
        /// </summary>
        /// <param name="name">The name of the uniform</param>
        /// <param name="data">The data to set</param>
        public static void SetUniformAll(string name, Vector3 data)
        {
            foreach (Shader s in Shaders)
            {
                s.SetUniform(name, data);
            }
        }

        /// <summary>
        /// Set a uniform Vector2 value on all shaders.
        /// </summary>
        /// <param name="name">The name of the uniform</param>
        /// <param name="data">The data to set</param>
        public static void SetUniformAll(string name, Vector2 data)
        {
            foreach (Shader s in Shaders)
            {
                s.SetUniform(name, data);
            }
        }

        /// <summary>
        /// Set a uniform Vector4 value on all shaders.
        /// </summary>
        /// <param name="name">The name of the uniform</param>
        /// <param name="data">The data to set</param>
        public static void SetUniformAll(string name, Vector4 data)
        {
            foreach (Shader s in Shaders)
            {
                s.SetUniform(name, data);
            }
        }

        /// <summary>
        /// Set a uniform Quaternion value on all shaders.
        /// </summary>
        /// <param name="name">The name of the uniform</param>
        /// <param name="data">The data to set</param>
        public static void SetUniformAll(string name, Quaternion data)
        {
            foreach (Shader s in Shaders)
            {
                s.SetUniform(name, data);
            }
        }

        #endregion

        #region Uniform Getters

        /// <summary>
        /// Gets the int value for the requested Uniform.
        /// </summary>
        /// <param name="name">The name of the Uniform (Variable) to get</param>
        /// <param name="data">The data stored on the GPU or 0 if the Uniform doesn't exsist.</param>
        public void GetUniform(string name, out int data)
        {
            if (HasUniform(name))
            {
                GL.UseProgram(GLHandle);
                GL.GetUniformiv(GLHandle, uniformLocations[name], out data);
            }
            else
                data = 0;
        }

        /// <summary>
        /// Gets the uint value for the requested Uniform.
        /// </summary>
        /// <param name="name">The name of the Uniform (Variable) to get</param>
        /// <param name="data">The data stored on the GPU or 0 if the Uniform doesn't exsist.</param>
        public void GetUniform(string name, out uint data)
        {
            if (HasUniform(name))
            {
                GL.UseProgram(GLHandle);
                GL.GetUniformuiv(GLHandle, uniformLocations[name], out data);
            }
            else
                data = 0;
        }

        /// <summary>
        /// Gets the float value for the requested Uniform.
        /// </summary>
        /// <param name="name">The name of the Uniform (Variable) to get</param>
        /// <param name="data">The data stored on the GPU or 0 if the Uniform doesn't exsist.</param>
        public void GetUniform(string name, out float data)
        {
            if (HasUniform(name))
            {
                GL.UseProgram(GLHandle);
                GL.GetUniformfv(GLHandle, uniformLocations[name], out data);
            }
            else
                data = 0;
        }

        /// <summary>
        /// Gets the double value for the requested Uniform.
        /// </summary>
        /// <param name="name">The name of the Uniform (Variable) to get</param>
        /// <param name="data">The data stored on the GPU or 0 if the Uniform doesn't exsist.</param>
        public void GetUniform(string name, out double data)
        {
            if (HasUniform(name))
            {
                GL.UseProgram(GLHandle);
                GL.GetUniformdv(GLHandle, uniformLocations[name], out data);
            }
            else
                data = 0;
        }

        /// <summary>
        /// Gets the Matrix4x4 value for the requested Uniform.
        /// </summary>
        /// <param name="name">The name of the Uniform (Variable) to get</param>
        /// <param name="data">The data stored on the GPU or <see cref="Matrix4x4.Identit"/> if the Uniform doesn't exsist.</param>
        public void GetUniform(string name, out Matrix4x4 data)
        {
            if (HasUniform(name))
            {
                //ReadOnlySpan<float> matrices = new ReadOnlySpan<float>(data.ToArray());

                GL.UseProgram(GLHandle);

                float[] floats = new float[16];

                GL.GetUniformfv(GLHandle, uniformLocations[name], out floats[0]);

                if (floats == null || floats.Length < 16)
                {
                    data = Matrix4x4.Identity;
                    return;
                }

                data = new Matrix4x4(
                      floats[ 0], floats[ 1], floats[ 2], floats[ 3]
                    , floats[ 4], floats[ 5], floats[ 6], floats[ 7]
                    , floats[ 8], floats[ 9], floats[10], floats[11]
                    , floats[12], floats[13], floats[14], floats[15]);

            }
            else
                data = Matrix4x4.Identity;
        }

        /// <summary>
        /// Gets the Matrix3x3 value for the requested Uniform.
        /// </summary>
        /// <param name="name">The name of the Uniform (Variable) to get</param>
        /// <param name="data">The data stored on the GPU or <see cref="Matrix3x3.Identit"/> if the Uniform doesn't exsist.</param>
        public void GetUniform(string name, out Matrix3x3 data)
        {
            if (HasUniform(name))
            {
                //ReadOnlySpan<float> matrices = new ReadOnlySpan<float>(data.ToArray());

                GL.UseProgram(GLHandle);

                float[] floats = new float[16];

                GL.GetUniformfv(GLHandle, uniformLocations[name], out floats[0]);

                if (floats == null || floats.Length < 16)
                {
                    data = Matrix3x3.Identity;
                    return;
                }

                data = new Matrix3x3(
                      floats[0], floats[1], floats[2]
                    , floats[3], floats[4], floats[5]
                    , floats[6], floats[7], floats[8]);

            }
            else
                data = Matrix3x3.Identity;
        }

        /// <summary>
        /// Gets the Vector3 value for the requested Uniform.
        /// </summary>
        /// <param name="name">The name of the Uniform (Variable) to get</param>
        /// <param name="data">The data stored on the GPU or <see cref="Vector3.Zero"/> if the Uniform doesn't exsist.</param>
        public void GetUniform(string name, out Vector3 data)
        {
            if (HasUniform(name))
            {
                GL.UseProgram(GLHandle);

                float[] floats = new float[3];
                GL.GetUniformfv(GLHandle, GL.GetUniformLocation(GLHandle, name + "[0]"), out floats[0]);
                //GL.GetUniformfv(GLHandle, GL.GetUniformLocation(GLHandle, name + "[1]"), out floats[1]);
                //GL.GetUniformfv(GLHandle, GL.GetUniformLocation(GLHandle, name + "[2]"), out floats[2]);

                if (floats == null || floats.Length < 3)
                {
                    data = Vector3.Zero;
                    return;
                }

                data = new Vector3(floats[0], floats[1], floats[2]);
            }
            else
                data = Vector3.Zero;
        }

        /// <summary>
        /// Gets the Vector2 value for the requested Uniform.
        /// </summary>
        /// <param name="name">The name of the Uniform (Variable) to get</param>
        /// <param name="data">The data stored on the GPU or <see cref="Vector2.Zero"/> if the Uniform doesn't exsist.</param>
        public void GetUniform(string name, out Vector2 data)
        {

            if (HasUniform(name))
            {
                GL.UseProgram(GLHandle);

                float[] floats = new float[2];
                GL.GetUniformfv(GLHandle, GL.GetUniformLocation(GLHandle, name + "[0]"), out floats[0]);
                //GL.GetUniformfv(GLHandle, GL.GetUniformLocation(GLHandle, name + "[1]"), out floats[1]);
                data = new Vector2(floats[0], floats[1]);
            }
            else
                data = Vector2.Zero;
        }

        /// <summary>
        /// Gets the Vector4 value for the requested Uniform.
        /// </summary>
        /// <param name="name">The name of the Uniform (Variable) to get</param>
        /// <param name="data">The data stored on the GPU or <see cref="Vector4.Zero"/> if the Uniform doesn't exsist.</param>
        public void GetUniform(string name, out Vector4 data)
        {

            if (HasUniform(name))
            {
                GL.UseProgram(GLHandle);

                float[] floats = new float[4];
                GL.GetUniformfv(GLHandle, GL.GetUniformLocation(GLHandle, name + "[0]"), out floats[0]);
                //GL.GetUniformfv(GLHandle, GL.GetUniformLocation(GLHandle, name + "[1]"), out floats[1]);
                //GL.GetUniformfv(GLHandle, GL.GetUniformLocation(GLHandle, name + "[2]"), out floats[2]);
                //GL.GetUniformfv(GLHandle, GL.GetUniformLocation(GLHandle, name + "[3]"), out floats[3]);

                data = new Vector4(floats[0], floats[1], floats[2], floats[3]);
            }
            else
                data = Vector4.Zero;
        }

        /// <summary>
        /// Gets the Quaternion value for the requested Uniform.
        /// </summary>
        /// <param name="name">The name of the Uniform (Variable) to get</param>
        /// <param name="data">The data stored on the GPU or <see cref="Quaternion.Identity"/> if the Uniform doesn't exsist.</param>
        public void GetUniform(string name, out Quaternion data)
        {
            if (HasUniform(name))
            {
                GL.UseProgram(GLHandle);

                float[] floats = new float[4];
                GL.GetUniformfv(GLHandle, GL.GetUniformLocation(GLHandle, name + "[0]"), out floats[0]);
                //GL.GetUniformfv(GLHandle, GL.GetUniformLocation(GLHandle, name + "[1]"), out floats[1]);
                //GL.GetUniformfv(GLHandle, GL.GetUniformLocation(GLHandle, name + "[2]"), out floats[2]);
                //GL.GetUniformfv(GLHandle, GL.GetUniformLocation(GLHandle, name + "[3]"), out floats[3]);

                data = new Quaternion(floats[0], floats[1], floats[2], floats[3]);
            }
            else
                data = Quaternion.Identity;
        }

        #endregion

        /// <summary>
        /// If true then this shader has been released from the GPU.
        /// </summary>
        bool isDisposed = false;

        /// <summary>
        /// Releases the Shader from GPU Memory. 
        /// Any future calls to this shader will crash and burn.
        /// </summary>
        public void Dispose()
        {
            if (isDisposed) return;

            GL.DeleteProgram(GLHandle);
            Shaders.Remove(this);

            isDisposed = true;
        }

        ~Shader()
        {
            Dispose();
        }

    }
}
