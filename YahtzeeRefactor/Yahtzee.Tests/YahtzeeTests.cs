using System.Collections.Generic;
using Xunit;
using Yahtzee.Production;
using Shouldly;

namespace Yahtzee.Tests
{
    public class YahtzeeTests
    {
        
        [Fact]
        public void Chance_scores_sum_of_all_dice()
        {
            int expected = 15;
            int actual = new YahtzeeGame(2, 3, 4, 5, 1).Chance();
            Assert.Equal(expected, actual);
            Assert.Equal(16, new YahtzeeGame(3, 3, 4, 5, 1).Chance());
        }

        [Fact]
        public void Yahtzee_scores_50()
        {
            int expected = 50;
            int actual = new YahtzeeGame(4, 4, 4, 4, 4).Yahtzee();
            Assert.Equal(expected, actual);
            Assert.Equal(50, new YahtzeeGame(6, 6, 6, 6, 6).Yahtzee());
            Assert.Equal(0, new YahtzeeGame(6, 6, 6, 6, 3).Yahtzee());
        }

        [Fact]
        public void Test_1s()
        {
            Assert.True(new YahtzeeGame(1, 2, 3, 4, 5).Ones() == 1);
            Assert.Equal(2, new YahtzeeGame(1, 2, 1, 4, 5).Ones());
            Assert.Equal(0, new YahtzeeGame(6, 2, 2, 4, 5).Ones());
            Assert.Equal(4, new YahtzeeGame(1, 2, 1, 1, 1).Ones());
        }

        [Fact]
        public void test_2s()
        {
            Assert.Equal(4, new YahtzeeGame(1, 2, 3, 2, 6).Twos());
            Assert.Equal(10, new YahtzeeGame(2, 2, 2, 2, 2).Twos());
        }

        [Fact]
        public void test_threes()
        {
            Assert.Equal(6, new YahtzeeGame(1, 2, 3, 2, 3).Threes());
            Assert.Equal(12, new YahtzeeGame(2, 3, 3, 3, 3).Threes());
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
            Assert.Equal(0, new YahtzeeGame(4, 4, 4, 5, 5).Sixes());
            Assert.Equal(6, new YahtzeeGame(4, 4, 6, 5, 5).Sixes());
            Assert.Equal(18, new YahtzeeGame(6, 5, 6, 6, 5).Sixes());
        }

        [Fact]
        public void one_pair()
        {
            Assert.Equal(6, new YahtzeeGame(3, 4, 3, 5, 6).ScorePair());
            //Assert.Equal(10, YahtzeeGame.ScorePair(5, 3, 3, 3, 5));
            //Assert.Equal(12, YahtzeeGame.ScorePair(5, 3, 6, 6, 5));
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