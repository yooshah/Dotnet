using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagementApi.DTos;
using TaskManagementApi.Models;
using TaskManagementApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagementApi.Controllers
{
    [Authorize(Roles = "Admin,User")]
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskService _taskService;

        public TaskController(TaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TaskModel>> GetAllTasks()
        {
            var tasks = _taskService.GetAllTasks();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public ActionResult<TaskModel> GetTask(int id)
        {
            var task = _taskService.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,User")]
        public ActionResult<TaskModel> CreateTask(TaskDTO taskDto)
        {
            var username = User.Identity.Name; 
            var task = _taskService.CreateTask(taskDto, username);
            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,User")]
        public ActionResult<TaskModel> UpdateTask(int id, TaskDTO taskDto)
        {
            var task = _taskService.UpdateTask(id, taskDto);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteTask(int id)
        {
            var success = _taskService.DeleteTask(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }

}
