using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigginDeep.Models;
using Microsoft.EntityFrameworkCore;

namespace DigginDeep.API.Models
{
    public class StudentRepository: IStudentRepository
    {
        private readonly DDDatabase _DDDatabase;

        public StudentRepository(DDDatabase DDDatabase)
        {
            _DDDatabase = DDDatabase;
        }

        

        public async Task<Student> AddStudent(Student student)
        {
            var result = _DDDatabase.Students.AddAsync(student);
            await _DDDatabase.SaveChangesAsync();
            return result.Result.Entity;
        }

        public async void DeleteStudent(int id)
        {
            var student = _DDDatabase.Students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                _DDDatabase.Students.Remove(student);
                await _DDDatabase.SaveChangesAsync();
            }
        }

        public async Task<Student> GetStudent(int id)
        {
            var student = await _DDDatabase.Students.FirstOrDefaultAsync(s => s.Id == id);
            if (student == null)
            {
                throw new Exception($"Student with id {id} not found.");
            }
            return student;
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _DDDatabase.Students.ToListAsync();
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            var result = _DDDatabase.Students.Update(student);
            await _DDDatabase.SaveChangesAsync();
            return result.Entity;
        }

    }
}