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

        private void SetupDesk(int durability, int initialLength, int eraserSize)
        {
            _paper = new Paper();
            _pencil = new Pencil(_paper, durability, initialLength, eraserSize);
        }
        
        [Fact]
        public void WhenWritingOnPaperTextIsAdded()
        {
            var testString = "She sells sea shells";
            SetupDesk(25, 100, 100);

            _pencil.Write(testString);

            _paper.Text.ShouldBe(testString);
        }

        [Fact]
        public void WhenWritingAnAdditionalTimeAppendNewText()
        {
            SetupDesk(100, 100, 100);
            var testString1 = "She sells sea shells";
            var testString2 = " and other stuff";
            
            _pencil.Write(testString1);
            _pencil.Write(testString2);
            
            _paper.Text.ShouldBe("She sells sea shells and other stuff");

        }

        [Fact]
        public void WhenWritingMoreCharactersThanDurabilityAddsSpacesNotCharacters()
        {
            SetupDesk(5, 100, 109);
            var testString = "seventeen";
            var expected = "seven    ";
            
            _pencil.Write(testString);
            
            _paper.Text.ShouldBe(expected);
        }

        [Fact]
        public void WhenWritingSpacesOrNewLinesDurabilityDoesNotDegrade()
        {
            SetupDesk(5, 100, 100 );
            var testString = "\n    seventeen";
            var expected = "\n    seven    ";

            _pencil.Write(testString);
            
            _paper.Text.ShouldBe(expected);

        }

        [Fact]
        public void WhenWritingCapitalLettersPointDegradesTwiceAsFast()
        {
            SetupDesk(5, 100, 100);
            var testString = "Seven";
            var expectedString = "Seve ";
            
            _pencil.Write(testString);
            
            _paper.Text.ShouldBe(expectedString);
        }

        [Fact]
        public void PencilCanBeSharpenedToRestoreOriginalPointyness()
        {
            Paper paper = new Paper();
            Pencil stubby = new Pencil(paper,5, 2, 100);
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
            SetupDesk(5,0, 100);

            var testString = "Text";
            var expected = "Text    ";
            
            _pencil.Write(testString);
            _pencil.Sharpen();
            _pencil.Write(testString);
            
            _paper.Text.ShouldBe(expected);
        }
        
        [Fact]
        public void PencilLosesLengthOnEachSharpening()
        {
            SetupDesk(5,1, 100);

            var testString = "Text";
            var expected = "TextText    ";
            
            _pencil.Write(testString);
            _pencil.Sharpen();
            _pencil.Write(testString);
            _pencil.Sharpen();
            _pencil.Write(testString);
            
            _paper.Text.ShouldBe(expected);
        }

        [Fact]
        public void WhenErasingWordOnlyLastWordIsReplacedWithWhiteSpace()
        {
            SetupDesk(100,100, 100);
            var testString = "test text test";
            var expected = "test text     ";
            
            _pencil.Write(testString);
            _pencil.Erase("test");
            
            _paper.Text.ShouldBe(expected);
        }

        [Fact]
        public void ErasersHaveDegradationTooAndErasingWorksFromEndOfWordToBeAJerk()
        {
            SetupDesk(100, 100, 2);
            var testString = "test text test";
            var expected = "test text te  ";
            
            _pencil.Write(testString);
            _pencil.Erase("test");
            
            _paper.Text.ShouldBe(expected);
        }

        [Fact]
        public void DoNotEraseAnythingIfErasedStringNotFound()
        {
            SetupDesk(100, 100, 100);
            var testString = "test test test";
            
            _pencil.Write(testString);
            _pencil.Erase("Tossed");
            
            _paper.Text.ShouldBe(testString);
        }

        [Fact]
        public void WhenEditingTheStringNewWordIsInsertedIntoPlaceOfLastErase()
        {
            SetupDesk(100, 100, 100);
            var testString = "An apple a day keeps the doctor away!";
            var expected = "An onion a day keeps the doctor away!";
            
            _pencil.Write(testString);
            _pencil.Erase("apple");
            _pencil.Edit("onion");
            
            _paper.Text.ShouldBe(expected);
        }
    }

    
    
}