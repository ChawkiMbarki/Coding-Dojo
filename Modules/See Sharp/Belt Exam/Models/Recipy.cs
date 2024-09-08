#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Belt_Exam.Models;

public class Recipy
{
  [Key]
  public int Id { get; set; }

  [Required]
  public string Title { get; set; }

  [Required]
  public string Ingredient1 { get; set; }
  [Required]
  public string Ingredient2 { get; set; }
  [Required]
  public string Ingredient3 { get; set; }
  [Required]
  public string Ingredient4 { get; set; }
  [Required]
  public string Ingredient5 { get; set; }

  [Required]
  public bool Vegitarian { get; set; } = false;

  [Required]
  public bool Gluten { get; set; } = false;

  [Required]
  public string Instructions { get; set; }

  [Required]
  public int CreatorId { get; set; }

  public User? Creator { get; set; }
  public List<Rating> Ratings { get; set; } = new List<Rating>();
}

