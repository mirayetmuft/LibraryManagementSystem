using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    public class Book:IModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Kitap Adı"), StringLength(100,MinimumLength=1, ErrorMessage = "{2}-{1} Karakter Arasında Olamalı!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Yazar Adı")]
        public int AuthorId { get; set; }
        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Kategori")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Bulunduğu Raf")]
        public string Shelf { get; set; }
        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Durumu")]
        public bool Status { get; set; }
        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Sayfa Sayısı")]
        public int Page { get; set; }
    }
}
