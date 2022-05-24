using CheckoutFeature.Promos;

namespace CheckoutFeature.Products;

public abstract class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string PLU { get; set; }
    public double Price { get; set; }
    public Promo? Promo { get; set; }
}