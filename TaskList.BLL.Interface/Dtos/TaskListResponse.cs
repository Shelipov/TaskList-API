using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskList.BLL.Interface.Dtos
{
    public class TaskListResponse
    {
        public Guid CurrentTaskListId { get; set; }
        public string? CurrentTaskListName { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
    }
}
