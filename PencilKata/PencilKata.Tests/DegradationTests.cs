using PencilKata.Library;
using Xunit;
using Shouldly;

namespace PencilKata.Tests
{
    public class DegradationTests
    {
        [Fact]
        public void WhenWritingPastDurabilityIsZeroOnlyWhiteSpaceIsReturned()
        {
            var pencil = new Pencil(4);
            var testString = "hello";
            var expectedString = "hell ";

            var result = pencil.Write(testString);
            
            result.ShouldBe(expectedString);
        }

        [Fact]
        public void WhenWritingToSurfacePastDurabilityZeroOnlyWhiteSpaceIsOnSurface()
        {
            var pencil = new Pencil(4);
            var paper = new Paper();
            var testString = "hello";
            var expectedString = "hell ";

            pencil.WriteTo(paper, testString);
            
            paper.Contents.ShouldBe(expectedString);
        }

        [Fact]
        public void WhenWritingUpperCaseLettersSharpnessIsLostTwiceAsFast()
        {
            var pencil = new Pencil(4);
            var paper = new Paper();
            var testString = "HELLO";
            var expectedString = "HE   ";
            
            pencil.WriteTo(paper, testString);
            
            paper.Contents.ShouldBe(expectedString);
        }
    }
}