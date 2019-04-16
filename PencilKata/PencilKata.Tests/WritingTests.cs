using System;
using PencilKata.Library;
using Shouldly;
using Xunit;

namespace PencilKata.Tests
{
    public class WritingTests
    {
        [Fact]
        public void WhenWritingPencilReturnsInputString()
        {
            var pencil = new Pencil();
            var testString = "Turkey Sammich";

            var result = pencil.Write(testString);
            
            result.ShouldBe(testString);
        }

        [Fact]
        public void WhenWritingOnPaperInputStringShownOnPaper()
        {
            var pencil = new Pencil();
            var paper = new Paper();
            var testString = "Turkey";
            var expectedString = "Turkey";

            pencil.Write(paper, testString);

            paper.Contents.ShouldBe(expectedString);
        }

        [Fact]
        public void WhenWritingMultipleStringsToPaperAllStringsAreDisplayed()
        {
            var pencil = new Pencil();
            var paper = new Paper();
            var testString1 = "Turkey Sandwich";
            var testString2 = " with Bacon";
            var expectedString = "Turkey Sandwich with Bacon";

            pencil.Write(paper, testString1);
            pencil.Write(paper, testString2);
            
            paper.Contents.ShouldBe(expectedString);
        }
    }
}