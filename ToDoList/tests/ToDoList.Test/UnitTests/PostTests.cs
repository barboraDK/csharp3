namespace ToDoList.Test;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using ToDoList.WebApi.Controllers;
using ToDoList.Domain.DTOs;
using Microsoft.AspNetCore.Http;
using ToDoList.Persistence.Repositories;
using NSubstitute;
using ToDoList.Domain.Models;
using Xunit.Sdk;

public class PostUnitTests
{
    [Fact]
    public async Task Post_ValidRequest_ReturnsOkResult()
    {
        /*
        // Arrange
        var repositoryMock = Substitute.For<IRepository<ToDoItem>>();
        var controller = new ToDoItemsController(repositoryMock);
        var request = new ToDoItemCreateRequestDto("Test Name", "Test Description", false);
        repositoryMock.When(r => r.Create(Arg.Any<ToDoItem>())).Do(r => throw new Exception());

        // Act
        var result = controller.Create(request);

        // Assert
        var createdResult = Assert.IsType<ActionResult<ToDoItemGetResponseDto>>(result);
        */

    }

}

