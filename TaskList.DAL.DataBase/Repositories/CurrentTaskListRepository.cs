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

        public IQueryable<CurrentTaskList> Search(SearchCurrentTaskListDto dto)
        {
            var currentTaskList = dbSet
                .Include(x => x.UserCurrentTaskLists)
                .ThenInclude(x => x.User)
                .Include(x => x.CurrentTasks)
                .Where(x => x.UserCurrentTaskLists.Select(x => x.UserId).Contains(dto.UserId.Value));

            if (!string.IsNullOrWhiteSpace(dto.Search))
            {
                currentTaskList = currentTaskList.Where(x => dto.Search.ToLower().Contains(x.CurrentTaskListName.ToLower()));
            }

            currentTaskList = dto.OrderField switch
            {
                SearchTaskListOrder.CurrentTaskListName => currentTaskList.OrderField(x => x.CurrentTaskListName, dto.OrderBy),
                SearchTaskListOrder.CreatedDate => currentTaskList.OrderField(x => x.CreatedDate, dto.OrderBy),
                _ => throw new NotImplementedException()
            };

            return currentTaskList;
        }

        public async Task<List<CurrentTaskList>> GetAggregateById(Guid currentTasklistId)
        {
            return await  dbSet
                .Include(x => x.UserCurrentTaskLists)
                .ThenInclude(x => x.User)
                .Include(x => x.CurrentTasks)
                .Where(x => x.CurrentTaskListId == currentTasklistId).ToListAsync();
        }
        public async Task<CurrentTaskList> GetAggregateById(Guid currentTasklistId,Guid userId)
        {
            return await dbSet
                .Include(x => x.UserCurrentTaskLists)
                .ThenInclude(x => x.User)
                .Include(x => x.CurrentTasks)
                .Where(x => x.CurrentTaskListId == currentTasklistId && x.UserCurrentTaskLists.Select(x => x.UserId).Contains(userId)).FirstOrDefaultAsync();
        }
        public async Task<CurrentTaskList> GetByOwnerId(Guid userId)
        {
            return await dbSet.FirstOrDefaultAsync(x => x.OwnerId == userId);
        }
    }
}
