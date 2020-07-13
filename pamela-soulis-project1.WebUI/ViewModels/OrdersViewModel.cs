using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace pamela_soulis_project1.WebUI.ViewModels
{
    public class OrdersViewModel
    {
        [Display(Name = "Order ID")]
        public int OrderId { get; set; }



        [Display(Name = "Customer ID")]        
        [Required]
        public int CustomerId { get; set; }



        [Display(Name = "Location ID")]
        [Range(1, 2)]
        [Required]
        public int LocationId { get; set; }



        [Display(Name = "Order Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM-dd-yyyy}")]
        public DateTime Date { get; set; }



        public IEnumerable<OrderlineViewModel> OrderLine { get; set; }


        public List<SelectListItem> Locations { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Off Piste Market Street" },
            new SelectListItem { Value = "2", Text = "Off Piste Northfield" },
            
        };


    }
}
