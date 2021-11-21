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
            Product a = new() { ID = "A", Price = 50m };
            Cart cart = new();
            cart.AddItem(a, 3);

            //Act
            PromotionsEngine engine = new();
            decimal totalordervalue =  engine.Calculate(cart);

            //Assert
            Assert.Equal(130m, totalordervalue);

        }
    }
}
