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
            var pencil = new Pencil();
            var paper = Substitute.For<IWritable>();
            var testString = "We writing nao";

            pencil.Write(paper, testString);

            paper.Received(1).Write(testString);
        }
    }
}