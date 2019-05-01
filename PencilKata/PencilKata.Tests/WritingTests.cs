using PencilKata.Library;
using Shouldly;
using Xunit;

namespace PencilKata.Tests
{
    public class WritingTests
    {
        private Pencil pencil;

        private void SetupPencil(int durability, int length = 0)
        {
            pencil = new Pencil(durability, length);
        }
        
        [Fact]
        public void WhenWritingToPaperWithSharpPencilWritingAppearsAndPointDegrades()
        {
            SetupPencil(50);
            var paper = new Paper(14);
            var inputString = "Well Now Hello";
            
            paper.Write(pencil, inputString);
            
            pencil.PointDurability.ShouldBe(35);
            paper.Writing.ShouldBe(inputString);
        }

        [Fact]
        public void WhenWritingToPaperWithDullPencilOnlyWhitespaceIsReturned()
        {
            SetupPencil(5);
            var paper = new Paper(14);
            var inputString = "Well Now Hello";
            
            paper.Write(pencil, inputString);
            
            pencil.PointDurability.ShouldBe(0);
            paper.Writing.ShouldBe("Well          ");
        }

        [Fact]
        public void WhenWritingToPaperWithPencilSharpeningBetweenStringsAllowsAllToAppend()
        {
            SetupPencil(5,1);
            var paper = new Paper(9);
            var stringOne = "Well ";
            var stringTwo = "Done";
            
            paper.Write(pencil, stringOne);
            pencil.Sharpen();
            paper.Write(pencil, stringTwo);
            
            paper.Writing.ShouldBe(stringOne + stringTwo);
        }

        [Fact]
        public void WhenWritingToPaperWithPencilShortPencilWillNotWriteAfterPointRunsOut()
        {
            SetupPencil(5,0);
            var paper = new Paper(9);
            var stringOne = "Well ";
            var stringTwo = "Done";
            
            paper.Write(pencil, stringOne);
            pencil.Sharpen();
            paper.Write(pencil, stringTwo);
            
            paper.Writing.ShouldBe($"{stringOne}    ");
        }
    }
}