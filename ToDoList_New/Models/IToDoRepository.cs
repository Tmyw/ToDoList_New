using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Mvc;

namespace ToDoList_New.Models;

public interface IToDoRepository
{
    public List<ToDo> GetToDoList();
    public Task<ToDo> AddToDoList(ToDo toDo);
    public Task<Object> UpdateStatus(int id, ToDo toDo);
    public void Remove(int id);
    public bool Validate(int id);
}