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

        public ResponseEditTaskDto EditTask(Guid Id, EditTaskDto request)
        {
            var exist = _container.Tasks.FirstOrDefault(t => t.Id == Id);

            if(exist == null)
            {
                throw new Exception("Error: Tarea no encontrada");
            }

            if (request.UserId.HasValue && request.UserId.Value != Guid.Empty)
            {
                
                exist.UserId = request.UserId.Value;
            }

            if(!string.IsNullOrEmpty(request.Title))
            {
                exist.Title = request.Title;
            }

            if(!string.IsNullOrEmpty(request.CompleteDescription))
            {
                exist.CompleteDescription = request.CompleteDescription;
            }

            if(!string.IsNullOrEmpty(request.State))
            {
                exist.State = request.State;
            }

            if(!string.IsNullOrEmpty(request.ExpirationDate))
            {
                exist.ExpirationDate = request.ExpirationDate;
            }

            if(!string.IsNullOrEmpty(request.Comments))
            {
                exist.Comments = request.Comments;
            }

        

            return exist.ToGetEditResponse();

        }
    }
}