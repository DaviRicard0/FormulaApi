using Microsoft.EntityFrameworkCore;

namespace FormulaApi.Data
{
    public class FormulaApiContext : DbContext
    {
        public FormulaApiContext(DbContextOptions<FormulaApiContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Driver> Drivers { get; set; } = default!;
    }
}
