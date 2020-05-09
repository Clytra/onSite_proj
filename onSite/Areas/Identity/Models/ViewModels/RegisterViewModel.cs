using System.ComponentModel.DataAnnotations;

namespace onSite.Areas.Identity.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string RepeatPassword { get; set; }
    }
}
