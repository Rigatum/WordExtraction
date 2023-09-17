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
    
    public async Task<HashSet<string>> GetUniqueWordsAsync(IFormFile formFile)
    {
        var text = await formFile.ReadAsync(_typeRead);

        return text;
    }
}