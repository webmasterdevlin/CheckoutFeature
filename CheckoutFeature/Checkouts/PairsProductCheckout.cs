using CheckoutFeature.Products;
using CheckoutFeature.Promos;

namespace CheckoutFeature.Checkouts;

public static class PairsProductCheckout
{
    public static void AddPriceForPairsProduct(PairsProduct product, List<double> prices)
    {
        var cost = product.Price * product.Quantity;
        cost = ProcessIfPromoIsOn(product, cost);
        prices.Add(cost);
    }

    public static double ProcessIfPromoIsOn(PairsProduct product, double cost)
    {
        if (product.Promo is not { OnSale: true }) return cost;
        if (product.Quantity < (product.Promo as BuyTwoGetOnePromo)!.ProductQuantityToGetDiscount) return cost;
        
        cost = ComputePrice(product, cost);

        return cost;
    }

    public static double ComputePrice(PairsProduct product, double cost)
    {
        var discountedPrice = (product.Promo as BuyTwoGetOnePromo)!.PercentageOfDiscount / 100 * cost;
        var discountQuantity = Math.Floor((double)
                                          product.Quantity
                                          / (product.Promo as BuyTwoGetOnePromo)!.ProductQuantityToGetDiscount);
        cost = discountedPrice - product.Price * discountQuantity;
        return cost;
    }
}