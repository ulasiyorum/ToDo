namespace ToDo_backend.Dtos
{
    public class UpdateToDoDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = "Example ToDo";
        public string Description { get; set; } = "ToDo description";
        public int Priority { get; set; } = 0;
        public DateTime Due { get; set; } = (DateTime.Now).AddDays(1);
    }
}
