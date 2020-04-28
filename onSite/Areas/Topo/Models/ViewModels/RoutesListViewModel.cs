using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onSite.Areas.Topo.Models.ViewModels
{
    public class RoutesListViewModel
    {
        public IEnumerable<ClimbingRouteModel> Routes { get; set; }

        public string CurrentWall { get; set; }
    }
}
