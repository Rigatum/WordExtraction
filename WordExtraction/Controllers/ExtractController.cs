using Microsoft.AspNetCore.Mvc;

namespace WordExtraction.Controllers;

public class ExtractController : Controller
{
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
                await fileStream.CopyToAsync(memoryStream);
            }
        }
        
        return Ok("Файл успешно обработан.");
    }
}