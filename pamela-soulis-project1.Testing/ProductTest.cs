using Microsoft.VisualStudio.TestTools.UnitTesting;
using pamela_soulis_project1.Domain.Model;
using System;
using Xunit;


namespace pamela_soulis_project1.Testing
{
    [TestClass]
    public class ProductTest
    {
        private readonly Product _product = new Product();

        [Fact]
        public void ProductNameNotEmptyOrNull()
        {

            Assert.ThrowsException<ArgumentException>(() => _product.Name = string.Empty);

        }
        [Fact]
        public void ProductPriceNotZero()
        {
            Assert.ThrowsException<ArgumentException>(() => _product.Price = 0);
        }
    }
}