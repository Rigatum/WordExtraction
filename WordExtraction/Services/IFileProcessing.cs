using System.Collections;

namespace WordExtraction.Services;

public interface IFileProcessing
{
    HashSet<string> GetUniqueWords();
}