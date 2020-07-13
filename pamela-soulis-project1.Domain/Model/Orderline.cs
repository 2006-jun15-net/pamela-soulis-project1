using System;
using System.Collections.Generic;
using System.Text;

namespace pamela_soulis_project1.Domain.Model
{


    /// <summary>
    /// Junction table Orderline
    /// </summary>
    public class OrderLine : BaseBusinessModel
    {

       
        private int _quantity;


        /// <summary>
        /// Has an Order ID FK
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// And a Product ID FK
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// And products
        /// </summary>
        public Product Product { get; set; }
        

        /// <summary>
        /// And product amount user can add to order
        /// </summary>
        public int Quantity
        {
            get => _quantity;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Product order quantity cannot be negative.", nameof(value));
                }
                _quantity = value;
            }
        }

    }
}
