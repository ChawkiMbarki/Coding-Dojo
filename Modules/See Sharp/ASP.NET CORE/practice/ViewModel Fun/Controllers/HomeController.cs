using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ViewModel_Fun.Models;

namespace ViewModel_Fun.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var a = new MessageViewModel
        {
            Message = "Here is a message"
        };
        return View(a);
    }

    public IActionResult Numbers()
    {
        var b = new NumbersViewModel
        {
            Numbers = new int[] { 1, 2, 10, 21, 8, 7, 3 }
        };
        return View(b);
    }

    public IActionResult User()
    {
        var c = new SingleUserViewModel
        {
            User = new User { FirstName = "Neil", LastName = "Gaiman" }
        };
        return View(c);
    }

    public IActionResult Users()
    {
        var d = new UsersListViewModel
        {
            Users = new List<User>
            {
                new User { FirstName = "Neil", LastName = "Gaiman" },
                new User { FirstName = "Terry", LastName = "Pratchett" },
                new User { FirstName = "Jane", LastName = "Austen" },
                new User { FirstName = "Stephen", LastName = "King" },
                new User { FirstName = "Mary", LastName = "Shelley" }
            }
        };
        return View(d);
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
