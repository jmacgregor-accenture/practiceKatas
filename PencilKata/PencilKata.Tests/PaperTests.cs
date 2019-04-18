using System.Dynamic;
using PencilKata.Library;
using Xunit;
using Shouldly;

namespace PencilKata.Tests
{
    public class PaperTests
    {
        [Fact]
        public void WhenAddingOneStringToPaperContentsDisplaysTheString()
        {
            var paper = new Paper();
            var testString = "Howdy Hey";
            var expectedString = "Howdy Hey";
            
            paper.Write(testString);
            
            paper.Contents.ShouldBe(expectedString);
        }

        [Fact]
        public void WhenAddingTwoStringsTheSecondIsAppendedToFirst()
        {
            var paper = new Paper();
            var firstString = "Howdy Hey";
            var secondString = " Partner Jones!";
            var expectedString = "Howdy Hey Partner Jones!";
            
            paper.Write(firstString);
            paper.Write(secondString);
            
            paper.Contents.ShouldBe(expectedString);
        }
    }
}