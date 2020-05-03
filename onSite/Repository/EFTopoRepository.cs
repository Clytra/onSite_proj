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
            context.AttachRange(topoModel.Routes.Select(l => l.Name));
            if(topoModel.TopoID == 0)
            {
                context.Topo.Add(topoModel);
            }
            else
            {
                TopoModel dbEntry = context.Topo
                    .FirstOrDefault(p => p.TopoID == topoModel.TopoID);
                if(dbEntry != null)
                {
                    dbEntry.Area = topoModel.Area;
                    dbEntry.Region = topoModel.Region;
                    dbEntry.Sector = topoModel.Sector;
                    dbEntry.Rock = topoModel.Rock;
                    dbEntry.Wall = topoModel.Wall;
                }
            }
            context.SaveChanges();
        }

        public TopoModel DeleteTopo(int TopoID)
        {
            TopoModel dbEntry = context.Topo
                .FirstOrDefault(p => p.TopoID == TopoID);
            if(dbEntry != null)
            {
                context.Topo.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
