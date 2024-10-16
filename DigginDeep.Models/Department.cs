using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigginDeep.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Major { get; set; } = string.Empty;

        public string DepartmentHead { get; set; } = string.Empty;

        public string DepartmentEmail { get; set; } = string.Empty;
    }
}