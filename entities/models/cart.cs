using System.ComponentModel.DataAnnotations;

namespace Cproject.Entities.Models
{
    public class Cart
    {
        [Key]
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }

        public User? User { get; set; } 
        public virtual ICollection<Product>? Products { get; set; }  
}       }