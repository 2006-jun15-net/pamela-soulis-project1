using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using pamela_soulis_project1.DataAccess.Model;
using pamela_soulis_project1.Domain.Model;
using pamela_soulis_project1.Domain.Repositories;
using pamela_soulis_project1.WebUI.Models;
using Microsoft.AspNetCore.Http;
using pamela_soulis_project1.WebUI.ViewModels;

namespace pamela_soulis_project1.WebUI.Controllers
{
    public class OrderLineController : Controller
    {

        private readonly OrdersRepository _ordersRepo;
        
        private readonly OrderLineRepository _orderlineRepo; 
        
        private readonly ProductRepository _productRepo;


        public OrderLineController(OrdersRepository ordrepo, OrderLineRepository olrepo, ProductRepository prorepo)
        {
            _ordersRepo = ordrepo;
            _orderlineRepo = olrepo;           
            _productRepo = prorepo;
        }


        public ActionResult Create([FromQuery] int orderId, int productId)
        {
            var orderline = new OrderlineViewModel
            {
                OrderId = orderId,
                ProductId = productId, 
                
            };
            return View(orderline); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderlineViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var product = _productRepo.GetById(viewModel.ProductId);
                    var order = _ordersRepo.GetById(viewModel.OrderId);
                    var orderline = new OrderLine
                    {
                        OrderId = viewModel.OrderId,
                        Quantity = viewModel.Quantity 
                    };

                    //var thisNewOrderId = _ordersRepo.NewOrder();
                    var theNewOrder = _orderlineRepo.AddingANewOrderLine(orderline, product, order);
                    _orderlineRepo.Insert(theNewOrder);
                    _orderlineRepo.SaveToDB();
                    return RedirectToAction(nameof(ProductController.Index));

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
