using MVC.DTO;
using MVC.Models;
using MVC.Repository;

namespace MVC.Service
{
    public class ProductService
    {
        private readonly ProductRepository _repository;
        public ProductService(ProductRepository repository)
        {
            this._repository = repository;
        }
        public async Task<List<Product>> FillAllProductService()
        {
            var list = await _repository.GetAllProduct();
            return list;
        }

        public async Task<List<Category>> GetAllCategory()
        {
            var listCategory = await _repository.GetAllCategories();
            return listCategory;    
        }

        public Product CreateProductService(ProductDT productDT) {
            Product product = _repository.Create(productDT);
            return product;
        }

        public Product GetProductServiceById (int id)
        {
            Product product = _repository.GetProductById(id);
            return product;
        }

        public Product UpdateProductByIdService(int id, Product product) { 
            Product productUpdate = _repository.UpdateProductById(id, product);
            return productUpdate;   
        
        }

        public void DeleteProductServiceById(int id) { 
        _repository.DeleteProductById(id);
        }
    }
}
