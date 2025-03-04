using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;
using TaskManagementServer.DAL;
using TaskManagementServer.Models;


namespace TaskManagementServer.Controllers;

[Route("api/tasks")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly TaskDAL _TaskDAL;

    public TaskController()
    {
        _TaskDAL = new TaskDAL();
    }

    // Get all tasks
    [HttpGet]
    public ActionResult<List<TaskModel>> GetTasks()
    {
        return Ok(_TaskDAL.GetAllTasks());
    }

    // Get task by ID
    [HttpGet("{id}")]
    public ActionResult<TaskModel> GetTask(int id)
    {
        var task = _TaskDAL.GetTaskById(id);
        if (task == null) return NotFound("Task not found");
        return Ok(task);
    }

    // Add a new task
    [HttpPost]
    public ActionResult AddTask([FromBody] TaskModel task)
    {
        _TaskDAL.AddTask(task);
        return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
    }

    // Update a task
    [HttpPut("{id}")]
    public ActionResult UpdateTask(int id, [FromBody] TaskModel updatedTask)
    {
        if (!_TaskDAL.UpdateTask(id, updatedTask)) return NotFound("Task not found");
        return NoContent();
    }

    // Delete a task
    [HttpDelete("{id}")]
    public ActionResult DeleteTask(int id)
    {
        if (!_TaskDAL.DeleteTask(id)) return NotFound("Task not found");
        return NoContent();
    }
}

