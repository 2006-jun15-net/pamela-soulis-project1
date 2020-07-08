﻿using System;
using System.Collections.Generic;

namespace pamela_soulis_project1.DataAccess.Model
{
    public partial class OrderLine : DataModel
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
