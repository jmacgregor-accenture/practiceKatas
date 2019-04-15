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
            var pencil = new Pencil(100);
            var testString = "Hello am a string";

            var result = pencil.Write(testString);
            
            result.ShouldBe(testString);
        }

        [Fact]
        public void WhenPencilWritesOnPaperTextAppearsOnPaper()
        {
            var pencil = new Pencil(100);
            var paper = new Paper();
            var testString = "Hello I am a string too";

            pencil.Write(paper, testString);

            paper.Contents.ShouldBe(testString);
        }

        [Fact]
        public void WhenPencilWritesOnPaperItAddsToExistingContents()
        {
            var pencil = new Pencil(100);
            var paper = new Paper();
            var firstString = "This is the start";
            var secondString = " and this is the end";

            pencil.Write(paper, firstString);
            pencil.Write(paper, secondString);
            
            paper.Contents.ShouldBe("This is the start and this is the end");
        }

        [Fact]
        public void WhenPencilWritesThePointDegrades()
        {
            var pencil = new Pencil(5);
            var testString = "Mouse Squad";

            var result = pencil.Write(testString);

            result.ShouldBe("Mouse      ");
        }
    }
}