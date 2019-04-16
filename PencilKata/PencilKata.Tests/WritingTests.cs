using PencilKata.Library;
using Xunit;
using Shouldly;

namespace PencilKata.Tests
{
    public class WritingTests : TestDesk
    {
        [Fact]
        public void WhenPencilWritesTextIsReturned()
        {
            SetupDesk(100, 5, false);
            var testString = "Hello am a string";

            var result = _pencil.Write(testString);
            
            result.ShouldBe(testString);
        }

        [Fact]
        public void WhenPencilWritesOnPaperTextAppearsOnPaper()
        {
            SetupDesk(100, 5, true);
            var testString = "Hello I am a string too";

            _pencil.Write(_paper, testString);

            _paper.Contents.ShouldBe(testString);
        }

        [Fact]
        public void WhenPencilWritesOnPaperItAddsToExistingContents()
        {
            SetupDesk(100, 5, true);
            var firstString = "This is the start";
            var secondString = " and this is the end";

            _pencil.Write(_paper, firstString);
            _pencil.Write(_paper, secondString);
            
            _paper.Contents.ShouldBe("This is the start and this is the end");
        }

        [Fact]
        public void WhenPencilWritesThePointDegrades()
        {
            SetupDesk(6, 5, false);
            var testString = "Mouse Squad";

            var result = _pencil.Write(testString);

            result.ShouldBe("Mouse      ");
        }

        [Fact]
        public void WhenPencilWritesThePointDoesNotDegradeFromWhiteSpace()
        {
            SetupDesk(9, 5, false);
            var testString = "Mouse Squad";

            var result = _pencil.Write(testString);
            
            result.ShouldBe("Mouse Sq   ");
        }

        [Fact]
        public void WhenPencilWritesThePointDegradesTwiceAsFastOnUpperCaseLetters()
        {
            SetupDesk(10, 5, false);
            var testString = "This Will Not Finish";
            var expected = "This Will           ";

            var result = _pencil.Write(testString);
            
            result.ShouldBe(expected);
        }
    }
}