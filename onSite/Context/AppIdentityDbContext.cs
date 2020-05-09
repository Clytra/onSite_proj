using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using onSite.Areas.Identity.Models;

namespace onSite.Context
{
    public class AppIdentityDbContext : IdentityDbContext<AppUserModel>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
            : base(options) { }
    }
}
