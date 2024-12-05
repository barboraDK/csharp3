namespace ToDoList.Test.UnitTests;

using NSubstitute;
using Microsoft.AspNetCore.Mvc;
using ToDoList.WebApi.Controllers;
using ToDoList.Persistence.Repositories;
using ToDoList.Domain.Models;
using Microsoft.AspNetCore.Http;
using NSubstitute.ExceptionExtensions;
/*
public class DeleteUnitTests
{
    [Fact]
    public void Delete_DeleteByIdValidItemId_ReturnsNoContent()
    {
        // Arrange
        var repositoryMock = Substitute.For<IRepositoryAsync<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);
        repositoryMock.ReadById(Arg.Any<int>()).Returns(new ToDoItem { Name = "testItem", Description = "testDescription", IsCompleted = false });
        var someId = 1;

        // Act
        var result = controller.DeleteById(someId);

        // Assert
        Assert.IsType<NoContentResult>(result);
        repositoryMock.Received(1).ReadById(someId);
        repositoryMock.Received(1).DeleteById(someId);
    }

    [Fact]
    public void Delete_DeleteByIdInvalidItemId_ReturnsNotFound()
    {
        // Arrange
        var repositoryMock = Substitute.For<IRepositoryAsync<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);
        repositoryMock.ReadById(Arg.Any<int>()).Returns(null as ToDoItem);
        var someId = 1;

        // Act
        var result = controller.DeleteById(someId);

        // Assert
        Assert.IsType<NotFoundResult>(result);
        repositoryMock.Received(1).ReadById(someId);
        repositoryMock.Received(0).DeleteById(Arg.Any<int>()); // make sure nothing was deleted
    }

    [Fact]
    public async Task Delete_DeleteByIdExceptionOccurredDuringRepositoryReadById_ReturnsInternalServerError()
    {
        // Arrange
        var repositoryMock = Substitute.For<IRepositoryAsync<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);
        repositoryMock.ReadById(Arg.Any<int>()).Throws(new Exception());
        var someId = 1;

        // Act
        var result = await controller.DeleteById(someId);

        // Assert
        Assert.IsType<ObjectResult>(result);
        repositoryMock.Received(1).ReadById(someId);
        Assert.Equal(StatusCodes.Status500InternalServerError, ((ObjectResult)result).StatusCode);
    }

    [Fact]
    public async Task Delete_DeleteByIdExceptionOccurredDuringRepositoryDelete_ReturnsInternalServerError()
    {
        // Arrange
        var repositoryMock = Substitute.For<IRepositoryAsync<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);
        repositoryMock.ReadById(Arg.Any<int>()).Returns(new ToDoItem { Name = "testItem", Description = "testDescription", IsCompleted = false });
        repositoryMock.When(r => r.DeleteById(Arg.Any<int>())).Do(r => throw new Exception());
        var someId = 1;

        // Act
        var result = await controller.DeleteById(someId);

        // Assert
        Assert.IsType<ObjectResult>(result);
        repositoryMock.Received(1).ReadById(someId);
        repositoryMock.Received(1).DeleteById(someId);
        Assert.Equal(StatusCodes.Status500InternalServerError, ((ObjectResult)result).StatusCode);
    }
}
*/