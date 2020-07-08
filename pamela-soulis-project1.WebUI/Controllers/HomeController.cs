using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pamela_soulis_project1.Domain.Repositories;
using pamela_soulis_project1.WebUI.Models;
//using pamela_soulis_project1.WebUI.ViewModels;
using pamela_soulis_project1.DataAccess.Model;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;

namespace pamela_soulis_project1.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly LocationRepository _locationRepo;
        //private readonly CustomerRepository _customerRepo;
        
        

        //public HomeController(LocationRepository locrepo, ILogger<HomeController> logger)
        //public HomeController(CustomerRepository crepo, ILogger<HomeController> logger)
        public HomeController(ILogger<HomeController> logger)
        {
            // _locationRepo = locrepo;
           // _customerRepo = crepo;
            _logger = logger;
        }

        public IActionResult Index()
        {

            //LocationRepository locrepo = new LocationRepository(_context);

            //var viewModel = _locationRepo.GetAll().Select(l => new LocationViewModel
            //{
            //    Name = l.Name
            //});

            //return View(viewModel);
            //return View(_customerRepo.GetAll());
            // return View(_locationRepo.GetAll());
            return View();
        }

        //[HttpGet]
        //public IActionResult AddACustomer()
        //{
        //    return View();
        //}


        //[HttpPost]
        //public IActionResult AddACustomer(IFormCollection formData)
        //{

        //    //need to validate the data : make sure it's not null, etc
        //    try
        //    {
        //        var customer = new Customer(formData["FirstName"], formData["LastName"]);
        //        _customerRepo.Insert(customer);
        //        _customerRepo.SaveToDB();

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch (Exception)
        //    {
        //        ModelState.AddModelError("", "there was some error, try again");
        //        return View();
        //    }
            
        //}



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
