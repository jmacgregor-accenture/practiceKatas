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

        [Fact]
        public void WhenErasingOnlyWordOnPaperOnlyWhiteSpaceRemains()
        {
            var testString = "Test";
            var paper = new Paper();
            paper.Write(testString);

            paper.Erase(testString);
            
            paper.Contents.ShouldBe("    ");
        }

        [Fact]
        public void WhenErasingOneOfTwoWordsOnPaperFirstWordAndWhiteSpaceRemains()
        {
            var startingString = "Hotdog tests";
            var stringToErase = "tests";
            var paper = new Paper();
            paper.Write(startingString);

            paper.Erase(stringToErase);
            
            paper.Contents.ShouldBe("Hotdog      ");
        }

        [Fact]
        public void WhenErasingOneOfTwoInstancesOnlyOneAndWhiteSpaceRemains()
        {
            var startingString = "This is test test";
            var erasingString = "test";
            var paper = new Paper();
            paper.Write(startingString);
            
            paper.Erase(erasingString);
            
            paper.Contents.ShouldBe("This is test     ");
        }

        [Fact]
        public void WhenErasingWordNotAtEndOfContentInsertsWhiteSpace()
        {
            var startingString = "This is test hamburgers";
            var erasingString = "test";
            var paper = new Paper();
            paper.Write(startingString);
            
            paper.Erase(erasingString);
            
            paper.Contents.ShouldBe("This is      hamburgers");
        }
    }
}