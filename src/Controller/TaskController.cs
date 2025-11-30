using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TaskService.src.Dto;
using TaskService.src.Interface;

namespace TaskService.src
{
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;
        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpPost("Tasks")]
        public IActionResult CreateTask(CreateTaskDto request)
        {
            try
            {

                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result =  _taskRepository.CreateTask(request);

                return Ok(new
                {
                    message = "Tarea creada con exito",
                    Task = result
                });
                
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpGet("documents/{documentId}/tasks")]
        public IActionResult GetTaskByDocumentId(Guid documentId)
        {
            try
            {
                
                var Tasks = _taskRepository.GetTaskByDocumentId(documentId);

                var response = new
                {
                    message = "Tareas Obtenidas con exito",
                    Tasks = Tasks
                };

                return Ok(response);
            }
            catch (Exception e)
            {
                
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpGet("tasks/{Id}")]
        public IActionResult GetTaskById (Guid Id)
        {
            try
            {
                var task = _taskRepository.GetTaskById(Id);

                if(task == null)
                {
                    return NotFound("Error: Tarea no encontrada");
                }

                var response = new
                {
                    message = "Tareas Obtenidas con exito",
                    Task = task
                };

                return Ok(response);
            }
            catch (Exception e)
            {
                
                return StatusCode(500, new { message = e.Message });
            }
        }

        

        


    }
}