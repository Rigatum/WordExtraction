using System.Collections;
using WordExtraction.Services.ReadStrategy;

namespace WordExtraction.Services;

public interface IFileProcessService
{
    Task<Dictionary<string, int>> GetUniqueWordsAsync(IFormFile formFile);
    void SetFileRead(ITypeRead typeRead);
}