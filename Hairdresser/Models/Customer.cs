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
        public string Address { get; set; }
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
