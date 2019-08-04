using Microsoft.EntityFrameworkCore;

namespace AntilopaApi.Models
{
    public class AntilopaDbContext: DbContext
    {
        public AntilopaDbContext(DbContextOptions<AntilopaDbContext> options): base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
    }
}