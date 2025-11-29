using System;
using System.Collections.Generic;
using System.Linq;
using TaskService.src.Model;

namespace TaskService.src.Data
{
    public class TaskContainer
    {
        public List<TaskModel> Tasks {get; set;} = new();
    }
}