using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList_New.Models;

public class ToDo
{
    [Required] public int Id { get; set; }
    [Required, MaxLength(500)] public string TaskName { get; set; } = null!;
    [Required] public bool IsDone { get; set; }
}