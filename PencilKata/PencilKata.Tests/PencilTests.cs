using System;
using PencilKata.Library;
using Xunit;
using Shouldly;

namespace PencilKata.Tests
{
    public class PencilTests
    {
        private Paper _paper;
        private Pencil _pencil;

        private void SetupDesk(int durability, int initialLength)
        {
            _paper = new Paper();
            _pencil = new Pencil(_paper, durability, initialLength);
        }
        
        [Fact]
        public void WhenWritingOnPaperTextIsAdded()
        {
            var testString = "She sells sea shells";
            SetupDesk(25, 100);

            _pencil.Write(testString);

            _paper.Text.ShouldBe(testString);
        }

        [Fact]
        public void WhenWritingAnAdditionalTimeAppendNewText()
        {
            SetupDesk(100, 100);
            var testString1 = "She sells sea shells";
            var testString2 = " and other stuff";
            
            _pencil.Write(testString1);
            _pencil.Write(testString2);
            
            _paper.Text.ShouldBe("She sells sea shells and other stuff");

        }

        [Fact]
        public void WhenWritingMoreCharactersThanDurabilityAddsSpacesNotCharacters()
        {
            SetupDesk(5, 100);
            var testString = "seventeen";
            var expected = "seven    ";
            
            _pencil.Write(testString);
            
            _paper.Text.ShouldBe(expected);
        }

        [Fact]
        public void WhenWritingSpacesOrNewLinesDurabilityDoesNotDegrade()
        {
            SetupDesk(5, 100);
            var testString = "\n    seventeen";
            var expected = "\n    seven    ";

            _pencil.Write(testString);
            
            _paper.Text.ShouldBe(expected);

        }

        [Fact]
        public void WhenWritingCapitalLettersPointDegradesTwiceAsFast()
        {
            SetupDesk(5, 100);
            var testString = "Seven";
            var expectedString = "Seve ";
            
            _pencil.Write(testString);
            
            _paper.Text.ShouldBe(expectedString);
        }

        [Fact]
        public void PencilCanBeSharpenedToRestoreOriginalPointyness()
        {
            Paper paper = new Paper();
            Pencil stubby = new Pencil(paper,5, 2);
            var testString = "Texts";
            var secondTestString = "Seven";
            var expected = "Text Seve ";
            
            stubby.Write(testString);
            stubby.Sharpen();
            stubby.Write(secondTestString);
            
            paper.Text.ShouldBe(expected);

        }

        [Fact]
        public void PencilCanOnlyBeSharpenedWhenLengthIsMoreThanZero()
        {
            SetupDesk(5,0);

            var testString = "Text";
            var expected = "Text    ";
            
            _pencil.Write(testString);
            _pencil.Sharpen();
            _pencil.Write(testString);
            
            _paper.Text.ShouldBe(expected);
        }
    }

    
    
}