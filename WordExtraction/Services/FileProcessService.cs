using WordExtraction.Extensions;
using WordExtraction.Services.ReadStrategy;

namespace WordExtraction.Services;

public class FileProcessService : IFileProcessService
{
    private ITypeRead _typeRead;
    private readonly ITranslateService _translateService;

    public FileProcessService(ITranslateService translateService)
    {
        _translateService = translateService;
    }

    public void SetFileRead(ITypeRead typeRead)
    {
        _typeRead = typeRead;
    }
    
    public async Task<Dictionary<string, int>> GetUniqueWordsAsync(IFormFile formFile)
    {
        var text = await formFile.ReadAsync(_typeRead);

        var words = text
            .Where(d => d.Value > 50)
            .Select(d => d.Key);

        _ = _translateService.TranslateAsync(words, "ru", "en");

        return text;
    }
}