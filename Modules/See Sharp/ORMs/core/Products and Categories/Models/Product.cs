#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Products_and_Categories.Models;

public class Product
{
  [Key]
  public int ProductId { get; set; }

  [Required]
  [MaxLength(45)]
  public string Name { get; set; }

  public string? Description { get; set; }

  [Column(TypeName = "decimal(18,2)")]
  public decimal Price { get; set; }

  public DateTime CreatedAt { get; set; } = DateTime.Now;
  public DateTime UpdatedAt { get; set; } = DateTime.Now;

  public List<Association> Associations { get; set; } = new List<Association>();
}
