
namespace OnlineStorAccess.entities
{
    public class Item
    {
        public enum UnitTypes
        {
            PerPeace=1,PerKG=2
        }
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public DateTime ExpirDate { get; set; }

        public DateTime ProdDate { get; set; }

        public UnitTypes UnitType { get; set; }
 
    }

    
}
