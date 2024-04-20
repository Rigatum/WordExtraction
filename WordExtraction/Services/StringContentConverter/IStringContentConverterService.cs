namespace WordExtraction.Services.StringContentConverter
{
    public interface IStringContentConverterService
    {
        public Task<StringContent> Convert(string sourceLanguage, string targetLanguage, IEnumerable<string> words);
    }
}
