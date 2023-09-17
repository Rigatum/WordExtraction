using System.Text;

namespace WordExtraction.Services.ReadStrategy;

public class MicrosoftWordRead : ITypeRead
{
    public Task<StringBuilder> ReadAsync(IFormFile formFile)
    {
        throw new NotImplementedException();
    }
}