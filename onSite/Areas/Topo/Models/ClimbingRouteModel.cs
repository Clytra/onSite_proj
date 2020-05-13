using System.ComponentModel.DataAnnotations;

namespace onSite.Areas.Topo.Models
{
    public class ClimbingRouteModel
    {
        //Primary key
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

        public bool Approved { get; set; }

        public bool IsHidden { get; set; }

        public virtual TopoModel TopoModel { get; set; }
    }
}
