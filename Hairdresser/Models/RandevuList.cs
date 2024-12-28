using System.ComponentModel.DataAnnotations;

namespace Hairdresser.Models
{
    public class RandevuList
    {
        [Display(Name = "Müşteri Adı")]
        public string musteriAdi { get; set; }
        [Display(Name = "Çalışan Adı")]
        public string calisanAdi { get; set;}
        [Display(Name = "İşlem Adı")]
        public string islemAdi { get; set;}
        [Display(Name = "Randevu Tarihi")]
        public DateTime randevuTarihi { get; set; }
    }
}
