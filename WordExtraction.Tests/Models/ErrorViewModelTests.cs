using FluentAssertions;
using FluentAssertions.Execution;
using WordExtraction.Models;

namespace WordExtraction.Tests.Models;

public class ErrorViewModelTests
{
    [Theory]
    [InlineData("sd")]
    [InlineData("2341223")]
    [InlineData("$#%*#$is")]
    [InlineData(" ")]
    public void Properties_WithNotNullArguments_Succeeds(string? requestId)
    {
        var errorViewModel = Setup();

        errorViewModel.RequestId = requestId;

        using (new AssertionScope())
        {
            errorViewModel.RequestId.Should().Be(requestId);
            errorViewModel.ShowRequestId.Should().BeTrue();
        }
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void Properties_WithNullArguments_Succeeds(string? requestId)
    {
        var errorViewModel = Setup();

        errorViewModel.RequestId = requestId;

        using (new AssertionScope())
        {
            errorViewModel.RequestId.Should().Be(requestId);
            errorViewModel.ShowRequestId.Should().BeFalse();
        }
    }

    private ErrorViewModel Setup() => new();
}