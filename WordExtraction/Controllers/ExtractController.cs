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
    public async Task<ActionResult> UploadFile(IFormFile file)
    {
        _fileProcess.SetFileRead(new PdfRead());
        var q = await _fileProcess.GetUniqueWordsAsync(file);
        
        
        return Ok(q);
    }
}