using Scalar.AspNetCore;
using TaskService.src.Data;
using TaskService.src.Interface;
using TaskService.src.Repository;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();

//Controllers
builder.Services.AddControllers();

//Contenedor
builder.Services.AddSingleton<TaskContainer>();

//Repositorio
builder.Services.AddScoped<ITaskRepository, TaskRepository>();





var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
    app.MapGet("/debug-memory", (TaskContainer container) => container.Tasks);
}

app.UseHttpsRedirection();
app.MapControllers(); 
app.Run();

