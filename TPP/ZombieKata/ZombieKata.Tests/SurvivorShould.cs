using Xunit;
using Shouldly;
using ZombieKata.Game;

namespace ZombieKata.Tests
{
    public class SurvivorShould
    {
        private const string PHILLIP = "Phillip";
        private Survivor _survivor;

        private void CreateHealthyPhillip()
        {
            _survivor = new Survivor(PHILLIP);
        }

        [Fact]
        public void BeWoundedWhenHarmed()
        {
            CreateHealthyPhillip();

            _survivor.Harm();
            
            _survivor.Wounds.ShouldBe(1);
        }

        [Fact]
        public void DieWithTwoWounds()
        {
            CreateHealthyPhillip();
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
            CreateHealthyPhillip();
            var lethalAmountOfWounds = 2;

            for (var i = 0; i < lethalAmountOfWounds + 1; i++)
            {
                _survivor.Harm();
            }
            
            _survivor.Wounds.ShouldBe(2);
        }
    }
}