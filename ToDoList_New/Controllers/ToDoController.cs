using Microsoft.AspNetCore.Mvc;
using ToDoList_New.Models;

namespace ToDoList_New.Controllers;

[Route("[controller]/[action]")]
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
        return Ok(_toDoRepository.GetToDoList());
    }
    
    [HttpGet("{isDone}")]
    public ActionResult<List<ToDo>> Get(bool isDone)
    {
        var bools = _toDoRepository.GetToDoList().Select(x => x.IsDone = isDone).AsQueryable().ToList();
        return Ok(bools);
        
    }
    
    [HttpPost]
    public ActionResult<List<ToDo>> Add(string taskName)
    {
        return Ok(_toDoRepository.AddToDoList(taskName));
        // return Ok(_toDoRepository.GetToDoList());
    }
    
    

}