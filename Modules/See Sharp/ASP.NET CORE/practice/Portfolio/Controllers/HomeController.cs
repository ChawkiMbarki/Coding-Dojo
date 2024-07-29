using Microsoft.AspNetCore.Mvc;

namespace HomeController.Controllers;

public class HomeController : Controller
{
    [HttpGet("")]
    public string Index()
    {
        return "This is my Index!";
    }
}