using NSubstitute;
using NSubstitute.Exceptions;
using PencilKata.Library;
using Shouldly;
using Xunit;

namespace PencilKata.Tests
{
    public class PencilShould
    {
        [Fact]
        public void WriteToPaper()
        {
            var paper = Substitute.For<IWritable>();
            var pencil = new Pencil();
            var testString = "writing";

            pencil.Write(paper, testString);

            paper.Received(1).Write(testString);
        }
    }
}