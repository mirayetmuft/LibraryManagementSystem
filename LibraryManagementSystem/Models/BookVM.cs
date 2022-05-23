using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    public class BookVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public string CategoryName { get; set; }
        public string Shelf { get; set; }
        public bool Status { get; set; }
        public int Page { get; set; }
    }
}
