using WordExtraction.Extensions;
using WordExtraction.Services.ReadStrategy;

namespace WordExtraction.Services;

public class FileProcess : IFileProcess
{
    private ITypeRead _typeRead;
    
    public void SetFileRead(ITypeRead typeRead)
    {
        _typeRead = typeRead;
    }
    
    public HashSet<string> GetUniqueWords(IFormFile formFile)
    {
        formFile.Read(_typeRead);
        
        throw new NotImplementedException();
    }
}