using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using DigginDeep.API.Models;
using DigginDeep.Models;

namespace DigginDeep.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ToDoListController: ControllerBase
    {
        private readonly IToDoListRepository _toDoListRepository;

        public ToDoListController(IToDoListRepository toDoListRepository)
        {
            _toDoListRepository = toDoListRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetToDoLists()
        {
            try
            {
                return Ok(await _toDoListRepository.GetToDoLists());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetToDoList(int id)
        {
            try
            {
                return Ok(await _toDoListRepository.GetToDoList(id));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddToDoList(ToDoList toDoList)
        {
            try
            {
                return Ok(await _toDoListRepository.AddToDoList(toDoList));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateToDoList(ToDoList toDoList)
        {
            try
            {
                return Ok(await _toDoListRepository.UpdateToDoList(toDoList));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteToDoList(int id)
        {
            try
            {
                _toDoListRepository.DeleteToDoList(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("search/{task}")]
        public async Task<ActionResult> Search(string task)
        {
            try
            {
                return Ok(await _toDoListRepository.Search(task));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("incomplete")]
        public async Task<ActionResult> GetIncompleteTasks()
        {
            try
            {
                return Ok(await _toDoListRepository.GetIncompleteTasks());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("complete")]
        public async Task<ActionResult> GetCompleteTasks()
        {
            try
            {
                return Ok(await _toDoListRepository.GetCompleteTasks());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("overdue")]
        public async Task<ActionResult> GetOverdueTasks()
        {
            try
            {
                return Ok(await _toDoListRepository.GetOverdueTasks());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("today")]
        public async Task<ActionResult> GetTasksDueToday()
        {
            try
            {
                return Ok(await _toDoListRepository.GetTasksDueToday());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("tomorrow")]
        public async Task<ActionResult> GetTasksDueTomorrow()
        {
            try
            {
                return Ok(await _toDoListRepository.GetTasksDueTomorrow());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("thisweek")]
        public async Task<ActionResult> GetTasksDueThisWeek()
        {
            try
            {
                return Ok(await _toDoListRepository.GetTasksDueThisWeek());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPut("complete/{id}")]
        public async Task<ActionResult> MarkTaskComplete(int id)
        {
            try
            {
                return Ok(await _toDoListRepository.MarkTaskComplete(id));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPut("incomplete/{id}")]
        public async Task<ActionResult> MarkTaskIncomplete(int id)
        {
            try
            {
                return Ok(await _toDoListRepository.MarkTaskIncomplete(id));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}