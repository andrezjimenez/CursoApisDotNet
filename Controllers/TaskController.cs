using Microsoft.AspNetCore.Mvc;
using sss.Services;
using sss.Models;


namespace sss.Controllers;

[Route("api/[controller]")]
public class TaskController: ControllerBase
{
    ITaskService taskService;

    public TaskController (ITaskService service)
    {
        taskService = service;
    }

    [HttpGet]
    public IActionResult Get(){
        return Ok(taskService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Tarea tarea){
        taskService.Save(tarea);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id,[FromBody] Tarea tarea){

        taskService.Update(id,tarea);
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id){

        taskService.Delete(id);
        return Ok();
    }

}