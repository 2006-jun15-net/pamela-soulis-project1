using Microsoft.EntityFrameworkCore;
using pamela_soulis_project1.DataAccess.Model;
using pamela_soulis_project1.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Text;
using System.Text.RegularExpressions;

namespace pamela_soulis_project1.Domain.Repositories 
{



    public class CustomerRepository : GenericRepository<pamela_soulis_project1.DataAccess.Model.Customer, pamela_soulis_project1.Domain.Model.Customer>
    {

        public CustomerRepository(pamelasoulisproject1Context _context) : base(_context)
        {

        }

        



        /// <summary>
        /// Takes in a customer's ID and gives access to navigation properties
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public pamela_soulis_project1.Domain.Model.Customer GetWithNavigations(int customerId)
        {
            var customer = table
                .Include(c => c.Orders)
                    .ThenInclude(o => o.OrderLine)
                        .ThenInclude(o1 => o1.Product)
                 .First(i => i.CustomerId == customerId);


            var businessCustomer = mapper.Map<pamela_soulis_project1.Domain.Model.Customer>(customer);
            return businessCustomer;
        }

        


        /// <summary>
        /// Returns the customer to be added to the database, given their first and last name
        /// </summary>
        /// <param name="customerfirstname"></param>
        /// <param name="customerlastname"></param>
        /// <returns></returns>
        
        public pamela_soulis_project1.Domain.Model.Customer AddCustomer(pamela_soulis_project1.Domain.Model.Customer customer)
        {
            var entity = new pamela_soulis_project1.Domain.Model.Customer { FirstName = customer.FirstName, LastName = customer.LastName };            
            return entity;

        }


        public IEnumerable<pamela_soulis_project1.Domain.Model.Customer> SearchByName(string search)
        {
            var person = table
                .Where(c => c.LastName.Contains(search));


            var businessCustomer = mapper.Map<IEnumerable<Domain.Model.Customer>>(person);
            return businessCustomer;

        }

    }
}
