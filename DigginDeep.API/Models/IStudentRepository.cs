using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigginDeep.Models;
using Microsoft.EntityFrameworkCore;

namespace DigginDeep.API.Models
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetStudents();

        Task<Student> GetStudent(int id);
        Task<Student> AddStudent(Student student);
        Task<Student> UpdateStudent(Student student);

        void DeleteStudent(int id);
    }
}