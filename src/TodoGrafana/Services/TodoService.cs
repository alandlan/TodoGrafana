using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TodoGrafana.Data;
using TodoGrafana.Models;

namespace TodoGrafana.Services
{
    public class TodoService : ITodoService
    {
        private readonly IMongoCollection<Todo> _todosCollection;

        public TodoService(IOptions<TodoDatabaseSettings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            var database = client.GetDatabase(options.Value.DatabaseName);
            _todosCollection = database.GetCollection<Todo>(options.Value.TodoCollectionName);
        }
        public async Task<Todo> CreateTodoAsync(Todo todo)
        {
            await _todosCollection.InsertOneAsync(todo);
            return todo;
        }

        public async Task<Todo> GetTodoAsync(string id)
        {
            return await _todosCollection.Find(todo => todo.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Todo>> GetTodosAsync()
        {
            return await _todosCollection.Find(todo => true).ToListAsync();
        }

        public async Task RemoveTodoAsync(Todo todoIn)
        {
            await _todosCollection.DeleteOneAsync(todo => todo.Id == todoIn.Id);
        }

        public async Task UpdateTodoAsync(string id, Todo todoIn)
        {
            await _todosCollection.ReplaceOneAsync(todo => todo.Id == id, todoIn);
        }
    }
}