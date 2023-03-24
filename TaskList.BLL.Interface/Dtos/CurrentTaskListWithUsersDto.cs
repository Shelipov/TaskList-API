using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskList.BLL.Interface.Dtos
{
    public class CurrentTaskListWithUsersDto
    {
        public Guid CurrentTaskListId { get; set; }
        public string? CurrentTaskListName { get; set; }
        public IEnumerable<UserDto> Users { get; set; }
    }
}
