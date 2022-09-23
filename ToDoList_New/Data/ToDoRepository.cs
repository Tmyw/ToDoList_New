using Microsoft.EntityFrameworkCore;
using ToDoList_New.Models;

namespace ToDoList_New.Data;

public class ToDoRepository :IToDoRepository
{
    public ToDoRepository()
    {
        using (var context = new ToDoContext())
        {
            var toDoList=new List<ToDo>
            {
                
                    new ToDo { Id = 1,TaskName = "read a book", IsDone = true},
                    new ToDo { Id = 2,TaskName = "do homework",IsDone = false},
                    new ToDo { Id = 3,TaskName = "buy clothes",IsDone = true}
                    
                
            };
            
            context.ToDoList.AddRange(toDoList);
            context.SaveChanges();
        }
        
    }
    public string GetToDoList()
    {
        using (var context = new ToDoContext())
        {
            
            var list = context.ToDoList.ToString();
            return list ;
            
        }

       
    }
}