using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using PromotionEngine;

namespace Engine.Tests
{
    public class PromotionsEngineTests
    {
        [Fact]
        public void BuyNItems()
        {
            //Arrange
            Product a1 = new() { ID = "A", Price = 50m };
            Product a2 = new() { ID = "A", Price = 30m };
            Product a3 = new() { ID = "A", Price = 20m };
            Cart cart = new();
            cart.AddItem(a1);
            cart.AddItem(a2);
            cart.AddItem(a3);

            //Act
            PromotionsEngine engine = new();
            decimal totalordervalue =  engine.Calculate(cart);

            //Assert
            Assert.Equal(130m, totalordervalue);

        }
    }
}
