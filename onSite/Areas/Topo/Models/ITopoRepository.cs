using System.Linq;

namespace onSite.Areas.Topo.Models
{
    public interface ITopoRepository
    {
        IQueryable<TopoModel> Topos { get; }

        //void SaveTopo(TopoModel topoModel);

        //TopoModel DeleteTopo(int TopoID);
    }
}
