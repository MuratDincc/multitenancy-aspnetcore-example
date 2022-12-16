using Tenant.API.Data.Entities;
using Tenant.API.Models.Customer;

namespace Tenant.API.Services;

public interface ICustomerService
{
    IEnumerable<Customer> GetAll();

    Customer GetById(int id);

    Customer Insert(CustomerInsertModel customerInsertModel);
    Customer Update(CustomerUpdateModel customerUpdateModel);
    Customer Delete(int id);
}