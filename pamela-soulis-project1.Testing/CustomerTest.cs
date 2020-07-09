using Microsoft.VisualStudio.TestTools.UnitTesting;
using pamela_soulis_project1.Domain.Model;
using System;
using Xunit;


namespace pamela_soulis_project1.Testing 
{
    [TestClass]
    public class CustomerTest
    {
        private readonly Customer _customer = new Customer();

        [Fact]
        public void CustomerNameNotEmptyOrNull()
        {

            Assert.ThrowsException<ArgumentException>(() => _customer.FirstName = string.Empty);

        }
        [Fact]
        public void TheCustomerNameNotEmptyOrNull()
        {

            Assert.ThrowsException<ArgumentException>(() => _customer.LastName = string.Empty);

        }


        [Fact]
        public void FirstNameNonEmptyValueStoresCorrectly()
        {
            string randomFirstNameValue = "Ashley";
            _customer.FirstName = randomFirstNameValue;
            Assert.AreEqual(randomFirstNameValue, _customer.FirstName);
        }

        [Fact]
        public void LastNameNonEmptyValueStoresCorrectly()
        {
            string randomLastNameValue = "Gomez";
            _customer.LastName = randomLastNameValue;
            Assert.AreEqual(randomLastNameValue, _customer.LastName);
        }

    }
}
