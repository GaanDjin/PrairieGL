using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrairieGL.Utils.NanoJpeg
{
    internal sealed class ChannelData
    {
        public int Cid;
        public int Ssx;
        public int Ssy;
        public int Width;
        public int Height;
        public int Stride;
        public int Qtsel;
        public int Actabsel;
        public int Dctabsel;
        public int Dcpred;
        public byte[] Pixels;
    }
}
