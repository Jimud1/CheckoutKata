using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class Checkout : ICheckout
    {
        private List<Product> _basket;
        private List<Product> _predefinedProducts;
        public Checkout()
        {
            _predefinedProducts = new ProductContext()._products;
            _basket = new List<Product>();
        }
        public int GetTotalPrice()
        {
            int result = 0;
            foreach(var product in _basket)
            {
                result += product.UnitPrice;
            }

            var offerProducts = _basket.Where(x => x.SpecialOffer != null).ToList();
            foreach (var val in CalculateSpecialOffer(offerProducts))
            {
                result += val;
            }

            return result;
        }

        private bool ConditionMet(Product product)
        {
            return _basket.Where(p => p.SKU == product.SKU).Count() >= product.SpecialOffer.NoOfItemsForOffer;
        }


        public void Scan(string item)
        {
            var itemToAdd = _predefinedProducts.Find(p => p.SKU.ToLower() == item);
            if (itemToAdd == null) throw new ArgumentException("This item doesn't exist");
            _basket.Add(itemToAdd);
        }

        /// <summary>
        /// Apply special offer to product
        /// </summary>
        /// <param name="specialOffers"></param>
        /// <returns>toRemove, toAdd</returns>
        private int[] CalculateSpecialOffer(List<Product> specialOffers)
        {
            var query = specialOffers.GroupBy(p => p.SKU);
            int toAdd = 0,
                toRemove = 0;

            foreach (var productGroup in query)
            {
                //Get the special offer model
                var product = productGroup.Select(p => p).FirstOrDefault();
                //Get how many items we need for offer to apply
                int offerOn = product.SpecialOffer.NoOfItemsForOffer;
                int offerPrice = product.SpecialOffer.OfferPrice;
                for (int i = 0; i <= Qualify(productGroup.Count(), offerOn) - 1; i++)
                {
                    toAdd += offerPrice;
                    toRemove -= product.UnitPrice * offerOn;
                }
            }
            return new int[] { toRemove, toAdd };
        }

        /// <summary>
        /// How many offers to apply
        /// </summary>
        /// <param name="products"></param>
        /// <param name="offerOn"></param>
        /// <returns></returns>
        int Qualify(int products, int offerOn)
        {
            return products / offerOn;
        }
    }
}
