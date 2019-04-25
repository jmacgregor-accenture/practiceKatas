using System;
using PencilKata.Library;
using Shouldly;
using Xunit;

namespace PencilKata.Tests
{
    public class PaperTests
    {
        Pencil pencil = new Pencil(5);
        

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

        
    }
}