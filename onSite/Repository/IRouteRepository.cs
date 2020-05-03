using onSite.Areas.Topo.Models;
using System.Collections.Generic;

namespace onSite.Repository
{
    public interface IRouteRepository
    {
        IEnumerable<ClimbingRouteModel> Routes { get; }

        ClimbingRouteModel DeleteRoute(int RouteId);
    }
}
