using System;
using System.ComponentModel.DataAnnotations;

namespace DigginDeep.Models
{
    public class ToDoList
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Task { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [Required]
        public DateTime DueDate { get; set; }
        
        public bool IsComplete { get; set; }
    }
}