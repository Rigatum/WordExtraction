using System.Net;
using FluentAssertions.Execution;
using Moq;
using Moq.Protected;
using WordExtraction.Services.FileSystemService;
using WordExtraction.Services.StringContentConverter;
using WordExtraction.Services.TranslateService;

namespace WordExtraction.Tests.ServiceTests;

public class TranslateServiceTests
{
    [Fact]
    public async Task TranslateServiceConstructorWithDI()
    {
        var words = new List<string> { "корабль", "карта", "монитор" };
        var sourceLanguage = "ru";
        var targetLanguage = "en";

        var (translateService, httpClientFactoryMock, fileSystemServiceMock, stringContentConverterServiceMock) = SetupMocks();

        _ = await translateService.TranslateViaYandexByHttpAsync(words, sourceLanguage, targetLanguage);

        using (new AssertionScope())
        {
            httpClientFactoryMock.VerifyAll();
            fileSystemServiceMock.VerifyAll();
            stringContentConverterServiceMock.VerifyAll();
        }
    }

    private (TranslateService, Mock<IHttpClientFactory>, Mock<IFileSystemService>, Mock<IStringContentConverterService>) SetupMocks()
    {
        var httpClientFactoryMock = new Mock<IHttpClientFactory>(MockBehavior.Strict);
        var fileSystemServiceMock = new Mock<IFileSystemService>(MockBehavior.Strict);
        var stringContentConverterServiceMock = new Mock<IStringContentConverterService>(MockBehavior.Strict);

        var mockHttpMessageHandler = new Mock<HttpMessageHandler>();

        mockHttpMessageHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", 
                ItExpr.IsAny<HttpRequestMessage>(), 
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage { StatusCode = HttpStatusCode.OK });

        httpClientFactoryMock?
            .Setup(m => m.CreateClient(It.IsAny<string>()))
            .Returns(new HttpClient(mockHttpMessageHandler.Object))
            .Verifiable(Times.Once);

        fileSystemServiceMock?
            .Setup(f => f.GetSolutionPath())
            .Returns("")
            .Verifiable(Times.Once);

        fileSystemServiceMock?
            .Setup(f => f.GetContentFromFile(It.IsAny<string>()))
            .Returns(Task.FromResult(""))
            .Verifiable(Times.Once);

        stringContentConverterServiceMock?.Setup(s =>
            s.Convert(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<List<string>>()))
            .Returns(Task.FromResult(new StringContent("")))
            .Verifiable(Times.Once);

        return (new(httpClientFactoryMock?.Object!, fileSystemServiceMock?.Object!, stringContentConverterServiceMock?.Object!),
            httpClientFactoryMock, fileSystemServiceMock, stringContentConverterServiceMock)!;

    }
}