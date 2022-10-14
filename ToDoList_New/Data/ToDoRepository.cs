using Microsoft.AspNetCore.Mvc;
using ToDoList_New.Models;

namespace ToDoList_New.Data;

public class ToDoRepository : IToDoRepository
{
    private readonly ToDoContext context;

    public ToDoRepository(ToDoContext context)
    {
        this.context = context;
    }

    public List<ToDo> GetToDoList()
    {
        var list = context.ToDoList.AsQueryable().ToList();
        return list;
    }

    public void AddToDoList(ToDo toDo)
    {
        context.ToDoList.AddRange(new ToDo { TaskName =toDo.TaskName, IsDone = false });
        context.SaveChanges();
    }

    public async Task<ActionResult> UpdateStatus(int id, ToDo toDo)
    {
        var checkExisting = context.ToDoList.Any(x => x.TaskName == toDo.TaskName && x.Id == toDo.Id);
        if (checkExisting)
        {
            var toBeUpdated = context.ToDoList.Single(x => x.Id == id);
            toBeUpdated.IsDone = toDo.IsDone;
            await context.SaveChangesAsync();
            return null;
        }
       
        return new BadRequestObjectResult($"The request which id is {toDo.Id} and taskName is {toDo.TaskName} does not exist") ;
        
    }

    public void Remove(int id)
    {
        var toDo = context.ToDoList.Single(x => x.Id == id);
        context.ToDoList.Remove(toDo);
        context.SaveChanges();
    }
    
    public bool Validate(int id)
    {
        return context.ToDoList.Any(x => x.Id == id);;
    }
    
    
    
}