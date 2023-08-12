using Microsoft.AspNetCore.Mvc;

namespace WordExtraction.Controllers;

public class Extract : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}