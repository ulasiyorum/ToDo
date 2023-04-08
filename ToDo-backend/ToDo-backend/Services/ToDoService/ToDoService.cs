namespace ToDo_backend.Services.ToDoService
{
    public class ToDoService : IToDoService
    {
        public Task<ServiceResponse<List<GetToDoDto>>> Add(AddToDoDto addDto)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetToDoDto>>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetToDoDto>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetToDoDto>>> Update(UpdateToDoDto updateDto)
        {
            throw new NotImplementedException();
        }
    }
}
