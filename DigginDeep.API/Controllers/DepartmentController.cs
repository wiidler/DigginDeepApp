using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using DigginDeep.API.Models;
using DigginDeep.Models;

namespace DigginDeepApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetDepartments()
        {
            try
            {
                return Ok(await _departmentRepository.GetDepartments());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetDepartment(int id)
        {
            try
            {
                return Ok(await _departmentRepository.GetDepartment(id));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddDepartment(Department department)
        {
            try
            {
                return Ok(await _departmentRepository.AddDepartment(department));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateDepartment(Department department)
        {
            try
            {
                return Ok(await _departmentRepository.UpdateDepartment(department));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDepartment(int id)
        {
            try
            {
                _departmentRepository.DeleteDepartment(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
