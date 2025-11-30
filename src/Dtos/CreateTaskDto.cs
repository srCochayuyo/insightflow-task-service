using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskService.src.Dto
{
    public class CreateTaskDto
    {

        [Required(ErrorMessage = "Id de Documento es Requerido")]
        public Guid DocumentId {get; set;} 

        [Required(ErrorMessage = "Id de Usuario es Requerido")]
        public Guid UserId {get; set;}

        [Required(ErrorMessage = "Titulo de Tarea es Requerido")]
        public string Title {get; set;} = string.Empty!;

        public string? CompleteDescription {get; set;}

        [Required(ErrorMessage = "Estado de Tarea es Requerido")]
        [RegularExpression(@"^(Pendiente|En Progreso|Completado)$", ErrorMessage = "El estado ingresado no es válido.")]
        public string State {get; set;} = string.Empty!;

        [Required(ErrorMessage = "Fecha de Finalizacion Requerida")]
        [RegularExpression(@"^(0[1-9]|[12][0-9]|3[01])\/(0[1-9]|1[0-2])\/\d{4}$", ErrorMessage = "La fecha debe tener el formato dd/mm/yyyy.")]
        public string ExpirationDate {get;set;} = string.Empty!;

    }
}