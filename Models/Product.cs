namespace Models
{
    public class Product
    {
        public Product(string sku, int unitPrice, SpecialOffer specialOffer)
        {
            SKU = sku;
            UnitPrice = unitPrice;
            SpecialOffer = specialOffer;
        }
        public string SKU { get; set; }
        public int UnitPrice { get; set; }
        public SpecialOffer SpecialOffer { get; set; }
    }
}
