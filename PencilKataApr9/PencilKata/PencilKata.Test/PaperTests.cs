using System;
using PencilKata.Desk;
using Xunit;
using Shouldly;

namespace PencilKata.Test
{
    public class PaperTests
    {
        [Fact]
        public void WhenWritingTextIsStored()
        {
            var testString = "She sells sea shells";
            var paper = new Paper();

            paper.Write(testString);

            paper.Contents.ShouldBe(testString);
        }

        [Fact]
        public void WhenWritingTextTwiceBothStringsAreAppendedToContents()
        {
            var firstString = "She sells sea shells";
            var secondString = " down by the sea shore";
            var paper = new Paper();
            
            paper.Write(firstString);
            paper.Write(secondString);
            
            paper.Contents.ShouldBe($"{firstString}{secondString}");
        }
    }
}