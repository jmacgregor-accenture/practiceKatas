using System;
using System.Runtime.InteropServices.ComTypes;
using NSubstitute;
using NSubstitute.Core.Arguments;
using NSubstitute.ReceivedExtensions;
using PencilKata.Library;
using Shouldly;
using Xunit;

namespace PencilKata.Tests
{
    public class WritingTests
    {
        [Fact]
        public void WhenWritingAStringReturnsTheString()
        {
            var pencil = new Pencil();
            var testString = "test";
            var expectedString = "test";

            var result = pencil.Write(testString);
            
            result.ShouldBe(expectedString);
        }

        [Fact(Skip = "Need to test Paper")]
        public void WhenWritingOnPaperWrittenStringAppearsOnPaper()
        {
            var pencil = new Pencil();
            var paper = new Paper();
            var testString = "test";
            var expectedString = "test";

            pencil.WriteTo(paper, testString);
            
            paper.Contents.ShouldBe(expectedString);
        }
    }
}