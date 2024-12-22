using System.ComponentModel.DataAnnotations;

namespace Hairdresser.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Username { get; set; }
        [StringLength(30)]
        public string? UserSurname { get; set; }
        [Required]
        [StringLength(100)]
        public string Password { get; set; }
        public bool Locked { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Required]
        [StringLength(50)]
        public string Role { get; set; } = "user";

    }
}
