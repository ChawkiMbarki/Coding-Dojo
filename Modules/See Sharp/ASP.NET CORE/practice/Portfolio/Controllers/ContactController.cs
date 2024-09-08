using Microsoft.AspNetCore.Mvc;

namespace Contact.Controllers;

public class ContactController : Controller   // Remember inheritance?    
{
    [HttpGet("Contact")]
    public ViewResult Contact()
    {
        return View("Contact");
    }
}