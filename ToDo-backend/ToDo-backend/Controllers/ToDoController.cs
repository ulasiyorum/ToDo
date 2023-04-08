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

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<GetToDoDto>>>> Delete(int id)
        {
            return Ok(await service.Delete(id));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetToDoDto>>>> Update(UpdateToDoDto update)
        {
            return Ok(await service.Update(update));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetToDoDto>>>> Add(AddToDoDto add)
        {
            return Ok(await service.Add(add));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetToDoDto>>>> GetById(int id)
        {
            return Ok(await service.GetByUser(id));
        }
    }
}
