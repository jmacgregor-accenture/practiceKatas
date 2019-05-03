using System.Linq;
using Xunit;
using Shouldly;
using ZombieKata.Game;
using static ZombieKata.Tests.SurvivorFactory;
using static ZombieKata.Game.Levels;

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

        [Fact]
        public void AddEquipmentToInventory()
        {
            _survivor = CreateHealthyPhillip();
            var foundEquipment = new Equipment("Cheese Whiz");

            _survivor.AddEquipment(foundEquipment);
            
            _survivor.Equipment.ShouldContain(foundEquipment);
        }

        [Fact]
        public void NotAddMoreEquipmentThanCanCarry()
        {
            _survivor = CreateHealthyPhillip();
            var numberOfItemsToAdd = 6;

            for (var i = 0; i < numberOfItemsToAdd; i++)
            {
                _survivor.AddEquipment(new Equipment($"Sword{i}"));
            }
            
            _survivor.Equipment.Count.ShouldBe(_survivor.EquipmentCapacity);
        }

        [Fact]
        public void DiscardEquipmentWhenCarryingMoreThanNewCapacity()
        {
            var maxEquipNumber = 5;
            _survivor = CreateHealthyPhillip();
            for (var i = 0; i < maxEquipNumber; i++)
            {
                _survivor.AddEquipment(new Equipment($"Sword{i+1}"));
            }
            
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
        public void NotAdvanceWhenThresholdIsNotCrossed()
        {
            var orangeThreshold = ORANGE.Value;
            _survivor = CreateHealthyPhillip();

            AddManyExperience(orangeThreshold);
            
            _survivor.Level.ShouldBe(YELLOW);
        }

        [Theory]
        [InlineData("Yellow", "Yellow")]
        [InlineData("Orange", "Orange")]
        [InlineData("Red", "Red")]
        public void AdvanceToCorrectLevelBasedOnExperienceEarned(string levelThreshold, 
            string expectedLevelName)
        {
            var threshold = ALL_LEVELS
                .First(level => level.Name == levelThreshold).Value;
            var expectedLevel = ALL_LEVELS.Find(level => level.Name == expectedLevelName);
            _survivor = CreateHealthyPhillip();
            
            AddManyExperience(threshold + 1);
            
            _survivor.Level.ShouldBe(expectedLevel);
        }
    }
}