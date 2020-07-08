using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace pamela_soulis_project1.WebUI.ViewModels
{
    public class CustomerViewModel
    {

        [Display(Name = "ID")]
        public int CustomerId { get; set; }


        [Required]
        public string FirstName { get; set; }


        [Required]
        public string LastName { get; set; }

        public IEnumerable<OrdersViewModel> Orders { get; set; }
    }
}
