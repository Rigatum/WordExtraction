using WordExtraction.Services.ReadStrategy;

namespace WordExtraction.Services.FileProcessService;

public interface IFileProcessService
{
    Task<Dictionary<string, int>> GetUniqueWordsAsync(IFormFile formFile);
    public void SetTypeRead(ITypeRead typeRead);
}