namespace WordExtraction.Services.TranslateService
{
    public interface ITranslateService
    {
        public Task<string> TranslateViaYandexByHttpAsync(IEnumerable<string> words, string sourceLanguage, string targetLanguage);
    }
}
