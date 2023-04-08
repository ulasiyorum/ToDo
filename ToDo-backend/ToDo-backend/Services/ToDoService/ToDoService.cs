using ToDo_backend.Data;

namespace ToDo_backend.Services.ToDoService
{
    public class ToDoService : IToDoService
    {

        private readonly IMapper mapper;
        private readonly DataContext context;

        public ToDoService(IMapper mapper, DataContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }


        public async Task<ServiceResponse<List<GetToDoDto>>> Add(AddToDoDto addDto)
        {
            var response = new ServiceResponse<List<GetToDoDto>>();
            try
            {
                var value = mapper.Map<ToDo>(addDto);

                await context.ToDoList.AddAsync(value);

                await context.SaveChangesAsync();

                var list = await context.ToDoList.Select(v => mapper.Map<GetToDoDto>(v)).ToListAsync();

                response.Data = list;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<List<GetToDoDto>>> Delete(int id)
        {
            var response = new ServiceResponse<List<GetToDoDto>>();
            try
            {
                var value = await context.ToDoList.FirstOrDefaultAsync(v => v.Id == id);

                if (value is null)
                    throw new Exception("Not Found");


                context.ToDoList.Remove(value);

                await context.SaveChangesAsync();

                var list = await context.ToDoList.Select(v => mapper.Map<GetToDoDto>(v)).ToListAsync();

                response.Data = list;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<List<GetToDoDto>>> GetAll()
        {
            var response = new ServiceResponse<List<GetToDoDto>>();
            try
            {
                var list = await context.ToDoList.Select(val => mapper.Map<GetToDoDto>(val)).ToListAsync();
                response.Data = list;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<List<GetToDoDto>>> GetByUser(int id)
        {
            var response = new ServiceResponse<List<GetToDoDto>>();
            try
            {
                var list = await context.ToDoList.Where(item => item.Id == id).Select(item => mapper.Map<GetToDoDto>(item)).ToListAsync();
                response.Data = list;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<List<GetToDoDto>>> Update(UpdateToDoDto updateDto)
        {
            var response = new ServiceResponse<List<GetToDoDto>>();
            try
            {
                var value = await context.ToDoList.FirstOrDefaultAsync(v => v.Id == updateDto.Id);

                if (value is null)
                    throw new Exception("Not found");

                value.Title = updateDto.Title;
                value.Description = updateDto.Description;
                value.Priority = updateDto.Priority;
                value.Due = updateDto.Due;

                await context.SaveChangesAsync();

                var list = await context.ToDoList.Select(val => mapper.Map<GetToDoDto>(val)).ToListAsync();
                response.Data = list;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
