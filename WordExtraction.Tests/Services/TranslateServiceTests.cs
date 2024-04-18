using Moq;
using WordExtraction.Services;

namespace WordExtraction.Tests.Services;

public class TranslateServiceTests
{
    private readonly IHttpClientFactory _httpClientFactory = new Mock<IHttpClientFactory>(MockBehavior.Strict).Object;

    [Fact]
    public void GetApiKey_WhenFileWithApiKeyExist_IsNotNullOrWhiteSpace()
    {
        var translateService = new TranslateService(_httpClientFactory);

        var solutionPath = Directory.GetParent(Environment.CurrentDirectory)?.Parent?.Parent?.Parent?.FullName;

        var apiKey = translateService.GetApiKey(solutionPath).Result;

        Assert.False(string.IsNullOrWhiteSpace(apiKey));
    }
}