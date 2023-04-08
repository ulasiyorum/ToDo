using ToDo_backend.Dtos.UserDto;

namespace ToDo_backend.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<GetUserDto>> Register();
        Task<ServiceResponse<GetUserDto>> Login(string key);
        Task<ServiceResponse<GetUserDto>> Update(UpdateUserDto user);
    }
}
