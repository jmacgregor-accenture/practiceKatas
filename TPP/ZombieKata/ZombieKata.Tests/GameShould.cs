using Shouldly;
using Xunit;
using ZombieKata.Game;

namespace ZombieKata.Tests
{
    public class GameShould
    {
        [Fact]
        public void StartWithNoSurvivors()
        {
            var game = new ZombieGame();

            game.Survivors.Count.ShouldBe(0);
        }

        [Fact]
        public void AddPlayers()
        {
            var game = new ZombieGame();
            var newSurvivor = new Survivor("Charles");

            game.AddSurvivor(newSurvivor);
            
            game.Survivors.Count.ShouldBe(1);
        }
    }
}