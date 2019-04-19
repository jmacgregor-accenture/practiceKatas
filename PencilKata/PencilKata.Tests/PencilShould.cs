using NSubstitute;
using PencilKata.Library;
using Xunit;
using Shouldly;

namespace PencilKata.Tests
{
    public class PencilShould
    {
        [Fact]
        public void WriteToPaper()
        {
            var pencil = new Pencil(25);
            var paper = Substitute.For<IWritable>();
            var testString = "We writing nao";

            pencil.Write(paper, testString);

            paper.Received(1).Write(testString);
        }

        [Fact]
        public void ReturnSpacesWhenWritingBeyondDurability()
        {
            var pencil = new Pencil(4);
            var paper = Substitute.For<IWritable>();
            
            pencil.Write(paper,"running");
            
            paper.Received(1).Write("runn   ");
        }
    }
}