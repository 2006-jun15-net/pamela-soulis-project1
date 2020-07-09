using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace pamela_soulis_project1.WebUI.ViewModels
{
    public class LocationViewModel
    {

        [Display(Name = "Location ID")]
        public int LocationId { get; set; } 



        [Display(Name = "Location Name")]
        public string Name { get; set; }

        public IEnumerable<OrdersViewModel> Orders { get; set; }

    }
}
