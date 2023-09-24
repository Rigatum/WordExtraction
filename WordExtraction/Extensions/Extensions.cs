using System.Text.RegularExpressions;
using WordExtraction.Services;
using WordExtraction.Services.ReadStrategy;

namespace WordExtraction.Extensions;

public static class Extensions
{
    public static void AddCustomServices(this IServiceCollection services)
    {
        services.AddSingleton<IFileProcess, FileProcess>();
    }
    
    public static async Task<HashSet<string>> ReadAsync(this IFormFile formFile, ITypeRead typeRead)
    {
        var textStringBuilder=  await typeRead.ReadAsync(formFile);
        string text = textStringBuilder.ToString();
        text = Regex.Replace(text, @"[^\u0000-\u007F]+", string.Empty);
        text = Regex.Replace(text, @"[^a-zA-Z]+", " ");
        string[] words = Regex.Split(text, @"\s+");
        
        HashSet<string> hashSet = new HashSet<string>(words);

        return hashSet;
    }
}