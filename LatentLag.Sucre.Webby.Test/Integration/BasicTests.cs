using System.Net;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc.Testing;

[TestClass]
public class BasicTests
{
    private static WebApplicationFactory<Program> _factory = null!;

    [ClassInitialize]
    public static void AssemblyInitialize(TestContext _)
    {
        _factory = new WebApplicationFactory<Program>();
    }

    [ClassCleanup]
    public static void AssemblyCleanup(TestContext _)
    {
        _factory.Dispose();
    }

    [TestMethod]
    [DataRow("/coffee", "POST")]
    [DataRow("/coffee", "BREW")]
    public async Task EnsureServiceIsATeapot(string url, string method)
    {
        // Arrange
        var client = _factory.CreateClient();


        // Act
        var response = await client.SendAsync(new HttpRequestMessage
        {
            Content = new StringContent(string.Empty),
            Method = new HttpMethod(method),
            RequestUri = new Uri(url),
        });
        

        // Assert
        Assert.AreEqual((HttpStatusCode)418, response.StatusCode);
        Assert.AreEqual("text/plain; charset=utf-8",
            response.Content.Headers.ContentType?.ToString());
        Assert.AreEqual("I'm a teapot", response.Content.ReadAsStringAsync().Result);
    }
}
