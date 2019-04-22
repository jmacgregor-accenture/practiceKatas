using System;
using PencilKata.Library;
using Shouldly;
using Xunit;

namespace PencilKata.Tests
{
    public class PaperShould
    {
        [Fact]
        public void DisplaySingleString()
        {
            var paper = new Paper();
            var testString = "testing";

            paper.Write(testString);

            paper.Read().ShouldBe(testString);
        }
    }
}