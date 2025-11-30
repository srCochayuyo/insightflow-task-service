using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskService.src.Dto;
using TaskService.src.Dtos;

namespace TaskService.src.Interface
{
    public interface ITaskRepository
    {
        public ResponseCreateTaskDto CreateTask (CreateTaskDto request);

        public List<ResponseGetTaskByDocumentDto> GetTaskByDocumentId (Guid DocumentId);

        public ResponseGetTaskDto? GetTaskById (Guid Id);

        public ResponseEditTaskDto EditTask(Guid Id, EditTaskDto request);
    }
}