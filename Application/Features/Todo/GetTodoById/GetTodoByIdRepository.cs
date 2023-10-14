using System.Data;
using Application.Common;
using Dapper;

namespace Application.Features.Todo.GetTodoById;

public class GetTodoByIdRepository : IGetTodoByIdRepository
{
    private readonly IApplicationDbContext _context;

    public GetTodoByIdRepository(IApplicationDbContext context)
    {
        _context = context;
    }
    
    private IDbConnection Connection => _context.CreateConnection();
    
    public Task<GetTodoByIdModel?> GetById(string id)
    {
        const string sql = "SELECT id, title, owner, created_at as \"CreatedAt\", completed, completed_at as \"CompletedAt\" FROM todo WHERE id = @Id";
        return Connection.QuerySingleOrDefaultAsync<GetTodoByIdModel>(sql, new { Id = id });
    }
}