using Microsoft.AspNetCore.Mvc;

namespace SurveyController.Controllers
{
  public class SurveyController : Controller
  {
    [HttpGet("")]
    public IActionResult Index()
    {
      return View();
    }

    [HttpPost("SubmitForm")]
    public IActionResult SubmitForm(string name, string location, string language, string comment)
    {
      return RedirectToAction("Results", new { name = name, location = location, language = language, comment = comment });
    }

    [HttpGet("Results")]
    public IActionResult Results(string name, string location, string language, string comment)
    {
      ViewBag.Name = name;
      ViewBag.Location = location;
      ViewBag.Language = language;
      ViewBag.Comment = comment;
      return View();
    }
  }
}
