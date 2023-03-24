using Microsoft.EntityFrameworkCore;
using TaskList.DAL.DataBase.Context;
using TaskList.DAL.Interface.Models;
using TaskList.DAL.Interface.Repositories;

namespace TaskList.DAL.DataBase.Repositories
{
    public class UserCurrentTaskListRepository : SQLRepository<UserCurrentTaskList>, IUserCurrentTaskListRepository
    {
        public UserCurrentTaskListRepository(TaskListContext context) : base(context)
        {
        }

        public async Task<UserCurrentTaskList> GetByIdAndUserId(Guid currentTasklistId, Guid userId)
        {
            return await dbSet.Include(x => x.CurrentTaskLists).FirstOrDefaultAsync(x => x.UserId == userId && x.CurrentTaskLists.Select(x => x.CurrentTaskListId).Contains(currentTasklistId));
        }
    }
}
