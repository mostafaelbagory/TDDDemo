using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.Protected;
using TDDDemo.Controllers;
using TDDDemo.Models;
using TDDDemo.Services;
using TestProject.Fixture;
using TestProject.Helpers;

namespace TestProject.Systems.Controllers;

public class TestUserService
{
    //[Fact]
    //public async Task GetAllUsers_WhenCalled_InvokesHttpGetRequest()
    //{
     
    //    //Arrange
    //    var expectedResponse = UserFixture.GetTestUsers();
    //    var handlerMock = MockHttpMessageHandler<User>.SetupBasicGetResourceList(expectedResponse);
    //    var httpClient = new HttpClient(handlerMock.Object);
    //    var sut = new UserService(httpClient);
    //    //Act
    //    var result =  await sut.GetAllUsers();
    //    //Assert
    //    handlerMock
    //        .Protected()
    //        .Verify(
    //        "SendAsync",
    //        Times.Exactly(1),
    //        ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get),
    //        ItExpr.IsAny<CancellationToken>());
    //}
    [Fact]
    public async Task GetAllUsers_WhenCalled_ReturnsListOfUsers()
    {
     
        //Arrange
        var expectedResponse = UserFixture.GetTestUsers();
        var handlerMock = MockHttpMessageHandler<User>.SetupBasicGetResourceList(expectedResponse);
        var httpClient = new HttpClient(handlerMock.Object);
        var sut = new UserService(httpClient);
        //Act
        var result =  await sut.GetAllUsers();
        //Assert
        result.Should().BeOfType<List<User>>();
    }

}