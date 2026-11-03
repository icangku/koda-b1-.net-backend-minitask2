using System.ComponentModel.DataAnnotations;

namespace Indomaret.Api.Models;

public sealed class Product(string productCode, string name, decimal price, int stock, string category)
{
  [Required]
  public string Code {get;} = productCode;
  [Required]
  public string Name {get;} = name;
  [Required, Range(0, double.PositiveInfinity)]
  public decimal Price {get;} = price;
  [Required, Range(0, int.MaxValue)]
  public int Stock {get;} = stock;
  [Required]
  public string Category {get; } = category;
}