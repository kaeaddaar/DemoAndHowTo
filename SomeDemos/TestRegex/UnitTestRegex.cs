using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
using libRegex;


namespace TestRegex
{
    [TestClass]
    public class UnitTestRegex
    {
        [TestMethod]
        public void TestPhoneNumberRegex()
        {
            string ToTest = @"+250 486-7712
+250-486-7712
250-486-7712, 250 486 7712, +250-486-7712
250-48507712"; // this line isn't a phone number due to the 7 characters instead of 3 then 4
            MatchCollection Col = RegexExpressions.GetPhoneNumbers(ToTest);
            Assert.AreEqual(5, Col.Count);
            Assert.AreEqual("+250 486-7712", Col[0].Value);
            Assert.AreEqual("+250-486-7712", Col[1].Value);
            Assert.AreEqual("250-486-7712", Col[2].Value);
            Assert.AreEqual("250 486 7712", Col[3].Value);
            Assert.AreEqual("+250-486-7712", Col[4].Value);
        }

        [TestMethod]
        public void TestFindTextInBrackets()
        {
            string ToTest = @"abc123(hello), asdlf;kj(world)";
            MatchCollection Col = RegexExpressions.GetTextFromBracketToBracket(ToTest);
            Assert.AreEqual(2, Col.Count);
            Assert.AreEqual("(hello)", Col[0].Value);
            Assert.AreEqual("(world)", Col[1].Value);
        }
    }
}
