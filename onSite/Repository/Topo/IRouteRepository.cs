using onSite.Areas.Topo.Models;
using System.Linq;

namespace onSite.Repository.Topo
{
    public interface IRouteRepository
    {
        IQueryable<ClimbingRouteModel> Routes { get; }
        void SaveRoute(ClimbingRouteModel climbingRouteModel);
    }
}
