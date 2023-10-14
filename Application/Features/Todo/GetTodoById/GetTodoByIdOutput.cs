namespace Application.Features.Todo.GetTodoById;

public record GetTodoByIdOutput(bool Success, string? ErrorMessage, string? Id, string? Title, string? Owner, DateTime? CreatedAt, bool? Completed, DateTime? CompletedAt);