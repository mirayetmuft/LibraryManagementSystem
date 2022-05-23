using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    public class BookUserBookBarrowVM
    {
        public int Id { get; set; }
        public string UserFullName { get; set; }
        public string BookName { get; set; }
        public DateTime BorrowingDate { get; set; }
        public DateTime DateToBeReturned { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
