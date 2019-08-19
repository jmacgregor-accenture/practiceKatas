using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingKata.Game
{
    public class BowlingGame
    {
        public int Rolls {
            get 
            {
                return _rolls.Count;
            }
        }

        private List<int> _rolls;

        public BowlingGame()
        {
            _rolls = new List<int>();
        }
        
        public void Roll(int pins)
        {
            _rolls.Add(pins);
        }

        public int Score() 
        {
            return _rolls.Sum();
        }
    }
}