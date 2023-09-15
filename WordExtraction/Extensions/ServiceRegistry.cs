using WordExtraction.Services;

namespace WordExtraction.Extensions;

public static class ServiceRegistry
{
    public static void AddCustomServices(this IServiceCollection services)
    {
        services.AddSingleton<IFileProcessing, FileProcessing>();
    }
}