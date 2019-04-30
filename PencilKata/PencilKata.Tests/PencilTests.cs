using PencilKata.Library;
using Shouldly;
using Xunit;

namespace PencilKata.Tests
{
    public class PencilTests
    {
        [Fact]
        public void WhenPencilWritesALowerCaseCharacterThenDurabilityDegradesByOne()
        {
            int initialDurability = 5;
            var pencil = new Pencil(initialDurability);

            pencil.Write('w');

            pencil.PointDurability.ShouldBe(4);
        }
        
        [Fact]
        public void WhenPencilWritesAnUpperCaseCharacterThenDurabilityDegradesByTwo()
        {
            int initialDurability = 5;
            var pencil = new Pencil(initialDurability);

            pencil.Write('U');

            pencil.PointDurability.ShouldBe(3);
        }

        [Theory]
        [InlineData(' ')]
        [InlineData('\t')]
        [InlineData('\n')]
        public void WhenPencilWritesWhiteSpaceCharacterDurabilityDoesNotChange(char testInput)
        {
            int initialDurability = 5;
            var pencil = new Pencil(initialDurability);
            
            pencil.Write(testInput);
            
            pencil.PointDurability.ShouldBe(5);
        }

        [Fact]
        public void PencilDoesNotDegradeBelowZero()
        {
            var initialDurability = 5;
            var pencil = new Pencil(initialDurability);
            var input = "Word Word";

            foreach (var letter in input)
            {
                pencil.Write(letter);
            }
            
            pencil.PointDurability.ShouldBe(0);
        }
    }
}