using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using To_Do_List.DTOs;
using To_Do_List.Entities;
using To_Do_List.Repositories;

namespace To_Do_List.Controllers
{
    [ApiController]
    [Route("tasks")]
    public class TasksController : ControllerBase
    {
        private readonly ITasksRepository repository;

        public TasksController(ITasksRepository repository)
        {
            this.repository = repository;
        }

        // GET /tasks
        [HttpGet]
        public IEnumerable<TaskDTO> GetTasks()
        {
            var tasks = repository.GetTasks().Select(t => t.AsDTO());
            return tasks;
        }

        // GET /tasks/{id}
        [HttpGet("{id}")]
        public ActionResult<TaskDTO> GetTask(Guid id)
        {
            var task = repository.GetTask(id);

            if (task is null)
            {
                return NotFound();
            }

            return task.AsDTO();
        }

        // POST /tasks
        [HttpPost]
        public ActionResult<TaskDTO> CreateTask(CreateTaskDTO taskDTO)
        {
            Task task = new Task()
            {
                Id = Guid.NewGuid(),
                Description = taskDTO.Description,
                Completed = false
            };

            repository.CreateTask(task);

            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task.AsDTO());
        }

        // UPDATE /tasks/{id}
        [HttpPatch("{id}")]
        public ActionResult UpdateTask(Guid id, UpdateTaskDTO taskDTO)
        {
            var task = repository.GetTask(id);

            if (task is null)
            {
                return NotFound();
            }

            Task newTask = task with
            {
                Completed = taskDTO.Completed
            };

            repository.UpdateTask(newTask);

            return NoContent();
        }
    }
}