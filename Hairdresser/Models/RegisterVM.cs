using System.ComponentModel.DataAnnotations;

namespace Hairdresser.Models
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "İsminizi Giriniz")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "Soyadinizi Giriniz")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "Email Adresinizi Giriniz")]
        public string email { get; set; }

        [Required(ErrorMessage = "Şifrenizi Giriniz")]
        [MinLength(2, ErrorMessage = "Şifre uzunluğu 2 karakterden uzun olmalı")]
        [MaxLength(20, ErrorMessage = "Şifre uzunluğu 20 karakterden uzun olmamalı")]
        public string password { get; set; }

        [Required(ErrorMessage = "Şifre Kontrol Giriniz")]
        [Compare(nameof(password), ErrorMessage = "Şifreniz eşleşmiyor , tekrar giriniz!")]
        public string repassword { get; set; }
        [Required(ErrorMessage = "Telefon Numaranızı Giriniz")]
        public string phone
        {
            get; set;
        }
        public string Gender    { get; set; }
    }
}
