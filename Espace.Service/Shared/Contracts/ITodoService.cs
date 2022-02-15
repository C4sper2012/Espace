using Espace.Service.Shared.Models;

namespace Espace.Service.Shared.Contracts
{
    public interface ITodoService
    {
        Task<List<TodoItem>> GetItemsAsync();
        Task<TodoItem> GetItemByIdAsync(int id);
        Task<TodoItem> CreateAsync(TodoItem todoItem);
        Task Update(int id, TodoItem todoItem);
        Task Delete(int id);
    }
}