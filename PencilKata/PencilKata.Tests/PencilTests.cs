using PencilKata.Library;
using Shouldly;
using Xunit;

namespace PencilKata.Tests
{
    public class PencilTests
    {
        private const int fiveDurability = 5;
        private Pencil pencil;

        private void SetupPencil(int durability, int length = 0)
        {
            pencil = new Pencil(durability, length);
        }
        
        [Fact]
        public void WhenPencilWritesALowerCaseCharacterThenDurabilityDegradesByOne()
        {
            SetupPencil(fiveDurability);

            pencil.Use('w');

            pencil.Durability.ShouldBe(4);
        }
        
        [Fact]
        public void WhenPencilWritesAnUpperCaseCharacterThenDurabilityDegradesByTwo()
        {
            SetupPencil(fiveDurability);

            pencil.Use('U');

            pencil.Durability.ShouldBe(3);
        }

        [Theory]
        [InlineData(' ')]
        [InlineData('\t')]
        [InlineData('\n')]
        public void WhenPencilWritesWhiteSpaceCharacterDurabilityDoesNotChange(char testInput)
        {
            SetupPencil(fiveDurability);
            
            pencil.Use(testInput);
            
            pencil.Durability.ShouldBe(5);
        }

        [Fact]
        public void PencilDoesNotDegradeBelowZero()
        {
            SetupPencil(fiveDurability);
            var input = "Word Word";

            foreach (var letter in input)
            {
                pencil.Use(letter);
            }
            
            pencil.Durability.ShouldBe(0);
        }

        [Fact]
        public void PencilDurabilityRestoresToInitialWhenSharpened()
        {
            SetupPencil(1, 1);
            pencil.Use('n');

            pencil.Sharpen();
            
            pencil.Durability.ShouldBe(1);
        }

        [Fact]
        public void PencilWithNoLengthWillNotSharpen()
        {
            SetupPencil(1);
            pencil.Use('n');
            
            pencil.Sharpen();
            
            pencil.Durability.ShouldBe(0);
        }

        [Fact]
        public void PencilWithLengthReducesByOneWhenSharpened()
        {
           var startingLength = 3;
           SetupPencil(1, startingLength);
           pencil.Use('n');
           
           pencil.Sharpen();
           
           pencil.Length.ShouldBe(startingLength - 1);
        }
    }
}