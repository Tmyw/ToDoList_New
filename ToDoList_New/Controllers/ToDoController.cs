using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Mvc;
using ToDoList_New.Models;

namespace ToDoList_New.Controllers;

[Route("[controller]")]
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
    public ActionResult<List<ToDo>> GetWithStatus(bool isDone)
    {
        var list = _toDoRepository.GetToDoList().Where(x => x.IsDone == isDone).ToList();
        return Ok(list);
    }

    [HttpPost]
    public ActionResult<List<ToDo>> Add([FromBody] ToDo toDO)
    {
        _toDoRepository.AddToDoList(toDO);
        return RedirectToAction("Get");
    }

    [HttpPut("{id}")]
    public ActionResult<List<ToDo>> edit(int id, [FromBody] ToDo toDO)
    {
        var list = _toDoRepository.UpdateStatus(id, toDO);
        return Ok(list);
    }
    
    [HttpPut("{id}")]
    public void delete(int id)
    {
        _toDoRepository.Remove(id);
    }
}