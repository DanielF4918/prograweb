using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FrontEnd.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrdersHelper _ordersHelper;

        public OrdersController(IOrdersHelper ordersHelper)
        {
            _ordersHelper = ordersHelper;
        }

        public IActionResult Index()
        {
            var orders = _ordersHelper.GetAllOrders();
            return View(orders);
        }

        public IActionResult Details(int id)
        {
            var order = _ordersHelper.GetOrder(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(OrderViewModel order)
        {
            if (ModelState.IsValid)
            {
                _ordersHelper.Add(order);
                return RedirectToAction("Index");
            }
            return View(order);
        }

        public IActionResult Edit(int id)
        {
            var order = _ordersHelper.GetOrder(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        [HttpPost]
        public IActionResult Edit(OrderViewModel order)
        {
            if (ModelState.IsValid)
            {
                _ordersHelper.Update(order);
                return RedirectToAction("Index");
            }
            return View(order);
        }

        public IActionResult Delete(int id)
        {
            var order = _ordersHelper.GetOrder(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _ordersHelper.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
