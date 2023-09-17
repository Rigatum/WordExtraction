using System.Collections;
using WordExtraction.Services.ReadStrategy;

namespace WordExtraction.Services;

public interface IFileProcess
{
    HashSet<string> GetUniqueWords(IFormFile formFile);
    void SetFileRead(ITypeRead typeRead);
}