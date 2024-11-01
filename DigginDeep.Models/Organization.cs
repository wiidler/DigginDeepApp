using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigginDeep.Models
{
    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string website { get; set; } = string.Empty;

    }
}