using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Models;
using MVC.Repository;

namespace MVC.Service
{
    public class CategoryService
    {
        private readonly CategoryRepository _repository;
        public CategoryService(CategoryRepository context)
        {
            this._repository = context;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            List<Category> categories = await _repository.GetAllCategoriesAsync();
            return categories;
        }

        public Category AddCategoryAsync(Category createCategory)
        {
            Category  category =  _repository.AddCategory(createCategory);
            return category;
        }

        public Category GetCategoryById (int id)
        {
            Category category = _repository.GetCategoryById(id);
            return category;
        }

        public Category UpdateCategoryService(int id, Category category) { 
            Category categoryUpdate = _repository.UpdateCategory(id, category);
            return categoryUpdate;
        }

        public void DeleteCategoryServiceById(int id) { 
            _repository.Delete(id);
        }

    }
}
