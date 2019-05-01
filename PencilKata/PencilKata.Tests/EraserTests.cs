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

            eraser.Erase('d');

            eraser.Durability.ShouldBe(4);
        }
    }
}