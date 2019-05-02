using Shouldly;
using Xunit;
using ZombieKata.Game;

namespace ZombieKata.Tests
{
    public class EquipmentShould
    {
        [Fact]
        public void HaveName()
        {
            var testName = "taco";
            
            var equipment = new Equipment(testName);

            equipment.Name.ShouldBe(testName);
        }
    }
}