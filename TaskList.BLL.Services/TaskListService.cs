using AutoMapper;
using TaskList.BLL.Interface.ActionResult;
using TaskList.BLL.Interface.Common;
using TaskList.BLL.Interface.Dtos;
using TaskList.BLL.Interface.Services;
using TaskList.DAL.Interface.Repositories;
using Microsoft.EntityFrameworkCore;

namespace TaskList.BLL.Services
{
    public class TaskListService : ITaskListService
    {
        private readonly IMapper mapper;
        private readonly ICurrentTaskListRepository currentTaskListRepository;
        private readonly ICurrentTaskRepository currentTaskRepository;
        private readonly IUserCurrentTaskListRepository userCurrentTaskListRepository;
        private readonly IUserRepository userRepository;

        public TaskListService(IMapper mapper,
            ICurrentTaskListRepository currentTaskListRepository,
            ICurrentTaskRepository currentTaskRepository,
            IUserCurrentTaskListRepository userCurrentTaskListRepository,
            IUserRepository userRepository)
        {
            this.mapper = mapper;
            this.currentTaskListRepository = currentTaskListRepository;
            this.currentTaskRepository = currentTaskRepository;
            this.userCurrentTaskListRepository = userCurrentTaskListRepository;
            this.userRepository = userRepository;
        }

        public async Task<Result<PagedResponse<TaskListResponse>>> Search(SearchTaskListDto dto)
        {
            try
            {
                var query = currentTaskListRepository.Search(dto);
                var currentTaskList = await query.Skip(dto.Skip).Take(dto.Take).ToListAsync();

                return Result.Ok(new PagedResponse<TaskListResponse>(await query.CountAsync(),
                    mapper.Map<IEnumerable<TaskListResponse>>(currentTaskList)));
            }
            catch (Exception ex)
            {
                var message = $"Failed to {nameof(Search)}";
                return Result.Fail<PagedResponse<TaskListResponse>>(message);
            }
        }
    }
}
