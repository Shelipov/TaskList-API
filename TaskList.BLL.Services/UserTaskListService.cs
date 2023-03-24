using AutoMapper;
using Microsoft.Extensions.Logging;
using TaskList.BLL.Interface.ActionResult;
using TaskList.BLL.Interface.Services;
using TaskList.DAL.Interface.Models;
using TaskList.DAL.Interface.Repositories;

namespace TaskList.BLL.Services
{
    public class UserTaskListService : IUserTaskListService
    {
        private readonly IMapper mapper;
        private readonly ICurrentTaskListRepository currentTaskListRepository;
        private readonly ICurrentTaskRepository currentTaskRepository;
        private readonly IUserCurrentTaskListRepository userCurrentTaskListRepository;
        private readonly IUserRepository userRepository;
        private readonly ILogger<TaskListService> logger;

        public UserTaskListService(IMapper mapper,
            ICurrentTaskListRepository currentTaskListRepository,
            ICurrentTaskRepository currentTaskRepository,
            IUserCurrentTaskListRepository userCurrentTaskListRepository,
            IUserRepository userRepository,
            ILogger<TaskListService> logger)
        {
            this.mapper = mapper;
            this.currentTaskListRepository = currentTaskListRepository;
            this.currentTaskRepository = currentTaskRepository;
            this.userCurrentTaskListRepository = userCurrentTaskListRepository;
            this.userRepository = userRepository;
            this.logger = logger;
        }

        public async Task<Result<Guid>> AssignmentUserToTask(Guid currentTasklistId, Guid userId)
        {
            try
            {
                var user = await userRepository.GetByIdAsync(userId);
                if (user is null)
                {
                    var message = $"Failed to {nameof(AssignmentUserToTask)} - User not found";
                    return Result.Fail<Guid>(message);
                }
                var currentTaskList = await currentTaskListRepository.GetByIdAsync(currentTasklistId);
                if (currentTaskList is null)
                {
                    var message = $"Failed to {nameof(AssignmentUserToTask)} - CurrentTasklist not found";
                    return Result.Fail<Guid>(message);
                }
                var userCurrentTaskList = new UserCurrentTaskList
                {
                    UserCurrentTaskListId = Guid.NewGuid(),
                    CreatedDate = DateTime.UtcNow,
                    UserId = userId,
                    CurrentTaskLists = new List<CurrentTaskList>() { currentTaskList }
                };
                await userCurrentTaskListRepository.AddAsync(userCurrentTaskList);
                await userCurrentTaskListRepository.SaveChangesAsync();
                return Result.Ok(userCurrentTaskList.UserCurrentTaskListId);
            }
            catch (Exception ex)
            {
                var message = $"Failed to {nameof(AssignmentUserToTask)}";
                return Result.Fail<Guid>(message);
            }
        }

        public async Task<Result<Guid>> UnAssignmentUserToTask(Guid currentTasklistId, Guid userId)
        {
            try
            {
                var user = await userRepository.GetByIdAsync(userId);
                if (user is null)
                {
                    var message = $"Failed to {nameof(UnAssignmentUserToTask)} - User not found";
                    return Result.Fail<Guid>(message);
                }
                var userCurrentTaskList = await userCurrentTaskListRepository.GetByIdAndUserId(currentTasklistId, userId);
                if (userCurrentTaskList is null)
                {
                    var message = $"Failed to {nameof(UnAssignmentUserToTask)} - UserCurrentTaskList not found";
                    return Result.Fail<Guid>(message);
                }
                await userCurrentTaskListRepository.RemoveAsync(userCurrentTaskList.UserCurrentTaskListId);
                await userCurrentTaskListRepository.SaveChangesAsync();
                return Result.Ok(userCurrentTaskList.UserCurrentTaskListId);
            }
            catch (Exception ex)
            {
                var message = $"Failed to {nameof(UnAssignmentUserToTask)}";
                return Result.Fail<Guid>(message);
            }
        }
    }
}
