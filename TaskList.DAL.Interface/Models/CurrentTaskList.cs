using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskList.DAL.Interface.Models
{
    public class CurrentTaskList
    {
        public Guid CurrentTaskListId { get; set; }
        [MaxLength(255)]
        public string? CurrentTaskListName { get; set;}
        public DateTime? UpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UserCurrentTaskListId { get; set; }
        public Guid? OwnerId { get; set; }
        public virtual ICollection<UserCurrentTaskList> UserCurrentTaskLists { get; set; }
        public virtual ICollection<CurrentTask> CurrentTasks { get; set; } 
    }
}
