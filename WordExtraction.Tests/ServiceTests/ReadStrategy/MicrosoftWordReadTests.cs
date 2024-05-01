using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Moq;
using WordExtraction.Services.ReadStrategy;

namespace WordExtraction.Tests.ServiceTests.ReadStrategy;

public class MicrosoftWordReadTests
{
    [Fact]
    public void ReadAsync_NotImplemented_ShouldThrowNotImplementedException()
    {
        var microsoftWordRead = new MicrosoftWordRead();
        var formFile = SetupMock();

        Action act = () => microsoftWordRead.ReadAsync(formFile);

        act.Should().Throw<NotImplementedException>();
    }

    private IFormFile SetupMock() => new Mock<IFormFile>(MockBehavior.Strict).Object;
}