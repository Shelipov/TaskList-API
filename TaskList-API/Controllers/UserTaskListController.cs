using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TaskList.BLL.Interface.Services;

namespace TaskList_API.Controllers
{
    [Route("api/user-tasks")]
    [ApiController]
    public class UserTaskListController : ControllerBase
    {
        private readonly IUserTaskListService userTaskListService;
        private readonly ILogger<TaskListController> logger;

        public UserTaskListController(IUserTaskListService userTaskListService, ILogger<TaskListController> logger)
        {
            this.userTaskListService = userTaskListService;
            this.logger = logger;
        }

        /// <summary>
        /// assignment user to Task List 
        /// </summary> 
        /// <remarks>
        [HttpPut("{userId}/assignment/{currentTaskListId}")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AssignmentUserToTask([Required] Guid? currentTaskListId,[Required] Guid? userId)
        {
            var result = await userTaskListService.AssignmentUserToTask(currentTaskListId.Value, userId.Value);
            if (!result.IsSucceed)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok(result.Value);
        }

        /// <summary>
        /// unassignment user from Task List 
        /// </summary> 
        /// <remarks>
        [HttpPut("{userId}/unassignment/{currentTaskListId}")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UnAssignmentUserToTask([Required] Guid? currentTaskListId,[Required] Guid? userId)
        {
            var result = await userTaskListService.UnAssignmentUserToTask(currentTaskListId.Value, userId.Value);
            if (!result.IsSucceed)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok(result.Value);
        }
    }
}
