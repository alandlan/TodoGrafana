using TodoGrafana.Models;

namespace TodoGrafana.Services
{
    public interface ITodoService
    {
        Task<IEnumerable<Todo>> GetTodosAsync();
        Task<Todo> GetTodoAsync(string id);
        Task<Todo> CreateTodoAsync(Todo todo);
        Task UpdateTodoAsync(string id, Todo todoIn);
        Task RemoveTodoAsync(Todo todoIn);
    }
}