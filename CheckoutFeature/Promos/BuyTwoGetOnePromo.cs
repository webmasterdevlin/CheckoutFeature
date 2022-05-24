namespace CheckoutFeature.Promos;

public class BuyTwoGetOnePromo : Promo
{
    public int ProductQuantityToGetDiscount { get; set; }
    public int PercentageOfDiscount { get; set; }
}