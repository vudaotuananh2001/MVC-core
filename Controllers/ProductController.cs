using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MVC.DTO;
using MVC.Models;
using MVC.Service;
using System.Collections.Generic;


namespace MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;
        public ProductController(ProductService productService)
        {
            this._productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                // Await the asynchronous method
                List<Product> listProduct = await _productService.FillAllProductService();
                return View(listProduct);
            }
            catch (Exception ex)
            {
                // Handle exception or log it
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpGet]
        public  async Task<IActionResult> Create() {
            try
            {
                List<Category> listCategory = await _productService.GetAllCategory();
                ViewBag.Category = listCategory;
                return View();
            }
            catch (Exception ex) {
                throw new Exception("Excepton");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDT  productDT)
        {
            try
            {
                if (ModelState.IsValid) {
                    Product product = new Product();
                    product = _productService.CreateProductService(productDT);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception("Excepton");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit (int id)
        {
              List<Category> listCategory = await _productService.GetAllCategory();
                ViewBag.Category = listCategory;
            Product product = _productService.GetProductServiceById(id);
            return View(product);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            Product productUpdae = _productService.UpdateProductByIdService(id, product);
            return RedirectToAction("Index");   
        }

        [HttpDelete]
        public async Task<IActionResult> Delete (int id)
        {
            _productService.DeleteProductServiceById(id);
            return RedirectToAction("Index");
        }
    }
}
