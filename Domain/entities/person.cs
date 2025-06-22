using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.entities
{
    public class Person
    {
        public int id {  get; set; }
        public required string fName { get; set; }
        public required string  lName { get; set; }
         
        public string? Phone { get; set; }
        public string? Email { get; set; }

    }
}
