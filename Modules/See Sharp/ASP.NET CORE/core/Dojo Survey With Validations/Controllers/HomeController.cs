using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Dojo_Survey_With_Validations.Models;

namespace Dojo_Survey_With_Validations.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Result(Survey survey)
    {
        if (!ModelState.IsValid)
        {
            return View("Index", survey);
        }

        ViewBag.Name = survey.Name;
        ViewBag.Location = survey.Location;
        ViewBag.Language = survey.Language;
        ViewBag.Comment = survey.Comment;

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
