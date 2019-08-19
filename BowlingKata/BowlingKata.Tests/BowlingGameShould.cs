using System;
using BowlingKata.Game;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Shouldly;
using Xunit;

namespace BowlingKata.Tests
{
    public class BowlingGameShould
    {
        private BowlingGame _game;
        
        private void RollPins(int rolls, int pins = 0)
        {
            for (var roll = 0; roll < rolls; roll++)
            {
                _game.Roll(pins);
            }
        }
        
        [Fact]
        public void ScoreZeroForZeroPins()
        {
            _game = new BowlingGame();

            RollPins(20);
            
            _game.Score().ShouldBe(0);
        }

        [Fact]
        public void ScoreOneForOnePin()
        {
            _game = new BowlingGame();
            
            _game.Roll(1);
            RollPins(19);
            
            _game.Score().ShouldBe(1);
        }

        [Fact]
        public void ScoreTenWithOnePinEachFrame()
        {
            _game = new BowlingGame();
            
            RollPins(20, 1);
            
            _game.Score().ShouldBe(20);
        }

        [Fact]
        public void HaveTwentyRollsWithNoSparesOrStrikes()
        {
            _game = new BowlingGame();
            
            RollPins(20,3);

            _game.Rolls.ShouldBe(20);
        }

        [Fact(Skip = "Refactor")]
        public void ScoreSpareAsTenPlusNextRoll()
        {
            _game = new BowlingGame();
            
            _game.Roll(3);
            _game.Roll(7);
            _game.Roll(3);
            RollPins(7);
            
            _game.Score().ShouldBe(16);
        }
    }
}