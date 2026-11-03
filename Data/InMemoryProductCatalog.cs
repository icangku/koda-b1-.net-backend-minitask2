using Indomaret.Api.Models;

namespace Indomaret.Api.Data;

public class InMemoryProductCatalog
{
  private readonly object _sync = new();
  private readonly List<Product> _products = [];

  public IReadOnlyList<Product> GetAll()
  {
    lock (_sync)
    {
      return _products.ToArray();
    }
  }

  public Product? GetByCode(string code)
  {
    lock (_sync)
    {
      return _products.FirstOrDefault(p => string.Equals(p.Code, code.Trim(), StringComparison.OrdinalIgnoreCase));
    }
  }

  public bool TryCreateProduct(Product product)
  {
    lock (_sync)
    {
      if(_products.Any(p => string.Equals(p.Code, product.Code, StringComparison.OrdinalIgnoreCase)))
      {
        return false;
      }
      _products.Add(product);
      return true;
    }
  }

  public bool TryRemove(string code)
  {
    lock (_sync)
    {
      var index = _products.FindIndex(p => string.Equals(p.Code, code.Trim(), StringComparison.OrdinalIgnoreCase));

      if(index < 0) return false;

      _products.RemoveAt(index);
      return true;
    }
  }

  public bool TryUpdateProduct(Product product)
  {
    lock (_sync)
    {
      var index = _products.FindIndex(p => string.Equals(p.Code, product.Code, StringComparison.OrdinalIgnoreCase));

      if(index < 0) return false;

      _products[index] = product;

      return true;
    }
  }
}