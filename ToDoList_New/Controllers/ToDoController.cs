using Microsoft.AspNetCore.Mvc;
using ToDoList_New.Models;

namespace ToDoList_New.Controllers;

public class ToDoController : Controller
{
    private readonly IToDoRepository _toDoRepository;

    public ToDoController(IToDoRepository toDoRepository)
    {
        _toDoRepository = toDoRepository;
    }

    [HttpGet]
    public ActionResult<List<ToDo>> Get()
    {
        return View(_toDoRepository.GetToDoList());
    }
    
    [HttpPost]
    public ActionResult<List<ToDo>> Add(int id , string taskName, bool isDone)
    {
        return Ok(_toDoRepository.AddToDoList(id , taskName,  isDone));
    }

}