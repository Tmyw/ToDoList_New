using System.Text.Json.Nodes;

namespace ToDoList_New.Models;

public interface IToDoRepository
{
    public List<ToDo> GetToDoList();
    public void AddToDoList(ToDo toDo);
    public object UpdateStatus(int id, ToDo toDo);
    public void Remove(int id);
}