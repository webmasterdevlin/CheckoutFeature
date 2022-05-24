using CheckoutFeature.Products;

namespace CheckoutFeature.Checkouts;

public static class WeightProductCheckout
{
    public static void AddPriceForWeightProduct(WeightProduct product, List<double> costs)
    {
        var price = product.Price * product.WeightInKiloGrams;
        if (product.Promo is { OnSale: true })
        {
            // TODO: Implement if needed
        }
        costs.Add(price);
    }  
}