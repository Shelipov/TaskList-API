using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskList.BLL.Interface.ActionResult;

namespace TaskList.Sheduler.Intefaces
{
    public interface ITaskListShedulerService
    {
        Task Exequte();
    }
}
