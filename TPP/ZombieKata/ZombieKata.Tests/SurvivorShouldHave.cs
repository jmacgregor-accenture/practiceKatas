using Shouldly;
using Xunit;
using ZombieKata.Game;

namespace ZombieKata.Tests
{
    public class SurvivorShouldHave
    {
        private const string PHILLIP = "Phillip";
        private Survivor _survivor;

        private void CreateHealthyPhillip()
        {
            _survivor = new Survivor(PHILLIP);
        }
        
        [Fact]
        public void Name()
        {
            CreateHealthyPhillip();

            _survivor.Name.ShouldBe(PHILLIP);
        }

        [Fact]
        public void NoWoundsAtStart()
        {
            CreateHealthyPhillip();

            _survivor.Wounds.ShouldBe(0);
        }

        [Fact]
        public void CorrectNumberOfActionsAtStart()
        {
            CreateHealthyPhillip();

            _survivor.ActionsPerTurn.ShouldBe(3);
        }
    }
}