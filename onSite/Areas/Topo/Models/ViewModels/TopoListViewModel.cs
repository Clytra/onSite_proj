using onSite.Components;
using System;
using System.Collections.Generic;

namespace onSite.Areas.Topo.Models.ViewModels
{
    public class TopoListViewModel
    {
        public IEnumerable<TopoModel> Topos { get; set; }
        public IEnumerable<ClimbingRouteModel> Routes { get; set; }

        public List<string> regions { get; set; }
        public List<string> rocks { get; set; }
        public List<string> walls { get; set; }

        public PagingInfo PagingInfo { get; set; }
        public string CurrentTerritory { get; set; }

    }
}
