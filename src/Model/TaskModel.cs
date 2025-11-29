using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskService.src.Model
{
    public class TaskModel
    {
        public Guid Id {get; set;} = Guid.NewGuid();

        public Guid DocumentId {get; set;} 

        public Guid UserId {get; set;}

        public string Title {get; set;} = string.Empty!;

        public string? Comments {get;set;} 

        public string? CompleteDescription{get; set;}
        
        public string State {get; set;} = string.Empty!;

        public bool IsActive {get; set;} = true; 
    }
}