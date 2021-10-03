using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.Data
{
    public class AddDbContext : DbContext
    {
        public AddDbContext(DbContextOptions<AddDbContext> op) : base(op)
        {
        }
        public DbSet<Book> Books { get; set; }
    
    }
}
