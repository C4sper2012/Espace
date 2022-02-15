using System.Text;
using System.Text.Json;
using Espace.Service.Helpers;
using Espace.Service.Shared.Contracts;
using Espace.Service.Shared.Models;

namespace Espace.Service.Shared.Services
{
    public class TodoService : ITodoService
    {
        private static readonly HttpClient _httpClient = new HttpClient
            {BaseAddress = new Uri(AppConstants.BaseUrl.GetStringValue())};

        private readonly JsonSerializerOptions _options;

        public TodoService()
        {
            _options = new JsonSerializerOptions {PropertyNameCaseInsensitive = true};
        }

        public async Task<List<TodoItem>> GetItemsAsync()
        {
            string content = await _httpClient.GetStringAsync(AppConstants.WebAPI.GetStringValue());
            List<TodoItem> todoItems = JsonSerializer.Deserialize<List<TodoItem>>(content, _options);

            return todoItems;
        }

        public async Task<TodoItem> GetItemByIdAsync(int id)
        {
            string content = await _httpClient.GetStringAsync($"{AppConstants.WebAPI.GetStringValue()}/{id}");
            TodoItem todoItem = JsonSerializer.Deserialize<TodoItem>(content, _options);
            return todoItem;
        }

        public async Task<TodoItem> CreateAsync(TodoItem todoItem)
        {
            string todoJson = JsonSerializer.Serialize(todoItem);
            StringContent requestContent = new StringContent(todoJson, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(AppConstants.WebAPI.GetStringValue(), requestContent);
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            TodoItem createdTodoItem = JsonSerializer.Deserialize<TodoItem>(content, _options);
            return createdTodoItem;
        }

        public async Task Update(int id, TodoItem todoItem)
        {
            var todoJson = JsonSerializer.Serialize(todoItem);
            StringContent requestContent = new StringContent(todoJson, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{AppConstants.WebAPI.GetStringValue()}/{id}", requestContent);
            response.EnsureSuccessStatusCode();
        }

        public async Task Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"{AppConstants.WebAPI.GetStringValue()}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}