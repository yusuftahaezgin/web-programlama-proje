using System.ComponentModel.DataAnnotations;

namespace BerberOtomasyonu.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Eposta")]
        public string Email { get; set;}=null!;

        [Required]  
        [StringLength(15, ErrorMessage = "Şifre alanı maksimum 15 karakter olmalı!")]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string Sifre { get; set; }=null!;
    }
}