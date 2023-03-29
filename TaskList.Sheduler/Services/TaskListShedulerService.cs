using AutoMapper;
using Microsoft.Extensions.Logging;
using TaskList.BLL.Interface.ActionResult;
using TaskList.Sheduler.Intefaces;

namespace TaskList.Sheduler.Services
{
    public class TaskListShedulerService : ITaskListShedulerService
    {
        private readonly ILogger<TaskListShedulerService> logger;
        private readonly IMapper mapper;
        public TaskListShedulerService(ILogger<TaskListShedulerService> logger,
           IMapper mapper)
        {
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task Exequte()
        {
            
        }
    }
}
