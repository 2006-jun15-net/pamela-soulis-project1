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

            int thisOrderId = table.Count();
            return thisOrderId; 

        }


        /// <summary>
        /// Returns the order to be added to the database, given customer ID and location ID
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="locationId"></param>
        /// <returns></returns>
        

        //This works: add an order based on location and customer id
        public pamela_soulis_project1.Domain.Model.Orders AddOrder(Domain.Model.Orders order, Domain.Model.Customer customer, Domain.Model.Location location)
        {
            
            var orderDate = DateTime.Today;
            var orderEntity = new Domain.Model.Orders { CustomerId = customer.CustomerId, LocationId = location.LocationId, Date = orderDate };
            
            return orderEntity;
        }



    }
}
