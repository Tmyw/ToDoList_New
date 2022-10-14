using System.Text.Json.Nodes;
using Microsoft.EntityFrameworkCore;
using ToDoList_New.Models;

namespace ToDoList_New.Data;

public class ToDoRepository : IToDoRepository
{
    public List<ToDo> toDoList;
    public int i = 3;
    private readonly ToDoContext context;

    public ToDoRepository(ToDoContext context)
    {
        this.context = context;
    }

    public List<ToDo> getToDoList()
    {
        var list = context.ToDoList.AsQueryable().ToList();
        return list;
    }

    public void addToDoList(ToDo todo)
    {
        i++;
        context.ToDoList.Add(new ToDo { Id = i, TaskName =todo.TaskName, IsDone = false });
        context.SaveChanges();
    }

    public List<ToDo> updateStatus(int id, JsonObject request)
    {
        i++;
        var taskName = (string)request["taskName"];
        var toDo = context.ToDoList.Single(x => x.TaskName == taskName && x.Id == id);
        var status =
            toDo.IsDone = (bool)request["isDone"];
        ;
        context.SaveChanges();
        var list = context.ToDoList.Where(x => x.Id == id).AsQueryable().ToList();
        return list;
    }
}