namespace ToDoList.Test;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.WebApi.Controllers;
using ToDoList.Domain.Models;

public class DeleteTests
{
    public static void PrepareItems()
    {
        ToDoItemsController.items.Clear();
        ToDoItemsController.items.Add(new ToDoItem { ToDoItemId = 1, Name = "Item 1", Description = "First Item", IsCompleted = false });
    }

    [Fact]
    public void DeleteById_ReturnsNoContent_WhenDeleteIsSuccessful()
    {
        // Arrange
        var controller = new ToDoItemsController();
        PrepareItems();

        // Act
        var result = controller.DeleteById(1);

        // Assert
        //test failuje protoze v kontroler vraci Ok, ale test je v poradku, to je chyba v kontroleru
        var noContentResult = Assert.IsType<NoContentResult>(result);
        Assert.Equal(StatusCodes.Status204NoContent, noContentResult.StatusCode);
        var deletedItem = ToDoItemsController.items.FirstOrDefault(i => i.ToDoItemId == 1);
        Assert.Null(deletedItem);
    }

    [Fact]
    public void DeleteById_ReturnsNotFound_WhenItemDoesNotExist()
    {
        // Arrange
        var controller = new ToDoItemsController();

        // Act
        var result = controller.DeleteById(999);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }
}
