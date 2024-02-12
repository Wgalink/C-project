using System.ComponentModel.DataAnnotations;


namespace Cproject.Entities.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Pseudo { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } = "buyer" ;
        public virtual Cart? Cart { get; set; }
    }
}