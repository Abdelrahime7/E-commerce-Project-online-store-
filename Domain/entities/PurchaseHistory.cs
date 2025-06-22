using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.entities
{
    public class PurchaseHistory
    {
        public int  ID { get; set; }
        public int OrderID  { get; set; }

        public int CustomerID { get; set; }
    }

}
