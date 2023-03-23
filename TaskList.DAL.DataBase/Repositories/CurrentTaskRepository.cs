using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskList.DAL.DataBase.Context;
using TaskList.DAL.Interface.Models;
using TaskList.DAL.Interface.Repositories;

namespace TaskList.DAL.DataBase.Repositories
{
    public class CurrentTaskRepository : SQLRepository<CurrentTask>, ICurrentTaskRepository
    {
        public CurrentTaskRepository(TaskListContext context) : base(context)
        {
        }
    }
}
