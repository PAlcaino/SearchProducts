namespace ProductsSearch.Core.Tests
{
    using Xunit;

    public class ExtensionMethodsTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("   ")]
        public void IsPalindrome_Invalid_String_Should_Return_False(string stringToTest)
        {
            //// Assert
            Assert.False(stringToTest.IsPalindrome());
        }

        [Theory]
        [InlineData("ab")]
        [InlineData("test")]
        [InlineData("test test")]
        public void IsPalindrome_Non_Palindrome_String_Should_Return_False(string stringToTest)
        {
            //// Assert
            Assert.False(stringToTest.IsPalindrome());
        }

        [Theory]
        [InlineData("anA")]
        [InlineData("Amadaladama")]
        [InlineData("AmimeMima")]
        public void IsPalindrome_Palindrome_String_Should_Ignore_Case(string stringToTest)
        {
            //// Assert
            Assert.True(stringToTest.IsPalindrome());
        }

        [Theory]
        [InlineData("an a")]
        [InlineData("Amad a la dama")]
        [InlineData("A mi me mima")]
        public void IsPalindrome_Palindrome_String_Should_Ignore_White_Spaces(string stringToTest)
        {
            //// Assert
            Assert.True(stringToTest.IsPalindrome());
        }

        [Theory]
        [InlineData("abcd")]
        [InlineData("ABCD")]
        [InlineData("ABC123")]
        [InlineData("123456")]
        public void IsAlphanumeric_Alphanumeric_Strings_Should_Return_True(string stringToTest)
        {
            //// Assert
            Assert.True(stringToTest.IsAlphaNumeric());
        }

        [Theory]
        [InlineData("ab cd")]
        [InlineData("  ABCD")]
        [InlineData("ABC123  ")]
        [InlineData("123  456")]
        public void IsAlphanumeric_Alphanumeric_Strings_With_WhiteSpaces_Should_Return_True(string stringToTest)
        {
            //// Assert
            Assert.True(stringToTest.IsAlphaNumeric());
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("   ")]
        [InlineData("#$%&$#&")]
        public void IsAlphanumeric_Invalid_Strings_With_WhiteSpaces_Should_Return_False(string stringToTest)
        {
            //// Assert
            Assert.False(stringToTest.IsAlphaNumeric());
        }
    }
}
