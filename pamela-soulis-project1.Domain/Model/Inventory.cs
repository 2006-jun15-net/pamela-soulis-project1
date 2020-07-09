using System;
using System.Collections.Generic;
using System.Text;

namespace pamela_soulis_project1.Domain.Model 
{
    /// <summary>
    /// Junction table Inventory, with an associated location, product, and product quantity available
    /// </summary>
    public class Inventory : BaseBusinessModel
    {

        private int _quantity; 


        /// <summary>
        /// Inventory associated to a particular store
        /// </summary>
        public int LocationId { get; set; } 


        /// <summary>
        /// And a  product 
        /// </summary>
        public int ProductId { get; set; }



        /// <summary>
        /// The amount of that product the store has
        /// </summary>
        public int Quantity 
        {
            get => _quantity;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Product quantity cannot be negative.", nameof(value));
                }
                _quantity = value;
            }
        }


    }
}