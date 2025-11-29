using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskService.src.Dto;

namespace TaskService.src.Interface
{
    public interface ITaskRepository
    {
        public ResponseCreateTaskDto CreateTask (CreateTaskDto request);
    }
}