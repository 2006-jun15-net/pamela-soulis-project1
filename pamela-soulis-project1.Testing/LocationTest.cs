using Microsoft.VisualStudio.TestTools.UnitTesting;
using pamela_soulis_project1.Domain.Model;
using System;
using Xunit;


namespace pamela_soulis_project1.Testing 
{
    [TestClass]
    public class LocationTest
    {
        private readonly Location _location = new Location();

        [Fact]
        public void LocationNameNotEmptyOrNull()
        {

            Assert.ThrowsException<ArgumentException>(() => _location.Name = string.Empty);

        }


        [Fact]
        public void NameNonEmptyValueStoresCorrectly()
        {
            string randomNameValue = "Zara";
            _location.Name = randomNameValue;
            Assert.AreEqual(randomNameValue, _location.Name);
        }

    }
}
