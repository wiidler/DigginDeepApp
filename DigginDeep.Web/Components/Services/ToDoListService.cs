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
            _httpClient = httpClient;
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

        public async Task DeleteToDoList(int id)
        {
            await _httpClient.DeleteAsync($"api/todolist/{id}");
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

        public async Task<IEnumerable<ToDoList>> MarkTaskComplete(int id)
        {
            return await _httpClient.GetFromJsonAsync<ToDoList[]>($"api/todolist/complete/{id}");
        }

        public async Task<IEnumerable<ToDoList>> MarkTaskIncomplete(int id)
        {
            return await _httpClient.GetFromJsonAsync<ToDoList[]>($"api/todolist/incomplete/{id}");
        }
    }
}