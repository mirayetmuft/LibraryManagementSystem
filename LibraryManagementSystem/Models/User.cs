using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    public class User:IModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Fakülte Numarası"), StringLength(5, ErrorMessage = "{1} Karakter Olamalı!")]
        public string IdNumber { get; set; }
        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Adı ve Soyadı"), StringLength(40, MinimumLength = 5, ErrorMessage = "{0} , {2} - {1} Karakter Olmalı")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Fakülte Adı"), StringLength(40, MinimumLength = 5, ErrorMessage = "{0} , {2} - {1} Karakter Olmalı")]
        public string Faculty { get; set; }
        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Bölüm Adı"), StringLength(40, MinimumLength = 5, ErrorMessage = "{0} , {2} - {1} Karakter Olmalı")]
        public string Department { get; set; }
        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Telefon No"), StringLength(15, MinimumLength = 10, ErrorMessage = "{0} , {2} - {1} Karakter Olmalı"), DataType(DataType.PhoneNumber, ErrorMessage = "{0} Uygun formatta değil!")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "E-Posta"), StringLength(50, MinimumLength = 6, ErrorMessage = "{0} , {2} - {1} Karakter Olmalı"), DataType(DataType.EmailAddress, ErrorMessage = "{0} Uygun formatta değil!")]
        public string Email { get; set; }

    }
}
