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
    }
}