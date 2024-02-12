using System.ComponentModel.DataAnnotations;

namespace Cproject.Entities.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public Guid? CartId { get; set; }
        public Cart? Cart { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public bool Available { get; set; }
        public DateTime AddedTime { get; set; }
        public Guid? SellerId { get; set; }
    }
}