using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Session_Workshop.Models;

namespace Session_Workshop.Controllers;

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
    public IActionResult Index(User User)
    {
        if (ModelState.IsValid)
        {
            HttpContext.Session.SetString("Name", User.Name);
            HttpContext.Session.SetInt32("Number", 22);
            return RedirectToAction("Dashboard");
        }
        return View();
    }

    public IActionResult Dashboard()
    {
        string? Name = HttpContext.Session.GetString("Name");
        int? Number = HttpContext.Session.GetInt32("Number");
        if ((string?)Name == null)
        {
            return RedirectToAction("Index");
        }
        User User = new User
        {
            Name = Name,
            Number = Number
        };
        return View(User);
    }

    [HttpPost]
    public IActionResult Dashboard(string test)
    {
        Console.WriteLine(test);
        var a = HttpContext.Session.GetInt32("Number") ?? 22;

        switch (test)
        {
            case "1":
                a += 1;
                Console.WriteLine("111");
                break;
            case "2":
                a -= 1;
                Console.WriteLine("222");
                break;
            case "3":
                a *= 2;
                Console.WriteLine("333");
                break;
            case "4":
                a += new Random().Next(1, 11);
                Console.WriteLine("444");
                break;
        }

        HttpContext.Session.SetInt32("Number", a);
        return RedirectToAction("Dashboard");
    }

    [HttpPost]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
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
