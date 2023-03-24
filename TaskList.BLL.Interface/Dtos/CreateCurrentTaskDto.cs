using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskList.BLL.Interface.Dtos
{
    public class CreateCurrentTaskDto
    {
        [Required]
        public string? CurrentTaskName { get; set; }
        [Required]
        public string? Description { get; set; }
    }
}
