using NUnit.Framework;
using Models;
using Services;

namespace Tests
{
    public class Tests
    {
        ICheckout _checkout;
        [SetUp]
        public void Setup()
        {
            //simple setup
            _checkout = new Checkout();
        }

        [Test]
        public void SimpleCalculatePrice()
        {
            //assemble
            var itemA = new Product("hello", 1, null);
            //act
            _checkout.Scan(itemA.SKU);
            var result = _checkout.GetTotalPrice();
            //asset
            Assert.AreEqual(itemA.UnitPrice, result);
        }
    }
}