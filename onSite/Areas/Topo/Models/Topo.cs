using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onSite.Areas.Topo.Models
{
    public class Topo
    {
        public int TopoID { get; set; }
        public string Voivodeship { get; set; }
        public string Area { get; set; }
        public string Rock { get; set; }
        public string ClimbingRoute { get; set; }
        public string Difficulty { get; set; }

    }
}
