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

        }
    }
}
