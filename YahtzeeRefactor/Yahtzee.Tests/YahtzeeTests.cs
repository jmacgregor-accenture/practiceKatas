using System.Collections.Generic;
using Xunit;
using Yahtzee.Production;
using Shouldly;

namespace Yahtzee.Tests
{
    public class YahtzeeTests
    {
        [Fact]
        public void YahtzeeGame_OneThroughFive_DictionaryLoaded()
        {
            var yahtzee = new YahtzeeGame(1,2,3,4,5);
            var expectedDictionary = new Dictionary<int, int>
            {
                {1,1},
                {2,2},
                {3,3},
                {4,4},
                {5,5}
            };
            
            yahtzee.dice.ShouldBe(expectedDictionary);
        }

        [Fact]
        public void YahtzeeGame_AllFives_DictionaryLoaded()
        {
            var yahtzee = new YahtzeeGame(5,5,5,5,5);
            var expectedDictionary = new Dictionary<int, int>
            {
                {5,25}
            };
            
            yahtzee.dice.ShouldBe(expectedDictionary);
        }
        
        [Fact]
        public void Chance_scores_sum_of_all_dice()
        {
            int expected = 15;
            int actual = YahtzeeGame.Chance(2, 3, 4, 5, 1);
            Assert.Equal(expected, actual);
            Assert.Equal(16, YahtzeeGame.Chance(3, 3, 4, 5, 1));
        }

        [Fact]
        public void Yahtzee_scores_50()
        {
            int expected = 50;
            int actual = YahtzeeGame.Yahtzee(4, 4, 4, 4, 4);
            Assert.Equal(expected, actual);
            Assert.Equal(50, YahtzeeGame.Yahtzee(6, 6, 6, 6, 6));
            Assert.Equal(0, YahtzeeGame.Yahtzee(6, 6, 6, 6, 3));
        }

        [Fact]
        public void Test_1s()
        {
            Assert.True(YahtzeeGame.Ones(1, 2, 3, 4, 5) == 1);
            Assert.Equal(2, YahtzeeGame.Ones(1, 2, 1, 4, 5));
            Assert.Equal(0, YahtzeeGame.Ones(6, 2, 2, 4, 5));
            Assert.Equal(4, YahtzeeGame.Ones(1, 2, 1, 1, 1));
        }

        [Fact]
        public void test_2s()
        {
            Assert.Equal(4, YahtzeeGame.Twos(1, 2, 3, 2, 6));
            Assert.Equal(10, YahtzeeGame.Twos(2, 2, 2, 2, 2));
        }

        [Fact]
        public void test_threes()
        {
            Assert.Equal(6, YahtzeeGame.Threes(1, 2, 3, 2, 3));
            Assert.Equal(12, YahtzeeGame.Threes(2, 3, 3, 3, 3));
        }

        [Fact]
        public void fours_test()
        {
            Assert.Equal(12, new YahtzeeGame(4, 4, 4, 5, 5).Fours());
            Assert.Equal(8, new YahtzeeGame(4, 4, 5, 5, 5).Fours());
            Assert.Equal(4, new YahtzeeGame(4, 5, 5, 5, 5).Fours());
        }

        [Fact]
        public void fives()
        {
            Assert.Equal(10, new YahtzeeGame(4, 4, 4, 5, 5).Fives());
            Assert.Equal(15, new YahtzeeGame(4, 4, 5, 5, 5).Fives());
            Assert.Equal(20, new YahtzeeGame(4, 5, 5, 5, 5).Fives());
        }

        [Fact]
        public void sixes_test()
        {
            Assert.Equal(0, new YahtzeeGame(4, 4, 4, 5, 5).sixes());
            Assert.Equal(6, new YahtzeeGame(4, 4, 6, 5, 5).sixes());
            Assert.Equal(18, new YahtzeeGame(6, 5, 6, 6, 5).sixes());
        }

        [Fact]
        public void one_pair()
        {
            Assert.Equal(6, YahtzeeGame.ScorePair(3, 4, 3, 5, 6));
            Assert.Equal(10, YahtzeeGame.ScorePair(5, 3, 3, 3, 5));
            Assert.Equal(12, YahtzeeGame.ScorePair(5, 3, 6, 6, 5));
        }

        [Fact]
        public void two_Pair()
        {
            Assert.Equal(16, YahtzeeGame.TwoPair(3, 3, 5, 4, 5));
            Assert.Equal(0, YahtzeeGame.TwoPair(3, 3, 5, 5, 5));
        }

        [Fact]
        public void three_of_a_kind()
        {
            Assert.Equal(9, YahtzeeGame.ThreeOfAKind(3, 3, 3, 4, 5));
            Assert.Equal(15, YahtzeeGame.ThreeOfAKind(5, 3, 5, 4, 5));
            Assert.Equal(0, YahtzeeGame.ThreeOfAKind(3, 3, 3, 3, 5));
        }

        [Fact]
        public void four_of_a_knd()
        {
            Assert.Equal(12, YahtzeeGame.FourOfAKind(3, 3, 3, 3, 5));
            Assert.Equal(20, YahtzeeGame.FourOfAKind(5, 5, 5, 4, 5));
            Assert.Equal(0, YahtzeeGame.FourOfAKind(3, 3, 3, 3, 3));
        }

        [Fact]
        public void smallStraight()
        {
            Assert.Equal(15, YahtzeeGame.SmallStraight(1, 2, 3, 4, 5));
            Assert.Equal(15, YahtzeeGame.SmallStraight(2, 3, 4, 5, 1));
            Assert.Equal(0, YahtzeeGame.SmallStraight(1, 2, 2, 4, 5));
        }

        [Fact]
        public void largeStraight()
        {
            Assert.Equal(20, YahtzeeGame.LargeStraight(6, 2, 3, 4, 5));
            Assert.Equal(20, YahtzeeGame.LargeStraight(2, 3, 4, 5, 6));
            Assert.Equal(0, YahtzeeGame.LargeStraight(1, 2, 2, 4, 5));
        }

        [Fact]
        public void fullHouse()
        {
            Assert.Equal(18, YahtzeeGame.FullHouse(6, 2, 2, 2, 6));
            Assert.Equal(0, YahtzeeGame.FullHouse(2, 3, 4, 5, 6));
        }
    }
}