using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Countdown.Models;

namespace Countdown.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        CountdownModel model = new CountdownModel
        {
            StartTime = DateTime.Now,
            EndTime = new DateTime(2026, 12, 31, 7, 0, 0)
        };
        return View(model);
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
