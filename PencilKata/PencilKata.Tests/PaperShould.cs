using PencilKata.Library;
using Xunit;
using Shouldly;

namespace PencilKata.Tests
{
    public class PaperShould
    {
        [Fact]
        public void WriteToPaper()
        {
            IWritable paper = new Paper();
            var testString = "I am a string";

            paper.Write(testString);

            paper.Read().ShouldBe(testString);
        }
    }
}