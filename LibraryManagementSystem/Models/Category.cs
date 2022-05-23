using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    public class Category:IModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Kategori"), StringLength(40, MinimumLength = 5, ErrorMessage = "{0} , {2} - {1} Karakter Olmalı")]
        public string Name { get; set; }
    }
}
