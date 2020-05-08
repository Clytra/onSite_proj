using System.ComponentModel.DataAnnotations;

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

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy}")]
        public int Year { get; set; }

        public double Length { get; set; }

        public string Description { get; set; }
        public TopoModel TopoModel { get; set; }
    }
}
