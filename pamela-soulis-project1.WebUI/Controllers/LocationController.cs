using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pamela_soulis_project1.DataAccess.Model;
using pamela_soulis_project1.Domain.Repositories;
using pamela_soulis_project1.WebUI.Models;
using Microsoft.AspNetCore.Http;

namespace pamela_soulis_project1.WebUI.Controllers
{
    public class LocationController : Controller
    {

        private readonly LocationRepository _locationRepo; 

        //public CustomerRepository Crepo { get; }

        //public CustomerController(CustomerRepository crepo) =>
        //    Crepo = crepo ?? throw new ArgumentNullException(nameof(crepo));

        public LocationController(LocationRepository locrepo)
        {
            _locationRepo = locrepo;
        }
        public IActionResult Index()
        {

            
            return View(_locationRepo.GetAll());
            //return View();
        }
    }
}
