using System.Text.Json;

namespace WordExtraction.Services.StringContentConverter
{
    public class StringContentConverter : IStringContentConverter
    {
        public async Task<StringContent> Convert(string sourceLanguage, string targetLanguage, IEnumerable<string> words)
        {
            using var stream = new MemoryStream();

            var model = new
            {
                sourceLanguageCode = sourceLanguage,
                targetLanguageCode = targetLanguage,
                texts = string.Join(",", words)
            };

            await JsonSerializer.SerializeAsync(stream, model, model.GetType());
            stream.Position = 0;
            using var reader = new StreamReader(stream);
            var stringContent = await reader.ReadToEndAsync();

            return new StringContent(stringContent);
        }
    }
}
