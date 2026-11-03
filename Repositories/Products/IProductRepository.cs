using Indomaret.Api.Models;

namespace Indomaret.Api.Repositories.Products;

public interface IProductRepository
{
  IReadOnlyList<Product> GetAll();
  Product? GetByCode(string code);
  bool TryAdd(Product product);
  bool TryUpdate(Product product);
  bool TryDelete(string code);
}