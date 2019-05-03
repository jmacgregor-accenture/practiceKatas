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

        [Fact]
        public void NotEndIfAnyoneIsLeftAlive()
        {
            var game = new ZombieGame();
            var survivor = new Survivor("Harry");
            var survivor2 = new Survivor("William");
            survivor.Harm();
            survivor.Harm();
            game.AddSurvivor(survivor);
            game.AddSurvivor(survivor2);

            var result = game.IsOver();

            result.ShouldBeFalse();
        }

        [Fact]
        public void StartAtLevelBlue()
        {
            var game = new ZombieGame();

            game.Level.ShouldBe(Levels.BLUE);
        }

        [Fact(Skip = "Redesign Needed")]
        public void HaveLevelThatMatchesHighestPlayerLevel()
        {
            var game = new ZombieGame();
            var survivorOne = new Survivor("Charles");
            survivorOne.Level = Levels.YELLOW;

            game.SetLevel();
            
            game.Level.ShouldBe(Levels.YELLOW);
        }
    }
}