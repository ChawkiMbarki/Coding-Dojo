using Microsoft.AspNetCore.Mvc;

namespace Contact.Controllers;

public class ContactController : Controller   // Remember inheritance?    
{
    [HttpGet("/Contact")]
    public string Contact()
    {
        return "This is my Contact!";
    }
}