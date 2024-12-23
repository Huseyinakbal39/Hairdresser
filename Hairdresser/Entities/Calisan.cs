using System.ComponentModel.DataAnnotations;

namespace Hairdresser.Entities
{
    public class Calisan
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a valid name")]
        [MaxLength(50)]
        [MinLength(2)]
        [Display(Name = "Employee Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a valid surname")]
        [MaxLength(50)]
        [MinLength(2)]
        [Display(Name = "Employee Surname")]
        public string Surname { get; set; }
        [EmailAddress(ErrorMessage = "Please enter a valid email")]
        public string Email { get; set; }
        [Phone(ErrorMessage = "Please enter a valid phone number")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public string Position { get; set; }
        [Required(ErrorMessage = "Please enter a valid salary")]
        [Display(Name = "Employee Salary")]
        [Range(1000, 100000, ErrorMessage = "Salary must be between 1000-100000")]
        public int Salary { get; set; }

        [Required]
        [StringLength(80)]
        public string Password { get; set; }
        [StringLength(80)]
        public string PreviousPassword { get; set; }
        //public ICollection<WorkingHours> WorkingHours { get; set; } // Çalışma saatleri
        //public ICollection<Appointment> Appointments { get; set; } // Çalışanın gerçekleştirdiği randevular
    }
}

