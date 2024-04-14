namespace WordExtraction.Services
{
    public interface ITranslateService
    {
        public Task TranslateAsync(IEnumerable<string> words);
    }
}
