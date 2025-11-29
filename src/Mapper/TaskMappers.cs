using System;
using System.Collections.Generic;
using System.Linq;
using TaskService.src.Dto;
using TaskService.src.Model;

namespace TaskService.src.Mapper
{
    public static  class TaskMappers
    {
        public static ResponseCreateTaskDto ToCreateTaskResponse(this TaskModel task)
        {
            return new ResponseCreateTaskDto
            {
                Id  = task.Id,
                DocumentId = task.DocumentId,
                UserId = task.UserId,
                Title = task.Title,
                CompleteDescription = task.CompleteDescription,
                State = task.State
            };
        }
    }
}