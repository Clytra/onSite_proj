using onSite.Areas.Topo.Models;
using onSite.Context;
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

        public IQueryable<TopoModel> Topos => context.Topo;
        
        public void SaveTopo(TopoModel topoModel)
        {
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
                    dbEntry.Voivodeship = topoModel.Voivodeship;
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
