namespace WordExtraction.Models
{
    public class TranslateWordsModel
    {
        public string SourceLanguage { get; set; }
        public string TargetLanguage { get; set; }
        public IEnumerable<string> Words { get; set; }

        public TranslateWordsModel(string sourceLanguage, string targetLanguage, IEnumerable<string> words)
        {
            SourceLanguage = sourceLanguage;
            TargetLanguage = targetLanguage;
            Words = words;
        }
    }
}
