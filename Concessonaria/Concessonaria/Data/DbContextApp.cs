using Concessonaria.Models;
using Microsoft.EntityFrameworkCore;

namespace Concessonaria.Data
{
    public class DbContextApp : DbContext
    {
        public DbContextApp(DbContextOptions<DbContextApp> options) : base(options) {}

        public DbSet<Cars> Car { get; set; }

        public DbSet<Photo> Photo { get; set; }
    }
}
