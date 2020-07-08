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

namespace pamela_soulis_project1.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly LocationRepository _locationRepo;
        //public static pamelasoulisproject1Context context = new pamelasoulisproject1Context(options);
        private readonly pamelasoulisproject1Context _context;

        //public HomeController(LocationRepository locationRepo, ILogger<HomeController> logger)
        public HomeController(pamelasoulisproject1Context context, ILogger<HomeController> logger)
        {
            // _locationRepo = locationRepo;
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {

            LocationRepository locrepo = new LocationRepository(_context);

            //var viewModel = _locationRepo.GetAll().Select(l => new LocationViewModel
            //{
            //    Name = l.Name
            //});

            //return View(viewModel);

            return View(locrepo.GetAll());
        }

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
