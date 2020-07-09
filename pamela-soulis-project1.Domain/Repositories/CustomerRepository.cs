using Microsoft.EntityFrameworkCore;
using pamela_soulis_project1.DataAccess.Model;
using pamela_soulis_project1.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace pamela_soulis_project1.Domain.Repositories 
{



    public class CustomerRepository : GenericRepository<pamela_soulis_project1.DataAccess.Model.Customer, pamela_soulis_project1.Domain.Model.Customer>
    {

        public CustomerRepository(pamelasoulisproject1Context _context) : base(_context)
        {

        }


        //public void DisplayCustomer()
        //{
        //    var pastCustomers = GetAll().ToList();
        //    foreach (var person in pastCustomers)
        //    {
        //        Console.WriteLine($"{person.FirstName}.");
        //    }
        //}




        /// <summary>
        /// Takes in a customer's ID and gives access to navigation properties
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public Customer GetWithNavigations(int customerId)
        {
            var customer = table
                .Include(c => c.Orders)
                    .ThenInclude(o => o.OrderLine)
                        .ThenInclude(o1 => o1.Product)
                 .First(i => i.CustomerId == customerId);


            var businessCustomer = mapper.Map<Customer>(customer);
            return businessCustomer;
        }


        /// <summary>
        /// Returns the customer to be added to the database, given their first and last name
        /// </summary>
        /// <param name="customerfirstname"></param>
        /// <param name="customerlastname"></param>
        /// <returns></returns>
        public Customer AddingANewCustomer(string customerfirstname, string customerlastname)
        {
            var theCustomerToBeAdded = new Customer { FirstName = customerfirstname, LastName = customerlastname };
            //var businessCustomerToBeAdded = mapper.Map<Customer>(theCustomerToBeAdded);
            return theCustomerToBeAdded; 
        }


        public void AddCustomer(Customer customer)
        {
            var entity = new Customer { FirstName = customer.FirstName, LastName = customer.LastName };
            _context.Customer.Add(entity);

        }
    }
}
