using System.Text;

namespace WordExtraction.Services.ReadStrategy;

public interface ITypeRead
{
    Task<StringBuilder> ReadAsync(IFormFile formFile);
}