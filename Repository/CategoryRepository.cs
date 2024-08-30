using MVC.Data;
using MVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer;

namespace MVC.Repository
{
    public class CategoryRepository
    {
        private readonly ApplicationConnection _context;

        public CategoryRepository(ApplicationConnection _context)
        {
           this._context = _context;
        }

        // get all category 
        public async Task< List<Category>> GetAllCategoriesAsync()
        {
            List<Category> listCategory = await _context.categories.ToListAsync();    
            return listCategory;
        }

        // create new category 
        public Category AddCategory(Category createCategory)
        {
          Category category = new Category();
            category.Name = createCategory.Name;
            category.Description = createCategory.Description;
            _context.categories.Add(category);
            _context.SaveChanges();
            return category;
        }

        // get information category by id
        public Category GetCategoryById (int id)
        {
            Category category = _context.categories.Where(category => category.Id == id).FirstOrDefault();
            return category;
        }

        // update cayetegory
        public Category UpdateCategory(int id, Category category)
        {
            Category categoryUpdate = _context.categories.Update(category).Entity;
            _context.SaveChanges();
            return categoryUpdate;
        }

        public void Delete (int id)
        {
            var category = _context.categories.Where(category => category.Id == id).FirstOrDefault();
            _context.categories.Remove(category);
            _context.SaveChanges(); 
        }

    }
}
