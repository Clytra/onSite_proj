using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using onSite.Areas.Topo.Models;

namespace onSite.Context
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TopoModel>()
                .HasMany(t => t.Routes)
                .WithOne(r => r.TopoModel);
        }

        public DbSet<TopoModel> Topo { get; set; }
        public DbSet<ClimbingRouteModel> Routes { get; set; }
    }
}
