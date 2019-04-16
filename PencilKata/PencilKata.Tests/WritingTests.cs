using System;
using System.IO.Compression;
using PencilKata.Library;
using Shouldly;
using Xunit;

namespace PencilKata.Tests
{
    public class WritingTests
    {
        protected Pencil _pencil;
        protected Paper _paper;

        protected void SetupDesk(int pencilDurability)
        {
            _paper = new Paper();
            _pencil = new Pencil(pencilDurability);
        }
        
        [Fact]
        public void WhenWritingPencilReturnsInputString()
        {
            SetupDesk(25);
            var testString = "Turkey Sammich";

            var result = _pencil.Write(testString);
            
            result.ShouldBe(testString);
        }

        [Fact]
        public void WhenWritingOnPaperInputStringShownOnPaper()
        {
            SetupDesk(25);
            var testString = "Turkey";
            var expectedString = "Turkey";

            _pencil.Write(_paper, testString);

            _paper.Contents.ShouldBe(expectedString);
        }

        [Fact]
        public void WhenWritingMultipleStringsToPaperAllStringsAreDisplayed()
        {
            SetupDesk(50);
            var testString1 = "Turkey Sandwich";
            var testString2 = " with Bacon";
            var expectedString = "Turkey Sandwich with Bacon";

            _pencil.Write(_paper, testString1);
            _pencil.Write(_paper, testString2);
            
            _paper.Contents.ShouldBe(expectedString);
        }
    }
}