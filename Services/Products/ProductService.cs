using Indomaret.Api.DTOs.Products;
using Indomaret.Api.Models;
using Indomaret.Api.Repositories.Products;

namespace Indomaret.Api.Services.Products;

public class ProductService(IProductRepository repository) : IProductService
{
  private readonly IProductRepository _repository = repository;

  ProductResponse? IProductService.Create(CreateProductRequest request)
  {
    var product = new Product(request.Code, request.Name, request.Price, request.Stock, request.Category);

    return _repository.TryAdd(product) ? ProductResponse.FromModel(product) : null;
  }

  bool IProductService.Delete(string productCode)
  {
    return _repository.TryDelete(productCode);
  }

  IReadOnlyList<ProductResponse> IProductService.GetAll()
  {
    return _repository.GetAll().Select(ProductResponse.FromModel).ToArray();
  }

  ProductResponse? IProductService.GetByCode(string productCode)
  {
    var product = _repository.GetByCode(productCode);
    return product is null ? null : ProductResponse.FromModel(product);
  }

  ProductResponse? IProductService.Update(string productCode, UpdateProductRequest request)
  {
    var product = new Product(productCode, request.Name, request.Price, request.Stock, request.Category);
    return _repository.TryUpdate(product) ? ProductResponse.FromModel(product) : null;
  }
}