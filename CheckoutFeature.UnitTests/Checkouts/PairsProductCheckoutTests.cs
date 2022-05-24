using System;
using CheckoutFeature.Checkouts;
using CheckoutFeature.Products;
using CheckoutFeature.Promos;
using Xunit;

namespace CheckoutFeature.UnitTests.Checkouts;

public class PairsProductCheckoutTests
{
    [Theory]
    [InlineData(1)]
    public void ComputePrice_OneItem_ExactPrice(int quantity)
    {
        // Arrange
        var product = new PairsProduct
        {
            Price = 59.90,
            Quantity = quantity,
            Promo = new BuyTwoGetOnePromo
            {
                Id = Guid.NewGuid(),
                OnSale = true,
                PercentageOfDiscount = 100,
                ProductQuantityToGetDiscount = 3
            }
        };
        var cost = product.Price * quantity;
        
        // Act
        cost = PairsProductCheckout.ComputePrice(product, cost);
        
        // Assert
        Assert.Equal(59.90, cost);
    }
    
    [Theory]
    [InlineData(5)]
    public void ComputePrice_FiveItems_ExactPrice(int quantity)
    {
        // Arrange
        var product = new PairsProduct
        {
            Price = 59.90,
            Quantity = quantity,
            Promo = new BuyTwoGetOnePromo
            {
                Id = Guid.NewGuid(),
                OnSale = true,
                PercentageOfDiscount = 100,
                ProductQuantityToGetDiscount = 3
            }
        };
        var cost = quantity * product.Price;
        
        // Act
        cost = PairsProductCheckout.ComputePrice(product, cost);
        
        // Assert
        Assert.Equal(239.6, cost);
    }
}