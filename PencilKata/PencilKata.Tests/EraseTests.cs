using PencilKata.Library;
using Xunit;
using Shouldly;

namespace PencilKata.Tests
{   
    public class EraseTests : TestDesk
    {
        [Fact]
        public void WhenErasingTheLastWordFromAPageItIsReplacedWithWhiteSpace()
        {
            SetupDesk(25, 5, true);
            var testString = "Banana Banana";
            var eraseString = "Banana";
            var expected = "Banana       ";

            _pencil.Write(_paper, testString);
            _pencil.Erase(_paper, eraseString);
            
            _paper.Contents.ShouldBe(expected);
        }
    }
}