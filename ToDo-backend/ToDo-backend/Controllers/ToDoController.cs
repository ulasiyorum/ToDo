using Microsoft.AspNetCore.Mvc;
using ToDo_backend.Services;
using ToDo_backend.Services.ToDoService;

namespace ToDo_backend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ToDoController : ControllerBase
    {
        public readonly IToDoService service;
        public ToDoController(IToDoService service)
        {
            this.service = service;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetToDoDto>>>> GetAll()
        {
            return Ok(await service.GetAll());
        }
    }
}
