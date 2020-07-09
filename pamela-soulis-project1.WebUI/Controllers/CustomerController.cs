using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pamela_soulis_project1.DataAccess.Model;
using pamela_soulis_project1.Domain.Repositories;
using pamela_soulis_project1.WebUI.Models;
using Microsoft.AspNetCore.Http;
using pamela_soulis_project1.WebUI.ViewModels;
//using AspNetCore;

namespace pamela_soulis_project1.WebUI.Controllers
{
    public class CustomerController : Controller
    {

        private readonly CustomerRepository _customerRepo;

        //public CustomerRepository Crepo { get; }

        //public CustomerController(CustomerRepository crepo) =>
        //    Crepo = crepo ?? throw new ArgumentNullException(nameof(crepo));

        public CustomerController(CustomerRepository crepo)
        {
            _customerRepo = crepo;
        }
        public IActionResult Index()
        {

            //IEnumerable<Customer> customer = (IEnumerable<Customer>)Crepo.GetAll();
            return View(_customerRepo.GetAll());
            
        }


        //almost works : get customer order history ( their order ID and which location ID and how much they bought)
        // still need to display the product names and have the right title in the table over the quantity
        public ActionResult Details(int id)
        {
            //var customer = _customerRepo.GetById(id);
            var customer = _customerRepo.GetWithNavigations(id);
            var viewModel = new CustomerViewModel
            {
                CustomerId = customer.CustomerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Orders = customer.Orders.Select(y => new OrdersViewModel
                {
                    OrderId = y.OrderId,
                    CustomerId = y.CustomerId,
                    LocationId = y.LocationId,
                    Date = y.Date,
                    OrderLine = y.OrderLine.Select(x => new OrderlineViewModel
                    {
                        Quantity = x.Quantity
                        //Product = x.Product.Select(z => new ProductViewModel
                        //{ 
                        //    Name = z.Name
                        //}),
                        
                    }),
                }),
                
            };
            return View(viewModel);
        }


        //this works! Adding a new customer
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //public ActionResult Create(IFormCollection formData)
        public ActionResult Create(CustomerViewModel viewModel)
        {
            var customer = new Customer
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName
            };
            _customerRepo.AddCustomer(customer);
            _customerRepo.SaveToDB();
            return RedirectToAction(nameof(Index));

            
        }

    }
}
