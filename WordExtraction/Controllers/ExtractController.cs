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
    
    // GET
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> UploadFile(IFormFile file)
    {
        using (var fileStream = file.OpenReadStream())
        {
            using (var memoryStream = new MemoryStream())
            {
                _fileProcess.SetFileRead(new WebPageByUriRead());
                _fileProcess.GetUniqueWords();
                
                await fileStream.CopyToAsync(memoryStream);
            }
        }
        
        return Ok("Файл успешно обработан.");
    }
}