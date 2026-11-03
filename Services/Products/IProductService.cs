using Indomaret.Api.DTOs.Products;

namespace Indomaret.Api.Services.Products;

public interface IProductService
{
   IReadOnlyList<ProductResponse> GetAll();
    ProductResponse? GetByCode(string productCode);
    ProductResponse? Create(CreateProductRequest request);
    ProductResponse? Update(string productCode, UpdateProductRequest request);

    bool Delete(string productCode);
}