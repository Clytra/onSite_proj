using System.Collections.Generic;

namespace onSite.Areas.Topo.Models
{
    public interface ITopoRepository
    {
        IEnumerable<TopoModel> Topos { get; }

        void SaveTopo(TopoModel topoModel);

        TopoModel DeleteTopo(int TopoID);
    }
}
