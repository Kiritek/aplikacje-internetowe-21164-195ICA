using Microsoft.EntityFrameworkCore;

namespace CRUD_API2.Models
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options)
        {

        }
        public DbSet<Tutorial> Tutorials { get; set; }
    }
}
