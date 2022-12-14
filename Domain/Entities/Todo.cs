namespace Domain.Entities;


public class Todo
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public Status Status { get; set; }
}

public enum Status
{
    Todo,
    InProgress,
    Done
}