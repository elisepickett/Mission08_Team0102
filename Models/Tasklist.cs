using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mission08_Team0102.Models
{
    public class Tasklist
    {
        [Key]
        [Required]
        public int TaskId { get; set; }
        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        [Required(ErrorMessage = "The Task Name Field is Required.")]
        public string TaskName { get; set; }
        [Range(1, 4, ErrorMessage = "The Quadrant Field is Required, and must be between 1-4.")]
        public int Quadrant { get; set; }
        public DateOnly? DueDate { get; set; }
        [Required(ErrorMessage = "The Completion Field is Required.")]
        public Boolean Completion { get; set; }
    }
}
