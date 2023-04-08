global using AutoMapper;
global using ToDo_backend.Models;

namespace ToDo_backend
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ToDo, GetToDoDto>();
            CreateMap<AddToDoDto, ToDo>();
            CreateMap<UpdateToDoDto, ToDo>();
        }
    }
}
