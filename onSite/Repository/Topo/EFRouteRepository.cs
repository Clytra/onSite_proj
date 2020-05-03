using Microsoft.EntityFrameworkCore;
using onSite.Areas.Topo.Models;
using onSite.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onSite.Repository.Topo
{
    public class EFRouteRepository : IRouteRepository
    {
        private ApplicationDbContext context;

        public EFRouteRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<ClimbingRouteModel> Routes => context.Routes
            .Include(r => r.TopoModel);

        public ClimbingRouteModel DeleteRoute(int routeID)
        {
            ClimbingRouteModel dbEntry = context.Routes
                .FirstOrDefault(p => p.RouteID == routeID);
            if (dbEntry != null)
            {
                context.Routes.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}

