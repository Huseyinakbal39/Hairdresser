using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hairdresser.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Username is required.")]
        [StringLength(30, ErrorMessage = "Username can be max 30 characters.")]
        [DisplayName("Name")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [MinLength(3, ErrorMessage = "Password can be min 6 characters.")]
        [MaxLength(16, ErrorMessage = "Password can be max 30 characters.")]
        [DisplayName("Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = " Re-Password is required.")]
        [MinLength(3, ErrorMessage = "Re-Password can be min 6 characters.")]
        [MaxLength(16, ErrorMessage = "Re-Password can be max 30 characters.")]
        [Compare(nameof(Password))]
        [DisplayName("Password")]
        public string RePassword { get; set; }
    }
}
