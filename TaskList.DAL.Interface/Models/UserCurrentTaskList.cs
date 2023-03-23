using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskList.DAL.Interface.Models
{
    public class UserCurrentTaskList
    {
        public Guid UserCurrentTaskListId { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<CurrentTaskList> CurrentTaskLists { get; set; } 
    }
}
