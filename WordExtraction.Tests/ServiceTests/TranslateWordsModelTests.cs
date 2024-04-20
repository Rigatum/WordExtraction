﻿using FluentAssertions;
using FluentAssertions.Execution;
using WordExtraction.Models;

namespace WordExtraction.Tests.ServiceTests;

public class TranslateWordsModelTests
{
    [Theory]
    [InlineData("de", "ru", new[] { "car", "mother" })]
    [InlineData("ru", "de", new[] { "" })]
    [InlineData("de", "en", new[] { "324" })]
    [InlineData("de", "en", new[] { "polizei", "pferd" })]
    public void TranslateWordsModelConstructor(string sourceLanguage, string targetLanguage, IEnumerable<string> words)
    {
        var translateWordsModel = new TranslateWordsModel(sourceLanguage, targetLanguage, words);

        using (new AssertionScope())
        {
            translateWordsModel.SourceLanguage.Should().NotBeNullOrWhiteSpace();
            translateWordsModel.TargetLanguage.Should().NotBeNullOrWhiteSpace();
            translateWordsModel.Words.Should().NotBeNullOrEmpty();
            translateWordsModel.Words.Should().AllBeOfType(typeof(string));
            translateWordsModel.SourceLanguage.Should().BeEquivalentTo(sourceLanguage);
            translateWordsModel.TargetLanguage.Should().BeEquivalentTo(targetLanguage);
            translateWordsModel.Words.Should().HaveSameCount(words);
            translateWordsModel.Words.Should().BeEquivalentTo(words);
        }
    }
}