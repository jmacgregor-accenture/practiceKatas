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

        private void SetupDesk(int durability)
        {
            _paper = new Paper();
            _pencil = new Pencil(_paper, durability);
        }
        
        [Fact]
        public void WhenWritingOnPaperTextIsAdded()
        {
            var testString = "She sells sea shells";
            SetupDesk(25);

            _pencil.Write(testString);

            _paper.Text.ShouldBe(testString);
        }

        [Fact]
        public void WhenWritingAnAdditionalTimeAppendNewText()
        {
            SetupDesk(100);
            var testString1 = "She sells sea shells";
            var testString2 = " and other stuff";
            
            _pencil.Write(testString1);
            _pencil.Write(testString2);
            
            _paper.Text.ShouldBe("She sells sea shells and other stuff");

        }

        [Fact]
        public void WhenWritingMoreCharactersThanDurabilityAddsSpacesNotCharacters()
        {
            SetupDesk(5);
            var testString = "seventeen";
            var expected = "seven    ";
            
            _pencil.Write(testString);
            
            _paper.Text.ShouldBe(expected);
        }

        [Fact]
        public void WhenWritingSpacesOrNewLinesDurabilityDoesNotDegrade()
        {
            SetupDesk(5);
            var testString = "\n    seventeen";
            var expected = "\n    seven    ";

            _pencil.Write(testString);
            
            _paper.Text.ShouldBe(expected);

        }

        [Fact]
        public void WhenWritingCapitalLettersPointDegradesTwiceAsFast()
        {
            SetupDesk(5);
            var testString = "Seven";
            var expectedString = "Seve ";
            
            _pencil.Write(testString);
            
            _paper.Text.ShouldBe(expectedString);
        }
        
    }

    
    
}