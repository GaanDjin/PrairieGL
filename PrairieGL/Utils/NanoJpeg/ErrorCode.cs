using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrairieGL.Utils.NanoJpeg
{
    /// <summary>
    /// Error codes for decoding errors
    /// </summary>
    public enum ErrorCode
    {
        /// <summary>
        /// Not a JPEG file
        /// </summary>
        NoJpeg,

        /// <summary>
        /// Unsupported format
        /// </summary>
        Unsupported,

        /// <summary>
        /// Internal error
        /// </summary>
        InternalError,

        /// <summary>
        /// Syntax error
        /// </summary>
        SyntaxError,
    }
}
