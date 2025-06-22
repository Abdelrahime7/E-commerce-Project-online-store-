using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStorAccess.entities
{
    public class ItemGallery
    {
        public int  ID  { get; set; }
        public  int ItemID { get; set; }

        public string ImageLink { get; set; } = null!;


    }
}
