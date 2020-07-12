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

        private readonly InventoryRepository _inventoryRepo;


        public OrderLineController(OrdersRepository ordrepo, OrderLineRepository olrepo, ProductRepository prorepo, InventoryRepository invrepo)
        {
            _ordersRepo = ordrepo;
            _orderlineRepo = olrepo;           
            _productRepo = prorepo;
            _inventoryRepo = invrepo;
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

        //this works
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(OrderlineViewModel viewModel)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var product = _productRepo.GetById(viewModel.ProductId);
        //            var order = _ordersRepo.GetById(viewModel.OrderId);
        //            var orderline = new OrderLine
        //            {
        //                OrderId = viewModel.OrderId,
        //                Quantity = viewModel.Quantity
        //            };

        //            var thisNewOrderId = _ordersRepo.NewOrder();
        //            var theNewOrder = _orderlineRepo.AddingANewOrderLine(orderline, product, order);
        //            _orderlineRepo.Insert(theNewOrder);
        //            _orderlineRepo.SaveToDB();
        //            return RedirectToAction(nameof(Index));

        //        }
        //        return View(viewModel);

        //    }
        //    catch (ArgumentException)
        //    {
        //        ModelState.AddModelError("", "Invalid, please try again.");
        //        return View(viewModel);
        //    }

        //}




        ////trying with updating inventory
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderlineViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   // var previousOrdersInfo = TempData["OrdersData"] as Orders;
                    var product = _productRepo.GetById(viewModel.ProductId);
                    var order = _ordersRepo.GetById(viewModel.OrderId);
                    var orderline = new OrderLine
                    {
                        OrderId = viewModel.OrderId,
                        Quantity = viewModel.Quantity
                    };

                    var thisNewOrderId = _ordersRepo.NewOrder();
                    var theNewOrder = _orderlineRepo.AddingANewOrderLine(orderline, product, order);
                    _orderlineRepo.Insert(theNewOrder);
                    _orderlineRepo.SaveToDB();


                    //  first get the inventory that's avaliable for that product
                    var maxAmountForOrder = _inventoryRepo.GetProductQuantity(product.ProductId); //the amount available before order
                    //  then check if product amount asked for is > that maxAmountForOrder
                    //  if so, reject order
                    if (orderline.Quantity > maxAmountForOrder.Quantity)
                    {
                        ModelState.AddModelError("", "Sorry, this product is out of stock, try again.");
                    }

                    maxAmountForOrder.Quantity = maxAmountForOrder.Quantity - orderline.Quantity;

                    //decrease the inventory for a given product at a given location
                    _inventoryRepo.UpdateTheQuantity(maxAmountForOrder.Quantity, product, 1);
                    _inventoryRepo.SaveToDB();


                    return RedirectToAction(nameof(Index));

                }
                return View(viewModel);

            }
            catch (ArgumentException)
            {
                ModelState.AddModelError("", "Invalid, please try again.");
                return View(viewModel);
            }

        }


        public IActionResult Index()
        {

            return View(_orderlineRepo.GetAll());

        }

        //public ActionResult OrderlineDetailsOfNewOrder(int id)
        //{

        //    var orderline = _orderlineRepo.GetWithNavigations(id);
        //    var viewModel = new OrderlineViewModel
        //    {
        //        OrderId = orderline.OrderId,
        //        Product = orderline.Product,
        //        Quantity = orderline.Quantity


        //    };
        //    return View(viewModel);
        //}
    }
}
