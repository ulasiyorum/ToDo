namespace ToDo_backend.Dtos.UserDto
{
    public class GetUserDto
    {
        public int Id { get; set; }
        public string LoginKey { get; set; } = string.Empty;
        public string Name { get; set; } = "Guest";
    }
}
