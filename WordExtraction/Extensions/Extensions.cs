using System.Text.RegularExpressions;
using WordExtraction.Services;
using WordExtraction.Services.ReadStrategy;

namespace WordExtraction.Extensions;

public static class Extensions
{
    public static void AddCustomServices(this IServiceCollection services)
    {
        services.AddTransient<IFileProcess, FileProcess>();
    }
    
    public static async Task<Dictionary<string, int>> ReadAsync(this IFormFile formFile, ITypeRead typeRead)
    {
        var textStringBuilder = await typeRead.ReadAsync(formFile);
        string text = textStringBuilder.ToString();
        text = Regex.Replace(text, @"[^\u0000-\u007F]+", string.Empty);
        text = Regex.Replace(text, @"[^a-zA-Z]+", " ").ToLower();
        string[] words = Regex.Split(text, @"\s+");
        var wordsByFrequencyDict = words
            .GroupBy(w => w)
            .ToDictionary(g => g.Key, g => g.Count());

        return wordsByFrequencyDict;
    }
}