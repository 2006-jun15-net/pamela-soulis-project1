﻿using System;
using System.Collections.Generic;

namespace pamela_soulis_project1.DataAccess.Model
{
    public partial class Inventory : DataModel
    {
        public int LocationId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Location Location { get; set; }
        public virtual Product Product { get; set; }
    }
}
