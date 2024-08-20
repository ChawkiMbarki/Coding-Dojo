#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace Session_Workshop.Models;

public class User
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }
    public int? Number { get; set; }
}


