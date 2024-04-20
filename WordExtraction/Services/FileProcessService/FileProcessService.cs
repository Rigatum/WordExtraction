using WordExtraction.Extensions;
using WordExtraction.Services.ReadStrategy;
using WordExtraction.Services.TranslateService;

namespace WordExtraction.Services.FileProcessService;

public class FileProcessService : IFileProcessService
{
    private ITypeRead _typeRead = null!;
    private readonly ITranslateService _translateService;

    public FileProcessService(ITranslateService translateService)
    {
        _translateService = translateService;
    }

    public async Task<Dictionary<string, int>> GetUniqueWordsAsync(IFormFile formFile, ITypeRead typeRead)
    {
        _typeRead = typeRead;

        var text = await formFile.ReadAsync(_typeRead);

        var words = text
            .Where(d => d.Value > 200)
            .OrderByDescending(d => d.Value)
            .Select(d => d.Key);

        _ = await _translateService.TranslateAsync(words, "en", "ru");

        return text;
    }
}