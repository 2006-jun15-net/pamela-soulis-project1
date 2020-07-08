﻿using System;
using System.Collections.Generic;

namespace pamela_soulis_project1.DataAccess.Model
{
    public partial class Location : DataModel 
    {
        public Location()
        {
            Inventory = new HashSet<Inventory>();
            Orders = new HashSet<Orders>();
        }

        public int LocationId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
