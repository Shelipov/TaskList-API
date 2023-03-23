using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskList.DAL.Interface.Models
{
    public class CurrentTask
    {
        public Guid CurrentTaskId { get; set; }
        public string? CurrentTaskName { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        public Guid CurrentTaskListId { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual CurrentTaskList CurrentTaskList { get; set; }
    }
}
