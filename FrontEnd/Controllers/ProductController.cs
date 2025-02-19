using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class ProductController : Controller
    {
        IProductHelper _productHelper;
        ISupplierHelper _supplierHelper;
        ICategoryHelper _categoryHelper;
        public ProductController(IProductHelper productHelper, ISupplierHelper supplierHelper, ICategoryHelper categoryHelper)
        {
            _productHelper = productHelper;
            _supplierHelper = supplierHelper;
            _categoryHelper = categoryHelper;
        }

        // GET: ProductController
        public ActionResult Index()
        {
            return View(_productHelper.GetAll());

        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            ProductViewModel product = _productHelper.GetById(id);
            product.CategoryName = _categoryHelper
                                    .GetCategory(product.CategoryId)
                                    .CategoryName;

            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            ProductViewModel product = new ProductViewModel();
            product.Suppliers = _supplierHelper.GetAll();
            product.Categories = _categoryHelper.GetCategories();
            return View(product);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel product)
        {
            try
            {
                _productHelper.AddProduct(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            ProductViewModel product = _productHelper.GetById(id);
            product.Suppliers = _supplierHelper.GetAll();
            product.Categories = _categoryHelper.GetCategories();
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductViewModel product)
        {
            try
            {

                _productHelper.EdiProduct(product);
                return RedirectToAction("Details", new { id = product.ProductId });
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            ProductViewModel product = _productHelper.GetById(id);
            product.CategoryName = _categoryHelper
                                    .GetCategory(product.CategoryId)
                                    .CategoryName;

            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ProductViewModel product)
        {
            try
            {
                _productHelper.DeleteProduct(product.ProductId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}