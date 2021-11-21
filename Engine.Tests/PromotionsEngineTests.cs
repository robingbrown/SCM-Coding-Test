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

        [Fact]
        public void BuyCandD()
        {
            //Arrange
            Product c = new() { ID = "C", Price = 20m };
            Product d = new() { ID = "D", Price = 15m };
            Cart cart = new();
            cart.AddItem(c, 1);
            cart.AddItem(d, 1);

            //Act
            PromotionsEngine engine = new();
            decimal totalordervalue = engine.Calculate(cart);

            //Assert
            Assert.Equal(30m, totalordervalue);

        }
    
        [Fact]
        public void ScenarioA()
        {
            //Arrange
            Product a = new() { ID = "A", Price = 50m };
            Product b = new() { ID = "B", Price = 30m };
            Product c = new() { ID = "C", Price = 20m };
            //Product d = new() { ID = "D", Price = 15m };
            Cart cart = new();
            cart.AddItem(a, 1);
            cart.AddItem(b, 1);
            cart.AddItem(c, 1);
            //cart.AddItem(d, 1);

            //Act
            PromotionsEngine engine = new();
            decimal totalordervalue = engine.Calculate(cart);

            //Assert
            Assert.Equal(100m, totalordervalue);
        }
    }
}
