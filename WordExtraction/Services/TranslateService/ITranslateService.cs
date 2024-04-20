namespace WordExtraction.Services.TranslateService
{
    public interface ITranslateService
    {
        public Task<string> TranslateAsync(IEnumerable<string> words, string sourceLanguage, string targetLanguage);
    }
}
