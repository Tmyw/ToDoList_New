using System.Text.Json.Nodes;
using Microsoft.EntityFrameworkCore;
using ToDoList_New.Models;

namespace ToDoList_New.Data;

public class ToDoRepository : IToDoRepository
{
    public List<ToDo> toDoList;
    public int i = 3;


    public ToDoRepository()
    {
        using var context = new ToDoContext();
        toDoList = new List<ToDo>
        {
            new ToDo { Id = 1, TaskName = "read a book", IsDone = true },
            new ToDo { Id = 2, TaskName = "do homework", IsDone = false },
            new ToDo { Id = 3, TaskName = "buy clothes", IsDone = true }
        };

        context.ToDoList.AddRange(toDoList);
        context.SaveChanges();
    }

    public List<ToDo> getToDoList()
    {
        using var context = new ToDoContext();
        var list = context.ToDoList.AsQueryable().ToList();
        return list;
    }

    public void addToDoList(JsonObject request)
    {
        using var context = new ToDoContext();
        i++;
        context.ToDoList.Add(new ToDo { Id = i, TaskName = (string)request["taskName"], IsDone = false });
        context.SaveChanges();
    }
    
    public List<ToDo> updateStatus(int id,JsonObject request)
    {
        using var context = new ToDoContext();
        i++;
        var taskName = (string)request["taskName"];
        var toDo = context.ToDoList.Single(x => x.TaskName == taskName && x.Id==id);
        var status =
        toDo.IsDone = (bool)request["isDone"];;
        context.SaveChanges();
        var list = context.ToDoList.Where(x => x.Id == id).AsQueryable().ToList();
        return list;
    }
}