using Auth.API.Data.Entities;
using Shared.Domain.Models;
using Shared.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Auth.API.Services;

public class UserService : IUserService
{
    #region Fields

    private readonly IRepository<Company> _companyRepository;
    private readonly IRepository<Company_User_Mapping> _companyUserMappingRepository;
    private readonly IRepository<Pool> _poolRepository;
    private readonly IRepository<User> _userRepository;

    #endregion

    #region Ctor

    public UserService(IRepository<Company> companyRepository, IRepository<Company_User_Mapping> companyUserMappingRepository, IRepository<Pool> poolRepository, IRepository<User> userRepository)
    {
        this._companyRepository = companyRepository;
        this._companyUserMappingRepository = companyUserMappingRepository;
        this._poolRepository = poolRepository;
        this._userRepository = userRepository;
    }

    #endregion

    #region Methods

    public TenantInfo Login(int companyId, string email, string password)
    {
        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            return null;
       
        var user = _userRepository.Find(expression: x => x.Email == email && x.Password == password, include: source => source.Include(y => y.Company_User_Mappings).ThenInclude(x => x.Company).ThenInclude(x => x.Pool)).FirstOrDefault();

        if (user == null || user.Id == 0)
            return null;

        var companyUserMapping = user.Company_User_Mappings.Where(x => x.CompanyId == companyId).FirstOrDefault();

        if (companyUserMapping == null || companyUserMapping.Id == 0)
            return null;

        var company = companyUserMapping.Company;

        if (company == null || company.Id == 0)
            return null;

        var pool = company.Pool;

        if (pool == null || pool.Id == 0)
            return null;

        TenantInfo tenantInfo = new TenantInfo()
        {
            Company = new TenantInfo.TenantCompany()
            {
                Id = company.Id,
                Name = company.Name,
                ApiKey = company.ApiKey,
                SecretKey = company.SecretKey
            },
            Database = new TenantInfo.TenantDatabase()
            {
                DatabaseName = company.DatabaseName,
                Host = pool.Host,
                Username = pool.Username,
                Password = pool.Password
            },
            User = new TenantInfo.TenantUser()
            {
                Id = user.Id,
                Email = user.Email
            }
        };

        return tenantInfo;
    }

    #endregion
}