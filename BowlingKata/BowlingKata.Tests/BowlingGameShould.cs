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
            
            game.Roll(0);
            var score = game.Score();
            
            score.ShouldBe(0);
        }

        [Fact]
        public void ScoreOneForOnePin()
        {
            var game = new BowlingGame();
            
            game.Roll(1);
            
            game.Score().ShouldBe(1);
        }
    }
}