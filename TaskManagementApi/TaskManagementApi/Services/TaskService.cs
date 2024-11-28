using TaskManagementApi.DTos;
using TaskManagementApi.Models;

namespace TaskManagementApi.Services
{
    public class TaskService
    {
        private readonly List<TaskModel> _tasks;

        public TaskService()
        {
            _tasks = new List<TaskModel>(); 
        }

        public IEnumerable<TaskModel> GetAllTasks()
        {
            return _tasks;
        }

        public TaskModel GetTaskById(int id)
        {
            return _tasks.FirstOrDefault(task => task.Id == id);
        }

        public TaskModel CreateTask(TaskDTO taskDto, string createdBy)
        {
            var task = new TaskModel
            {
                Id = _tasks.Count + 1,
                Title = taskDto.Title,
                Description = taskDto.Description,
                Status = taskDto.Status,
                CreatedBy = createdBy
            };
            _tasks.Add(task);
            return task;
        }

        public TaskModel UpdateTask(int id, TaskDTO taskDto)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                task.Title = taskDto.Title;
                task.Description = taskDto.Description;
                task.Status = taskDto.Status;
            }
            return task;
        }

        public bool DeleteTask(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                _tasks.Remove(task);
                return true;
            }
            return false;
        }
    }
}
