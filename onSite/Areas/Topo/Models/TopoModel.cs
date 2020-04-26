using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace onSite.Areas.Topo.Models
{
    public class TopoModel
    {
        [Key]
        public int TopoID { get; set; }

        [Required(ErrorMessage = "To pole nie może zostać puste.")]
        public string Area { get; set; }

        [Required(ErrorMessage = "To pole nie może zostać puste.")]
        public string Region { get; set; }

        [Required(ErrorMessage = "To pole nie może zostać puste.")]
        public string Sector { get; set; }

        [Required(ErrorMessage = "To pole nie może zostać puste.")]
        public string Rock { get; set; }

        [Required(ErrorMessage = "To pole nie może zostać puste.")]
        public string Wall { get; set; }

        public ICollection<ClimbingRouteModel> Routes { get; set; }
    }
}
