using Data;
using NUnit.Framework;
using Services;
using System;

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
        public void ItemDidntScan()
        {
            var test = "z";
            var ex = Assert.Throws<ArgumentException>(() => _checkout.Scan(test));
            Assert.That(ex.Message, Is.EqualTo("This item doesn't exist"));
        }

        [Test]
        public void ItemDidScanPass()
        {
            var test = "a";
            Assert.DoesNotThrow(() => _checkout.Scan(test));
        }

        [Test]
        public void SimpleCalculatePrice()
        {
            //assemble
            var itemA = "a";
            //act
            _checkout.Scan(itemA);
            var result = _checkout.GetTotalPrice();
            //asset
            Assert.AreEqual(new ProductContext()._products.Find(p => p.SKU .ToLower()== itemA).UnitPrice, 
                result);
        }
    }
}