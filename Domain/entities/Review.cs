using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStorAccess.entities
{
    public class Review
    {
        public int Id { get; set; }
        public string ? Descreption { get; set; }

        public required Customer  Customer { get; set; }

        public required Item Item { get; set; }

        public DateTime Date { get; set; }

    }
}
