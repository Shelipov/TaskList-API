using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskList.BLL.Interface.Common;
using TaskList.BLL.Interface.Dtos;
using TaskList.BLL.Interface.Services;

namespace TaskList_API.Controllers
{
    [Route("api/task-list")]
    [ApiController]
    public class TaskListController : ControllerBase
    {
        private readonly ITaskListService taskListService;
        public TaskListController(ITaskListService taskListService)
        {
            this.taskListService = taskListService;
        }

        /// <summary>
        /// Search Task List
        /// </summary> 
        /// <remarks>
        /// defaults:
        ///  - Skip = 0
        ///  - Take = 10
        ///  - OrderField = CreatedDate
        /// </remarks>
        [HttpGet("search")]
        [ProducesResponseType(typeof(PagedResponse<TaskListResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> SearchDataAccessPermissions([FromQuery] SearchTaskListDto dto)
        {
            var result = await taskListService.Search(dto);
            if (!result.IsSucceed)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok(result.Value);
        }
    }
}
