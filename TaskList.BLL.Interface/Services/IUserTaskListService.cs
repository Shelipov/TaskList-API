using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskList.BLL.Interface.ActionResult;

namespace TaskList.BLL.Interface.Services
{
    public interface IUserTaskListService
    {
        Task<Result<Guid>> AssignmentUserToTask(Guid currentTasklistId, Guid userId);
        Task<Result<Guid>> UnAssignmentUserToTask(Guid currentTasklistId, Guid userId);
    }
}
