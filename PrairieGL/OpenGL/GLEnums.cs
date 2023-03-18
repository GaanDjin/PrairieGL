using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PrairieGL.OpenGL.GLDelegates;

namespace PrairieGL.OpenGL
{
    /// <summary>
    /// Used by glClear to define which buffers should be cleared.
    /// </summary>
    public enum GLColourMasks : uint
    {
        /// <summary>
        /// Indicates the depth buffer.
        /// </summary>
        GL_DEPTH_BUFFER_BIT = 0x00000100,
        /// <summary>
        /// Indicates the stencil buffer.
        /// </summary>
        GL_STENCIL_BUFFER_BIT = 0x00000400,
        /// <summary>
        /// Indicates the buffers currently enabled for color writing.
        /// </summary>
        GL_COLOR_BUFFER_BIT = 0x00004000,
        /// <summary>
        /// Indicates the accumulation buffer.
        /// </summary>
        GL_ACCUM_BUFFER_BIT = 0x00000200
    }

    /// <summary>
    /// Specifies the target to which the buffer object is bound
    /// </summary>
    public enum BufferTargets
    {
        /// <summary>
        /// Vertex attributes
        /// </summary>
        GL_ARRAY_BUFFER = 0x8892,
        /// <summary>
        /// Atomic counter storage
        /// </summary>
        GL_ATOMIC_COUNTER_BUFFER = 0x92C0,
        /// <summary>
        /// Buffer copy source
        /// </summary>
        GL_COPY_READ_BUFFER = 0x8F36,
        /// <summary>
        /// Buffer copy destination
        /// </summary>
        GL_COPY_WRITE_BUFFER = 0x8F37,
        /// <summary>
        /// Indirect compute dispatch commands
        /// </summary>
        GL_DISPATCH_INDIRECT_BUFFER = 0x90EE,
        /// <summary>
        /// Indirect command arguments
        /// </summary>
        GL_DRAW_INDIRECT_BUFFER = 0x8F3F,
        /// <summary>
        /// Vertex array indices
        /// </summary>
        GL_ELEMENT_ARRAY_BUFFER = 0x8893,
        /// <summary>
        /// Pixel read target
        /// </summary>
        GL_PIXEL_PACK_BUFFER = 0x88EB,
        /// <summary>
        /// Texture data source
        /// </summary>
        GL_PIXEL_UNPACK_BUFFER = 0x88EC,
        /// <summary>
        /// Query result buffer
        /// </summary>
        GL_QUERY_BUFFER = 0x9192,
        /// <summary>
        /// Read-write storage for shaders
        /// </summary>
        GL_SHADER_STORAGE_BUFFER = 0x90D2,
        /// <summary>
        ///  Texture data buffer
        /// </summary>
        GL_TEXTURE_BUFFER = 0x8C2A,
        /// <summary>
        ///  Transform feedback buffer
        /// </summary>
        GL_TRANSFORM_FEEDBACK_BUFFER = 0x8C8E,
        /// <summary>
        /// Uniform block storage
        /// </summary>
        GL_UNIFORM_BUFFER = 0x8A11
    }

    /// <summary>
    /// Hints at how a buffer will be used.
    /// </summary>
    public enum BufferUsages
    {
        /// <summary>
        /// The data store contents will be modified once and used at most a few times.
        /// The data store contents are modified by the application, 
        /// and used as the source for GL drawing and image specification commands.
        /// </summary>
        GL_STREAM_DRAW = 0x88E0,
        /// <summary>
        /// The data store contents will be modified once and used at most a few times.
        /// The data store contents are modified by reading data from the GL, 
        /// and used to return that data when queried by the application.
        /// </summary>
        GL_STREAM_READ = 0x88E1,
        /// <summary>
        /// The data store contents will be modified once and used at most a few times.
        /// The data store contents are modified by reading data from the GL, 
        /// and used as the source for GL drawing and image specification commands.
        /// </summary>
        GL_STREAM_COPY = 0x88E2,
        /// <summary>
        /// The data store contents will be modified once and used many times.
        /// The data store contents are modified by the application, 
        /// and used as the source for GL drawing and image specification commands.
        /// </summary>
        GL_STATIC_DRAW = 0x88E4,
        /// <summary>
        /// The data store contents will be modified once and used many times.
        /// The data store contents are modified by reading data from the GL, 
        /// and used to return that data when queried by the application.
        /// </summary>
        GL_STATIC_READ = 0x88E5,
        /// <summary>
        /// The data store contents will be modified once and used many times.
        /// The data store contents are modified by reading data from the GL, 
        /// and used as the source for GL drawing and image specification commands.
        /// </summary>
        GL_STATIC_COPY = 0x88E6,
        /// <summary>
        /// The data store contents will be modified repeatedly and used many times.
        /// The data store contents are modified by the application, 
        /// and used as the source for GL drawing and image specification commands.
        /// </summary>
        GL_DYNAMIC_DRAW = 0x88E8,
        /// <summary>
        /// The data store contents will be modified repeatedly and used many times.
        /// The data store contents are modified by reading data from the GL, 
        /// and used to return that data when queried by the application.
        /// </summary>
        GL_DYNAMIC_READ = 0x88E9,
        /// <summary>
        /// The data store contents will be modified repeatedly and used many times.
        /// The data store contents are modified by reading data from the GL, 
        /// and used as the source for GL drawing and image specification commands.
        /// </summary>
        GL_DYNAMIC_COPY = 0x88EA


    }

    /// <summary>
    /// Defines what format the data being passed is.
    /// </summary>
    public enum GLDataTypes
    {
        /// <summary>
        ///  accepted by glVertexAttribPointer, glVertexAttribPointer and glVertexAttribIPointer.
        /// </summary>
        GL_BYTE = 0x1400,
        /// <summary>
        ///  accepted by glVertexAttribPointer, glVertexAttribPointer and glVertexAttribIPointer.
        /// </summary>
        GL_UNSIGNED_BYTE = 0x1401,
        /// <summary>
        ///  accepted by glVertexAttribPointer, glVertexAttribPointer and glVertexAttribIPointer.
        /// </summary>
        GL_SHORT = 0x1402,
        /// <summary>
        ///  accepted by glVertexAttribPointer, glVertexAttribPointer and glVertexAttribIPointer.
        /// </summary>
        GL_UNSIGNED_SHORT = 0x1403,
        /// <summary>
        ///  accepted by glVertexAttribPointer, glVertexAttribPointer and glVertexAttribIPointer.
        /// </summary>
        GL_INT = 0x1404,
        /// <summary>
        /// accepted by glVertexAttribPointer, glVertexAttribPointer and glVertexAttribIPointer.
        /// </summary>
        GL_UNSIGNED_INT = 0x1405,
        /// <summary>
        /// Accepted by glVertexAttribPointer.
        /// </summary>
        GL_HALF_FLOAT = 0x140B,
        /// <summary>
        /// Accepted by glVertexAttribPointer.
        /// </summary>
        GL_FLOAT = 0x1406,
        /// <summary>
        /// Accepted by glVertexAttribPointer.
        /// The only accepted value by glVertexAttribLPointer. 
        /// </summary>
        GL_DOUBLE = 0x140A,
        /// <summary>
        /// Accepted by glVertexAttribPointer.
        /// </summary>
        GL_FIXED = 0x140C,
        /// <summary>
        /// Accepted by glVertexAttribPointer.
        /// </summary>
        GL_INT_2_10_10_10_REV = 0x8D9F,
        /// <summary>
        /// Accepted by glVertexAttribPointer.
        /// </summary>
        GL_UNSIGNED_INT_2_10_10_10_REV = 0x8368,
        /// <summary>
        /// Accepted by glVertexAttribPointer.
        /// </summary>
        GL_UNSIGNED_INT_10F_11F_11F_REV = 0x8C3B,
        /// <summary>
        /// The only accepted value by glVertexAttribLPointer. 
        /// </summary>

    }

    /// <summary>
    /// Specifies what kind of primitives to render.
    /// <see href="https://www.glprogramming.com/red/images/Image34.gif"/>
    /// </summary>
    public enum RenderModes
    {
        /// <summary>
        /// Draw only the points in the array
        /// </summary>
        GL_POINTS = 0x0000,
        /// <summary>
        /// Draw a continuous line from each point to the next 
        /// </summary>
        GL_LINE_STRIP = 0x0003,
        /// <summary>
        /// Draw a continuous line from each point to the next and 
        /// at the last point draw a line back to the beginning
        /// </summary>
        GL_LINE_LOOP = 0x0002,
        /// <summary>
        /// Draw a line for every 2 points.
        /// So draw a line 
        /// from point 0 to 1 and 
        /// from point 2 to 3 
        /// but not 
        /// from point 1 to 2.
        /// </summary>
        GL_LINES = 0x0001,
        /// <summary>
        /// Draw a continuous line from each point to the next.
        /// Used by Geometry shaders. 
        /// During rendering the first and last line points are not rendered.
        /// </summary>
        GL_LINE_STRIP_ADJACENCY = 0x000B,
        /// <summary>
        /// Used by geometry shaders.
        /// </summary>
        GL_LINES_ADJACENCY = 0x000A,
        /// <summary>
        /// Draw contiguous triangles.
        /// The first 3 points make up a triangle then each point after that 
        /// will use the last two points to make up a trinagle that shares 
        /// one side with the last triangle.
        /// </summary>
        GL_TRIANGLE_STRIP = 0x0005,
        /// <summary>
        /// The first point makes up one corner of each triangle. 
        /// The second point makes up the starting end of a fan and earch 
        /// point after uses the last point and the first point to make up a triangle.
        /// </summary>
        GL_TRIANGLE_FAN = 0x0006,
        /// <summary>
        /// Every 3 points make up a descrete triangle. No points are shared.
        /// </summary>
        GL_TRIANGLES = 0x0004,
        /// <summary>
        /// Used by geometry shaders.
        /// Similar to GL_LINES except 4 points are used for a single line and
        /// only the segment between 1 and 2 are rendered. (Ignoring points 0 and 3)
        /// </summary>
        GL_TRIANGLE_STRIP_ADJACENCY = 0x000D,
        /// <summary>
        /// Used by geometry shaders.
        /// </summary>
        GL_TRIANGLES_ADJACENCY = 0x000C,
        /// <summary>
        /// Used by tessellation.
        /// </summary>
        GL_PATCHES = 0x000E,
        /// <summary>
        /// Every 4 points make up a descrete quad (4 sided polygon). 
        /// No points are shared.
        /// </summary>
        GL_QUADS = 0x0007,
        /// <summary>
        /// he first four points make up a quad followed by every two points 
        /// use the previous two points to make up a quad. 
        /// So every quad shares a side with the last quad. 
        /// </summary>
        GL_QUAD_STRIP = 0x0008,
        /// <summary>
        /// All points make up a single polygon. 
        /// </summary>
        GL_POLYGON = 0x0009,

    }

    /// <summary>
    /// Specifies the type of shader to be created.
    /// </summary>
    public enum ShaderProgramTypes
    {
        /// <summary>
        /// Compute shaders are used to perform parallel operations on the GPU 
        /// without  rendering anything
        /// </summary>
        GL_COMPUTE_SHADER = 0x91B9,
        /// <summary>
        /// Used in the render pipeline to apply effects to verticies
        /// </summary>
        GL_VERTEX_SHADER = 0x8B31,
        /// <summary>
        /// The first step of tessellation is the optional invocation of a 
        /// tessellation control shader (TCS). 
        /// The TCS has two jobs:
        /// 
        /// Determine the amount of tessellation that a primitive should have.
        /// Perform any special transformations on the input patch data.
        /// </summary>
        GL_TESS_CONTROL_SHADER = 0x8E88,
        /// <summary>
        /// The Tessellation Evaluation Shader (TES) is a Shader program 
        /// written in GLSL that takes the results of a Tessellation operation 
        /// and computes the interpolated positions and other per-vertex data 
        /// from them. These values are passed on to the next stage in the
        /// pipeline.
        /// <see href="https://www.khronos.org/opengl/wiki/Tessellation_Evaluation_Shader"/>
        /// </summary>
        GL_TESS_EVALUATION_SHADER = 0x8E87,
        /// <summary>
        /// A Geometry Shader (GS) is a Shader program written in GLSL that 
        /// governs the processing of Primitives. 
        /// Geometry shaders reside between the Vertex Shaders 
        /// (or the optional Tessellation stage) and the fixed-function 
        /// Vertex Post-Processing stage.
        /// <see href="https://www.khronos.org/opengl/wiki/Geometry_Shader"/>
        /// </summary>
        GL_GEOMETRY_SHADER = 0x8DD9,
        /// <summary>
        /// A Fragment Shader is the Shader stage that will process a 
        /// Fragment generated by the Rasterization into a set of colors and 
        /// a single depth value.
        /// 
        /// The fragment shader is the OpenGL pipeline stage after a primitive 
        /// is rasterized. For each sample of the pixels covered by a primitive,
        /// a "fragment" is generated. Each fragment has a Window Space position,
        /// a few other values, and it contains all of the interpolated 
        /// per-vertex output values from the last Vertex Processing stage.
        /// 
        /// The output of a fragment shader is a depth value, a possible stencil
        /// value (unmodified by the fragment shader), and zero or more color 
        /// values to be potentially written to the buffers in the current 
        /// framebuffers.
        /// 
        /// Fragment shaders take a single fragment as input and produce a 
        /// single fragment as output.
        /// <see href="https://www.khronos.org/opengl/wiki/Fragment_Shader"/>
        /// </summary>
        GL_FRAGMENT_SHADER = 0x8B30
    }

    /// <summary>
    /// The value of a parameter for a specific shader object. 
    /// </summary>
    public enum ShaderParameters
    {
        /// <summary>
        /// params returns GL_VERTEX_SHADER if shader is a vertex shader object, GL_GEOMETRY_SHADER if shader is a 
        /// geometry shader object, and GL_FRAGMENT_SHADER if shader is a fragment shader object.
        /// </summary>
        GL_SHADER_TYPE = 0x8B4F,

        /// <summary>
        /// params returns GL_TRUE if shader is currently flagged for deletion, and GL_FALSE otherwise.
        /// </summary>
        GL_DELETE_STATUS = 0x8B80,


        /// <summary>
        /// params returns GL_TRUE if the last compile operation on shader was successful, and GL_FALSE otherwise.
        /// </summary>
        GL_COMPILE_STATUS = 0x8B81,


        /// <summary>
        /// params returns the number of characters in the information log for shader including the 
        /// null termination character (i.e., the size of the character buffer required to store the information log). 
        /// If shader has no information log, a value of 0 is returned.
        /// </summary>
        GL_INFO_LOG_LENGTH = 0x8B84,


        /// <summary>
        /// params returns the length of the concatenation of the source strings that make up the shader source for 
        /// the shader, including the null termination character. 
        /// (i.e., the size of the character buffer required to store the shader source). 
        /// If no source code exists, 0 is returned.
        /// </summary>
        GL_SHADER_SOURCE_LENGTH = 0x8B88,
    }

    /// <summary>
    /// The value of a parameter for a specific program object. 
    /// </summary>
    public enum ProgramParameters
    {
        /// <summary>
        /// params returns GL_TRUE if program is currently flagged for deletion, and GL_FALSE otherwise.
        /// </summary>
        GL_DELETE_STATUS = 0x8B80,


        /// <summary>
        /// params returns GL_TRUE if the last link operation on program was successful, and GL_FALSE otherwise.
        /// </summary>
        GL_LINK_STATUS = 0x8B82,


        /// <summary>
        /// params returns GL_TRUE or if the last validation operation on program was successful, and GL_FALSE otherwise.
        /// </summary>
        GL_VALIDATE_STATUS = 0x8B83,


        /// <summary>
        /// params returns the number of characters in the information log for program including the null termination character (i.e., the size of the character buffer required to store the information log). If program has no information log, a value of 0 is returned.
        /// </summary>
        GL_INFO_LOG_LENGTH = 0x8B84,


        /// <summary>
        /// params returns the number of shader objects attached to program.
        /// </summary>
        GL_ATTACHED_SHADERS = 0x8B85,


        /// <summary>
        /// params returns the number of active attribute atomic counter buffers used by program.
        /// </summary>
        GL_ACTIVE_ATOMIC_COUNTER_BUFFERS = 0x92D9,


        /// <summary>
        /// params returns the number of active attribute variables for program.
        /// </summary>
        GL_ACTIVE_ATTRIBUTES = 0x8B89,


        /// <summary>
        /// params returns the length of the longest active attribute name for program, including the null termination character (i.e., the size of the character buffer required to store the longest attribute name). If no active attributes exist, 0 is returned.
        /// </summary>
        GL_ACTIVE_ATTRIBUTE_MAX_LENGTH = 0x8B8A,


        /// <summary>
        /// params returns the number of active uniform variables for program.
        /// </summary>
        GL_ACTIVE_UNIFORMS = 0x8B86,


        /// <summary>
        /// params returns the length of the longest active uniform variable name for program, including the null termination character (i.e., the size of the character buffer required to store the longest uniform variable name). If no active uniform variables exist, 0 is returned.
        /// </summary>
        GL_ACTIVE_UNIFORM_MAX_LENGTH = 0x8B87,


        /// <summary>
        /// params returns the length of the program binary, in bytes that will be returned by a call to glGetProgramBinary. When a progam's GL_LINK_STATUS is GL_FALSE, its program binary length is zero.
        /// </summary>
        GL_PROGRAM_BINARY_LENGTH = 0x8741,


        /// <summary>
        /// params returns an array of three integers containing the local work group size of the compute program as specified by its input layout qualifier(s). program must be the name of a program object that has been previously linked successfully and contains a binary for the compute shader stage.
        /// </summary>
        GL_COMPUTE_WORK_GROUP_SIZE = 0x8267,


        /// <summary>
        /// params returns a symbolic constant indicating the buffer mode used when transform feedback is active. This may be GL_SEPARATE_ATTRIBS or GL_INTERLEAVED_ATTRIBS.
        /// </summary>
        GL_TRANSFORM_FEEDBACK_BUFFER_MODE = 0x8C7F,


        /// <summary>
        /// params returns the number of varying variables to capture in transform feedback mode for the program.
        /// </summary>
        GL_TRANSFORM_FEEDBACK_VARYINGS = 0x8C83,


        /// <summary>
        /// params returns the length of the longest variable name to be used for transform feedback, including the null-terminator.
        /// </summary>
        GL_TRANSFORM_FEEDBACK_VARYING_MAX_LENGTH = 0x8C76,


        /// <summary>
        /// params returns the maximum number of vertices that the geometry shader in program will output.
        /// </summary>
        GL_GEOMETRY_VERTICES_OUT = 0x8916,


        /// <summary>
        /// params returns a symbolic constant indicating the primitive type accepted as input to the geometry shader contained in program.
        /// </summary>
        GL_GEOMETRY_INPUT_TYPE = 0x8917,


        /// <summary>
        /// params returns a symbolic constant indicating the primitive type that will be output by the geometry shader contained in program.
        /// </summary>
        GL_GEOMETRY_OUTPUT_TYPE = 0x8918,
    }

    /// <summary>
    /// Use glIsEnabled or glGet to determine the current setting of any capability. 
    /// The initial value for each capability with the exception of GL_DITHER and GL_MULTISAMPLE is GL_FALSE. 
    /// The initial value for GL_DITHER and GL_MULTISAMPLE is GL_TRUE.
    /// </summary>
    public enum GLCapabilities
    {
        /// <summary>
        /// If enabled, blend the computed fragment color values with the values in the color buffers. See glBlendFunc.
        /// </summary>
        GL_BLEND = 0x0BE2,
        /// <summary>
        /// If enabled, clip geometry against user-defined half space 0.
        /// </summary>
        GL_CLIP_DISTANCE0 = 0x3000,
        /// <summary>
        /// If enabled, clip geometry against user-defined half space 1.
        /// </summary>
        GL_CLIP_DISTANCE1 = 0x3001,
        /// <summary>
        /// If enabled, clip geometry against user-defined half space 2.
        /// </summary>
        GL_CLIP_DISTANCE2 = 0x3002,
        /// <summary>
        /// If enabled, clip geometry against user-defined half space 3.
        /// </summary>
        GL_CLIP_DISTANCE3 = 0x3003,
        /// <summary>
        /// If enabled, clip geometry against user-defined half space 4.
        /// </summary>
        GL_CLIP_DISTANCE4 = 0x3004,
        /// <summary>
        /// If enabled, clip geometry against user-defined half space 5.
        /// </summary>
        GL_CLIP_DISTANCE5 = 0x3005,
        /// <summary>
        /// If enabled, clip geometry against user-defined half space 6.
        /// </summary>
        GL_CLIP_DISTANCE6 = 0x3006,
        /// <summary>
        /// If enabled, clip geometry against user-defined half space 7.
        /// </summary>
        GL_CLIP_DISTANCE7 = 0x3007,

        /// <summary>
        /// If enabled, apply the currently selected logical operation to the computed fragment color and color buffer values. See glLogicOp.
        /// </summary>
        GL_COLOR_LOGIC_OP = 0x0BF2,

        /// <summary>
        /// If enabled, cull polygons based on their winding in window coordinates. See glCullFace.
        /// </summary>
        GL_CULL_FACE = 0x0B44,

        /// <summary>
        /// If enabled, debug messages are produced by a debug context. 
        /// When disabled, the debug message log is silenced. 
        /// Note that in a non-debug context, very few, if any messages might be produced, even when GL_DEBUG_OUTPUT is enabled.
        /// </summary>
        GL_DEBUG_OUTPUT = 0x92E0,

        /// <summary>
        /// If enabled, debug messages are produced synchronously by a debug context. 
        /// If disabled, debug messages may be produced asynchronously. 
        /// In particular, they may be delayed relative to the execution of GL commands, 
        /// and the debug callback function may be called from a thread other than that in which the commands are executed. 
        /// See glDebugMessageCallback.
        /// </summary>
        GL_DEBUG_OUTPUT_SYNCHRONOUS = 0x8242,

        /// <summary>
        /// If enabled, the −wc≤zc≤wc plane equation is ignored by view volume clipping 
        /// (effectively, there is no near or far plane clipping). See glDepthRange.
        /// </summary>
        GL_DEPTH_CLAMP = 0x864F,

        /// <summary>
        /// If enabled, do depth comparisons and update the depth buffer. 
        /// Note that even if the depth buffer exists and the depth mask is non-zero, 
        /// the depth buffer is not updated if the depth test is disabled. See glDepthFunc and glDepthRange.
        /// </summary>
        GL_DEPTH_TEST = 0x0B71,

        /// <summary>
        /// If enabled, dither color components or indices before they are written to the color buffer.
        /// </summary>
        GL_DITHER = 0x0BD0,

        /// <summary>
        /// If enabled and the value of GL_FRAMEBUFFER_ATTACHMENT_COLOR_ENCODING for the framebuffer attachment 
        /// corresponding to the destination buffer is GL_SRGB, the R, G, and B destination color values 
        /// (after conversion from fixed-point to floating-point) are considered to be encoded for the sRGB color space 
        /// and hence are linearized prior to their use in blending.
        /// </summary>
        GL_FRAMEBUFFER_SRGB = 0x8DB9,

        /// <summary>
        /// If enabled, draw lines with correct filtering. Otherwise, draw aliased lines. See glLineWidth.
        /// </summary>
        GL_LINE_SMOOTH = 0x0B20,

        /// <summary>
        /// If enabled, use multiple fragment samples in computing the final color of a pixel. See glSampleCoverage.
        /// </summary>
        GL_MULTISAMPLE = 0x809D,

        /// <summary>
        /// If enabled, and if the polygon is rendered in GL_FILL mode, an offset is added to depth values of a polygon's 
        /// fragments before the depth comparison is performed. See glPolygonOffset.
        /// </summary>
        GL_POLYGON_OFFSET_FILL = 0x8037,

        /// <summary>
        /// If enabled, and if the polygon is rendered in GL_LINE mode, an offset is added to depth values of a polygon's
        /// fragments before the depth comparison is performed. See glPolygonOffset.
        /// </summary>
        GL_POLYGON_OFFSET_LINE = 0x2A02,

        /// <summary>
        /// If enabled, an offset is added to depth values of a polygon's fragments before the depth comparison is performed, 
        /// if the polygon is rendered in GL_POINT mode. See glPolygonOffset.
        /// </summary>
        GL_POLYGON_OFFSET_POINT = 0x2A01,

        /// <summary>
        /// If enabled, draw polygons with proper filtering. Otherwise, draw aliased polygons. For correct antialiased polygons, 
        /// an alpha buffer is needed and the polygons must be sorted front to back.
        /// </summary>
        GL_POLYGON_SMOOTH = 0x0B41,

        /// <summary>
        /// Enables primitive restarting. If enabled, any one of the draw commands which transfers a set of generic
        /// attribute array elements to the GL will restart the primitive when the index of the vertex is equal 
        /// to the primitive restart index. See glPrimitiveRestartIndex.
        /// </summary>
        GL_PRIMITIVE_RESTART = 0x8F9D,

        /// <summary>
        /// Enables primitive restarting with a fixed index. If enabled, any one of the draw commands which transfers 
        /// a set of generic attribute array elements to the GL will restart the primitive when the index of the vertex 
        /// is equal to the fixed primitive index for the specified index type. 
        /// The fixed index is equal to 2n−1 where n is equal to 8 for GL_UNSIGNED_BYTE, 
        /// 16 for GL_UNSIGNED_SHORT and 32 for GL_UNSIGNED_INT.
        /// </summary>
        GL_PRIMITIVE_RESTART_FIXED_INDEX = 0x8D69,

        /// <summary>
        /// If enabled, primitives are discarded after the optional transform feedback stage, but before rasterization.
        /// Furthermore, when enabled, glClear, glClearBufferData, glClearBufferSubData, glClearTexImage, and glClearTexSubImage 
        /// are ignored.
        /// </summary>
        GL_RASTERIZER_DISCARD = 0x8C89,

        /// <summary>
        /// If enabled, compute a temporary coverage value where each bit is determined by the alpha value at the 
        /// corresponding sample location. The temporary coverage value is then ANDed with the fragment coverage value.
        /// </summary>
        GL_SAMPLE_ALPHA_TO_COVERAGE = 0x809E,


        /// <summary>
        /// If enabled, each sample alpha value is replaced by the maximum representable alpha value.
        /// </summary>
        GL_SAMPLE_ALPHA_TO_ONE = 0x809F,


        /// <summary>
        /// If enabled, the fragment's coverage is ANDed with the temporary coverage value. 
        /// If GL_SAMPLE_COVERAGE_INVERT is set to GL_TRUE, invert the coverage value. See glSampleCoverage.
        /// </summary>
        GL_SAMPLE_COVERAGE = 0x80A0,


        /// <summary>
        /// If enabled, the active fragment shader is run once for each covered sample, or at fraction of this rate as
        /// determined by the current value of GL_MIN_SAMPLE_SHADING_VALUE. See glMinSampleShading.
        /// </summary>
        GL_SAMPLE_SHADING = 0x8C36,


        /// <summary>
        /// If enabled, the sample coverage mask generated for a fragment during rasterization will be ANDed with the value of 
        /// GL_SAMPLE_MASK_VALUE before shading occurs. See glSampleMaski.
        /// </summary>
        GL_SAMPLE_MASK = 0x8E51,


        /// <summary>
        ///  If enabled, discard fragments that are outside the scissor rectangle. See glScissor.
        /// </summary>
        GL_SCISSOR_TEST = 0x0C11,


        /// <summary>
        /// If enabled, do stencil testing and update the stencil buffer. See glStencilFunc and glStencilOp.
        /// </summary>
        GL_STENCIL_TEST = 0x0B90,


        /// <summary>
        /// If enabled, cubemap textures are sampled such that when linearly sampling from the border between two adjacent faces,
        /// texels from both faces are used to generate the final sample value. 
        /// When disabled, texels from only a single face are used to construct the final sample value.
        /// </summary>
        GL_TEXTURE_CUBE_MAP_SEAMLESS = 0x884F,


        /// <summary>
        /// If enabled and a vertex or geometry shader is active, then the derived point size is taken from the 
        /// (potentially clipped) shader builtin gl_PointSize and clamped to the implementation-dependent point size range.
        /// </summary>
        GL_PROGRAM_POINT_SIZE = 0x8642,


        /* Extensions Check for compatible (GL.HasExtenstion) before use! */

        GL_DEBUG_OUTPUT_SYNCHRONOUS_ARB = 0x8242
    }

    /// <summary>
    /// How depth level Comparisons should be performed
    /// </summary>
    public enum GLComparisonFunctions
    {
        /// <summary>
        /// Never passes.
        /// </summary>
        GL_NEVER = 0x0200,

        /// <summary>
        /// Passes if the incoming depth value is less than the stored depth value.
        /// </summary>
        GL_LESS = 0x0201,

        /// <summary>
        /// Passes if the incoming depth value is equal to the stored depth value.
        /// </summary>
        GL_EQUAL = 0x0202,

        /// <summary>
        /// Passes if the incoming depth value is less than or equal to the stored depth value.
        /// </summary>
        GL_LEQUAL = 0x0203,

        /// <summary>
        /// Passes if the incoming depth value is greater than the stored depth value.
        /// </summary>
        GL_GREATER = 0x0204,

        /// <summary>
        /// Passes if the incoming depth value is not equal to the stored depth value.
        /// </summary>
        GL_NOTEQUAL = 0x0205,

        /// <summary>
        /// Passes if the incoming depth value is greater than or equal to the stored depth value.
        /// </summary>
        GL_GEQUAL = 0x0206,

        /// <summary>
        /// Always passes.
        /// </summary>
        GL_ALWAYS = 0x0207

    }

    /// <summary>
    /// The ID to assign the active texture to.
    /// Like telling OpenGL which texture to use for the next texture operations.
    /// </summary>
    public enum TextureUnits
    {
        GL_TEXTURE0 = 0x84C0,
        GL_TEXTURE1 = 0x84C1,
        GL_TEXTURE2 = 0x84C2,
        GL_TEXTURE3 = 0x84C3,
        GL_TEXTURE4 = 0x84C4,
        GL_TEXTURE5 = 0x84C5,
        GL_TEXTURE6 = 0x84C6,
        GL_TEXTURE7 = 0x84C7,
        GL_TEXTURE8 = 0x84C8,
        GL_TEXTURE9 = 0x84C9,
        GL_TEXTURE10 = 0x84CA,
        GL_TEXTURE11 = 0x84CB,
        GL_TEXTURE12 = 0x84CC,
        GL_TEXTURE13 = 0x84CD,
        GL_TEXTURE14 = 0x84CE,
        GL_TEXTURE15 = 0x84CF,
        GL_TEXTURE16 = 0x84D0,
        GL_TEXTURE17 = 0x84D1,
        GL_TEXTURE18 = 0x84D2,
        GL_TEXTURE19 = 0x84D3,
        GL_TEXTURE20 = 0x84D4,
        GL_TEXTURE21 = 0x84D5,
        GL_TEXTURE22 = 0x84D6,
        GL_TEXTURE23 = 0x84D7,
        GL_TEXTURE24 = 0x84D8,
        GL_TEXTURE25 = 0x84D9,
        GL_TEXTURE26 = 0x84DA,
        GL_TEXTURE27 = 0x84DB,
        GL_TEXTURE28 = 0x84DC,
        GL_TEXTURE29 = 0x84DD,
        GL_TEXTURE30 = 0x84DE,
        GL_TEXTURE31 = 0x84DF,
        GL_ACTIVE_TEXTURE = 0x84E0
    }

    /// <summary>
    /// Specifies the target to which the texture is bound for texture functions.
    /// What type of texture are we looking at.
    /// </summary>
    public enum TextureTargets
    {
        GL_TEXTURE_1D = 0x0DE0,
        GL_TEXTURE_2D = 0x0DE1,
        GL_TEXTURE_3D = 0x806F,
        GL_TEXTURE_1D_ARRAY = 0x8C18,
        GL_TEXTURE_2D_ARRAY = 0x8C1A,
        GL_TEXTURE_RECTANGLE = 0x84F5,
        GL_TEXTURE_CUBE_MAP = 0x8513,
        GL_TEXTURE_CUBE_MAP_ARRAY = 0x9009,
        GL_TEXTURE_BUFFER = 0x8C2A,
        GL_TEXTURE_2D_MULTISAMPLE = 0x9100,
        GL_TEXTURE_2D_MULTISAMPLE_ARRAY = 0x9102,

        GL_PROXY_TEXTURE_2D = 0x8064,
        GL_PROXY_TEXTURE_1D_ARRAY = 0x8C19,
        GL_PROXY_TEXTURE_RECTANGLE = 0x84F7,
        GL_TEXTURE_CUBE_MAP_POSITIVE_X = 0x8515,
        GL_TEXTURE_CUBE_MAP_NEGATIVE_X = 0x8516,
        GL_TEXTURE_CUBE_MAP_POSITIVE_Y = 0x8517,
        GL_TEXTURE_CUBE_MAP_NEGATIVE_Y = 0x8518,
        GL_TEXTURE_CUBE_MAP_POSITIVE_Z = 0x8519,
        GL_TEXTURE_CUBE_MAP_NEGATIVE_Z = 0x851A,
        GL_PROXY_TEXTURE_CUBE_MAP = 0x851B
    }

    /// <summary>
    /// Specifies the format of the pixel data.
    /// </summary>
    public enum ImagePixelFormats
    {
        GL_RED = 0x1903,
        GL_RG = 0x8227,
        GL_RGB = 0x1907,
        GL_BGR = 0x80E0,
        GL_RGBA = 0x1908,
        GL_BGRA = 0x80E1,
        GL_RED_INTEGER = 0x8D94,
        GL_RG_INTEGER = 0x8228,
        GL_RGB_INTEGER = 0x8D98,
        GL_BGR_INTEGER = 0x8D9A,
        GL_RGBA_INTEGER = 0x8D99,
        GL_BGRA_INTEGER = 0x8D9B,
        GL_STENCIL_INDEX = 0x1901,
        GL_DEPTH_COMPONENT = 0x1902,
        GL_DEPTH_STENCIL = 0x84F9
    }

    /// <summary>
    /// Specifies the data type of the pixel data.
    /// </summary>
    public enum ImagePixelDataTypes
    {
        GL_UNSIGNED_BYTE = 0x1401,
        GL_BYTE = 0x1400,
        GL_UNSIGNED_SHORT = 0x1403,
        GL_SHORT = 0x1402,
        GL_UNSIGNED_INT = 0x1405,
        GL_INT = 0x1404,
        GL_HALF_FLOAT = 0x140B,
        GL_FLOAT = 0x1406,
        GL_UNSIGNED_BYTE_3_3_2 = 0x8032,
        GL_UNSIGNED_BYTE_2_3_3_REV = 0x8362,
        GL_UNSIGNED_SHORT_5_6_5 = 0x8363,
        GL_UNSIGNED_SHORT_5_6_5_REV = 0x8364,
        GL_UNSIGNED_SHORT_4_4_4_4 = 0x8033,
        GL_UNSIGNED_SHORT_4_4_4_4_REV = 0x8365,
        GL_UNSIGNED_SHORT_5_5_5_1 = 0x8034,
        GL_UNSIGNED_SHORT_1_5_5_5_REV = 0x8366,
        GL_UNSIGNED_INT_8_8_8_8 = 0x8035,
        GL_UNSIGNED_INT_8_8_8_8_REV = 0x8367,
        GL_UNSIGNED_INT_10_10_10_2 = 0x8036,
        GL_UNSIGNED_INT_2_10_10_10_REV = 0x8368
    }

    /// <summary>
    /// Tells glTexParameter and glTextureParameter to assign the value or 
    /// values in params to the texture parameter specified as pname.
    /// </summary>
    public enum TextureParameters
    {
        /// <summary>
        /// Specifies the mode used to read from depth-stencil format textures.
        /// params must be one of GL_DEPTH_COMPONENT or GL_STENCIL_INDEX. 
        /// If the depth stencil mode is GL_DEPTH_COMPONENT, then reads from 
        /// depth-stencil format textures will return the depth component of 
        /// the texel in Rt and the stencil component will be discarded. 
        /// If the depth stencil mode is GL_STENCIL_INDEX then the stencil 
        /// component is returned in Rt and the depth component is discarded. 
        /// The initial value is GL_DEPTH_COMPONENT.
        /// </summary>
        GL_DEPTH_STENCIL_TEXTURE_MODE = 0x90EA,
        /// <summary>
        /// Specifies the index of the lowest defined mipmap level. 
        /// This is an integer value. The initial value is 0.
        /// </summary>
        GL_TEXTURE_BASE_LEVEL = 0x813C,
        /// <summary>
        /// Specifies the comparison operator used when 
        /// GL_TEXTURE_COMPARE_MODE is set to GL_COMPARE_REF_TO_TEXTURE. 
        /// </summary>
        GL_TEXTURE_COMPARE_FUNC = 0x884D,
        /// <summary>
        /// Specifies the texture comparison mode for currently bound depth 
        /// textures. That is, a texture whose internal format is 
        /// GL_DEPTH_COMPONENT_*; see glTexImage2D) 
        /// </summary>
        GL_TEXTURE_COMPARE_MODE = 0x884C,
        /// <summary>
        /// params specifies a fixed bias value that is to be added to the 
        /// level-of-detail parameter for the texture before texture sampling. 
        /// The specified value is added to the shader-supplied bias value 
        /// (if any) and subsequently clamped into the implementation-defined 
        /// range [−biasmax,biasmax], where biasmax is the value of the 
        /// implementation defined constant GL_MAX_TEXTURE_LOD_BIAS. 
        /// The initial value is 0.0.
        /// </summary>
        GL_TEXTURE_LOD_BIAS = 0x8501,
        /// <summary>
        /// The texture minifying function is used whenever the level-of-detail 
        /// function used when sampling from the texture determines that the texture 
        /// should be minified. There are six defined minifying functions. 
        /// Two of them use either the nearest texture elements or a weighted 
        /// average of multiple texture elements to compute the texture value. 
        /// The other four use mipmaps.
        /// </summary>
        GL_TEXTURE_MIN_FILTER = 0x2801,
        /// <summary>
        /// The texture magnification function is used whenever the level-of-detail 
        /// function used when sampling from the texture determines that the texture 
        /// should be magified. It sets the texture magnification function to either
        /// GL_NEAREST or GL_LINEAR (see below). GL_NEAREST is generally faster 
        /// than GL_LINEAR, but it can produce textured images with sharper edges 
        /// because the transition between texture elements is not as smooth. 
        /// The initial value of GL_TEXTURE_MAG_FILTER is GL_LINEAR.
        /// </summary>
        GL_TEXTURE_MAG_FILTER = 0x2800,
        /// <summary>
        /// Sets the minimum level-of-detail parameter. 
        /// This floating-point value limits the selection of highest resolution 
        /// mipmap (lowest mipmap level).
        /// The initial value is -1000.
        /// </summary>
        GL_TEXTURE_MIN_LOD = 0x813A,
        /// <summary>
        /// Sets the maximum level-of-detail parameter. 
        /// This floating-point value limits the selection of the lowest 
        /// resolution mipmap (highest mipmap level). 
        /// The initial value is 1000.
        /// </summary>
        GL_TEXTURE_MAX_LOD = 0x813B,
        /// <summary>
        /// Sets the index of the highest defined mipmap level. 
        /// This is an integer value. 
        /// The initial value is 1000.
        /// </summary>
        GL_TEXTURE_MAX_LEVEL = 0x813D,
        /// <summary>
        /// Sets the swizzle that will be applied to the r component of a 
        /// texel before it is returned to the shader. 
        /// Valid values for param are GL_RED, GL_GREEN, GL_BLUE, GL_ALPHA, 
        /// GL_ZERO and GL_ONE. 
        /// If GL_TEXTURE_SWIZZLE_R is GL_RED, the value for r will be 
        /// taken from the first channel of the fetched texel. 
        /// If GL_TEXTURE_SWIZZLE_R is GL_GREEN, the value for r will be 
        /// taken from the second channel of the fetched texel. 
        /// If GL_TEXTURE_SWIZZLE_R is GL_BLUE, the value for r will be 
        /// taken from the third channel of the fetched texel. 
        /// If GL_TEXTURE_SWIZZLE_R is GL_ALPHA, the value for r will be 
        /// taken from the fourth channel of the fetched texel. 
        /// If GL_TEXTURE_SWIZZLE_R is GL_ZERO, the value for r will be 
        /// subtituted with 0.0.
        /// If GL_TEXTURE_SWIZZLE_R is GL_ONE, the value for r will be 
        /// subtituted with 1.0. 
        /// The initial value is GL_RED.
        /// </summary>
        GL_TEXTURE_SWIZZLE_R = 0x8E42,
        /// <summary>
        /// Sets the swizzle that will be applied to the g component of a 
        /// texel before it is returned to the shader. Valid values for param 
        /// and their effects are similar to those of GL_TEXTURE_SWIZZLE_R. 
        /// The initial value is GL_GREEN.
        /// </summary>
        GL_TEXTURE_SWIZZLE_G = 0x8E43,
        /// <summary>
        /// Sets the swizzle that will be applied to the b component of a 
        /// texel before it is returned to the shader. Valid values for param 
        /// and their effects are similar to those of GL_TEXTURE_SWIZZLE_R. 
        /// The initial value is GL_BLUE.
        /// </summary>
        GL_TEXTURE_SWIZZLE_B = 0x8E44,
        /// <summary>
        /// Sets the swizzle that will be applied to the a component of a 
        /// texel before it is returned to the shader. Valid values for param 
        /// and their effects are similar to those of GL_TEXTURE_SWIZZLE_R. 
        /// The initial value is GL_ALPHA.
        /// </summary>
        GL_TEXTURE_SWIZZLE_A = 0x8E45,
        /// <summary>
        /// Sets the wrap parameter for texture coordinate s to either 
        /// GL_CLAMP_TO_EDGE, GL_CLAMP_TO_BORDER, GL_MIRRORED_REPEAT, 
        /// GL_REPEAT, or GL_MIRROR_CLAMP_TO_EDGE. GL_CLAMP_TO_EDGE 
        /// causes s coordinates to be clamped to the range [12N,1−12N], 
        /// where N is the size of the texture in the direction of clamping.
        /// GL_CLAMP_TO_BORDER evaluates s coordinates in a similar manner 
        /// to GL_CLAMP_TO_EDGE. However, in cases where clamping would 
        /// have occurred in GL_CLAMP_TO_EDGE mode, the fetched texel 
        /// data is substituted with the values specified by 
        /// GL_TEXTURE_BORDER_COLOR. GL_REPEAT causes the integer part of 
        /// the s coordinate to be ignored; the GL uses only the fractional 
        /// part, thereby creating a repeating pattern. 
        /// GL_MIRRORED_REPEAT causes the s coordinate to be set to the 
        /// fractional part of the texture coordinate if the integer part 
        /// of s is even; if the integer part of s is odd, then the s 
        /// texture coordinate is set to 1−frac(s), where frac(s) represents
        /// the fractional part of s. 
        /// GL_MIRROR_CLAMP_TO_EDGE causes the s coordinate to be repeated 
        /// as for GL_MIRRORED_REPEAT for one repetition of the texture, 
        /// at which point the coordinate to be clamped as in GL_CLAMP_TO_EDGE. 
        /// Initially, GL_TEXTURE_WRAP_S is set to GL_REPEAT.
        /// </summary>
        GL_TEXTURE_WRAP_S = 0x2802,
        /// <summary>
        /// Sets the wrap parameter for texture coordinate t to either
        /// GL_CLAMP_TO_EDGE, GL_CLAMP_TO_BORDER, GL_MIRRORED_REPEAT, 
        /// GL_REPEAT, or GL_MIRROR_CLAMP_TO_EDGE. See the discussion 
        /// under GL_TEXTURE_WRAP_S. 
        /// Initially, GL_TEXTURE_WRAP_T is set to GL_REPEAT.
        /// </summary>
        GL_TEXTURE_WRAP_T = 0x2803,
        /// <summary>
        /// Sets the wrap parameter for texture coordinate r to either 
        /// GL_CLAMP_TO_EDGE, GL_CLAMP_TO_BORDER, GL_MIRRORED_REPEAT, 
        /// GL_REPEAT, or GL_MIRROR_CLAMP_TO_EDGE. See the discussion 
        /// under GL_TEXTURE_WRAP_S. 
        /// Initially, GL_TEXTURE_WRAP_R is set to GL_REPEAT.
        /// </summary>
        GL_TEXTURE_WRAP_R = 0x8072,
        /// <summary>
        /// The data in params specifies four values that define the border 
        /// values that should be used for border texels. If a texel is 
        /// sampled from the border of the texture, the values of 
        /// GL_TEXTURE_BORDER_COLOR are interpreted as an RGBA color to match 
        /// the texture's internal format and substituted for the non-existent 
        /// texel data. If the texture contains depth components, the first 
        /// component of GL_TEXTURE_BORDER_COLOR is interpreted as a depth value.
        /// The initial value is (0.0,0.0,0.0,0.0).
        /// 
        /// If the values for GL_TEXTURE_BORDER_COLOR are specified with 
        /// glTexParameterIiv or glTexParameterIuiv, the values are stored 
        /// unmodified with an internal data type of integer.
        /// If specified with glTexParameteriv, they are converted to floating
        /// point with the following equation: f= ((2*c+1)/(pow(2,b)−1)). If specified with
        /// glTexParameterfv, they are stored unmodified as floating-point 
        /// values.
        /// </summary>
        GL_TEXTURE_BORDER_COLOR = 0x1004,
        /// <summary>
        /// Sets the swizzles that will be applied to the r, g, b, and a 
        /// components of a texel before they are returned to the shader. 
        /// Valid values for params and their effects are similar to those
        /// of GL_TEXTURE_SWIZZLE_R, except that all channels are specified 
        /// simultaneously. Setting the value of GL_TEXTURE_SWIZZLE_RGBA is 
        /// equivalent (assuming no errors are generated) to setting the 
        /// parameters of each of GL_TEXTURE_SWIZZLE_R, GL_TEXTURE_SWIZZLE_G,
        /// GL_TEXTURE_SWIZZLE_B, and GL_TEXTURE_SWIZZLE_A successively.
        /// </summary>
        GL_TEXTURE_SWIZZLE_RGBA = 0x8E46
    }

    /// <summary>
    /// See possible combinations at: glTexParameter  
    /// <see href="https://registry.khronos.org/OpenGL-Refpages/gl4/"/>
    /// </summary>
    public enum TextureParameterValues
    {
        /// <summary>
        /// Each element is a single depth value. 
        /// The GL converts it to floating point and clamps to the range [0,1].
        /// </summary>
        GL_DEPTH_COMPONENT = 0x1902,
        GL_STENCIL_INDEX = 0x1901,
        GL_LEQUAL = 0x0203,
        GL_GEQUAL = 0x0206,
        GL_LESS = 0x0201,
        GL_GREATER = 0x0204,
        GL_EQUAL = 0x0202,
        GL_NOTEQUAL = 0x0205,
        GL_ALWAYS = 0x0207,
        GL_NEVER = 0x0200,
        GL_COMPARE_REF_TO_TEXTURE = 0x884E,
        GL_NONE = 0,
        GL_NEAREST = 0x2600,
        GL_LINEAR = 0x2601,
        GL_NEAREST_MIPMAP_NEAREST = 0x2700,
        GL_LINEAR_MIPMAP_NEAREST = 0x2701,
        GL_NEAREST_MIPMAP_LINEAR = 0x2702,
        GL_LINEAR_MIPMAP_LINEAR = 0x2703,
        GL_RED = 0x1903,
        GL_GREEN = 0x1904,
        GL_BLUE = 0x1905,
        GL_ALPHA = 0x1906,
        GL_ZERO = 0,
        GL_ONE = 1,
        GL_CLAMP_TO_EDGE = 0x812F,
        GL_CLAMP_TO_BORDER = 0x812D,
        GL_MIRRORED_REPEAT = 0x8370,
        GL_REPEAT = 0x2901,
        GL_MIRROR_CLAMP_TO_EDGE = 0x8743,

    }

    public enum PixelPackingFormats
    {
        /// <summary>
        /// If true, byte ordering for multibyte color components, depth components, or stencil indices is reversed. 
        /// That is, if a four-byte component consists of bytes b0, b1, b2, b3, it is stored in memory as 
        /// b3, b2, b1, b0 if GL_PACK_SWAP_BYTES is true. 
        /// GL_PACK_SWAP_BYTES has no effect on the memory order of components within a pixel, only on the order of
        /// bytes within components or indices. For example, the three components of a GL_RGB format pixel are always 
        /// stored with red first, green second, and blue third, regardless of the value of GL_PACK_SWAP_BYTES.
        /// </summary>
        GL_PACK_SWAP_BYTES = 0x0D00,
        /// <summary>
        /// If true, bits are ordered within a byte from least significant to most significant; 
        /// otherwise, the first bit in each byte is the most significant one.
        /// </summary>
        GL_PACK_LSB_FIRST = 0x0D01,
        /// <summary>
        /// If greater than 0, GL_PACK_ROW_LENGTH defines the number of pixels in a row.
        /// If the first pixel of a row is placed at location p in memory, 
        /// then the location of the first pixel of the next row is obtained by skipping components or indices, 
        /// where 
        /// n is the number of components or indices in a pixel, 
        /// l is the number of pixels in a row (GL_PACK_ROW_LENGTH if it is greater than 0, the width argument 
        ///     to the pixel routine otherwise), 
        /// a is the value of GL_PACK_ALIGNMENT, and s is the size, in bytes, of a single component 
        /// (if a<s, then it is as if a=s). 
        /// In the case of 1-bit values, the location of the next row is obtained by skipping components or indices.
///
/// The word component in this description refers to the nonindex values red, green, blue, alpha, and depth.
/// Storage format GL_RGB, for example, has three components per pixel: first red, then green, and finally blue.
        /// 
        /// SEE the OpenGL Online Docs!
        /// </summary>
        GL_PACK_ROW_LENGTH = 0x0D02,
        /// <summary>
        /// 
        /// </summary>
        GL_PACK_IMAGE_HEIGHT = 0x806C,
        GL_PACK_SKIP_PIXELS = 0x0D04,
        GL_PACK_SKIP_ROWS = 0x0D03,
        GL_PACK_SKIP_IMAGES = 0x806B,
        GL_PACK_ALIGNMENT = 0x0D05,
        GL_UNPACK_SWAP_BYTES = 0x0CF0,
        GL_UNPACK_LSB_FIRST = 0x0CF1,
        GL_UNPACK_ROW_LENGTH = 0x0CF2,
        GL_UNPACK_IMAGE_HEIGHT = 0x806E,
        GL_UNPACK_SKIP_PIXELS = 0x0CF4,
        GL_UNPACK_SKIP_ROWS = 0x0CF3,
        GL_UNPACK_SKIP_IMAGES = 0x806D,
        GL_UNPACK_ALIGNMENT = 0x0CF5
    }

    /// <summary>
    /// Specifies the number of color components in the texture.
    /// </summary>
    public enum CompressedTextureImageFormats
    {
        GL_COMPRESSED_RED_RGTC1 = 0x8DBB,
        GL_COMPRESSED_SIGNED_RED_RGTC1,
        GL_COMPRESSED_RG_RGTC2 = 0x8DBC,
        GL_COMPRESSED_SIGNED_RG_RGTC2 = 0x8DBE,
        GL_COMPRESSED_RGBA_BPTC_UNORM = 0x8E8C,
        GL_COMPRESSED_SRGB_ALPHA_BPTC_UNORM = 0x8E8D,
        GL_COMPRESSED_RGB_BPTC_SIGNED_FLOAT = 0x8E8E,
        GL_COMPRESSED_RGB_BPTC_UNSIGNED_FLOAT = 0x8E8F,
        GL_COMPRESSED_RGB8_ETC2 = 0x9274,
        GL_COMPRESSED_SRGB8_ETC2 = 0x9275,
        GL_COMPRESSED_RGB8_PUNCHTHROUGH_ALPHA1_ETC2 = 0x9276,
        GL_COMPRESSED_SRGB8_PUNCHTHROUGH_ALPHA1_ETC2 = 0x9277,
        GL_COMPRESSED_RGBA8_ETC2_EAC = 0x9278,
        GL_COMPRESSED_SRGB8_ALPHA8_ETC2_EAC = 0x9279,
        GL_COMPRESSED_R11_EAC = 0x9270,
        GL_COMPRESSED_SIGNED_R11_EAC = 0x9271,
        GL_COMPRESSED_RG11_EAC = 0x9272,
        GL_COMPRESSED_SIGNED_RG11_EAC = 0x9273,
        GL_COMPRESSED_RGB_S3TC_DXT1_EXT = 0x83F0,
        GL_COMPRESSED_RGBA_S3TC_DXT1_EXT = 0x83F1,
        GL_COMPRESSED_RGBA_S3TC_DXT3_EXT = 0x83F2,
        GL_COMPRESSED_RGBA_S3TC_DXT5_EXT = 0x83F3
    }

    public enum DrawIndexTypes
    {
        GL_UNSIGNED_BYTE = 0x1401,
        GL_UNSIGNED_SHORT = 0x1403,
        GL_UNSIGNED_INT = 0x1405
    }

    public enum GLErrors
    {
        /// <summary>
        /// No error has been recorded. The value of this symbolic constant is guaranteed to be 0.
        /// </summary>
        GL_NO_ERROR = 0,

        /// <summary>
        /// An unacceptable value is specified for an enumerated argument. The offending command is ignored and has no other side effect than to set the error flag.
        /// </summary>
        GL_INVALID_ENUM = 0x0500,

        /// <summary>
        /// A numeric argument is out of range. The offending command is ignored and has no other side effect than to set the error flag.
        /// </summary>
        GL_INVALID_VALUE = 0x0501,

        /// <summary>
        /// The specified operation is not allowed in the current state. The offending command is ignored and has no other side effect than to set the error flag.
        /// </summary>
        GL_INVALID_OPERATION = 0x0502,

        /// <summary>
        /// The framebuffer object is not complete. The offending command is ignored and has no other side effect than to set the error flag.
        /// </summary>
        GL_INVALID_FRAMEBUFFER_OPERATION = 0x0506,

        /// <summary>
        /// There is not enough memory left to execute the command. The state of the GL is undefined, except for the state of the error flags, after this error is recorded.
        /// </summary>
        GL_OUT_OF_MEMORY = 0x0505,

        /// <summary>
        /// An attempt has been made to perform an operation that would cause an internal stack to underflow.
        /// </summary>
        GL_STACK_UNDERFLOW = 0x0504,

        /// <summary>
        /// An attempt has been made to perform an operation that would cause an internal stack to overflow.
        /// </summary>
        GL_STACK_OVERFLOW = 0x0503

    }

    public enum BlendingFactor
    {
        GL_ZERO = 0,
        GL_ONE = 1,
        GL_SRC_COLOR = 0x0300,
        GL_ONE_MINUS_SRC_COLOR = 0x0301,
        GL_DST_COLOR = 0x0306,
        GL_ONE_MINUS_DST_COLOR = 0x0307,
        GL_SRC_ALPHA = 0x0302,
        GL_ONE_MINUS_SRC_ALPHA = 0x0303,
        GL_DST_ALPHA = 0x0304,
        GL_ONE_MINUS_DST_ALPHA = 0x0305,
        GL_CONSTANT_COLOR = 0x8001,
        GL_ONE_MINUS_CONSTANT_COLOR = 0x8002,
        GL_CONSTANT_ALPHA = 0x8003,
        GL_ONE_MINUS_CONSTANT_ALPHA = 0x8004
    }

    public enum GetValueParameters
    {
        /// <summary>
        /// data returns a single value indicating the active multitexture unit. The initial value is GL_TEXTURE0. 
        /// See glActiveTexture.
        /// </summary>
        GL_ACTIVE_TEXTURE = 0x84E0,


        /// <summary>
        /// data returns a pair of values indicating the range of widths supported for aliased lines. See glLineWidth.
        /// </summary>
        GL_ALIASED_LINE_WIDTH_RANGE = 0x846E,


        /// <summary>
        /// data returns a single value, the name of the buffer object currently bound to the target GL_ARRAY_BUFFER.
        /// If no buffer object is bound to this target, 0 is returned. The initial value is 0. See glBindBuffer.
        /// </summary>
        GL_ARRAY_BUFFER_BINDING = 0x8894,


        /// <summary>
        /// data returns a single boolean value indicating whether blending is enabled. The initial value is GL_FALSE. 
        /// See glBlendFunc.
        /// </summary>
        GL_BLEND = 0x0BE2,


        /// <summary>
        /// data returns four values, the red, green, blue, and alpha values which are the components of the blend color.
        /// See glBlendColor.
        /// </summary>
        GL_BLEND_COLOR = 0x8005,


        /// <summary>
        /// data returns one value, the symbolic constant identifying the alpha destination blend function. 
        /// The initial value is GL_ZERO. See glBlendFunc and glBlendFuncSeparate.
        /// </summary>
        GL_BLEND_DST_ALPHA = 0x80CA,


        /// <summary>
        /// data returns one value, the symbolic constant identifying the RGB destination blend function. 
        /// The initial value is GL_ZERO. See glBlendFunc and glBlendFuncSeparate.
        /// </summary>
        GL_BLEND_DST_RGB = 0x80C8,


        /// <summary>
        /// data returns one value, a symbolic constant indicating whether the RGB blend equation is 
        /// GL_FUNC_ADD, GL_FUNC_SUBTRACT, GL_FUNC_REVERSE_SUBTRACT, GL_MIN or GL_MAX. See glBlendEquationSeparate.
        /// </summary>
        GL_BLEND_EQUATION_RGB = 0x8009,


        /// <summary>
        /// data returns one value, a symbolic constant indicating whether the Alpha blend equation is 
        /// GL_FUNC_ADD, GL_FUNC_SUBTRACT, GL_FUNC_REVERSE_SUBTRACT, GL_MIN or GL_MAX. See glBlendEquationSeparate.
        /// </summary>
        GL_BLEND_EQUATION_ALPHA = 0x883D,


        /// <summary>
        /// data returns one value, the symbolic constant identifying the alpha source blend function. 
        /// The initial value is GL_ONE. See glBlendFunc and glBlendFuncSeparate.
        /// </summary>
        GL_BLEND_SRC_ALPHA = 0x80CB,


        /// <summary>
        /// data returns one value, the symbolic constant identifying the RGB source blend function. 
        /// The initial value is GL_ONE. See glBlendFunc and glBlendFuncSeparate.
        /// </summary>
        GL_BLEND_SRC_RGB = 0x80C9,


        /// <summary>
        /// data returns four values: the red, green, blue, and alpha values used to clear the color buffers.
        /// Integer values, if requested, are linearly mapped from the internal floating-point representation 
        /// such that 1.0 returns the most positive representable integer value, and −1.0 returns the most 
        /// negative representable integer value.The initial value is (0, 0, 0, 0). See glClearColor.
        /// </summary>
        GL_COLOR_CLEAR_VALUE = 0x0C22,


        /// <summary>
        /// data returns a single boolean value indicating whether a fragment's RGBA color values are merged into 
        /// the framebuffer using a logical operation. The initial value is GL_FALSE. See glLogicOp.
        /// </summary>
        GL_COLOR_LOGIC_OP = 0x0BF2,


        /// <summary>
        /// data returns four boolean values: the red, green, blue, and alpha write enables for the color buffers.
        /// The initial value is (GL_TRUE, GL_TRUE, GL_TRUE, GL_TRUE). See glColorMask.
        /// </summary>
        GL_COLOR_WRITEMASK = 0x0C23,


        /// <summary>
        /// data returns a list of symbolic constants of length GL_NUM_COMPRESSED_TEXTURE_FORMATS indicating which 
        /// compressed texture formats are available. See glCompressedTexImage2D.
        /// </summary>
        GL_COMPRESSED_TEXTURE_FORMATS = 0x86A3,


        /// <summary>
        /// data returns one value, the maximum number of active shader storage blocks that may be accessed by a 
        /// compute shader.
        /// </summary>
        GL_MAX_COMPUTE_SHADER_STORAGE_BLOCKS = 0x90DB,


        /// <summary>
        /// data returns one value, the maximum total number of active shader storage blocks that may be accessed 
        /// by all active shaders.
        /// </summary>
        GL_MAX_COMBINED_SHADER_STORAGE_BLOCKS = 0x90DC,


        /// <summary>
        /// data returns one value, the maximum number of uniform blocks per compute shader.The value must be at least 14.
        /// See glUniformBlockBinding.
        /// </summary>
        GL_MAX_COMPUTE_UNIFORM_BLOCKS = 0x91BB,


        /// <summary>
        /// data returns one value, the maximum supported texture image units that can be used to access texture maps 
        /// from the compute shader. The value must be at least 16. See glActiveTexture.
        /// </summary>
        GL_MAX_COMPUTE_TEXTURE_IMAGE_UNITS = 0x91BC,


        /// <summary>
        /// data returns one value, the maximum number of individual floating-point, integer, or boolean values that 
        /// can be held in uniform variable storage for a compute shader.The value must be at least 1024. See glUniform.
        /// </summary>
        GL_MAX_COMPUTE_UNIFORM_COMPONENTS = 0x8263,


        /// <summary>
        /// data returns a single value, the maximum number of atomic counters available to compute shaders.
        /// </summary>
        GL_MAX_COMPUTE_ATOMIC_COUNTERS = 0x8265,


        /// <summary>
        /// data returns a single value, the maximum number of atomic counter buffers that may be accessed by a 
        /// compute shader.
        /// </summary>
        GL_MAX_COMPUTE_ATOMIC_COUNTER_BUFFERS = 0x8264,


        /// <summary>
        /// data returns one value, the number of words for compute shader uniform variables in all uniform blocks
        /// (including default). The value must be at least 1. See glUniform.
        /// </summary>
        GL_MAX_COMBINED_COMPUTE_UNIFORM_COMPONENTS = 0x8266,


        /// <summary>
        /// data returns one value, the number of invocations in a single local work group (i.e., the product of the 
        /// three dimensions) that may be dispatched to a compute shader.
        /// </summary>
        GL_MAX_COMPUTE_WORK_GROUP_INVOCATIONS = 0x90EB,


        /// <summary>
        /// Accepted by the indexed versions of glGet.data the maximum number of work groups that may be dispatched to
        /// a compute shader.Indices 0, 1, and 2 correspond to the X, Y and Z dimensions, respectively.
        /// </summary>
        GL_MAX_COMPUTE_WORK_GROUP_COUNT = 0x91BE,


        /// <summary>
        /// Accepted by the indexed versions of glGet. data the maximum size of a work groups that may be used during 
        /// compilation of a compute shader. Indices 0, 1, and 2 correspond to the X, Y and Z dimensions, respectively.
        /// </summary>
        GL_MAX_COMPUTE_WORK_GROUP_SIZE = 0x91BF,


        /// <summary>
        /// data returns a single value, the name of the buffer object currently bound to the target 
        /// GL_DISPATCH_INDIRECT_BUFFER.If no buffer object is bound to this target, 0 is returned.The initial value is 0.
        /// See glBindBuffer.
        /// </summary>
        GL_DISPATCH_INDIRECT_BUFFER_BINDING = 0x90EF,


        /// <summary>
        /// data returns a single value, the maximum depth of the debug message group stack.
        /// </summary>
        GL_MAX_DEBUG_GROUP_STACK_DEPTH = 0x826C,


        /// <summary>
        /// data returns a single value, the current depth of the debug message group stack.
        /// </summary>
        GL_DEBUG_GROUP_STACK_DEPTH = 0x826D,


        /// <summary>
        /// data returns one value, the flags with which the context was created (such as debugging functionality).
        /// </summary>
        GL_CONTEXT_FLAGS = 0x821E,


        /// <summary>
        /// data returns a single boolean value indicating whether polygon culling is enabled.The initial value is 
        /// GL_FALSE.See glCullFace.
        /// </summary>
        GL_CULL_FACE = 0x0B44,


        /// <summary>
        /// data returns a single value indicating the mode of polygon culling.The initial value is GL_BACK.
        /// See glCullFace.
        /// </summary>
        GL_CULL_FACE_MODE = 0x0B45,


        /// <summary>
        /// data returns one value, the name of the program object that is currently active, or 0 if no program
        /// object is active.See glUseProgram.
        /// </summary>
        GL_CURRENT_PROGRAM = 0x8B8D,


        /// <summary>
        /// data returns one value, the value that is used to clear the depth buffer. Integer values, if requested,
        /// are linearly mapped from the internal floating-point representation such that 1.0 returns the most 
        /// positive representable integer value, and −1.0 returns the most negative representable integer value.
        /// The initial value is 1. See glClearDepth.
        /// </summary>
        GL_DEPTH_CLEAR_VALUE = 0x0B73,


        /// <summary>
        /// data returns one value, the symbolic constant that indicates the depth comparison function.
        /// The initial value is GL_LESS.See glDepthFunc.
        /// </summary>
        GL_DEPTH_FUNC = 0x0B74,


        /// <summary>
        /// data returns two values: the near and far mapping limits for the depth buffer.Integer values, 
        /// if requested, are linearly mapped from the internal floating-point representation such that 1.0 returns 
        /// the most positive representable integer value, and −1.0 returns the most negative representable integer value.
        /// The initial value is (0, 1). See glDepthRange.
        /// </summary>
        GL_DEPTH_RANGE = 0x0B70,


        /// <summary>
        /// data returns a single boolean value indicating whether depth testing of fragments is enabled.
        /// The initial value is GL_FALSE.See glDepthFunc and glDepthRange.
        /// </summary>
        GL_DEPTH_TEST = 0x0B71,


        /// <summary>
        /// data returns a single boolean value indicating if the depth buffer is enabled for writing.
        /// The initial value is GL_TRUE.See glDepthMask.
        /// </summary>
        GL_DEPTH_WRITEMASK = 0x0B72,


        /// <summary>
        /// data returns a single boolean value indicating whether dithering of fragment colors and indices is enabled.
        /// The initial value is GL_TRUE.
        /// </summary>
        GL_DITHER = 0x0BD0,


        /// <summary>
        /// data returns a single boolean value indicating whether double buffering is supported.
        /// </summary>
        GL_DOUBLEBUFFER = 0x0C32,


        /// <summary>
        /// data returns one value, a symbolic constant indicating which buffers are being drawn to. See glDrawBuffer. 
        /// The initial value is GL_BACK if there are back buffers, otherwise it is GL_FRONT.
        /// </summary>
        GL_DRAW_BUFFER = 0x0C01,


        /// <summary>
        /// data returns one value, a symbolic constant indicating which buffers are being drawn to by the corresponding 
        /// output color.See glDrawBuffers. The initial value of GL_DRAW_BUFFER0 is GL_BACK if there are back buffers, 
        /// otherwise it is GL_FRONT.The initial values of draw buffers for all other output colors is GL_NONE.
        /// </summary>
        GL_DRAW_BUFFER0 = 0x8825,
        GL_DRAW_BUFFER1 = 0x8826,
        GL_DRAW_BUFFER2 = 0x8827,
        GL_DRAW_BUFFER3 = 0x8828,
        GL_DRAW_BUFFER4 = 0x8829,
        GL_DRAW_BUFFER5 = 0x882A,
        GL_DRAW_BUFFER6 = 0x882B,
        GL_DRAW_BUFFER7 = 0x882C,
        GL_DRAW_BUFFER8 = 0x882D,
        GL_DRAW_BUFFER9 = 0x882E,
        GL_DRAW_BUFFER10 = 0x882F,
        GL_DRAW_BUFFER11 = 0x8830,
        GL_DRAW_BUFFER12 = 0x8831,
        GL_DRAW_BUFFER13 = 0x8832,
        GL_DRAW_BUFFER14 = 0x8833,
        GL_DRAW_BUFFER15 = 0x8834,


        /// <summary>
        /// data returns one value, the name of the framebuffer object currently bound to the GL_DRAW_FRAMEBUFFER target.
        /// If the default framebuffer is bound, this value will be zero. The initial value is zero.See glBindFramebuffer.
        /// </summary>
        GL_DRAW_FRAMEBUFFER_BINDING = 0x8CA6,


        /// <summary>
        /// data returns one value, the name of the framebuffer object currently bound to the GL_READ_FRAMEBUFFER target.
        /// If the default framebuffer is bound, this value will be zero. The initial value is zero.See glBindFramebuffer.
        /// </summary>
        GL_READ_FRAMEBUFFER_BINDING = 0x8CAA,


        /// <summary>
        /// data returns a single value, the name of the buffer object currently bound to the target 
        /// GL_ELEMENT_ARRAY_BUFFER.If no buffer object is bound to this target, 0 is returned.The initial value is 0. 
        /// See glBindBuffer.
        /// </summary>
        GL_ELEMENT_ARRAY_BUFFER_BINDING = 0x8895,


        /// <summary>
        /// data returns one value, a symbolic constant indicating the mode of the derivative accuracy hint for 
        /// fragment shaders. The initial value is GL_DONT_CARE.See glHint.
        /// </summary>
        GL_FRAGMENT_SHADER_DERIVATIVE_HINT = 0x8B8B,


        /// <summary>
        /// data returns a single GLenum value indicating the implementation's preferred pixel data format. 
        /// See glReadPixels.
        /// </summary>
        GL_IMPLEMENTATION_COLOR_READ_FORMAT = 0x8B9B,


        /// <summary>
        /// data returns a single GLenum value indicating the implementation's preferred pixel data type. 
        /// See glReadPixels.
        /// </summary>
        GL_IMPLEMENTATION_COLOR_READ_TYPE = 0x8B9A,


        /// <summary>
        /// data returns a single boolean value indicating whether antialiasing of lines is enabled.
        /// The initial value is GL_FALSE.See glLineWidth.
        /// </summary>
        GL_LINE_SMOOTH = 0x0B20,


        /// <summary>
        /// data returns one value, a symbolic constant indicating the mode of the line antialiasing hint.
        /// The initial value is GL_DONT_CARE.See glHint.
        /// </summary>
        GL_LINE_SMOOTH_HINT = 0x0C52,


        /// <summary>
        /// data returns one value, the line width as specified with glLineWidth.The initial value is 1.
        /// </summary>
        GL_LINE_WIDTH = 0x0B21,


        /// <summary>
        /// data returns one value, the implementation dependent specifc vertex of a primitive that is used to
        /// select the rendering layer. If the value returned is equivalent to GL_PROVOKING_VERTEX, then the 
        /// vertex selection follows the convention specified by glProvokingVertex. If the value returned is 
        /// equivalent to GL_FIRST_VERTEX_CONVENTION, then the selection is always taken from the first vertex 
        /// in the primitive. If the value returned is equivalent to GL_LAST_VERTEX_CONVENTION, then the selection 
        /// is always taken from the last vertex in the primitive. If the value returned is equivalent to 
        /// GL_UNDEFINED_VERTEX, then the selection is not guaranteed to be taken from any specific vertex in the
        /// primitive.
        /// </summary>
        GL_LAYER_PROVOKING_VERTEX = 0x825E,


        /// <summary>
        /// data returns one value, a symbolic constant indicating the selected logic operation mode.
        /// The initial value is GL_COPY.See glLogicOp.
        /// </summary>
        GL_LOGIC_OP_MODE = 0x0BF0,


        /// <summary>
        /// data returns one value, the major version number of the OpenGL API supported by the current context.
        /// </summary>
        GL_MAJOR_VERSION = 0x821B,


        /// <summary>
        /// data returns one value, a rough estimate of the largest 3D texture that the GL can handle. 
        /// The value must be at least 64. Use GL_PROXY_TEXTURE_3D to determine if a texture is too large. 
        /// See glTexImage3D.
        /// </summary>
        GL_MAX_3D_TEXTURE_SIZE = 0x8073,


        /// <summary>
        /// data returns one value.The value indicates the maximum number of layers allowed in an array texture, 
        /// and must be at least 256. See glTexImage2D.
        /// </summary>
        GL_MAX_ARRAY_TEXTURE_LAYERS = 0x88FF,


        /// <summary>
        /// data returns one value, the maximum number of application-defined clipping distances.
        /// The value must be at least 8.
        /// </summary>
        GL_MAX_CLIP_DISTANCES = 0x0D32,


        /// <summary>
        /// data returns one value, the maximum number of samples in a color multisample texture.
        /// </summary>
        GL_MAX_COLOR_TEXTURE_SAMPLES = 0x910E,


        /// <summary>
        /// data returns a single value, the maximum number of atomic counters available to all active shaders.
        /// </summary>
        GL_MAX_COMBINED_ATOMIC_COUNTERS = 0x92D7,


        /// <summary>
        /// data returns one value, the number of words for fragment shader uniform variables in all uniform blocks 
        /// (including default). The value must be at least 1. See glUniform.
        /// </summary>
        GL_MAX_COMBINED_FRAGMENT_UNIFORM_COMPONENTS = 0x8A33,


        /// <summary>
        /// data returns one value, the number of words for geometry shader uniform variables in all uniform blocks 
        /// (including default). The value must be at least 1. See glUniform.
        /// </summary>
        GL_MAX_COMBINED_GEOMETRY_UNIFORM_COMPONENTS = 0x8A32,


        /// <summary>
        /// data returns one value, the maximum supported texture image units that can be used to access texture maps 
        /// from the vertex shader and the fragment processor combined.If both the vertex shader and the fragment
        /// processing stage access the same texture image unit, then that counts as using two texture image units 
        /// against this limit.The value must be at least 48. See glActiveTexture.
        /// </summary>
        GL_MAX_COMBINED_TEXTURE_IMAGE_UNITS = 0x8B4D,


        /// <summary>
        /// data returns one value, the maximum number of uniform blocks per program. The value must be at least 70. 
        /// See glUniformBlockBinding.
        /// </summary>
        GL_MAX_COMBINED_UNIFORM_BLOCKS = 0x8A2E,


        /// <summary>
        /// data returns one value, the number of words for vertex shader uniform variables in all uniform blocks 
        /// (including default). The value must be at least 1. See glUniform.
        /// </summary>
        GL_MAX_COMBINED_VERTEX_UNIFORM_COMPONENTS = 0x8A31,


        /// <summary>
        /// data returns one value. The value gives a rough estimate of the largest cube-map texture that the GL 
        /// can handle. The value must be at least 1024. Use GL_PROXY_TEXTURE_CUBE_MAP to determine if a texture 
        /// is too large. See glTexImage2D.
        /// </summary>
        GL_MAX_CUBE_MAP_TEXTURE_SIZE = 0x851C,


        /// <summary>
        /// data returns one value, the maximum number of samples in a multisample depth or depth-stencil texture.
        /// </summary>
        GL_MAX_DEPTH_TEXTURE_SAMPLES = 0x910F,


        /// <summary>
        /// data returns one value, the maximum number of simultaneous outputs that may be written in a fragment shader. 
        /// The value must be at least 8. See glDrawBuffers.
        /// </summary>
        GL_MAX_DRAW_BUFFERS = 0x8824,


        /// <summary>
        /// data returns one value, the maximum number of active draw buffers when using dual-source blending.
        /// The value must be at least 1. See glBlendFunc and glBlendFuncSeparate.
        /// </summary>
        GL_MAX_DUAL_SOURCE_DRAW_BUFFERS = 0x88FC,


        /// <summary>
        /// data returns one value, the recommended maximum number of vertex array indices. See glDrawRangeElements.
        /// </summary>
        GL_MAX_ELEMENTS_INDICES = 0x80E9,


        /// <summary>
        /// data returns one value, the recommended maximum number of vertex array vertices. See glDrawRangeElements.
        /// </summary>
        GL_MAX_ELEMENTS_VERTICES = 0x80E8,


        /// <summary>
        /// data returns a single value, the maximum number of atomic counters available to fragment shaders.
        /// </summary>
        GL_MAX_FRAGMENT_ATOMIC_COUNTERS = 0x92D6,


        /// <summary>
        /// data returns one value, the maximum number of active shader storage blocks that may be accessed by a 
        /// fragment shader.
        /// </summary>
        GL_MAX_FRAGMENT_SHADER_STORAGE_BLOCKS = 0x90DA,


        /// <summary>
        /// data returns one value, the maximum number of components of the inputs read by the fragment shader, 
        /// which must be at least 128.
        /// </summary>
        GL_MAX_FRAGMENT_INPUT_COMPONENTS = 0x9125,


        /// <summary>
        /// data returns one value, the maximum number of individual floating-point, integer, or boolean values 
        /// that can be held in uniform variable storage for a fragment shader.The value must be at least 1024. 
        /// See glUniform.
        /// </summary>
        GL_MAX_FRAGMENT_UNIFORM_COMPONENTS = 0x8B49,


        /// <summary>
        /// data returns one value, the maximum number of individual 4-vectors of floating-point, integer, or 
        /// boolean values that can be held in uniform variable storage for a fragment shader.The value is equal 
        /// to the value of GL_MAX_FRAGMENT_UNIFORM_COMPONENTS divided by 4 and must be at least 256. See glUniform.
        /// </summary>
        GL_MAX_FRAGMENT_UNIFORM_VECTORS = 0x8DFD,


        /// <summary>
        /// data returns one value, the maximum number of uniform blocks per fragment shader.
        /// The value must be at least 12. See glUniformBlockBinding.
        /// </summary>
        GL_MAX_FRAGMENT_UNIFORM_BLOCKS = 0x8A2D,


        /// <summary>
        /// data returns one value, the maximum width for a framebuffer that has no attachments, 
        /// which must be at least 16384. See glFramebufferParameter.
        /// </summary>
        GL_MAX_FRAMEBUFFER_WIDTH = 0x9315,


        /// <summary>
        /// data returns one value, the maximum height for a framebuffer that has no attachments, 
        /// which must be at least 16384. See glFramebufferParameter.
        /// </summary>
        GL_MAX_FRAMEBUFFER_HEIGHT = 0x9316,


        /// <summary>
        /// data returns one value, the maximum number of layers for a framebuffer that has no attachments, 
        /// which must be at least 2048. See glFramebufferParameter.
        /// </summary>
        GL_MAX_FRAMEBUFFER_LAYERS = 0x9317,


        /// <summary>
        /// data returns one value, the maximum samples in a framebuffer that has no attachments, 
        /// which must be at least 4. See glFramebufferParameter.
        /// </summary>
        GL_MAX_FRAMEBUFFER_SAMPLES = 0x9318,


        /// <summary>
        /// data returns a single value, the maximum number of atomic counters available to geometry shaders.
        /// </summary>
        GL_MAX_GEOMETRY_ATOMIC_COUNTERS = 0x92D5,


        /// <summary>
        /// data returns one value, the maximum number of active shader storage blocks that may be accessed by a
        /// geometry shader.
        /// </summary>
        GL_MAX_GEOMETRY_SHADER_STORAGE_BLOCKS = 0x90D7,


        /// <summary>
        /// data returns one value, the maximum number of components of inputs read by a geometry shader, 
        /// which must be at least 64.
        /// </summary>
        GL_MAX_GEOMETRY_INPUT_COMPONENTS = 0x9123,


        /// <summary>
        /// data returns one value, the maximum number of components of outputs written by a geometry shader, 
        /// which must be at least 128.
        /// </summary>
        GL_MAX_GEOMETRY_OUTPUT_COMPONENTS = 0x9124,


        /// <summary>
        /// data returns one value, the maximum supported texture image units that can be used to access 
        /// texture maps from the geometry shader. The value must be at least 16. See glActiveTexture.
        /// </summary>
        GL_MAX_GEOMETRY_TEXTURE_IMAGE_UNITS = 0x8C29,


        /// <summary>
        /// data returns one value, the maximum number of uniform blocks per geometry shader.
        /// The value must be at least 12. See glUniformBlockBinding.
        /// </summary>
        GL_MAX_GEOMETRY_UNIFORM_BLOCKS = 0x8A2C,


        /// <summary>
        /// data returns one value, the maximum number of individual floating-point, integer, or boolean values
        /// that can be held in uniform variable storage for a geometry shader.The value must be at least 1024. 
        /// See glUniform.
        /// </summary>
        GL_MAX_GEOMETRY_UNIFORM_COMPONENTS = 0x8DDF,


        /// <summary>
        /// data returns one value, the maximum number of samples supported in integer format multisample buffers.
        /// </summary>
        GL_MAX_INTEGER_SAMPLES = 0x9110,


        /// <summary>
        /// data returns one value, the minimum alignment in basic machine units of pointers returned fromglMapBuffer
        /// and glMapBufferRange.This value must be a power of two and must be at least 64.
        /// </summary>
        GL_MIN_MAP_BUFFER_ALIGNMENT = 0x90BC,


        /// <summary>
        /// data returns one value, the maximum length of a label that may be assigned to an object. 
        /// See glObjectLabel and glObjectPtrLabel.
        /// </summary>
        GL_MAX_LABEL_LENGTH = 0x82E8,


        /// <summary>
        /// data returns one value, the maximum texel offset allowed in a texture lookup, which must be at least 7.
        /// </summary>
        GL_MAX_PROGRAM_TEXEL_OFFSET = 0x8905,


        /// <summary>
        /// data returns one value, the minimum texel offset allowed in a texture lookup, which must be at most -8.
        /// </summary>
        GL_MIN_PROGRAM_TEXEL_OFFSET = 0x8904,


        /// <summary>
        /// data returns one value.The value gives a rough estimate of the largest rectangular texture that the GL
        /// can handle. The value must be at least 1024. Use GL_PROXY_TEXTURE_RECTANGLE to determine if a texture 
        /// is too large. See glTexImage2D.
        /// </summary>
        GL_MAX_RECTANGLE_TEXTURE_SIZE = 0x84F8,


        /// <summary>
        /// data returns one value.The value indicates the maximum supported size for renderbuffers.
        /// See glFramebufferRenderbuffer.
        /// </summary>
        GL_MAX_RENDERBUFFER_SIZE = 0x84E8,


        /// <summary>
        /// data returns one value, the maximum number of sample mask words.
        /// </summary>
        GL_MAX_SAMPLE_MASK_WORDS = 0x8E59,


        /// <summary>
        /// data returns one value, the maximum glWaitSync timeout interval.
        /// </summary>
        GL_MAX_SERVER_WAIT_TIMEOUT = 0x9111,


        /// <summary>
        /// data returns one value, the maximum number of shader storage buffer binding points on the context, 
        /// which must be at least 8.
        /// </summary>
        GL_MAX_SHADER_STORAGE_BUFFER_BINDINGS = 0x90DD,


        /// <summary>
        /// data returns a single value, the maximum number of atomic counters available to tessellation control shaders.
        /// </summary>
        GL_MAX_TESS_CONTROL_ATOMIC_COUNTERS = 0x92D3,


        /// <summary>
        /// data returns a single value, the maximum number of atomic counters available to tessellation
        /// evaluation shaders.
        /// </summary>
        GL_MAX_TESS_EVALUATION_ATOMIC_COUNTERS = 0x92D4,


        /// <summary>
        /// data returns one value, the maximum number of active shader storage blocks that may be accessed 
        /// by a tessellation control shader.
        /// </summary>
        GL_MAX_TESS_CONTROL_SHADER_STORAGE_BLOCKS = 0x90D8,


        /// <summary>
        /// data returns one value, the maximum number of active shader storage blocks that may be accessed 
        /// by a tessellation evaluation shader.
        /// </summary>
        GL_MAX_TESS_EVALUATION_SHADER_STORAGE_BLOCKS = 0x90D9,


        /// <summary>
        /// data returns one value.The value gives the maximum number of texels allowed in the texel array 
        /// of a texture buffer object. Value must be at least 65536.
        /// </summary>
        GL_MAX_TEXTURE_BUFFER_SIZE = 0x8C2B,


        /// <summary>
        /// data returns one value, the maximum supported texture image units that can be used to access
        /// texture maps from the fragment shader. The value must be at least 16. See glActiveTexture.
        /// </summary>
        GL_MAX_TEXTURE_IMAGE_UNITS = 0x8872,


        /// <summary>
        /// data returns one value, the maximum, absolute value of the texture level-of-detail bias. 
        /// The value must be at least 2.0.
        /// </summary>
        GL_MAX_TEXTURE_LOD_BIAS = 0x84FD,


        /// <summary>
        /// data returns one value.The value gives a rough estimate of the largest texture that the GL can handle.
        /// The value must be at least 1024. Use a proxy texture target such as GL_PROXY_TEXTURE_1D or 
        /// GL_PROXY_TEXTURE_2D to determine if a texture is too large. See glTexImage1D and glTexImage2D.
        /// </summary>
        GL_MAX_TEXTURE_SIZE = 0x0D33,


        /// <summary>
        /// data returns one value, the maximum number of uniform buffer binding points on the context, 
        /// which must be at least 36.
        /// </summary>
        GL_MAX_UNIFORM_BUFFER_BINDINGS = 0x8A2F,


        /// <summary>
        /// data returns one value, the maximum size in basic machine units of a uniform block, which must 
        /// be at least 16384.
        /// </summary>
        GL_MAX_UNIFORM_BLOCK_SIZE = 0x8A30,


        /// <summary>
        /// data returns one value, the maximum number of explicitly assignable uniform locations, which must
        /// be at least 1024.
        /// </summary>
        GL_MAX_UNIFORM_LOCATIONS = 0x826E,


        /// <summary>
        /// data returns one value, the number components for varying variables, which must be at least 60.
        /// </summary>
        GL_MAX_VARYING_COMPONENTS = 0x8B4B,


        /// <summary>
        /// data returns one value, the number 4-vectors for varying variables, which is equal to the value of 
        /// GL_MAX_VARYING_COMPONENTS and must be at least 15.
        /// </summary>
        GL_MAX_VARYING_VECTORS = 0x8DFC,


        /// <summary>
        /// data returns one value, the maximum number of interpolators available for processing varying 
        /// variables used by vertex and fragment shaders.This value represents the number of individual 
        /// floating-point values that can be interpolated; varying variables declared as vectors, matrices, 
        /// and arrays will all consume multiple interpolators.The value must be at least 32.
        /// </summary>
        GL_MAX_VARYING_FLOATS = 0x8B4B,


        /// <summary>
        /// data returns a single value, the maximum number of atomic counters available to vertex shaders.
        /// </summary>
        GL_MAX_VERTEX_ATOMIC_COUNTERS = 0x92D2,


        /// <summary>
        /// data returns one value, the maximum number of 4-component generic vertex attributes accessible to a
        /// vertex shader.The value must be at least 16. See glVertexAttrib.
        /// </summary>
        GL_MAX_VERTEX_ATTRIBS = 0x8869,


        /// <summary>
        /// data returns one value, the maximum number of active shader storage blocks that may be accessed by a 
        /// vertex shader.
        /// </summary>
        GL_MAX_VERTEX_SHADER_STORAGE_BLOCKS = 0x90D6,


        /// <summary>
        /// data returns one value, the maximum supported texture image units that can be used to access 
        /// texture maps from the vertex shader. The value may be at least 16. See glActiveTexture.
        /// </summary>
        GL_MAX_VERTEX_TEXTURE_IMAGE_UNITS = 0x8B4C,


        /// <summary>
        /// data returns one value, the maximum number of individual floating-point, integer, or boolean values
        /// that can be held in uniform variable storage for a vertex shader.The value must be at least 1024. 
        /// See glUniform.
        /// </summary>
        GL_MAX_VERTEX_UNIFORM_COMPONENTS = 0x8B4A,


        /// <summary>
        /// data returns one value, the maximum number of 4-vectors that may be held in uniform variable storage 
        /// for the vertex shader.The value of GL_MAX_VERTEX_UNIFORM_VECTORS is equal to the value of 
        /// GL_MAX_VERTEX_UNIFORM_COMPONENTS and must be at least 256.
        /// </summary>
        GL_MAX_VERTEX_UNIFORM_VECTORS = 0x8DFB,


        /// <summary>
        /// data returns one value, the maximum number of components of output written by a vertex shader, 
        /// which must be at least 64.
        /// </summary>
        GL_MAX_VERTEX_OUTPUT_COMPONENTS = 0x9122,


        /// <summary>
        /// data returns one value, the maximum number of uniform blocks per vertex shader.The value must be at least 12.
        /// See glUniformBlockBinding.
        /// </summary>
        GL_MAX_VERTEX_UNIFORM_BLOCKS = 0x8A2B,


        /// <summary>
        /// data returns two values: the maximum supported width and height of the viewport.
        /// These must be at least as large as the visible dimensions of the display being rendered to.See glViewport.
        /// </summary>
        GL_MAX_VIEWPORT_DIMS = 0x0D3A,


        /// <summary>
        /// data returns one value, the maximum number of simultaneous viewports that are supported.
        /// The value must be at least 16. See glViewportIndexed.
        /// </summary>
        GL_MAX_VIEWPORTS = 0x825B,


        /// <summary>
        /// data returns one value, the minor version number of the OpenGL API supported by the current context.
        /// </summary>
        GL_MINOR_VERSION = 0x821C,


        /// <summary>
        /// data returns a single integer value indicating the number of available compressed texture formats.
        /// The minimum value is 4. See glCompressedTexImage2D.
        /// </summary>
        GL_NUM_COMPRESSED_TEXTURE_FORMATS = 0x86A2,


        /// <summary>
        /// data returns one value, the number of extensions supported by the GL implementation for the current context.
        /// See glGetString.
        /// </summary>
        GL_NUM_EXTENSIONS = 0x821D,


        /// <summary>
        /// data returns one value, the number of program binary formats supported by the implementation.
        /// </summary>
        GL_NUM_PROGRAM_BINARY_FORMATS = 0x87FE,


        /// <summary>
        /// data returns one value, the number of binary shader formats supported by the implementation. 
        /// If this value is greater than zero, then the implementation supports loading binary shaders.
        /// If it is zero, then the loading of binary shaders by the implementation is not supported.
        /// </summary>
        GL_NUM_SHADER_BINARY_FORMATS = 0x8DF9,


        /// <summary>
        /// data returns one value, the byte alignment used for writing pixel data to memory.The initial value is 4.
        /// See glPixelStore.
        /// </summary>
        GL_PACK_ALIGNMENT = 0x0D05,


        /// <summary>
        /// data returns one value, the image height used for writing pixel data to memory.The initial value is 0.
        /// See glPixelStore.
        /// </summary>
        GL_PACK_IMAGE_HEIGHT = 0x806C,


        /// <summary>
        /// data returns a single boolean value indicating whether single-bit pixels being written to memory 
        /// are written first to the least significant bit of each unsigned byte. The initial value is GL_FALSE.
        /// See glPixelStore.
        /// </summary>
        GL_PACK_LSB_FIRST = 0x0D01,


        /// <summary>
        /// data returns one value, the row length used for writing pixel data to memory.The initial value is 0.
        /// See glPixelStore.
        /// </summary>
        GL_PACK_ROW_LENGTH = 0x0D02,


        /// <summary>
        /// data returns one value, the number of pixel images skipped before the first pixel is written into memory.
        /// The initial value is 0. See glPixelStore.
        /// </summary>
        GL_PACK_SKIP_IMAGES = 0x806B,


        /// <summary>
        /// data returns one value, the number of pixel locations skipped before the first pixel is written into memory.
        /// The initial value is 0. See glPixelStore.
        /// </summary>
        GL_PACK_SKIP_PIXELS = 0x0D04,


        /// <summary>
        /// data returns one value, the number of rows of pixel locations skipped before the first pixel is written 
        /// into memory.The initial value is 0. See glPixelStore.
        /// </summary>
        GL_PACK_SKIP_ROWS = 0x0D03,


        /// <summary>
        /// data returns a single boolean value indicating whether the bytes of two-byte and four-byte pixel indices
        /// and components are swapped before being written to memory. The initial value is GL_FALSE.See glPixelStore.
        /// </summary>
        GL_PACK_SWAP_BYTES = 0x0D00,


        /// <summary>
        /// data returns a single value, the name of the buffer object currently bound to the target GL_PIXEL_PACK_BUFFER.
        /// If no buffer object is bound to this target, 0 is returned.The initial value is 0. See glBindBuffer.
        /// </summary>
        GL_PIXEL_PACK_BUFFER_BINDING = 0x88ED,


        /// <summary>
        /// data returns a single value, the name of the buffer object currently bound to the target
        /// GL_PIXEL_UNPACK_BUFFER.If no buffer object is bound to this target, 0 is returned.The initial value is 0. 
        /// See glBindBuffer.
        /// </summary>
        GL_PIXEL_UNPACK_BUFFER_BINDING = 0x88EF,


        /// <summary>
        /// data returns one value, the point size threshold for determining the point size. See glPointParameter.
        /// </summary>
        GL_POINT_FADE_THRESHOLD_SIZE = 0x8128,


        /// <summary>
        /// data returns one value, the current primitive restart index.The initial value is 0.
        /// See glPrimitiveRestartIndex.
        /// </summary>
        GL_PRIMITIVE_RESTART_INDEX = 0x8F9E,


        /// <summary>
        /// data an array of GL_NUM_PROGRAM_BINARY_FORMATS values, indicating the proram binary formats supported by
        /// the implementation.
        /// </summary>
        GL_PROGRAM_BINARY_FORMATS = 0x87FF,


        /// <summary>
        /// data a single value, the name of the currently bound program pipeline object, or zero if no program 
        /// pipeline object is bound.See glBindProgramPipeline.
        /// </summary>
        GL_PROGRAM_PIPELINE_BINDING = 0x825A,


        /// <summary>
        /// data returns a single boolean value indicating whether vertex program point size mode is enabled.
        /// If enabled, then the point size is taken from the shader built-in gl_PointSize.
        /// If disabled, 
        /// then the point size is taken from the point state as specified by glPointSize.The initial value is GL_FALSE.
        /// </summary>
        GL_PROGRAM_POINT_SIZE = 0x8642,


        /// <summary>
        /// data returns one value, the currently selected provoking vertex convention.
        /// The initial value is GL_LAST_VERTEX_CONVENTION.See glProvokingVertex.
        /// </summary>
        GL_PROVOKING_VERTEX = 0x8E4F,


        /// <summary>
        /// data returns one value, the point size as specified by glPointSize.The initial value is 1.
        /// </summary>
        GL_POINT_SIZE = 0x0B11,


        /// <summary>
        /// data returns one value, the size difference between adjacent supported sizes for antialiased points.
        /// See glPointSize.
        /// </summary>
        GL_POINT_SIZE_GRANULARITY = 0x0B13,


        /// <summary>
        /// data returns two values: the smallest and largest supported sizes for antialiased points. 
        /// The smallest size must be at most 1, and the largest size must be at least 1. See glPointSize.
        /// </summary>
        GL_POINT_SIZE_RANGE = 0x0B12,


        /// <summary>
        /// data returns one value, the scaling factor used to determine the variable offset that is added to the
        /// depth value of each fragment generated when a polygon is rasterized.The initial value is 0.
        /// See glPolygonOffset.
        /// </summary>
        GL_POLYGON_OFFSET_FACTOR = 0x8038,


        /// <summary>
        /// data returns one value.This value is multiplied by an implementation-specific value and then added to the
        /// depth value of each fragment generated when a polygon is rasterized.The initial value is 0. 
        /// See glPolygonOffset.
        /// </summary>
        GL_POLYGON_OFFSET_UNITS = 0x2A00,


        /// <summary>
        /// data returns a single boolean value indicating whether polygon offset is enabled for polygons in fill mode.
        /// The initial value is GL_FALSE.See glPolygonOffset.
        /// </summary>
        GL_POLYGON_OFFSET_FILL = 0x8037,


        /// <summary>
        /// data returns a single boolean value indicating whether polygon offset is enabled for polygons in line mode. 
        /// The initial value is GL_FALSE.See glPolygonOffset.
        /// </summary>
        GL_POLYGON_OFFSET_LINE = 0x2A02,


        /// <summary>
        /// data returns a single boolean value indicating whether polygon offset is enabled for polygons in point mode. 
        /// The initial value is GL_FALSE.See glPolygonOffset.
        /// </summary>
        GL_POLYGON_OFFSET_POINT = 0x2A01,


        /// <summary>
        /// data returns a single boolean value indicating whether antialiasing of polygons is enabled.
        /// The initial value is GL_FALSE.See glPolygonMode.
        /// </summary>
        GL_POLYGON_SMOOTH = 0x0B41,


        /// <summary>
        /// data returns one value, a symbolic constant indicating the mode of the polygon antialiasing hint.
        /// The initial value is GL_DONT_CARE.See glHint.
        /// </summary>
        GL_POLYGON_SMOOTH_HINT = 0x0C53,


        /// <summary>
        /// data returns one value, a symbolic constant indicating which color buffer is selected for reading.
        /// The initial value is GL_BACK if there is a back buffer, otherwise it is GL_FRONT.See glReadPixels.
        /// </summary>
        GL_READ_BUFFER = 0x0C02,


        /// <summary>
        /// data returns a single value, the name of the renderbuffer object currently bound to the target
        /// GL_RENDERBUFFER.If no renderbuffer object is bound to this target, 0 is returned.The initial value is 0. 
        /// See glBindRenderbuffer.
        /// </summary>
        GL_RENDERBUFFER_BINDING = 0x8CA7,


        /// <summary>
        /// data returns a single integer value indicating the number of sample buffers associated with the framebuffer.
        /// See glSampleCoverage.
        /// </summary>
        GL_SAMPLE_BUFFERS = 0x80A8,


        /// <summary>
        /// data returns a single positive floating-point value indicating the current sample coverage value. 
        /// See glSampleCoverage.
        /// </summary>
        GL_SAMPLE_COVERAGE_VALUE = 0x80AA,


        /// <summary>
        /// data returns a single boolean value indicating if the temporary coverage value should be inverted.
        /// See glSampleCoverage.
        /// </summary>
        GL_SAMPLE_COVERAGE_INVERT = 0x80AB,


        /// <summary>
        /// params returns one value indicating the current sample mask value.See glSampleMaski.
        /// </summary>
        GL_SAMPLE_MASK_VALUE = 0x8E52,


        /// <summary>
        /// data returns a single value, the name of the sampler object currently bound to the active texture unit. 
        /// The initial value is 0. See glBindSampler.
        /// </summary>
        GL_SAMPLER_BINDING = 0x8919,


        /// <summary>
        /// data returns a single integer value indicating the coverage mask size. See glSampleCoverage.
        /// </summary>
        GL_SAMPLES = 0x80A9,


        /// <summary>
        /// data returns four values: the x and y window coordinates of the scissor box, followed by its width and height. 
        /// Initially the x and y window coordinates are both 0 and the width and height are set to the size of the window.
        /// See glScissor.
        /// </summary>
        GL_SCISSOR_BOX = 0x0C10,


        /// <summary>
        /// data returns a single boolean value indicating whether scissoring is enabled.The initial value is GL_FALSE.
        /// See glScissor.
        /// </summary>
        GL_SCISSOR_TEST = 0x0C11,


        /// <summary>
        /// data returns a single boolean value indicating whether an online shader compiler is present in the 
        /// implementation. All desktop OpenGL implementations must support online shader compilations, and therefore 
        /// the value of GL_SHADER_COMPILER will always be GL_TRUE.
        /// </summary>
        GL_SHADER_COMPILER = 0x8DFA,


        /// <summary>
        /// When used with non-indexed variants of glGet (such as glGetIntegerv), data returns a single value,
        /// the name of the buffer object currently bound to the target GL_SHADER_STORAGE_BUFFER.
        /// If no buffer object is bound to this target, 0 is returned.When used with indexed variants of glGet 
        /// (such as glGetIntegeri_v), data returns a single value, the name of the buffer object bound to the
        /// indexed shader storage buffer binding points. The initial value is 0 for all targets. See glBindBuffer,
        /// glBindBufferBase, and glBindBufferRange.
        /// </summary>
        GL_SHADER_STORAGE_BUFFER_BINDING = 0x90D3,


        /// <summary>
        /// data returns a single value, the minimum required alignment for shader storage buffer sizes and offset. 
        /// The initial value is 1. See glShaderStorageBlockBinding.
        /// </summary>
        GL_SHADER_STORAGE_BUFFER_OFFSET_ALIGNMENT = 0x90DF,


        /// <summary>
        /// When used with indexed variants of glGet (such as glGetInteger64i_v), data returns a single value, 
        /// the start offset of the binding range for each indexed shader storage buffer binding. 
        /// The initial value is 0 for all bindings. See glBindBufferRange.
        /// </summary>
        GL_SHADER_STORAGE_BUFFER_START = 0x90D4,


        /// <summary>
        /// When used with indexed variants of glGet (such as glGetInteger64i_v), data returns a single value, 
        /// the size of the binding range for each indexed shader storage buffer binding.
        /// The initial value is 0 for all bindings. See glBindBufferRange.
        /// </summary>
        GL_SHADER_STORAGE_BUFFER_SIZE = 0x90D5,


        /// <summary>
        /// data returns a pair of values indicating the range of widths supported for smooth (antialiased) lines. 
        /// See glLineWidth.
        /// </summary>
        GL_SMOOTH_LINE_WIDTH_RANGE = 0x0B22,


        /// <summary>
        /// data returns a single value indicating the level of quantization applied to smooth line width parameters.
        /// </summary>
        GL_SMOOTH_LINE_WIDTH_GRANULARITY = 0x0B23,


        /// <summary>
        /// data returns one value, a symbolic constant indicating what action is taken for back-facing polygons 
        /// when the stencil test fails. The initial value is GL_KEEP. See glStencilOpSeparate.
        /// </summary>
        GL_STENCIL_BACK_FAIL = 0x8801,


        /// <summary>
        /// data returns one value, a symbolic constant indicating what function is used for back-facing polygons 
        /// to compare the stencil reference value with the stencil buffer value. The initial value is GL_ALWAYS. 
        /// See glStencilFuncSeparate.
        /// </summary>
        GL_STENCIL_BACK_FUNC = 0x8800,


        /// <summary>
        /// data returns one value, a symbolic constant indicating what action is taken for back-facing polygons 
        /// when the stencil test passes, but the depth test fails. The initial value is GL_KEEP. 
        /// See glStencilOpSeparate.
        /// </summary>
        GL_STENCIL_BACK_PASS_DEPTH_FAIL = 0x8802,


        /// <summary>
        /// data returns one value, a symbolic constant indicating what action is taken for back-facing polygons
        /// when the stencil test passes and the depth test passes. The initial value is GL_KEEP. 
        /// See glStencilOpSeparate.
        /// </summary>
        GL_STENCIL_BACK_PASS_DEPTH_PASS = 0x8803,


        /// <summary>
        /// data returns one value, the reference value that is compared with the contents of the stencil buffer 
        /// for back-facing polygons. The initial value is 0. See glStencilFuncSeparate.
        /// </summary>
        GL_STENCIL_BACK_REF = 0x8CA3,


        /// <summary>
        /// data returns one value, the mask that is used for back-facing polygons to mask both the stencil 
        /// reference value and the stencil buffer value before they are compared. The initial value is all 1's.
        /// See glStencilFuncSeparate.
        /// </summary>
        GL_STENCIL_BACK_VALUE_MASK = 0x8CA4,


        /// <summary>
        /// data returns one value, the mask that controls writing of the stencil bitplanes for back-facing polygons.
        /// The initial value is all 1's. See glStencilMaskSeparate.
        /// </summary>
        GL_STENCIL_BACK_WRITEMASK = 0x8CA5,


        /// <summary>
        /// data returns one value, the index to which the stencil bitplanes are cleared. The initial value is 0.
        /// See glClearStencil.
        /// </summary>
        GL_STENCIL_CLEAR_VALUE = 0x0B91,


        /// <summary>
        /// data returns one value, a symbolic constant indicating what action is taken when the stencil test fails.
        /// The initial value is GL_KEEP. See glStencilOp. This stencil state only affects non-polygons and 
        /// front-facing polygons. Back-facing polygons use separate stencil state. See glStencilOpSeparate.
        /// </summary>
        GL_STENCIL_FAIL = 0x0B94,


        /// <summary>
        /// data returns one value, a symbolic constant indicating what function is used to compare the stencil 
        /// reference value with the stencil buffer value. The initial value is GL_ALWAYS. See glStencilFunc. 
        /// This stencil state only affects non-polygons and front-facing polygons. Back-facing polygons use 
        /// separate stencil state. See glStencilFuncSeparate.
        /// </summary>
        GL_STENCIL_FUNC = 0x0B92,


        /// <summary>
        /// data returns one value, a symbolic constant indicating what action is taken when the stencil test passes,
        /// but the depth test fails. The initial value is GL_KEEP. See glStencilOp. 
        /// This stencil state only affects non-polygons and front-facing polygons. 
        /// Back-facing polygons use separate stencil state. See glStencilOpSeparate.
        /// </summary>
        GL_STENCIL_PASS_DEPTH_FAIL = 0x0B95,


        /// <summary>
        /// data returns one value, a symbolic constant indicating what action is taken when the stencil test passes
        /// and the depth test passes. The initial value is GL_KEEP. See glStencilOp. This stencil state only affects
        /// non-polygons and front-facing polygons. Back-facing polygons use separate stencil state. 
        /// See glStencilOpSeparate.
        /// </summary>
        GL_STENCIL_PASS_DEPTH_PASS = 0x0B96,


        /// <summary>
        /// data returns one value, the reference value that is compared with the contents of the stencil buffer. 
        /// The initial value is 0. See glStencilFunc. This stencil state only affects non-polygons and front-facing
        /// polygons. Back-facing polygons use separate stencil state. See glStencilFuncSeparate.
        /// </summary>
        GL_STENCIL_REF = 0x0B97,


        /// <summary>
        /// data returns a single boolean value indicating whether stencil testing of fragments is enabled. 
        /// The initial value is GL_FALSE. See glStencilFunc and glStencilOp.
        /// </summary>
        GL_STENCIL_TEST = 0x0B90,


        /// <summary>
        /// data returns one value, the mask that is used to mask both the stencil reference value and the stencil
        /// buffer value before they are compared. The initial value is all 1's. See glStencilFunc. 
        /// This stencil state only affects non-polygons and front-facing polygons. Back-facing polygons use 
        /// separate stencil state. See glStencilFuncSeparate.
        /// </summary>
        GL_STENCIL_VALUE_MASK = 0x0B93,


        /// <summary>
        /// data returns one value, the mask that controls writing of the stencil bitplanes. 
        /// The initial value is all 1's. See glStencilMask. This stencil state only affects non-polygons and 
        /// front-facing polygons. Back-facing polygons use separate stencil state. See glStencilMaskSeparate.
        /// </summary>
        GL_STENCIL_WRITEMASK = 0x0B98,


        /// <summary>
        /// data returns a single boolean value indicating whether stereo buffers (left and right) are supported.
        /// </summary>
        GL_STEREO = 0x0C33,


        /// <summary>
        /// data returns one value, an estimate of the number of bits of subpixel resolution that are used to 
        /// position rasterized geometry in window coordinates. The value must be at least 4.
        /// </summary>
        GL_SUBPIXEL_BITS = 0x0D50,


        /// <summary>
        /// data returns a single value, the name of the texture currently bound to the target GL_TEXTURE_1D. 
        /// The initial value is 0. See glBindTexture.
        /// </summary>
        GL_TEXTURE_BINDING_1D = 0x8068,


        /// <summary>
        /// data returns a single value, the name of the texture currently bound to the target GL_TEXTURE_1D_ARRAY. 
        /// The initial value is 0. See glBindTexture.
        /// </summary>
        GL_TEXTURE_BINDING_1D_ARRAY = 0x8C1C,


        /// <summary>
        /// data returns a single value, the name of the texture currently bound to the target GL_TEXTURE_2D. 
        /// The initial value is 0. See glBindTexture.
        /// </summary>
        GL_TEXTURE_BINDING_2D = 0x8069,


        /// <summary>
        /// data returns a single value, the name of the texture currently bound to the target GL_TEXTURE_2D_ARRAY. 
        /// The initial value is 0. See glBindTexture.
        /// </summary>
        GL_TEXTURE_BINDING_2D_ARRAY = 0x8C1D,


        /// <summary>
        /// data returns a single value, the name of the texture currently bound to the target GL_TEXTURE_2D_MULTISAMPLE. 
        /// The initial value is 0. See glBindTexture.
        /// </summary>
        GL_TEXTURE_BINDING_2D_MULTISAMPLE = 0x9104,


        /// <summary>
        /// data returns a single value, the name of the texture currently bound to the target 
        /// GL_TEXTURE_2D_MULTISAMPLE_ARRAY. The initial value is 0. See glBindTexture.
        /// </summary>
        GL_TEXTURE_BINDING_2D_MULTISAMPLE_ARRAY = 0x9105,


        /// <summary>
        /// data returns a single value, the name of the texture currently bound to the target GL_TEXTURE_3D. 
        /// The initial value is 0. See glBindTexture.
        /// </summary>
        GL_TEXTURE_BINDING_3D = 0x806A,


        /// <summary>
        /// data returns a single value, the name of the texture currently bound to the target GL_TEXTURE_BUFFER.
        /// The initial value is 0. See glBindTexture.
        /// </summary>
        GL_TEXTURE_BINDING_BUFFER = 0x8C2C,


        /// <summary>
        /// data returns a single value, the name of the texture currently bound to the target GL_TEXTURE_CUBE_MAP. 
        /// The initial value is 0. See glBindTexture.
        /// </summary>
        GL_TEXTURE_BINDING_CUBE_MAP = 0x8514,


        /// <summary>
        /// data returns a single value, the name of the texture currently bound to the target GL_TEXTURE_RECTANGLE.
        /// The initial value is 0. See glBindTexture.
        /// </summary>
        GL_TEXTURE_BINDING_RECTANGLE = 0x84F6,


        /// <summary>
        /// data returns a single value indicating the mode of the texture compression hint. 
        /// The initial value is GL_DONT_CARE.
        /// </summary>
        GL_TEXTURE_COMPRESSION_HINT = 0x84EF,


        /// <summary>
        /// data returns a single value, the minimum required alignment for texture buffer sizes and offset.
        /// The initial value is 1. See glUniformBlockBinding.
        /// </summary>
        GL_TEXTURE_BUFFER_OFFSET_ALIGNMENT = 0x919F,


        /// <summary>
        /// data returns a single value, the 64-bit value of the current GL time. See glQueryCounter.
        /// </summary>
        GL_TIMESTAMP = 0x8E28,


        /// <summary>
        /// When used with non-indexed variants of glGet (such as glGetIntegerv), data returns a single value, 
        /// the name of the buffer object currently bound to the target GL_TRANSFORM_FEEDBACK_BUFFER. 
        /// If no buffer object is bound to this target, 0 is returned. When used with indexed variants of glGet 
        /// (such as glGetIntegeri_v), data returns a single value, the name of the buffer object bound to the 
        /// indexed transform feedback attribute stream. The initial value is 0 for all targets. See glBindBuffer, 
        /// glBindBufferBase, and glBindBufferRange.
        /// </summary>
        GL_TRANSFORM_FEEDBACK_BUFFER_BINDING = 0x8C8F,


        /// <summary>
        /// When used with indexed variants of glGet (such as glGetInteger64i_v), data returns a single value, 
        /// the start offset of the binding range for each transform feedback attribute stream.
        /// The initial value is 0 for all streams. See glBindBufferRange.
        /// </summary>
        GL_TRANSFORM_FEEDBACK_BUFFER_START = 0x8C84,


        /// <summary>
        /// When used with indexed variants of glGet (such as glGetInteger64i_v), data returns a single value,
        /// the size of the binding range for each transform feedback attribute stream. The initial value is 0 
        /// for all streams. See glBindBufferRange.
        /// </summary>
        GL_TRANSFORM_FEEDBACK_BUFFER_SIZE = 0x8C85,


        /// <summary>
        /// When used with non-indexed variants of glGet (such as glGetIntegerv), data returns a single value, 
        /// the name of the buffer object currently bound to the target GL_UNIFORM_BUFFER. If no buffer object is 
        /// bound to this target, 0 is returned. When used with indexed variants of glGet (such as glGetIntegeri_v),
        /// data returns a single value, the name of the buffer object bound to the indexed uniform buffer binding point. 
        /// The initial value is 0 for all targets. See glBindBuffer, glBindBufferBase, and glBindBufferRange.
        /// </summary>
        GL_UNIFORM_BUFFER_BINDING = 0x8A28,


        /// <summary>
        /// data returns a single value, the minimum required alignment for uniform buffer sizes and offset. 
        /// The initial value is 1. See glUniformBlockBinding.
        /// </summary>
        GL_UNIFORM_BUFFER_OFFSET_ALIGNMENT = 0x8A34,


        /// <summary>
        /// When used with indexed variants of glGet (such as glGetInteger64i_v), data returns a single value, 
        /// the size of the binding range for each indexed uniform buffer binding. 
        /// The initial value is 0 for all bindings. See glBindBufferRange.
        /// </summary>
        GL_UNIFORM_BUFFER_SIZE = 0x8A2A,


        /// <summary>
        /// When used with indexed variants of glGet (such as glGetInteger64i_v), data returns a single value, 
        /// the start offset of the binding range for each indexed uniform buffer binding. The initial value is 
        /// 0 for all bindings. See glBindBufferRange.
        /// </summary>
        GL_UNIFORM_BUFFER_START = 0x8A29,


        /// <summary>
        /// data returns one value, the byte alignment used for reading pixel data from memory. 
        /// The initial value is 4. See glPixelStore.
        /// </summary>
        GL_UNPACK_ALIGNMENT = 0x0CF5,


        /// <summary>
        /// data returns one value, the image height used for reading pixel data from memory. 
        /// The initial is 0. See glPixelStore.
        /// </summary>
        GL_UNPACK_IMAGE_HEIGHT = 0x806E,


        /// <summary>
        /// data returns a single boolean value indicating whether single-bit pixels being read from memory
        /// are read first from the least significant bit of each unsigned byte. The initial value is GL_FALSE. 
        /// See glPixelStore.
        /// </summary>
        GL_UNPACK_LSB_FIRST = 0x0CF1,


        /// <summary>
        /// data returns one value, the row length used for reading pixel data from memory. The initial value is 0.
        /// See glPixelStore.
        /// </summary>
        GL_UNPACK_ROW_LENGTH = 0x0CF2,


        /// <summary>
        /// data returns one value, the number of pixel images skipped before the first pixel is read from memory. 
        /// The initial value is 0. See glPixelStore.
        /// </summary>
        GL_UNPACK_SKIP_IMAGES = 0x806D,


        /// <summary>
        /// data returns one value, the number of pixel locations skipped before the first pixel is read from memory. 
        /// The initial value is 0. See glPixelStore.
        /// </summary>
        GL_UNPACK_SKIP_PIXELS = 0x0CF4,


        /// <summary>
        /// data returns one value, the number of rows of pixel locations skipped before the first pixel is read 
        /// from memory. The initial value is 0. See glPixelStore.
        /// </summary>
        GL_UNPACK_SKIP_ROWS = 0x0CF3,


        /// <summary>
        /// data returns a single boolean value indicating whether the bytes of two-byte and four-byte pixel
        /// indices and components are swapped after being read from memory. The initial value is GL_FALSE. 
        /// See glPixelStore.
        /// </summary>
        GL_UNPACK_SWAP_BYTES = 0x0CF0,


        /// <summary>
        /// data returns a single value, the name of the vertex array object currently bound to the context. 
        /// If no vertex array object is bound to the context, 0 is returned. The initial value is 0.
        /// See glBindVertexArray.
        /// </summary>
        GL_VERTEX_ARRAY_BINDING = 0x85B5,


        /// <summary>
        /// Accepted by the indexed forms. data returns a single integer value representing the instance step 
        /// divisor of the first element in the bound buffer's data store for vertex attribute bound to index.
        /// </summary>
        GL_VERTEX_BINDING_DIVISOR = 0x82D6,


        /// <summary>
        /// Accepted by the indexed forms. data returns a single integer value representing the byte offset 
        /// of the first element in the bound buffer's data store for vertex attribute bound to index.
        /// </summary>
        GL_VERTEX_BINDING_OFFSET = 0x82D7,


        /// <summary>
        /// Accepted by the indexed forms. data returns a single integer value representing the byte offset 
        /// between the start of each element in the bound buffer's data store for vertex attribute bound to index.
        /// </summary>
        GL_VERTEX_BINDING_STRIDE = 0x82D8,


        /// <summary>
        /// Accepted by the indexed forms. data returns a single integer value representing the name of the 
        /// buffer bound to vertex binding index.
        /// </summary>
        GL_VERTEX_BINDING_BUFFER = 0x8F4F,


        /// <summary>
        /// data returns a single integer value containing the maximum offset that may be added to a vertex 
        /// binding offset.
        /// </summary>
        GL_MAX_VERTEX_ATTRIB_RELATIVE_OFFSET = 0x82D9,


        /// <summary>
        /// data returns a single integer value containing the maximum number of vertex buffers that may be bound.
        /// </summary>
        GL_MAX_VERTEX_ATTRIB_BINDINGS = 0x82DA,


        /// <summary>
        /// When used with non-indexed variants of glGet (such as glGetIntegerv), data returns four values: 
        /// the x and y window coordinates of the viewport, followed by its width and height. 
        /// Initially the x and y window coordinates are both set to 0, and the width and height are set to 
        /// the width and height of the window into which the GL will do its rendering. See glViewport.
        /// 
        /// When used with indexed variants of glGet(such as glGetIntegeri_v), data returns four values: 
        /// the x and y window coordinates of the indexed viewport, followed by its width and height.
        /// Initially the x and y window coordinates are both set to 0, and the width and height are set to 
        /// the width and height of the window into which the GL will do its rendering. See glViewportIndexedf.
        /// </summary>
        GL_VIEWPORT = 0x0BA2,


        /// <summary>
        /// data returns two values, the minimum and maximum viewport bounds range.The minimum range should be at 
        /// least[-32768, 32767].
        /// </summary>
        GL_VIEWPORT_BOUNDS_RANGE = 0x825D,


        /// <summary>
        /// data returns one value, the implementation dependent specifc vertex of a primitive that is used to
        /// select the viewport index. If the value returned is equivalent to GL_PROVOKING_VERTEX, 
        /// then the vertex selection follows the convention specified by glProvokingVertex. 
        /// If the value returned is equivalent to GL_FIRST_VERTEX_CONVENTION, then the selection is always 
        /// taken from the first vertex in the primitive. If the value returned is equivalent to 
        /// GL_LAST_VERTEX_CONVENTION, then the selection is always taken from the last vertex in the primitive. 
        /// If the value returned is equivalent to GL_UNDEFINED_VERTEX, then the selection is not guaranteed to
        /// be taken from any specific vertex in the primitive.
        /// </summary>
        GL_VIEWPORT_INDEX_PROVOKING_VERTEX = 0x825F,


        /// <summary>
        /// data returns a single value, the number of bits of sub - pixel precision which the GL uses to 
        /// interpret the floating point viewport bounds. The minimum value is 0.
        /// </summary>
        GL_VIEWPORT_SUBPIXEL_BITS = 0x825C,


        /// <summary>
        /// data returns a single value, the maximum index that may be specified during the transfer of 
        /// generic vertex attributes to the GL.
        /// </summary>
        GL_MAX_ELEMENT_INDEX = 0x8D6B,

        /// <summary>
        /// 
        /// </summary>
        GL_DEBUG_LOGGED_MESSAGES = 0x9145,

        GL_DEBUG_NEXT_LOGGED_MESSAGE_LENGTH = 0x8243,

        GL_MAX_DEBUG_MESSAGE_LENGTH = 0x9143,
        GL_MAX_DEBUG_LOGGED_MESSAGES = 0x9144
    }

    /// <summary>
    /// glGetString returns a pointer to a static string describing some aspect of the current GL connection.
    /// </summary>
    public enum CurrentConnectionInfo
    {
        /// <summary>
        /// Returns the company responsible for this GL implementation. This name does not change from release to release.
        /// </summary>
        GL_VENDOR = 0x1F00,

        /// <summary>
        /// Returns the name of the renderer. This name is typically specific to a particular configuration of a hardware platform. 
        /// It does not change from release to release.
        /// </summary>
        GL_RENDERER = 0x1F01,

        /// <summary>
        /// Returns a version or release number.
        /// </summary>
        GL_VERSION = 0x1F02,

        /// <summary>
        /// Returns a version or release number for the shading language.
        /// </summary>
        GL_SHADING_LANGUAGE_VERSION = 0x8B8C,

        /// <summary>
        /// For glGetStringi only, returns the extension string supported by the implementation at index.
        /// </summary>
        GL_EXTENSIONS = 0x1F03,

    }

    public enum ErrorSources
    {
        GL_DONT_CARE = 0x1100,
        GL_DEBUG_SOURCE_API = 0x8246,
        GL_DEBUG_SOURCE_WINDOW_SYSTEM = 0x8247,
        GL_DEBUG_SOURCE_SHADER_COMPILER = 0x8248,
        GL_DEBUG_SOURCE_THIRD_PARTY = 0x8249,
        GL_DEBUG_SOURCE_APPLICATION = 0x824A,
        GL_DEBUG_SOURCE_OTHER = 0x824B

    }

    public enum ErrorType
    {
        GL_DONT_CARE = 0x1100,
        GL_DEBUG_TYPE_ERROR = 0x824C,
        GL_DEBUG_TYPE_DEPRECATED_BEHAVIOR = 0x824D,
        GL_DEBUG_TYPE_UNDEFINED_BEHAVIOR = 0x824E,
        GL_DEBUG_TYPE_PORTABILITY = 0x824F,
        GL_DEBUG_TYPE_PERFORMANCE = 0x8250,
        GL_DEBUG_TYPE_OTHER = 0x8251

    }

    public enum ErrorSeverity
    {
        GL_DONT_CARE = 0x1100,
        GL_DEBUG_SEVERITY_HIGH = 0x9146,
        GL_DEBUG_SEVERITY_MEDIUM = 0x9147,
        GL_DEBUG_SEVERITY_LOW = 0x9148,
        GL_DEBUG_SEVERITY_NOTIFICATION = 0x0000826B

    }

    public enum MatrixModes
    {
        /// <summary>
        /// Applies subsequent matrix operations to the modelview matrix stack.
        /// </summary>
        GL_MODELVIEW = 0x1700,

        /// <summary>
        /// Applies subsequent matrix operations to the projection matrix stack.
        /// </summary>
        GL_PROJECTION = 0x1701,

        /// <summary>
        /// Applies subsequent matrix operations to the texture matrix stack.
        /// </summary>
        GL_TEXTURE = 0x1702,

        /// <summary>
        /// Applies subsequent matrix operations to the color matrix stack.
        /// </summary>
        GL_COLOR = 0x1800
    }

    public enum FrameBufferTargets
    {
        GL_DRAW_FRAMEBUFFER = 0x8CA9,
        GL_READ_FRAMEBUFFER = 0x8CA8,
        GL_FRAMEBUFFER = 0x8D40
    }

    public enum RenderBufferTargets
    {
        GL_RENDERBUFFER = 0x8D41
    }

    public enum RenderBufferAttachments
    {
        GL_COLOR_ATTACHMENT0 = 0x8CE0,
        GL_COLOR_ATTACHMENT1 = 0x8CE1,
        GL_COLOR_ATTACHMENT2 = 0x8CE2,
        GL_COLOR_ATTACHMENT3 = 0x8CE3,
        GL_COLOR_ATTACHMENT4 = 0x8CE4,
        GL_COLOR_ATTACHMENT5 = 0x8CE5,
        GL_COLOR_ATTACHMENT6 = 0x8CE6,
        GL_COLOR_ATTACHMENT7 = 0x8CE7,
        GL_COLOR_ATTACHMENT8 = 0x8CE8,
        GL_COLOR_ATTACHMENT9 = 0x8CE9,
        GL_COLOR_ATTACHMENT10 = 0x8CEA,
        GL_COLOR_ATTACHMENT11 = 0x8CEB,
        GL_COLOR_ATTACHMENT12 = 0x8CEC,
        GL_COLOR_ATTACHMENT13 = 0x8CED,
        GL_COLOR_ATTACHMENT14 = 0x8CEE,
        GL_COLOR_ATTACHMENT15 = 0x8CEF,
        GL_COLOR_ATTACHMENT16 = 0x8CF0,
        GL_COLOR_ATTACHMENT17 = 0x8CF1,
        GL_COLOR_ATTACHMENT18 = 0x8CF2,
        GL_COLOR_ATTACHMENT19 = 0x8CF3,
        GL_COLOR_ATTACHMENT20 = 0x8CF4,
        GL_COLOR_ATTACHMENT21 = 0x8CF5,
        GL_COLOR_ATTACHMENT22 = 0x8CF6,
        GL_COLOR_ATTACHMENT23 = 0x8CF7,
        GL_COLOR_ATTACHMENT24 = 0x8CF8,
        GL_COLOR_ATTACHMENT25 = 0x8CF9,
        GL_COLOR_ATTACHMENT26 = 0x8CFA,
        GL_COLOR_ATTACHMENT27 = 0x8CFB,
        GL_COLOR_ATTACHMENT28 = 0x8CFC,
        GL_COLOR_ATTACHMENT29 = 0x8CFD,
        GL_COLOR_ATTACHMENT30 = 0x8CFE,
        GL_COLOR_ATTACHMENT31 = 0x8CFF,
        GL_DEPTH_ATTACHMENT = 0x8D00,
        GL_DEPTH_STENCIL_ATTACHMENT = 0x821A
    }

    public enum FrameBufferStatuses
    {
        /// <summary>
        /// if the specified framebuffer is complete. Otherwise, the return value is determined as follows:
        /// </summary>
        GL_FRAMEBUFFER_COMPLETE = 0x8CD5,
        /// <summary>
        /// is returned if the specified framebuffer is the default read or draw framebuffer, but the default framebuffer does not exist.
        /// </summary>
        GL_FRAMEBUFFER_UNDEFINED = 0x8219,

        /// <summary>
        /// is returned if any of the framebuffer attachment points are framebuffer incomplete.
        /// </summary>
        GL_FRAMEBUFFER_INCOMPLETE_ATTACHMENT = 0x8CD6,

        /// <summary>
        /// is returned if the framebuffer does not have at least one image attached to it.
        /// </summary>
        GL_FRAMEBUFFER_INCOMPLETE_MISSING_ATTACHMENT = 0x8CD7,

        /// <summary>
        /// is returned if the value of GL_FRAMEBUFFER_ATTACHMENT_OBJECT_TYPE is GL_NONE for any color attachment point(s) named by GL_DRAW_BUFFERi.
        /// </summary>
        GL_FRAMEBUFFER_INCOMPLETE_DRAW_BUFFER = 0x8CDB,

        /// <summary>
        ///  is returned if GL_READ_BUFFER is not GL_NONE and the value of GL_FRAMEBUFFER_ATTACHMENT_OBJECT_TYPE is GL_NONE for the color attachment point named by GL_READ_BUFFER.
        /// </summary>
        GL_FRAMEBUFFER_INCOMPLETE_READ_BUFFER = 0x8CDC,

        /// <summary>
        /// is returned if the combination of internal formats of the attached images violates an implementation-dependent set of restrictions.
        /// </summary>
        GL_FRAMEBUFFER_UNSUPPORTED = 0x8CDD,

        /// <summary>
        /// is returned if the value of GL_RENDERBUFFER_SAMPLES is not the same for all attached renderbuffers; if the value of GL_TEXTURE_SAMPLES is the not same for all attached textures; or, if the attached images are a mix of renderbuffers and textures, the value of GL_RENDERBUFFER_SAMPLES does not match the value of GL_TEXTURE_SAMPLES.
        /// is not the same for all attached textures; or, if the attached images are a mix of renderbuffers and textures, the value of GL_TEXTURE_FIXED_SAMPLE_LOCATIONS is not GL_TRUE for all attached textures. 
        /// is also returned if the value of GL_TEXTURE_FIXED_SAMPLE_LOCATIONS 
        /// </summary>
        GL_FRAMEBUFFER_INCOMPLETE_MULTISAMPLE = 0x8D56,

        /// <summary>
        /// is returned if any framebuffer attachment is layered, and any populated attachment is not layered, or if all populated color attachments are not from textures of the same target.
        /// </summary>
        GL_FRAMEBUFFER_INCOMPLETE_LAYER_TARGETS = 0x8DA8
    }
}
