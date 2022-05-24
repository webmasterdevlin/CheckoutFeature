namespace CheckoutFeature.Promos;

public class BuyThreePiecesForFixPricePromo : Promo
{
    public int ProductQuantityToGetDiscount { get; set; }
    public double FixPrice { get; set; }
}