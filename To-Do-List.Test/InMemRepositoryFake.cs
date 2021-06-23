using System;
using System.Collections.Generic;
using System.Linq;
using To_Do_List.Entities;
using To_Do_List.Repositories;

namespace To_Do_List.Test
{
    public class InMemRepositoryFake : ITasksRepository
    {
        private readonly List<Task> tasks;

        public InMemRepositoryFake(List<Task> taskList)
        {
            this.tasks = taskList;
        }

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