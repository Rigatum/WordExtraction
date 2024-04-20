using WordExtraction.Services.ReadStrategy;

namespace WordExtraction.Services.FileProcessService;

public interface IFileProcessService
{
    Task<Dictionary<string, int>> GetUniqueWordsAsync(IFormFile formFile, ITypeRead typeRead);
}