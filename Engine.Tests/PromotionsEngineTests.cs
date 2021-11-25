using PromotionEngine;
using System.Collections.Generic;
using Xunit;
using Moq;

namespace Engine.Tests
{
    public class PromotionsEngineTests
    {
        [Fact]
        public void CalculateTest()
        {
            //Arrange
            Product a = new() { ID = "A", Price = 50m };
            Cart cart = new();
            cart.AddItem(a, 1);
            var mockPromotion = new Mock<IPromotion>();
            mockPromotion.Setup(x => x.Discount(cart)).Returns(20);
            List<IPromotion> promotions = new();
            promotions.Add(mockPromotion.Object);

            //Act
            decimal totalordervalue = PromotionsEngine.Calculate(cart, promotions);

            //Assert
            Assert.Equal(30m, totalordervalue);

        }


        [Fact]
        public void NoPromotions()
        {

            //Arrange
            Product a = new() { ID = "A", Price = 50m };
            Cart cart = new();
            cart.AddItem(a, 1);
            List<IPromotion> promotions = new();

            //Act
            decimal totalordervalue = PromotionsEngine.Calculate(cart, promotions);

            //Assert
            Assert.Equal(50m, totalordervalue);
        }


    }
}
