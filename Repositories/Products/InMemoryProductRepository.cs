using Indomaret.Api.Data;
using Indomaret.Api.Models;

namespace Indomaret.Api.Repositories.Products;

public class InMemoryProductRepository(InMemoryProductCatalog catalog) : IProductRepository
{
  private readonly InMemoryProductCatalog _catalog = catalog;

  IReadOnlyList<Product> IProductRepository.GetAll() => _catalog.GetAll();

  Product? IProductRepository.GetByCode(string code) => _catalog.GetByCode(code);

  bool IProductRepository.TryAdd(Product product) => _catalog.TryCreateProduct(product);

  bool IProductRepository.TryDelete(string code) => _catalog.TryRemove(code);

  bool IProductRepository.TryUpdate(Product product) => _catalog.TryUpdateProduct(product);
}