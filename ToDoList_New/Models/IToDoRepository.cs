using System.Text.Json.Nodes;

namespace ToDoList_New.Models;

public interface IToDoRepository
{
    public List<ToDo> getToDoList();
    public void addToDoList(JsonObject request);
    public List<ToDo> updateStatus(int id, JsonObject request);
}