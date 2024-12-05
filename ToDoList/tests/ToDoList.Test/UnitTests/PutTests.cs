namespace ToDoList.Test.UnitTests;

using NSubstitute;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.DTOs;
using ToDoList.WebApi.Controllers;
using ToDoList.Persistence.Repositories;
using ToDoList.Domain.Models;
using Microsoft.AspNetCore.Http;
using NSubstitute.ReturnsExtensions;
/*
public class PutUnitTests
{
    [Fact]
    public void Put_UpdateByIdWhenItemUpdated_ReturnsNoContent()
    {
        // Arrange
        var repositoryMock = Substitute.For<IRepositoryAsync<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);
        var request = new ToDoItemUpdateRequestDto(
            Name: "Jmeno",
            Description: "Popis",
            IsCompleted: false,
            Category: null
        );
        var someId = 1;
        var readToDoItem = new ToDoItem { Name = "Jmeno", Description = "Popis", IsCompleted = false, ToDoItemId = someId };
        repositoryMock.ReadById(someId).Returns(readToDoItem);

        // Act
        var result = controller.UpdateById(someId, request);

        // Assert
        Assert.IsType<NoContentResult>(result);
        repositoryMock.Received(1).ReadById(someId);
        repositoryMock.Received(1).UpdateById(someId, Arg.Any<ToDoItem>());
    }

    [Fact]
    public void Put_UpdateByIdWhenIdNotFound_ReturnsNotFound()
    {
        // Arrange
        var repositoryMock = Substitute.For<IRepositoryAsync<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);
        var request = new ToDoItemUpdateRequestDto(
            Name: "Jmeno",
            Description: "Popis",
            IsCompleted: false,
            Category: null
        );
        repositoryMock.ReadById(Arg.Any<int>()).ReturnsNull();
        var someId = 1;

        // Act
        var result = controller.UpdateById(someId, request);

        // Assert
        Assert.IsType<NotFoundResult>(result);
        repositoryMock.Received(1).ReadById(someId);
    }

    [Fact]
    public void Put_UpdateByIdUnhandledException_ReturnsInternalServerError()
    {
        // Arrange
        var repositoryMock = Substitute.For<IRepositoryAsync<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);
        var request = new ToDoItemUpdateRequestDto(
            Name: "Jmeno",
            Description: "Popis",
            IsCompleted: false,
            Category: null
        );
        var someId = 1;
        var readToDoItem = new ToDoItem { Name = "Jmeno", Description = "Popis", IsCompleted = false, ToDoItemId = someId };

        repositoryMock.ReadById(Arg.Any<int>()).Returns(readToDoItem);
        repositoryMock.When(r => r.UpdateById(someId, Arg.Any<ToDoItem>())).Do(r => throw new Exception());

        // Act
        var result = controller.UpdateById(someId, request);

        // Assert
        Assert.IsType<ObjectResult>(result);
        Assert.Equivalent(new StatusCodeResult(StatusCodes.Status500InternalServerError), result);
    }
}
*/
