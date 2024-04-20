namespace WordExtraction.Services.StringContentConverter
{
    public interface IStringContentConverter
    {
        public Task<StringContent> Convert(string sourceLanguage, string targetLanguage, IEnumerable<string> words);
    }
}
