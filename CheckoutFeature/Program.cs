// See https://aka.ms/new-console-template for more information

using CheckoutFeature;
using CheckoutFeature.Checkouts;
using CheckoutFeature.Products;

var prices = new List<double>();

foreach (var product in FakeData.GetProducts())
{
   if (product.GetType() == typeof(PairsProduct))
      PairsProductCheckout.AddPriceForPairsProduct((PairsProduct)product, prices);
   
   if (product.GetType() == typeof(SingleProduct))
      SingleProductCheckout.AddPriceForSingleProduct((SingleProduct)product, prices);
   
   if (product.GetType() == typeof(WeightProduct))
      WeightProductCheckout.AddPriceForWeightProduct((WeightProduct)product, prices);
   
}

var totalPrice = prices.Sum();

Console.WriteLine("Total Price: " + totalPrice);
Console.ReadLine();