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

        [HttpGet("Login")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> Login(string key)
        {
            return Ok(await service.Login(key));
        }

        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> Register()
        {
            return Ok(await service.Register());
        }

        [HttpPut("Rename")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> Update(UpdateUserDto dto)
        {
            return Ok(await service.Update(dto));
        }
    }
}
