using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ToDo_backend.Controllers;
using ToDo_backend.Data;
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
            _controller = new ToDoController(_service, mapper);
        }

        [Fact]
        public void Test1()
        {

        }
    }
}