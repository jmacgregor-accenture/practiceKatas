using Xunit;
using YahtzeeRefactor.Library;

namespace YahtzeeRefactor.Tests
{
    public class YahtzeeTests
    {
        [Fact]
    public void Chance_scores_sum_of_all_dice()
    {
        int expected = 15;
        int actual = Yahtzee.Chance(2,3,4,5,1);
        Assert.Equal(expected, actual);
        Assert.Equal(16, Yahtzee.Chance(3,3,4,5,1));
    }

    [Fact]
    public void Yahtzee_scores_50() 
    {
        int expected = 50;
        int actual = Yahtzee.yahtzee(4,4,4,4,4);
        Assert.Equal(expected, actual);
        Assert.Equal(50, Yahtzee.yahtzee(6,6,6,6,6));
        Assert.Equal(0, Yahtzee.yahtzee(6,6,6,6,3));
    }

    [Fact]
    public void Test_1s() {
        Assert.True(Yahtzee.Ones(1,2,3,4,5) == 1);
        Assert.Equal(2, Yahtzee.Ones(1,2,1,4,5));
        Assert.Equal(0, Yahtzee.Ones(6,2,2,4,5));
        Assert.Equal(4, Yahtzee.Ones(1,2,1,1,1));
    }

    [Fact]
    public void test_2s() 
    {
        Assert.Equal(4, Yahtzee.Twos(1,2,3,2,6));
        Assert.Equal(10, Yahtzee.Twos(2,2,2,2,2));
    }

    [Fact]
    public void test_threes() 
    {
        Assert.Equal(6, Yahtzee.Threes(1,2,3,2,3));
        Assert.Equal(12, Yahtzee.Threes(2,3,3,3,3));
    }

    [Fact]
    public void fours_test() 
    {
        Assert.Equal(12, new Yahtzee(4,4,4,5,5).Fours());
        Assert.Equal(8, new Yahtzee(4,4,5,5,5).Fours());
        Assert.Equal(4, new Yahtzee(4,5,5,5,5).Fours());
    }

    [Fact]
    public void fives() {
        Assert.Equal(10, new Yahtzee(4,4,4,5,5).Fives());
        Assert.Equal(15, new Yahtzee(4,4,5,5,5).Fives());
        Assert.Equal(20, new Yahtzee(4,5,5,5,5).Fives());
    }

    [Fact]
    public void sixes_test() 
    {
        Assert.Equal(0, new Yahtzee(4,4,4,5,5).sixes());
        Assert.Equal(6, new Yahtzee(4,4,6,5,5).sixes());
        Assert.Equal(18, new Yahtzee(6,5,6,6,5).sixes());
    }

    [Fact]
    public void one_pair() 
    {
        Assert.Equal(6, Yahtzee.ScorePair(3,4,3,5,6));
        Assert.Equal(10, Yahtzee.ScorePair(5,3,3,3,5));
        Assert.Equal(12, Yahtzee.ScorePair(5,3,6,6,5));
    }

    [Fact]
    public void two_Pair() 
    {
        Assert.Equal(16, Yahtzee.TwoPair(3,3,5,4,5));
        Assert.Equal(0, Yahtzee.TwoPair(3,3,5,5,5));
    }

    [Fact]
    public void three_of_a_kind() 
    {
        Assert.Equal(9, Yahtzee.ThreeOfAKind(3,3,3,4,5));
        Assert.Equal(15, Yahtzee.ThreeOfAKind(5,3,5,4,5));
        Assert.Equal(0, Yahtzee.ThreeOfAKind(3,3,3,3,5));
    }

    [Fact]
    public void four_of_a_knd() 
    {
        Assert.Equal(12, Yahtzee.FourOfAKind(3,3,3,3,5));
        Assert.Equal(20, Yahtzee.FourOfAKind(5,5,5,4,5));
        Assert.Equal(0, Yahtzee.FourOfAKind(3,3,3,3,3));
    }

    [Fact]
    public void smallStraight() 
    {
        Assert.Equal(15, Yahtzee.SmallStraight(1,2,3,4,5));
        Assert.Equal(15, Yahtzee.SmallStraight(2,3,4,5,1));
        Assert.Equal(0, Yahtzee.SmallStraight(1,2,2,4,5));
    }

    [Fact]
    public void largeStraight() 
    {
        Assert.Equal(20, Yahtzee.LargeStraight(6,2,3,4,5));
        Assert.Equal(20, Yahtzee.LargeStraight(2,3,4,5,6));
        Assert.Equal(0, Yahtzee.LargeStraight(1,2,2,4,5));
    }

    [Fact]
    public void fullHouse() 
    {
        Assert.Equal(18, Yahtzee.FullHouse(6,2,2,2,6));
        Assert.Equal(0, Yahtzee.FullHouse(2,3,4,5,6));
}
    }
}