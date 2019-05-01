using System;
using PencilKata.Library;
using Shouldly;
using Xunit;

namespace PencilKata.Tests
{
    public class PaperTests
    {
        Pencil pencil = new Pencil(15, 0);
        Eraser _eraser = new Eraser(25);
        

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
            
            paper.Write(pencil,"Doesn't Matter");
            
            paper.Writing.ShouldBe("    ");
        }

        [Fact]
        public void ErasingReplacesStringWithWhitespace()
        {
            var paper = new Paper(4);
            var testString = "boom";
            paper.Writing = testString;
            paper.FirstOpenSpace = 4;

            paper.Erase(_eraser,testString);
            
            paper.Writing.ShouldBe("    ");
            paper.LastErasedSpot.ShouldBe(0);
        }

        [Fact]
        public void ErasingReplacesLastInstanceOfInputStringWithWhitespace()
        {
            var paper = new Paper(9);
            var testString = "boom";
            paper.Writing = $"{testString} {testString}";
            paper.FirstOpenSpace = 9;
            
            paper.Erase(_eraser, testString);
            
            paper.LastErasedSpot.ShouldBe(5);
            paper.Writing.ShouldBe($"{testString}     ");
        }

        [Fact]
        public void ErasingTwiceRemovesTwoInstancesOfInput()
        {
            var paper = new Paper(9);
            var testString = "boom";
            paper.Writing = $"{testString} {testString}";
            paper.FirstOpenSpace = 9;
            
            paper.Erase(_eraser, testString);
            paper.Erase(_eraser, testString);
            
            paper.Writing.ShouldBeNullOrWhiteSpace();
            paper.LastErasedSpot.ShouldBe(0);
        }

        [Fact]
        public void ErasingWithWornOutEraserOnlyErasesHalfTheWord()
        {
            var paper = new Paper(4);
            var eraser = new Eraser(2);
            var testString = "boom";
            paper.Writing = testString;
            paper.FirstOpenSpace = 4;
            
            paper.Erase(eraser, testString);
            
            paper.Writing.ShouldBe("bo  ");
            paper.LastErasedSpot.ShouldBe(2);
        }

        [Fact]
        public void EditWritingInsertsTextIntoLastErasedSpace()
        {
            var paper = new Paper(9);
            paper.Writing = "Heya Dude";
            paper.FirstOpenSpace = 9;
            
            paper.Erase(_eraser, "Heya");
            paper.Edit(pencil, "Hey!");
            
            paper.Writing.ShouldBe("Hey! Dude");
        }

        [Fact]
        public void EditWritingInsertsAtSignWhenEditingOverExistingText()
        {
            var paper = new Paper(9);
            paper.Writing = "Heya Dude";
            paper.FirstOpenSpace = 9;
            
            paper.Erase(_eraser, "Heya");
            paper.Edit(pencil, "Hey! Yo");
            
            paper.Writing.ShouldBe("Hey! @@de");
        }
    }
}