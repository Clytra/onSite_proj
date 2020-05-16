using System.Collections.Generic;
using onSite.Areas.Topo.Models;
using onSite.Areas.Topo.Models.ViewModels;

namespace onSite.Repository
{
    public interface ITopoRepository
    {
        IEnumerable<TopoModel> Topos { get; }

        IEnumerable<ClimbingRouteModel> Routes { get; }

        void SaveTopo(ClimbingRouteModel climbing);

        ClimbingRouteModel DeleteTopo(int TopoID);
    }
}
