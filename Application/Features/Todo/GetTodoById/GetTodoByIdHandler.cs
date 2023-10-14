namespace Application.Features.Todo.GetTodoById;

public class GetTodoByIdHandler : IGetTodoByIdHandler
{
    private readonly IGetTodoByIdRepository _repository;

    public GetTodoByIdHandler(IGetTodoByIdRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetTodoByIdOutput> Handle(GetTodoByIdInput input)
    {
        var todo = await _repository.GetById(input.Id);
        return todo == null
            ? new GetTodoByIdOutput(false, "Todo not found", null, null, null, null, false, null)
            : new GetTodoByIdOutput(true, null, todo.Id, todo.Title, todo.Owner, todo.CreatedAt, todo.Completed,
                todo.CompletedAt);
    }
}