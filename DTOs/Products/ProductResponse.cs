using Indomaret.Api.Models;

namespace Indomaret.Api.DTOs.Products;

public sealed record ProductResponse(string Code, string Name, decimal Price, int Stock, string Category)
{
  public static ProductResponse FromModel(Product product) => new(product.Code, product.Name, product.Price, product.Stock, product.Category);
}