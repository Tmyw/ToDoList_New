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
        return Ok(_toDoRepository.getToDoList());
    }

    [HttpGet("{isDone}")]
    public ActionResult<List<ToDo>> GetWithStatus(bool isDone)
    {
        var list = _toDoRepository.getToDoList().Where(x => x.IsDone == isDone).ToList();
        return Ok(list);
    }

    [HttpPost]
    public ActionResult<List<ToDo>> Add([FromBody] ToDo toDO)
    {
        _toDoRepository.addToDoList(toDO);
        return RedirectToAction("Get");
    }

    [HttpPut("{id}")]
    public ActionResult<List<ToDo>> edit(int id, JsonObject request)
    {
        var list = _toDoRepository.updateStatus(id, request);
        return list;
    }
}