using Microsoft.EntityFrameworkCore;
using onSite.Areas.Topo.Models;
using onSite.Areas.Topo.Models.ViewModels;
using onSite.Context;
using System.Collections.Generic;
using System.Linq;

namespace onSite.Repository
{
    public class EFTopoRepository : ITopoRepository
    {
        private ApplicationDbContext context;

        public EFTopoRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<TopoModel> Topos => context.Topo
            .Include(o => o.Routes).ToList();

        public IEnumerable<ClimbingRouteModel> Routes => context.Routes
            .Include(o => o.TopoModel).ToList();
        
        public void SaveTopo(ClimbingRouteModel topo)
        {
            if(topo.RouteID == 0)
            {
                context.Routes.Add(topo);
            }
            else
            {
                ClimbingRouteModel dbEntry = context.Routes
                    .Where(t => t.RouteID == topo.RouteID)
                    .Include(r => r.TopoModel)
                    .SingleOrDefault();
                if(dbEntry != null)
                {
                    dbEntry.Name = topo.Name;
                    dbEntry.Assurance = topo.Assurance;
                    dbEntry.Difficulty = topo.Difficulty;
                    dbEntry.Rating = topo.Rating;
                    dbEntry.Author = topo.Author;
                    dbEntry.Year = topo.Year;
                    dbEntry.Length = topo.Length;
                    dbEntry.Description = topo.Description;
                    //foreach(var row in topo.TopoModel)
                    //{
                    //    var existingRoute = dbEntry.Routes
                    //        .Where(c => c.RouteID == route.RouteID)
                    //        .SingleOrDefault();
                    //    if(existingRoute != null)
                    //    {
                    //        existingRoute.Name = route.Name;
                    //        existingRoute.Assurance = route.Assurance;
                    //        existingRoute.Difficulty = route.Difficulty;
                    //        existingRoute.Rating = route.Rating;
                    //        existingRoute.Author = route.Author;
                    //        existingRoute.Year = route.Year;
                    //        existingRoute.Length = route.Length;
                    //    }
                    //}
                }
            }
            context.SaveChanges();
        }

        public ClimbingRouteModel DeleteTopo(int routeID)
        {
            ClimbingRouteModel dbEntry = context.Routes
                .Where(t => t.RouteID == routeID)
                .SingleOrDefault();
            if (dbEntry != null)
            {
                context.Routes.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
