using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskService.src.Dto
{
    public class CreateTaskDto
    {

        public Guid DocumentId {get; set;} 

        public Guid UserId {get; set;}

        public string Title {get; set;} = string.Empty!;

        public string? CompleteDescription {get; set;}

        [RegularExpression(@"^(Pendiente|En Progreso|Completado)$", ErrorMessage = "El estado ingresado no es válido.")]
        public string State {get; set;} = string.Empty!;

    }
}