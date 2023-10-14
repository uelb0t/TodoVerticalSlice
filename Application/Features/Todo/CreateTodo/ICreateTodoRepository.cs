namespace Application.Features.Todo.CreateTodo;

public interface ICreateTodoRepository
{
    Task Add(Common.Entities.Todo todo);
}