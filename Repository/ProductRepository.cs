using MVC.Data;
using MVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer;
using MVC.DTO;

namespace MVC.Repository
{
    public class ProductRepository
    {
        private readonly ApplicationConnection _applicationConnection;
        public ProductRepository (ApplicationConnection applicationConnection)
        {
          this._applicationConnection = applicationConnection;
        }

        public async Task<List<Product>> GetAllProduct()
        {
            try
            {
                var list = await _applicationConnection.products.Include(p => p.Category).ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                // Log exception and handle it accordingly
                throw new ApplicationException("An error occurred while retrieving products.", ex);
            }
        }

        public Product Create(ProductDT createProduct)
        {
            Product product =  new Product();
            product.Name = createProduct.Name;
            product.Price = createProduct.Price;
            product.Description = createProduct.Description;
            product.CategoryId = createProduct.CategoryId;
            product.Status= createProduct.Status;   
            _applicationConnection.products.Add(product);
            _applicationConnection.SaveChangesAsync();
            return product;
        }

        public  Product GetProductById(int id)
        {
            Product product = _applicationConnection.products.Where(p => p.Id == id).FirstOrDefault();
            _applicationConnection.SaveChangesAsync();
            return product;
        }

        public async Task<List<Category>> GetAllCategories() {
            try
            {
                var list = await _applicationConnection.categories.ToListAsync();
                return list;
            }
            catch (Exception ex) {
                throw new ApplicationException("An error occurred while retrieving products.", ex);

            }
        } 

        public Product UpdateProductById(int id, Product productUpdate)
        {
            Product product = _applicationConnection.products.Update(productUpdate).Entity;
            _applicationConnection.SaveChanges();
            return product;
        }

        public void DeleteProductById(int id) { 
        Product product = _applicationConnection.products.Where(p=>p.Id == id).FirstOrDefault();
            _applicationConnection.Remove(product);
            _applicationConnection.SaveChangesAsync();
        }
    }
}
