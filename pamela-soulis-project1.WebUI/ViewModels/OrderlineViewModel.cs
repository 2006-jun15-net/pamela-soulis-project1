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

       

        [Display(Name = "Order ID")]  
        [Required]
        public int OrderId { get; set; }



        [Display(Name = "Product ID")]
        [Required]
        public int ProductId { get; set; }



        [Display(Name = "Amount")]
        [Required]
        public int Quantity { get; set; }

        
        public pamela_soulis_project1.Domain.Model.Product Product { get; set; }
        
    }

}
