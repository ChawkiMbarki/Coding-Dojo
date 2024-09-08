#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace Belt_Exam.Models;

public class User
{
  [Key]
  public int UserId { get; set; }

  [Required]
  [MinLength(2)]
  public string FirstName { get; set; }

  [Required]
  [MinLength(2)]
  public string LastName { get; set; }

  [Required]
  [EmailAddress]
  [UniqueEmail]
  public string Email { get; set; }

  [DataType(DataType.Password)]
  [PasswordCheck]
  public string Password { get; set; }

  public List<Recipy> RecipiesCreated { get; set; } = new List<Recipy>();
  public List<Rating> Ratings { get; set; } = new List<Rating>();

  public DateTime CreatedAt { get; set; } = DateTime.Now;
  public DateTime UpdatedAt { get; set; } = DateTime.Now;

  [NotMapped]
  [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
  public string PasswordConfirm { get; set; }
}

public class UniqueEmailAttribute : ValidationAttribute
{
  protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
  {
    if (value == null)
    {
      return new ValidationResult("Email is required!");
    }

    var context = (MyContext)validationContext.GetService(typeof(MyContext));
    if (context.Users.Any(e => e.Email == value.ToString()))
    {
      return new ValidationResult("Email must be unique!");
    }
    return ValidationResult.Success;
  }
}

public class PasswordCheckAttribute : ValidationAttribute
{
  protected override ValidationResult IsValid(object value, ValidationContext validationContext)
  {
    var password = value as string;

    if (string.IsNullOrWhiteSpace(password))
    {
      return new ValidationResult("Password is required!");
    }
    if (password.Length < 8)
    {
      return new ValidationResult("Password must be at least 8 characters long.");
    }
    if (!Regex.IsMatch(password, @"\d"))
    {
      return new ValidationResult("Password must contain at least one number.");
    }
    if (!Regex.IsMatch(password, @"[a-zA-Z]"))
    {
      return new ValidationResult("Password must contain at least one letter.");
    }
    if (!Regex.IsMatch(password, @"[\W_]"))
    {
      return new ValidationResult("Password must contain at least one special character.");
    }
    return ValidationResult.Success;
  }
}
