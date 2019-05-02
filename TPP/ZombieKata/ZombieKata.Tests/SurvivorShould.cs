using Xunit;
using Shouldly;
using ZombieKata.Game;
using static ZombieKata.Tests.SurvivorFactory;

namespace ZombieKata.Tests
{
    public class SurvivorShould
    {
        private Survivor _survivor;

        [Fact]
        public void BeWoundedWhenHarmed()
        {
            _survivor = CreateHealthyPhillip();

            _survivor.Harm();
            
            _survivor.Wounds.ShouldBe(1);
        }

        [Fact]
        public void DieWithTwoWounds()
        {
            _survivor = CreateHealthyPhillip();
            var lethalAmountOfWounds = 2;

            for (var i = 0; i < lethalAmountOfWounds; i++)
            {
                _survivor.Harm();
            }
            
            _survivor.IsDead.ShouldBeTrue();
        }

        [Fact]
        public void NotBeWoundedAfterDeath()
        {
            _survivor = CreateHealthyPhillip();
            var lethalAmountOfWounds = 2;

            for (var i = 0; i < lethalAmountOfWounds + 1; i++)
            {
                _survivor.Harm();
            }
            
            _survivor.Wounds.ShouldBe(2);
        }

        [Fact]
        public void LoseEquipmentSlotWhenHarmed()
        {
            _survivor = CreateHealthyPhillip();
            
            _survivor.Harm();
            
            _survivor.EquipmentCapacity.ShouldBe(4);
        }

        [Fact(Skip = "Placeholder to remember to add equipment reduction")]
        public void DiscardEquipmentWhenCarryingMoreThanNewCapacity()
        {
            var maxEquipNumber = 5;
            _survivor = CreateHealthyPhillip();
            
            // TODO
            // implement a way to add equipment
            // add max number of equipment
            
            _survivor.Harm();
            
            _survivor.Equipment.Count.ShouldBe(maxEquipNumber - 1);
        }
    }
}