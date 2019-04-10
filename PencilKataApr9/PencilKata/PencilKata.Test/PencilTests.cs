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

        [Fact]
        public void WhenWritingPastDurabilityDurabilityShowsZero()
        {
            var testString = "Seven";
            var pencil = new Pencil(2);

            var result = pencil.Write(testString);

            pencil.Durability.ShouldBe(0);
        }

        [Fact]
        public void WhenWritingUpperCaseDurabilityDegradesTwiceAsFast()
        {
            var testString = "SEV";
            var pencil = new Pencil(5);

            var result = pencil.Write(testString);
            
            pencil.Durability.ShouldBe(0);
        }

        [Fact]
        public void WhenWritingSpacesDurabilityDoesNotDegrade()
        {
            var testString = "  ";
            var pencil = new Pencil(5);

            var result = pencil.Write(testString);
            
            pencil.Durability.ShouldBe(5);
        }
    }
}