using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using WordExtraction.Controllers;

namespace WordExtraction.Tests.Controllers;

public class HomeControllerTests
{
    [Fact]
    public void Index_ActionExecutes_ReturnsViewForIndex()
    {
        var logger = new Mock<ILogger<HomeController>>(MockBehavior.Strict).Object;
        var result = new HomeController(logger).Index();

        result.Should().BeOfType<ViewResult>();
    }

    [Fact]
    public void Privacy_ActionExecutes_ReturnsViewForPrivacy()
    {
        var logger = new Mock<ILogger<HomeController>>(MockBehavior.Strict).Object;
        var result = new HomeController(logger).Privacy();

        result.Should().BeOfType<ViewResult>();
    }
}