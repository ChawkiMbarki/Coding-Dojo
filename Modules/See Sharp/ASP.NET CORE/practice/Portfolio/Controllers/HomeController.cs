using Microsoft.AspNetCore.Mvc;

namespace HomeController.Controllers;

public class HomeController : Controller
{
    [HttpGet("")]
    public ViewResult Index()
    {
        return View();
    }
}