using PencilKata.Library;
using Shouldly;
using Xunit;

namespace PencilKata.Tests
{
    public class EraserTests
    {
        [Fact]
        public void EraserDegradesOnePerCharacter()
        {
            var eraser = new Eraser(5);

            eraser.Use('d');

            eraser.Durability.ShouldBe(4);
        }

        [Theory]
        [InlineData(' ', 5)]
        [InlineData('\t', 5)]
        [InlineData('\n', 5)]
        public void EraserDoesNotDegradeOnWhiteSpace(char testChar, int expectedDurability)
        {
            var eraser = new Eraser(5);
            
            eraser.Use(testChar);
            
            eraser.Durability.ShouldBe(expectedDurability);
        }
    }
}