using PromotionEngine;
using Xunit;

namespace Engine.Tests
{
    public class CartTests
    {
        [Fact]
        public void HoldsData()
        {
            //Arrange
            Product a = new() { ID = "A", Price = 50m };
            Product b = new() { ID = "B", Price = 30m };
            Product c = new() { ID = "C", Price = 20m };
            Product d = new() { ID = "D", Price = 15m };

            //Act
            Cart cart = new();
            cart.AddItem(a, 1);
            cart.AddItem(b, 1);
            cart.AddItem(c, 1);
            cart.AddItem(d, 1);
            Product[] products = cart.Items;

            //Assert
            Assert.Equal(4, products.Length);
            Assert.Equal(a, products[0]);
            Assert.Equal(b, products[1]);
            Assert.Equal(c, products[2]);
            Assert.Equal(d, products[3]);

        }
    }
}
