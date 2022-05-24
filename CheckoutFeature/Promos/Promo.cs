namespace CheckoutFeature.Promos;

public abstract class Promo
{
    public Guid Id { get; set; }
    public bool OnSale { get; set; }
}