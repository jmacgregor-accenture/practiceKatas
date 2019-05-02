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

        [Fact]
        public void NotBeEquipped()
        {
            var equipment = new Equipment("noname");

            equipment.InHand.ShouldBeFalse();
        }
    }
}