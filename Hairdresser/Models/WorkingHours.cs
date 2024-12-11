using System.ComponentModel.DataAnnotations;

namespace Hairdresser.Models
{
    public class WorkingHours
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; } // Çalışanla ilişki
        public Employee Employee { get; set; }
        public DayOfWeek Day { get; set; } // Pazartesi, Salı, vb.
        public TimeSpan StartTime { get; set; } // Başlangıç saati
        public TimeSpan EndTime { get; set; }
    }
}
