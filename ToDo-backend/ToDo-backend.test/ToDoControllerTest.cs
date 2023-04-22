using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ToDo_backend.Controllers;
using ToDo_backend.Data;
using ToDo_backend.Dtos;
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

            var res = okResult.Value as ServiceResponse<List<GetToDoDto>>;
            Assert.NotNull(res);
            Assert.True(res.Success);

            // Assert
            Assert.IsType<ServiceResponse<List<GetToDoDto>>>(result);
            Assert.True(result.Success);
        }
    }
}