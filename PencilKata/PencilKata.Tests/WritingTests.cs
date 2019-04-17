using PencilKata.Library;
using Xunit;
using Shouldly;

namespace PencilKata.Tests
{
    public class WritingTests
    {
        [Fact]
        public void WhenWritingInputStringIsReturned()
        {
            var pencil = new Pencil();
            var testString = "test";
            var expectedString = "test";

            var result = pencil.Write(testString);

            result.ShouldBe(expectedString);
        }
    }
}