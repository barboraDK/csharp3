namespace ToDoList.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.DTOs;
using ToDoList.Domain.Models;
using ToDoList.Persistence;

[ApiController]
[Route("api/[Controller]")]
public class ToDoItemsController : ControllerBase
{
    private readonly ToDoItemsContext context;

    public ToDoItemsController(ToDoItemsContext context)
    {
        this.context = context;
    }
    [HttpPost]
    public ActionResult<ToDoItemGetResponseDto> Create(ToDoItemCreateRequestDto request)
    {
        try
        {
            var item = request.ToDomain();
            context.ToDoItems.Add(item);
            context.SaveChanges();

        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError);
        }
        return Ok();
    }

    [HttpGet]
    public ActionResult<IEnumerable<ToDoItemGetResponseDto>> Read()
    {
        try
        {

            List<ToDoItem> itemsToSendList = context.ToDoItems.ToList();
            if (itemsToSendList.Count == 0)
            {
                return NotFound();
            }

            return Ok(itemsToSendList);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("{toDoItemId:int}")]
    public ActionResult<ToDoItemGetResponseDto> ReadById(int toDoItemId)
    {
        try
        {
            var item = context.ToDoItems.Find(toDoItemId);

            return item == null
            ? NotFound()
            : Ok(ToDoItemGetResponseDto.FromDomain(item));
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPut("{toDoItemId:int}")]
    public IActionResult UpdateById(int toDoItemId, [FromBody] ToDoItemUpdateRequestDto request)
    {
        var item = context.ToDoItems.Find(toDoItemId);
        if (item == null)
        {
            return NotFound();
        }

        try
        {
            item.Name = request.Name;
            item.Description = request.Description;
            item.IsCompleted = request.IsCompleted;
            context.SaveChanges();
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError);
        }

        return Ok();
    }

    [HttpDelete("{toDoItemId:int}")]
    public IActionResult DeleteById(int toDoItemId)
    {
        try
        {
            var item = context.ToDoItems.Find(toDoItemId);

            if (item == null)
            {
                return NotFound();
            }
            context.ToDoItems.Remove(item);
            context.SaveChanges();
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError);
        }
        return Ok();
    }
}
