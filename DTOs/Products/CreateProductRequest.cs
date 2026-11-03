using System.ComponentModel.DataAnnotations;

namespace Indomaret.Api.DTOs.Products;

public sealed class CreateProductRequest()
{
  [Required, StringLength(30)]
  public required string Code{get; init;} = string.Empty;
  [Required, StringLength(100)]
  public required string Name{get; init;} = string.Empty;
  [Required, Range(typeof(decimal), "0", "10000000.99", ParseLimitsInInvariantCulture = true, ConvertValueInInvariantCulture = true)]
  public required decimal Price{get; init;}
  [Required, Range(0, int.MaxValue)]
  public required int Stock{get; init;}
  [Required, StringLength(100)]
  public required string Category{get; init;}
}