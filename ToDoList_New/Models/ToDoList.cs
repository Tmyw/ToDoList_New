namespace ToDoList_New.Models;

public class ToDoList
{
    
    public int Id { get; set; }
    public string TaskName { get; set; } = null!;
    public bool IsDone { get; set; }
   
}