using WordExtraction.Services;
using WordExtraction.Services.ReadStrategy;

namespace WordExtraction.Extensions;

public static class ServiceRegistry
{
    public static void AddCustomServices(this IServiceCollection services)
    {
        services.AddSingleton<IFileProcess, FileProcess>();
    }
}