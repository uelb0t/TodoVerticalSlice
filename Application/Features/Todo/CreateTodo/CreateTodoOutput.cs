namespace Application.Features.Todo.CreateTodo;

public record CreateTodoOutput(bool Success, string? ErrorMessage, string? Id);