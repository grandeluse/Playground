namespace RandomHack.FluentBuilderDesignPatter;

public class Order
{
    public int Number { get; init; }
    public DateTime CreatedOn { get; init; }

    public Address ShippingAddress { get; init; }

    public override string ToString()
    {
        return $"Questo ordine con numero: {Number} è da spedire a {ShippingAddress.City} in {ShippingAddress.Street} in {ShippingAddress.State} in {ShippingAddress.Country}";
    }
}

