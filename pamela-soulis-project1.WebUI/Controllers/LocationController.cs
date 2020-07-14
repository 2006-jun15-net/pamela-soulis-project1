using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pamela_soulis_project1.Domain.Model;
//using pamela_soulis_project1.DataAccess.Model;
using pamela_soulis_project1.Domain.Repositories;
using pamela_soulis_project1.WebUI.Models;
using Microsoft.AspNetCore.Http;
using pamela_soulis_project1.WebUI.ViewModels;

namespace pamela_soulis_project1.WebUI.Controllers
{
    public class LocationController : Controller
    {

        private readonly LocationRepository _locationRepo; 

        

        public LocationController(LocationRepository locrepo)
        {
            _locationRepo = locrepo;
        }
        public IActionResult Index()
        {
                        
            return View(_locationRepo.GetAll());
            
        }

        public ActionResult Details(int id)
        {
            
            var location = _locationRepo.GetOrderHistory(id);
            var viewModel = new LocationViewModel
            {
                LocationId = location.LocationId,
                Name = location.Name,
                Orders = location.Orders.Select(y => new OrdersViewModel
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
        public ActionResult InventoryDetails(int id)
        {
            var thelocation = _locationRepo.GetWithNavigations(id);
            var theviewModel = new LocationViewModel
            {
                LocationId = thelocation.LocationId,
                Name = thelocation.Name,
                Inventory = thelocation.Inventory.Select(i => new InventoryViewModel
                {
                    LocationId = i.LocationId,
                    ProductId = i.ProductId,
                    Quantity = i.Quantity
                }),
            };
            return View(theviewModel);

        }
        
           

    }
}
