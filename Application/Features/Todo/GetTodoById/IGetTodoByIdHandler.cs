namespace Application.Features.Todo.GetTodoById;

public interface IGetTodoByIdHandler
{
    Task<GetTodoByIdOutput> Handle(GetTodoByIdInput input);
}