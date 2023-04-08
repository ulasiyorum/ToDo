namespace ToDo_backend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Guest";
        public string LoginKey { get; set; } = string.Empty;
    }
}
