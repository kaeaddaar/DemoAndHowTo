using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExploringHexidecimals;
using System;

namespace TestExploringHexidecimals
{
    [TestClass]
    public class UnitTestExploringHexidecimals
    {
        [TestMethod]
        public void CombineTwoHexIntoOneBye()
        {
            // 1000 = 2^3 = 8
            // 1000 0000 = 2^(3+4) = 2^7 = 128
            // 1000 1000 = 2^7 + 2^3 = 128 + 8 = 136
            UInt16 Hex1 = 8;
            UInt16 Hex2 = 8;
            byte B = HexOps.TwoHexToOneByte(Hex1, Hex2);

            int Result = (int)B;
            Assert.AreEqual(136, Result);
        }

        [TestMethod]
        public void SeparateOneByteIntoTwoHex()
        {
            // 1000 = 2^3 = 8
            // 1000 0000 = 2^(3+4) = 2^7 = 128
            // 1000 1000 = 2^7 + 2^3 = 128 + 8 = 136
            byte B = (byte)136;
            UInt16 Hex1;
            UInt16 Hex2;
            Tuple<UInt16, UInt16> TwoHexes = HexOps.OneByteToTwoHex(B);
            Hex1 = TwoHexes.Item1;
            Hex2 = TwoHexes.Item2;
            Assert.AreEqual(8, Hex1);
            Assert.AreEqual(8, Hex2);
        }
    }
}
