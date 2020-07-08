﻿using System;
using System.Collections.Generic;
using System.Text;

namespace pamela_soulis_project1.Domain.Model
{

    /// <summary>
    /// Junction table Orderline
    /// </summary>
    public class OrderLine : BaseBusinessModel
    {

        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }



    }
}
