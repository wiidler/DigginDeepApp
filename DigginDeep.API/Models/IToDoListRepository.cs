using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigginDeep.Models;
using Microsoft.EntityFrameworkCore;

namespace DigginDeep.API.Models
{
    public interface IToDoListRepository
    {
        Task<IEnumerable<ToDoList>> GetToDoLists();

        Task<ToDoList> GetToDoList(int id);

        Task<ToDoList> AddToDoList(ToDoList toDoList);

        Task<ToDoList> UpdateToDoList(ToDoList toDoList);

        void DeleteToDoList(int id);

        Task<IEnumerable<ToDoList>> Search(string task);

        Task<IEnumerable<ToDoList>> GetIncompleteTasks();

        Task<IEnumerable<ToDoList>> GetCompleteTasks();

        Task<IEnumerable<ToDoList>> GetOverdueTasks();

        Task<IEnumerable<ToDoList>> GetTasksDueToday();

        Task<IEnumerable<ToDoList>> GetTasksDueTomorrow();

        Task<IEnumerable<ToDoList>> GetTasksDueThisWeek();

        Task<IEnumerable<ToDoList>> MarkTaskComplete(int id);

        Task<IEnumerable<ToDoList>> MarkTaskIncomplete(int id);
    }
}