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

        [Fact]
        public void WhenPencilWritesOnPaperTextAppearsOnPaper()
        {
            var pencil = new Pencil();
            var paper = new Paper();
            var testString = "Hello I am a string too";

            pencil.Write(paper, testString);

            paper.Contents.ShouldBe(testString);
        }
    }
}