using System;
using PencilKata.Library;
using Shouldly;
using Xunit;

namespace PencilKata.Tests
{
    public class PaperTests
    {
        Pencil pencil = new Pencil(15, 0);
        

        [Fact]
        public void PaperIsOfADefinedSize()
        {
            var paper = new Paper(5);
            
            paper.Writing.ShouldBe("     ");
        }
        
        [Theory]
        [InlineData("Hello World")]
        [InlineData("Hello Steve")]
        public void CanWriteTextOnPaperWithPencil(string testString)
        {
            var paper = new Paper(11);

            paper.Write(pencil,testString);
            
            Assert.Equal(testString, paper.Writing);
        }

        [Fact]
        public void TextWrittenToPaperIsAppendedEachTime()
        {
            var paper = new Paper(11);
            
            paper.Write(pencil, "Hello ");
            paper.Write(pencil, "World");
            
            Assert.Equal("Hello World", paper.Writing);
        }
        
        [Fact]
        public void TextWrittenToPaperIsAppendedThreeTimes()
        {
            var paper = new Paper(12);
            
            paper.Write(pencil, "Hello ");
            paper.Write(pencil, "World");
            paper.Write(pencil, "!");
            
            Assert.Equal("Hello World!", paper.Writing);
        }

        [Fact]
        public void TextDoesNotWriteToPaperWhenPencilIsDull()
        {
            var paper = new Paper(4);
            pencil.PointDurability = 0;
            
            paper.Write(pencil,"Doesn't Matter" );
            
            paper.Writing.ShouldBe("    ");
        }

        [Fact]
        public void ErasingReplacesStringWithWhitespace()
        {
            var paper = new Paper(4);
            var testString = "boom";
            paper.Writing = testString;

            paper.Erase(testString);
            
            paper.Writing.ShouldBe("    ");
        }
    }
}