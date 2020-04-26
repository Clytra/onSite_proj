using onSite.ViewModels;
using System.Collections.Generic;

namespace onSite.Areas.Topo.Models.ViewModels
{
    public class TopoListViewModel
    {
        public IEnumerable<TopoModel> Topos { get; set; }
        
        public PagingInfo PagingInfo { get; set; }

        public string CurrentType { get; set; }
    }
}
