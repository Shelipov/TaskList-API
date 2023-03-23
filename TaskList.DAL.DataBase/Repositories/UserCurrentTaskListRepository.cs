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
    }
}
