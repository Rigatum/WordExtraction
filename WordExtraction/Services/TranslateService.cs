using System.Text.Json;

namespace WordExtraction.Services
{
    public class TranslateService : ITranslateService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TranslateService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string> TranslateAsync(IEnumerable<string> words, string sourceLanguage, string targetLanguage)
        {
            var httpClient = _httpClientFactory.CreateClient();

            var solutionPath = Directory.GetParent(Environment.CurrentDirectory)?.FullName;
            string apiKey = GetApiKey(solutionPath).Result;

            httpClient.DefaultRequestHeaders.Add("Authorization", $"Api-Key {apiKey}");

            var json = new StringContent(TransformWordsToJson(sourceLanguage, targetLanguage, words).Result);

            return await httpClient.PostAsync(new Uri("https://translate.api.cloud.yandex.net/translate/v2/translate"), json).Result.Content.ReadAsStringAsync();
        }

        public async Task<string> GetApiKey(string path) =>  await File.ReadAllTextAsync($"{path}/test.env");

        public async Task<string> TransformWordsToJson(string sourceLanguage, string targetLanguage, IEnumerable<string> words)
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

            return stringContent;
        }
    }
}
