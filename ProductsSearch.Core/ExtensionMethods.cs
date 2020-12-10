namespace ProductsSearch.Core
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public static class ExtensionMethods
    {
        public static bool IsPalindrome(this string strToCheck)
        {
            if (string.IsNullOrWhiteSpace(strToCheck))
                return false;

            string input = strToCheck.ToLower().Replace(" ", "");
            return input.SequenceEqual(input.Reverse());
        }

        public static bool IsAlphaNumeric(this string strToCheck)
        {
            if (string.IsNullOrWhiteSpace(strToCheck))
                return false;

            Regex objAlphaNumericPattern = new Regex(@"^[A-Za-z0-9 ]+$");
            return objAlphaNumericPattern.IsMatch(strToCheck);
        }
    }
}
