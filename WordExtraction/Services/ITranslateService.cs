namespace WordExtraction.Services
{
    public interface ITranslateService
    {
        public Task<string> TranslateAsync(IEnumerable<string> words, string sourceLanguage, string targetLanguage);
    }
}
