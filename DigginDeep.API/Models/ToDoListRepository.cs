using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigginDeep.Models;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace DigginDeep.API.Models
{
    public class ToDoListRepository: IToDoListRepository
    {
        private readonly DDDatabase _DDDatabase;

        public ToDoListRepository(DDDatabase DDDatabase)
        {
            _DDDatabase = DDDatabase;
        }

        public async Task<IEnumerable<ToDoList>> GetToDoLists()
        {
            return await _DDDatabase.ToDoLists.ToListAsync();
        }

        public async Task<ToDoList> GetToDoList(int id)
        {
            var toDoList = await _DDDatabase.ToDoLists.FirstOrDefaultAsync(t => t.Id == id);
            if (toDoList == null)
            {
                throw new Exception($"ToDoList with id {id} not found.");
            }
            return toDoList;
        }

        public async Task<ToDoList> AddToDoList(ToDoList toDoList)
        {
            var result = await _DDDatabase.ToDoLists.AddAsync(toDoList);
            await _DDDatabase.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<ToDoList> UpdateToDoList(ToDoList toDoList)
        {
            var result = _DDDatabase.ToDoLists.Update(toDoList);
            await _DDDatabase.SaveChangesAsync();
            return result.Entity;
        }

        public async void DeleteToDoList(int id)
        {
            var toDoList = await _DDDatabase.ToDoLists.FirstOrDefaultAsync(t => t.Id == id);
            if (toDoList != null)
            {
                _DDDatabase.ToDoLists.Remove(toDoList);
                await _DDDatabase.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ToDoList>> Search(string task)
        {
            return await _DDDatabase.ToDoLists.Where(t => t.Task.Contains(task)).ToListAsync();
        }

        public async Task<IEnumerable<ToDoList>> GetIncompleteTasks()
        {
            return await _DDDatabase.ToDoLists.Where(t => t.IsComplete == false).ToListAsync();
        }

        public async Task<IEnumerable<ToDoList>> GetCompleteTasks()
        {
            return await _DDDatabase.ToDoLists.Where(t => t.IsComplete == true).ToListAsync();
        }

        public async Task<IEnumerable<ToDoList>> GetOverdueTasks()
        {
            return await _DDDatabase.ToDoLists.Where(t => t.DueDate.Date < DateTime.Today && t.IsComplete == false).ToListAsync();
        }
        
        public async Task<IEnumerable<ToDoList>> GetTasksDueToday()
        {
            return await _DDDatabase.ToDoLists.Where(t => t.DueDate.Date == DateTime.Today).ToListAsync();
        }

        public async Task<IEnumerable<ToDoList>> GetTasksDueTomorrow()
        {
            return await _DDDatabase.ToDoLists.Where(t => t.DueDate.Date == DateTime.Today.AddDays(1)).ToListAsync();
        }

        public async Task<IEnumerable<ToDoList>> GetTasksDueThisWeek()
        {
            return await _DDDatabase.ToDoLists.Where(t => t.DueDate.Date >= DateTime.Today && t.DueDate.Date <= DateTime.Today.AddDays(7)).ToListAsync();
        }

        public async Task<IEnumerable<ToDoList>> MarkTaskComplete(int id)
        {
            var toDoList = await _DDDatabase.ToDoLists.FirstOrDefaultAsync(t => t.Id == id);
            if (toDoList != null)
            {
                toDoList.IsComplete = true;
                await _DDDatabase.SaveChangesAsync();
            }
            return await _DDDatabase.ToDoLists.ToListAsync();
        }

        public async Task<IEnumerable<ToDoList>> MarkTaskIncomplete(int id)
        {
            var toDoList = await _DDDatabase.ToDoLists.FirstOrDefaultAsync(t => t.Id == id);
            if (toDoList != null)
            {
                toDoList.IsComplete = false;
                await _DDDatabase.SaveChangesAsync();
            }
            return await _DDDatabase.ToDoLists.ToListAsync();
        }
    }
}