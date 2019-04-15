using PencilKata.Library;
using Xunit;
using Shouldly;

namespace PencilKata.Tests
{
    public class PencilTests
    {
        [Fact]
        public void WhenPencilWritesTextIsReturned()
        {
            var pencil = new Pencil();
            var testString = "Hello am a string";

            var result = pencil.Write(testString);
            
            result.ShouldBe(testString);
        }
    }
}