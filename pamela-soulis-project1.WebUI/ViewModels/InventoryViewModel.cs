using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace pamela_soulis_project1.WebUI.ViewModels
{
    public class InventoryViewModel
    {

        [Display(Name = "Location ID")]
        public int LocationId { get; set; }


        [Display(Name = "Product ID")]
        public int ProductId { get; set; }


        [Display(Name = "Amount left")]
        public int Quantity { get; set; }

        
    }
}