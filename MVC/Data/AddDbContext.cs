using Microsoft.EntityFrameworkCore;

namespace MVC.Data
{
    public class AddDbContext : DbContext
    {
        public AddDbContext(DbContextOptions<AddDbContext> op): base(op)
        {

        }
    }
}
