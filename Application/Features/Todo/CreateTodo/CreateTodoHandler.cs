namespace Application.Features.Todo.CreateTodo;

public class CreateTodoHandler : ICreateTodoHandler
{
    private readonly ICreateTodoRepository _repository;
    private static readonly List<string> AvailableOwners = new() { "user1", "user2", "user3" };

    public CreateTodoHandler(ICreateTodoRepository repository)
    {
        _repository = repository;
    }

    public async Task<CreateTodoOutput> Handle(CreateTodoInput input)
    {
        if (string.IsNullOrWhiteSpace(input.Title))
            return new CreateTodoOutput(false, "Title can not be null or empty", null);
        if (string.IsNullOrWhiteSpace(input.Owner))
            return new CreateTodoOutput(false, "Owner can not be null or empty", null);
        if (!AvailableOwners.Contains(input.Owner))
            return new CreateTodoOutput(false, "Owner is not valid", null);
        
        var todo = new Common.Entities.Todo(input.Owner, input.Title);
        await _repository.Add(todo);
        return new CreateTodoOutput(true, null, todo.Id);
    }
}