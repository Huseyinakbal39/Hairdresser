using Hairdresser.Entities;
using System.ComponentModel.DataAnnotations;

namespace Hairdresser.Models
{
    public class Randevu
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }

        public int calisanId { get; set; }
        public Calisan Calisan { get; set; }

        public int ServiceId { get; set; }
        public Servis Service { get; set; }

        public DateTime AppointmentDate { get; set; }
    }
}
