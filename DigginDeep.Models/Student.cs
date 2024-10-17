using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigginDeep.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Major { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public Department Department { get; set; } = new Department();
    }
}