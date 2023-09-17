using WordExtraction.Services;
using WordExtraction.Services.ReadStrategy;

namespace WordExtraction.Extensions;

public static class Extensions
{
    public static void AddCustomServices(this IServiceCollection services)
    {
        services.AddSingleton<IFileProcess, FileProcess>();
    }
    
    public static HashSet<string> Read(this IFormFile formFile, ITypeRead typeRead)
    {
        typeRead.Read(formFile);
        throw new NotImplementedException();
    }
}