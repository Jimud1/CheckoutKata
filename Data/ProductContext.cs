using Models;
using System.Collections.Generic;

namespace Data
{
    public class ProductContext
    {
        public ProductContext()
        {
            //Simple setup
            var a = new Product("A", 50, new SpecialOffer(3, 130));
            var b = new Product("B", 30, new SpecialOffer(2, 45));
            var c = new Product("C", 20, null);
            var d = new Product("D", 15, null);
            _products.Add(a);
            _products.Add(b);
            _products.Add(c);
            _products.Add(d);
        }

        public List<Product> _products = new List<Product>();
        
    }
}
