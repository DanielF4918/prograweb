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
            var shippers = _shipperHelper.GetShippers();
            return View(shippers);
        }

        public IActionResult Details(int id)
        {
            var shipper = _shipperHelper.GetShipper(id);
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
        public IActionResult Create(ShipperViewModel shipper)
        {
            if (ModelState.IsValid)
            {
                _shipperHelper.Add(shipper);
                return RedirectToAction(nameof(Index));
            }
            return View(shipper);
        }

        public IActionResult Edit(int id)
        {
            var shipper = _shipperHelper.GetShipper(id);
            if (shipper == null)
            {
                return NotFound();
            }
            return View(shipper);
        }

        [HttpPost]
        public IActionResult Edit(ShipperViewModel shipper)
        {
            if (ModelState.IsValid)
            {
                _shipperHelper.Update(shipper);
                return RedirectToAction(nameof(Index));
            }
            return View(shipper);
        }

        public IActionResult Delete(int id)
        {
            var shipper = _shipperHelper.GetShipper(id);
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
            return RedirectToAction(nameof(Index));
        }
    }
}
