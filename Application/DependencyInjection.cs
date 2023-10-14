using Application.Common;
using Application.Features.Todo.CreateTodo;
using Application.Features.Todo.GetTodoById;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IApplicationDbContext, DbContext>(provider => new DbContext(configuration));
        services.AddScoped<ICreateTodoRepository, CreateTodoRepository>();
        services.AddScoped<IGetTodoByIdRepository, GetTodoByIdRepository>();
        services.AddScoped<ICreateTodoHandler, CreateTodoHandler>();
        services.AddScoped<IGetTodoByIdHandler, GetTodoByIdHandler>();

        return services;
    }
}