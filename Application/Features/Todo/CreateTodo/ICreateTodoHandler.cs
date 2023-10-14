namespace Application.Features.Todo.CreateTodo;

public interface ICreateTodoHandler
{
    Task<CreateTodoOutput> Handle(CreateTodoInput input);
}