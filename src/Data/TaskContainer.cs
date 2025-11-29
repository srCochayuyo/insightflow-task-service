using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskService.src.Data
{
    public class TaskContainer
    {
        public List<Task> Tasks {get; set;} = new();
    }
}