using System;

namespace ExploringHexidecimals
{
    public static class HexOps
    {
        public static byte TwoHexToOneByte(UInt16 Hex1, UInt16 Hex2)
        {
            UInt16 H1 = (UInt16)((int)Hex1 % (int)16);
            UInt16 H2 = (UInt16)((int)Hex1 % (int)16);
            // 1000 and 0000 1000 are bit representations of numbers
            byte B1 = (byte)H1;             // ex: 1000
            byte B2 = (byte)H2;             // ex: 1000

            byte result = (byte)(B1 << 4);  // ex: 1000 shifts right to 1000 0000
            result = (Byte)(result + B2);   // ex: 1000 looks like 0000 1000 in a byte
            return result;
        }

        public static Tuple<UInt16, UInt16> OneByteToTwoHex(byte ByteToSplit)
        {
            // 1000 and 0000 1000 are bit representations of numbers
            byte B = ByteToSplit;       // ex: 1000 1000
            byte B2 = (byte)(B << 4);   // ex: 1000 1000 shifts left to  1000 000
            B2 = (byte)(B2 >> 4);       // ex: 1000 0000 shifts right to 0000 1000
            byte B1 = (byte)(B >> 4);   // ex: 1000 1000 shifts right to 0000 1000 
 
            return new Tuple<ushort, ushort>(B1, B2);
        }
    }
}
