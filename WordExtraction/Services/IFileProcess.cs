using System.Collections;
using WordExtraction.Services.ReadStrategy;

namespace WordExtraction.Services;

public interface IFileProcess
{
    HashSet<string> GetUniqueWords();
    void SetFileRead(IRead read);
}