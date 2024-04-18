using System.Text.Json;

namespace WordExtraction.Services
{
    public class TranslateService : ITranslateService
    {
        private readonly IHttpClientFactory _factory;

        public TranslateService(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        public async Task<string> TranslateAsync(IEnumerable<string> words, string sourceLanguage, string targetLanguage)
        {
            var httpClient = _factory.CreateClient();

            string apiKey = GetApiKey().Result;

            httpClient.DefaultRequestHeaders.Add("Authorization", $"Api-Key {apiKey}");

            var json = new StringContent(TransformWordsToJson().Result);

            return await httpClient.PostAsync(new Uri("https://translate.api.cloud.yandex.net/translate/v2/translate"), json).Result.Content.ReadAsStringAsync();

            static async Task<string> GetApiKey() =>  await File.ReadAllTextAsync($"{Environment.CurrentDirectory}/test.env");

            async Task<string> TransformWordsToJson()
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
}
