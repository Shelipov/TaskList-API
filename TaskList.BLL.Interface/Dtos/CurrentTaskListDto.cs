using System.ComponentModel.DataAnnotations;

namespace TaskList.BLL.Interface.Dtos
{
    public class CurrentTaskListDto
    {
        public Guid CurrentTaskListId { get; set; }
        [MaxLength(255)]
        public string? CurrentTaskListName { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required]
        public Guid? UserId { get; set; }
        public IEnumerable<CurrentTaskDto> currentTaskDtos { get; set; }
    }
}
