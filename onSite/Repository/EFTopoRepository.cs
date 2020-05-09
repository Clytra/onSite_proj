using Microsoft.EntityFrameworkCore;
using onSite.Areas.Topo.Models;
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
        
        public void SaveTopo(TopoModel topoModel)
        {
            if(topoModel.TopoID == 0)
            {
                context.Topo.Add(topoModel);
            }
            else
            {
                TopoModel dbEntry = context.Topo
                    .Where(t => t.TopoID == topoModel.TopoID)
                    .Include(r => r.Routes)
                    .SingleOrDefault();
                if(dbEntry != null)
                {
                    dbEntry.Territory = topoModel.Territory;
                    dbEntry.Region = topoModel.Region;
                    dbEntry.Sector = topoModel.Sector;
                    dbEntry.Rock = topoModel.Rock;
                    dbEntry.Wall = topoModel.Wall;
                    foreach(var route in topoModel.Routes)
                    {
                        var existingRoute = dbEntry.Routes
                            .Where(c => c.RouteID == route.RouteID)
                            .SingleOrDefault();
                        if(existingRoute != null)
                        {
                            existingRoute.Name = route.Name;
                            existingRoute.Assurance = route.Assurance;
                            existingRoute.Difficulty = route.Difficulty;
                            existingRoute.Rating = route.Rating;
                            existingRoute.Author = route.Author;
                            existingRoute.Year = route.Year;
                            existingRoute.Length = route.Length;
                        }
                    }
                }
            }
            context.SaveChanges();
        }

        public TopoModel DeleteTopo(int TopoID)
        {
            TopoModel dbEntry = context.Topo
                .Where(t => t.TopoID == TopoID)
                .Include(r => r.Routes)
                .SingleOrDefault();
            if (dbEntry != null)
            {
                context.Topo.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
