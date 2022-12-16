using Tenant.API.Data.Entities;
using Tenant.API.Models.Product;

namespace Tenant.API.Services;

public interface IProductService
{
    IEnumerable<Product> GetAll();

    Product GetById(int id);

    Product Insert(ProductInsertModel productInsertModel);
    Product Update(ProductUpdateModel productUpdateModel);
    Product Delete(int id);
}