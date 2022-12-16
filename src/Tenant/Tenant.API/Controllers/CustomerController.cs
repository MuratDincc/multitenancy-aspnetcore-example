using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Infrastructure.Common;
using Tenant.API.Data.Entities;
using Tenant.API.Models.Customer;
using Tenant.API.Services;

namespace Tenant.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    #region Fields

    private readonly IWorkContext _workContext;
    private readonly ICustomerService _customerService;

    #endregion

    #region Ctor

    /// <summary>
    /// CustomerController
    /// </summary>
    /// <param name="workContext"></param>
    /// <param name="customerService"></param>
    public CustomerController(IWorkContext workContext, ICustomerService customerService)
    {
        this._workContext = workContext;
        this._customerService = customerService;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Get Products
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Customer>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Get()
    {
        return Ok(_customerService.GetAll());
    }

    /// <summary>
    /// Get Product By Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Customer))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Get(int id)
    {
        var customer = _customerService.GetById(id);

        if (customer == null)
        {
            return NotFound();
        }

        return Ok(customer);
    }

    /// <summary>
    /// Insert Customer
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Post([FromBody] CustomerInsertModel model)
    {
        var customer = _customerService.Insert(model);

        if (customer == null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        return Ok(customer);
    }

    /// <summary>
    /// Update Customer
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Put(CustomerUpdateModel model)
    {
        var customer = _customerService.Update(model);

        if (customer == null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        return Ok(customer);
    }

    /// <summary>
    /// Delete Customer
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Delete(int id)
    {
        var customer = _customerService.Delete(id);

        if (customer == null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        return Ok(customer);
    }

    #endregion
}