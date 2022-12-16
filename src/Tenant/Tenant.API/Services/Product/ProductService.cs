using Shared.Infrastructure.Repository;
using Tenant.API.Data.Entities;
using Tenant.API.Models.Product;

namespace Tenant.API.Services;

public class ProductService : IProductService
{
    #region Fields

    private readonly IRepository<Product> _productRepository;

    #endregion

    #region Ctor

    public ProductService(IRepository<Product> productRepository)
    {
        this._productRepository = productRepository;
    }

    #endregion

    #region Methods

    public IEnumerable<Product> GetAll()
    {
        return _productRepository.Find(x => x.Deleted == false).ToList();
    }

    public Product GetById(int id)
    {
        return _productRepository.GetById(id);
    }

    public Product Insert(ProductInsertModel productInsertModel)
    {
        Product product = new Product()
        {
            Code = Guid.NewGuid(),
            Name = productInsertModel.Name,
            Price = productInsertModel.Price,
            Deleted = false,
            CreatedOnUtc = DateTime.UtcNow,
            UpdatedOnUtc = DateTime.UtcNow
        };

        _productRepository.Insert(product);
        _productRepository.Save();

        return product;
    }

    public Product Update(ProductUpdateModel productUpdateModel)
    {
        var product = _productRepository.GetById(productUpdateModel.Id);

        if (product == null)
        {
            return null;
        }

        product.Name = productUpdateModel.Name;
        product.Price = productUpdateModel.Price;
        product.UpdatedOnUtc = DateTime.UtcNow;

        _productRepository.Update(product);
        _productRepository.Save();

        return product;
    }

    public Product Delete(int id)
    {
        var product = _productRepository.GetById(id);

        if (product == null)
        {
            return null;
        }

        product.Deleted = true;
        product.UpdatedOnUtc = DateTime.UtcNow;

        _productRepository.Update(product);
        _productRepository.Save();

        return product;
    }

    #endregion
}
