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
            var pencil = new Pencil(15);
            var testString = "writing";

            pencil.Write(paper, testString);

            paper.Received(1).Write(testString);
        }

        [Fact]
        public void DegradeAsWrites()
        {
            var paper = Substitute.For<IWritable>();
            var pencil = new Pencil(4);
            var testString = "writing";
            var expectedString = "writ   ";
            
            pencil.Write(paper, testString);
            
            paper.Received(1).Write(expectedString);
        }
    }
}