using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStorAccess.entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public  int ItemID { get; set; }
        public short Quantity   { get; set; }

        public decimal Price { get; set; }

        public decimal Total {  get; set; }
        public DateTime date { get; set; }
        
    }
}
