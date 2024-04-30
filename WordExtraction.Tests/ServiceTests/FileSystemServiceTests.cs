using FluentAssertions;
using WordExtraction.Services.FileSystemService;

namespace WordExtraction.Tests.ServiceTests;

public class FileSystemServiceTests
{
    [Fact]
    public async Task GetContentFromFile_WithValidPathToFile_ReturnApiKeyReadFromFile()
    {
        FileSystemService fileSystemService = Setup();

        var correctPathToFile =
            $"{Directory.GetParent(Environment.CurrentDirectory)?.Parent?.Parent?.Parent?.FullName}/test.env";

        var apiKey = await fileSystemService.GetContentFromFile(correctPathToFile);

        apiKey.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public void GetContentFromFile_WithInvalidPathToFile_ReturnFileNotFoundException()
    {
        FileSystemService fileSystemService = Setup();

        var correctPathToFile =
            $"{Directory.GetParent(Environment.CurrentDirectory)?.Parent?.Parent?.FullName}/test.env";

        Func<Task> act = async () => await fileSystemService.GetContentFromFile(correctPathToFile);

        act.Should().ThrowAsync<FileNotFoundException>();
    }

    [Fact]
    public void GetPathToApiKey()
    {
        FileSystemService fileSystemService = Setup();

        var path = fileSystemService.GetSolutionPath();

        path.Should().NotBeNullOrWhiteSpace();
    }

    private FileSystemService Setup() => new();
}