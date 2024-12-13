using System.ComponentModel.DataAnnotations;

namespace Hairdresser.Models
{
    public class Service
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a valid name")]
        [MaxLength(50)]
        [MinLength(2)]
        [Display(Name = "Service Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter a valid price")]
        [Display(Name = "Price")]
        [Range(100, 10000, ErrorMessage = "Price must be between 100-10000")]
        public int Price { get; set; }
        public string Category { get; set; }
        public TimeSpan Duration { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
