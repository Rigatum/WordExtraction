﻿using System.Text.Json;
using WordExtraction.Models;

namespace WordExtraction.Services.StringContentConverter
{
    public class StringContentConverter : IStringContentConverter
    {
        public async Task<StringContent> Convert(string sourceLanguage, string targetLanguage, IEnumerable<string> words)
        {
            using var stream = new MemoryStream();

            var model = new TranslateWordsModel(sourceLanguage, targetLanguage, words);

            await JsonSerializer.SerializeAsync(stream, model, model.GetType());

            stream.Position = 0;

            using var reader = new StreamReader(stream);

            var stringContent = await reader.ReadToEndAsync();

            return new StringContent(stringContent);
        }
    }
}
