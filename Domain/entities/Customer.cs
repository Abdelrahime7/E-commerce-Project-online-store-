using Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStorAccess.entities
{
    public class Customer:Person
    {
       public int Id { get; set; }
        public int Point {  get; set; }
         
        public int PurchaseHistoryID {  get; set; }
      
    }
}
