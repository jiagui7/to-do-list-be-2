using System;
using Xunit;
using To_Do_List.Controllers;
using To_Do_List.Repositories;
using To_Do_List.DTOs;
using To_Do_List.Entities;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace To_Do_List.Test
{
    public class TasksControllerTest
    {
        TasksController _controller;
        ITasksRepository _repository;

        static Guid idTracked = Guid.NewGuid();
        static string descriptionTracked = "Task 1";
        List<Task> initialTasks = new List<Task>()
            {
                new Task { Id = idTracked, Description = descriptionTracked, Completed = false },
                new Task { Id = Guid.NewGuid(), Description = "Task 2", Completed = false },
                new Task { Id = Guid.NewGuid(), Description = "Task 1", Completed = false }
            };

        public TasksControllerTest()
        {
            _repository = new InMemRepositoryFake(initialTasks);
            _controller = new TasksController(_repository);
        }

        [Fact]
        public void GetAllReturnsOkWhenCalled()
        {
            // Act
            var result = _controller.GetTasks();

            // Assert
            
        }

        [Fact]
        public void GetAllReturnsNotFoundWhenIdIsInvalid()
        {
            // Act
            var result = _controller.GetTask(Guid.NewGuid());

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void GetReturnsNotFoundWhenTaskDoesNotExist()
        {
            // Act
            var response = _controller.GetTask(Guid.NewGuid());

            // Assert
            Assert.IsType<NotFoundResult>(response.Result);
        }

        [Fact]
        public void GetReturnsTaskWhenIdExists()
        {
            // Act
            var response = _controller.GetTask(idTracked);

            // Assert
            Assert.Equal(descriptionTracked, response.Value.Description);
        }

        [Fact]
        public void AddReturnValidResponseWhenObjectIsValid()
        {
            // Arrange
            var task = new CreateTaskDTO() { Description = "Task 4" };

            // Act
            var response = _controller.CreateTask(task);

            // Assert
            var createdTask = (response.Result as CreatedAtActionResult).Value as TaskDTO;
            Assert.Equal(task.Description, createdTask.Description);
            Assert.Equal(false, createdTask.Completed);
        }

        [Fact]
        public void UpdateReturnNotFoundWhenItemDoesNotExist()
        {
            // Arrange
            var task = new UpdateTaskDTO() { Completed = true };

            // Act
            var response = _controller.UpdateTask(Guid.NewGuid(), task);

            // Assert
            Assert.IsType<NotFoundResult>(response);
        }
    }
}
