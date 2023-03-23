using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskList.BLL.Interface.Dtos;
using TaskList.BLL.Interface.Enums;
using TaskList.BLL.Interface.Extensions;
using TaskList.DAL.DataBase.Context;
using TaskList.DAL.Interface.Models;
using TaskList.DAL.Interface.Repositories;

namespace TaskList.DAL.DataBase.Repositories
{
    public class CurrentTaskListRepository : SQLRepository<CurrentTaskList>, ICurrentTaskListRepository
    {
        public CurrentTaskListRepository(TaskListContext context) : base(context)
        {
        }

        public IQueryable<CurrentTaskList> Search(SearchTaskListDto dto)
        {
            var currentTaskList = dbSet
                .Include(x => x.UserCurrentTaskList)
                .ThenInclude(x => x.User)
                .Include(x => x.CurrentTasks)
                .Where(x => x.CurrentTasks.Select(x => x.IsCompleted).Distinct().Contains(false));

            if (!string.IsNullOrWhiteSpace(dto.Search))
            {
                currentTaskList = currentTaskList.Where(x => dto.Search.ToLower().Contains(x.CurrentTaskListName.ToLower())
                  || dto.Search.ToLower().Contains(x.UserCurrentTaskList.User.FirstName.ToLower())
                  || dto.Search.ToLower().Contains(x.UserCurrentTaskList.User.LastName.ToLower()));
            }

            currentTaskList = dto.OrderField switch
            {
                SearchTaskListOrder.CurrentTaskListName => currentTaskList.OrderField(x => x.CurrentTaskListName, dto.OrderBy),
                SearchTaskListOrder.CreatedDate => currentTaskList.OrderField(x => x.CreatedDate, dto.OrderBy),
                SearchTaskListOrder.UserFirstName => currentTaskList.OrderField(x => x.UserCurrentTaskList.User.FirstName, dto.OrderBy),
                SearchTaskListOrder.UserLastName => currentTaskList.OrderField(x => x.UserCurrentTaskList.User.LastName, dto.OrderBy),
                _ => throw new NotImplementedException()
            };

            return currentTaskList;
        }
    }
}
