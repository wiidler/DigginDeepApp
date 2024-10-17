using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using DigginDeep.API.Models;
using DigginDeep.Models;

namespace DigginDeepApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetStudents()
        {
            try
            {
                return Ok(await _studentRepository.GetStudents());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetStudent(int id)
        {
            try
            {
                return Ok(await _studentRepository.GetStudent(id));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddStudent(Student student)
        {
            try
            {
                return Ok(await _studentRepository.AddStudent(student));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateStudent(Student student)
        {
            try
            {
                return Ok(await _studentRepository.UpdateStudent(student));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            try
            {
            _studentRepository.DeleteStudent(id);
            return Ok();
            }
            catch (Exception e)
            {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
