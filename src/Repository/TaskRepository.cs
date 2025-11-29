using System;
using System.Collections.Generic;
using System.Linq;
using TaskService.src.Data;
using TaskService.src.Dto;
using TaskService.src.Interface;
using TaskService.src.Mapper;
using TaskService.src.Model;

namespace TaskService.src.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskContainer _container;

        public TaskRepository(TaskContainer container)
        {
            _container = container;
        }

        public ResponseCreateTaskDto CreateTask(CreateTaskDto request)
        {
          var TaskRequest = new TaskModel
            {
                DocumentId = request.DocumentId,
                UserId = request.UserId,
                Title = request.Title,
                CompleteDescription = request.CompleteDescription,
                State = request.State

            };

            _container.Tasks.Add(TaskRequest);

            return TaskRequest.ToCreateTaskResponse();
        }
    }
}