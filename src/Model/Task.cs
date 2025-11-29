using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskService.src.Model
{
    public class Task
    {
        public Guid Id {get; set;} = Guid.NewGuid();

        public Guid DocumentId {get; set;} 

        public Guid UserId {get; set;}

        public string Title {get; set;} = string.Empty!;

        public string comments {get;set;} = string.Empty!;

        public string CompleteDescription = string.Empty!;

        [RegularExpression(@"^(Pendiente|En Progreso|Completado)$", ErrorMessage = "El estado ingresado no es válido.")]
        public string State {get; set;} = "pendiente";

        public bool IsActive {get; set;} = true;

    }
}