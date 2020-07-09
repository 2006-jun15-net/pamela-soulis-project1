using Microsoft.VisualStudio.TestTools.UnitTesting;
using pamela_soulis_project1.Domain.Model;
using System;
using Xunit;


namespace pamela_soulis_project1.Testing
{
    [TestClass]
    public class OrderlineTest
    {
        private readonly OrderLine _orderline = new OrderLine();


        [Fact]
        public void OrderlineProductQuantityNotNegative() 
        {
            Assert.ThrowsException<ArgumentException>(() => _orderline.Quantity = -2);
        }
    }

}
