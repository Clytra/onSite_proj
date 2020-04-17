using System.ComponentModel.DataAnnotations;

namespace onSite.Areas.Topo.Models
{
    public class TopoModel
    {
        public int TopoID { get; set; }

        [Required(ErrorMessage = "To pole nie może zostać puste.")]
        public string Voivodeship { get; set; }

        [Required(ErrorMessage = "To pole nie może zostać puste.")]
        public string Area { get; set; }

        [Required(ErrorMessage = "To pole nie może zostać puste.")]
        public string Rock { get; set; }

        [Required(ErrorMessage = "To pole nie może zostać puste.")]
        public string ClimbingRoute { get; set; }

        [Required(ErrorMessage = "To pole nie może zostać puste.")]
        public string Difficulty { get; set; }

        public string Description { get; set; }

    }
}
