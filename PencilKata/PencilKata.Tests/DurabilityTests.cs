using Xunit;
using Shouldly;

namespace PencilKata.Tests
{
    public class DurabilityTests : WritingTests
    {
        [Fact]
        public void WhenWritingPastEndOfDurabilityOnlyWhiteSpaceReturned()
        {
            SetupDesk(5);

            var testString = "ono help";
            var expectedString = "ono he  ";

            var result = _pencil.Write(testString);

            result.ShouldBe(expectedString);
        }
    }
}