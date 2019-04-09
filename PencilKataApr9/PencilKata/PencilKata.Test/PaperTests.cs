using System;
using PencilKata.Library;
using Xunit;
using Shouldly;

namespace PencilKata.Test
{
    public class PaperTests
    {
        [Fact]
        public void WhenWritingTextIsStored()
        {
            var testString = "She sells sea shells";
            var paper = new Paper();

            paper.Write(testString);

            paper.Contents.ShouldBe(testString);
        }
    }
}