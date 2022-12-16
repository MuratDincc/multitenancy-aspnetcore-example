using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Infrastructure.Common;
using Tenant.API.Data.Entities;
using Tenant.API.Models.Product;
using Tenant.API.Services;

namespace Tenant.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    #region Fields

    private readonly IWorkContext _workContext;
    private readonly IProductService _productService;

    #endregion

    #region Ctor

    /// <summary>
    /// ProductController
    /// </summary>
    /// <param name="workContext"></param>
    /// <param name="productService"></param>
    public ProductController(IWorkContext workContext, IProductService productService)
    {
        this._workContext = workContext;
        this._productService = productService;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Get Products
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Product>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Get()
    {
        return Ok(_productService.GetAll());
    }

    /// <summary>
    /// Get Product By Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Get(int id)
    {
        var product = _productService.GetById(id);

        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    /// <summary>
    /// Insert Product
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Post([FromBody] ProductInsertModel model)
    {
        var product = _productService.Insert(model);

        if (product == null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        return Ok(product);
    }

    /// <summary>
    /// Update Product
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Put(ProductUpdateModel model)
    {
        var product = _productService.Update(model);

        if (product == null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        return Ok(product);
    }

    /// <summary>
    /// Delete Product
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Delete(int id)
    {
        var product = _productService.Delete(id);

        if (product == null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        return Ok(product);
    }

    #endregion
}