using PencilKata.Library;
using Shouldly;
using Xunit;

namespace PencilKata.Tests
{
    public class WritingTests
    {
        [Fact]
        public void WhenWritingToPaperWithSharpPencilWritingAppearsAndPointDegrades()
        {
            var pencil = new Pencil(50);
            var paper = new Paper(14);
            var inputString = "Well Now Hello";
            
            paper.Write(pencil, inputString);
            
            pencil.PointDurability.ShouldBe(35);
            paper.Writing.ShouldBe(inputString);
        }

        [Fact]
        public void WhenWritingToPaperWithDullPencilOnlyWhitespaceIsReturned()
        {
            var pencil = new Pencil(5);
            var paper = new Paper(14);
            var inputString = "Well Now Hello";
            
            paper.Write(pencil, inputString);
            
            pencil.PointDurability.ShouldBe(0);
            paper.Writing.ShouldBe("Well          ");
        }
    }
}