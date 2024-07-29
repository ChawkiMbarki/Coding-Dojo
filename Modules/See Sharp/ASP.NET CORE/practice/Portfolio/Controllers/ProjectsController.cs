using Microsoft.AspNetCore.Mvc;

namespace Projects.controller;

public class ProjectsController : Controller
{
    [HttpGet("/Projects")]
    public string Projects()
    {
        return "These are my projects";
    }
}
