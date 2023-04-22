using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ToDo_backend.Controllers;
using ToDo_backend.Data;
using ToDo_backend.Dtos;
using ToDo_backend.Dtos.UserDto;
using ToDo_backend.Services;
using ToDo_backend.Services.ToDoService;

namespace ToDo_backend.test
{
    public class ToDoControllerTest
    {
        private readonly IMapper _mapper;
        private readonly DbContextOptions<DataContext> _options;
        private readonly ToDoController _controller;
        private readonly IToDoService _service;

        public ToDoControllerTest()
        {
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            }).CreateMapper();
            _options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "test")
            .Options;
            var dbContext = new DataContext(_options);

            _service = new ToDoService(_mapper,dbContext);
            _controller = new ToDoController(_service);
        }

        [Fact]
        public async Task GetAll_ReturnsListOfToDos()
        {
            // Act
            var result = await _service.GetAll();

            var okResult = (await _controller.GetAll()).Result as OkObjectResult;
            Assert.NotNull(okResult);
            var res = okResult.Value as ServiceResponse<List<GetToDoDto>>;
            Assert.NotNull(res);
            Assert.True(res.Success);

            // Assert
            Assert.IsType<ServiceResponse<List<GetToDoDto>>>(result);
            Assert.True(result.Success);
        }

        [Fact]
        public async Task GetUsersList_ReturnsUsersToDoItems()
        {
            // Arrange
            int userId = 1;

            // Act
            var okResult = (await _controller.GetById(userId)).Result as OkObjectResult;

            // Assert
            Assert.NotNull(okResult);
            var list = okResult.Value as ServiceResponse<List<GetToDoDto>>;
            Assert.IsType<ServiceResponse<List<GetToDoDto>>>(list);

            if(list.Data != null && list.Data.Count > 0)
            {
                Assert.True(list.Data[0].UserId == userId);
            }
            Assert.NotNull(list);
            Assert.True(list.Success);
        }

        [Fact]
        public async Task Delete_ReturnsDeletedToDoItem()
        {
            // Arrange
            int itemId = 1;

            // Act
            var okResult = (await _controller.Delete(itemId)).Result as OkObjectResult;

            // Assert
            Assert.NotNull(okResult);
            Assert.IsType<ServiceResponse<List<GetToDoDto>>>(okResult.Value);

            var res = okResult.Value as ServiceResponse<List<GetToDoDto>>;
            Assert.NotNull(res);
        }
    }
}