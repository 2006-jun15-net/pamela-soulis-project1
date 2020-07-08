using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using pamela_soulis_project1.DataAccess.Model;

namespace pamela_soulis_project1.WebUI.ViewModels
{
    public class OrderlineViewModel
    {
         
        [Display(Name = "Amount")]
        public int Quantity { get; set; }

        
        //public Product Product { get; set; }
        //public IEnumerable<ProductViewModel> Product { get; set; }
    }

}
