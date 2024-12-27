using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hairdresser.Models
{
    public class Servisler
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
        public string Gender { get; set; }
        public ICollection<Randevu> Randevu { get; set; }
    }
}