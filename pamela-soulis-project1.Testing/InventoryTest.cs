using Microsoft.VisualStudio.TestTools.UnitTesting;
using pamela_soulis_project1.Domain.Model;
using System;
using Xunit;


namespace pamela_soulis_project1.Testing
{
    [TestClass]
    public class InventoryTest
    {
        private readonly Inventory _inventory = new Inventory();

        
        [Fact]
        public void InventoryQuantityNotNegative()
        {
            Assert.ThrowsException<ArgumentException>(() => _inventory.Quantity = -2);
        }
    }

}
