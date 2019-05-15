namespace Models
{
    public class SpecialOffer
    {
        public SpecialOffer(int noOfItems, int offerPrice)
        {
            NoOfItemsForOffer = noOfItems;
            OfferPrice = offerPrice;
        }
        public int NoOfItemsForOffer { get; set; }
        public int OfferPrice { get; set; }
    }
}
