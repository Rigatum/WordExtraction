using WordExtraction.Services.ReadStrategy;

namespace WordExtraction.Services;

public class FileProcess : IFileProcess
{
    private IRead _read;
    
    public void SetFileRead(IRead read)
    {
        _read = read;
    }
    
    public HashSet<string> GetUniqueWords()
    {
        _read.DoAlgorithm();
        
        throw new NotImplementedException();
    }
}