using System;
using System.Collections.Generic;
using To_Do_List.Entities;

namespace To_Do_List.Repositories
{
        public interface ITasksRepository
    {
        Task GetTask(Guid id);
        IEnumerable<Task> GetTasks();
        void CreateTask(Task task);
        void UpdateTask(Task task);
    }
}