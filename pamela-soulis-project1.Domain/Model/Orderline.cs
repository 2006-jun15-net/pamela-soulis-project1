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

        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        


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
