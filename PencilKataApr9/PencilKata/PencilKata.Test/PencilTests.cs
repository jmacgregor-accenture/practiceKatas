using PencilKata.Desk;
using Xunit;
using Shouldly;

namespace PencilKata.Test
{
    public class PencilTests
    {
        [Fact]
        public void WhenInstantiatingPencilItHasPointDurability()
        {
            var pencil = new Pencil();

            pencil.Durability.ShouldBe(25);
        }

        [Fact]
        public void WhenWritingPencilDurabilityDegrades()
        {
            var testString = "Writing a thing...";
            var pencil = new Pencil();

            pencil.Write(testString);
            
            pencil.Durability.ShouldBeLessThan(25);
        }
        
        [Fact]
        public void WhenWritingPencilReturnsInput()
        {
            var testString = "Seven";
            var pencil = new Pencil();

            var result = pencil.Write(testString);
            
            result.ShouldBe(testString);
        }
    }
}