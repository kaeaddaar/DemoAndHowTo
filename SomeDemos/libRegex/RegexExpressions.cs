using System;
using System.Text.RegularExpressions;


namespace libRegex
{
    public static class RegexExpressions
    {
        // /(\+?[0-9]{3})(-| )([0-9]{3})(-| )([0-9]{4})/g    note that the opening / and following /g are not needed
        //const string PhoneNumberExpression = "/" + @"(\+?[0-9]{3})" + @"( |-)" + @"([0-9]{3})" + @"( |-)" + @"([0-9]{4})" + "/g";
        const string PhoneNumberExpression = @"(\+?[0-9]{3})" + @"( |-)" + @"([0-9]{3})" + @"( |-)" + @"([0-9]{4})";
        const string BracketContentExpression = @"([(])(\w)+([)])";

        public static MatchCollection GetPhoneNumbers(string MayContainPhoneNumbers)
        {
            // can I check to see if the expression validates?
            Regex R = new Regex(PhoneNumberExpression);
            MatchCollection M = R.Matches(MayContainPhoneNumbers);
            return M;
        }

        public static MatchCollection GetTextFromBracketToBracket(string MayContainBracketPairs)
        {
            Regex R = new Regex(BracketContentExpression);
            MatchCollection M = R.Matches(MayContainBracketPairs);
            return M;
        }
    }
}
