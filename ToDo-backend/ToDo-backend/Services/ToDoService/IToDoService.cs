global using ToDo_backend.Dtos;

namespace ToDo_backend.Services.ToDoService
{
    public interface IToDoService
    {
        Task<ServiceResponse<List<GetToDoDto>>> GetAll();
        Task<ServiceResponse<List<GetToDoDto>>> Update(UpdateToDoDto updateDto);
        Task<ServiceResponse<List<GetToDoDto>>> Delete(int id);
        Task<ServiceResponse<List<GetToDoDto>>> Add(AddToDoDto addDto);
        Task<ServiceResponse<List<GetToDoDto>>> GetByUser(int id);
    }
}
