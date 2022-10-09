namespace ToDoList_New.Models;

public interface IToDoRepository
{
    public List<ToDo> GetToDoList();
    public List<ToDo> AddToDoList(int id, string taskName, bool isDone);
}