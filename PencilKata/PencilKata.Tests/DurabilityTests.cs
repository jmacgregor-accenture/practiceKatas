using Xunit;
using Shouldly;

namespace PencilKata.Tests
{
    public class DurabilityTests : WritingTests
    {
        [Fact]
        public void WhenWritingPastEndOfDurabilityOnlyWhiteSpaceReturned()
        {
            SetupDesk(5, 0);

            var testString = "ono help";
            var expectedString = "ono he  ";

            var result = _pencil.Write(testString);

            result.ShouldBe(expectedString);
        }

        [Fact]
        public void WhenWritingUpperCaseLettersDegradeTwiceAsMuchAsLowerCase()
        {
            SetupDesk(5, 0);
            var testString = "Ono Help";
            var expectedString = "Ono H   ";

            var result = _pencil.Write(testString);
            
            result.ShouldBe(expectedString);
        }
    }
}