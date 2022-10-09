namespace ToDoList_New.Models;

public interface IToDoRepository
{
    public List<ToDo> GetToDoList();
}