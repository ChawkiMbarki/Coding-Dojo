using Microsoft.AspNetCore.Mvc;

namespace Projects.controller;

public class ProjectsController : Controller
{
    [HttpGet("Projects")]
    public ViewResult Projects()
    {
        return View("Projects");
    }
}
