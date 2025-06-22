using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Domain.entities
{
    public class Salle
    {
      public  int ID { get; set; }
        public  int OrderID { get; set; }
        public Decimal TotalAmount { get; set; } 
    }
}
