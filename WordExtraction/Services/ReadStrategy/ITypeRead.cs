using System.Text;

namespace WordExtraction.Services.ReadStrategy;

public interface ITypeRead
{
    StringBuilder Read(IFormFile formFile);
}