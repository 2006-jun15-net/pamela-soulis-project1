using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using pamela_soulis_project1.DataAccess.Model;
using pamela_soulis_project1.Domain.Repositories;
using pamela_soulis_project1.WebUI.Models;
using Microsoft.AspNetCore.Http;
using pamela_soulis_project1.WebUI.ViewModels;
using pamela_soulis_project1.Domain.Model;

namespace pamela_soulis_project1.WebUI.Controllers
{
    public class CustomerController : Controller
    {

        private readonly CustomerRepository _customerRepo;

        

        
        public CustomerController(CustomerRepository crepo)
        {
            _customerRepo = crepo;
        }


        //This works: home page for customer info displays all past customers
        //public IActionResult Index()
        //{

        //    return View(_customerRepo.GetAll());
            
        //}



        public IActionResult Index(string searchstring)
        {
            ViewData["CurrentFilter"] = searchstring;
            var customers = _customerRepo.GetAll();            
            if (!String.IsNullOrEmpty(searchstring))
            {
                //customers = customers.Where(c => c.LastName.Contains(searchstring));
                customers = _customerRepo.SearchByName(searchstring);
            }
            return View(customers.ToList()); 
        }






        //This works : get customer order history ( their order ID and which location ID and how much they bought and the product they bought)
        public ActionResult Details(int id)
        {
            
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
                        Quantity = x.Quantity, 
                        Product = x.Product 

                    }),
                }),
                
            };
            return View(viewModel);
        }



        public ActionResult DetailsOfNewOrder(int id)
        {

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
                    
                }),

            };
            return View(viewModel);
        }




        //This works! Adding a new customer
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("FirstName, LastName")]CustomerViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var customer = new Customer
                    {
                        FirstName = viewModel.FirstName,
                        LastName = viewModel.LastName
                    };
                    var theNewCustomer = _customerRepo.AddCustomer(customer);
                    _customerRepo.Insert(theNewCustomer);
                    _customerRepo.SaveToDB();
                    return RedirectToAction(nameof(Index)); 
                }
                return View(viewModel);
            }
            catch
            {
                return View(viewModel);
            }
            
        }






    }
}
