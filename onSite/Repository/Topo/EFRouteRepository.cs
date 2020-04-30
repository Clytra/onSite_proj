using Microsoft.EntityFrameworkCore;
using onSite.Areas.Topo.Models;
using onSite.Context;
using System;
using System.Linq;

namespace onSite.Repository.Topo
{
    public class EFRouteRepository : IRouteRepository
    {
        private ApplicationDbContext context;

        public EFRouteRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<ClimbingRouteModel> Routes => context.Routes
            .Include(r => r.TopoModel);

        public void SaveRoute(ClimbingRouteModel climbingRouteModel)
        {
        }
    }
}
