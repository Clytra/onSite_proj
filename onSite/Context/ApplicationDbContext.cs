using Microsoft.EntityFrameworkCore;
using onSite.Areas.Topo.Models;

namespace onSite.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<TopoModel> Topo { get; set; }
    }
}
