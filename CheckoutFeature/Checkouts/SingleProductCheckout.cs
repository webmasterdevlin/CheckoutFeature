using CheckoutFeature.Products;
using CheckoutFeature.Promos;

namespace CheckoutFeature.Checkouts;

public static class SingleProductCheckout
{ 
    public static void AddPriceForSingleProduct(SingleProduct product, List<double> costs)
    {
        var cost = product.Price * product.Quantity;
        
        if (product.Promo is { OnSale: true })
        {
            ComputeOnSalePrice(product, costs, cost);
            return;
        }
        
        costs.Add(cost);
    }

    private static void ComputeOnSalePrice(SingleProduct product, List<double> costs, double cost)
    {
        if (product.Quantity >= (product.Promo as BuyThreePiecesForFixPricePromo)!.ProductQuantityToGetDiscount)
        {
            var discountedPrice = (product.Promo as BuyThreePiecesForFixPricePromo)!.FixPrice;
            
            var discountQuantity = product.Quantity
                                   / (double)(product.Promo as BuyThreePiecesForFixPricePromo)!
                                   .ProductQuantityToGetDiscount;

            var wholeNumberAndDecimals = discountQuantity.ToString().Split('.');
            var wholeNumber = wholeNumberAndDecimals[0];
            
            if (wholeNumberAndDecimals.Length == 2)
            {
                if (ProcessBothDiscountedAndNonDiscounted(product, costs, wholeNumberAndDecimals, wholeNumber, discountedPrice))
                    return;
            }

            var total = double.Parse(wholeNumber) * discountedPrice;
            costs.Add(total);
            return;
        }

        costs.Add(cost);
    }

    public static bool ProcessBothDiscountedAndNonDiscounted(SingleProduct product, List<double> costs, string[] splitNumbers,
        string wholeNumber, double discountedPrice)
    {
        var decimals = splitNumbers[1];
        var firstChar = decimals.Remove(1);
        switch (int.Parse(firstChar))
        {
            case 3:
            {
                ComputeDiscountedWithOneItem(product, costs, wholeNumber, discountedPrice);
                return true;
            }
            case 6:
            {
                ComputeDiscountedPlusTwoItems(product, costs, wholeNumber, discountedPrice);
                return true;
            }
        }

        return false;
    }

    public static void ComputeDiscountedWithOneItem(SingleProduct product, List<double> costs, string wholeNumber,
        double discountedPrice)
    {
        var discountedPriceWithOneNormalPrice = double.Parse(wholeNumber)
                                                * discountedPrice
                                                + product.Price
                                                * 1;
        costs.Add(discountedPriceWithOneNormalPrice);
    }

    public static void ComputeDiscountedPlusTwoItems(SingleProduct product, List<double> costs, string wholeNumber,
        double discountedPrice)
    {
        var discountedPriceWithTwoNormalPrice = double.Parse(wholeNumber)
                                                * discountedPrice
                                                + product.Price
                                                * 2;
        costs.Add(discountedPriceWithTwoNormalPrice);
    }
}