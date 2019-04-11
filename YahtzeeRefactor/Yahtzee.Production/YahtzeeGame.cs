using System.Collections.Generic;
using System.Linq;

namespace Yahtzee.Production
{
    public class YahtzeeGame
    {
        public static int Chance(int d1, int d2, int d3, int d4, int d5)
        {
            int total = 0;
            total += d1;
            total += d2;
            total += d3;
            total += d4;
            total += d5;
            return total;
        }

        public static int Yahtzee(params int[] dice)
        {
            int[] counts = new int[6];
            
            foreach (int die in dice)
            {
                counts[die - 1]++;
            }

            for (int i = 0; i != 6; i++)
            {
                if (counts[i] == 5)
                    return 50;
            }

            return 0;
        }

        public int Ones()
        {
            var worked = _dice.TryGetValue(1, out var score);
            
            return score;
        }

        public int Twos()
        {
            var worked = _dice.TryGetValue(2, out var score);
            
            return score;
        }

        public int Threes()
        {
            var worked = _dice.TryGetValue(3, out var score);
            
            return score;
        }

        private Dictionary<int,int> _dice;

        public YahtzeeGame(int d1, int d2, int d3, int d4, int d5)
        {
            _dice = GetRollValues(d1, d2, d3, d4, d5);
        }

        private Dictionary<int, int> GetRollValues(params int[] diceValues)
        {
            var rollValue = new Dictionary<int,int>();

            foreach (var die in diceValues)
            {
                if (rollValue.Keys.Contains(die))
                {
                    rollValue[die] += die;
                }
                else
                {
                    rollValue.Add(die,die);
                }
            }

            return rollValue;
        }

        public int Fours()
        {
            return _dice[4];
        }

        public int Fives()
        {
            return _dice[5];
        }

        public int Sixes()
        {
            var worked = _dice.TryGetValue(6, out var score);
            
            return score;
        }

        public static int ScorePair(int d1, int d2, int d3, int d4, int d5)
        {
            int[] counts = new int[6];
            counts[d1 - 1]++;
            counts[d2 - 1]++;
            counts[d3 - 1]++;
            counts[d4 - 1]++;
            counts[d5 - 1]++;

            for (var at = 0; at != 6; at++)
            {
                if (counts[6 - at - 1] == 2)
                    return (6 - at) * 2;
            }

            return 0;
        }

        public static int TwoPair(int d1, int d2, int d3, int d4, int d5)
        {
            int[] counts = new int[6];
            counts[d1 - 1]++;
            counts[d2 - 1]++;
            counts[d3 - 1]++;
            counts[d4 - 1]++;
            counts[d5 - 1]++;

            int n = 0;
            int score = 0;

            for (int i = 0; i < 6; i += 1)
            {
                if (counts[6 - i - 1] == 2)
                {
                    n++;
                    score += (6 - i);
                }
            }

            if (n == 2)
            {
                return score * 2;
            }

            return 0;
        }

        public static int FourOfAKind(int d1, int d2, int d3, int d4, int d5)
        {
            int[] tallies = new int[6];
            tallies[d1 - 1]++;
            tallies[d2 - 1]++;
            tallies[d3 - 1]++;
            tallies[d4 - 1]++;
            tallies[d5 - 1]++;

            for (int i = 0; i < 6; i++)
            {
                if (tallies[i] == 4)
                    return (i + 1) * 4;
            }

            return 0;
        }

        public static int ThreeOfAKind(int d1, int d2, int d3, int d4, int d5)
        {
            int[] t = new int[6];
            t[d1 - 1]++;
            t[d2 - 1]++;
            t[d3 - 1]++;
            t[d4 - 1]++;
            t[d5 - 1]++;

            for (int i = 0; i < 6; i++)
            {
                if (t[i] == 3)
                    return (i + 1) * 3;
            }

            return 0;
        }

        public static int SmallStraight(int d1, int d2, int d3, int d4, int d5)
        {
            int[] tallies = new int[6];
            tallies[d1 - 1] += 1;
            tallies[d2 - 1] += 1;
            tallies[d3 - 1] += 1;
            tallies[d4 - 1] += 1;
            tallies[d5 - 1] += 1;

            if (tallies[0] == 1 &&
                tallies[1] == 1 &&
                tallies[2] == 1 &&
                tallies[3] == 1 &&
                tallies[4] == 1)
            {
                return 15;
            }


            return 0;
        }

        public static int LargeStraight(int d1, int d2, int d3, int d4, int d5)
        {
            int[] tallies = new int[6];
            tallies[d1 - 1] += 1;
            tallies[d2 - 1] += 1;
            tallies[d3 - 1] += 1;
            tallies[d4 - 1] += 1;
            tallies[d5 - 1] += 1;

            if (tallies[1] == 1 &&
                tallies[2] == 1 &&
                tallies[3] == 1 &&
                tallies[4] == 1 &&
                tallies[5] == 1)
            {
                return 20;
            }

            return 0;
        }

        public static int FullHouse(int d1, int d2, int d3, int d4, int d5)
        {
            bool _2 = false;
            int _2_at = 0;
            bool _3 = false;
            int _3_at = 0;


            int[] tallies = new int[6];
            tallies[d1 - 1] += 1;
            tallies[d2 - 1] += 1;
            tallies[d3 - 1] += 1;
            tallies[d4 - 1] += 1;
            tallies[d5 - 1] += 1;

            for (var i = 0; i != 6; i += 1)
            {
                if (tallies[i] == 2)
                {
                    _2 = true;
                    _2_at = i + 1;
                }
            }

            for (var i = 0; i != 6; i += 1)
            {
                if (tallies[i] == 3)
                {
                    _3 = true;
                    _3_at = i + 1;
                }
            }

            if (_2 && _3)
            {
                return _2_at * 2 + _3_at * 3;
            }

            return 0;
        }
    }
}