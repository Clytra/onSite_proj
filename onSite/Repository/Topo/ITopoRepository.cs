using System.Collections.Generic;
using System.Linq;

namespace onSite.Areas.Topo.Models
{
    public interface ITopoRepository
    {
        IEnumerable<TopoModel> Topos { get; }

        void SaveTopo(TopoModel topoModel);

        TopoModel DeleteTopo(int TopoID);
    }
}
