using System.Text.Json;
using FluentAssertions;
using FluentAssertions.Execution;
using WordExtraction.Models;
using WordExtraction.Services.StringContentConverter;

namespace WordExtraction.Tests.ServiceTests;

public class StringContentConverterServiceTests
{
    [Theory]
    [InlineData("de", "ru", new[] { "car", "mother" })]
    [InlineData("ru", "de", new[] { "" })]
    [InlineData("de", "en", new[] { "324" })]
    [InlineData("de", "en", new[] { "polizei", "pferd" })]
    [InlineData("de", "en", new[] { "polizei", "pferd", "dsf", "" })]
    public async Task Convert(string sourceLanguage, string targetLanguage, IEnumerable<string> words)
    {
        var stringContentConverterService = new StringContentConverterService();

        var content = await stringContentConverterService.Convert(sourceLanguage, targetLanguage, words);

        using (new AssertionScope())
        {
            content.Should().NotBeNull();
            content.Should().BeOfType(typeof(StringContent));

            var reader = await content.ReadAsStreamAsync();

            var deserializeObject = await JsonSerializer.DeserializeAsync(reader, typeof(TranslateWordsModel));

            deserializeObject.Should().NotBeNull();

            var model = (TranslateWordsModel)deserializeObject!;

            model.SourceLanguage.Should().NotBeNullOrWhiteSpace();
            model.TargetLanguage.Should().NotBeNullOrWhiteSpace();
            model.Words.Should().NotBeNullOrEmpty();
            model.Words.Should().AllBeOfType(typeof(string));
            model.SourceLanguage.Should().BeEquivalentTo(sourceLanguage);
            model.TargetLanguage.Should().BeEquivalentTo(targetLanguage);
            model.Words.Should().HaveSameCount(words);
            model.Words.Should().BeEquivalentTo(words);
        }
    }
}