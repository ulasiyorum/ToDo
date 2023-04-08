using Microsoft.AspNetCore.Mvc;
using ToDo_backend.Dtos.UserDto;
using ToDo_backend.Services;
using ToDo_backend.Services.UserService;

namespace ToDo_backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        public readonly IUserService service;
        public UserController(IUserService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> Login(string key)
        {
            return Ok(await service.Login(key));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> Register()
        {
            return Ok(await service.Register());
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> Update(UpdateUserDto dto)
        {
            return Ok(await service.Update(dto));
        }
    }
}
