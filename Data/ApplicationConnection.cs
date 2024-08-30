using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.Data
{
    public class ApplicationConnection :DbContext
    {
        public ApplicationConnection(DbContextOptions<ApplicationConnection> options) : base(options) {
        
        }
       public DbSet<Category> categories {get; set;}
        public DbSet<Product> products {get; set;} 
    }
}
