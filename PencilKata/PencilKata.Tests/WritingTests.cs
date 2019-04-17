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
            var pencil = new Pencil(25);
            var testString = "test";
            var expectedString = "test";

            var result = pencil.Write(testString);

            result.ShouldBe(expectedString);
        }

        [Fact]
        public void WhenWritingToSurfaceContentsIsUpdated()
        {
            var pencil = new Pencil(25);
            var paper = new Paper();
            var testString = "test";
            var expectedString = "test";
            
            pencil.WriteTo(paper, testString);

            paper.Contents.ShouldBe(expectedString);
        }

        [Fact]
        public void WhenWritingToSurfaceNewContentIsAddedToExistingContent()
        {
            var pencil = new Pencil(25);
            var paper = new Paper();
            var firstString = "hello";
            var secondString = " there";
            var expectedString = "hello there";
            
            pencil.WriteTo(paper, firstString);
            pencil.WriteTo(paper, secondString);
            
            paper.Contents.ShouldBe(expectedString);
        }
    }
}