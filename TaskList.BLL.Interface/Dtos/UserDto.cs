using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskList.BLL.Interface.Dtos
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public string? FullName { get; set; }
    }
}
