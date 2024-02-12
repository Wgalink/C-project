namespace C-project.entities.models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Pseudo { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public Cart Cart { get; set; }
    }
}