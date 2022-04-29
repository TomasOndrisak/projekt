using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
    public class ZamestnanciContext:DbContext
    {
        public ZamestnanciContext(DbContextOptions<ZamestnanciContext> options)
            : base(options)
        {

        }
        public DbSet<Zamestnanci> Zamestnanci { get; set; }
        public DbSet<Pozicie> Pozicie { get; set; }
        public DbSet<Archivovany> Archivovany { get; set; }
        public DbSet<Predoslepozicie> Predoslepozicie { get; set; }
        

    }
}
