using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FrontEnd.Controllers
{
    public class ShipperController : Controller
    {
        private readonly IShipperHelper _shipperHelper;

        public ShipperController(IShipperHelper shipperHelper)
        {
            _shipperHelper = shipperHelper;
        }

        public IActionResult Index()
        {
            var shippers = _shipperHelper.GetAll();
            return View(shippers);
        }

        public IActionResult Details(int id)
        {
            var shipper = _shipperHelper.GetById(id);
            if (shipper == null)
            {
                return NotFound();
            }
            return View(shipper);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ShipperViewModel model)
        {
            if (ModelState.IsValid)
            {
                _shipperHelper.Create(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var shipper = _shipperHelper.GetById(id);
            if (shipper == null)
            {
                return NotFound();
            }
            return View(shipper);
        }

        [HttpPost]
        public IActionResult Edit(ShipperViewModel model)
        {
            if (ModelState.IsValid)
            {
                _shipperHelper.Update(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var shipper = _shipperHelper.GetById(id);
            if (shipper == null)
            {
                return NotFound();
            }
            return View(shipper);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _shipperHelper.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
