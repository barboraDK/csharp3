namespace ToDoList.Test;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.DTOs;
using ToDoList.WebApi.Controllers;
using ToDoList.Domain.Models;

public class PutTests
{
    private static void PrepareItems()
    {
        ToDoItemsController.items.Clear();
        ToDoItemsController.items.Add(new ToDoItem { ToDoItemId = 1, Name = "Item 1", Description = "First Item", IsCompleted = false });
        ToDoItemsController.items.Add(new ToDoItem { ToDoItemId = 2, Name = "Item 2", Description = "Second Item", IsCompleted = false });
    }

    [Fact]
    public void UpdateById_ReturnsOkResult_WhenUpdateIsSuccessful()
    {
        // Arrange
        var controller = new ToDoItemsController();
        PrepareItems();
        var request = new ToDoItemUpdateRequestDto("Test ToDo", "Test Description", false);

        // Act
        var result = controller.UpdateById(1, request);

        // Assert
        var okResult = Assert.IsType<OkResult>(result);
        Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
    }

    [Fact]
    public void UpdateById_ReturnsNotFound_WhenItemDoesNotExist()
    {
        // Arrange
        var controller = new ToDoItemsController();
        var request = new ToDoItemUpdateRequestDto("Test ToDo", "Test Description", false);

        // Act
        var result = controller.UpdateById(999, request);

        // Assert
        var notFoundResult = Assert.IsType<NotFoundResult>(result);
        Assert.Equal(StatusCodes.Status404NotFound, notFoundResult.StatusCode);
    }
}
