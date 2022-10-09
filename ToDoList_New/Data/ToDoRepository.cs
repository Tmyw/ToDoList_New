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
    public List<ToDo> GetToDoList()
    {
        using (var context = new ToDoContext())
        {

            var list = context.ToDoList.AsQueryable().ToList();
            return list ;
            
        }
    }
    
    public List<ToDo> AddToDoList(int id, string taskName, bool isDone)
    {
        using (var context = new ToDoContext())
        {
            var addToDoList = new List<ToDo> { new ToDo() { Id = id, TaskName = taskName, IsDone = isDone } };
           context.ToDoList.AddRange(addToDoList);
           context.SaveChanges();
           return GetToDoList();

        }
    }
    
    
}