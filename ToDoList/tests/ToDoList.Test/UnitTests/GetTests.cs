namespace ToDoList.Test.UnitTests;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;
using ToDoList.Domain.Models;
using ToDoList.Persistence.Repositories;
using ToDoList.WebApi.Controllers;


public class GetUnitTests
{
    [Fact]
    public async Task Get_ReadAllAndSomeItemIsAvailable_ReturnsOk()
    {
        //Arrange
        var repositoryMock = Substitute.For<IRepositoryAsync<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);
        /*
        repositoryMock.When().Do();
        repositoryMock.Read().Returns();
        repositoryMock.Read().Throws();
        repositoryMock.Received().Read();
        */
        repositoryMock.Read().Returns(
            [
                new ToDoItem {
                    Name = "testName",
                    Description = "testDescription",
                    IsCompleted = false
                    }
                ]
                );


        //Act
        var result = await controller.Read();
        var resultResult = result.Result;

        //Assert
        Assert.IsType<OkObjectResult>(resultResult);
        repositoryMock.Received(1).Read();
    }

    [Fact]
    public async Task Get_ReadAllNoItemAvailable_ReturnNotFound()
    {
        //Arrange
        var repositoryMock = Substitute.For<IRepositoryAsync<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);
        repositoryMock.Read().ReturnsNull();

        //Act
        var result = await controller.Read();
        var resultResult = result.Result;

        //Assert
        Assert.IsType<NotFoundResult>(resultResult);
        repositoryMock.Received(1).Read();
        Assert.Equivalent(new StatusCodeResult(StatusCodes.Status404NotFound), resultResult);
    }

    [Fact]
    public async Task Get_ReadAllExceptionOccured_ReturnInternalServerError()
    {
        //Arrange
        var repositoryMock = Substitute.For<IRepositoryAsync<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);
        repositoryMock.Read().Throws(new Exception());

        //Act
        var result = await controller.Read();
        var resultResult = result.Result;

        //Assert
        Assert.IsType<ObjectResult>(resultResult);
        repositoryMock.Received(1).Read();
        Assert.Equivalent(new StatusCodeResult(StatusCodes.Status500InternalServerError), resultResult);
    }

}

