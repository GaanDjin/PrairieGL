using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrairieGL.Utils
{
    /// <summary>
    /// My attept at reading a Huffman tree for a custom decode stream.
    /// </summary>
    public class HuffmanTree
    {
        //public static HuffmanTree buildFromJFIFDHTSegment(byte[] segment)
        //{
        //    //HuffmanTable m_huffmanTable[2][2]
        //}

        //static void parseDHTSegment()
        //{
        //    //HuffmanTable[][] m_huffmanTable = new HuffmanTable[2][2];

        //    KeyValuePair<int, List<byte>>[] HuffmanTable = new KeyValuePair<int, List<byte>>[16];

        //    //if (!m_imageFile.is_open() || !m_imageFile.good())
        //    //{
        //    //    logFile << "Unable scan image file: \'" + m_filename + "\'" << "\n";
        //    //    return;
        //    //}

        //    string logFile = "Parsing Huffman table segment...\n";

        //    UInt16 len;
        //    m_imageFile.read(reinterpret_cast<char*>(&len), 2);
        //    len = htons(len);

        //    logFile += "Huffman table length: " + (int)len + "\n";

        //    int segmentEnd = (int)m_imageFile.tellg() + len - 2;

        //    while (m_imageFile.tellg() < segmentEnd)
        //    {
        //        byte htinfo = 0;
        //        m_imageFile += htinfo;

        //        int HTType = (int)((htinfo & 0x10) >> 4);
        //        int HTNumber = (int)(htinfo & 0x0F);

        //        logFile += "Huffman table type: " + HTType + "\n";
        //        logFile += "Huffman table #: " + HTNumber + "\n";

        //        int totalSymbolCount = 0;
        //        byte symbolCount;

        //        for (int i = 1; i <= 16; ++i)
        //        {
        //            m_imageFile >> std::noskipws >> symbolCount;
        //            m_huffmanTable[HTType][HTNumber][i - 1].first = (int)symbolCount;
        //            totalSymbolCount += (int)symbolCount;
        //        }

        //        // Load the symbols
        //        int syms = 0;
        //        for (int i = 0; syms < totalSymbolCount;)
        //        {
        //            // Read the next symbol, and add it to the
        //            // proper slot in the Huffman table.
        //            //
        //            // Depndending upon the symbol count, say n, for the current
        //            // symbol length, insert the next n symbols in the symbol
        //            // list to it's proper spot in the Huffman table. This means,
        //            // if symbol counts for symbols of lengths 1, 2 and 3 are 0,
        //            // 5 and 2 respectively, the symbol list will contain 7
        //            // symbols, out of which the first 5 are symbols with length
        //            // 2, and the remaining 2 are of length 3.
        //            byte code;
        //            m_imageFile = code;

        //            if (m_huffmanTable[HTType][HTNumber][i].first == 0)
        //            {
        //                while (m_huffmanTable[HTType][HTNumber][++i].first == 0) ;
        //            }

        //            m_huffmanTable[HTType][HTNumber][i].second.push_back(code);
        //            syms++;

        //            if (m_huffmanTable[HTType][HTNumber][i].first == m_huffmanTable[HTType][HTNumber][i].second.size())
        //                i++;
        //        }

        //        logFile += "Printing symbols for Huffman table (" + HTType + "," + HTNumber + ")..." + "\n";

        //        int totalCodes = 0;
        //        for (int i = 0; i < 16; ++i)
        //        {
        //            string codeStr = "";
        //            foreach (int symbol in m_huffmanTable[HTType][HTNumber][i].Values)
        //            {
        //                string ss = "0x" + symbol.ToString("X");
        //                codeStr += ss + " ";
        //                totalCodes++;
        //            }

        //            logFile += "Code length: " + (i + 1)
        //                                    + ", Symbol count: " + m_huffmanTable[HTType][HTNumber][i].second.size()
        //                                    + ", Symbols: " + codeStr + "\n";
        //        }

        //        logFile += "Total Huffman codes for Huffman table(Type:" + HTType + ",#:" + HTNumber + "): " + totalCodes + "\n";

        //        m_huffmanTree[HTType][HTNumber].constructHuffmanTree(m_huffmanTable[HTType][HTNumber]);
        //        auto htree = m_huffmanTree[HTType][HTNumber].getTree();
        //        logFile += "Huffman codes:-" + "\n";
        //        htree.inOrder();
        //    }

        //    logFile += "Finished parsing Huffman table segment [OK]" + "\n";
        //}

        public byte[] Decode(byte[] encodedBits)
        {
            throw new NotImplementedException();
        }

        // The number of bits left in the queue, and the value represented
        int queueLen = 0;
        uint queueVal = 0;

        int fp;

        ushort readBits(byte[] encodedBits, int len)
        {

            byte readByte;
            ushort output;

            if (len > queueLen)
            {
                do
                {
                    // Read a byte in, shift it up to join the queue
                    readByte = encodedBits[fp];
                    queueVal = (uint)(queueVal | (uint)(readByte << (24 - queueLen)));
                    queueLen += 8;
                } while (len > queueLen);
            }

            // Shift the requested number of bytes down to the other end
            output = (ushort)(((queueVal >> (32 - len)) & ((1 << len) - 1)));

            queueLen -= len;
            queueVal <<= len;

            return output;
        }

        public class Node
        {
            /// <summary>
            /// indiciates whether the node is a root node
            /// </summary>
            public bool IsRoot { get { return Parent == null; } }

            /// <summary>
            /// indicates whether the node is a leaf node
            /// </summary>
            public bool IsLeaf { get { return LeftChild == null && RightChild == null; } }

            /// <summary>
            /// The Huffman code corresponding to the node
            /// </summary>
            public string Code;

            /// <summary>
            /// The symbol value of a leaf node in the Huffman tree
            /// </summary>
            public ushort Value;

            /// <summary>
            /// Left child of the node
            /// </summary>
            public Node LeftChild;

            /// <summary>
            /// Right child of the node
            /// </summary>
            public Node RightChild;

            /// <summary>
            /// Parent of the node
            /// </summary>
            public Node Parent;
        }

        public struct HuffKey
        {
            public int Length;
            public ushort Code;

            public HuffKey(int len, ushort code)
            {
                Length = len;
                Code = code;
            }
        }
    }
}
