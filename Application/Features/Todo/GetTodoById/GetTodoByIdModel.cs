namespace Application.Features.Todo.GetTodoById;

public record GetTodoByIdModel(string Id, string Title, string Owner, DateTime CreatedAt, bool Completed, DateTime CompletedAt);