using System;
using PencilKata.Library;
using Xunit;
using Shouldly;

namespace PencilKata.Tests
{
    public class PencilTests
    {
        [Fact]
        public void WhenWritingOnPaperTextIsAdded()
        {
            var testString = "She sells sea shells";
            var paper = new Paper();
            var pencil = new Pencil(paper, 25);

            pencil.Write(testString);

            paper.Text.ShouldBe(testString);
        }

        [Fact]
        public void WhenWritingAnAdditionalTimeAppendNewText()
        {
            var paper = new Paper();
            var pencil = new Pencil(paper, 100);
            var testString1 = "She sells sea shells";
            var testString2 = " and other stuff";
            
            pencil.Write(testString1);
            pencil.Write(testString2);
            
            paper.Text.ShouldBe("She sells sea shells and other stuff");

        }

        [Fact]
        public void WhenWritingMoreCharactersThanDurabilityAddsSpacesNotCharacters()
        {
            var paper = new Paper();
            var pencil = new Pencil(paper, 5);
            var testString = "Seventeen";
            var expected = "Seven    ";
            
            pencil.Write(testString);
            
            paper.Text.ShouldBe(expected);
        }
        
    }

    
    
}