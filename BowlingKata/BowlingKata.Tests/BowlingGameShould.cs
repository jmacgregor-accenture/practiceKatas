using System;
using BowlingKata.Game;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Shouldly;
using Xunit;

namespace BowlingKata.Tests
{
    public class BowlingGameShould
    {
        [Fact]
        public void ScoreZeroForZeroPins()
        {
            var game = new BowlingGame();

            for (var frame = 0; frame < 10; frame++)
            {
                game.Roll(0);
            }
            
            
            var score = game.Score();
            
            score.ShouldBe(0);
        }

        [Fact]
        public void ScoreOneForOnePin()
        {
            var game = new BowlingGame();
            
            game.Roll(1);
            
            for (var frame = 1; frame < 10; frame++)
            {
                game.Roll(0);
            }
            
            game.Score().ShouldBe(1);
        }
    }
}