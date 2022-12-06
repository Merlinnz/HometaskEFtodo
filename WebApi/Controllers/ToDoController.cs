namespace WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Domain.Entities;
using Domain.Wrapper;

[ApiController]
[Route("controller")]

public class ToDoController
{
    private readonly ToDoService _todoService;

    public ToDoController(ToDoService todoService)
    {
        _todoService = todoService;
    }

    [HttpGet("Get ToDos")]
    public async Task<Response<List<Todo>>> Get()
    {
        return await _todoService.GetTodos();
    }

    [HttpPost("Insert")]
    public async Task<Response<Todo>> Add(Todo todo)
    {
        return await _todoService.Add(todo);
    }

    [HttpPut]
    public async Task<Response<Todo>> Put(Todo todo)
    {
        return await _todoService.Update(todo);
    }
    
    [HttpDelete]
    public async Task<Response<Todo>> Delete(int id)
    {
        return await _todoService.Delete(id);
    }
}
