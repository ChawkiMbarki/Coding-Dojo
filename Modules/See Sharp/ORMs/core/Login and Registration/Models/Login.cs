#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace Login_and_Registration.Models;

public class Login
{
  [Required]
  [EmailAddress]
  public string LoginEmail { get; set; }

  [Required]
  [DataType(DataType.Password)]
  public string LoginPassword { get; set; }
}

