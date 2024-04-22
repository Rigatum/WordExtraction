using WordExtraction.Services.FileSystemService;
using WordExtraction.Services.StringContentConverter;

namespace WordExtraction.Services.TranslateService
{
    public class TranslateService : ITranslateService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IFileSystemService _fileSystemService;
        private readonly IStringContentConverterService _stringContentConverter;

        public TranslateService(IHttpClientFactory httpClientFactory, IFileSystemService apiKeyService,
            IStringContentConverterService stringContentConverter)
        {
            _httpClientFactory = httpClientFactory;
            _fileSystemService = apiKeyService;
            _stringContentConverter = stringContentConverter;
        }
         
        public async Task<string> TranslateViaYandexByHttpAsync(IEnumerable<string> words, string sourceLanguage, string targetLanguage)
        {
            var httpClient = _httpClientFactory.CreateClient();

            var solutionPath = _fileSystemService.GetSolutionPath();

            string apiKey = await _fileSystemService.GetContentFromFile($"{solutionPath}/test.env");

            httpClient.DefaultRequestHeaders.Add("Authorization", $"Api-Key {apiKey}");

            var json = await _stringContentConverter.Convert(sourceLanguage, targetLanguage, words);

            return await httpClient.PostAsync(new Uri("https://translate.api.cloud.yandex.net/translate/v2/translate"), json).Result.Content.ReadAsStringAsync();
        }
    }
}
