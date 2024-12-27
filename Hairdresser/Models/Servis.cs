using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hairdresser.Models
{
    public class Servis
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a valid name")]
        [MaxLength(50)]
        [MinLength(2)]
        [Display(Name = "Service Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a valid price")]
        [Display(Name = "Price")]
        [Range(100, 10000, ErrorMessage = "Price must be between 100-10000")]
        public int Price { get; set; }
        [Column("Gender")]
        [MaxLength(20)]
        [MinLength(2)]
        public string Gender { get; set; }
        public ICollection<Randevu> Randevu { get; set; } = new List<Randevu>();
    }
}
