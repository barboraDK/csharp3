namespace ToDoList.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.DTOs;
using ToDoList.Domain.Models;

[ApiController]
[Route("api/[Controller]")]
public class ToDoItemsController : ControllerBase
{
    private static readonly List<ToDoItem> Items = [];
    [HttpPost]
    public IActionResult Create(ToDoItemCreateRequestDto request)
    {
        try
        {
            var item = request.ToDomain();
            item.ToDoItemId = Items.Count == 0 ? 1 : Items.Max(o => o.ToDoItemId) + 1;
            Items.Add(item);

        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError);
        }
        return Created();
    }

    [HttpGet]
    public IActionResult Read()
    {
        try
        {
            return Ok(Items);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("{toDoItemId:int}")]
    public IActionResult ReadById(int toDoItemId)
    {
        try
        {
            var item = Items.FirstOrDefault(i => i.ToDoItemId == toDoItemId);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPut("{toDoItemId:int}")]
    public IActionResult UpdateById(int toDoItemId, [FromBody] ToDoItemUpdateRequestDto request)
    {
        var existingProduct = Items.FirstOrDefault(item => item.ToDoItemId == toDoItemId);
        if (existingProduct == null)
        {
            return NotFound();
        }

        try
        {
            existingProduct.Name = request.Name;
            existingProduct.Description = request.Description;
            existingProduct.IsCompleted = request.IsCompleted;
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError);
        }

        return NoContent();
    }

    [HttpDelete("{toDoItemId:int}")]
    public IActionResult DeleteById(int toDoItemId)
    {
        try
        {
            var item = Items.FirstOrDefault(i => i.ToDoItemId == toDoItemId);
            if (item == null)
            {
                return NotFound();
            }

            Items.Remove(item);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError);

        }
        return NoContent();
    }
}
