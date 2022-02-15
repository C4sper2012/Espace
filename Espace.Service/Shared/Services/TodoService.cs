using System.Text;
using System.Text.Json;
using Espace.Service.Helpers;
using Espace.Service.Shared.Contracts;
using Espace.Service.Shared.Models;

namespace Espace.Service.Shared.Services
{
    public class TodoService : ITodoService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private readonly JsonSerializerOptions _options;
        
        public TodoService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _options = new JsonSerializerOptions {PropertyNameCaseInsensitive = true};
        }

        public async Task<List<TodoItem>> GetItemsAsync()
        {
            HttpClient client = _httpClientFactory.CreateClient();
            
            string content = await client.GetStringAsync(AppConstants.WebAPI.GetStringValue());
            List<TodoItem> todoItems = JsonSerializer.Deserialize<List<TodoItem>>(content, _options);

            return todoItems;
        }

        public async Task<TodoItem> GetItemByIdAsync(int id)
        {
            HttpClient client = _httpClientFactory.CreateClient();

            string content = await client.GetStringAsync($"{AppConstants.WebAPI.GetStringValue()}/{id}");
            TodoItem todoItem = JsonSerializer.Deserialize<TodoItem>(content, _options);
            return todoItem;
        }

        public async Task<TodoItem> CreateAsync(TodoItem todoItem)
        {
            HttpClient client = _httpClientFactory.CreateClient();

            string todoJson = JsonSerializer.Serialize(todoItem);
            StringContent requestContent = new StringContent(todoJson, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(AppConstants.WebAPI.GetStringValue(), requestContent);
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            TodoItem createdTodoItem = JsonSerializer.Deserialize<TodoItem>(content, _options);
            return createdTodoItem;
        }

        public async Task Update(TodoItem todoItem)
        {
            HttpClient client = _httpClientFactory.CreateClient();

            var todoJson = JsonSerializer.Serialize(todoItem);
            StringContent requestContent = new StringContent(todoJson, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"{AppConstants.WebAPI.GetStringValue()}/{todoItem.Id}", requestContent);
            response.EnsureSuccessStatusCode();
        }

        public async Task Delete(int id)
        {
            HttpClient client = _httpClientFactory.CreateClient();

            var response = await client.DeleteAsync($"{AppConstants.WebAPI.GetStringValue()}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}