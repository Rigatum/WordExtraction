using FluentAssertions;
using WordExtraction.Models;

namespace WordExtraction.Tests.Services;

public class TranslateWordsModelTests
{
    [Theory]
    [InlineData("de", "ru", new[] {"car", "mother"})]
    [InlineData("ru", "de", new[] {""})]
    [InlineData("de", "en", new[] {"324"})]
    [InlineData("de", "en", new[] {"polizei", "pferd"})]
    public void TranslateWordsModelConstructor(string sourceLanguage, string targetLanguage, IEnumerable<string> words)
    {
        var translateWordsModel = new TranslateWordsModel(sourceLanguage, targetLanguage, words);

        translateWordsModel.SourceLanguage.Should().BeEquivalentTo(sourceLanguage);
        translateWordsModel.TargetLanguage.Should().BeEquivalentTo(targetLanguage);
        translateWordsModel.Words.Should().HaveSameCount(words);
        translateWordsModel.Words.Should().BeEquivalentTo(words);
    }
}