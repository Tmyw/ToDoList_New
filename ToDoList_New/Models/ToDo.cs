using System.ComponentModel.DataAnnotations;

namespace ToDoList_New.Models;

public class ToDo
{
    
   public int Id { get; set; }
   [Required]  public string TaskName { get; set; } = null!;
    public bool IsDone { get; set; }
   
}