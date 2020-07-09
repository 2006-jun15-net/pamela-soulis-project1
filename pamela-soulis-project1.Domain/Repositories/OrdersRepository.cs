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



    public class OrdersRepository : GenericRepository<pamela_soulis_project1.DataAccess.Model.Orders, pamela_soulis_project1.Domain.Model.Orders>
    {

        public OrdersRepository(pamelasoulisproject1Context _context) : base(_context)
        {

        }


        /// <summary>
        /// Count for next order ID
        /// </summary>
        /// <returns></returns>
        public int NewOrder()
        {

            int thisOrderId = table.Count() + 3;
            return thisOrderId;

        }


        /// <summary>
        /// Returns the order to be added to the database, given customer ID and location ID
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="locationId"></param>
        /// <returns></returns>
        public Orders AddingANewOrder(int customerId, int locationId)
        {
            DateTime date = DateTime.Now;
            var orderDate = DateTime.Today;
            var orderTime = date.TimeOfDay;
            var theOrderToBeAdded = new Orders { CustomerId = customerId, LocationId = locationId, Date = orderDate };
            return theOrderToBeAdded;
        }

        //var businessCustomer = mapper.Map<Customer>(customer);


        public void AddOrder(Orders order, Domain.Model.Customer customer, Domain.Model.Location location)
        {
            //if (customer != null & location != null)
            //{

            //}
            var orderDate = DateTime.Today;
            var orderEntity = new Orders { CustomerId = customer.CustomerId, LocationId = location.LocationId, Date = orderDate };
            _context.Orders.Add(orderEntity);
        }

        //public void AddCustomer(Customer customer)
        //{
        //    var entity = new Customer { FirstName = customer.FirstName, LastName = customer.LastName };
        //    _context.Customer.Add(entity);

        //}
    }
}
