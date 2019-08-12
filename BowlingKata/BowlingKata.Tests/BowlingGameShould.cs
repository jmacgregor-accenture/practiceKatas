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
        
        private void RollFrames(int frames, int pins = 0)
        {
            for (var frame = 0; frame < frames; frame++)
            {
                _game.Roll(pins);
            }
        }
        
        [Fact]
        public void ScoreZeroForZeroPins()
        {
            _game = new BowlingGame();

            RollFrames(10);
            
            _game.Score().ShouldBe(0);
        }

        [Fact]
        public void ScoreOneForOnePin()
        {
            _game = new BowlingGame();
            
            _game.Roll(1);
            RollFrames(9);
            
            _game.Score().ShouldBe(1);
        }

        [Fact]
        public void ScoreTenWithOnePinEachFrame()
        {
            _game = new BowlingGame();
            
            RollFrames(10, 1);
            
            _game.Score().ShouldBe(10);
        }
    }
}