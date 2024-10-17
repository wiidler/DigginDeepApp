using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigginDeep.Models;
using Microsoft.EntityFrameworkCore;

namespace DigginDeep.API.Models
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetDepartments();

        Task<Department> GetDepartment(int id);

        Task<Department> AddDepartment(Department department);

        Task<Department> UpdateDepartment(Department department);

        void DeleteDepartment(int id);
    }
}