using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace pamela_soulis_project1.WebUI.ViewModels
{
    public class OrdersViewModel
    {
        [Display(Name = "Your Order ID")]
        public int OrderId { get; set; }



        [Display(Name = "Customer ID")]
        public int CustomerId { get; set; }



        [Display(Name = "Location ID")]
        public int LocationId { get; set; }



        [Display(Name = "Past Order Date")]
        [DisplayFormat(DataFormatString = "{0:yyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }



        public IEnumerable<OrderlineViewModel> OrderLine { get; set; }  

         

    }
}
