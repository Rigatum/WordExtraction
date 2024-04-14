using System.Text;
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

        public async Task TranslateAsync(IEnumerable<string> words)
        {
            var httpClient = _factory.CreateClient();
            string workingDirectory = Environment.CurrentDirectory;
            var s = await File.ReadAllTextAsync($"{workingDirectory}/test.env");

            httpClient.DefaultRequestHeaders.Add("Authorization", $"Api-Key {s}");

            using StringContent jsonContent = new(
                JsonSerializer.Serialize(new
                {
                    sourceLanguageCode = "ru",
                    targetLanguageCode = "en",
                    texts = "машина"
                }),
                Encoding.UTF8,
                "application/json");

            var q = httpClient.PostAsync(new Uri("https://translate.api.cloud.yandex.net/translate/v2/translate"), jsonContent).Result.Content.ReadAsStringAsync().Result;
        }
    }
}
