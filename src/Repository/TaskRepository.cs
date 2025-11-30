using System;
using System.Collections.Generic;
using System.Linq;
using TaskService.src.Data;
using TaskService.src.Dto;
using TaskService.src.Dtos;
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
                State = request.State,
                ExpirationDate = request.ExpirationDate

            };

            _container.Tasks.Add(TaskRequest);

            return TaskRequest.ToCreateTaskResponse();
        }

        public List<ResponseGetTaskByDocumentDto> GetTaskByDocumentId(Guid DocumentId)
        {
            var result = _container.Tasks.Where( t => t.DocumentId == DocumentId && t.IsActive)
            .Select(t => new ResponseGetTaskByDocumentDto
            {
                Id = t.Id,
                UserId = t.UserId,
                Title = t.Title,
                State = t.State,
                ExpirationDate = t.ExpirationDate

            }).ToList();

            return result;
        }

        public ResponseGetTaskDto? GetTaskById (Guid Id)
        {
            var result = _container.Tasks.FirstOrDefault(t => t.Id == Id && t.IsActive);

            if (result == null) 
            {
                return null; 
            }

            return result.ToGetTaskResponse();
        }
    }
}