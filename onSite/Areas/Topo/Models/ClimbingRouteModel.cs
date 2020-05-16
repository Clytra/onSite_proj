using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace onSite.Areas.Topo.Models
{
    public class ClimbingRouteModel
    {
        [Key]
        public int RouteID { get; set; }

        [Required(ErrorMessage = "To pole nie może zostać puste.")]
        public string Name { get; set; }

        public string Assurance { get; set; }

        [Required(ErrorMessage = "To pole nie może zostać puste.")]
        public string Difficulty { get; set; }

        public double Rating { get; set; }

        public string Author { get; set; }

        [StringLength(4)]
        public string Year { get; set; }

        public double Length { get; set; }

        public string Description { get; set; }

        public string RouteScheme { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> Regions { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> Areas { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> Rocks { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> Walls { get; set; }

        public virtual TopoModel TopoModel { get; set; }
    }
}
