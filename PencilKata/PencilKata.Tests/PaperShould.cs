using System;
using PencilKata.Library;
using Shouldly;
using Xunit;

namespace PencilKata.Tests
{
    public class PaperShould
    {
        [Theory]
        [InlineData("testing", "testing")]
        [InlineData("banana", "banana")]
        public void DisplaySingleString(string testString, string expected)
        {
            var paper = new Paper();

            paper.Write(testString);

            paper.Read().ShouldBe(expected);
        }
    }
}