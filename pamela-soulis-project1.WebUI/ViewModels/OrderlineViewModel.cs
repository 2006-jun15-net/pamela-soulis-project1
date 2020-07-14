using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using pamela_soulis_project1.DataAccess.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;

namespace pamela_soulis_project1.WebUI.ViewModels
{
    public class OrderlineViewModel
    {

       

        [Display(Name = "Order ID")]  
        [Required]
        public int OrderId { get; set; }



        [Display(Name = "Product ID")]
        [Range(1, 4)]
        [Required]
        public int ProductId { get; set; }



        [Display(Name = "Amount")]
        [Range(1,30)]
        [Required]
        public int Quantity { get; set; }

        
        public pamela_soulis_project1.Domain.Model.Product Product { get; set; }


        //drop down menu:
        public List<SelectListItem> Products { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Skis" },
            new SelectListItem { Value = "2", Text = "Ski Boots" },
            new SelectListItem { Value = "3", Text = "Snowboards" },
            new SelectListItem { Value = "4", Text = "Snowboard Boots" },
        };

    }

}
