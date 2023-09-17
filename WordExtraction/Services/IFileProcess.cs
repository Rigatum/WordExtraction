using System.Collections;
using WordExtraction.Services.ReadStrategy;

namespace WordExtraction.Services;

public interface IFileProcess
{
    Task<HashSet<string>> GetUniqueWordsAsync(IFormFile formFile);
    void SetFileRead(ITypeRead typeRead);
}