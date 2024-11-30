using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Json;
using DigginDeep.Models;

namespace DigginDeep.Web.Components.Services
{
    public class ToDoListService: IToDoListService
    {
        private readonly HttpClient _httpClient;

        public ToDoListService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<IEnumerable<ToDoList>> GetToDoLists()
        {
            return await _httpClient.GetFromJsonAsync<ToDoList[]>("api/todolist");
        }

        public async Task<ToDoList> GetToDoList(int id)
        {
            return await _httpClient.GetFromJsonAsync<ToDoList>($"api/todolist/{id}");
        }

        public async Task<ToDoList> AddToDoList(ToDoList toDoList)
        {
            var response = await _httpClient.PostAsJsonAsync("api/todolist", toDoList);
            return await response.Content.ReadFromJsonAsync<ToDoList>();
        }

        public async Task<ToDoList> UpdateToDoList(ToDoList toDoList)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/todolist/{toDoList.Id}", toDoList);
            return await response.Content.ReadFromJsonAsync<ToDoList>();
        }

        public async Task<bool> DeleteToDoList(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/todolist/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<ToDoList>> Search(string task)
        {
            return await _httpClient.GetFromJsonAsync<ToDoList[]>($"api/todolist/search/{task}");
        }

        public async Task<IEnumerable<ToDoList>> GetIncompleteTasks()
        {
            return await _httpClient.GetFromJsonAsync<ToDoList[]>("api/todolist/incomplete");
        }

        public async Task<IEnumerable<ToDoList>> GetCompleteTasks()
        {
            return await _httpClient.GetFromJsonAsync<ToDoList[]>("api/todolist/complete");
        }

        public async Task<IEnumerable<ToDoList>> GetOverdueTasks()
        {
            return await _httpClient.GetFromJsonAsync<ToDoList[]>("api/todolist/overdue");
        }

        public async Task<IEnumerable<ToDoList>> GetTasksDueToday()
        {
            return await _httpClient.GetFromJsonAsync<ToDoList[]>("api/todolist/today");
        }

        public async Task<IEnumerable<ToDoList>> GetTasksDueTomorrow()
        {
            return await _httpClient.GetFromJsonAsync<ToDoList[]>("api/todolist/tomorrow");
        }

        public async Task<IEnumerable<ToDoList>> GetTasksDueThisWeek()
        {
            return await _httpClient.GetFromJsonAsync<ToDoList[]>("api/todolist/thisweek");
        }

        public async Task<ToDoList> MarkTaskComplete(int id)
        {
            var response = await _httpClient.PutAsync($"api/todolist/complete/{id}", null);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ToDoList>();
        }

        public async Task<ToDoList> MarkTaskIncomplete(int id)
        {
            var response = await _httpClient.PutAsync($"api/todolist/incomplete/{id}", null);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ToDoList>();
        }
    }
}