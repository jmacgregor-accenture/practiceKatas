using System;
using PencilKata.Library;
using Xunit;
using Shouldly;

namespace PencilKata.Tests
{
    public class PencilTests
    {
        [Fact]
        public void WhenWritingOnPaperTextIsAdded()
        {
            var testString = "She sells sea shells";
            var paper = new Paper();
            var pencil = new Pencil(paper);

            pencil.Write(testString);

            paper.Text.ShouldBe(testString);
        }
    }

    
}