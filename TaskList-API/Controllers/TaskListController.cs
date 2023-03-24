using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
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
        private readonly ILogger<TaskListController> logger;

        public TaskListController(ITaskListService taskListService, ILogger<TaskListController> logger)
        {
            this.taskListService = taskListService;
            this.logger = logger;
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
        public async Task<ActionResult> SearchDataAccessPermissions([FromQuery] SearchCurrentTaskListDto dto)
        {
            var result = await taskListService.Search(dto);
            if (!result.IsSucceed)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok(result.Value);
        }

        /// <summary>
        /// Create new Task List
        /// </summary> 
        /// <remarks>
        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create([FromBody] CreateCurrentTaskListDto dto)
        {
            var result = await taskListService.Create(dto);
            if (!result.IsSucceed)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok(result.Value);
        }

        /// <summary>
        /// Get Task List By CurrentTasklistId
        /// </summary> 
        /// <remarks>
        [HttpGet("{currentTasklistId}/user/{UserId}")]
        [ProducesResponseType(typeof(CurrentTaskListDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetById([Required] Guid? currentTasklistId, [Required] Guid? userId)
        {
            var result = await taskListService.GetById(currentTasklistId.Value, userId.Value);
            if (!result.IsSucceed)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok(result.Value);
        }

        /// <summary>
        /// Update Task List 
        /// </summary> 
        /// <remarks>
        [HttpPut]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Update([FromBody] CurrentTaskListDto dto)
        {
            var result = await taskListService.Update(dto);
            if (!result.IsSucceed)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok(result.Value);
        }

        /// <summary>
        /// Delete Task List By CurrentTasklistId
        /// </summary> 
        /// <remarks>
        [HttpDelete("{currentTasklistId}/user/{UserId}")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteById([Required] Guid? currentTasklistId, [Required] Guid? userId)
        {
            var result = await taskListService.DeleteById(currentTasklistId.Value, userId.Value);
            if (!result.IsSucceed)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok(result.Value);
        }

        /// <summary>
        /// Get Task List with users
        /// </summary> 
        /// <remarks>
        [HttpGet("{currentTasklistId}/assignment-users")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetWithUsersById([Required] Guid? currentTasklistId)
        {
            var result = await taskListService.GetWithUsersById(currentTasklistId.Value);
            if (!result.IsSucceed)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok(result.Value);
        }
    }
}
