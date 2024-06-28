namespace WordExtraction.Models
{
    public class TranslateWordsModel
    {
        public string SourceLanguageCode { get; set; }
        public string TargetLanguageCode { get; set; }
        public IEnumerable<string> Words { get; set; }

        public TranslateWordsModel(string sourceLanguageCode, string targetLanguageCode, IEnumerable<string> words)
        {
            SourceLanguageCode = sourceLanguageCode;
            TargetLanguageCode = targetLanguageCode;
            Words = words;
        }
    }
}
