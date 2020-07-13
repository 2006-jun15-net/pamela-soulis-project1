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

        //private readonly OrdersRepository _orderRepo; 

        /// <summary>
        /// Returns the order to be added to the database, given product and order details, and product quantity
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>       

        //this works! add an orderline:  
        //public pamela_soulis_project1.Domain.Model.OrderLine AddingANewOrderLine(Domain.Model.OrderLine orderline, Domain.Model.Product product, Domain.Model.Orders order) //don't need this anymore
        public pamela_soulis_project1.Domain.Model.OrderLine AddingANewOrderLine(Domain.Model.OrderLine orderline, Domain.Model.Product product, int theNewOrderIdToEnter)
        {
                       
            var theOrderToBeAdded = new pamela_soulis_project1.Domain.Model.OrderLine { OrderId = theNewOrderIdToEnter, ProductId = product.ProductId, Quantity = orderline.Quantity };
            
            
            //var theOrderToBeAdded = new pamela_soulis_project1.Domain.Model.OrderLine { OrderId = order.OrderId, ProductId = product.ProductId, Quantity = orderline.Quantity }; //don't need this anymore
            return theOrderToBeAdded;
        }

         
        public pamela_soulis_project1.Domain.Model.OrderLine GetWithNavigations(int orderId)
        {
            var orderline = table
                .Include(c => c.Product)                   
                 .First(i => i.OrderId == orderId);


            var businessOrderline = mapper.Map<pamela_soulis_project1.Domain.Model.OrderLine>(orderline);
            return businessOrderline;
        }


    }
}
