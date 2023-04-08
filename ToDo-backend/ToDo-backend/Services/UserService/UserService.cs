using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using ToDo_backend.Data;
using ToDo_backend.Dtos.UserDto;

namespace ToDo_backend.Services.UserService
{
    public class UserService : IUserService
    {
        public readonly IMapper mapper;
        public readonly DataContext context;

        public UserService(IMapper mapper, DataContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<ServiceResponse<GetUserDto>> Login(string key)
        {
            var response = new ServiceResponse<GetUserDto>();

            try
            {
                var user = await context.Users.FirstOrDefaultAsync(u => u.LoginKey == key);

                if (user is null)
                    throw new Exception("Wrong password or User does not exist");

                response.Data = mapper.Map<GetUserDto>(user);
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<GetUserDto>> Register()
        {
            var response = new ServiceResponse<GetUserDto>();
            try
            {
                string key = "";
                var list = await context.Users.ToListAsync();

                do
                {
                    key = GenerateRandomKey();
                } while (UserExists(key, list));

                AddUserDto dto = new AddUserDto
                {
                    LoginKey = key
                };
                var user = mapper.Map<User>(dto);
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();

                var data = await context.Users.FirstOrDefaultAsync(u => u.Id == user.Id);

                if (data is null)
                    throw new Exception("Failed to create user");

                response.Data = mapper.Map<GetUserDto>(data);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<GetUserDto>> Update(UpdateUserDto user)
        {
            var response = new ServiceResponse<GetUserDto>();
            try
            {
                var _user = await context.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
                
                if (_user is null)
                    throw new Exception("User with Id:" + user.Id + " is not found");

                _user.Name = user.Name;
                await context.SaveChangesAsync();

                response.Data = mapper.Map<GetUserDto>(_user);

            } catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        private string GenerateRandomKey()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 24)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }

        private bool UserExists(string key, List<User> list)
        {
            foreach(var user in list)
            {
                if (user.LoginKey == key)
                    return true;
            }

            return false;
        }
    }
}
