using Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStorAccess.entities
{
    public class User:Person
    {
        public int Id { get; set; }
        public string ? UserName  { get; set; }
        public string ? Password { get; set; } 
        public short Permission {  get; set; }
    
    }
}
