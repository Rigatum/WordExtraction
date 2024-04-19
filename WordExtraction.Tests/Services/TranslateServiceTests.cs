using Moq;
using FluentAssertions;
using WordExtraction.Services;

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
}