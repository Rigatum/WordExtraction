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
            var httpClient = CreateHttpClient(_httpClientFactory);

            var solutionPath = Directory.GetParent(Environment.CurrentDirectory)?.FullName;

            string apiKey = GetApiKey(solutionPath).Result;

            AddHeadersForAuthorization(httpClient, "Authorization", $"Api-Key {apiKey}");

            var json = new StringContent(TransformWordsToJson(sourceLanguage, targetLanguage, words).Result);

            return await httpClient.PostAsync(new Uri("https://translate.api.cloud.yandex.net/translate/v2/translate"), json).Result.Content.ReadAsStringAsync();
        }

        public HttpClient CreateHttpClient(IHttpClientFactory httpClientFactory) => httpClientFactory.CreateClient();

        public async Task<string> GetApiKey(string path) =>  await File.ReadAllTextAsync($"{path}/test.env");

        public void AddHeadersForAuthorization(HttpClient httpClient, string name, string value) => httpClient.DefaultRequestHeaders.Add(name, value);

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
