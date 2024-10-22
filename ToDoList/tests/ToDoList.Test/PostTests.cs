namespace ToDoList.Test;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using ToDoList.WebApi.Controllers;
using ToDoList.Domain.DTOs;
using Microsoft.AspNetCore.Http;

public class PostTests
{
    [Fact]
    public void Post_ValidRequest_ReturnsOkResult()
    {
        // Arrange
        var controller = new ToDoItemsController();
        var request = new ToDoItemCreateRequestDto("Test Name", "Test Description", false);

        // Act
        var result = controller.Create(request);

        // Assert
        var createdResult = Assert.IsType<OkResult>(result);
        Assert.Equal(StatusCodes.Status200OK, createdResult.StatusCode);
    }

    [Fact]
    public void Post_MultipleItems_CreatesWithCorrectId()
    {
        // Arrange
        var controller = new ToDoItemsController();
        var firstRequest = new ToDoItemCreateRequestDto("First Item", "First Description", false);
        var secondRequest = new ToDoItemCreateRequestDto("Second Item", "Second Description", false);

        // Act
        controller.Create(firstRequest);
        controller.Create(secondRequest);

        // Assert
        Assert.Equal(2, ToDoItemsController.items.Count);
        Assert.Equal(1, ToDoItemsController.items[0].ToDoItemId);
        Assert.Equal(2, ToDoItemsController.items[1].ToDoItemId);
    }

}
