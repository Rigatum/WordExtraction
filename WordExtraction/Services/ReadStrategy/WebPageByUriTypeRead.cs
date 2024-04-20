using System.Text;

namespace WordExtraction.Services.ReadStrategy;

public class WebPageByUriTypeRead : ITypeRead
{
    public Task<StringBuilder> ReadAsync(IFormFile formFile)
    {
        throw new NotImplementedException();
    }
}