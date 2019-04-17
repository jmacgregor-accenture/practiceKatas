using PencilKata.Library;
using Xunit;
using Shouldly;

namespace PencilKata.Tests
{
    public class DegradationTests
    {
        [Fact]
        public void WhenWritingPastDurabilityIsZeroOnlyWhiteSpaceIsReturned()
        {
            var pencil = new Pencil(4);
            var testString = "hello";
            var expectedString = "hell";

            var result = pencil.Write(testString);
            
            result.ShouldBe(expectedString);
        }
    }
}