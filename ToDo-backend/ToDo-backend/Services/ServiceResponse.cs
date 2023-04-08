namespace ToDo_backend.Services
{
    public class ServiceResponse<T>
    {
        T? Data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = "Successful";
    }
}
