using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mission08_Team0102.Models
{
    public class Task
    {
        [Key]
        [Required]
        public int TaskId { get; set; }
        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public int TaskName { get; set; }
        public int Quadrant { get; set; }
        public DateOnly? DueDate { get; set; }
        public Boolean Completion { get; set; }
    }
}
