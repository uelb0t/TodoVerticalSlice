using System.Data;
using Application.Common;
using Dapper;

namespace Application.Features.Todo.CreateTodo;

public class CreateTodoRepository : ICreateTodoRepository
{
    private readonly IApplicationDbContext _context;

    public CreateTodoRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    private IDbConnection Connection => _context.CreateConnection();
    
    public async Task Add(Common.Entities.Todo todo)
    {
        const string sql = "INSERT INTO todo (id, owner, title, completed, created_at, completed_at) VALUES (@Id, @Owner, @Title, @Completed, @CreatedAt, @CompletedAt)";
        await Connection.ExecuteAsync(sql, todo);
    }
}