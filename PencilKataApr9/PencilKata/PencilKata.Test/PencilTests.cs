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
    }
}