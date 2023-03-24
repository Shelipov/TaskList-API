using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskList.BLL.Interface.Dtos
{
    public class CreateCurrentTaskListDto
    {
        [Required]
        public string? CurrentTaskListName { get; set; }
        [Required]
        public Guid? UserId { get; set; }
        public ICollection<CreateCurrentTaskDto> CreateCurrentTaskDtos { get; set; }
    }
}
