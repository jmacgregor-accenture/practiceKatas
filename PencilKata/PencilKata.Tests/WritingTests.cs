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

            pencil.Write(paper, testString);

            paper.Contents.ShouldBe(testString);
        }
    }
}