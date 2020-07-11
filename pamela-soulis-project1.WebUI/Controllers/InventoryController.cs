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
    public class InventoryController : Controller
    {

        private readonly InventoryRepository _inventoryRepo;




        public InventoryController(InventoryRepository invrepo)
        {
            _inventoryRepo = invrepo;
        }


        //public ActionResult Edit(int productId, int locationId)
        //{
        //    var inventory = new InventoryViewModel
        //    {
        //        ProductId = productId,
        //        LocationId = locationId
        //    };
        //    return View(inventory);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(InventoryViewModel viewModel)
        //{

        //}
    }
}
