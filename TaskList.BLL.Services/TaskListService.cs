using AutoMapper;
using TaskList.BLL.Interface.ActionResult;
using TaskList.BLL.Interface.Common;
using TaskList.BLL.Interface.Dtos;
using TaskList.BLL.Interface.Services;
using TaskList.DAL.Interface.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TaskList.DAL.Interface.Models;

namespace TaskList.BLL.Services
{
    public class TaskListService : ITaskListService
    {
        private readonly IMapper mapper;
        private readonly ICurrentTaskListRepository currentTaskListRepository;
        private readonly ICurrentTaskRepository currentTaskRepository;
        private readonly IUserCurrentTaskListRepository userCurrentTaskListRepository;
        private readonly IUserRepository userRepository;
        private readonly ILogger<TaskListService> logger;

        public TaskListService(IMapper mapper,
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

        public async Task<Result<PagedResponse<TaskListResponse>>> Search(SearchCurrentTaskListDto dto)
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

        public async Task<Result<Guid>> Create(CreateCurrentTaskListDto dto)
        {
            try
            {
                var user = await userRepository.GetByIdAsync(dto.UserId.Value);
                if(user is null)
                {
                    var message = $"Failed to {nameof(Create)} - User not found";
                    return Result.Fail<Guid>(message);
                }
                var currentTaskListId = Guid.NewGuid();
                await CreateCurrentTaskList(currentTaskListId, dto, user);
                await CreateCurrentTasks(currentTaskListId, dto);
                await currentTaskRepository.SaveChangesAsync();
                return Result.Ok(currentTaskListId);
            }
            catch (Exception ex)
            {
                var message = $"Failed to {nameof(Create)}";
                return Result.Fail<Guid>(message);
            }
        }
        public async Task<Result<CurrentTaskListDto>> GetById(Guid currentTasklistId, Guid userId)
        {
            try
            {
                var currentTasklist = await currentTaskListRepository.GetAggregateById(currentTasklistId,userId);
                if (currentTasklist is null)
                {
                    var message = $"Failed to {nameof(GetById)} - CurrentTasklist not found";
                    return Result.Fail<CurrentTaskListDto>(message);
                }
                return Result.Ok(mapper.Map<CurrentTaskListDto>(currentTasklist));
            }
            catch (Exception ex)
            {
                var message = $"Failed to {nameof(GetById)}";
                return Result.Fail<CurrentTaskListDto>(message);
            }
        }

        public async Task<Result<Guid>> Update(CurrentTaskListDto dto)
        {
            try
            {
                var currentTasklist = await currentTaskListRepository.GetAggregateById(dto.CurrentTaskListId, dto.UserId.Value);
                if (currentTasklist is null)
                {
                    var message = $"Failed to {nameof(Update)} - CurrentTasklist not found";
                    return Result.Fail<Guid>(message);
                }

                await UpdateCurrentTaskList(currentTasklist, dto);
                await currentTaskRepository.SaveChangesAsync();
                return Result.Ok(currentTasklist.CurrentTaskListId);
            }
            catch (Exception ex)
            {
                var message = $"Failed to {nameof(Update)}";
                return Result.Fail<Guid>(message);
            }
        }

        public async Task<Result<Guid>> DeleteById(Guid currentTasklistId, Guid userId)
        {
            try
            {
                var currentTasklist = await currentTaskListRepository.GetAggregateById(currentTasklistId, userId);
                if (currentTasklist is null)
                {
                    var message = $"Failed to {nameof(DeleteById)} - CurrentTasklist not found";
                    return Result.Fail<Guid>(message);
                }
                await currentTaskListRepository.RemoveAsync(currentTasklist.CurrentTaskListId);
                await currentTaskListRepository.SaveChangesAsync();
                return Result.Ok(currentTasklist.CurrentTaskListId);
            }
            catch (Exception ex)
            {
                var message = $"Failed to {nameof(DeleteById)}";
                return Result.Fail<Guid>(message);
            }
        }

        public async Task<Result<CurrentTaskListWithUsersDto>> GetWithUsersById(Guid currentTasklistId)
        {
            try
            {
                var currentTasklist = await currentTaskListRepository.GetAggregateById(currentTasklistId);
                if (currentTasklist is null)
                {
                    var message = $"Failed to {nameof(GetWithUsersById)} - CurrentTasklist not found";
                    return Result.Fail<CurrentTaskListWithUsersDto>(message);
                }
                
                return Result.Ok(mapper.Map<CurrentTaskListWithUsersDto>(currentTasklist));
            }
            catch (Exception ex)
            {
                var message = $"Failed to {nameof(GetWithUsersById)}";
                return Result.Fail<CurrentTaskListWithUsersDto>(message);
            }
        }

        private async Task UpdateCurrentTaskList(CurrentTaskList currentTaskList, CurrentTaskListDto dto)
        {
            currentTaskList.CurrentTaskListName = dto.CurrentTaskListName;
            currentTaskList.UpdatedDate = DateTime.UtcNow;
            foreach(var currentTask in dto.currentTaskDtos)
            {
                var task = currentTaskList.CurrentTasks.Where(x => x.CurrentTaskId == currentTask.CurrentTaskId).FirstOrDefault();
                task.Description = currentTask.Description;
                task.UpdatedDate = DateTime.UtcNow;
                task.CurrentTaskName = currentTask.CurrentTaskName;
            }
        }

        private async Task CreateCurrentTaskList(Guid currentTaskListId, CreateCurrentTaskListDto dto,User user)
        {
            var userCurrentTaskListId = Guid.NewGuid();
            
            var currentTaskList = new CurrentTaskList 
            {
                CurrentTaskListId = currentTaskListId,
                CreatedDate = DateTime.UtcNow,
                CurrentTaskListName = dto.CurrentTaskListName,
                UserCurrentTaskListId = userCurrentTaskListId,
                OwnerId = user.UserId
            };
            var userCurrentTaskList = new UserCurrentTaskList
            {
                UserCurrentTaskListId = userCurrentTaskListId,
                CreatedDate = DateTime.UtcNow,
                UserId = user.UserId,
                CurrentTaskLists = new List<CurrentTaskList> { currentTaskList }
            };
            await currentTaskListRepository.AddAsync(currentTaskList);
            await userCurrentTaskListRepository.AddAsync(userCurrentTaskList);
            
        }
        private async Task CreateCurrentTasks(Guid currentTaskListId, CreateCurrentTaskListDto dto)
        {
            var curentTasks = dto.CreateCurrentTaskDtos.Select(x => new CurrentTask
            {
                CurrentTaskId = Guid.NewGuid(),
                CreatedDate = DateTime.UtcNow,
                CurrentTaskListId = currentTaskListId,
                CurrentTaskName = x.CurrentTaskName,
                Description = x.Description,
            });
            await currentTaskRepository.AddAsync(curentTasks);
        }
    }
}
