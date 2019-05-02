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

        [Fact]
        public void OnlyAddUniquePlayers()
        {
            var game = new ZombieGame();
            var survivorOne = new Survivor("William");
            var survivorTwo = new Survivor("William");
            
            game.AddSurvivor(survivorOne);
            game.AddSurvivor(survivorTwo);
            
            game.Survivors.Count.ShouldBe(1);
        }

        [Fact]
        public void EndIfAllPlayersAreDead()
        {
            var game = new ZombieGame();
            var survivor = new Survivor("Harry");
            survivor.Harm();
            survivor.Harm();
            game.AddSurvivor(survivor);

            var result = game.IsOver();

            result.ShouldBeTrue();
        }
    }
}