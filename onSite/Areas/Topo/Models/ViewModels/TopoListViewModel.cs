using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onSite.Areas.Topo.Models.ViewModels
{
    public class TopoListViewModel
    {
        public IEnumerable<TopoModel> Topos { get; set; }
        
        public PagingInfo PagingInfo { get; set; }

        public string CurrentType { get; set; }
    }
}
