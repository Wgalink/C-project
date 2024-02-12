using System.ComponentModel.DataAnnotations;

namespace Cproject.Entities.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public Guid CartId { get; set; }
        public Cart? Cart { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public bool Available { get; set; }
        public DateTime AddedTime { get; set; }
        public int SellerId { get; set; }
    }
}