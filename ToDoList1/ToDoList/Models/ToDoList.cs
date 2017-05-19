using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ToDoList.Models
{

    public enum Priority
    {
        High, Medium, Low
    }
    [Table("Task")]
    public class ToDoList
    {
        [Key]
        [Column("TaskId")]
        public int TaskId { get; set; }

        [Column("TaskName")]
        [Required(ErrorMessage = "Task Name is required")]
        [RegularExpression(@"^[A-Za-z0-9 _]+$", ErrorMessage = "Enter Alphabets")]
        [StringLength(30, MinimumLength = 3)]
        public string TaskName { get; set; }

        public Priority? Priority { get; set; }

        public DateTime TaskDate { get; set; }

        public bool IsCompleted { get; set; }
        

    }
}