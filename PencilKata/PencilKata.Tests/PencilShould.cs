using NSubstitute;
using PencilKata.Library;
using Xunit;
using Shouldly;

namespace PencilKata.Tests
{
    public class PencilShould
    {
        private IWritable paper = Substitute.For<IWritable>();
        
        [Fact]
        public void WriteToPaper()
        {
            var pencil = new Pencil(25);
            var testString = "We writing nao";

            pencil.Write(paper, testString);

            paper.Received(1).Write(testString);
        }

        [Fact]
        public void ReturnSpacesWhenWritingBeyondDurability()
        {
            var pencil = new Pencil(4);
            
            pencil.Write(paper,"running");
            
            paper.Received(1).Write("runn   ");
        }

        [Fact]
        public void NotDegradeWhenWritingWhiteSpace()
        {
            var pencil = new Pencil(6);

            pencil.Write(paper,"boo boo");
            
            paper.Received(1).Write("boo boo");
        }

        [Fact]
        public void DegradeTwiceAsFastWritingUpperCaseLetters()
        {
            var pencil = new Pencil(4);
            
            pencil.Write(paper, "Boot");
            
            paper.Received(1).Write("Boo ");
        }
    }
}