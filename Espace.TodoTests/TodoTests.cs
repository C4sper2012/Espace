using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace TodoTests
{
    public class TodoTests
    {
        [Fact]
        public async Task GetTodos()
        {
            HttpClient client = new HttpClient();
            var todos = await client.GetFromJsonAsync<List<Todo>>("https://localhost:5001/todoitems");

            Assert.NotEmpty(todos);
        }

        [Fact]
        public async Task PostTodos()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:5001/todoitems", new Todo { Name = "I want to do this thing tomorrow" });

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            
            List<Todo> todos = await client.GetFromJsonAsync<List<Todo>>("https://localhost:5001/todoitems");

            Todo todo = Assert.Single(todos);
            Assert.Equal("I want to do this thing tomorrow", todo.Name);
            Assert.False(todo.IsComplete);
        }

        [Fact]
        public async Task DeleteTodos()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:5001/todoitems", new Todo { Name = "I want to do this thing tomorrow" });

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            var todos = await client.GetFromJsonAsync<List<Todo>>("https://localhost:5001/todoitems");
            
            
            Todo todo = Assert.Single(todos);
            
            Assert.Equal("I want to do this thing tomorrow", todo.Name);
            Assert.False(todo.IsComplete);

            response = await client.DeleteAsync($"https://localhost:5001/todoitems/{todo.Id}");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            response = await client.GetAsync($"https://localhost:5001/todoitems/{todo.Id}");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            
        }
    }
}