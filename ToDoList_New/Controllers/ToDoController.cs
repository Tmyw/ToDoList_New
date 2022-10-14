using System.Net;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
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
        var addToDoList = _toDoRepository.AddToDoList(toDO);

        return Ok(addToDoList.Result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] ToDo toDo)
    {
        var updateToDo = _toDoRepository.UpdateStatus(id, toDo);
        return Accepted("");
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        if (!_toDoRepository.Validate(id))
        {
            return NotFound("");
        }

        _toDoRepository.Remove(id);
        return NoContent();
    }
}