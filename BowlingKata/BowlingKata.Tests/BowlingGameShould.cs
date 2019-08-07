using System;
using BowlingKata.Game;
using Shouldly;
using Xunit;

namespace BowlingKata.Tests
{
    public class BowlingGameShould
    {
        [Fact]
        public void TestSomething()
        {
            var game = new BowlingGame();
            game.ShouldNotBeNull();
        }
    }
}