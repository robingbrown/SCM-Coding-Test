using System;
using Xunit;
using PromotionEngine;

namespace Engine.Tests
{
    public class CartTests
    {
        [Fact]
        public void HoldsData()
        {
            //Arrange
            Product a = new Product { ID = "A", Price = 50m };
            Product b = new Product { ID = "B", Price = 30m };
            Product c = new Product { ID = "C", Price = 20m };
            Product d = new Product { ID = "D", Price = 15m };

            //Act
            Cart cart = new Cart();
            cart.AddItem(a);
            cart.AddItem(b);
            cart.AddItem(c);
            cart.AddItem(d);
            Product[] products = cart.Items();

            //Assert
            Assert.Equal(4, products.Length);
            Assert.Equal(a, products[0]);
            Assert.Equal(b, products[1]);
            Assert.Equal(c, products[2]);
            Assert.Equal(d, products[3]);

        }
    }
}
