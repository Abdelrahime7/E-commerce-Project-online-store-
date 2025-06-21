using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStorAccess.entities
{
    public class Order
    {

        public enum OrderStatus
        {
         Proccessing =1,shiped=2,delieverd =3   
        }

        public int ID { get; set; }
        public OrderStatus Status { get; set; }

        public required Customer Customer {  get; set; }

    }
}
