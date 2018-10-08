using System;
using System.Text.RegularExpressions;


namespace libRegex
{
    public static class RegexExpressions
    {
        // /(\+?[0-9]{3})(-| )([0-9]{3})(-| )([0-9]{4})/g
        //const string PhoneNumberExpression = "/" + @"(\+?[0-9]{3})" + @"( |-)" + @"([0-9]{3})" + @"( |-)" + @"([0-9]{4})" + "/g";
        const string PhoneNumberExpression = @"(\+?[0-9]{3})" + @"( |-)" + @"([0-9]{3})" + @"( |-)" + @"([0-9]{4})";
        public static MatchCollection GetPhoneNumbers(string MayContainPhoneNumbers)
        {
            // can I check to see if the expression validates?
            Regex R = new Regex(PhoneNumberExpression);
            MatchCollection M = R.Matches(MayContainPhoneNumbers);
            return M;
        }
    }
}
