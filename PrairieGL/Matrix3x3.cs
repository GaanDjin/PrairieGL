using System.Numerics;

namespace PrairieGL
{
    /// <summary>
    /// A structure encapsulating a 3x3 matrix.
    /// </summary>
    /// <remarks>
    /// Most of this class is from the following sources:
    /// https://chromium.googlesource.com/external/github.com/g-truc/glm/+/refs/heads/master/glm/detail/type_mat3x3.hpp
    /// https://chromium.googlesource.com/external/github.com/g-truc/glm/+/refs/heads/master/glm/detail/type_mat3x3.inl
    /// https://github.com/opentk/opentk/blob/master/src/OpenTK.Mathematics/Matrix/Matrix3.cs
    /// https://github.com/sharpdx/SharpDX/blob/master/Source/SharpDX.Mathematics/Matrix3x3.cs
    /// https://github.com/microsoft/referencesource/blob/master/System.Numerics/System/Numerics/Matrix4x4.cs
    /// </remarks>
    public struct Matrix3x3 : IEquatable<Matrix3x3>
    {
        #region Public Fields
        /// <summary>
        /// Value at row 1, column 1 of the matrix.
        /// </summary>
        public float M11;
        /// <summary>
        /// Value at row 1, column 2 of the matrix.
        /// </summary>
        public float M12;
        /// <summary>
        /// Value at row 1, column 3 of the matrix.
        /// </summary>
        public float M13;

        /// <summary>
        /// Value at row 2, column 1 of the matrix.
        /// </summary>
        public float M21;
        /// <summary>
        /// Value at row 2, column 2 of the matrix.
        /// </summary>
        public float M22;
        /// <summary>
        /// Value at row 2, column 3 of the matrix.
        /// </summary>
        public float M23;

        /// <summary>
        /// Value at row 3, column 1 of the matrix.
        /// </summary>
        public float M31;
        /// <summary>
        /// Value at row 3, column 2 of the matrix.
        /// </summary>
        public float M32;
        /// <summary>
        /// Value at row 3, column 3 of the matrix.
        /// </summary>
        public float M33;
        #endregion Public Fields

        private static readonly Matrix3x3 _identity = new Matrix3x3
        (
            1f, 0f, 0f,
            0f, 1f, 0f,
            0f, 0f, 1f
        );

        /// <summary>
        /// Returns the multiplicative identity matrix.
        /// </summary>
        public static Matrix3x3 Identity
        {
            get { return _identity; }
        }

        /// <summary>
        /// Returns whether the matrix is the identity matrix.
        /// </summary>
        public bool IsIdentity
        {
            get
            {
                return M11 == 1f && M22 == 1f && M33 == 1f && // Check diagonal element first for early out.
                                    M12 == 0f && M13 == 0f &&
                       M21 == 0f && M23 == 0f &&
                       M31 == 0f && M32 == 0f;
            }
        }

        /// <summary>
        /// Constructs a Matrix3x3 from the given components.
        /// </summary>
        ///
        public Matrix3x3(float m11, float m12, float m13,
                         float m21, float m22, float m23,
                         float m31, float m32, float m33)
        {
            this.M11 = m11;
            this.M12 = m12;
            this.M13 = m13;

            this.M21 = m21;
            this.M22 = m22;
            this.M23 = m23;

            this.M31 = m31;
            this.M32 = m32;
            this.M33 = m33;
        }

        /// <summary>
        /// Creates a Matrix3x3 using the first 3 rows and columns from a Matrix4x4
        /// </summary>
        /// <param name="matrix">The Matrix to copy</param>
        public Matrix3x3(Matrix4x4 matrix)
        {
            this.M11 = matrix.M11;
            this.M12 = matrix.M12;
            this.M13 = matrix.M13;

            this.M21 = matrix.M21;
            this.M22 = matrix.M22;
            this.M23 = matrix.M23;

            this.M31 = matrix.M31;
            this.M32 = matrix.M32;
            this.M33 = matrix.M33;
        }

        /// <summary>
        /// Creates an array from this Matrix. 
        /// By row order.
        /// </summary>
        /// <returns>An array containing the matrix values</returns>
        public float[] ToArray()
        {
            return new float[] {
                        this.M11, this.M12, this.M13,
                        this.M21, this.M22, this.M23,
                        this.M31, this.M32, this.M33
                    };
        }


        /// <summary>
        /// Returns a boolean indicating whether this matrix instance is equal to the other given matrix.
        /// </summary>
        /// <param name="other">The matrix to compare this instance to.</param>
        /// <returns>True if the matrices are equal; False otherwise.</returns>
        public bool Equals(Matrix3x3 other)
        {
            return (M11 == other.M11 && M22 == other.M22 && M33 == other.M33 &&  // Check diagonal element first for early out.
                                        M12 == other.M12 && M13 == other.M13 && 
                    M21 == other.M21 && M23 == other.M23 && 
                    M31 == other.M31 && M32 == other.M32);
        }

        /// <summary>
        /// Returns a boolean indicating whether the given Object is equal to this matrix instance.
        /// </summary>
        /// <param name="obj">The Object to compare against.</param>
        /// <returns>True if the Object is equal to this matrix; False otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Matrix3x3)
            {
                return Equals((Matrix3x3)obj);
            }

            return false;
        }

        /// <summary>
        /// Returns a String representing this matrix instance.
        /// </summary>
        /// <returns>The string representation.</returns>
        public override string ToString()
        {
            return string.Format("{{ {{M11:{0} M12:{1} M13:{2}}} {{M21:{4} M22:{5} M23:{6}}} {{M31:{8} M32:{9} M33:{10}}} }}",
                                 M11.ToString(), M12.ToString(), M13.ToString(), 
                                 M21.ToString(), M22.ToString(), M23.ToString(), 
                                 M31.ToString(), M32.ToString(), M33.ToString()
                                 );
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>The hash code.</returns>
        public override int GetHashCode()
        {
            return M11.GetHashCode() + M12.GetHashCode() + M13.GetHashCode() + 
                   M21.GetHashCode() + M22.GetHashCode() + M23.GetHashCode() + 
                   M31.GetHashCode() + M32.GetHashCode() + M33.GetHashCode();
        }
    }
}