using Auth0.AspNetCore.Authentication;
using Espace.Service.Shared.Models;
using Microsoft.EntityFrameworkCore;
using TodoContext = Espace.WebAPI.TodoContext;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

#region SERVICES

builder.Services.AddDbContext<TodoContext>(opt =>
    opt.UseSqlServer(
        @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TodoDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));

builder.Services.AddScoped<DbContext, DbContext>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion

WebApplication app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

#region API ENDPOINTS

app.MapGet("/todoitems", async (TodoContext db) =>
    await db.Todos.ToListAsync());

app.MapGet("/todoitems/complete", async (TodoContext db) =>
    await db.Todos.Where(t => t.Completed).ToListAsync());

app.MapGet("/todoitems/{id}", async (int id, TodoContext db) =>
    await db.Todos.FindAsync(id)
        is TodoItem todo
        ? Results.Ok(todo)
        : Results.NotFound());

app.MapPost("/todoitems", async (TodoItem todo, TodoContext db) =>
{
    db.Todos.Add(todo);
    await db.SaveChangesAsync();

    return Results.Created($"/todoitems/{todo.Id}", todo);
});

app.MapPut("/todoitems/{id}", async (int id, TodoItem inputTodo, TodoContext db) =>
{
    TodoItem? todo = await db.Todos.FindAsync(id);

    if (todo is null) return Results.NotFound();

    todo.Title = inputTodo.Title;
    todo.Description = inputTodo.Description;
    todo.Completed = inputTodo.Completed;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/todoitems/{id}", async (int id, TodoContext db) =>
{
    if (await db.Todos.FindAsync(id) is TodoItem todo)
    {
        db.Todos.Remove(todo);
        await db.SaveChangesAsync();
        return Results.Ok(todo);
    }

    return Results.NotFound();
});

#endregion


app.Run();