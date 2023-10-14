namespace Application.Features.Todo.GetTodoById;

public interface IGetTodoByIdRepository
{
    Task<GetTodoByIdModel?> GetById(string id);
}