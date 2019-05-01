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
            
            pencil.Durability.ShouldBe(35);
            paper.Writing.ShouldBe(inputString);
        }

        [Fact]
        public void WhenWritingToPaperWithDullPencilOnlyWhitespaceIsReturned()
        {
            SetupPencil(5);
            var paper = new Paper(14);
            var inputString = "Well Now Hello";
            
            paper.Write(pencil, inputString);
            
            pencil.Durability.ShouldBe(0);
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

        [Fact]
        public void WhenWritingToPaperWithPencilAndFullEraserWillWriteStringEraseStringAndWriteNewString()
        {
            SetupPencil(50);
            var paper = new Paper(14);
            var eraser = new Eraser(50);
            var stringOne = "Well ";
            var stringTwo = "Done ";
            var stringThree = "You!";
            
            paper.Write(pencil, stringOne);
            paper.Write(pencil, stringTwo);
            paper.Erase(eraser, stringTwo);
            paper.Write(pencil, stringThree);
            
            paper.Writing.ShouldBe($"{stringOne}     {stringThree}");
        }

        [Fact]
        public void WhenWritingToPaperWithPencilAndLowEraserWillWriteStringEraseHalfWordAndWriteNewString()
        {
            SetupPencil(50);
            var paper = new Paper(14);
            var eraser = new Eraser(2);
            var stringOne = "Well ";
            var stringTwo = "Done ";
            var stringThree = "You!";
            
            paper.Write(pencil, stringOne);
            paper.Write(pencil, stringTwo);
            paper.Erase(eraser, stringTwo);
            paper.Write(pencil, stringThree);
            
            paper.Writing.ShouldBe($"{stringOne}Do   {stringThree}");
        }
        
        [Fact(Skip = "Got ahead of myself")]
        public void WritingStringAndErasingLastWordThenWritingNewWordPaperShowsNewWordAtEndOfString()
        {
            SetupPencil(50);
            var eraser = new Eraser(25);
            var paper = new Paper(23);
            paper.Write(pencil, "Do ");
            paper.Write(pencil, "Re ");
            paper.Write(pencil, "Mi ");
            paper.Write(pencil, "Fu ");
            paper.Write(pencil, "So ");
            paper.Write(pencil, "La ");
            paper.Write(pencil, "Ti ");
            paper.Write(pencil, "Du");
            
            paper.Erase(eraser,"Du");
            paper.Write(pencil, "Do");
            
            paper.Writing.ShouldBe("Do Re Mi Fa So La Ti Do");
        }
    }
}