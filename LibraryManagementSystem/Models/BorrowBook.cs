using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    public class BorrowBook:IModel
    {
        private DateTime date;
        private DateTime returnDate;
        public int Id { get; set; }
        [BindRequired]
        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Kullanıcı Adı-Soyadı")]
        public int UserId { get; set; }
        [BindRequired]
        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Kitap Adı")]
        public int BookId { get; set; }
        [BindRequired]
        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Alındığı tarih")]
        public DateTime BorrowingDate {
            get { return date; }
            set { date = DateTime.Now; } 
        }
        public DateTime DateToBeReturned 
        {
            get { return returnDate; }
            set { returnDate=BorrowingDate.AddDays(15); }
        }
        public DateTime ReturnDate { get; set; }
       

    }
}
