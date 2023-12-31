using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TDDDemo.Controllers;
using TDDDemo.Models;
using TDDDemo.Services;
using TestProject.Fixture;

namespace TestProject.Systems.Controllers;

public class TestUserController
{
    [Fact]
    public async Task Get_OnSuccess_ReturnsStatus200()
    {
        var mockUserService = new Mock<IUserService>();
        //mockUserService
        //    .Setup(service => service.GetAllUsers())
        //    .ReturnsAsync(new List<User>());
        //Arrange
        var sut = new UsersController(mockUserService.Object);
        //Act
        var result = (OkObjectResult)await sut.Get();
        //Assert
        result.StatusCode.Should().Be(200);
    }
    [Fact]
    public async Task Get_OnSuccess_InvokeService()
    {
        //arrange
        var mockUserService = new Mock<IUserService>();
        mockUserService
            .Setup(service => service.GetAllUsers())
            .ReturnsAsync(new List<User>());
        var sut = new UsersController(mockUserService.Object);

        //act
        var result = await sut.Get();

        // Assert
        mockUserService.Verify(service => service.GetAllUsers(), Times.Once());
    }
    [Fact]
    public async Task Get_OnSuccess_ReturnListOfUsers()
    {
        //arrange
        var mockUserService = new Mock<IUserService>();
        mockUserService
            .Setup(service => service.GetAllUsers())
            .ReturnsAsync(UserFixture.GetTestUsers());
        var sut = new UsersController(mockUserService.Object);

        //act
        var result = await sut.Get();

        //asert
        result.Should().BeOfType<OkObjectResult>();
        var objResult = (OkObjectResult)result;
        objResult.Value.Should().BeOfType<List<User>>();  
    }
    [Fact]
    public async Task Get_OnNoUsersFound_ReturnNotFound()
    {
        //arrange
        var mockUserService = new Mock<IUserService>();
        mockUserService
            .Setup(service => service.GetAllUsers())
            .ReturnsAsync(new List<User>());
        var sut = new UsersController(mockUserService.Object);

        //act
        var result = await sut.Get();
        //asert
        result.Should().BeOfType<NotFoundResult>();
    }
}