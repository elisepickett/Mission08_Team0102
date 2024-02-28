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
        public int TaskName { get; set; }
        [Required(ErrorMessage = "The Quadrant Field is Required.")]
        public int Quadrant { get; set; }
        public DateOnly? DueDate { get; set; }
        [Required(ErrorMessage = "The Completion Field is Required.")]
        public Boolean Completion { get; set; }
    }
}
