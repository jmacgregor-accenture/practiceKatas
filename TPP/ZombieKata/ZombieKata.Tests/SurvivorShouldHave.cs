using Shouldly;
using Xunit;
using ZombieKata.Game;
using static ZombieKata.Tests.SurvivorFactory;

namespace ZombieKata.Tests
{
    public class SurvivorShouldHave
    {
        private Survivor _survivor;
        
        [Fact]
        public void Name()
        {
            _survivor = CreateHealthyPhillip();

            _survivor.Name.ShouldBe(PHILLIP);
        }

        [Fact]
        public void NoWoundsAtStart()
        {
            _survivor = CreateHealthyPhillip();

            _survivor.Wounds.ShouldBe(0);
        }

        [Fact]
        public void CorrectNumberOfActionsAtStart()
        {
            _survivor = CreateHealthyPhillip();

            _survivor.ActionsPerTurn.ShouldBe(3);
        }

        [Fact]
        public void CorrectNumberOfEquipmentSlotsAtStart()
        {
            _survivor = CreateHealthyPhillip();

            _survivor.EquipmentCapacity.ShouldBe(3);
        }
    }
}