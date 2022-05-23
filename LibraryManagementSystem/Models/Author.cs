using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Models
{
    public class Author:IModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }
}
