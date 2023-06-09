﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskList.BLL.Interface.Dtos;
using TaskList.DAL.Interface.Models;

namespace TaskList.DAL.Interface.Repositories
{
    public interface ICurrentTaskListRepository : IRepository<CurrentTaskList>
    {
        IQueryable<CurrentTaskList> Search(SearchCurrentTaskListDto dto);
        Task<List<CurrentTaskList>> GetAggregateById(Guid currentTasklistId);
        Task<CurrentTaskList> GetAggregateById(Guid currentTasklistId, Guid userId);
    }
}
