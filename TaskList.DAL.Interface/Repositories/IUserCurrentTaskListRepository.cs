
using TaskList.DAL.Interface.Models;

namespace TaskList.DAL.Interface.Repositories
{
    public interface IUserCurrentTaskListRepository : IRepository<UserCurrentTaskList>
    {
        Task<UserCurrentTaskList> GetByIdAndUserId(Guid currentTasklistId, Guid userId);
    }
}
