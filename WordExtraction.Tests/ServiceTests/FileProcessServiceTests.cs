using Moq;
using WordExtraction.Services.FileProcessService;
using WordExtraction.Services.ReadStrategy;

namespace WordExtraction.Tests.ServiceTests;

public class FileProcessServiceTests
{
    [Fact]
    public void SetTypeRead_SetValueToProperty()
    {
        var translateServiceMock = new Mock<IFileProcessService>();

        var fileProcessService = SetupMockForSetTypeRead(translateServiceMock);

        fileProcessService.SetTypeRead(new PdfRead());

        translateServiceMock.VerifyAll();
    }

    private IFileProcessService SetupMockForSetTypeRead(Mock<IFileProcessService> fileProcessServiceMock)
    {
        fileProcessServiceMock
            .Setup(f => f.SetTypeRead(It.IsAny<ITypeRead>()))
            .Verifiable(Times.Once);

        return fileProcessServiceMock.Object;
    }
}