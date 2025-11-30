using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskService.src.Dtos
{
    public class EditTaskDto
    {
        public Guid? UserId {get; set;}

        public string? Title {get; set;} 

        public string? CompleteDescription {get; set;}

        [RegularExpression(@"^(Pendiente|En Progreso|Completado)$", ErrorMessage = "El estado ingresado no es válido.")]
        public string? State {get; set;} 

        [RegularExpression(@"^(0[1-9]|[12][0-9]|3[01])\/(0[1-9]|1[0-2])\/\d{4}$", ErrorMessage = "La fecha debe tener el formato dd/mm/yyyy.")]
        public string? ExpirationDate {get;set;} 

        public string? Comments {get;set;} 

    }
}