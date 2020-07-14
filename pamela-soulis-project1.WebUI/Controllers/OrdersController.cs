using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pamela_soulis_project1.Domain.Model;
using pamela_soulis_project1.Domain.Repositories;
using pamela_soulis_project1.WebUI.Models;
using Microsoft.AspNetCore.Http;
using pamela_soulis_project1.WebUI.ViewModels;

namespace pamela_soulis_project1.WebUI.Controllers
{
    public class OrdersController : Controller
    {

        private readonly OrdersRepository _ordersRepo;
        private readonly CustomerRepository _customerRepo;
        private readonly LocationRepository _locationRepo;


        public OrdersController(OrdersRepository ordrepo, CustomerRepository crepo, LocationRepository locrepo) 
        {
            _ordersRepo = ordrepo;
            _customerRepo = crepo;
            _locationRepo = locrepo;
        }


        public ActionResult Create([FromQuery] int customerId, int locationId)
        {
            var order = new OrdersViewModel
            {
                CustomerId = customerId,
                LocationId = locationId
            };
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrdersViewModel viewModel)
        {
            try
            {
                
                if (ModelState.IsValid)
                {
                    var customer = _customerRepo.GetById(viewModel.CustomerId);
                    var location = _locationRepo.GetById(viewModel.LocationId);
                    var order = new Orders
                    {
                        OrderId = viewModel.OrderId,
                        Date = viewModel.Date
                    };

                    
                    var theNewOrder = _ordersRepo.AddOrder(order, customer, location);

                    //store the location ID that user inputed
                    TempData["userLocation"] = location.LocationId;

                    _ordersRepo.Insert(theNewOrder);
                    _ordersRepo.SaveToDB();
                    return RedirectToAction(nameof(CustomerController.DetailsOfNewOrder),
                       "Customer", new { id = viewModel.CustomerId });

                }
                return View(viewModel);
            }
            catch (ArgumentException)
            {
                ModelState.AddModelError("", "Invalid, please try again");
                return View(viewModel);
            }

        }
    }
}
