using Moq;
using FluentAssertions;
using WordExtraction.Services;
using FluentAssertions.Execution;

namespace WordExtraction.Tests.Services;

public class TranslateServiceTests
{
    private readonly IHttpClientFactory _httpClientFactory = new Mock<IHttpClientFactory>(MockBehavior.Strict).Object;

    [Fact]
    public async Task GetApiKey_WithValidPathToFile_ReturnApiKeyReadFromFile()
    {
        var translateService = new TranslateService(_httpClientFactory);

        var solutionPath = Directory.GetParent(Environment.CurrentDirectory)?.Parent?.Parent?.Parent?.FullName;

        var apiKey = await translateService.GetApiKey(solutionPath);

        apiKey.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GetApiKey_WithInvalidPathToFile_ReturnFileNotFoundException()
    {
        var translateService = new TranslateService(_httpClientFactory);

        var solutionPath = Directory.GetParent(Environment.CurrentDirectory)?.Parent?.Parent?.FullName;

        Func<Task> act = async () => await translateService.GetApiKey(solutionPath);

        act.Should().ThrowAsync<FileNotFoundException>();
    }

    [Fact]
    public void CreateHttpClient_WithValidHttpClientFactory_ShouldReturnHttpClientInstance()
    {
        var factoryMock = new Mock<IHttpClientFactory>(MockBehavior.Strict);
        var expectedClient = new HttpClient();
        factoryMock.Setup(f => f.CreateClient(It.IsAny<string>())).Returns(expectedClient);
        var translateService = new TranslateService(factoryMock.Object);

        var httpClient = translateService.CreateHttpClient(factoryMock.Object);

        using (new AssertionScope())
        {
            httpClient.Should().BeOfType<HttpClient>();
            httpClient.Should().NotBeNull();
            factoryMock.Verify(f => f.CreateClient(It.IsAny<string>()), Times.Once);
        }
    }
}