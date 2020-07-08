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



    public class OrderLineRepository : GenericRepository<pamela_soulis_project1.DataAccess.Model.OrderLine, pamela_soulis_project1.Domain.Model.OrderLine>
    {

        public OrderLineRepository(pamelasoulisproject1Context _context) : base(_context)
        {

        }



        /// <summary>
        /// Returns the order to be added to the database, given product and order details, and product quantity
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public OrderLine AddingANewOrderLine(int orderId, int productId, int quantity)
        {

            var theOrderToBeAdded = new OrderLine { OrderId = orderId, ProductId = productId, Quantity = quantity };
            return theOrderToBeAdded;
        }
    }
}
