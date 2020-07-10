using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

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
        [Required]
        public int LocationId { get; set; }



        [Display(Name = "Order Date")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM-dd-yyyy}")]
        public DateTime Date { get; set; }



        public IEnumerable<OrderlineViewModel> OrderLine { get; set; }  

         
        //date stuff in orders.create.cshtml
        //<div class="form-group">
        //        <label asp-for="Date" class="control-label"></label>
        //        <input asp-for="Date" class="form-control" />
        //        <span asp-validation-for="Date" class="text-danger"></span>
        //    </div>


    }
}
