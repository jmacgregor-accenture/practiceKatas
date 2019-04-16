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

        protected void SetupDesk()
        {
            _paper = new Paper();
            _pencil = new Pencil();
        }
        
        [Fact]
        public void WhenWritingPencilReturnsInputString()
        {
            SetupDesk();
            var testString = "Turkey Sammich";

            var result = _pencil.Write(testString);
            
            result.ShouldBe(testString);
        }

        [Fact]
        public void WhenWritingOnPaperInputStringShownOnPaper()
        {
            SetupDesk();
            var testString = "Turkey";
            var expectedString = "Turkey";

            _pencil.Write(_paper, testString);

            _paper.Contents.ShouldBe(expectedString);
        }

        [Fact]
        public void WhenWritingMultipleStringsToPaperAllStringsAreDisplayed()
        {
            SetupDesk();
            var testString1 = "Turkey Sandwich";
            var testString2 = " with Bacon";
            var expectedString = "Turkey Sandwich with Bacon";

            _pencil.Write(_paper, testString1);
            _pencil.Write(_paper, testString2);
            
            _paper.Contents.ShouldBe(expectedString);
        }
    }
}