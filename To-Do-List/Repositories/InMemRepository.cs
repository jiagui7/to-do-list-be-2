using System;
using System.Collections.Generic;
using System.Linq;
using To_Do_List.Entities;

namespace To_Do_List.Repositories
{
    public class InMemRepository : ITasksRepository
    {
        private readonly List<Task> tasks = new() { };

        public IEnumerable<Task> GetTasks()
        {
            return tasks;
        }

        public Task GetTask(Guid id)
        {
            return tasks.Where(tasks => tasks.Id == id).SingleOrDefault();
        }

        public void CreateTask(Task task)
        {
            this.tasks.Add(task);
        }

        public void UpdateTask(Task task)
        {
            var index = tasks.FindIndex(t => t.Id == task.Id);
            tasks[index] = task;
        }
    }
}