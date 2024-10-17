using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigginDeep.Models;
using Microsoft.EntityFrameworkCore;

namespace DigginDeep.API.Models
{
    public class DepartmentRepository:IDepartmentRepository
    {
        private readonly DDDatabase _DDDatabase;

        public DepartmentRepository(DDDatabase DDDatabase)
        {
            _DDDatabase = DDDatabase;
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _DDDatabase.Departments.ToListAsync();
        }

        public async Task<Department> GetDepartment(int id)
        {
            var department = await _DDDatabase.Departments.FirstOrDefaultAsync(d => d.Id == id);
            if (department == null)
            {
                throw new InvalidOperationException("Department not found");
            }
            return department;
        }
        
        public async Task<Department> AddDepartment(Department department)
        {
            var result = _DDDatabase.Departments.AddAsync(department);
            await _DDDatabase.SaveChangesAsync();
            return result.Result.Entity;
        }

        public async Task<Department> UpdateDepartment(Department department)
        {
            var result = _DDDatabase.Departments.Update(department);
            await _DDDatabase.SaveChangesAsync();
            return result.Entity;
        }

        public async void DeleteDepartment(int id)
        {
            var department = _DDDatabase.Departments.FirstOrDefault(d => d.Id == id);
            if (department != null)
            {
                _DDDatabase.Departments.Remove(department);
                await _DDDatabase.SaveChangesAsync();
            }
        }
    }
}