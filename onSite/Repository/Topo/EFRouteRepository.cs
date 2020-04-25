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

        public IQueryable<ClimbingRouteModel> Routes => context.Routes;

        IQueryable<ClimbingRouteModel> IRouteRepository.Routes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void SaveRoute(ClimbingRouteModel climbingRouteModel)
        {

        }
    }
}
