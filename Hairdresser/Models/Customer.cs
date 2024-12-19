using System.ComponentModel.DataAnnotations;

namespace Hairdresser.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a valid name")]
        [MaxLength(50)]
        [MinLength(2)]
        [Display(Name = "Customer Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a valid surname")]
        [MaxLength(50)]
        [MinLength(2)]
        [Display(Name = "Customer Surname")]
        public string Surname { get; set; }

        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        [Required]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a valid password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a valid password")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage ="Password does not match")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set;} = string.Empty;
        //public ICollection<Appointment> Appointments { get; set; }
    }
}
