using Microsoft.EntityFrameworkCore;

namespace AntilopaApi.Models
{
    public class AntilopaDbContext: DbContext
    {
        public AntilopaDbContext(DbContextOptions<AntilopaDbContext> options): base(options)
        {
        }

        public DbSet<Owner> Owners {get; set;}
        public DbSet<Car> Cars { get; set; }
    }
}