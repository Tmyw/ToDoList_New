using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Mvc;

namespace ToDoList_New.Models;

public interface IToDoRepository
{
    public List<ToDo> GetToDoList();
    public void AddToDoList(ToDo toDo);
    public Task<ActionResult> UpdateStatus(int id, ToDo toDo);
    public void Remove(int id);
    public bool Validate(int id);
}