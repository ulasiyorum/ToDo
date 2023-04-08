global using AutoMapper;
global using ToDo_backend.Models;
using ToDo_backend.Dtos.UserDto;

namespace ToDo_backend
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ToDo, GetToDoDto>();
            CreateMap<AddToDoDto, ToDo>();
            CreateMap<UpdateToDoDto, ToDo>();
            CreateMap<User, GetUserDto>();
            CreateMap<AddUserDto, User>();
        }
    }
}
