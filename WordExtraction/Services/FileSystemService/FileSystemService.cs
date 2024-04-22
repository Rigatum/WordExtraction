namespace WordExtraction.Services.FileSystemService;

public class FileSystemService : IFileSystemService
{
    public async Task<string> GetContentFromFile(string path) => await File.ReadAllTextAsync(path);

    public string? GetSolutionPath() => Directory.GetParent(Environment.CurrentDirectory)?.FullName;
}