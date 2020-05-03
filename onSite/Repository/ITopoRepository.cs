using System.Collections.Generic;
using onSite.Areas.Topo.Models;
using onSite.Areas.Topo.Models.ViewModels;

namespace onSite.Repository
{
    public interface ITopoRepository
    {
        IEnumerable<TopoModel> Topos { get; }

        void SaveTopo(TopoModel topoModel);

        TopoModel DeleteTopo(int TopoID);
    }
}
