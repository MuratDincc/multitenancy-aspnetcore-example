using Shared.Infrastructure.Repository;
using Tenant.API.Data.Entities;
using Tenant.API.Models.Customer;

namespace Tenant.API.Services;

public class CustomerService : ICustomerService
{
    #region Fields

    private readonly IRepository<Customer> _customerRepository;

    #endregion

    #region Ctor

    public CustomerService(IRepository<Customer> customerRepository)
    {
        this._customerRepository = customerRepository;
    }

    #endregion

    #region Methods

    public IEnumerable<Customer> GetAll()
    {
        return _customerRepository.Find(x => x.Deleted == false).ToList();
    }

    public Customer GetById(int id)
    {
        return _customerRepository.GetById(id);
    }

    public Customer Insert(CustomerInsertModel customerInsertModel)
    {
        Customer customer = new Customer()
        {
            Code = Guid.NewGuid(),
            FirstName = customerInsertModel.FirstName,
            LastName = customerInsertModel.LastName,
            Email = customerInsertModel.Email,
            Deleted = false,
            CreatedOnUtc = DateTime.UtcNow,
            UpdatedOnUtc = DateTime.UtcNow
        };

        _customerRepository.Insert(customer);
        _customerRepository.Save();

        return customer;
    }

    public Customer Update(CustomerUpdateModel customerUpdateModel)
    {
        var customer = _customerRepository.GetById(customerUpdateModel.Id);

        if (customer == null)
        {
            return null;
        }

        customer.FirstName = customerUpdateModel.FirstName;
        customer.LastName = customerUpdateModel.LastName;
        customer.Email = customerUpdateModel.Email;
        customer.UpdatedOnUtc = DateTime.UtcNow;

        _customerRepository.Update(customer);
        _customerRepository.Save();

        return customer;
    }

    public Customer Delete(int id)
    {
        var customer = _customerRepository.GetById(id);

        if (customer == null)
        {
            return null;
        }

        customer.Deleted = true;
        customer.UpdatedOnUtc = DateTime.UtcNow;

        _customerRepository.Update(customer);
        _customerRepository.Save();

        return customer;
    }

    #endregion
}
