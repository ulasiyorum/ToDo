namespace ToDo_backend.Dtos
{
    public class GetToDoDto
    {
        public int Id;
        public string Title { get; set; } = "Example ToDo";
        public string Description { get; set; } = "ToDo description";
        public int Priority { get; set; } = 0;
        public DateTime Due { get; set; } = (DateTime.Now).AddDays(1);
        public DateTime StartTime { get; set; } = DateTime.Now;
        public int UserId { get; set; }
    }
}
