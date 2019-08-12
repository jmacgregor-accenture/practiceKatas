using System;

namespace BowlingKata.Game
{
    public class BowlingGame
    {
        private int _pinsStruck;
        
        public void Roll(int pins)
        {
            _pinsStruck += pins;
        }

        public int Score() 
        {
            return _pinsStruck;
        }
    }
}