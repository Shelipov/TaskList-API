using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskList.BLL.Interface.Enums;

namespace TaskList.BLL.Interface.Dtos
{
    public class CurrentTaskDto
    {
        public Guid CurrentTaskId { get; set; }
        public string? CurrentTaskName { get; set; }
        public string? Description { get; set; }
        public CurrentTaskStatus IsCompleted { get; set; }
        public Guid CurrentTaskListId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
