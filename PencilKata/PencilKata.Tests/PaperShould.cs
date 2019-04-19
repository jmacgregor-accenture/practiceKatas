using PencilKata.Library;
using Xunit;
using Shouldly;

namespace PencilKata.Tests
{
    public class PaperShould
    {
        [Theory]
        [InlineData("I am a string", "I am a string")]
        [InlineData("I am also a string", "I am also a string")]
        public void ReturnWrittenString(string stringToWrite, string expectedString)
        {
            IWritable paper = new Paper();

            paper.Write(stringToWrite);

            paper.Read().ShouldBe(expectedString);
        }

        [Fact]
        public void ReturnMultipleWrittenStrings()
        {
            IWritable paper = new Paper();
            var stringOne = "I am the first string";
            var stringTwo = " and I am the second one";
            
            paper.Write(stringOne);
            paper.Write(stringTwo);
            
            paper.Read().ShouldBe(stringOne + stringTwo);
        }
    }
}