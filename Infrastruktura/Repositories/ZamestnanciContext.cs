using Microsoft.EntityFrameworkCore;
using Infrastruktura.Models;
namespace Infrastruktura.Repositories
{
    public class ZamestnanciContext : DbContext
    {
        public ZamestnanciContext(DbContextOptions<ZamestnanciContext> options)
            : base(options)
        {

        }
        public DbSet<Zamestnanci> Zamestnanci { get; set; }
        public DbSet<Pozicie> Pozicie { get; set; }
        
        public DbSet<Predoslepozicie> Predoslepozicie { get; set; }


    }
}