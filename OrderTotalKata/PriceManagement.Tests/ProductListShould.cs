using Shouldly;
using Xunit;

namespace PriceManagement.Tests
{
    public class ProductListShould
    {
        [Fact]
        public void StartWithNoProducts()
        {
            var productList = new ProductList();

            var result = productList.GetAll();

            result.ShouldBeOfType<Product>();
        }
    }
}