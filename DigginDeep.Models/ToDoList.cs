using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigginDeep.Models
{
    public class ToDoList
    {
        public int Id { get; set; }
        public string Task { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public bool IsComplete { get; set; }
    }
}