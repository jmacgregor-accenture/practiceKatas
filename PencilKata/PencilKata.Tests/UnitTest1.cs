using System;
using PencilKata.Library;
using Xunit;

namespace PencilKata.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void CanWriteTextOnPaperWithPencil()
        {
            var pencil = new Pencil();
            var paper = new Paper();

            paper.Write(pencil, "Hello World");
            
            Assert.Equal("Hello World", paper.Writing);
        }
    }
}