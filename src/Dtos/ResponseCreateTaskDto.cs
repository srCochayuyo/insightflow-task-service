using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskService.src.Dto
{
    public class ResponseCreateTaskDto
    {
         public Guid Id {get; set;} = Guid.NewGuid();

        public Guid DocumentId {get; set;} 

        public Guid UserId {get; set;}

        public string Title {get; set;} = string.Empty!;

        public string? CompleteDescription{get; set;}

        public string State {get; set;} = string.Empty!;
    }
}