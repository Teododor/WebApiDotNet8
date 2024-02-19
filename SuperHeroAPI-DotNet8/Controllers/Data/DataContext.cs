using Microsoft.EntityFrameworkCore;
using SuperHeroAPI_DotNet8.Controllers.Entities;

namespace SuperHeroAPI_DotNet8.Controllers.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}
