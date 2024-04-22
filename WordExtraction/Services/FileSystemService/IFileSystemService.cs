namespace WordExtraction.Services.FileSystemService
{
    public interface IFileSystemService
    {
        public Task<string> GetContentFromFile(string path);
        public string? GetSolutionPath();
    }
}
