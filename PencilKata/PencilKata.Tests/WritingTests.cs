using System;
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
    }
}