using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;                                                                              

namespace Infrastructure.Services;

public class ToDoService
{
    private readonly DataContext _context;

    public ToDoService(DataContext context)
    {
        _context = context;
    }

    public async Task<Response<List<Todo>>> GetTodos()
    {
        var response =  await _context.Todos.ToListAsync();
        return new Response<List<Todo>>(response);
    }

    public async Task<Response<Todo>> Add(Todo todo)
    {
        _context.Todos.Add(todo);
        await _context.SaveChangesAsync();
        return new Response<Todo>(todo);
    }

    public async Task<Response<Todo>> Update(Todo todo)
    {
        var find = await _context.Todos.FindAsync(todo.Id);
        find.Title = todo.Title;
        find.Description = todo.Description;
        find.Status = todo.Status;

        await _context.SaveChangesAsync();
        return new Response<Todo>(todo);
    }

    public async Task<Response<Todo>> Delete(int id)
    {
        var find = await _context.Todos.FindAsync(id);
        _context.Todos.Remove(find);
        await _context.SaveChangesAsync();
        return new Response<Todo>(find);
    }
}