using Moq;
using Moq.Protected;
using Newtonsoft.Json;

namespace TestProject.Helpers;  

internal static class MockHttpMessageHandler<T> 
{
    internal static Mock<HttpMessageHandler> SetupBasicGetResourceList(List<T> expectedResponse)
    {
        var mockRes = new HttpResponseMessage(System.Net.HttpStatusCode.OK) 
        { 
            Content = new StringContent(JsonConvert.SerializeObject(expectedResponse))
        };
        mockRes.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");


        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock.Protected().Setup<Task<HttpResponseMessage>>("SendAsync",
            ItExpr.IsAny<Task<HttpResponseMessage>>(),
            ItExpr.IsAny<Task<CancellationToken>>())
            .ReturnsAsync(mockRes);

        return handlerMock;
    }
}
