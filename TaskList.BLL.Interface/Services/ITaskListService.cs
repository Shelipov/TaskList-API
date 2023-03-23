using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskList.BLL.Interface.ActionResult;
using TaskList.BLL.Interface.Common;
using TaskList.BLL.Interface.Dtos;

namespace TaskList.BLL.Interface.Services
{
    public interface ITaskListService
    {
        Task<Result<PagedResponse<TaskListResponse>>> Search(SearchTaskListDto dto);
    }
}
