namespace ToDoList.Test.UnitTests;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;
using ToDoList.Domain.Models;
using ToDoList.Persistence.Repositories;
using ToDoList.WebApi.Controllers;


public class DeleteByIdTests
{
    [Fact]
    public async Task Delete_ValidItemId_ReturnsNoContent()
    {
        //Arrange
        var repositoryMock = Substitute.For<IRepositoryAsync<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);
        var item = new ToDoItem
        {
            Name = "testName",
            Description = "testDescription",
            IsCompleted = false
        };
        repositoryMock.DeleteById(Arg.Any<int>()).Returns(item);


        //Act
        var result = await controller.DeleteById(item.ToDoItemId);

        //Assert
        Assert.IsType<NoContentResult>(result);
        repositoryMock.Received(1).DeleteById(item.ToDoItemId);
    }
}

