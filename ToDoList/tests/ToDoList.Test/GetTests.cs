namespace ToDoList.Test;

using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.Models;
using ToDoList.WebApi.Controllers;
using Microsoft.AspNetCore.Http;
using ToDoList.Domain.DTOs;


public class GetTests
{
    [Fact]
    public void Get_AllItems_ReturnsAllItems()
    {
        // Arrange
        var controller = new ToDoItemsController();
        var toDoItem1 = new ToDoItem { ToDoItemId = 1, Name = "Task 1", Description = "Description 1", IsCompleted = false };
        var toDoItem2 = new ToDoItem { ToDoItemId = 2, Name = "Task 2", Description = "Description 2", IsCompleted = true };
        ToDoItemsController.items.Add(toDoItem1);
        ToDoItemsController.items.Add(toDoItem2);

        // Act
        var result = controller.Read();
        var okResult = Assert.IsType<OkObjectResult>(result); //toto uz patri pod Assert
        var value = Assert.IsAssignableFrom<IEnumerable<ToDoItemGetResponseDto>>(okResult.Value); //toto uz patri pod Assert


        //Tomuto rikam robustni test :) palec nahoru
        // Assert
        Assert.Equal(2, value.Count());
        var itemList = value.ToList();
        Assert.Equal(toDoItem1.ToDoItemId, itemList[0].Id);
        Assert.Equal(toDoItem1.Name, itemList[0].Name);
        Assert.Equal(toDoItem1.Description, itemList[0].Description);
        Assert.Equal(toDoItem1.IsCompleted, itemList[0].IsCompleted);

        Assert.Equal(toDoItem2.ToDoItemId, itemList[1].Id);
        Assert.Equal(toDoItem2.Name, itemList[1].Name);
        Assert.Equal(toDoItem2.Description, itemList[1].Description);
        Assert.Equal(toDoItem2.IsCompleted, itemList[1].IsCompleted);

    }

    [Fact]
    public void Get_NoItmes_ReturnsNotFound() //preklep ve jmenu :)
    {
        // Arrange
        var controller = new ToDoItemsController();
        ToDoItemsController.items.Clear();

        // Act
        var result = controller.Read();

        // Assert
        var notFoundResult = Assert.IsType<NotFoundResult>(result);
        Assert.NotNull(notFoundResult);
        Assert.Equal(StatusCodes.Status404NotFound, notFoundResult.StatusCode);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    public void GetById_ReturnsOkResult_WithItem(int id) //GetById je samostatna metoda - Get a GetById, chtelo by to podle me samostatny soubor
    {
        // Arrange
        var controller = new ToDoItemsController();
        ToDoItemsController.items.Clear();
        ToDoItemsController.items.Add(new ToDoItem { ToDoItemId = 1, Name = "Item 1", Description = "First Item", IsCompleted = false });
        ToDoItemsController.items.Add(new ToDoItem { ToDoItemId = 2, Name = "Item 2", Description = "Second Item", IsCompleted = false });

        // Act
        var result = controller.ReadById(id) as OkObjectResult;

        // Assert
        var item = Assert.IsType<ToDoItemGetResponseDto>(result.Value);
        Assert.NotNull(result);
        Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        Assert.Equal(id, item.Id);

        //tady by taky stalo za to otestovat ze jsme dostali nezmenene Name, Description, IsCompleted jak jsi to delala v Get_AllItems_ReturnsAllItems testu
    }

    [Fact]
    public void GetById_ReturnsNotFound_WhenItemDoesNotExist() //GetById je samostatna metoda - Get a GetById, chtelo by to podle me samostatny soubor
    {
        // Arrange
        var controller = new ToDoItemsController();
        ToDoItemsController.items.Clear();

        // Act
        var result = controller.ReadById(999);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }
}
