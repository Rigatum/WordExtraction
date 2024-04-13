using Microsoft.AspNetCore.Mvc;
using WordExtraction.Services;
using WordExtraction.Services.ReadStrategy;

namespace WordExtraction.Controllers;

public class ExtractController : Controller
{
    private readonly IFileProcess _fileProcess;

    public ExtractController(IFileProcess fileProcess)
    {
        _fileProcess = fileProcess;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    [RequestSizeLimit(500000000)]
    public async Task<ActionResult> UploadFile(IFormFile file)
    {
        _fileProcess.SetFileRead(new PdfRead());
        var wordsAndFrequencyDict = await _fileProcess.GetUniqueWordsAsync(file);

        return Ok(wordsAndFrequencyDict.OrderByDescending(x => x.Value));
    }
}