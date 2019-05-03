using Xunit;
using Shouldly;
using ZombieKata.Game;
using static ZombieKata.Tests.SurvivorFactory;
using static ZombieKata.Game.Globals;

namespace ZombieKata.Tests
{
    public class SurvivorShould
    {
        private Survivor _survivor;
        
        private void AddManyExperience(int amountOfExperience)
        {
            for (var i = 0; i < amountOfExperience; i++)
            {
                _survivor.AddExperience();
            }
        }

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

        [Fact]
        public void AddExperienceOnePointEachCall()
        {
            _survivor = CreateHealthyPhillip();

            _survivor.AddExperience();
            
            _survivor.Experience.ShouldBe(1);
        }

        [Fact]
        public void AdvanceToYellowWhenCrossingExperienceThreshold()
        {
            var yellowThreshold = Levels["Yellow"];
            _survivor = CreateHealthyPhillip();

            AddManyExperience(yellowThreshold + 1);
            
            _survivor.Experience.ShouldBe(7);
            _survivor.Level.ShouldBe("Yellow");
        }

        [Fact]
        public void AdvanceToOrangeWhenCrossingExperienceThreshold()
        {
            var orangeThreshold = Levels["Orange"];
            _survivor = CreateHealthyPhillip();

            AddManyExperience(orangeThreshold + 1);
            
            _survivor.Experience.ShouldBe(19);
            _survivor.Level.ShouldBe("Orange");
        }

        [Fact]
        public void NotAdvanceWhenThresholdIsNotCrossed()
        {
            var orangeThreshold = Levels["Orange"];
            _survivor = CreateHealthyPhillip();

            AddManyExperience(orangeThreshold);
            
            _survivor.Level.ShouldBe("Yellow");
        }

        [Theory]
        [InlineData("Red", "Red")]
        public void AdvanceToRedWhenCrossingExperienceThreshold(string levelThreshold, 
            string expectedLevel)
        {
            var threshold = Levels[levelThreshold];
            _survivor = CreateHealthyPhillip();
            
            AddManyExperience(threshold + 1);
            
            _survivor.Level.ShouldBe(expectedLevel);
        }
    }
}