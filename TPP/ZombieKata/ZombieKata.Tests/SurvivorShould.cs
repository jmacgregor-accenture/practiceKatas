using Xunit;
using Shouldly;
using ZombieKata.Game;

namespace ZombieKata.Tests
{
    public class SurvivorShould
    {
        [Fact]
        public void HaveName()
        {
            var testName = "Phillip";
            
            var survivor = new Survivor(testName);

            survivor.Name.ShouldBe(testName);
        }

        [Fact]
        public void StartWithNoWounds()
        {
            var testName = "Phillip";
            
            var survivor = new Survivor(testName);

            survivor.Wounds.ShouldBe(0);
        }
    }
}