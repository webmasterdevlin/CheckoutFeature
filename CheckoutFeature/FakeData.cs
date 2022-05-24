using CheckoutFeature.Products;
using CheckoutFeature.Promos;

namespace CheckoutFeature;

public static class FakeData
{
    public static IEnumerable<Product> GetProducts()
    {
        return new List<Product>
        {
            new PairsProduct
            {
                Id = Guid.NewGuid(),
                Name = "Rubber Gloves",
                Price = 59.90,
                PLU = "A",
                Quantity = 5,
                Promo = new BuyTwoGetOnePromo 
                { 
                   Id = Guid.NewGuid(),
                   OnSale = true,
                   PercentageOfDiscount = 100,
                   ProductQuantityToGetDiscount = 3
                }
            },
            // new SingleProduct
            // {
            //     Id = Guid.NewGuid(),
            //     Name = "Stethoscope",
            //     Price = 399,
            //     PLU = "B",
            //     Quantity = 5,
            //     Promo = new BuyThreePiecesForFixPricePromo()
            //     {
            //         Id = Guid.NewGuid(),
            //         FixPrice = 999,
            //         OnSale = true,
            //         ProductQuantityToGetDiscount = 3
            //     }
            // },
            // new WeightProduct
            // {
            //     Id = Guid.NewGuid(),
            //     Name = "Talc",
            //     WeightInKiloGrams = 0.1,
            //     Price = 19.54,
            //     PLU = "C"
            // }
        };
    }
}