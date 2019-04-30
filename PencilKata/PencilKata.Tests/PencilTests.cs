using PencilKata.Library;
using Shouldly;
using Xunit;

namespace PencilKata.Tests
{
    public class PencilTests
    {
        private const int fiveDurability = 5;
        private Pencil pencil;

        private void SetupPencil(int durability)
        {
            pencil = new Pencil(durability);
        }
        
        [Fact]
        public void WhenPencilWritesALowerCaseCharacterThenDurabilityDegradesByOne()
        {
            SetupPencil(fiveDurability);

            pencil.Write('w');

            pencil.PointDurability.ShouldBe(4);
        }
        
        [Fact]
        public void WhenPencilWritesAnUpperCaseCharacterThenDurabilityDegradesByTwo()
        {
            SetupPencil(fiveDurability);

            pencil.Write('U');

            pencil.PointDurability.ShouldBe(3);
        }

        [Theory]
        [InlineData(' ')]
        [InlineData('\t')]
        [InlineData('\n')]
        public void WhenPencilWritesWhiteSpaceCharacterDurabilityDoesNotChange(char testInput)
        {
            SetupPencil(fiveDurability);
            
            pencil.Write(testInput);
            
            pencil.PointDurability.ShouldBe(5);
        }

        [Fact]
        public void PencilDoesNotDegradeBelowZero()
        {
            SetupPencil(fiveDurability);
            var input = "Word Word";

            foreach (var letter in input)
            {
                pencil.Write(letter);
            }
            
            pencil.PointDurability.ShouldBe(0);
        }

        [Fact]
        public void PencilDurabilityRestoresToInitialWhenSharpened()
        {
            SetupPencil(1);
            pencil.Write('n');

            pencil.Sharpen();
            
            pencil.PointDurability.ShouldBe(1);
        }
    }
}