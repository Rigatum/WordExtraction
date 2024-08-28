using FluentAssertions;
using FluentAssertions.Execution;
using WordExtraction.Models;

namespace WordExtraction.Tests.Models;

public class TranslateWordsModelTests
{
    [Theory]
    [InlineData("de", "ru", new[] { "car", "mother" })]
    [InlineData("ru", "de", new[] { "" })]
    [InlineData("de", "en", new[] { "324" })]
    [InlineData("de", "en", new[] { "polizei", "pferd" })]
    public void Constructor_WithArguments_Succeeds(string sourceLanguage, string targetLanguage, IEnumerable<string> words)
    {
        var translateWordsModel = CreateTranslateWordsModelWithCustomCtor(sourceLanguage, targetLanguage, words);

        using (new AssertionScope())
        {
            translateWordsModel.SourceLanguageCode.Should().NotBeNullOrWhiteSpace();
            translateWordsModel.TargetLanguageCode.Should().NotBeNullOrWhiteSpace();
            translateWordsModel.Words.Should().NotBeNullOrEmpty();
            translateWordsModel.Words.Should().AllBeOfType(typeof(string));
            translateWordsModel.SourceLanguageCode.Should().BeEquivalentTo(sourceLanguage);
            translateWordsModel.TargetLanguageCode.Should().BeEquivalentTo(targetLanguage);
            translateWordsModel.Words.Should().HaveSameCount(words);
            translateWordsModel.Words.Should().BeEquivalentTo(words);
        }
    }

    private TranslateWordsModel CreateTranslateWordsModelWithCustomCtor(string sourceLanguage,
        string targetLanguage, IEnumerable<string> words) => new(sourceLanguage, targetLanguage, words);
}